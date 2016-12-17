using System;
using System.Collections;
using System.Threading;
using System.Text;

using UnityEngine;

internal class NetThread
{
	private TCPClient m_tcpClient = null;
	private Thread m_thread = null;
	private Boolean m_live = false;

	private byte[] m_rcvBuffer;
	private byte[] m_msgBuffer;
	
			
	public NetThread(TCPClient client_)
	{
		m_tcpClient = client_;
		m_thread = new Thread(new ThreadStart(Run));

		m_rcvBuffer = new byte[128*1024];
		m_msgBuffer = new byte[0];
	}
	
    public TCPClient TCPClient { get { return m_tcpClient; } }

	public void Start()
	{
		m_live = true;
		m_thread.Start();
	}
	
	private void Run()
	{
		while(m_live)
		{	
			Thread.Sleep(10);
			
			if(null == m_tcpClient || !m_tcpClient.Connected()) 
			{
				break;
			}
			
			int recvLen = m_tcpClient.Receive(ref m_rcvBuffer);
			if(recvLen < 0)
			{
				Debug.LogError("NetThread recv error: " + recvLen);
				break;
			}

			if(recvLen > 0)
			{
				int msgLen = (null==m_msgBuffer) ? 0 : m_msgBuffer.Length;
				Array.Resize(ref m_msgBuffer, msgLen + recvLen);				
                Array.Copy(m_rcvBuffer, 0, m_msgBuffer, msgLen, recvLen);
			}

			if(m_msgBuffer.Length > TCPClient.HEAD_LEN)
			{				
				int cmdLen = BitConverter.ToInt32(m_msgBuffer, 0);							
				if(m_msgBuffer.Length >= cmdLen + TCPClient.HEAD_LEN)
				{			
					byte[] cmdBytes = new byte[cmdLen];
					Array.Copy(m_msgBuffer, TCPClient.HEAD_LEN, cmdBytes, 0, cmdLen);
						
					NetController.Instance.AddCmd(cmdBytes);
					
                    int packetLen = cmdLen + TCPClient.HEAD_LEN;
                    int lastLen = m_msgBuffer.Length - packetLen;

					Array.Copy(m_msgBuffer, packetLen, m_msgBuffer, 0, lastLen);
					Array.Resize(ref m_msgBuffer, lastLen); 
				}
			}
		}
	}
	
	public void Final()
	{
		if(m_live)
		{
			m_tcpClient.Close();
			m_tcpClient = null;
			m_live = false;
			m_thread.Join();
		}
	}
};
