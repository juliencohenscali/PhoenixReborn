
namespace TTYRatServer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.shellWin = new System.Windows.Forms.TextBox();
            this.cmdbox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.StartListernerbutton = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shellWin
            // 
            this.shellWin.BackColor = System.Drawing.Color.Black;
            this.shellWin.Dock = System.Windows.Forms.DockStyle.Top;
            this.shellWin.ForeColor = System.Drawing.Color.Lime;
            this.shellWin.Location = new System.Drawing.Point(0, 0);
            this.shellWin.Multiline = true;
            this.shellWin.Name = "shellWin";
            this.shellWin.ReadOnly = true;
            this.shellWin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.shellWin.Size = new System.Drawing.Size(726, 348);
            this.shellWin.TabIndex = 0;
            // 
            // cmdbox
            // 
            this.cmdbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdbox.Location = new System.Drawing.Point(0, 348);
            this.cmdbox.Name = "cmdbox";
            this.cmdbox.Size = new System.Drawing.Size(726, 20);
            this.cmdbox.TabIndex = 1;
            this.cmdbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(726, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(45, 17);
            this.status.Text = "Ready !";
            // 
            // StartListernerbutton
            // 
            this.StartListernerbutton.Enabled = false;
            this.StartListernerbutton.Location = new System.Drawing.Point(13, 377);
            this.StartListernerbutton.Name = "StartListernerbutton";
            this.StartListernerbutton.Size = new System.Drawing.Size(126, 46);
            this.StartListernerbutton.TabIndex = 3;
            this.StartListernerbutton.Text = "Start Listener";
            this.StartListernerbutton.UseVisualStyleBackColor = true;
            this.StartListernerbutton.Click += new System.EventHandler(this.StartListernerbutton_Click);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(14, 430);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(124, 20);
            this.portBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 46);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start Listener";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 508);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.StartListernerbutton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdbox);
            this.Controls.Add(this.shellWin);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Reverse Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TextBox portBox;

        private System.Windows.Forms.Button StartListernerbutton;

        #endregion

        private System.Windows.Forms.TextBox shellWin;
        private System.Windows.Forms.TextBox cmdbox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
    }
}

