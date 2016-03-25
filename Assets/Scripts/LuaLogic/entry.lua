
--local protobuf = require ("protobuf")

--local protobuf = require("protobuf")
require ("login_pb")
--login_pb = require "Protol/login_pb"
local login_pb = _G['Protol/login_pb']
NetBuffer = require "NetBuffer"

function CmdParse(body_)
	print ("protoId_" .. protoId_)
	--print ("body_" .. body_)

	local cmd = login_pb.LoginRet()
	cmd:ParseFromString(body_)
	print("ip:"..cmd.gatewayip .. ",port:" .. cmd.gatewayport .. ",accid:" .. cmd.accountid .. ",token:" .. cmd.token)

	--local path = "/Users/aTunet/Desktop/repoGit/proj_x/Assets/Scripts/LuaLogic/protos/login.pb"
	-- local path = "D:/repoGit/proj_x_client/Assets/Scripts/LuaLogic/protos/login.pb"

	-- local pbBin = io.open(path, "rb")
	-- local buffer = pbBin:read "*a"
	-- pbBin:close()

	-- protobuf.register(buffer)
	-- print ("register ok")
	-- local cmd = protobuf.decode("LoginRet", body_)

	-- print("ip:"..cmd.gatewayip .. ",port:" .. cmd.gatewayport .. ",accid:" .. cmd.accid .. ",token:" .. cmd.token)


end


function SendCmd(protoId_, bytes_)
	NetBuffer.s_protoId = protoId_
	NetBuffer.s_bytes = bytes_
	NetBuffer:SendCmd()
end


function LoginLoginServer()

	print(tostring(VERIFY_VERSION))
	
	local verifyCmd = login_pb.VerifyVersion()
	verifyCmd.clientversion = 2016
	SendCmd(257, verifyCmd:SerializeToString())

	local loginCmd = login_pb.LoginReq()
	loginCmd.accountid = 8888
	loginCmd.verifier = "fasdfa"
	SendCmd(258, loginCmd:SerializeToString())
end