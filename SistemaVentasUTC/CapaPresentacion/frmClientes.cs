using CapaNegocio;
using CapaEntidad;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using ClosedXML.Excel;
namespace CapaPresentacion
{
    public partial class frmClientes : Form
    {
        private CN_Cliente objNegocio = new CN_Cliente();

        private int idClienteSeleccionado = 0;
        public frmClientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void CargarDatos()
        {
            List<Cliente> lista = objNegocio.Listar();
            dgvClientes.DataSource = lista;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente()
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

            string mensaje = string.Empty;

            int idGenerado = objNegocio.Registrar(obj, out mensaje);

            if (idGenerado != 0)
            {
                MessageBox.Show("Cliente guardado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatos();

                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtNombre.Focus();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
                idClienteSeleccionado = Convert.ToInt32(fila.Cells["IdCliente"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un cliente de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            Cliente obj = new Cliente()
            {
                IdCliente = idClienteSeleccionado, 
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

            string mensaje = string.Empty;
            bool respuesta = objNegocio.Editar(obj, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Cliente editado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos(); 
                Limpiar();     
                idClienteSeleccionado = 0; 
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un cliente de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Deseas eliminar este cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;
                bool respuesta = objNegocio.Eliminar(idClienteSeleccionado, out mensaje);

                if (respuesta)
                {
                    MessageBox.Show("Cliente eliminado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDatos(); 
                    Limpiar();     
                    idClienteSeleccionado = 0; 
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            // 1. Validar que la tabla de clientes tenga datos
            if (dgvClientes.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Elegir dónde guardar el PDF
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "PDF Files |*.pdf";
            guardar.FileName = "Reporte_Clientes.pdf";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Crear el documento PDF en formato horizontal
                    Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                    PdfWriter.GetInstance(doc, new FileStream(guardar.FileName, FileMode.Create));
                    doc.Open();

                    // 4. Agregar un título al documento
                    doc.Add(new Paragraph("Reporte de Clientes Registrados\n\n"));

                    // 5. Crear la tabla PDF midiendo las columnas de dgvClientes
                    PdfPTable tablaPdf = new PdfPTable(dgvClientes.Columns.Count);

                    // Copiar los encabezados grises
                    foreach (DataGridViewColumn columna in dgvClientes.Columns)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(columna.HeaderText));
                        celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                        tablaPdf.AddCell(celda);
                    }

                    // Copiar los datos de cada cliente fila por fila
                    foreach (DataGridViewRow fila in dgvClientes.Rows)
                    {
                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            // Si la celda está vacía, pone un texto en blanco
                            tablaPdf.AddCell(celda.Value?.ToString() ?? "");
                        }
                    }

                    // 6. Pegar la tabla en el documento y cerrarlo
                    doc.Add(tablaPdf);
                    doc.Close();

                    MessageBox.Show("Reporte de clientes generado con éxito.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvClientes.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Excel Files |*.xlsx";
            guardar.FileName = "Reporte_Clientes.xlsx";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var hoja = wb.Worksheets.Add("Clientes");
                        for (int i = 0; i < dgvClientes.Columns.Count; i++)
                        {
                            hoja.Cell(1, i + 1).Value = dgvClientes.Columns[i].HeaderText;
                        }
                        for (int filas = 0; filas < dgvClientes.Rows.Count; filas++)
                        {
                            for (int col = 0; col < dgvClientes.Columns.Count; col++)
                            {
                                hoja.Cell(filas + 2, col + 1).Value = dgvClientes.Rows[filas].Cells[col].Value?.ToString();
                            }
                        }
                        wb.SaveAs(guardar.FileName);
                    }
                    MessageBox.Show("Excel de clientes generado con éxito.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
