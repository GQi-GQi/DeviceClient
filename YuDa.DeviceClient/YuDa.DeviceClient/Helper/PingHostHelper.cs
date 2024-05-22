using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace YuDa.DeviceClient
{
    /// <summary>
    /// ICMP协议
    /// </summary>
    public class PingICMPHostHelper
    {
        const int SOCKET_ERROR = -1;

        public string PingHost(TcpClient tcpClient)
        {

            byte[] sendbuf = Encoding.UTF8.GetBytes("shadiao kai shadiao kai shadiao kai shadiao kai");

            DateTime startTime = DateTime.Now; // Start timing 
            tcpClient.GetStream().Write(sendbuf, 0, sendbuf.Length);

            // Initialize the buffers. The receive buffer is the size of the 
            // ICMP header plus the IP header (20 bytes) 
            Byte[] ReceiveBuffer = new Byte[256];
            int nBytes = 0;
            //Receive the bytes 
            bool recd = false;
            int timeout = 0;
            int dwStop = 0;
            //loop for checking the time of the server responding 
            while (!recd)
            {
                nBytes = tcpClient.GetStream().Read(ReceiveBuffer,0, sendbuf.Length);
                if (nBytes == SOCKET_ERROR)
                {
                    return "主机没有响应";

                }
                else if (nBytes == sendbuf.Length)
                {
                    dwStop = (int)(DateTime.Now - startTime).TotalMilliseconds; // stop timing 
                    return "Reply from " + tcpClient.Client.RemoteEndPoint.ToString() + " in "
                    + dwStop + "ms.  Received: " + nBytes + " Bytes.";

                }
                timeout = (int)(DateTime.Now - startTime).TotalMilliseconds;
                if (timeout > 1000)
                {
                    return "超时";
                }
            }

            //close the socket 
            return "";
        }
       
    }
}
