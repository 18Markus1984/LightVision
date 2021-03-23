
namespace LightVisionSettings
{
    partial class Vorlagen
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
            this.label2 = new System.Windows.Forms.Label();
            this.cB_clock = new System.Windows.Forms.CheckBox();
            this.cB_GME = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(374, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hier sollen Dinge rein wie Uhr und andere Animationen die wir gemacht haben";
            // 
            // cB_clock
            // 
            this.cB_clock.AutoSize = true;
            this.cB_clock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.cB_clock.ForeColor = System.Drawing.Color.White;
            this.cB_clock.Location = new System.Drawing.Point(462, 102);
            this.cB_clock.Name = "cB_clock";
            this.cB_clock.Size = new System.Drawing.Size(95, 28);
            this.cB_clock.TabIndex = 3;
            this.cB_clock.Text = "Enable";
            this.cB_clock.UseVisualStyleBackColor = true;
            // 
            // cB_GME
            // 
            this.cB_GME.AutoSize = true;
            this.cB_GME.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.cB_GME.ForeColor = System.Drawing.Color.White;
            this.cB_GME.Location = new System.Drawing.Point(462, 288);
            this.cB_GME.Name = "cB_GME";
            this.cB_GME.Size = new System.Drawing.Size(95, 28);
            this.cB_GME.TabIndex = 5;
            this.cB_GME.Text = "Enable";
            this.cB_GME.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LightVisionSettings.Properties.Resources.GMEAktieV2;
            this.pictureBox2.Location = new System.Drawing.Point(35, 238);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(379, 125);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LightVisionSettings.Properties.Resources.hjbjkbjk;
            this.pictureBox1.Location = new System.Drawing.Point(35, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(379, 125);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Vorlagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cB_GME);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cB_clock);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Name = "Vorlagen";
            this.Size = new System.Drawing.Size(917, 552);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cB_clock;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox cB_GME;
    }
}
