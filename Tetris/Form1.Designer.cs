namespace Tetris
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TimTetris = new System.Windows.Forms.Timer(this.components);
            this.PanUnten = new System.Windows.Forms.Panel();
            this.PanRechts = new System.Windows.Forms.Panel();
            this.PanLinks = new System.Windows.Forms.Panel();
            this.CmdPause = new System.Windows.Forms.Button();
            this.CmdRechts = new System.Windows.Forms.Button();
            this.CmdUnten = new System.Windows.Forms.Button();
            this.CmdLinks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TimTetris
            // 
            this.TimTetris.Enabled = true;
            this.TimTetris.Interval = 500;
            this.TimTetris.Tick += new System.EventHandler(this.TimTetris_Tick);
            // 
            // PanUnten
            // 
            this.PanUnten.BackColor = System.Drawing.Color.Black;
            this.PanUnten.Location = new System.Drawing.Point(24, 337);
            this.PanUnten.Name = "PanUnten";
            this.PanUnten.Size = new System.Drawing.Size(160, 1);
            this.PanUnten.TabIndex = 56;
            // 
            // PanRechts
            // 
            this.PanRechts.BackColor = System.Drawing.Color.Black;
            this.PanRechts.Location = new System.Drawing.Point(184, 77);
            this.PanRechts.Name = "PanRechts";
            this.PanRechts.Size = new System.Drawing.Size(1, 260);
            this.PanRechts.TabIndex = 55;
            // 
            // PanLinks
            // 
            this.PanLinks.BackColor = System.Drawing.Color.Black;
            this.PanLinks.Location = new System.Drawing.Point(24, 77);
            this.PanLinks.Name = "PanLinks";
            this.PanLinks.Size = new System.Drawing.Size(1, 260);
            this.PanLinks.TabIndex = 54;
            // 
            // CmdPause
            // 
            this.CmdPause.Location = new System.Drawing.Point(70, 361);
            this.CmdPause.Name = "CmdPause";
            this.CmdPause.Size = new System.Drawing.Size(70, 28);
            this.CmdPause.TabIndex = 53;
            this.CmdPause.Text = "Pause";
            this.CmdPause.UseVisualStyleBackColor = true;
            this.CmdPause.Click += new System.EventHandler(this.CmdPause_Click);
            // 
            // CmdRechts
            // 
            this.CmdRechts.Location = new System.Drawing.Point(124, 12);
            this.CmdRechts.Name = "CmdRechts";
            this.CmdRechts.Size = new System.Drawing.Size(40, 28);
            this.CmdRechts.TabIndex = 52;
            this.CmdRechts.Text = "Re";
            this.CmdRechts.UseVisualStyleBackColor = true;
            this.CmdRechts.Click += new System.EventHandler(this.CmdRechts_Click);
            // 
            // CmdUnten
            // 
            this.CmdUnten.Location = new System.Drawing.Point(84, 47);
            this.CmdUnten.Name = "CmdUnten";
            this.CmdUnten.Size = new System.Drawing.Size(40, 28);
            this.CmdUnten.TabIndex = 51;
            this.CmdUnten.Text = "Dr";
            this.CmdUnten.UseVisualStyleBackColor = true;
            this.CmdUnten.Click += new System.EventHandler(this.CmdUnten_Click);
            // 
            // CmdLinks
            // 
            this.CmdLinks.Location = new System.Drawing.Point(44, 12);
            this.CmdLinks.Name = "CmdLinks";
            this.CmdLinks.Size = new System.Drawing.Size(40, 28);
            this.CmdLinks.TabIndex = 50;
            this.CmdLinks.Text = "Li";
            this.CmdLinks.UseVisualStyleBackColor = true;
            this.CmdLinks.Click += new System.EventHandler(this.CmdLinks_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 401);
            this.Controls.Add(this.PanUnten);
            this.Controls.Add(this.PanRechts);
            this.Controls.Add(this.PanLinks);
            this.Controls.Add(this.CmdPause);
            this.Controls.Add(this.CmdRechts);
            this.Controls.Add(this.CmdUnten);
            this.Controls.Add(this.CmdLinks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Timer TimTetris;
        internal System.Windows.Forms.Panel PanUnten;
        internal System.Windows.Forms.Panel PanRechts;
        internal System.Windows.Forms.Panel PanLinks;
        internal System.Windows.Forms.Button CmdPause;
        internal System.Windows.Forms.Button CmdRechts;
        internal System.Windows.Forms.Button CmdUnten;
        internal System.Windows.Forms.Button CmdLinks;
    }
}

