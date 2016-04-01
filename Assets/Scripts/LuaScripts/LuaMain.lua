

require("LuaRoute")
require("Login.LoginSvr")


function LuaMain()
	local cmdFunc = LuaRoute.controllers[CSInterface.s_recvProtoId]
	if nil == cmdFunc then
		print("unknown cmd, function  not found: 0x" .. string.format("%x",CSInterface.s_recvProtoId))
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
	Login.LoginSvr.LoginToServer()
end