
module(..., package.seeall)

function New(metatable_)
	print("InitBattleBehaviour New called")
	local tb = {}
	setmetatable(tb, metatable_)
	metatable_.__index = metatable_
	return tb
end

function Awake()
	--print ("InitBattleBehaviour Awake called")
end

function Start()
	--print("InitBattleBehaviour Start called")
	  local GameObject = UnityEngine.GameObject           

    local levelAB = ABManager.get("sprite_scene")
	local sceneAB = ABManager.get("prefab_scene")

	local bgPrefab = sceneAB:LoadAsset ("battlebg")
	if nil ~= bgPrefab then
		print("bg prefab asset load ok")
	end
	local battleBgGo = GameObject.Instantiate(bgPrefab)
    battleBgGo.transform:SetParent(SceneRoot(), false)
    battleBgGo.name = "battleBG"

    local mainAB = ABManager.get("prefab_battleui")

    local battleuiPrefab = mainAB:LoadAsset("panel_quit")
    local battleuiGo = GameObject.Instantiate(battleuiPrefab)
    battleuiGo.transform:SetParent(UIRoot(), false)
    battleuiGo.name = "panel_battle_ui"

    local uiBehaviour = CSInterface.AddComponent(battleuiGo, "UIBattleBehaviour")
    local quitBtnTrans = battleuiGo.transform:FindChild("btn_quit")
    if nil ~= quitBtnTrans then
        local quitBtn = quitBtnTrans.gameObject:GetComponent("Button")
        if nil ~= quitBtn then
            CSInterface.AddClick(quitBtn, uiBehaviour.OnClickQuit)
        end
    end
end

function Update()
	--print("InitBattleBehaviour Update called")
end

function LateUpdate()
	--print("InitBattleBehaviour LateUpdate called")
end

function FixedUpdate()
	--print("InitBattleBehaviour FixedUpdate called")
end

function OnDestroy()
	--print("InitBattleBehaviour OnDestroy called")
end

function OnClick(go_)
	print ("OnClick called: " .. go_.name)
end

function OnClickQuit(go_)
	
	print ("OnClickQuit called: " .. go_.name)

	CSInterface.LoadLevel("MainScene")
end
