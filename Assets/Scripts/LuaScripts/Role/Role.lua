require("Protol.basetype_pb")
local BaseTypePb = Protol.basetype_pb

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
		createCmd.avatar:append(1)
		createCmd.avatar:append(1)
		createCmd.avatar:append(1)
		createCmd.avatar:append(1)
		SendCmd(BaseTypePb.CREATE_ROLE_REQ, createCmd:SerializeToString())
		print("role size is 0, req create role: " .. createCmd.rolename)
	else
		local onlineCmd = RolePb.SelectRoleOnline()
		onlineCmd.roleid = revCmd.rolebase[1].roleid
		SendCmd(BaseTypePb.SELECT_ROLE_ONLINE, onlineCmd:SerializeToString())
		print("select role online:" .. revCmd.rolebase[1].roleid .. "," .. revCmd.rolebase[1].rolename)
	end
end

function ParseCreateRoleRet()
	local revCmd = RolePb.CreateRoleRet()
	revCmd:ParseFromString(CSInterface.s_recvBytes)
	print ("create role success: " .. revCmd.rolebase.roleid .. revCmd.rolebase.rolename)

	local onlineCmd = RolePb.SelectRoleOnline()
	onlineCmd.roleid = revCmd.rolebase.roleid
	SendCmd(BaseTypePb.SELECT_ROLE_ONLINE, onlineCmd:SerializeToString())
	print("select role online:" .. revCmd.rolebase.roleid .. revCmd.rolebase.rolename)
end

function ParseRoleDataLoadOk()
	print("Role data load ok")

    local GameObject = UnityEngine.GameObject           

	local btnTrans = UIRoot():FindChild("login_btn(Clone)")
	if nil ~= btnTrans then 
		GameObject.Destroy(btnTrans.gameObject)
	end

	local bgTrans = SceneRoot():FindChild("background(Clone)")
	if nil ~= bgTrans then
		GameObject.Destroy(bgTrans.gameObject)
	end

    local levelAB = ABManager.get("sprite_level")
	local sceneAB = ABManager.get("prefab_scene")

	local bgPrefab = sceneAB:LoadAsset ("mainbg")
	if nil ~= bgPrefab then
		print("bg prefab asset load ok")
	end
	local mainBgTrans = GameObject.Instantiate(bgPrefab).transform
    mainBgTrans:SetParent(SceneRoot(), false)
    mainBgTrans.gameObject.name = "mainBG"

    local mainAB = ABManager.get("prefab_main_ui")

    local goldPrefab = mainAB:LoadAsset("prop_gold")
    local goldTrans = GameObject.Instantiate(goldPrefab).transform
    goldTrans:SetParent(UIRoot(), false)
    --goldTrans.gameObject.name = "prop_gold"

    local cashPrefab = mainAB:LoadAsset("prop_cash")
    local cashTrans = GameObject.Instantiate(cashPrefab).transform
    cashTrans:SetParent(UIRoot(), false)
    --cashTrans.gameObject.name = "prop_cash"

    local strengthPrefab = mainAB:LoadAsset("prop_strength")
    local strengthTrans = GameObject.Instantiate(strengthPrefab).transform
    strengthTrans:SetParent(UIRoot(), false)

    CSInterface.AddComponent(strengthTrans.gameObject, "BehaviourTest")
    CSInterface.AddComponent(strengthTrans.gameObject, "BehaviourTest2")

end