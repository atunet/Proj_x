

require ("login_pb")
local login_pb = _G['Protol/login_pb']

local  controllers = 
{

}

function CmdParse()

	local cmdFunc = controllers[NetBuffer.s_recvProtoId]
	if null == cmdFunc then
		print("unknown cmd, function  not found")
		return
	end

	cmdFunc()
	
	--ocal cmd = login_pb.LoginRet()
	--cmd:ParseFromString(NetBuffer.s_recvBytes)
	--print("ip:"..cmd.gatewayip .. ",port:" .. cmd.gatewayport .. ",accid:" .. cmd.accountid .. ",token:" .. cmd.token)
end


function SendCmd(protoId_, bytes_)
	NetBuffer.s_sendProtoId = protoId_
	NetBuffer.s_sendBytes = bytes_
	NetBuffer.SendCmd()
end


function LoginLoginServer()	
	local verifyCmd = login_pb.VerifyVersion()
	verifyCmd.clientversion = 2016
	SendCmd(257, verifyCmd:SerializeToString())

	local loginCmd = login_pb.LoginReq()
	loginCmd.accountid = 8888
	loginCmd.verifier = "fasdfa"
	SendCmd(258, loginCmd:SerializeToString())
end