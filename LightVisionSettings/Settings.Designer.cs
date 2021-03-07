
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.bt_MenuColor = new System.Windows.Forms.Button();
            this.bt_ContentColor = new System.Windows.Forms.Button();
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
            // bt_MenuColor
            // 
            this.bt_MenuColor.Location = new System.Drawing.Point(36, 107);
            this.bt_MenuColor.Name = "bt_MenuColor";
            this.bt_MenuColor.Size = new System.Drawing.Size(93, 23);
            this.bt_MenuColor.TabIndex = 21;
            this.bt_MenuColor.Text = "bt_ContentColor";
            this.bt_MenuColor.UseVisualStyleBackColor = true;
            this.bt_MenuColor.Click += new System.EventHandler(this.MenuColor_Click);
            // 
            // bt_ContentColor
            // 
            this.bt_ContentColor.Location = new System.Drawing.Point(153, 107);
            this.bt_ContentColor.Name = "bt_ContentColor";
            this.bt_ContentColor.Size = new System.Drawing.Size(124, 23);
            this.bt_ContentColor.TabIndex = 22;
            this.bt_ContentColor.Text = "bt_MenuColor";
            this.bt_ContentColor.UseVisualStyleBackColor = true;
            this.bt_ContentColor.Click += new System.EventHandler(this.contentColor_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(147)))), ((int)(((byte)(72)))));
            this.Controls.Add(this.bt_ContentColor);
            this.Controls.Add(this.bt_MenuColor);
            this.Controls.Add(this.cB_RGB);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(555, 415);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cB_RGB;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button bt_MenuColor;
        private System.Windows.Forms.Button bt_ContentColor;
    }
}
