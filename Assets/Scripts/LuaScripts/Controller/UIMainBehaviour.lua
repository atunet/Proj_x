
module(..., package.seeall)

function New(metatable_)
	print("UIMainBehaviour New called")
	local tb = {}
	setmetatable(tb, metatable_)
	metatable_.__index = metatable_
	return tb
end

function Awake()
	--print ("UIMainBehaviour Awake called")
end

function Start()
	--print("UIMainBehaviour Start called")
end

function Update()
	--print("UIMainBehaviour Update called")
end

function LateUpdate()
	--print("UIMainBehaviour LateUpdate called")
end

function FixedUpdate()
	--print("UIMainBehaviour FixedUpdate called")
end

function OnDestroy()
	--print("UIMainBehaviour OnDestroy called")
end

function OnClick(go_)
	print ("OnClick called: " .. go_.name)
end

function OnClickLv(go_)

	print ("OnClickLv called: " .. go_.name)

	CSBridge.LoadLevel("BattleScene")
end
