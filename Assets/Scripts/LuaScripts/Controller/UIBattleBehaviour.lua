
module(..., package.seeall)

function New(metatable_)
	print("UIBattleBehaviour New called")
	local tb = {}
	setmetatable(tb, metatable_)
	metatable_.__index = metatable_
	return tb
end

function Awake()
	--print ("UIBattleBehaviour Awake called")
end

function Start()
	--print("UIBattleBehaviour Start called")
end

function Update()
	--print("UIBattleBehaviour Update called")
end

function LateUpdate()
	--print("UIBattleBehaviour LateUpdate called")
end

function FixedUpdate()
	--print("UIBattleBehaviour FixedUpdate called")
end

function OnDestroy()
	--print("UIBattleBehaviour OnDestroy called")
end

function OnClick(go_)
	print ("OnClick called: " .. go_.name)
end

function OnClickQuit(go_)
	
	print ("OnClickQuit called: " .. go_.name)

	CSInterface.LoadLevel("MainScene")
end
