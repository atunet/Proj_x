using System;
using LuaInterface;

public sealed class NetBuffer
{
	public static int s_protoId = 0;
	public static LuaByteBuffer s_bytes = null; 

	public static bool SendCmd()
	{
		return NetController.Instance.SendCmd((UInt16)s_protoId, s_bytes.buffer);
	}
}
