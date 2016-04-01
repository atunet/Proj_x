require("role_pb")
local RolePb = _G['Protol/role_pb']

module(..., package.seeall)

function ParseRoleList()
	local cmd = RolePb.RoleList()
	cmd:ParseFromString(CSInterface.s_recvBytes)
	print("recv role list success, role count:" .. table.getn(cmd.rolebase))
end