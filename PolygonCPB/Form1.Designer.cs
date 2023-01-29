namespace PolygonCPB
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
            this.формаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PointsCounter = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.формаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // формаToolStripMenuItem
            // 
            this.формаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.squareToolStripMenuItem,
            this.triangleToolStripMenuItem});
            this.формаToolStripMenuItem.Name = "формаToolStripMenuItem";
            this.формаToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.формаToolStripMenuItem.Text = "Форма";
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.circleToolStripMenuItem_Click);
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.CheckedChanged += new System.EventHandler(this.squareToolStripMenuItem_Click);
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.squareToolStripMenuItem_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.triangleToolStripMenuItem_Click);
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.triangleToolStripMenuItem_Click);
            // 
            // PointsCounter
            // 
            this.PointsCounter.AutoSize = true;
            this.PointsCounter.Location = new System.Drawing.Point(762, 24);
            this.PointsCounter.Name = "PointsCounter";
            this.PointsCounter.Size = new System.Drawing.Size(13, 15);
            this.PointsCounter.TabIndex = 1;
            this.PointsCounter.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PointsCounter);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem формаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.Label PointsCounter;
    }
}
