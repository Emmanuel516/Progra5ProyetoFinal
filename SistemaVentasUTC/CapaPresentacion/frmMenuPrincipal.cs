using System;
using System.Collections.Generic; 
using System.Drawing; 
using System.Linq; 
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; 
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmMenuPrincipal : Form
    {

        public frmMenuPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
     
        }


        private void btnAbrirClientes_Click(object sender, EventArgs e)
        {
            frmClientes ventanaClientes = new frmClientes();
            ventanaClientes.ShowDialog();
        }

        private void btnAbrirProductos_Click(object sender, EventArgs e)
        {
    
        }

        private void btnAbrirVentas_Click(object sender, EventArgs e)
        {
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
     
        }
    }
}