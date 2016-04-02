require("basetype_pb")
local BaseTypePb = _G['Protol/basetype_pb']

require("role_pb")
local RolePb = _G['Protol/role_pb']

module(..., package.seeall)

function ParseRoleList()
	print("recv byte length:" .. string.len(CSInterface.s_recvBytes))
	local revCmd = RolePb.RoleList()
	revCmd:ParseFromString(CSInterface.s_recvBytes)

	if 0 == table.getn(revCmd.rolebase) then
		--[[
		local createCmd = RolePb.CreateRoleReq()
		createCmd.roletype = 11103000
		createCmd.rolename = "atunet1"
		createCmd.avatar:append(1)
		createCmd.avatar:append(1)
		createCmd.avatar:append(1)
		createCmd.avatar:append(1)
		SendCmd(BaseTypePb.CREATE_ROLE_REQ, createCmd:SerializeToString())
		print("role size is 0, req create role: " .. createCmd.rolename)
		--]]
		print("role list size is 0")
	else
		local onlineCmd = RolePb.SelectRoleOnline()
		onlineCmd.roleid = revCmd.rolebase[1].roleid
		SendCmd(BaseTypePb.SELECT_ROLE_ONLINE, onlineCmd:SerializeToString())
		print("select role online:" .. revCmd.rolebase[1].roleid .. revCmd.rolebase[1].rolename)
	end
end

	--[[
	local GameObject = UnityEngine.GameObject           
            local ParticleSystem = UnityEngine.ParticleSystem    

            local go = GameObject('go')
            go:AddComponent(typeof(ParticleSystem))
            local node = go.transform
            node.position = Vector3.one      
            print('gameObject is: '..tostring(go))     
            GameObject.Destroy(go, 5)       
	--]]

function ParseCreateRoleRet()
	local revCmd = RolePb.CreateRoleRet()
	revCmd:ParseFromString(CSInterface.s_recvBytes)
	print ("create role success: " .. revCmd.rolebase.roleid .. revCmd.rolebase.rolename)

	local onlineCmd = RolePb.SelectRoleOnline()
	onlineCmd.roleid = revCmd.rolebase.roleid
	SendCmd(BaseTypePb.SELECT_ROLE_ONLINE, onlineCmd:SerializeToString())
	print("select role online:" .. revCmd.rolebase.roleid .. revCmd.rolebase.rolename)
end