namespace LightVisionSettings
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bt_Speichern = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(524, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hier sollen alle aktuellen Panels angezeigt werden und ihre Reihenfolge, die man " +
    "hier dann auch ändern kann";
            // 
            // bt_Speichern
            // 
            this.bt_Speichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Speichern.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Speichern.Location = new System.Drawing.Point(45, 409);
            this.bt_Speichern.Name = "bt_Speichern";
            this.bt_Speichern.Size = new System.Drawing.Size(91, 41);
            this.bt_Speichern.TabIndex = 1;
            this.bt_Speichern.Text = "Speichern";
            this.bt_Speichern.UseVisualStyleBackColor = true;
            this.bt_Speichern.Click += new System.EventHandler(this.bt_Speichern_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(262, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Doppel Klick!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(425, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Drag and Drop!";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(147)))), ((int)(((byte)(72)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_Speichern);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(744, 516);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bt_Speichern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
