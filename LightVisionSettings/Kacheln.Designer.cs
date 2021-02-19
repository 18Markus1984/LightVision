﻿namespace LightVisionSettings
{
    partial class Kacheln
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.bt_Speichern = new System.Windows.Forms.Button();
            this.bt_Color = new System.Windows.Forms.Button();
            this.bt_fill = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_Speichern
            // 
            this.bt_Speichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Speichern.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Speichern.Location = new System.Drawing.Point(18, 271);
            this.bt_Speichern.Name = "bt_Speichern";
            this.bt_Speichern.Size = new System.Drawing.Size(91, 41);
            this.bt_Speichern.TabIndex = 0;
            this.bt_Speichern.Text = "Speichern";
            this.bt_Speichern.UseVisualStyleBackColor = true;
            this.bt_Speichern.Click += new System.EventHandler(this.bt_Speichern_Click);
            // 
            // bt_Color
            // 
            this.bt_Color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Color.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Color.Location = new System.Drawing.Point(115, 271);
            this.bt_Color.Name = "bt_Color";
            this.bt_Color.Size = new System.Drawing.Size(62, 41);
            this.bt_Color.TabIndex = 1;
            this.bt_Color.Text = "Farbe";
            this.bt_Color.UseVisualStyleBackColor = true;
            this.bt_Color.Click += new System.EventHandler(this.bt_Color_Click_1);
            // 
            // bt_fill
            // 
            this.bt_fill.BackgroundImage = global::LightVisionSettings.Properties.Resources.fill_color_24px;
            this.bt_fill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_fill.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_fill.Location = new System.Drawing.Point(230, 271);
            this.bt_fill.Name = "bt_fill";
            this.bt_fill.Size = new System.Drawing.Size(41, 41);
            this.bt_fill.TabIndex = 3;
            this.bt_fill.UseVisualStyleBackColor = true;
            this.bt_fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // bt_clear
            // 
            this.bt_clear.BackgroundImage = global::LightVisionSettings.Properties.Resources.erase_24px;
            this.bt_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_clear.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_clear.Location = new System.Drawing.Point(183, 271);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(41, 41);
            this.bt_clear.TabIndex = 2;
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Kacheln
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bt_fill);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_Color);
            this.Controls.Add(this.bt_Speichern);
            this.Name = "Kacheln";
            this.Size = new System.Drawing.Size(786, 538);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button bt_Speichern;
        private System.Windows.Forms.Button bt_Color;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_fill;
    }
}
