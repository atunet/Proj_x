require("login_pb")
local login_pb = _G['Protol/login_pb']

module(..., package.seeall)

local function ParseLoginRet()
	local cmd = login_pb.LoginRet()
	cmd:ParseFromString(CSInterface.s_recvBytes)
	print("ip:"..cmd.gatewayip .. ",port:" .. cmd.gatewayport .. ",accid:" .. cmd.accountid .. ",token:" .. cmd.token)
	
	CSInterface.SetServerAddr(cmd.gatewayip, cmd.gatewayport)
	CSInterface.SetServerType(100)	-- 0:loginserver; >0:gatewaserver
	globalToken = cmd.token

	CSInterface.DisconnectToServer()
	CSInterface.LoginToServer()
end