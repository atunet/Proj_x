using UnityEngine;
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
	
    public void SetAddr(string ip_, int port_)
    {
        m_serverIP = ip_;
        m_serverPort = port_;
    }

	public Boolean Connect ()
	{
        if (null != m_socket)
        {
            m_socket.Shutdown(SocketShutdown.Both);
            m_socket.Disconnect(true);
            m_socket.Close();
            m_socket = null;
            Debug.LogWarning("Socket already init,shutdown && close before reconnect!!");
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
            Debug.LogError("TCPClient Connect exception:" + e_.ToString());
            m_socket = null;
			return false;
		}

		Debug.Log("TCPClient connect server ok [" + m_serverIP + ":" + m_serverPort + "]");
		return true;
	}

	public void Close ()
	{
		if (m_socket.Connected) 
		{
			m_socket.Shutdown (SocketShutdown.Both);
			m_socket.Disconnect (true);
		}
		Debug.Log("TCPClient closed!");
	}
	
	public Boolean Send (UInt16 msgId_, byte[] msg_)
	{	
        UInt32 packetLen = (UInt32)(MSG_ID_LEN + SEQUENCE_LEN + msg_.Length);
        byte[] sendBytes = new byte[HEAD_LEN + packetLen];

        BitConverter.GetBytes(packetLen).CopyTo(sendBytes, 0);
        BitConverter.GetBytes(msgId_).CopyTo(sendBytes, HEAD_LEN);
        BitConverter.GetBytes(++s_seqNO).CopyTo(sendBytes, HEAD_LEN+MSG_ID_LEN);
        msg_.CopyTo(sendBytes, HEAD_LEN+MSG_ID_LEN+SEQUENCE_LEN);		
		
        int offset = 0;
		while(offset < sendBytes.Length)
		{
			offset += m_socket.Send(sendBytes, offset, sendBytes.Length-offset, SocketFlags.None);
		}

        Debug.Log("TCPClient send msgid:" + msgId_.ToString("X") + ",msg len:" +  msg_.Length + ",total len:" + packetLen);
        return true;
	}

	public int Receive (ref byte[] recvBuf_)
	{		
		int code = 0;
		if(m_socket.Poll(0, SelectMode.SelectError))
		{
			Debug.Log("poll get error, may be disconnected!");
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
				//Debug.Log(e_.ToString());
			}
		}
		
		return code;
	}
	
	public bool Connected ()
	{
		return m_socket.Connected;
	}

}
