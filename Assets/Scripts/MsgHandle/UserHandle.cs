using System.IO;
using ProtoBuf;

public static class UserHandle
{
    private static MemoryStream s_sendStream = new MemoryStream();
    private static MemoryStream s_recvStream = new MemoryStream();

    public static bool ParseUserList(byte[] msg_, int msgLen_)
    {
        s_recvStream.Position = 0;
        s_recvStream.Write(msg_, 0, msgLen_);
        Cmd.UserList ret = Serializer.Deserialize<Cmd.UserList>(s_recvStream);

        if (0 == ret.userbase.Count)
        {
            Cmd.CreateUserReq req = new Cmd.CreateUserReq();
            req.username = "abc";
            req.usertype = 1;
            Serializer.Serialize<Cmd.CreateUserReq>(s_sendStream, req);
            NetController.Instance.SendMsgToGate(req.id, s_sendStream.ToArray());
        }
        else
        {
            Cmd.SelectUserOnline req = new Cmd.SelectUserOnline();
            req.userid = ret.userbase[0].userid;
            Serializer.Serialize<Cmd.SelectUserOnline>(s_sendStream, req);
            NetController.Instance.SendMsgToGate(req.id, s_sendStream.ToArray());
        }

        return true;
    }

    public static bool ParseCreateUserRet(byte[] msg_, int msgLen_)
    {
        s_recvStream.Position = 0;
        s_recvStream.Write(msg_, 0, msgLen_);
        Cmd.CreateUserRet ret = Serializer.Deserialize<Cmd.CreateUserRet>(s_recvStream);

        Cmd.SelectUserOnline req = new Cmd.SelectUserOnline();
        req.userid = ret.userbase.userid;
        Serializer.Serialize<Cmd.SelectUserOnline>(s_sendStream, req);
        NetController.Instance.SendMsgToGate(req.id, s_sendStream.ToArray());

        return true;
    }

    public static bool ParseUserBaseData(byte[] msg_, int msgLen_)
    {
        s_recvStream.Position = 0;
        s_recvStream.Write(msg_, 0, msgLen_);
        Cmd.SendUserBaseData ret = Serializer.Deserialize<Cmd.SendUserBaseData>(s_recvStream);

        return true;
    }

    public static bool ParseUserItemList(byte[] msg_, int msgLen_)
    {
        return true;
    }
}
