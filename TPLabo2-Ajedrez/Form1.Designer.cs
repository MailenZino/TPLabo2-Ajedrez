
namespace TPLabo2_Ajedrez
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnProx = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.NroSol = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnProx
            // 
            this.btnProx.BackColor = System.Drawing.Color.Gray;
            this.btnProx.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProx.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProx.Location = new System.Drawing.Point(557, 170);
            this.btnProx.Name = "btnProx";
            this.btnProx.Size = new System.Drawing.Size(192, 73);
            this.btnProx.TabIndex = 0;
            this.btnProx.Text = "Próxima Solución";
            this.btnProx.UseVisualStyleBackColor = false;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Silver;
            this.btnAtras.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAtras.Location = new System.Drawing.Point(557, 302);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(192, 79);
            this.btnAtras.TabIndex = 1;
            this.btnAtras.Text = "Volver Atrás";
            this.btnAtras.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(557, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 71);
            this.button1.TabIndex = 2;
            this.button1.Text = "Mostrar Solución";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // NroSol
            // 
            this.NroSol.BackColor = System.Drawing.SystemColors.MenuText;
            this.NroSol.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NroSol.ForeColor = System.Drawing.SystemColors.Window;
            this.NroSol.Location = new System.Drawing.Point(98, 410);
            this.NroSol.Name = "NroSol";
            this.NroSol.Size = new System.Drawing.Size(152, 28);
            this.NroSol.TabIndex = 3;
            this.NroSol.Text = "Solución nro.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NroSol);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnProx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Solución";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProx;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NroSol;
    }
}
