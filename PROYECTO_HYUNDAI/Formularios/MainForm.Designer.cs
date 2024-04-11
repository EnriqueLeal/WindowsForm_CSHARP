namespace PROYECTO_HYUNDAI.Formularios
{
    partial class MainForm
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
            pnl1 = new Panel();
            tabControlAplicaciones = new TabControl();
            tab1 = new TabPage();
            tab2 = new TabPage();
            pnl1.SuspendLayout();
            tabControlAplicaciones.SuspendLayout();
            SuspendLayout();
            // 
            // pnl1
            // 
            pnl1.Controls.Add(tabControlAplicaciones);
            pnl1.Location = new Point(12, 12);
            pnl1.Name = "pnl1";
            pnl1.Size = new Size(872, 516);
            pnl1.TabIndex = 0;
            pnl1.Paint += pnl1_Paint;
            // 
            // tabControlAplicaciones
            // 
            tabControlAplicaciones.Controls.Add(tab1);
            tabControlAplicaciones.Controls.Add(tab2);
            tabControlAplicaciones.Location = new Point(12, 3);
            tabControlAplicaciones.Multiline = true;
            tabControlAplicaciones.Name = "tabControlAplicaciones";
            tabControlAplicaciones.SelectedIndex = 0;
            tabControlAplicaciones.Size = new Size(764, 300);
            tabControlAplicaciones.TabIndex = 0;
            tabControlAplicaciones.Click += ButtonViewDetails_Click;
            // 
            // tab1
            // 
            tab1.Location = new Point(4, 29);
            tab1.Name = "tab1";
            tab1.Padding = new Padding(3);
            tab1.Size = new Size(756, 267);
            tab1.TabIndex = 0;
            tab1.UseVisualStyleBackColor = true;
            tab1.Click += tab1_Click;
            // 
            // tab2
            // 
            tab2.Location = new Point(4, 29);
            tab2.Name = "tab2";
            tab2.Padding = new Padding(3);
            tab2.Size = new Size(756, 267);
            tab2.TabIndex = 1;
            tab2.UseVisualStyleBackColor = true;
            tab2.Click += tab2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(896, 540);
            Controls.Add(pnl1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            pnl1.ResumeLayout(false);
            tabControlAplicaciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl1;
        private TabControl tabControlAplicaciones;
        private TabPage tab1;
        private TabPage tab2;
    }
}