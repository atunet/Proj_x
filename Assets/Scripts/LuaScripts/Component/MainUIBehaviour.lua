
module(..., package.seeall)

function New(metatable_)
	print("BehaviourTest New called")
	local tb = {}
	setmetatable(tb, metatable_)
	metatable_.__index = metatable_
	return tb
end

function Awake()
	--print ("BehaviourTest Awake called")
end

function Start()
	--print("BehaviourTest Start called")
end

function Update()
	--print("BehaviourTest Update called")
end

function LateUpdate()
	--print("BehaviourTest LateUpdate called")
end

function FixedUpdate()
	--print("BehaviourTest FixedUpdate called")
end

function OnDestroy()
	--print("BehaviourTest OnDestroy called")
end

function OnClick(go_)
	print ("OnClick called: " .. go_.name)
end

function OnClickLv(go_)
	print ("OnClickLv called: " .. go_.name)
end
