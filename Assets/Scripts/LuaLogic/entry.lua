

require ("login_pb")
local login_pb = _G['Protol/login_pb']


function ParseLoginRet()

	local cmd = login_pb.LoginRet()
	cmd:ParseFromString(NetBuffer.s_recvBytes)
	print("ip:"..cmd.gatewayip .. ",port:" .. cmd.gatewayport .. ",accid:" .. cmd.accountid .. ",token:" .. cmd.token)
	
	NetBuffer.s_gateIp = cmd.gatewayip
	NetBuffer.s_gatePort = cmd.gatewayport
	NetBuffer.s_token = cmd.token

	NetBuffer.DisconnectLoginServer()
	NetBuffer.LoginGatewayServer()
end

local  controllers = 
{
	[259] = ParseLoginRet,
}

function CmdParse()

	local cmdFunc = controllers[NetBuffer.s_recvProtoId]
	if nil == cmdFunc 
	then
		print("unknown cmd, function  not found:" .. NetBuffer.s_recvProtoId)
		return
	end

	cmdFunc()
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