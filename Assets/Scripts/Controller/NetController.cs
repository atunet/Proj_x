using UnityEngine;

using System;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.IO;


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
    }

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
        
    public void LoginToLoginServer()
    {
        if (m_thread.InitLoginClient("127.0.0.1", 4444))
        {
           /*
            * local verifyCmd = LoginPb.VerifyVersion()
                verifyCmd.clientversion = 796688481
                SendCmd(ProtoTypePb.VERIFY_VERSION_CS, verifyCmd:SerializeToString())

                local loginCmd = LoginPb.LoginReq()
                loginCmd.accountid = 9528
                loginCmd.verifier = "fasdfa"
                SendCmd(ProtoTypePb.LOGIN_LOGIN_CS, loginCmd:SerializeToString())
            */
        }
    }

    public void LoginToGateServer()
    {
        if (m_thread.InitGateClient("127.0.0.1", 4444))
        {
            /*
            local loginCmd = LoginPb.LoginGatewReq()
                loginCmd.accountid = 9528
                loginCmd.verifier = "fasdfa"
                SendMsg(ProtoTypePb.LOGIN_GATE_CS, loginCmd:SerializeToString())
                */


        }
    }

    public void LoginToCrossServer()
    {
        if (m_thread.InitCrossClient("127.0.0.1", 4444))
        {/*
            local loginCmd = LoginPb.LoginCrossReq()
                loginCmd.accountid = 9528
                loginCmd.verifier = "fasdfa"
                SendMsgToCross(ProtoTypePb.LOGIN_LOGIN_CS, loginCmd:SerializeToString())
                */
        }
    }
    /*
    public void Connect()
	{
		if (null != m_thread) 
		{
			Debug.LogWarning("Connect server ignored: netthread already running");
			return;
		}

		TCPClient tcpClient = new TCPClient (m_serverIP, m_serverPort);
		if (!tcpClient.Connect ()) 
		{
            Debug.LogError("connect to server failed (" + m_serverIP + ":" + m_serverPort + ")");
            tcpClient = null;
            return;
        }

		//m_thread = new NetThread (tcpClient);
		//m_thread.Start ();

		CmdHandler.Instance.LoginToServer();

        Debug.Log("NetController connect server ok, netthread started");
	}*/

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
                {
                    Debug.Log("recv tickcmd,just send back");
                    SendMsg((UInt16)CSInterface.s_recvProtoId, realCmd);
                }
                else if (1 == CSInterface.s_recvProtoId)
                {   // recv loginLoginRet msg,do connect to gate ...
                    LoginToGateServer();

                    /*
                    local revCmd = LoginPb.LoginRet()
                        revCmd:ParseFromString(CSInterface.s_recvBytes)
                        print("ip:"..revCmd.gatewayip .. ",port:" .. revCmd.gatewayport .. ",accid:" .. revCmd.accountid .. ",token:" .. revCmd.token)

                        CSInterface.SetServerAddr(revCmd.gatewayip, revCmd.gatewayport)
                        CSInterface.SetServerType(100)  -- 0:loginserver; >0:gatewaserver
                    globalToken = revCmd.token

                        CSInterface.DisconnectToServer()
                        CSInterface.LoginToServer()

                        local loginCmd = LoginPb.LoginGatewayReq()
                        loginCmd.accountid = 9528
                        loginCmd.token = Login.LoginSvr.globalToken
                        loginCmd.appVersion = "1.1.1"
                        loginCmd.deviceId = 8
                        SendCmd(ProtoTypePb.LOGIN_GATEW_CS, loginCmd:SerializeToString())

                        */
                }
                else if (2 == (CSInterface.s_recvProtoId | 0xff00))
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
  
    public void AddCmd(byte[] cmd_)
    {
        Monitor.Enter(m_cmdList);        
        
		m_cmdList.Add(cmd_);       
        
		Monitor.Exit(m_cmdList);
    }

    public bool SendMsg(UInt16 protoId_, byte[] buf_)
    {
        m_thread.TCPClient.SendMsg(protoId_, buf_);
        return true;
    }

    public bool SendMsgToCross(UInt16 protoId_, byte[] buf_)
    {
        m_thread.TCPClient.SendMsg(protoId_, buf_);
        return true;
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
