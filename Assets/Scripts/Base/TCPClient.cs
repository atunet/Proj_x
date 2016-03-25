using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TCPClient
{
	private String m_serverIP = null;
	private int m_serverPort = 0;
	private Socket m_socket = null;
	private static UInt32 s_seqNO = 1;

	public TCPClient (String ip_, int port_)
	{	
		m_serverIP = ip_;
		m_serverPort = port_;
		m_socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	}
	
	public Boolean Connect ()
	{
		if(m_socket.Connected)
		{	
            Debug.LogWarning("the socket is already connected");
			return true;
		}
		
        Debug.Log("TCPClient connect server:[" + m_serverIP + ":" + m_serverPort + "]");


		IPEndPoint serverAddr = new IPEndPoint(IPAddress.Parse(m_serverIP), m_serverPort);
		try
		{
			m_socket.Connect (serverAddr);
		}
		catch(SocketException e_)
		{
			Debug.Log(e_.ToString());
			return false;
		}
		
		return true;
	}

	public void Close ()
	{
        m_socket.Shutdown(SocketShutdown.Both);
		m_socket.Disconnect(true);
		Debug.Log("TCPClient closed!");
	}
	
	public Boolean Send (UInt16 protoId_, byte[] msg_)
	{	
		UInt32 packetLen = (UInt32)(PROTO_ID_LEN + SEQ_LEN + msg_.Length);
        byte[] sendBytes = new byte[HEAD_LEN + packetLen];

        BitConverter.GetBytes(packetLen).CopyTo(sendBytes, 0);
		BitConverter.GetBytes(protoId_).CopyTo(sendBytes, HEAD_LEN);
		BitConverter.GetBytes(s_seqNO++).CopyTo(sendBytes, HEAD_LEN+PROTO_ID_LEN);
		msg_.CopyTo(sendBytes, HEAD_LEN+PROTO_ID_LEN+SEQ_LEN);		
		
        int offset = 0;
		while(offset < sendBytes.Length)
		{
			offset += m_socket.Send(sendBytes, offset, sendBytes.Length-offset, SocketFlags.None);
		}

		Debug.Log("TCPClient Send msg:" + protoId_ + ",len:" + msg_.Length + ",cmd len:" + packetLen);
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
	
	internal static Byte HEAD_LEN = 4;
	internal static Byte PROTO_ID_LEN = 2;
	internal static Byte SEQ_LEN = 4;
}
