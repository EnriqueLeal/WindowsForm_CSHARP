namespace PROYECTO_HYUNDAI.Formularios
{
    partial class Empleados
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
            panel1 = new Panel();
            TxtBoxUsuario = new TextBox();
            TxtBoxID = new TextBox();
            btnGuardar = new Button();
            lblActivo = new Label();
            lblCargo = new Label();
            lblAp_materno = new Label();
            lblAp_paterno = new Label();
            lblNombre = new Label();
            TxtBoxAp_materno = new TextBox();
            TxtBoxActivo = new TextBox();
            TxtBoxAp_paterno = new TextBox();
            TxtBoxCargo = new TextBox();
            TxtBoxNombre = new TextBox();
            DataGridEmpleados = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridEmpleados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(TxtBoxUsuario);
            panel1.Controls.Add(TxtBoxID);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(lblActivo);
            panel1.Controls.Add(lblCargo);
            panel1.Controls.Add(lblAp_materno);
            panel1.Controls.Add(lblAp_paterno);
            panel1.Controls.Add(lblNombre);
            panel1.Controls.Add(TxtBoxAp_materno);
            panel1.Controls.Add(TxtBoxActivo);
            panel1.Controls.Add(TxtBoxAp_paterno);
            panel1.Controls.Add(TxtBoxCargo);
            panel1.Controls.Add(TxtBoxNombre);
            panel1.Controls.Add(DataGridEmpleados);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(761, 411);
            panel1.TabIndex = 0;
            // 
            // TxtBoxUsuario
            // 
            TxtBoxUsuario.Location = new Point(510, 31);
            TxtBoxUsuario.Name = "TxtBoxUsuario";
            TxtBoxUsuario.Size = new Size(125, 27);
            TxtBoxUsuario.TabIndex = 13;
            // 
            // TxtBoxID
            // 
            TxtBoxID.Location = new Point(356, 98);
            TxtBoxID.Name = "TxtBoxID";
            TxtBoxID.Size = new Size(125, 27);
            TxtBoxID.TabIndex = 12;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(574, 98);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Location = new Point(202, 75);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(51, 20);
            lblActivo.TabIndex = 10;
            lblActivo.Text = "Activo";
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Location = new Point(35, 75);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(49, 20);
            lblCargo.TabIndex = 9;
            lblCargo.Text = "Cargo";
            // 
            // lblAp_materno
            // 
            lblAp_materno.AutoSize = true;
            lblAp_materno.Location = new Point(355, 8);
            lblAp_materno.Name = "lblAp_materno";
            lblAp_materno.Size = new Size(126, 20);
            lblAp_materno.TabIndex = 8;
            lblAp_materno.Text = "Apellido Materno";
            // 
            // lblAp_paterno
            // 
            lblAp_paterno.AutoSize = true;
            lblAp_paterno.Location = new Point(202, 8);
            lblAp_paterno.Name = "lblAp_paterno";
            lblAp_paterno.Size = new Size(120, 20);
            lblAp_paterno.TabIndex = 7;
            lblAp_paterno.Text = "Apellido Paterno";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(36, 8);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 6;
            lblNombre.Text = "Nombre";
            // 
            // TxtBoxAp_materno
            // 
            TxtBoxAp_materno.Location = new Point(355, 31);
            TxtBoxAp_materno.Name = "TxtBoxAp_materno";
            TxtBoxAp_materno.Size = new Size(125, 27);
            TxtBoxAp_materno.TabIndex = 5;
            // 
            // TxtBoxActivo
            // 
            TxtBoxActivo.Location = new Point(202, 98);
            TxtBoxActivo.Name = "TxtBoxActivo";
            TxtBoxActivo.Size = new Size(125, 27);
            TxtBoxActivo.TabIndex = 4;
            // 
            // TxtBoxAp_paterno
            // 
            TxtBoxAp_paterno.Location = new Point(202, 31);
            TxtBoxAp_paterno.Name = "TxtBoxAp_paterno";
            TxtBoxAp_paterno.Size = new Size(125, 27);
            TxtBoxAp_paterno.TabIndex = 3;
            // 
            // TxtBoxCargo
            // 
            TxtBoxCargo.Location = new Point(36, 98);
            TxtBoxCargo.Name = "TxtBoxCargo";
            TxtBoxCargo.Size = new Size(125, 27);
            TxtBoxCargo.TabIndex = 2;
            // 
            // TxtBoxNombre
            // 
            TxtBoxNombre.Location = new Point(36, 31);
            TxtBoxNombre.Name = "TxtBoxNombre";
            TxtBoxNombre.Size = new Size(125, 27);
            TxtBoxNombre.TabIndex = 1;
            // 
            // DataGridEmpleados
            // 
            DataGridEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridEmpleados.Location = new Point(3, 180);
            DataGridEmpleados.Name = "DataGridEmpleados";
            DataGridEmpleados.RowHeadersWidth = 51;
            DataGridEmpleados.Size = new Size(755, 216);
            DataGridEmpleados.TabIndex = 0;
            DataGridEmpleados.CellContentClick += DataGridEmpleados_CellContentClick;
            // 
            // Empleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Empleados";
            Text = "Empleados";
            Load += Empleados_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridEmpleados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView DataGridEmpleados;
        private TextBox TxtBoxAp_materno;
        private TextBox TxtBoxActivo;
        private TextBox TxtBoxAp_paterno;
        private TextBox TxtBoxCargo;
        private TextBox TxtBoxNombre;
        private Label lblNombre;
        private Label lblAp_paterno;
        private Label lblCargo;
        private Label lblAp_materno;
        private Label lblActivo;
        private Button btnGuardar;
        private TextBox TxtBoxID;
        private TextBox TxtBoxUsuario;
    }
}