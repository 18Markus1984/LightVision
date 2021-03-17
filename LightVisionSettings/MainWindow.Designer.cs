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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightVision_Base));
            this.p_Nav = new System.Windows.Forms.Panel();
            this.bt_Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.p_Content = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bt_Settings = new System.Windows.Forms.Button();
            this.bt_Dashboard = new System.Windows.Forms.Button();
            this.bt_Templates = new System.Windows.Forms.Button();
            this.bt_Animator = new System.Windows.Forms.Button();
            this.bt_Editor = new System.Windows.Forms.Button();
            this.p_Nav.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Nav
            // 
            this.p_Nav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(95)))));
            this.p_Nav.Controls.Add(this.bt_Close);
            this.p_Nav.Controls.Add(this.panel1);
            this.p_Nav.Controls.Add(this.panel2);
            this.p_Nav.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_Nav.Location = new System.Drawing.Point(0, 0);
            this.p_Nav.Name = "p_Nav";
            this.p_Nav.Size = new System.Drawing.Size(172, 458);
            this.p_Nav.TabIndex = 0;
            this.p_Nav.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // bt_Close
            // 
            this.bt_Close.BackColor = System.Drawing.Color.Transparent;
            this.bt_Close.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bt_Close.FlatAppearance.BorderSize = 0;
            this.bt_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Close.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.bt_Close.ForeColor = System.Drawing.Color.White;
            this.bt_Close.Location = new System.Drawing.Point(0, 418);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(172, 40);
            this.bt_Close.TabIndex = 1;
            this.bt_Close.Text = "Beenden";
            this.bt_Close.UseVisualStyleBackColor = false;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_Settings);
            this.panel1.Controls.Add(this.bt_Dashboard);
            this.panel1.Controls.Add(this.bt_Templates);
            this.panel1.Controls.Add(this.bt_Animator);
            this.panel1.Controls.Add(this.bt_Editor);
            this.panel1.Location = new System.Drawing.Point(0, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 214);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 117);
            this.panel2.TabIndex = 2;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Forte", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "LightVision";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // p_Content
            // 
            this.p_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(147)))), ((int)(((byte)(72)))));
            this.p_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Content.Location = new System.Drawing.Point(172, 0);
            this.p_Content.Name = "p_Content";
            this.p_Content.Size = new System.Drawing.Size(747, 458);
            this.p_Content.TabIndex = 1;
            this.p_Content.Paint += new System.Windows.Forms.PaintEventHandler(this.p_Content_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bt_Settings
            // 
            this.bt_Settings.BackColor = System.Drawing.Color.Transparent;
            this.bt_Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_Settings.FlatAppearance.BorderSize = 0;
            this.bt_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Settings.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.bt_Settings.ForeColor = System.Drawing.Color.White;
            this.bt_Settings.Image = global::LightVisionSettings.Properties.Resources.gears_30px;
            this.bt_Settings.Location = new System.Drawing.Point(0, 160);
            this.bt_Settings.Name = "bt_Settings";
            this.bt_Settings.Size = new System.Drawing.Size(172, 40);
            this.bt_Settings.TabIndex = 5;
            this.bt_Settings.Text = "Settings      ";
            this.bt_Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.bt_Settings.UseVisualStyleBackColor = false;
            this.bt_Settings.Click += new System.EventHandler(this.bt_Settings_Click);
            // 
            // bt_Dashboard
            // 
            this.bt_Dashboard.BackColor = System.Drawing.Color.Transparent;
            this.bt_Dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_Dashboard.FlatAppearance.BorderSize = 0;
            this.bt_Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Dashboard.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.bt_Dashboard.ForeColor = System.Drawing.Color.White;
            this.bt_Dashboard.Image = global::LightVisionSettings.Properties.Resources.Dashboard_Layout_24px;
            this.bt_Dashboard.Location = new System.Drawing.Point(0, 120);
            this.bt_Dashboard.Name = "bt_Dashboard";
            this.bt_Dashboard.Size = new System.Drawing.Size(172, 40);
            this.bt_Dashboard.TabIndex = 4;
            this.bt_Dashboard.Text = "Dashboard";
            this.bt_Dashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.bt_Dashboard.UseVisualStyleBackColor = false;
            this.bt_Dashboard.Click += new System.EventHandler(this.bt_Dashboard_Click);
            // 
            // bt_Templates
            // 
            this.bt_Templates.BackColor = System.Drawing.Color.Transparent;
            this.bt_Templates.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_Templates.FlatAppearance.BorderSize = 0;
            this.bt_Templates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Templates.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.bt_Templates.ForeColor = System.Drawing.Color.White;
            this.bt_Templates.Image = global::LightVisionSettings.Properties.Resources.home_24px;
            this.bt_Templates.Location = new System.Drawing.Point(0, 80);
            this.bt_Templates.Name = "bt_Templates";
            this.bt_Templates.Size = new System.Drawing.Size(172, 40);
            this.bt_Templates.TabIndex = 3;
            this.bt_Templates.Text = "Templates  ";
            this.bt_Templates.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.bt_Templates.UseVisualStyleBackColor = false;
            this.bt_Templates.Click += new System.EventHandler(this.bt_templates_Click);
            // 
            // bt_Animator
            // 
            this.bt_Animator.BackColor = System.Drawing.Color.Transparent;
            this.bt_Animator.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_Animator.FlatAppearance.BorderSize = 0;
            this.bt_Animator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Animator.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.bt_Animator.ForeColor = System.Drawing.Color.White;
            this.bt_Animator.Image = global::LightVisionSettings.Properties.Resources.play_24px;
            this.bt_Animator.Location = new System.Drawing.Point(0, 40);
            this.bt_Animator.Name = "bt_Animator";
            this.bt_Animator.Size = new System.Drawing.Size(172, 40);
            this.bt_Animator.TabIndex = 2;
            this.bt_Animator.Text = "Animator    ";
            this.bt_Animator.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.bt_Animator.UseVisualStyleBackColor = false;
            this.bt_Animator.Click += new System.EventHandler(this.bt_Animator_Click);
            // 
            // bt_Editor
            // 
            this.bt_Editor.BackColor = System.Drawing.Color.Transparent;
            this.bt_Editor.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_Editor.FlatAppearance.BorderSize = 0;
            this.bt_Editor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Editor.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.bt_Editor.ForeColor = System.Drawing.Color.White;
            this.bt_Editor.Image = global::LightVisionSettings.Properties.Resources.pencil_24px;
            this.bt_Editor.Location = new System.Drawing.Point(0, 0);
            this.bt_Editor.Name = "bt_Editor";
            this.bt_Editor.Size = new System.Drawing.Size(172, 40);
            this.bt_Editor.TabIndex = 1;
            this.bt_Editor.Text = "Editor         ";
            this.bt_Editor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.bt_Editor.UseVisualStyleBackColor = false;
            this.bt_Editor.Click += new System.EventHandler(this.bt_Editor_Click);
            // 
            // LightVision_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 458);
            this.ControlBox = false;
            this.Controls.Add(this.p_Content);
            this.Controls.Add(this.p_Nav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LightVision_Base";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.p_Nav.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Nav;
        private System.Windows.Forms.Button bt_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_Editor;
        private System.Windows.Forms.Panel p_Content;
        private System.Windows.Forms.Button bt_Templates;
        private System.Windows.Forms.Button bt_Animator;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_Dashboard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bt_Settings;
    }
}

