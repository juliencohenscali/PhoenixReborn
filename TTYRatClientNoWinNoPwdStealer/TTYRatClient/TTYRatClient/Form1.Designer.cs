namespace TTYRatClient
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
            this.launchButton = new System.Windows.Forms.Button();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // launchButton
            // 
            this.launchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.launchButton.Location = new System.Drawing.Point(33, 29);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(261, 165);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "Start Server";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(46, 251);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(214, 20);
            this.ipBox.TabIndex = 1;
            this.ipBox.Text = "127.0.0.1";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(46, 345);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(214, 20);
            this.portBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(46, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP";
            // 
            // portLabel
            // 
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.portLabel.Location = new System.Drawing.Point(46, 313);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(79, 29);
            this.portLabel.TabIndex = 4;
            this.portLabel.Text = "PORT";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(699, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel1.Text = "Ready !";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 440);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.launchButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.TextBox portBox;

        private System.Windows.Forms.Button launchButton;

        #endregion
    }
}

