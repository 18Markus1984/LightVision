
namespace LightVisionSettings
{
    partial class Settings
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.cB_RGB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cB_RGB
            // 
            this.cB_RGB.AutoSize = true;
            this.cB_RGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cB_RGB.ForeColor = System.Drawing.Color.White;
            this.cB_RGB.Location = new System.Drawing.Point(36, 44);
            this.cB_RGB.Name = "cB_RGB";
            this.cB_RGB.Size = new System.Drawing.Size(71, 28);
            this.cB_RGB.TabIndex = 20;
            this.cB_RGB.Text = "RGB";
            this.cB_RGB.UseVisualStyleBackColor = true;
            this.cB_RGB.CheckedChanged += new System.EventHandler(this.cB_RGB_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(147)))), ((int)(((byte)(72)))));
            this.Controls.Add(this.cB_RGB);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(555, 415);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cB_RGB;
    }
}
