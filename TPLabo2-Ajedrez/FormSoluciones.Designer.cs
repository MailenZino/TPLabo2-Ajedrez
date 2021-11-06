
namespace TPLabo2_Ajedrez
{
    partial class FormSoluciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSoluciones));
            this.btnProxSol = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btn_GenerarSol = new System.Windows.Forms.Button();
            this.NroSol = new System.Windows.Forms.TextBox();
            this.ImgAtaqueLeve = new System.Windows.Forms.PictureBox();
            this.labelAtaqueLeve = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelAtaqueFuerte = new System.Windows.Forms.Label();
            this.BoxcantSoluciones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImgAtaqueLeve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProxSol
            // 
            this.btnProxSol.BackColor = System.Drawing.Color.Gray;
            this.btnProxSol.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProxSol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProxSol.Location = new System.Drawing.Point(557, 201);
            this.btnProxSol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProxSol.Name = "btnProxSol";
            this.btnProxSol.Size = new System.Drawing.Size(192, 73);
            this.btnProxSol.TabIndex = 0;
            this.btnProxSol.Text = "Próxima Solución";
            this.btnProxSol.UseVisualStyleBackColor = false;
            this.btnProxSol.Click += new System.EventHandler(this.btnProxSol_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Silver;
            this.btnSalir.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalir.Location = new System.Drawing.Point(585, 292);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(123, 55);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btn_GenerarSol
            // 
            this.btn_GenerarSol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_GenerarSol.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerarSol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_GenerarSol.Location = new System.Drawing.Point(557, 104);
            this.btn_GenerarSol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GenerarSol.Name = "btn_GenerarSol";
            this.btn_GenerarSol.Size = new System.Drawing.Size(192, 71);
            this.btn_GenerarSol.TabIndex = 2;
            this.btn_GenerarSol.Text = "Generar Soluciones";
            this.btn_GenerarSol.UseVisualStyleBackColor = false;
            this.btn_GenerarSol.Click += new System.EventHandler(this.btn_GenerarSol_Click);
            // 
            // NroSol
            // 
            this.NroSol.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.NroSol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NroSol.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.NroSol.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NroSol.ForeColor = System.Drawing.SystemColors.InfoText;
            this.NroSol.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.NroSol.Location = new System.Drawing.Point(15, 407);
            this.NroSol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NroSol.Name = "NroSol";
            this.NroSol.ReadOnly = true;
            this.NroSol.Size = new System.Drawing.Size(152, 21);
            this.NroSol.TabIndex = 3;
            this.NroSol.Text = "Solución nro.1";
            // 
            // ImgAtaqueLeve
            // 
            this.ImgAtaqueLeve.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ImgAtaqueLeve.BackgroundImage")));
            this.ImgAtaqueLeve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ImgAtaqueLeve.Location = new System.Drawing.Point(557, 371);
            this.ImgAtaqueLeve.Name = "ImgAtaqueLeve";
            this.ImgAtaqueLeve.Size = new System.Drawing.Size(41, 37);
            this.ImgAtaqueLeve.TabIndex = 4;
            this.ImgAtaqueLeve.TabStop = false;
            this.ImgAtaqueLeve.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelAtaqueLeve
            // 
            this.labelAtaqueLeve.AutoSize = true;
            this.labelAtaqueLeve.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAtaqueLeve.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelAtaqueLeve.Location = new System.Drawing.Point(515, 411);
            this.labelAtaqueLeve.Name = "labelAtaqueLeve";
            this.labelAtaqueLeve.Size = new System.Drawing.Size(108, 23);
            this.labelAtaqueLeve.TabIndex = 5;
            this.labelAtaqueLeve.Text = "Ataque leve";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(679, 371);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 37);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // labelAtaqueFuerte
            // 
            this.labelAtaqueFuerte.AutoSize = true;
            this.labelAtaqueFuerte.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAtaqueFuerte.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelAtaqueFuerte.Location = new System.Drawing.Point(645, 411);
            this.labelAtaqueFuerte.Name = "labelAtaqueFuerte";
            this.labelAtaqueFuerte.Size = new System.Drawing.Size(129, 23);
            this.labelAtaqueFuerte.TabIndex = 7;
            this.labelAtaqueFuerte.Text = "Ataque Fuerte";
            // 
            // BoxcantSoluciones
            // 
            this.BoxcantSoluciones.FormattingEnabled = true;
            this.BoxcantSoluciones.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "36"});
            this.BoxcantSoluciones.Location = new System.Drawing.Point(585, 45);
            this.BoxcantSoluciones.Name = "BoxcantSoluciones";
            this.BoxcantSoluciones.Size = new System.Drawing.Size(123, 24);
            this.BoxcantSoluciones.TabIndex = 8;
            this.BoxcantSoluciones.SelectedIndexChanged += new System.EventHandler(this.BoxcantSoluciones_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(478, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccione la cantidad de soluciones a mostrar";
            // 
            // FormSoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoxcantSoluciones);
            this.Controls.Add(this.labelAtaqueFuerte);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelAtaqueLeve);
            this.Controls.Add(this.ImgAtaqueLeve);
            this.Controls.Add(this.NroSol);
            this.Controls.Add(this.btn_GenerarSol);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProxSol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSoluciones";
            this.Text = "Solución";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgAtaqueLeve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProxSol;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btn_GenerarSol;
        private System.Windows.Forms.TextBox NroSol;
        private System.Windows.Forms.PictureBox ImgAtaqueLeve;
        private System.Windows.Forms.Label labelAtaqueLeve;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelAtaqueFuerte;
        private System.Windows.Forms.ComboBox BoxcantSoluciones;
        private System.Windows.Forms.Label label1;
    }
}
