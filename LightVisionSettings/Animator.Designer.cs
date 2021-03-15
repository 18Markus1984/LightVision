
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
            this.tb_showtime = new System.Windows.Forms.TextBox();
            this.tb_NamePanel = new System.Windows.Forms.TextBox();
            this.bt_NewPanel = new System.Windows.Forms.Button();
            this.cb_SelectedPanal = new System.Windows.Forms.ComboBox();
            this.bt_Color = new System.Windows.Forms.Button();
            this.bt_Löschen = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.number = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Tamplate = new System.Windows.Forms.Button();
            this.bt_fill = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_color8 = new System.Windows.Forms.Button();
            this.bt_color7 = new System.Windows.Forms.Button();
            this.bt_color6 = new System.Windows.Forms.Button();
            this.bt_color5 = new System.Windows.Forms.Button();
            this.bt_color4 = new System.Windows.Forms.Button();
            this.bt_color3 = new System.Windows.Forms.Button();
            this.bt_color2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_picture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.number)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_showtime
            // 
            this.tb_showtime.Location = new System.Drawing.Point(633, 302);
            this.tb_showtime.Name = "tb_showtime";
            this.tb_showtime.Size = new System.Drawing.Size(100, 20);
            this.tb_showtime.TabIndex = 15;
            this.tb_showtime.MouseLeave += new System.EventHandler(this.tb_showtime_MouseLeave);
            // 
            // tb_NamePanel
            // 
            this.tb_NamePanel.Location = new System.Drawing.Point(472, 302);
            this.tb_NamePanel.Name = "tb_NamePanel";
            this.tb_NamePanel.Size = new System.Drawing.Size(155, 20);
            this.tb_NamePanel.TabIndex = 14;
            // 
            // bt_NewPanel
            // 
            this.bt_NewPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_NewPanel.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_NewPanel.Location = new System.Drawing.Point(405, 302);
            this.bt_NewPanel.Name = "bt_NewPanel";
            this.bt_NewPanel.Size = new System.Drawing.Size(61, 41);
            this.bt_NewPanel.TabIndex = 13;
            this.bt_NewPanel.Text = "Neu";
            this.bt_NewPanel.UseVisualStyleBackColor = true;
            this.bt_NewPanel.Click += new System.EventHandler(this.bt_NewPanel_Click);
            // 
            // cb_SelectedPanal
            // 
            this.cb_SelectedPanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectedPanal.FormattingEnabled = true;
            this.cb_SelectedPanal.Location = new System.Drawing.Point(472, 328);
            this.cb_SelectedPanal.Name = "cb_SelectedPanal";
            this.cb_SelectedPanal.Size = new System.Drawing.Size(155, 21);
            this.cb_SelectedPanal.TabIndex = 12;
            this.cb_SelectedPanal.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedPanal_SelectedIndexChanged);
            // 
            // bt_Color
            // 
            this.bt_Color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Color.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Color.Location = new System.Drawing.Point(123, 302);
            this.bt_Color.Name = "bt_Color";
            this.bt_Color.Size = new System.Drawing.Size(41, 41);
            this.bt_Color.TabIndex = 9;
            this.bt_Color.Text = "Farbe";
            this.bt_Color.UseVisualStyleBackColor = true;
            this.bt_Color.Click += new System.EventHandler(this.bt_Color_Click_1);
            // 
            // bt_Löschen
            // 
            this.bt_Löschen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Löschen.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Löschen.Location = new System.Drawing.Point(13, 302);
            this.bt_Löschen.Name = "bt_Löschen";
            this.bt_Löschen.Size = new System.Drawing.Size(91, 41);
            this.bt_Löschen.TabIndex = 8;
            this.bt_Löschen.Text = "Löschen";
            this.bt_Löschen.UseVisualStyleBackColor = true;
            this.bt_Löschen.Click += new System.EventHandler(this.bt_Löschen_Click);
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(633, 329);
            this.number.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.number.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(100, 20);
            this.number.TabIndex = 16;
            this.number.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // bt_Tamplate
            // 
            this.bt_Tamplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Tamplate.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Tamplate.Location = new System.Drawing.Point(13, 349);
            this.bt_Tamplate.Name = "bt_Tamplate";
            this.bt_Tamplate.Size = new System.Drawing.Size(91, 41);
            this.bt_Tamplate.TabIndex = 18;
            this.bt_Tamplate.Text = "Template";
            this.bt_Tamplate.UseVisualStyleBackColor = true;
            // 
            // bt_fill
            // 
            this.bt_fill.BackgroundImage = global::LightVisionSettings.Properties.Resources.fill_color_24px;
            this.bt_fill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_fill.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_fill.Location = new System.Drawing.Point(358, 302);
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
            this.bt_clear.Location = new System.Drawing.Point(311, 302);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(41, 41);
            this.bt_clear.TabIndex = 10;
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // bt_color8
            // 
            this.bt_color8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_color8.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_color8.Location = new System.Drawing.Point(264, 349);
            this.bt_color8.Name = "bt_color8";
            this.bt_color8.Size = new System.Drawing.Size(41, 41);
            this.bt_color8.TabIndex = 26;
            this.bt_color8.Text = "F1";
            this.bt_color8.UseVisualStyleBackColor = true;
            // 
            // bt_color7
            // 
            this.bt_color7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_color7.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_color7.Location = new System.Drawing.Point(217, 349);
            this.bt_color7.Name = "bt_color7";
            this.bt_color7.Size = new System.Drawing.Size(41, 41);
            this.bt_color7.TabIndex = 25;
            this.bt_color7.Text = "F1";
            this.bt_color7.UseVisualStyleBackColor = true;
            // 
            // bt_color6
            // 
            this.bt_color6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_color6.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_color6.Location = new System.Drawing.Point(170, 349);
            this.bt_color6.Name = "bt_color6";
            this.bt_color6.Size = new System.Drawing.Size(41, 41);
            this.bt_color6.TabIndex = 24;
            this.bt_color6.Text = "F1";
            this.bt_color6.UseVisualStyleBackColor = true;
            // 
            // bt_color5
            // 
            this.bt_color5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_color5.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_color5.Location = new System.Drawing.Point(123, 349);
            this.bt_color5.Name = "bt_color5";
            this.bt_color5.Size = new System.Drawing.Size(41, 41);
            this.bt_color5.TabIndex = 23;
            this.bt_color5.Text = "F1";
            this.bt_color5.UseVisualStyleBackColor = true;
            // 
            // bt_color4
            // 
            this.bt_color4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_color4.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_color4.Location = new System.Drawing.Point(264, 302);
            this.bt_color4.Name = "bt_color4";
            this.bt_color4.Size = new System.Drawing.Size(41, 41);
            this.bt_color4.TabIndex = 22;
            this.bt_color4.Text = "F1";
            this.bt_color4.UseVisualStyleBackColor = true;
            // 
            // bt_color3
            // 
            this.bt_color3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_color3.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_color3.Location = new System.Drawing.Point(217, 302);
            this.bt_color3.Name = "bt_color3";
            this.bt_color3.Size = new System.Drawing.Size(41, 41);
            this.bt_color3.TabIndex = 21;
            this.bt_color3.Text = "F1";
            this.bt_color3.UseVisualStyleBackColor = true;
            // 
            // bt_color2
            // 
            this.bt_color2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_color2.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_color2.Location = new System.Drawing.Point(170, 302);
            this.bt_color2.Name = "bt_color2";
            this.bt_color2.Size = new System.Drawing.Size(41, 41);
            this.bt_color2.TabIndex = 20;
            this.bt_color2.Text = "F1";
            this.bt_color2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::LightVisionSettings.Properties.Resources.color_dropper_30px;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(358, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 41);
            this.button1.TabIndex = 28;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bt_picture
            // 
            this.bt_picture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_picture.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_picture.Location = new System.Drawing.Point(405, 349);
            this.bt_picture.Name = "bt_picture";
            this.bt_picture.Size = new System.Drawing.Size(61, 41);
            this.bt_picture.TabIndex = 27;
            this.bt_picture.Text = "Bild";
            this.bt_picture.UseVisualStyleBackColor = true;
            // 
            // Animator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(147)))), ((int)(((byte)(72)))));
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_picture);
            this.Controls.Add(this.bt_color8);
            this.Controls.Add(this.bt_color7);
            this.Controls.Add(this.bt_color6);
            this.Controls.Add(this.bt_color5);
            this.Controls.Add(this.bt_color4);
            this.Controls.Add(this.bt_color3);
            this.Controls.Add(this.bt_color2);
            this.Controls.Add(this.bt_Tamplate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.number);
            this.Controls.Add(this.tb_showtime);
            this.Controls.Add(this.tb_NamePanel);
            this.Controls.Add(this.bt_NewPanel);
            this.Controls.Add(this.cb_SelectedPanal);
            this.Controls.Add(this.bt_fill);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_Color);
            this.Controls.Add(this.bt_Löschen);
            this.Name = "Animator";
            this.Size = new System.Drawing.Size(820, 517);
            ((System.ComponentModel.ISupportInitialize)(this.number)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_showtime;
        private System.Windows.Forms.TextBox tb_NamePanel;
        private System.Windows.Forms.Button bt_NewPanel;
        private System.Windows.Forms.ComboBox cb_SelectedPanal;
        private System.Windows.Forms.Button bt_fill;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_Color;
        private System.Windows.Forms.Button bt_Löschen;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Tamplate;
        private System.Windows.Forms.Button bt_color8;
        private System.Windows.Forms.Button bt_color7;
        private System.Windows.Forms.Button bt_color6;
        private System.Windows.Forms.Button bt_color5;
        private System.Windows.Forms.Button bt_color4;
        private System.Windows.Forms.Button bt_color3;
        private System.Windows.Forms.Button bt_color2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bt_picture;
    }
}
