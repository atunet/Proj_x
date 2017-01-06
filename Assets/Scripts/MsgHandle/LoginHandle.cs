using System.IO;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf;

public static class LoginHandle
{
    private static MemoryStream s_sendStream = new MemoryStream();
    private static MemoryStream s_recvStream = new MemoryStream();

    public static bool ParseLoginLoginRet(byte[] msg_, int msgLen_)
    {
        s_recvStream.Position = 0;
        s_recvStream.Write(msg_, 0, msgLen_);
        Cmd.LoginRet ret = Serializer.Deserialize<Cmd.LoginRet>(s_recvStream);

        NetController.Instance.LoginToGateServer(ret.gatewayip, (int)ret.gatewayport, ret.accountid, ret.tempid);
        NetController.Instance.DestroyLoginClient();

        return true;
    }

    public static bool ParseLoginGatewayRet(byte[] msg_, int msgLen_)
    {
        UnityEngine.Debug.Log("Login gateway server return ok!");
        return true;
    }

    public static bool ParseLoginCrossRet(byte[] msg_, int msgLen_)
    {
        return true;
    }
}
