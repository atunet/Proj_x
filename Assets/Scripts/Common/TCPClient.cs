using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TCPClient
{
    internal static Byte HEAD_LEN = 4;
    internal static Byte MSG_ID_LEN = 2;
    internal static Byte SEQUENCE_LEN = 4;


    private String m_serverIP = null;
    private int m_serverPort = 0;
    private Socket m_socket = null;
    private UInt32 s_seqNO = 0;


    public TCPClient (String ip_, int port_)
    {	
        m_serverIP = ip_;
        m_serverPort = port_;
    }


	public Boolean Connect ()
	{
        if(null != m_socket)
        {
            Console.WriteLine("Socket is not null,connect ignored!!!");
            return true;
        }

        IPEndPoint serverAddr = new IPEndPoint(IPAddress.Parse(m_serverIP), m_serverPort);
        m_socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);	
        //m_socket.SendTimeout = 1000;               
		try
		{
			m_socket.Connect (serverAddr);
		}
		catch(SocketException e_)
		{
            Console.WriteLine("TCPClient Connect exception:{0}", e_.ToString());
            m_socket = null;
			return false;
		}

        Console.WriteLine("TCPClient connect server ok [{0}:{1}]", m_serverIP, m_serverPort);
		return true;
	}


	public void Close ()
	{
		if (m_socket.Connected) 
		{
			m_socket.Shutdown (SocketShutdown.Both);
			m_socket.Disconnect (true);
		}
        Console.WriteLine("TCPClient closed!");
	}
	

	public Boolean SendMsg (UInt16 msgId_, byte[] msg_)
	{	
        
        if (m_socket.Connected && 
           !m_socket.Poll(10 * 1000, SelectMode.SelectError))
        {
            UInt32 packetLen = (UInt32)(MSG_ID_LEN + SEQUENCE_LEN + msg_.Length);
            byte[] sendBytes = new byte[HEAD_LEN + packetLen];

            BitConverter.GetBytes(packetLen).CopyTo(sendBytes, 0);
            BitConverter.GetBytes(msgId_).CopyTo(sendBytes, HEAD_LEN);
            BitConverter.GetBytes(++s_seqNO).CopyTo(sendBytes, HEAD_LEN + MSG_ID_LEN);
            msg_.CopyTo(sendBytes, HEAD_LEN + MSG_ID_LEN + SEQUENCE_LEN);		
    		
            int offset = 0;
            while (offset < sendBytes.Length)
            {
                offset += m_socket.Send(sendBytes, offset, sendBytes.Length - offset, SocketFlags.None);
            }

            Console.WriteLine("TCPClient send msgid:{0} ok,msg len:{1},total len:{2}", msgId_.ToString("X"), msg_.Length, packetLen);
            return true;
        }
        else
        {
            Console.WriteLine("TCPClient send msg failed,socket is disconnected,msgid:{0},len:{1}", msgId_.ToString("X"), msg_.Length);
            return false;
        }
	}

	public int Receive (ref byte[] recvBuf_)
	{		
		int code = 0;
		if(m_socket.Poll(0, SelectMode.SelectError))
		{
            Console.WriteLine("socket poll get error, may be disconnected!");
			code = -1;
		}
		else if(m_socket.Poll(100*1000, SelectMode.SelectRead))
		{
			try
			{
				code = m_socket.Receive(recvBuf_);
			}
			catch(Exception e_)
			{
                Console.WriteLine(e_.ToString());
            }
		}
		
		return code;
	}
	
    public int bufToMsg(ref byte[] msgBuf_)
    {

        return 0;
    }

	public bool Connected ()
	{
		return m_socket.Connected;
	}

}
