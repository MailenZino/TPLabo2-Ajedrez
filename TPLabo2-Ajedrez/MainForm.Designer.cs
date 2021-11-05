
namespace TPLabo2_Ajedrez
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSln = new System.Windows.Forms.Button();
            this.btnComplejidad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSln
            // 
            this.btnSln.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSln.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSln.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSln.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSln.Location = new System.Drawing.Point(50, 103);
            this.btnSln.Name = "btnSln";
            this.btnSln.Size = new System.Drawing.Size(250, 42);
            this.btnSln.TabIndex = 0;
            this.btnSln.Text = "Mostrar soluciones";
            this.btnSln.UseVisualStyleBackColor = false;
            this.btnSln.Click += new System.EventHandler(this.btnSln_Click);
            // 
            // btnComplejidad
            // 
            this.btnComplejidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnComplejidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplejidad.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplejidad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnComplejidad.Location = new System.Drawing.Point(50, 465);
            this.btnComplejidad.Name = "btnComplejidad";
            this.btnComplejidad.Size = new System.Drawing.Size(182, 34);
            this.btnComplejidad.TabIndex = 1;
            this.btnComplejidad.Text = "Complejidad";
            this.btnComplejidad.UseVisualStyleBackColor = false;
            this.btnComplejidad.Click += new System.EventHandler(this.btnComplejidad_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(909, 531);
            this.Controls.Add(this.btnComplejidad);
            this.Controls.Add(this.btnSln);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSln;
        private System.Windows.Forms.Button btnComplejidad;
    }
}