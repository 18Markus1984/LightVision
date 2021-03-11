﻿
namespace LightVisionSettings
{
    partial class Animator
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
            this.tb_showtime = new System.Windows.Forms.TextBox();
            this.tb_NamePanel = new System.Windows.Forms.TextBox();
            this.bt_NewPanel = new System.Windows.Forms.Button();
            this.cb_SelectedPanal = new System.Windows.Forms.ComboBox();
            this.bt_fill = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_Color = new System.Windows.Forms.Button();
            this.bt_Speichern = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Animator";
            // 
            // tb_showtime
            // 
            this.tb_showtime.Location = new System.Drawing.Point(582, 355);
            this.tb_showtime.Name = "tb_showtime";
            this.tb_showtime.Size = new System.Drawing.Size(100, 20);
            this.tb_showtime.TabIndex = 15;
            // 
            // tb_NamePanel
            // 
            this.tb_NamePanel.Location = new System.Drawing.Point(421, 355);
            this.tb_NamePanel.Name = "tb_NamePanel";
            this.tb_NamePanel.Size = new System.Drawing.Size(155, 20);
            this.tb_NamePanel.TabIndex = 14;
            // 
            // bt_NewPanel
            // 
            this.bt_NewPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_NewPanel.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_NewPanel.Location = new System.Drawing.Point(354, 355);
            this.bt_NewPanel.Name = "bt_NewPanel";
            this.bt_NewPanel.Size = new System.Drawing.Size(61, 41);
            this.bt_NewPanel.TabIndex = 13;
            this.bt_NewPanel.Text = "Neu";
            this.bt_NewPanel.UseVisualStyleBackColor = true;
            // 
            // cb_SelectedPanal
            // 
            this.cb_SelectedPanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectedPanal.FormattingEnabled = true;
            this.cb_SelectedPanal.Location = new System.Drawing.Point(421, 381);
            this.cb_SelectedPanal.Name = "cb_SelectedPanal";
            this.cb_SelectedPanal.Size = new System.Drawing.Size(155, 21);
            this.cb_SelectedPanal.TabIndex = 12;
            // 
            // bt_fill
            // 
            this.bt_fill.BackgroundImage = global::LightVisionSettings.Properties.Resources.fill_color_24px;
            this.bt_fill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_fill.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_fill.Location = new System.Drawing.Point(307, 355);
            this.bt_fill.Name = "bt_fill";
            this.bt_fill.Size = new System.Drawing.Size(41, 41);
            this.bt_fill.TabIndex = 11;
            this.bt_fill.UseVisualStyleBackColor = true;
            this.bt_fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // bt_clear
            // 
            this.bt_clear.BackgroundImage = global::LightVisionSettings.Properties.Resources.erase_24px;
            this.bt_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_clear.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_clear.Location = new System.Drawing.Point(260, 355);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(41, 41);
            this.bt_clear.TabIndex = 10;
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // bt_Color
            // 
            this.bt_Color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Color.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Color.Location = new System.Drawing.Point(192, 355);
            this.bt_Color.Name = "bt_Color";
            this.bt_Color.Size = new System.Drawing.Size(62, 41);
            this.bt_Color.TabIndex = 9;
            this.bt_Color.Text = "Farbe";
            this.bt_Color.UseVisualStyleBackColor = true;
            this.bt_Color.Click += new System.EventHandler(this.bt_Color_Click_1);
            // 
            // bt_Speichern
            // 
            this.bt_Speichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Speichern.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Speichern.Location = new System.Drawing.Point(95, 355);
            this.bt_Speichern.Name = "bt_Speichern";
            this.bt_Speichern.Size = new System.Drawing.Size(91, 41);
            this.bt_Speichern.TabIndex = 8;
            this.bt_Speichern.Text = "Speichern";
            this.bt_Speichern.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(582, 382);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 16;
            // 
            // Animator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(147)))), ((int)(((byte)(72)))));
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.tb_showtime);
            this.Controls.Add(this.tb_NamePanel);
            this.Controls.Add(this.bt_NewPanel);
            this.Controls.Add(this.cb_SelectedPanal);
            this.Controls.Add(this.bt_fill);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_Color);
            this.Controls.Add(this.bt_Speichern);
            this.Controls.Add(this.label2);
            this.Name = "Animator";
            this.Size = new System.Drawing.Size(820, 517);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_showtime;
        private System.Windows.Forms.TextBox tb_NamePanel;
        private System.Windows.Forms.Button bt_NewPanel;
        private System.Windows.Forms.ComboBox cb_SelectedPanal;
        private System.Windows.Forms.Button bt_fill;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_Color;
        private System.Windows.Forms.Button bt_Speichern;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
