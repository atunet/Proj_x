using UnityEngine;
using System.Collections;
using System.IO;
using ProtoBuf;
using LuaInterface;
using System;

public class CmdMonoBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	/*
	byte[] buffer = new byte[100];
	for(int i = 0; i < buffer.Length; ++i)
	{
		buffer[i] = (byte)(i % 10);
	}*/
	
	Cmd.LoginRet ret = new Cmd.LoginRet();
	ret.accountid = 999999;
	ret.token = 100;
	ret.gatewayip = "192.168.0.3";
	ret.gatewayport = 8888;
	ret.transitip = "192.168.0.2";
	ret.transitport = 7777;
	
	MemoryStream ms = new MemoryStream();
	Serializer.Serialize<Cmd.LoginRet>(ms, ret);
	LuaByteBuffer buffer = new LuaByteBuffer(ms.ToArray());
	
	//CmdHandler.Instance.cmdParse(100, ms.ToArray());
	CmdHandler.Instance.CmdParse(buffer);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Destroy()
	{
	CmdHandler.Instance.Dispose();
	}
}


//public class AnyClass
//{
//	static void Old() {}
//	static void New() {}
//
//	public static void Main()
//	{
//		Old();
//	}
//};
//
//[AttributeUsage(AttributeTargets.Class)]
//public class HelpAttribute : System.Attribute
//{
//	public HelpAttribute(string desc_) 
//	{
//		this.m_desc = desc_;
//	}
//
//	protected string m_desc;
//	public string Desc
//	{
//		get { return m_desc; }
//		set { m_desc = value; }
//	}
//};
//
//[HelpAttribute("help text")]
//public class AnyClass
//{
//	static void doXXX()
//	{
//	}
//};
//
//[Obsolete("old method can not be used", true)]
//public class driveClass : AnyClass
//{
//};
