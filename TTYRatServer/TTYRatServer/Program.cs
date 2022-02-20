using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TTYRatServer
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
    
    public class LocalVariables
    {
        public static List<(ulong, NetworkStream,TcpClient,IPAddress)> ns_collection2 = new List<(ulong, NetworkStream, TcpClient, IPAddress)>();
        public static List <NetworkStream> ns_collection = new List<NetworkStream>();
        public static List<TcpClient> client_collection = new List<TcpClient>();
        public static List<int> port_list = new List<int>();
        public static List<string> global_ip_list = new List<string>();
    }
}