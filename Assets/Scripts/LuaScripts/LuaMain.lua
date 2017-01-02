

require("LuaRoute")

function LuaMain()
	local handle = LuaRoute.controllers[CSBridge.s_recvProtoId]
	if nil == handle then
		print("unknown msg,handle not found: 0x" .. string.format("%04x",CSBridge.s_recvProtoId))
		return
	end
	handle()
end


function SendMsg(protoId_, bytes_)
	CSBridge.s_sendProtoId = protoId_
	CSBridge.s_sendBytes = bytes_
	CSBridge.SendMsg()
end

function UIRoot()
	return CSBridge.s_uiRoot;
end

function SceneRoot()
	return CSBridge.s_sceneRoot;
end