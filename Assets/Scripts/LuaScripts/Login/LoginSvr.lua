require("login_pb")
local LoginPb = _G['Protol/login_pb']

module(..., package.seeall)


function ParseLoginRet()
	local cmd = LoginPb.LoginRet()
	cmd:ParseFromString(CSInterface.s_recvBytes)
	print("ip:"..cmd.gatewayip .. ",port:" .. cmd.gatewayport .. ",accid:" .. cmd.accountid .. ",token:" .. cmd.token)
	
	CSInterface.SetServerAddr(cmd.gatewayip, cmd.gatewayport)
	CSInterface.SetServerType(100)	-- 0:loginserver; >0:gatewaserver
	globalToken = cmd.token

	CSInterface.DisconnectToServer()
	CSInterface.LoginToServer()
end


function ParseLoginGateRet()
	local cmd = LoginPb.LoginGatewayRet()
	cmd:ParseFromString(CSInterface.s_recvBytes)
	print("login gatewayserver success!")	
end


function LoginToServer()
	if 0 == CSInterface.GetServerType() then	
		local verifyCmd = LoginPb.VerifyVersion()
		verifyCmd.clientversion = 1458796688481
		SendCmd(257, verifyCmd:SerializeToString())

		local loginCmd = LoginPb.LoginReq()
		loginCmd.accountid = 8888
		loginCmd.verifier = "fasdfa"
		SendCmd(258, loginCmd:SerializeToString())
	else
		local loginCmd = LoginPb.LoginGatewayReq()
		loginCmd.accountid = 8888
		loginCmd.token = Login.LoginSvr.globalToken
		loginCmd.appVersion = "1.1.1"
		loginCmd.deviceId = 8
		SendCmd(260, loginCmd:SerializeToString())
	end
end