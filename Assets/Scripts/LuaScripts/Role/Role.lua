require("Protol.prototype_pb")
local ProtoTypePb = Protol.prototype_pb

require("Protol.role_pb")
local RolePb = Protol.role_pb

module(..., package.seeall)

function ParseRoleList()
	print("recv byte length:" .. string.len(CSInterface.s_recvBytes))
	local revCmd = RolePb.RoleList()
	revCmd:ParseFromString(CSInterface.s_recvBytes)

	if 0 == table.getn(revCmd.rolebase) then		
		local createCmd = RolePb.CreateRoleReq()
		createCmd.roletype = 11103000
		createCmd.rolename = "atunet2"
		--createCmd.avatar:append(1)
		--createCmd.avatar:append(1)
		--createCmd.avatar:append(1)
		--createCmd.avatar:append(1)
		SendCmd(BaseTypePb.CREATE_USER_CS, createCmd:SerializeToString())
		print("role size is 0, req create role: " .. createCmd.rolename)
	else
		local onlineCmd = RolePb.SelectRoleOnline()
		onlineCmd.roleid = revCmd.rolebase[1].roleid
		SendCmd(BaseTypePb.USER_ONLINE_CS, onlineCmd:SerializeToString())
		print("select role online:" .. revCmd.rolebase[1].roleid .. "," .. revCmd.rolebase[1].rolename)
	end
end

function ParseCreateRoleRet()
	local revCmd = RolePb.CreateRoleRet()
	revCmd:ParseFromString(CSInterface.s_recvBytes)
	print ("create role success: " .. revCmd.rolebase.roleid .. revCmd.rolebase.rolename)

	local onlineCmd = RolePb.SelectRoleOnline()
	--onlineCmd.roleid = revCmd.rolebase.roleid
	SendCmd(BaseTypePb.USER_ONLINE_CS, onlineCmd:SerializeToString())
	print("select role online:" .. revCmd.rolebase.roleid .. revCmd.rolebase.rolename)
end

function ParseRoleDataLoadOk()
	print("Role data load ok")
	
	CSInterface.LoadLevel("MainScene")
  end
 