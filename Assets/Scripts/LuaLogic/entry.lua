

require ("basetype_pb")
local basetype_pb = _G['Protol/basetype_pb']
require ("login_pb")
local login_pb = _G['Protol/login_pb']
require ("role_pb")
local  role_pb = _G['Protol/role_pb']

require ("login.login")

function ParseLoginRet()
	local cmd = login_pb.LoginRet()
	cmd:ParseFromString(CSInterface.s_recvBytes)
	print("ip:"..cmd.gatewayip .. ",port:" .. cmd.gatewayport .. ",accid:" .. cmd.accountid .. ",token:" .. cmd.token)
	
	CSInterface.SetServerAddr(cmd.gatewayip, cmd.gatewayport)
	CSInterface.SetServerType(100)	-- 0:loginserver; >0:gatewaserver
	globalToken = cmd.token

	CSInterface.DisconnectToServer()
	CSInterface.LoginToServer()
end


function ParseLoginGateRet()
	local cmd = login_pb.LoginGatewayRet()
	cmd:ParseFromString(CSInterface.s_recvBytes)
	print("login gatewayserver success!")	
end

function ParseRoleList()
	local cmd = role_pb.RoleList()
	cmd:ParseFromString(CSInterface.s_recvBytes)
	print("recv role list success, role count:" .. table.getn(cmd.rolebase))
	--print("recv role list success")
end

local controllers = 
{
	[basetype_pb.LOGIN_LOGIN_RET] 	= login.login.ParseLoginRet,
	[basetype_pb.LOGIN_GATEW_RET] 	= ParseLoginGateRet,
	[basetype_pb.SEND_ROLE_LIST] 	= ParseRoleList,
}


function CmdParse()
	--print(package.path)
	print(package.loaded["Protol/login_pb"])
	local cmdFunc = controllers[CSInterface.s_recvProtoId]
	if nil == cmdFunc 
	then
		print("unknown cmd, function  not found:" .. string.format("%x",CSInterface.s_recvProtoId))
		return
	end

	cmdFunc()
end


function SendCmd(protoId_, bytes_)
	CSInterface.s_sendProtoId = protoId_
	CSInterface.s_sendBytes = bytes_
	CSInterface.SendCmd()
end


function LoginToServer()
	if 0 == CSInterface.GetServerType()
	then	
		local verifyCmd = login_pb.VerifyVersion()
		verifyCmd.clientversion = 1458796688481
		SendCmd(257, verifyCmd:SerializeToString())

		local loginCmd = login_pb.LoginReq()
		loginCmd.accountid = 8888
		loginCmd.verifier = "fasdfa"
		SendCmd(258, loginCmd:SerializeToString())
	else
		local loginCmd = login_pb.LoginGatewayReq()
		loginCmd.accountid = 8888
		loginCmd.token = globalToken
		loginCmd.appVersion = "1.1.1"
		loginCmd.deviceId = 8
		SendCmd(260, loginCmd:SerializeToString())
	end
end