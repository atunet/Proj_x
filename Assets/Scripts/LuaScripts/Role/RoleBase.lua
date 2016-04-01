require("basetype_pb")
local BaseTypePb = _G['Protol/basetype_pb']

require("role_pb")
local RolePb = _G['Protol/role_pb']

module(..., package.seeall)

function ParseRoleList()
	local revCmd = RolePb.RoleList()
	revCmd:ParseFromString(CSInterface.s_recvBytes)

	if 0 == table.getn(revCmd.rolebase) then
		local createCmd = RolePb.CreateRoleReq()
		createCmd.roletype = 11103000
		createCmd.rolename = "atunet"
		--[[createCmd.avatar[1] = 1
		createCmd.avatar[2] = 2
		createCmd.avatar[3] = 1
		createCmd.avatar[4] = 1
		--]]
		SendCmd(BaseTypePb.CREATE_ROLE_REQ, createCmd:SerializeToString())

		print("role size is 0, req create role: " .. createCmd.rolename)

	else
		local onlineCmd = RolePb.SelectRoleOnline()
		onlineCmd.roleid = revCmd.rolebase[1].roleid
		SendCmd(BaseTypePb.SELECT_ROLE_ONLINE, onlineCmd:SerializeToString())

		print("select role online:" .. revCmd.rolebase[1].roleid .. revCmd.rolebase[1].rolename)
	end

end