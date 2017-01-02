

require("LuaRoute")

function LuaMain()
	local handle = LuaRoute.controllers[CSInterface.s_recvProtoId]
	if nil == handle then
		print("unknown msg,handle not found: 0x" .. string.format("%04x",CSInterface.s_recvProtoId))
		return
	end
	handle()
end


function SendMsg(protoId_, bytes_)
	CSInterface.s_sendProtoId = protoId_
	CSInterface.s_sendBytes = bytes_
	CSInterface.SendMsg()
end

function UIRoot()
	return CSInterface.s_uiRoot;
end

function SceneRoot()
	return CSInterface.s_sceneRoot;
end