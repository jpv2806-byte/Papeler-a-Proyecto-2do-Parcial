namespace ProyectoPapeleria
{
    partial class Papeleria
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Papeleria));
            pictureBox1 = new PictureBox();
            txtNomProd = new TextBox();
            lblNomProd = new Label();
            lblIdProd = new Label();
            lblCantidad = new Label();
            txtIdProd = new TextBox();
            txtCantidad = new TextBox();
            btnRegistrar = new Button();
            btnBorrar = new Button();
            btnMas = new Button();
            btnMenos = new Button();
            btnCerrar = new Button();
            btnBuscar = new Button();
            lstbProd = new ListBox();
            btnMostrar = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Khaki;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1345, 181);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // txtNomProd
            // 
            txtNomProd.Location = new Point(322, 181);
            txtNomProd.Name = "txtNomProd";
            txtNomProd.Size = new Size(453, 27);
            txtNomProd.TabIndex = 0;
            // 
            // lblNomProd
            // 
            lblNomProd.AutoSize = true;
            lblNomProd.Font = new Font("Verdana", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNomProd.Location = new Point(40, 179);
            lblNomProd.Name = "lblNomProd";
            lblNomProd.Size = new Size(251, 25);
            lblNomProd.TabIndex = 1;
            lblNomProd.Text = "Nombre del Producto";
            // 
            // lblIdProd
            // 
            lblIdProd.AutoSize = true;
            lblIdProd.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIdProd.Location = new Point(40, 43);
            lblIdProd.Name = "lblIdProd";
            lblIdProd.Size = new Size(168, 28);
            lblIdProd.TabIndex = 2;
            lblIdProd.Text = "ID Producto";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(40, 245);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(125, 28);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "Cantidad";
            // 
            // txtIdProd
            // 
            txtIdProd.Location = new Point(322, 43);
            txtIdProd.Name = "txtIdProd";
            txtIdProd.Size = new Size(453, 27);
            txtIdProd.TabIndex = 4;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(322, 245);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(453, 27);
            txtCantidad.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.Location = new Point(950, 135);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(240, 44);
            btnRegistrar.TabIndex = 6;
            btnRegistrar.Text = "Registrar Producto";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBorrar.Location = new Point(1055, 471);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(240, 44);
            btnBorrar.TabIndex = 7;
            btnBorrar.Text = "Borrar Producto";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnMas
            // 
            btnMas.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMas.Location = new Point(367, 289);
            btnMas.Name = "btnMas";
            btnMas.Size = new Size(147, 44);
            btnMas.TabIndex = 8;
            btnMas.Text = "Cantidad+1";
            btnMas.UseVisualStyleBackColor = true;
            btnMas.Click += btnMas_Click;
            // 
            // btnMenos
            // 
            btnMenos.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenos.Location = new Point(594, 289);
            btnMenos.Name = "btnMenos";
            btnMenos.Size = new Size(145, 44);
            btnMenos.TabIndex = 9;
            btnMenos.Text = "Cantidad -1";
            btnMenos.UseVisualStyleBackColor = true;
            btnMenos.Click += btnMenos_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.Location = new Point(1229, 638);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 35);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(322, 101);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(207, 44);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "Buscar (Id)";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lstbProd
            // 
            lstbProd.FormattingEnabled = true;
            lstbProd.Location = new Point(40, 362);
            lstbProd.Name = "lstbProd";
            lstbProd.Size = new Size(973, 284);
            lstbProd.TabIndex = 13;
            lstbProd.SelectedIndexChanged += lstbProd_SelectedIndexChanged;
            // 
            // btnMostrar
            // 
            btnMostrar.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMostrar.Location = new Point(568, 101);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(207, 44);
            btnMostrar.TabIndex = 14;
            btnMostrar.Text = "Mostrar Todos";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(870, 101);
            label1.Name = "label1";
            label1.Size = new Size(453, 18);
            label1.TabIndex = 15;
            label1.Text = "Llena todos los campos antes de registrar un producto";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Ivory;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnMostrar);
            groupBox1.Controls.Add(lstbProd);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(btnCerrar);
            groupBox1.Controls.Add(btnMenos);
            groupBox1.Controls.Add(btnMas);
            groupBox1.Controls.Add(btnBorrar);
            groupBox1.Controls.Add(btnRegistrar);
            groupBox1.Controls.Add(txtCantidad);
            groupBox1.Controls.Add(txtIdProd);
            groupBox1.Controls.Add(lblCantidad);
            groupBox1.Controls.Add(lblIdProd);
            groupBox1.Controls.Add(lblNomProd);
            groupBox1.Controls.Add(txtNomProd);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 181);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1345, 633);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            // 
            // label2
            // 
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1055, 393);
            label2.Name = "label2";
            label2.Size = new Size(240, 54);
            label2.TabIndex = 16;
            label2.Text = "Selecciona en la lista el producto que deseas eliminar";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(440, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(475, 153);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // Papeleria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1345, 814);
            Controls.Add(pictureBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Name = "Papeleria";
            Text = "Papeleria";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private TextBox txtNomProd;
        private Label lblNomProd;
        private Label lblIdProd;
        private Label lblCantidad;
        private TextBox txtIdProd;
        private TextBox txtCantidad;
        private Button btnRegistrar;
        private Button btnBorrar;
        private Button btnMas;
        private Button btnMenos;
        private Button btnCerrar;
        private Button btnBuscar;
        private ListBox lstbProd;
        private Button btnMostrar;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private PictureBox pictureBox2;
    }
}
