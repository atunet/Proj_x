﻿using UnityEngine;

using System;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
//using System.Xml.Linq;
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
        Debug.Log("NetController Connect:[" + ip_ +":" + port_ + "]");

		if (null != m_thread) 
		{
			Debug.Log("NetController Connect error: NetThread is running");
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
            foreach (byte[] cmd in m_cmdList)
            {	
                CmdHandler.Instance.CmdParse(new LuaInterface.LuaByteBuffer(cmd));
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
}
