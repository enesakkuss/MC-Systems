namespace McSystems.Presentation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rezervasyonYönetimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervasyonListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rezervasyonYönetimiToolStripMenuItem,
            this.rezervasyonListesiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rezervasyonYönetimiToolStripMenuItem
            // 
            this.rezervasyonYönetimiToolStripMenuItem.Name = "rezervasyonYönetimiToolStripMenuItem";
            this.rezervasyonYönetimiToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.rezervasyonYönetimiToolStripMenuItem.Text = "Rezervasyon Yönetimi";
            this.rezervasyonYönetimiToolStripMenuItem.Click += new System.EventHandler(this.rezervasyonYönetimiToolStripMenuItem_Click);
            // 
            // rezervasyonListesiToolStripMenuItem
            // 
            this.rezervasyonListesiToolStripMenuItem.Name = "rezervasyonListesiToolStripMenuItem";
            this.rezervasyonListesiToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.rezervasyonListesiToolStripMenuItem.Text = "Rezervasyon Listesi";
            this.rezervasyonListesiToolStripMenuItem.Click += new System.EventHandler(this.rezervasyonListesiToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Yönetim Ekranı";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem rezervasyonYönetimiToolStripMenuItem;
        private ToolStripMenuItem rezervasyonListesiToolStripMenuItem;
    }
}