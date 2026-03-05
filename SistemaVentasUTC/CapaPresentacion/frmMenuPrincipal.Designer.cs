namespace CapaPresentacion
{
    partial class frmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnAbrirClientes = new Button();
            btnAbrirProductos = new Button();
            btnAbrirVentas = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(220, 9);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(379, 24);
            label1.TabIndex = 0;
            label1.Text = "SISTEMA DE VENTAS - MENÚ PRINCIPAL";
            // 
            // btnAbrirClientes
            // 
            btnAbrirClientes.Location = new Point(30, 96);
            btnAbrirClientes.Margin = new Padding(2);
            btnAbrirClientes.Name = "btnAbrirClientes";
            btnAbrirClientes.Size = new Size(162, 57);
            btnAbrirClientes.TabIndex = 1;
            btnAbrirClientes.Text = "Módulo de Clientes";
            btnAbrirClientes.UseVisualStyleBackColor = true;
            btnAbrirClientes.Click += btnAbrirClientes_Click;
            // 
            // btnAbrirProductos
            // 
            btnAbrirProductos.Location = new Point(30, 177);
            btnAbrirProductos.Margin = new Padding(2);
            btnAbrirProductos.Name = "btnAbrirProductos";
            btnAbrirProductos.Size = new Size(162, 57);
            btnAbrirProductos.TabIndex = 2;
            btnAbrirProductos.Text = "Módulo de Productos";
            btnAbrirProductos.UseVisualStyleBackColor = true;
            btnAbrirProductos.Click += btnAbrirProductos_Click;
            // 
            // btnAbrirVentas
            // 
            btnAbrirVentas.Location = new Point(30, 261);
            btnAbrirVentas.Margin = new Padding(2);
            btnAbrirVentas.Name = "btnAbrirVentas";
            btnAbrirVentas.Size = new Size(162, 57);
            btnAbrirVentas.TabIndex = 3;
            btnAbrirVentas.Text = "Caja Registradora";
            btnAbrirVentas.UseVisualStyleBackColor = true;
            btnAbrirVentas.Click += btnAbrirVentas_Click;
            // 
            // button1
            // 
            button1.Location = new Point(30, 337);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(162, 57);
            button1.TabIndex = 4;
            button1.Text = "Reporte de Ventas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 479);
            Controls.Add(button1);
            Controls.Add(btnAbrirVentas);
            Controls.Add(btnAbrirProductos);
            Controls.Add(btnAbrirClientes);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "frmMenuPrincipal";
            Text = "frmMenuPrincipal";
            Load += frmMenuPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAbrirClientes;
        private Button btnAbrirProductos;
        private Button btnAbrirVentas;
        private Button button1;
    }
}