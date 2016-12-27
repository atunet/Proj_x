require("Protol.prototype_pb")
local ProtoTypePb = Protol.prototype_pb

require("Protol.login_pb")
local LoginPb = Protol.login_pb

module(..., package.seeall)


function ParseLoginRet()
	local revCmd = LoginPb.LoginRet()
	revCmd:ParseFromString(CSInterface.s_recvBytes)
	print("ip:"..revCmd.gatewayip .. ",port:" .. revCmd.gatewayport .. ",accid:" .. revCmd.accountid .. ",token:" .. revCmd.token)
	
	CSInterface.SetServerAddr(revCmd.gatewayip, revCmd.gatewayport)
	CSInterface.SetServerType(100)	-- 0:loginserver; >0:gatewaserver
	globalToken = revCmd.token

	CSInterface.DisconnectToServer()
	CSInterface.LoginToServer()
end


function ParseLoginGateRet()
	local revCmd = LoginPb.LoginGatewayRet()
	revCmd:ParseFromString(CSInterface.s_recvBytes)
	print("login gatewayserver success!")	
end

--[[
function LoginToServer()
	if 0 == CSInterface.GetServerType() then	
		local verifyCmd = LoginPb.VerifyVersion()
		verifyCmd.clientversion = 796688481
		SendCmd(ProtoTypePb.VERIFY_VERSION_CS, verifyCmd:SerializeToString())

		local loginCmd = LoginPb.LoginReq()
		loginCmd.accountid = 9528
		loginCmd.verifier = "fasdfa"
		SendCmd(ProtoTypePb.LOGIN_LOGIN_CS, loginCmd:SerializeToString())
	else
		local loginCmd = LoginPb.LoginGatewayReq()
		loginCmd.accountid = 9528
		loginCmd.token = Login.LoginSvr.globalToken
		loginCmd.appVersion = "1.1.1"
		loginCmd.deviceId = 8
		SendCmd(ProtoTypePb.LOGIN_GATEW_CS, loginCmd:SerializeToString())
	end
end
]]