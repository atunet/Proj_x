using System;
using LuaInterface;

public sealed class NetBuffer
{
	public static int s_recvProtoId = 0;
	public static LuaByteBuffer s_recvBytes = null;

	public static int s_sendProtoId = 0;
	public static LuaByteBuffer s_sendBytes = null; 

	public static bool SendCmd()
	{
		return NetController.Instance.SendCmd((UInt16)s_sendProtoId, s_sendBytes.buffer);
	}
}
