namespace UI.administrator
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.岩石识别管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单词词库管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.单词插入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单词更改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.岩石识别管理ToolStripMenuItem,
            this.单词词库管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 岩石识别管理ToolStripMenuItem
            // 
            this.岩石识别管理ToolStripMenuItem.Name = "岩石识别管理ToolStripMenuItem";
            this.岩石识别管理ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.岩石识别管理ToolStripMenuItem.Text = "岩石识别管理";
            this.岩石识别管理ToolStripMenuItem.Click += new System.EventHandler(this.岩石识别管理ToolStripMenuItem_Click);
            // 
            // 单词词库管理ToolStripMenuItem
            // 
            this.单词词库管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单词插入ToolStripMenuItem,
            this.单词更改ToolStripMenuItem});
            this.单词词库管理ToolStripMenuItem.Name = "单词词库管理ToolStripMenuItem";
            this.单词词库管理ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.单词词库管理ToolStripMenuItem.Text = "单词词库管理";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 646);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // 单词插入ToolStripMenuItem
            // 
            this.单词插入ToolStripMenuItem.Name = "单词插入ToolStripMenuItem";
            this.单词插入ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.单词插入ToolStripMenuItem.Text = "单词插入";
            this.单词插入ToolStripMenuItem.Click += new System.EventHandler(this.单词插入ToolStripMenuItem_Click);
            // 
            // 单词更改ToolStripMenuItem
            // 
            this.单词更改ToolStripMenuItem.Name = "单词更改ToolStripMenuItem";
            this.单词更改ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.单词更改ToolStripMenuItem.Text = "单词更改";
            this.单词更改ToolStripMenuItem.Click += new System.EventHandler(this.单词更改ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 674);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 岩石识别管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单词词库管理ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 单词插入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单词更改ToolStripMenuItem;
    }
}