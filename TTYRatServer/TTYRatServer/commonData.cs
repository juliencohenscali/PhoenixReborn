using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using TTYRatServer;

namespace TTYRatServer
{
    class commonData
    {
        
        public static Dictionary<string, administrate> ip_panel_pair = new Dictionary<string, administrate>();

        // Random set of bytes in order to check the validity of the incoming package
        // This set can be of any size
        public static byte[] scheme = { 21, 36, 47, 71, 99, 61, 71, 71, 99, 255, 254, 253,
                            36, 45, 66, 253, 21, 46, 47, 66, 39, 41, 66, 99, 
                            253, 252, 251, 216, 222, 221, 216, 99, 41, 56, 57, 58, 3};

        // The set of bytes sent when valid data is received from the client
        // This byte array is consisting of arbitrary bytes and can be altered if needed - keep in mind that you should 
        //   also change it on the client side
        public static byte[] recv_signal = { 20, 26, 91, 36, 71, 64, 63, 99, 251, 253, 69, 31, 31,
                                 72, 69, 109, 101, 108, 97, 110, 105, 101, 109, 101, 108};

        public static void sendMessage(string message, NetworkStream clientStream) //Wrap string to be able to send it
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(clientStream);
                char[] tmp = { };
                byte[] msgToSend = ASCIIEncoding.ASCII.GetBytes(message);
                foreach (var c in message)
                {
                    tmp.Append(c);
                }
                Console.WriteLine("msg to send : " + message);
                streamWriter.Write(msgToSend);
                Console.WriteLine("message : " + message + " sent !!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
            
            
        }

        public static void decryptMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}
/*
 byte[] received_message = new byte[client.ReceiveBufferSize];
            
//Read Received Message with  myNetworkStream.Read(received_message,0,client.ReceiveBufferSize)
//and write it into an int ReadedBytes
int readed_bytes = networkStream.Read(received_message,0,client.ReceiveBufferSize);
string msg = Encoding.Default.GetString(received_message,0,readed_bytes);
string client_ip = menu.parseMessageIP(msg);
string client_id = menu.parseMessageID(msg);
*/