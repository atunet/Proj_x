
module(..., package.seeall)

function New(metatable_)
	print("InitMainBehaviour New called")
	local tb = {}
	setmetatable(tb, metatable_)
	metatable_.__index = metatable_
	return tb
end

function Awake()
	--print ("InitMainBehaviour Awake called")
end

function Start()
	--print("InitMainBehaviour Start called")

    local GameObject = UnityEngine.GameObject           

    local levelAB = ABManager.get("sprite_level")
	local sceneAB = ABManager.get("prefab_scene")

	local bgPrefab = sceneAB:LoadAsset ("mainbg")
	if nil ~= bgPrefab then
		print("bg prefab asset load ok")
	end
	local mainBgGo = GameObject.Instantiate(bgPrefab)
    mainBgGo.transform:SetParent(SceneRoot(), false)
    mainBgGo.name = "mainBG"

    local mainAB = ABManager.get("prefab_mainui")

    local mainuiPrefab = mainAB:LoadAsset("panel_main_ui")
    local mainuiGo = GameObject.Instantiate(mainuiPrefab)
    mainuiGo.transform:SetParent(UIRoot(), false)
    mainuiGo.name = "panel_main_ui"

    local uiBehaviour = CSBridge.AddComponent(mainuiGo, "UIMainBehaviour")
    local lvBtnTrans = mainuiGo.transform:FindChild("btn_level")
    if nil ~= lvBtnTrans then
        local lvBtn = lvBtnTrans.gameObject:GetComponent("Button")
        if nil ~= lvBtn then
            CSBridge.AddClick(lvBtn, uiBehaviour.OnClickLv)
        end
    end

    -- local goldPrefab = mainAB:LoadAsset("prop_gold")
    -- local goldGo = GameObject.Instantiate(goldPrefab)
    -- goldGo.transform:SetParent(UIRoot(), false)
    -- goldGo.name = "prop_gold"

    -- local cashPrefab = mainAB:LoadAsset("prop_cash")
    -- local cashGo = GameObject.Instantiate(cashPrefab)
    -- cashGo.transform:SetParent(UIRoot(), false)
    -- cashGo.name = "prop_cash"

    -- local strengthPrefab = mainAB:LoadAsset("prop_strength")
    -- local strengthGo = GameObject.Instantiate(strengthPrefab)
    -- strengthGo.transform:SetParent(UIRoot(), false)
    -- strengthGo.name = "prop_strength"

	--local levelBtnPrefab = mainAB:LoadAsset("btn_level")
    --local levelBtnGo = GameObject.Instantiate(levelBtnPrefab)
    --levelBtnGo.transform:SetParent(UIRoot(), false)
    --levelBtnGo.name = "btn_level"

    --local test = CSBridge.AddComponent(levelBtnGo, "BehaviourTest")
    --local btn = levelBtnGo:GetComponent("Button")
    --CSBridge.AddClick(btn, test.OnClick)
end

function Update()
	--print("InitMainBehaviour Update called")
end

function LateUpdate()
	--print("InitMainBehaviour LateUpdate called")
end

function FixedUpdate()
	--print("InitMainBehaviour FixedUpdate called")
end

function OnDestroy()
	--print("InitMainBehaviour OnDestroy called")
end

function OnClick(go_)
	print ("OnClick called: " .. go_.name)
end
