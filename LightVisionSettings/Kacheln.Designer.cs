namespace LightVisionSettings
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
            this.cb_SelectedPanal = new System.Windows.Forms.ComboBox();
            this.bt_NewPanel = new System.Windows.Forms.Button();
            this.tb_NamePanel = new System.Windows.Forms.TextBox();
            this.tb_showtime = new System.Windows.Forms.TextBox();
            this.bt_Löschen = new System.Windows.Forms.Button();
            this.bt_picture = new System.Windows.Forms.Button();
            this.p_Color1 = new System.Windows.Forms.Panel();
            this.p_Color2 = new System.Windows.Forms.Panel();
            this.p_Color4 = new System.Windows.Forms.Panel();
            this.p_Color3 = new System.Windows.Forms.Panel();
            this.p_Color8 = new System.Windows.Forms.Panel();
            this.p_Color7 = new System.Windows.Forms.Panel();
            this.p_Color6 = new System.Windows.Forms.Panel();
            this.p_Color5 = new System.Windows.Forms.Panel();
            this.bt_ColorPicker = new System.Windows.Forms.Button();
            this.bt_fill = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_Speichern
            // 
            this.bt_Speichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Speichern.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Speichern.Location = new System.Drawing.Point(13, 271);
            this.bt_Speichern.Name = "bt_Speichern";
            this.bt_Speichern.Size = new System.Drawing.Size(91, 41);
            this.bt_Speichern.TabIndex = 0;
            this.bt_Speichern.Text = "Speichern";
            this.bt_Speichern.UseVisualStyleBackColor = true;
            this.bt_Speichern.Click += new System.EventHandler(this.bt_Speichern_Click);
            // 
            // cb_SelectedPanal
            // 
            this.cb_SelectedPanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectedPanal.FormattingEnabled = true;
            this.cb_SelectedPanal.Location = new System.Drawing.Point(472, 297);
            this.cb_SelectedPanal.Name = "cb_SelectedPanal";
            this.cb_SelectedPanal.Size = new System.Drawing.Size(155, 21);
            this.cb_SelectedPanal.TabIndex = 4;
            this.cb_SelectedPanal.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bt_NewPanel
            // 
            this.bt_NewPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_NewPanel.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_NewPanel.Location = new System.Drawing.Point(405, 271);
            this.bt_NewPanel.Name = "bt_NewPanel";
            this.bt_NewPanel.Size = new System.Drawing.Size(61, 41);
            this.bt_NewPanel.TabIndex = 5;
            this.bt_NewPanel.Text = "Neu";
            this.bt_NewPanel.UseVisualStyleBackColor = true;
            this.bt_NewPanel.Click += new System.EventHandler(this.bt_NewPanel_Click);
            // 
            // tb_NamePanel
            // 
            this.tb_NamePanel.Location = new System.Drawing.Point(472, 271);
            this.tb_NamePanel.Name = "tb_NamePanel";
            this.tb_NamePanel.Size = new System.Drawing.Size(155, 20);
            this.tb_NamePanel.TabIndex = 6;
            this.tb_NamePanel.Text = "Name";
            this.tb_NamePanel.Enter += new System.EventHandler(this.tb_NamePanel_Enter);
            this.tb_NamePanel.Leave += new System.EventHandler(this.tb_NamePanel_Enter);
            // 
            // tb_showtime
            // 
            this.tb_showtime.Location = new System.Drawing.Point(633, 271);
            this.tb_showtime.Name = "tb_showtime";
            this.tb_showtime.Size = new System.Drawing.Size(100, 20);
            this.tb_showtime.TabIndex = 7;
            this.tb_showtime.Text = "Anzeigedauer";
            this.tb_showtime.Enter += new System.EventHandler(this.tb_showtime_Enter);
            this.tb_showtime.Leave += new System.EventHandler(this.tb_showtime_Enter);
            // 
            // bt_Löschen
            // 
            this.bt_Löschen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Löschen.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Löschen.Location = new System.Drawing.Point(13, 318);
            this.bt_Löschen.Name = "bt_Löschen";
            this.bt_Löschen.Size = new System.Drawing.Size(91, 41);
            this.bt_Löschen.TabIndex = 8;
            this.bt_Löschen.Text = "Löschen";
            this.bt_Löschen.UseVisualStyleBackColor = true;
            this.bt_Löschen.Click += new System.EventHandler(this.bt_Löschen_Click);
            // 
            // bt_picture
            // 
            this.bt_picture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_picture.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_picture.Image = global::LightVisionSettings.Properties.Resources.picture_30px;
            this.bt_picture.Location = new System.Drawing.Point(405, 318);
            this.bt_picture.Name = "bt_picture";
            this.bt_picture.Size = new System.Drawing.Size(61, 41);
            this.bt_picture.TabIndex = 9;
            this.bt_picture.UseVisualStyleBackColor = true;
            this.bt_picture.Click += new System.EventHandler(this.bt_picture_Click);
            // 
            // p_Color1
            // 
            this.p_Color1.BackColor = System.Drawing.Color.White;
            this.p_Color1.Location = new System.Drawing.Point(123, 271);
            this.p_Color1.Name = "p_Color1";
            this.p_Color1.Size = new System.Drawing.Size(41, 41);
            this.p_Color1.TabIndex = 18;
            this.p_Color1.Click += new System.EventHandler(this.paletteChangeColor);
            this.p_Color1.DoubleClick += new System.EventHandler(this.p_Color1_DoubleClick);
            // 
            // p_Color2
            // 
            this.p_Color2.BackColor = System.Drawing.Color.White;
            this.p_Color2.Location = new System.Drawing.Point(170, 271);
            this.p_Color2.Name = "p_Color2";
            this.p_Color2.Size = new System.Drawing.Size(41, 41);
            this.p_Color2.TabIndex = 19;
            this.p_Color2.Click += new System.EventHandler(this.paletteChangeColor);
            this.p_Color2.DoubleClick += new System.EventHandler(this.p_Color1_DoubleClick);
            // 
            // p_Color4
            // 
            this.p_Color4.BackColor = System.Drawing.Color.White;
            this.p_Color4.Location = new System.Drawing.Point(264, 271);
            this.p_Color4.Name = "p_Color4";
            this.p_Color4.Size = new System.Drawing.Size(41, 41);
            this.p_Color4.TabIndex = 21;
            this.p_Color4.Click += new System.EventHandler(this.paletteChangeColor);
            this.p_Color4.DoubleClick += new System.EventHandler(this.p_Color1_DoubleClick);
            // 
            // p_Color3
            // 
            this.p_Color3.BackColor = System.Drawing.Color.White;
            this.p_Color3.Location = new System.Drawing.Point(217, 271);
            this.p_Color3.Name = "p_Color3";
            this.p_Color3.Size = new System.Drawing.Size(41, 41);
            this.p_Color3.TabIndex = 20;
            this.p_Color3.Click += new System.EventHandler(this.paletteChangeColor);
            this.p_Color3.DoubleClick += new System.EventHandler(this.p_Color1_DoubleClick);
            // 
            // p_Color8
            // 
            this.p_Color8.BackColor = System.Drawing.Color.White;
            this.p_Color8.Location = new System.Drawing.Point(264, 318);
            this.p_Color8.Name = "p_Color8";
            this.p_Color8.Size = new System.Drawing.Size(41, 41);
            this.p_Color8.TabIndex = 25;
            this.p_Color8.Click += new System.EventHandler(this.paletteChangeColor);
            this.p_Color8.DoubleClick += new System.EventHandler(this.p_Color1_DoubleClick);
            // 
            // p_Color7
            // 
            this.p_Color7.BackColor = System.Drawing.Color.White;
            this.p_Color7.Location = new System.Drawing.Point(217, 318);
            this.p_Color7.Name = "p_Color7";
            this.p_Color7.Size = new System.Drawing.Size(41, 41);
            this.p_Color7.TabIndex = 24;
            this.p_Color7.Click += new System.EventHandler(this.paletteChangeColor);
            this.p_Color7.DoubleClick += new System.EventHandler(this.p_Color1_DoubleClick);
            // 
            // p_Color6
            // 
            this.p_Color6.BackColor = System.Drawing.Color.White;
            this.p_Color6.Location = new System.Drawing.Point(170, 318);
            this.p_Color6.Name = "p_Color6";
            this.p_Color6.Size = new System.Drawing.Size(41, 41);
            this.p_Color6.TabIndex = 23;
            this.p_Color6.Click += new System.EventHandler(this.paletteChangeColor);
            this.p_Color6.DoubleClick += new System.EventHandler(this.p_Color1_DoubleClick);
            // 
            // p_Color5
            // 
            this.p_Color5.BackColor = System.Drawing.Color.White;
            this.p_Color5.Location = new System.Drawing.Point(123, 318);
            this.p_Color5.Name = "p_Color5";
            this.p_Color5.Size = new System.Drawing.Size(41, 41);
            this.p_Color5.TabIndex = 22;
            this.p_Color5.Click += new System.EventHandler(this.paletteChangeColor);
            this.p_Color5.DoubleClick += new System.EventHandler(this.p_Color1_DoubleClick);
            // 
            // bt_ColorPicker
            // 
            this.bt_ColorPicker.BackgroundImage = global::LightVisionSettings.Properties.Resources.color_dropper_30px;
            this.bt_ColorPicker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ColorPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ColorPicker.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ColorPicker.Location = new System.Drawing.Point(358, 318);
            this.bt_ColorPicker.Name = "bt_ColorPicker";
            this.bt_ColorPicker.Size = new System.Drawing.Size(41, 41);
            this.bt_ColorPicker.TabIndex = 10;
            this.bt_ColorPicker.UseVisualStyleBackColor = true;
            this.bt_ColorPicker.Click += new System.EventHandler(this.bt_ColorPicker_Click);
            // 
            // bt_fill
            // 
            this.bt_fill.BackgroundImage = global::LightVisionSettings.Properties.Resources.fill_color_24px;
            this.bt_fill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_fill.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_fill.Location = new System.Drawing.Point(358, 271);
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
            this.bt_clear.Location = new System.Drawing.Point(311, 271);
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
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.Controls.Add(this.p_Color8);
            this.Controls.Add(this.p_Color7);
            this.Controls.Add(this.p_Color6);
            this.Controls.Add(this.p_Color5);
            this.Controls.Add(this.p_Color4);
            this.Controls.Add(this.p_Color3);
            this.Controls.Add(this.p_Color2);
            this.Controls.Add(this.p_Color1);
            this.Controls.Add(this.bt_ColorPicker);
            this.Controls.Add(this.bt_picture);
            this.Controls.Add(this.bt_Löschen);
            this.Controls.Add(this.tb_showtime);
            this.Controls.Add(this.tb_NamePanel);
            this.Controls.Add(this.bt_NewPanel);
            this.Controls.Add(this.cb_SelectedPanal);
            this.Controls.Add(this.bt_fill);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_Speichern);
            this.Name = "Kacheln";
            this.Size = new System.Drawing.Size(786, 538);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button bt_Speichern;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_fill;
        private System.Windows.Forms.ComboBox cb_SelectedPanal;
        private System.Windows.Forms.Button bt_NewPanel;
        private System.Windows.Forms.TextBox tb_NamePanel;
        private System.Windows.Forms.TextBox tb_showtime;
        private System.Windows.Forms.Button bt_Löschen;
        private System.Windows.Forms.Button bt_picture;
        private System.Windows.Forms.Button bt_ColorPicker;
        private System.Windows.Forms.Panel p_Color1;
        private System.Windows.Forms.Panel p_Color2;
        private System.Windows.Forms.Panel p_Color4;
        private System.Windows.Forms.Panel p_Color3;
        private System.Windows.Forms.Panel p_Color8;
        private System.Windows.Forms.Panel p_Color7;
        private System.Windows.Forms.Panel p_Color6;
        private System.Windows.Forms.Panel p_Color5;
    }
}
