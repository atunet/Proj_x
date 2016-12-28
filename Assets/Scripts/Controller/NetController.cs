using UnityEngine;

using System;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;

public class NetController : MonoBehaviour 
{ 
    private static NetController s_instance = null;
    public static NetController Instance
    {
        get
        {
            if (s_instance == null)
            {
                GameObject obj = new GameObject("NetController");
                s_instance = obj.AddComponent<NetController>(); 
                GameObject.DontDestroyOnLoad(obj);
            }
            
            return s_instance;
        }
    }

    private NetController()
    {
    	m_serverType = 0;

        m_loginIP = "";
        m_loginPort = 0;
        m_gateIP = "";
        m_gatePort = 0;
        m_crossIP = "";
        m_crossPort = 0;
    }

    private string m_loginIP;
    private int m_loginPort;

    private string m_gateIP;
    private int m_gatePort;

    private string m_crossIP;
    private int m_crossPort;

    private string m_serverIP;
    public string ServerIP
    {
    	get { return m_serverIP; }
    	set { m_serverIP = value; }
    }
    private ushort m_serverPort;
    public ushort ServerPort
    {
    	get { return m_serverPort; }
    	set { m_serverPort = value; }
    }
    private byte m_serverType;
    public byte ServerType
    {
    	get { return m_serverType; }
    	set { m_serverType = value; }
    }

	private NetThread m_thread = null;
    private ArrayList m_cmdList = new ArrayList();
    private MemoryStream m_pbStream = new MemoryStream();

    public bool Init()
    {
        if (null != m_thread)
        {
            Debug.LogWarning("NetController already inited,repeated init ignored!!!");
            return false;
        }

        m_thread = new NetThread();
        m_thread.Start();

        Debug.Log("NetController init ok,netthread start working!!!");
        return true;
    }
        
    public void LoginToLoginServer(string ip_, int port_)
    {
        if (m_thread.InitLoginClient(ip_, port_))
        {
            Cmd.VerifyVersion verify = new Cmd.VerifyVersion();
            verify.clientversion = 2017;
            Serializer.Serialize<Cmd.VerifyVersion>(m_pbStream, verify);
            SendMsgToLogin(verify.id, m_pbStream.ToArray());

            Cmd.LoginReq login = new Cmd.LoginReq();
            login.accountid = 9529;
            login.verifier = "this is verifier code";
            Serializer.Serialize<Cmd.LoginReq>(m_pbStream, login);
            SendMsgToLogin(login.id, m_pbStream.ToArray());
        }
    }

    public void LoginToGateServer(string ip_, int port_)
    {
        if (m_thread.InitGateClient(ip_, port_))
        {
            Cmd.LoginGatewayReq login = new Cmd.LoginGatewayReq();
            login.accountid = 9529;
            login.tempid = 7777;
            Serializer.Serialize<Cmd.LoginGatewayReq>(m_pbStream, login);
            SendMsgToGate(login.id, m_pbStream.ToArray());          
        }
    }

    public void LoginToCrossServer(string ip_, int port_)
    {
        if (m_thread.InitCrossClient(ip_, port_))
        {
            Cmd.LoginCrossReq login = new Cmd.LoginCrossReq();
            login.userid = 868686868686;
            login.tempid = 6666;
            Serializer.Serialize<Cmd.LoginCrossReq>(m_pbStream, login);
            SendMsgToCross(login.id, m_pbStream.ToArray());
        }
    }

    void LateUpdate()
    {
        Monitor.Enter(m_cmdList);
        
        if(m_cmdList.Count > 0)
        {
            foreach (byte[] recvCmd in m_cmdList)
			{	
				CSInterface.s_recvProtoId = BitConverter.ToUInt16(recvCmd, 0);
				byte[] realCmd = new byte[recvCmd.Length-TCPClient.MSG_ID_LEN];
				Array.Copy(recvCmd, TCPClient.MSG_ID_LEN, realCmd, 0, realCmd.Length);

                if (0 == CSInterface.s_recvProtoId)
                {   // TODO ... send to which server ???
                    Debug.Log("recv tickcmd,just send back");
                    SendMsgToGate((Cmd.EMessageID)CSInterface.s_recvProtoId, realCmd);
                }
                else if (Cmd.EMessageID.LOGIN_LOGIN_SC == (Cmd.EMessageID)CSInterface.s_recvProtoId)
                {  
                    MemoryStream ms = new MemoryStream(realCmd, 0, realCmd.Length);
                    Cmd.LoginRet ret = Serializer.Deserialize<Cmd.LoginRet>(ms);

                    if (m_thread.InitGateClient(ret.gatewayip, (int)ret.gatewayport))
                    {
                        Cmd.LoginGatewayReq login = new Cmd.LoginGatewayReq();
                        login.accountid = 9529;
                        login.tempid = 7777;
                        login.appVersion = "1.1.1";
                        login.deviceId = 100;

                        Serializer.Serialize<Cmd.LoginGatewayReq>(m_pbStream, login);
                        SendMsgToGate(login.id, m_pbStream.ToArray());          
                    }
                    m_thread.DestroyLoginClient();
                }
                else if (Cmd.EMessageID.PVP_CMD == (Cmd.EMessageID)(CSInterface.s_recvProtoId | 0xff00))
                {
                    // recv battle msg, do fighting logic in c#
                }
                else
				{		// default do other logic in lua 			
					CSInterface.s_recvBytes = new LuaInterface.LuaByteBuffer(realCmd);
    	            CmdHandler.Instance.CmdParse();
            	}
            }
            
            m_cmdList.Clear();
        }
        
        Monitor.Exit(m_cmdList);
    }   
  
    public void AddCmd(byte[] cmd_, int len_)
    {
        Monitor.Enter(m_cmdList);  

        byte[] msgBytes = new byte[len_];
        Array.Copy(cmd_, msgBytes, len_);
        m_cmdList.Add(msgBytes);       
        
		Monitor.Exit(m_cmdList);
    }

    public bool SendMsgToLogin(Cmd.EMessageID protoId_, byte[] buf_)
    {
        return m_thread.SendMsgToLogin((UInt16)protoId_, buf_);
    }

    public bool SendMsgToGate(Cmd.EMessageID protoId_, byte[] buf_)
    {
        return m_thread.SendMsgToGate((UInt16)protoId_, buf_);
    }

    public bool SendMsgToCross(Cmd.EMessageID protoId_, byte[] buf_)
    {
        return m_thread.SendMsgToCross((UInt16)protoId_, buf_);
    }

    public void Reset()
    {
        if(null != m_thread)
        {
            m_thread.Final();
            m_thread = null;
        }
    }

	void OnDestroy()
    {
        Reset();
    }

	void OnApplicationQuit()
	{
		Reset ();
		CmdHandler.Instance.Dispose ();
	}
}
