using System;
using System.Collections;
using System.Threading;
using System.Text;
using System.IO;

internal class NetThread
{
    private TCPClient m_loginClient = null;
    private TCPClient m_gateClient = null;
    private UDPClient m_crossClient = null;

    private byte[] m_loginRcvBuf = null;
    private byte[] m_gateRcvBuf = null;
    private byte[] m_crossRcvBuf = null;

    //private float m_lastGateTime = System.DateTime.Now;
    private TCPClient m_tcpClient = null;
    private Thread m_thread = null;
	private Boolean m_live = false;

    private MemoryStream m_rcvBuf;
    private MemoryStream m_msgBuf;


	private byte[] m_rcvBuffer;
	private byte[] m_msgBuffer;

    public NetThread()
    {
        m_loginRcvBuf = new byte[64*1024];
        m_gateRcvBuf = new byte[64*1024];
        m_crossRcvBuf = new byte[64*1024];

        m_thread = new Thread(new ThreadStart(Run));
    }

//public NetThread(TCPClient client_)
//{
//	m_tcpClient = client_;
//	m_thread = new Thread(new ThreadStart(Run));
//
//	m_rcvBuffer = new byte[128*1024];
//	m_msgBuffer = new byte[0];
//}

    public bool InitLoginClient(string ip_, int port_)
    {
        if (null != m_loginClient)
        {
            Console.WriteLine("tcp login client is not null, init ignored!!!");
            return true;
        }

        m_loginClient = new TCPClient(ip_, port_);
        if (!m_loginClient.Connect())
        {
            Console.WriteLine("tcp login client connect failed [{0}:{1}]", ip_, port_);
            m_loginClient = null;
            return false;
        }

        Console.WriteLine("tcp login client init connect ok [{0}:{1}]", ip_, port_);
        return true;
    }


    public bool InitGateClient(string ip_, int port_)
    {
        if (null != m_gateClient)
        {
            Console.WriteLine("tcp gate client is not null, init ignored!!!");
            return true;
        }

        m_gateClient = new TCPClient(ip_, port_);
        if (!m_gateClient.Connect())
        {
            Console.WriteLine("tcp gate client connect failed [{0}:{1}]", ip_, port_);
            m_gateClient = null;
            return false;
        }

        Console.WriteLine("tcp gate client init connect ok [{0}:{1}]", ip_, port_);
        return true;
    }

    public bool InitCrossClient(string ip_, int port_)
    {
        return true;
    }

    public bool DestroyLoginClient()
    {
        if (null != m_loginClient)
        {
            m_loginClient.Close();
            m_loginClient = null;

            Console.WriteLine("tcp login client destroy ok");
        }
        else
        {
            Console.WriteLine("tcp login client is null,destroy ignored!!!");
        }
    }
    public TCPClient TCPClient { get { return m_tcpClient; } }

	public void Start()
	{
		m_thread.Start();
        m_live = true;
	}
	
	private void Run()
	{
		while(m_live)
		{	
			Thread.Sleep(5);
			
            if (m_loginClient)
            {
                int retCode = m_loginClient.Receive();
                if (retCode >= 0)
                {
                    while (true)
                    {
                        int msgLen = m_loginClient.bufToMsg(m_loginRcvBuf);
                        if(msgLen <= 0) break;
                        NetController.Instance.AddCmd(m_loginRcvBuf, msgLen);
                    }
                }
                else if (retCode < 0)
                {
                }
            }
            if (m_gateClient)
            {
                int retCode = m_gateClient.Receive();
                if (retCode >= 0)
                {
                    while (true)
                    {
                        int msgLen = m_gateClient.bufToMsg(m_gateRcvBuf);
                        if(msgLen <= 0) break;
                        NetController.Instance.AddCmd(m_gateRcvBuf, msgLen);
                    }
                }
                else if (retCode < 0)
                {
                    
                }
            }
            if (m_crossClient)
            {
                int retCode = m_loginClient.Receive();
                if (retCode >= 0)
                {
                    while (true)
                    {
                        int msgLen = m_loginClient.bufToMsg(m_loginRcvBuf);
                        if(msgLen <= 0) break;
                        NetController.Instance.AddCmd(m_loginRcvBuf, msgLen);
                    }
                }
            }

			if(null == m_tcpClient || !m_tcpClient.Connected()) 
			{
				break;
			}
			
			int recvLen = m_tcpClient.Receive(ref m_rcvBuffer);
			if(recvLen < 0)
			{
                Console.WriteLine("NetThread recv error: " + recvLen);
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
