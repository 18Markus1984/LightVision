namespace LightVisionSettings
{
    partial class LightVision_Base
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.p_Nav = new System.Windows.Forms.Panel();
            this.bt_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_Einstellungen = new System.Windows.Forms.Button();
            this.bt_Kacheln = new System.Windows.Forms.Button();
            this.bt_Wecker = new System.Windows.Forms.Button();
            this.p_Content = new System.Windows.Forms.Panel();
            this.p_Slider = new System.Windows.Forms.Panel();
            this.kacheln1 = new LightVisionSettings.Kacheln();
            this.p_Nav.SuspendLayout();
            this.panel1.SuspendLayout();
            this.p_Content.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Nav
            // 
            this.p_Nav.BackColor = System.Drawing.Color.Black;
            this.p_Nav.Controls.Add(this.bt_Close);
            this.p_Nav.Controls.Add(this.label1);
            this.p_Nav.Controls.Add(this.panel1);
            this.p_Nav.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_Nav.Location = new System.Drawing.Point(0, 0);
            this.p_Nav.Name = "p_Nav";
            this.p_Nav.Size = new System.Drawing.Size(172, 538);
            this.p_Nav.TabIndex = 0;
            // 
            // bt_Close
            // 
            this.bt_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bt_Close.FlatAppearance.BorderSize = 0;
            this.bt_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Close.Font = new System.Drawing.Font("Forte", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Close.ForeColor = System.Drawing.Color.White;
            this.bt_Close.Location = new System.Drawing.Point(0, 498);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(172, 40);
            this.bt_Close.TabIndex = 1;
            this.bt_Close.Text = "Beenden";
            this.bt_Close.UseVisualStyleBackColor = false;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Forte", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "LightVision";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_Einstellungen);
            this.panel1.Controls.Add(this.bt_Kacheln);
            this.panel1.Controls.Add(this.bt_Wecker);
            this.panel1.Location = new System.Drawing.Point(0, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 254);
            this.panel1.TabIndex = 0;
            // 
            // bt_Einstellungen
            // 
            this.bt_Einstellungen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bt_Einstellungen.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_Einstellungen.FlatAppearance.BorderSize = 0;
            this.bt_Einstellungen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Einstellungen.Font = new System.Drawing.Font("Forte", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Einstellungen.ForeColor = System.Drawing.Color.White;
            this.bt_Einstellungen.Location = new System.Drawing.Point(0, 80);
            this.bt_Einstellungen.Name = "bt_Einstellungen";
            this.bt_Einstellungen.Size = new System.Drawing.Size(172, 40);
            this.bt_Einstellungen.TabIndex = 3;
            this.bt_Einstellungen.Text = "Einstellungen";
            this.bt_Einstellungen.UseVisualStyleBackColor = false;
            this.bt_Einstellungen.Click += new System.EventHandler(this.bt_Einstellungen_Click);
            // 
            // bt_Kacheln
            // 
            this.bt_Kacheln.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bt_Kacheln.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_Kacheln.FlatAppearance.BorderSize = 0;
            this.bt_Kacheln.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Kacheln.Font = new System.Drawing.Font("Forte", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Kacheln.ForeColor = System.Drawing.Color.White;
            this.bt_Kacheln.Location = new System.Drawing.Point(0, 40);
            this.bt_Kacheln.Name = "bt_Kacheln";
            this.bt_Kacheln.Size = new System.Drawing.Size(172, 40);
            this.bt_Kacheln.TabIndex = 2;
            this.bt_Kacheln.Text = "Kacheln";
            this.bt_Kacheln.UseVisualStyleBackColor = false;
            this.bt_Kacheln.Click += new System.EventHandler(this.bt_Kacheln_Click);
            // 
            // bt_Wecker
            // 
            this.bt_Wecker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bt_Wecker.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_Wecker.FlatAppearance.BorderSize = 0;
            this.bt_Wecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Wecker.Font = new System.Drawing.Font("Forte", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Wecker.ForeColor = System.Drawing.Color.White;
            this.bt_Wecker.Location = new System.Drawing.Point(0, 0);
            this.bt_Wecker.Name = "bt_Wecker";
            this.bt_Wecker.Size = new System.Drawing.Size(172, 40);
            this.bt_Wecker.TabIndex = 1;
            this.bt_Wecker.Text = "Wecker";
            this.bt_Wecker.UseVisualStyleBackColor = false;
            this.bt_Wecker.Click += new System.EventHandler(this.bt_Wecker_Click);
            // 
            // p_Content
            // 
            this.p_Content.Controls.Add(this.kacheln1);
            this.p_Content.Controls.Add(this.p_Slider);
            this.p_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Content.Location = new System.Drawing.Point(172, 0);
            this.p_Content.Name = "p_Content";
            this.p_Content.Size = new System.Drawing.Size(786, 538);
            this.p_Content.TabIndex = 1;
            // 
            // p_Slider
            // 
            this.p_Slider.BackColor = System.Drawing.Color.Black;
            this.p_Slider.Location = new System.Drawing.Point(0, 166);
            this.p_Slider.Name = "p_Slider";
            this.p_Slider.Size = new System.Drawing.Size(5, 40);
            this.p_Slider.TabIndex = 0;
            // 
            // kacheln1
            // 
            this.kacheln1.Location = new System.Drawing.Point(0, 0);
            this.kacheln1.Name = "kacheln1";
            this.kacheln1.Size = new System.Drawing.Size(786, 538);
            this.kacheln1.TabIndex = 1;
            // 
            // LightVision_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 538);
            this.ControlBox = false;
            this.Controls.Add(this.p_Content);
            this.Controls.Add(this.p_Nav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LightVision_Base";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.p_Nav.ResumeLayout(false);
            this.p_Nav.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.p_Content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Nav;
        private System.Windows.Forms.Button bt_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_Wecker;
        private System.Windows.Forms.Panel p_Content;
        private System.Windows.Forms.Button bt_Einstellungen;
        private System.Windows.Forms.Button bt_Kacheln;
        private System.Windows.Forms.Panel p_Slider;
        private Kacheln kacheln1;
    }
}

