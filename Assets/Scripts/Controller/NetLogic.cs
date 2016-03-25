using UnityEngine;
using System;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
//using System.Xml.Linq;
using System.IO;

public class NetLogic : MonoBehaviour 
{ 
	internal static TCPClient s_client = null;
	internal static NetThread s_thread = null;
	internal static byte[] s_cacheMsg = null;
	
	private static bool s_inited = false;
	private static ArrayList s_cmdList = new ArrayList();
	
	internal static String s_openId = "123456";
	internal static String s_openKey = "openkey_openkey_";
	internal static String s_token = null;
	internal static UInt32 s_accountId = 0;
	internal static UInt32 s_roleId = 0;
	
	void Start ()
	{		
	}
	

	void LateUpdate()
	{
		Monitor.Enter(s_cmdList);
		
		if(s_cmdList.Count > 0)
		{
			foreach (byte[] cmd in s_cmdList)
			{
				DoCmdParse(cmd);
			}
			
			s_cmdList.Clear();
		}
		
		Monitor.Exit(s_cmdList);
	}
	
	void OnDestroy()
	{
		Reset();
	}
	
	
	void DoCmdParse(byte[] cmd_)
	{
		Debug.Log("Parse cmd:" + cmd_[1] + ",para:" + cmd_[0]);
		/*
		switch(cmd_[1])	
		{
			case Command.CMD_LOGON:
				{
					ParseLogon.Parse(cmd_);
				}
				break;
			
			case Command.CMD_CARD:
				{
					ParseCard.Parse(cmd_);
				}
				break;
			
			case Command.CMD_INSTANCE:
				{
					ParseInstance.Parse(cmd_);
				}
				break;
			
			case Command.CMD_FRIEND:
				{
					ParseFriend.Parse(cmd_);
				}
				break;
			
			case Command.CMD_TASK:
				{
					ParseTask.Parse(cmd_);
				}
				break;
				
			case Command.CMD_SHOP:
				{
					ParseShop.Parse(cmd_);
				}
				break;
			
			case Command.CMD_MAIL:
				{
					ParseMail.Parse(cmd_);
				}
				break;
			
			default:
				{
					Debug.Log("Recv unknown cmd!!!");	
				}
				break;
		}*/
	}

	public static void AddCmd(byte[] cmd_)
	{
		Monitor.Enter(s_cmdList);
		
		s_cmdList.Add(cmd_);
		
		Monitor.Exit(s_cmdList);
	}
	
	public void Reset()
	{
		if(null != s_thread)
		{
			s_thread.Final();
			s_thread = null;
		}
	}
}
