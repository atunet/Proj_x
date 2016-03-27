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
            }
            
            return s_instance;
        }
    }
	 
	private NetThread m_thread = null;
    private ArrayList m_cmdList = new ArrayList();
    

    public void Connect(string ip_, ushort port_)
	{
		if (null != m_thread) 
		{
			Debug.LogWarning("Connect server ignored: netthread already running");
			return;
		}

		TCPClient tcpClient = new TCPClient (ip_, port_);
		if (!tcpClient.Connect ()) 
		{
            tcpClient = null;
            return;
        }

		m_thread = new NetThread (tcpClient);
		m_thread.Start ();

		CmdHandler.Instance.LoginLoginServer();

        Debug.Log("NetController connect server ok, netthread started");
	}

    void LateUpdate()
    {
        Monitor.Enter(m_cmdList);
        
        if(m_cmdList.Count > 0)
        {
            foreach (byte[] recvCmd in m_cmdList)
			{	
				byte[] realCmd = new byte[recvCmd.Length-TCPClient.PROTO_ID_LEN];
				Array.Copy(recvCmd, TCPClient.PROTO_ID_LEN, realCmd, 0, realCmd.Length);

				NetBuffer.s_recvProtoId = BitConverter.ToUInt16(recvCmd, 0);
				NetBuffer.s_recvBytes =	new LuaInterface.LuaByteBuffer(realCmd);
                CmdHandler.Instance.CmdParse();
            }
            
            m_cmdList.Clear();
        }
        
        Monitor.Exit(m_cmdList);
    }
    
    void OnDestroy()
    {
        Reset();
    }
    
    public void AddCmd(byte[] cmd_)
    {
        Monitor.Enter(m_cmdList);        
        
		m_cmdList.Add(cmd_);       
        
		Monitor.Exit(m_cmdList);
    }

    public bool SendCmd(UInt16 protoId_, byte[] buf_)
    {
        m_thread.TCPClient.Send(protoId_, buf_);
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

	void OnApplicationQuit()
	{
		Reset ();
		CmdHandler.Instance.Dispose ();
	}
}
