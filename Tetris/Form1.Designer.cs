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
            this.label1 = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.scoreOpen = new System.Windows.Forms.Button();
            this.top = new System.Windows.Forms.Label();
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
            this.PanUnten.Location = new System.Drawing.Point(25, 336);
            this.PanUnten.Name = "PanUnten";
            this.PanUnten.Size = new System.Drawing.Size(160, 1);
            this.PanUnten.TabIndex = 56;
            // 
            // PanRechts
            // 
            this.PanRechts.BackColor = System.Drawing.Color.Black;
            this.PanRechts.Location = new System.Drawing.Point(185, 77);
            this.PanRechts.Name = "PanRechts";
            this.PanRechts.Size = new System.Drawing.Size(1, 260);
            this.PanRechts.TabIndex = 55;
            // 
            // PanLinks
            // 
            this.PanLinks.BackColor = System.Drawing.Color.Black;
            this.PanLinks.Location = new System.Drawing.Point(25, 77);
            this.PanLinks.Name = "PanLinks";
            this.PanLinks.Size = new System.Drawing.Size(1, 260);
            this.PanLinks.TabIndex = 54;
            // 
            // CmdPause
            // 
            this.CmdPause.Location = new System.Drawing.Point(68, 352);
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
            this.CmdUnten.Location = new System.Drawing.Point(85, 39);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Score:";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Location = new System.Drawing.Point(70, 402);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(61, 13);
            this.score.TabIndex = 58;
            this.score.Text = "Score Here";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(25, 425);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 13);
            this.nameLabel.TabIndex = 59;
            this.nameLabel.Text = "Name: ";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(71, 425);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(61, 13);
            this.name.TabIndex = 60;
            this.name.Text = "Name Here";
            // 
            // scoreOpen
            // 
            this.scoreOpen.Location = new System.Drawing.Point(141, 400);
            this.scoreOpen.Name = "scoreOpen";
            this.scoreOpen.Size = new System.Drawing.Size(71, 41);
            this.scoreOpen.TabIndex = 61;
            this.scoreOpen.Text = "Show Scoreboard";
            this.scoreOpen.UseVisualStyleBackColor = true;
            this.scoreOpen.Click += new System.EventHandler(this.scoreOpen_Click);
            // 
            // top
            // 
            this.top.AutoSize = true;
            this.top.Location = new System.Drawing.Point(25, 449);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(63, 13);
            this.top.TabIndex = 62;
            this.top.Text = "Top Score: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(232, 474);
            this.Controls.Add(this.top);
            this.Controls.Add(this.scoreOpen);
            this.Controls.Add(this.name);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.score);
            this.Controls.Add(this.label1);
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
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button scoreOpen;
        private System.Windows.Forms.Label top;
    }
}

