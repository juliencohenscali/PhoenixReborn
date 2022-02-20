using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
//using System.Threading; 
/*
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
*/
namespace TTYRatServer
{

    public partial class Menu : Form
    {

        //TcpListener tcpListener;
        private NewListener _tcpListener;
        //private StreamWriter _streamWriter;
        //public void updatePort(int port)

        public Menu()
        {
            InitializeComponent();
        }

        public void Menu_Shown(object sender, EventArgs e)
        {
            iplist.GridLines = true;
            iplist.Scrollable = true;
            iplist.View = View.Details;
        }


        #region UI Events

        public void Shell_Click(object sender, EventArgs e)
        {
            Form2 shell = new Form2(this,null);
            shell.Show();
        }

        private void getipButton_Click(object sender, EventArgs e)
        {

            NewListener listener = new NewListener(this, listenerStatus);
            _tcpListener = listener;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            string ipAddresses = "";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(
                " LOCAL IP ADRESSES \n This client may identify himself on his network with one of those IPs \n");
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            if (ipHost.ToString().Length != 0)
            {
                foreach (var ipAddress in ipHost.AddressList)
                {
                    if (_tcpListener.checkIPV4(ipAddress))
                    {
                        stringBuilder.Append(ipAddress + "\n");
                    }
                }
            }

            MessageBox.Show(stringBuilder.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_tcpListener._myTcpListener.Pending())
                {
                    Console.WriteLine("Pending");
                }
                else
                {
                    Console.WriteLine("Not Pending");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

        }

        #endregion


        #region Manipulation Of List

        public void UpdateList(string ip, string id, int port)
        {
            string strPort = port.ToString();
            ListViewItem newItem = iplist.Items.Add(ip);
            var newItemIndex = newItem.Index;
            iplist.Items[newItemIndex].SubItems.Add(strPort);
            iplist.Items[newItemIndex].SubItems.Add(id);
        }

        public void removeConnectionIPlist(IPAddress toRemove_Ip, ulong id)
        {
            if (id == 0)
            {
                //string torem_ip = toRemove_Ip.ToString();
                foreach (ListViewItem item in iplist.Items)
                {
                    ulong itemId = uint.Parse(item.SubItems[2].Text);
                    
                    if (itemId == id)
                    {
                        iplist.Items.Remove(item);
                    }

                }
            }
            else
            {
                ListViewItem[] toRemItem = iplist.Items.Find(id.ToString(), true);
                iplist.Items.Remove(toRemItem[0]);
            }




        }

        #endregion


        #region Manipulation Of Messages

        public string parseMessageIP(string message)
        {
            string ip = parseMessage(message)[0];
            return ip;
        }

        public string parseMessageID(string message)
        {
            string id = parseMessage(message)[1];
            return id;
        }

        public string[] parseMessage(string message)
        {
            string[] tmpList = message.Split(':');
            return tmpList;
        }

        #endregion

        private void selectNs()
        {
            if (iplist.SelectedItems.Count == 1)
            {
                object var;
                bool found = false;
                ulong id = UInt64.Parse(iplist.SelectedItems[0].SubItems[2].Text);
                var myTuple = (id, LocalVariables.ns_collection[0],LocalVariables.client_collection[0],IPAddress.Any);
                foreach (var elem in LocalVariables.ns_collection2)
                {
                    if (elem.Item1 == id && !found)
                    {
                        myTuple = elem;
                        found = true;
                    }
                }

                if (found)
                {
                    Form1 shell = new Form1(this, myTuple.Item2,myTuple.Item4,myTuple.id);
                    shell.Show();
                }
                else
                {
                    throw new Exception("selectNS : object not found in list");
                }

            }
        }
        
        
        private void iplist_DoubleClick(object sender, EventArgs e)
        {
            /*if (iplist.SelectedItems.Count == 1)
            {
                object var;
                ulong id = UInt64.Parse(iplist.SelectedItems[0].SubItems[2].Text);
                var myTuple = (id, LocalVariables.ns_collection[0]);
                bool found = false;
                foreach (var tuple in LocalVariables.ns_collection2)
                {
                    while (!found)
                    {
                        if (tuple.Item1 == id)
                        {
                            myTuple = tuple;
                            found = true;
                            
                        }
                    }
                }
                
                if (found)
                {
                    NetworkStream clientStream = myTuple.Item2;
                    administrate admin = new administrate(iplist.SelectedItems[0].SubItems[2].Text, 
                        clientStream, 
                        iplist.SelectedItems[0].SubItems[0].Text);
                    admin.Show();
                    commonData.ip_panel_pair.Add(iplist.SelectedItems[0].SubItems[0].Text, admin);
                }
                else
                {
                    throw new Exception("Tools : Can't find selected item in ns_collection");
                }
                
            }*/

            if (iplist.SelectedItems.Count == 1)
            {
                object var;
                bool found = false;
                ulong id = UInt64.Parse(iplist.SelectedItems[0].SubItems[2].Text);
                var myTuple = (id, LocalVariables.ns_collection[0],LocalVariables.client_collection[0],IPAddress.Any);
                foreach (var elem in LocalVariables.ns_collection2)
                {
                    if (elem.Item1 == id && !found)
                    {
                        myTuple = elem;
                        found = true;
                    }
                }

                if (found)
                {
                    Form1 shell = new Form1(this, myTuple.Item2,myTuple.Item4,myTuple.id);
                    shell.Show();
                }
                else
                {
                    throw new Exception("selectNS : object not found in list");
                }

            }
        }



        public class NewListener
        {
            private IPAddress _actualConnectedIp;
            private ulong _actualConnectedId;
            private readonly ToolStripStatusLabel _listenerStatusLabel;
            public TcpListener _myTcpListener;
            private Socket _mySocketForServer;
            private NetworkStream _myNetworkStream;
            private StreamWriter _myStreamWriter;
            private StreamReader _myStreamReader;
            private StringBuilder _myStrInput;
            public Thread myth_StartListen, th_RunClient;
            public readonly int myPort = 1600;
            public static Menu myMenu;


            public NewListener(Menu actual_menu, ToolStripStatusLabel status)
            {
                myMenu = actual_menu;
                _listenerStatusLabel = status;

                myth_StartListen = new Thread(StartListen);
                myth_StartListen.Start();
            }

            public void StartListen()
            {
                //int port = Int32.Parse(myMenu.portBox.Text);
                try
                {
                    _myTcpListener = new TcpListener(System.Net.IPAddress.Any, myPort);
                    _myTcpListener.Start();

                    _listenerStatusLabel.Text = "Started Listenening on port " + myPort;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


                for (;;)
                {
                    TcpClient client = _myTcpListener.AcceptTcpClient();
                    _myNetworkStream = client.GetStream();
                    LocalVariables.ns_collection.Add(_myNetworkStream);

                    byte[] received_message = new byte[client.ReceiveBufferSize];

                    ;

                    int readed_bytes = _myNetworkStream.Read(received_message, 0, client.ReceiveBufferSize);
                    string msg = Encoding.Default.GetString(received_message, 0, readed_bytes);
                    Console.WriteLine(msg);


                    ToolStripStatusLabel listenerStatus = _listenerStatusLabel;
                    string ip = myMenu.parseMessageIP(msg);
                    string id = myMenu.parseMessageID(msg);
                    listenerStatus.Text = "Received Connection From " + ip + " on port " + myPort;
                    _actualConnectedIp = IPAddress.Parse(ip);
                    _actualConnectedId = UInt64.Parse(id);
                
                    myMenu.UpdateList(ip, id, myPort);
                    LocalVariables.ns_collection.Add(_myNetworkStream);
                    LocalVariables.client_collection.Add(client);
                    LocalVariables.ns_collection2.Add((_actualConnectedId, _myNetworkStream,client,_actualConnectedIp));
                    //client.Close();
                    //_mySocketForServer = _myTcpListener.AcceptSocket();

                

                    //Write ip in list and close connection
                    //_mySocketForServer = _myTcpListener.AcceptSocket();
                    //IPEndPoint endPoint = IPEndPoint.Parse(_mySocketForServer.ToString());
                    //RunClient(myMenu,_mySocketForServer);
                }
            }
            
            public bool checkIPV4(IPAddress address_to_check)
            {
                string input = address_to_check.ToString();

                IPAddress address;
                if (IPAddress.TryParse(input, out address))
                {
                    switch (address.AddressFamily)
                    {
                        case System.Net.Sockets.AddressFamily.InterNetwork:
                            return true;
                        case System.Net.Sockets.AddressFamily.InterNetworkV6:
                            return false;
                        default:
                            return false;

                    }
                }

                return false;
            }
            

        }
    }
}