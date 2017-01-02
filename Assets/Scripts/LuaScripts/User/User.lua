require("Protol.prototype_pb")
local ProtoTypePb = Protol.prototype_pb

require("Protol.user_pb")
local UserPb = Protol.user_pb

module(..., package.seeall)

function ParseUserList()
	local revCmd = UserPb.UserList()
	revCmd:ParseFromString(CSBridge.s_recvBytes)

	if 0 == table.getn(revCmd.userbase) then		
		local createCmd = UserPb.CreateUserReq()
		createCmd.usertype = 11103000
		createCmd.username = "atunet3"
		SendMsg(ProtoTypePb.CREATE_USER_CS, createCmd:SerializeToString())
		print("userlist is empty,req create user: " .. createCmd.username)
	else
		local onlineCmd = UserPb.SelectUserOnline()
		onlineCmd.userid = revCmd.userbase[1].userid
		SendMsg(ProtoTypePb.USER_ONLINE_CS, onlineCmd:SerializeToString())
		print("select user online:" .. revCmd.userbase[1].userid .. "," .. revCmd.userbase[1].username)
	end
end

function ParseCreateUserRet()
	local revCmd = UserPb.CreateUserRet()
	revCmd:ParseFromString(CSBridge.s_recvBytes)
	print ("create user success: " .. revCmd.userbase.userid .. "," .. revCmd.userbase.username)

	local onlineCmd = UserPb.SelectUserOnline()
	onlineCmd.userid = revCmd.userbase.userid
	SendMsg(ProtoTypePb.USER_ONLINE_CS, onlineCmd:SerializeToString())
	print("select user online:" .. revCmd.userbase.userid .. revCmd.userbase.username)
end

function ParseUserBaseData()
	local revCmd = UserPb.SendUserBaseData()
	revCmd:ParseFromString(CSBridge.s_recvBytes)
	print("recv user base data")
end

function ParseUserDataLoadOk()
	print("User data load ok")
	
	CSBridge.LoadLevel("MainScene")
  end
 