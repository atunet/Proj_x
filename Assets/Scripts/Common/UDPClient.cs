using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;

public class UDPClient
{
    private static Byte HEAD_LEN = 4;
    private static Byte MSG_ID_LEN = 2;
    private static Byte SEQUENCE_LEN = 4;
    private static int RCV_BUF_LEN = 256 * 1024;

    private String m_serverIP = null;
    private int m_serverPort = 0;
    private IPEndPoint m_serverAddr = null;
    private Socket m_socket = null;
    private UInt32 m_seqNO = 0;

    private byte[] m_rcvBuf = null;
    private int m_bufReadOffset = 0;
    private int m_bufWriteOffset = 0;


    public UDPClient (string ip_, int port_)
    {   
        m_serverIP = ip_;
        m_serverPort = port_;

        m_serverAddr = new IPEndPoint(IPAddress.Parse(m_serverIP), m_serverPort);
        m_socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp); 

        m_rcvBuf = new byte[RCV_BUF_LEN];

    }

    public Boolean SendMsg (UInt16 msgId_, byte[] msg_)
    {  
        UInt32 packetLen = (UInt32)(MSG_ID_LEN + SEQUENCE_LEN + msg_.Length);
        byte[] sendBytes = new byte[HEAD_LEN + packetLen];

        BitConverter.GetBytes(packetLen).CopyTo(sendBytes, 0);
        BitConverter.GetBytes(msgId_).CopyTo(sendBytes, HEAD_LEN);
        BitConverter.GetBytes(++m_seqNO).CopyTo(sendBytes, HEAD_LEN + MSG_ID_LEN);
        msg_.CopyTo(sendBytes, HEAD_LEN + MSG_ID_LEN + SEQUENCE_LEN);       

        int offset = 0;
        while (offset < sendBytes.Length)
        {
            offset += m_socket.SendTo(sendBytes, offset, sendBytes.Length - offset, SocketFlags.None, m_serverAddr);
        }

        Console.WriteLine("UDPClient send msgid:{0} ok,msg len:{1},total len:{2}", msgId_.ToString("X"), msg_.Length, packetLen);
        return true;
    }

    public int Receive()
    {
        int code = 0;
        if(m_socket.Poll(0, SelectMode.SelectError))
        {
            Console.WriteLine("socket poll get error, may be disconnected!");
            code = -1;
        }
        else if(m_socket.Poll(10*1000, SelectMode.SelectRead))
        {
            code = m_socket.Receive(m_rcvBuf, m_bufWriteOffset, RCV_BUF_LEN-m_bufWriteOffset, SocketFlags.None);
            if (code > 0)
            {

            }
        }

        return code;

    }

    public void Close()
    {
    }
}
