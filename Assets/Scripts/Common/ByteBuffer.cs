using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ByteBuffer
{
	private byte[] m_bytes = null;
	
	internal byte[] ToBytes()
	{
		return m_bytes;
	}
	
	
	// 登录类指令定义

	internal void FormatCmd_ReqLogon(string openId_, string openKey_)
	{
		/*
		UInt16 idLen = (UInt16)openId_.Length;
		UInt16 keyLen = (UInt16)openKey_.Length;
		int totalLen = TypeDefine.LEN_UINT32 + TypeDefine.LEN_UINT16 + idLen + TypeDefine.LEN_UINT16 + keyLen;
		
		m_bytes = new byte[totalLen];
		
		int offset = 0;
		Array.Copy(BitConverter.GetBytes(Command.CLIENT2DIR_LOGIN_REQ), 0, m_bytes, offset, TypeDefine.LEN_UINT32);
		offset += TypeDefine.LEN_UINT32;
		
		Array.Copy(BitConverter.GetBytes(idLen), 0, m_bytes, offset, TypeDefine.LEN_UINT16);
		offset += TypeDefine.LEN_UINT16;
		
		Array.Copy(Encoding.UTF8.GetBytes(openId_), 0, m_bytes, offset, idLen);
		offset += idLen;
		
		Array.Copy(BitConverter.GetBytes(keyLen), 0, m_bytes, offset, TypeDefine.LEN_UINT16);
		offset += TypeDefine.LEN_UINT16;
		
		Array.Copy(Encoding.UTF8.GetBytes(openKey_), 0, m_bytes, offset, keyLen);
		offset += keyLen;
		*/
	}
	
	
	internal void FormatCmd_ReqLogonGW()
	{
		/*
		UInt16 tokenLen = (UInt16)NetLogic.s_token.Length;
		
		m_bytes = new byte[TypeDefine.LEN_UINT32 + TypeDefine.LEN_UINT16 + tokenLen];
		
		int offset = 0;
		Array.Copy(BitConverter.GetBytes(Command.CLIENT2LOBBY_LOGIN_TOKEN_REQ), 0, m_bytes, offset, TypeDefine.LEN_UINT32);
		offset += TypeDefine.LEN_UINT32;
		
		Array.Copy(BitConverter.GetBytes(tokenLen), 0, m_bytes, offset, TypeDefine.LEN_UINT16);
		offset += TypeDefine.LEN_UINT16;
		
		Array.Copy(Encoding.UTF8.GetBytes(NetLogic.s_token), 0, m_bytes, offset, tokenLen);
		*/
	}
	
	internal void FormatCmd_ReqCreateRole( byte roleType_, UInt16 petId_, string roleName_)
	{
		/*
		UInt16 nameLen =(UInt16)(Encoding.UTF8.GetBytes(roleName_).Length);
		
		m_bytes = new byte[9+nameLen];
		
		int offset = 0;
		Array.Copy(BitConverter.GetBytes(Command.CLIENT2LOBBY_CREATE_CHAR_REQ), 0, m_bytes, offset, TypeDefine.LEN_UINT32);
		offset += TypeDefine.LEN_UINT32;
		
		Array.Copy(BitConverter.GetBytes(petId_), 0, m_bytes, offset, TypeDefine.LEN_UINT16);
		offset += TypeDefine.LEN_UINT16;
		
		Array.Copy(BitConverter.GetBytes(nameLen), 0, m_bytes, offset, TypeDefine.LEN_UINT16);
		offset += TypeDefine.LEN_UINT16;
		
		Array.Copy(Encoding.UTF8.GetBytes(roleName_), 0, m_bytes, offset, nameLen);
		offset += nameLen;
		
		Array.Copy(BitConverter.GetBytes(roleType_), 0, m_bytes, offset, TypeDefine.LEN_BYTE);
		*/
	}
}
