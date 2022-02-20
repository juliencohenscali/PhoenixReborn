using System.ComponentModel;

namespace TTYRatServer
{
    partial class TreeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStripDropDownMenu1 = new System.Windows.Forms.ToolStripDropDownMenu();
            this.helloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(27, 17);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(751, 416);
            this.treeView1.TabIndex = 0;
            // 
            // toolStripDropDownMenu1
            // 
            this.toolStripDropDownMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.helloToolStripMenuItem});
            this.toolStripDropDownMenu1.Name = "toolStripDropDownMenu1";
            this.toolStripDropDownMenu1.Size = new System.Drawing.Size(153, 48);
            // 
            // helloToolStripMenuItem
            // 
            this.helloToolStripMenuItem.Name = "helloToolStripMenuItem";
            this.helloToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helloToolStripMenuItem.Text = "Hello";
            this.helloToolStripMenuItem.Click += new System.EventHandler(this.helloToolStripMenuItem_Click);
            // 
            // TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView1);
            this.Name = "TreeView";
            this.Text = "TreeView";
            this.toolStripDropDownMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolStripMenuItem helloToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownMenu toolStripDropDownMenu1;

        private System.Windows.Forms.TreeView treeView1;

        #endregion
    }
}