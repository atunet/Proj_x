using System;
using System.Collections;
using System.Threading;
using System.Text;
using System.IO;

internal class NetThread
{
    private Thread m_thread = null;

    private TCPClient m_loginClient = null;
    private TCPClient m_gateClient = null;
    private UDPClient m_crossClient = null;

    private byte[] m_loginRcvBuf = null;
    private byte[] m_gateRcvBuf = null;
    private byte[] m_crossRcvBuf = null;


    public NetThread()
    {
        m_thread = new Thread(new ThreadStart(Run));

        m_loginRcvBuf = new byte[64*1024];
        m_gateRcvBuf = new byte[64*1024];
        m_crossRcvBuf = new byte[64*1024];
    }
    public void Start() { m_thread.Start(); }


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
        if (null == m_crossClient)
        {
            m_crossClient = new UDPClient(ip_, port_);
        }
        else
        {
            Console.WriteLine("udp cross client is not null, init ignored!!!");
        }

        return true;
    }


    public void DestroyLoginClient()
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

    public bool SendMsgToLogin(UInt16 msgId_, byte[] msg_)
    {
        return (null != m_loginClient) ? m_loginClient.SendMsg(msgId_, msg_) : false;
    }

    public bool SendMsgToGate(UInt16 msgId_, byte[] msg_)
    {
        return (null != m_gateClient) ? m_gateClient.SendMsg(msgId_, msg_) : false;
    }

    public bool SendMsgToCross(UInt16 msgId_, byte[] msg_)
    {
        return (null != m_crossClient) ? m_crossClient.SendMsg(msgId_, msg_) : false;
    }
	
	private void Run()
	{
        while(m_thread.IsAlive)
		{	
			Thread.Sleep(5);
			
            if (null != m_loginClient)
            {
                int retCode = m_loginClient.Receive();
                if (retCode >= 0)
                {
                    while (true)
                    {
                        int msgLen = m_loginClient.bufToMsg(ref m_loginRcvBuf);
                        if(msgLen <= 0) break;                        
                        NetController.Instance.AddCmd(m_loginRcvBuf, msgLen);
                    }
                }
                else if (retCode < 0)
                {
                }
            }
            if (null != m_gateClient)
            {
                int retCode = m_gateClient.Receive();
                if (retCode >= 0)
                {
                    while (true)
                    {
                        int msgLen = m_gateClient.bufToMsg(ref m_gateRcvBuf);
                        if(msgLen <= 0) break;
                        NetController.Instance.AddCmd(m_gateRcvBuf, msgLen);
                    }
                }
                else if (retCode < 0)
                {
                    
                }
            }
            if (null != m_crossClient)
            {
                int retCode = m_loginClient.Receive();
                if (retCode >= 0)
                {
                    while (true)
                    {
                        int msgLen = m_loginClient.bufToMsg(ref m_crossRcvBuf);
                        if(msgLen <= 0) break;
                        NetController.Instance.AddCmd(m_loginRcvBuf, msgLen);
                    }
                }
            }
		}
	}
	

	public void Final()
	{
        if(null != m_thread && m_thread.IsAlive)
		{
            if (null != m_loginClient)
            {
                m_loginClient.Close();
                m_loginClient = null;
            }
            if (null != m_gateClient)
            {
                m_gateClient.Close();
                m_gateClient = null;
            }
            if (null != m_crossClient)
            {
                m_crossClient.Close();
                m_crossClient = null;
            }
			m_thread.Join();
            m_thread = null;
		}
	}
};
