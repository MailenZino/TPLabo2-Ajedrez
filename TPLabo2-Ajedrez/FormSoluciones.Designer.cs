
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
            this.SuspendLayout();
            // 
            // btnProxSol
            // 
            this.btnProxSol.BackColor = System.Drawing.Color.Gray;
            this.btnProxSol.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProxSol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProxSol.Location = new System.Drawing.Point(418, 157);
            this.btnProxSol.Margin = new System.Windows.Forms.Padding(2);
            this.btnProxSol.Name = "btnProxSol";
            this.btnProxSol.Size = new System.Drawing.Size(144, 59);
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
            this.btnSalir.Location = new System.Drawing.Point(442, 266);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 45);
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
            this.btn_GenerarSol.Location = new System.Drawing.Point(418, 45);
            this.btn_GenerarSol.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GenerarSol.Name = "btn_GenerarSol";
            this.btn_GenerarSol.Size = new System.Drawing.Size(144, 58);
            this.btn_GenerarSol.TabIndex = 2;
            this.btn_GenerarSol.Text = "Generar Soluciones";
            this.btn_GenerarSol.UseVisualStyleBackColor = false;
            this.btn_GenerarSol.Click += new System.EventHandler(this.btn_GenerarSol_Click);
            // 
            // NroSol
            // 
            this.NroSol.BackColor = System.Drawing.SystemColors.MenuText;
            this.NroSol.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NroSol.ForeColor = System.Drawing.SystemColors.Window;
            this.NroSol.Location = new System.Drawing.Point(11, 331);
            this.NroSol.Margin = new System.Windows.Forms.Padding(2);
            this.NroSol.Name = "NroSol";
            this.NroSol.Size = new System.Drawing.Size(115, 24);
            this.NroSol.TabIndex = 3;
            this.NroSol.Text = "Solución nro.1";
            // 
            // FormSoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.NroSol);
            this.Controls.Add(this.btn_GenerarSol);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProxSol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSoluciones";
            this.Text = "Solución";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProxSol;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btn_GenerarSol;
        private System.Windows.Forms.TextBox NroSol;
    }
}
