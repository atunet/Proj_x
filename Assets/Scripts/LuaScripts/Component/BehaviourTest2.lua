
module(..., package.seeall)

function New(metatable_)
	print("BehaviourTest2 New called")
	local tb = {}
	setmetatable(tb, metatable_)
	metatable_.__index = metatable_
	return tb
end

function Awake()
	print ("BehaviourTest2 Awake called")
end

function Start()
	print("BehaviourTest2 Start called")
end

function Update()
	print("BehaviourTest2 Update called")
end

function LateUpdate()
	print("BehaviourTest2 LateUpdate called")
end

function FixedUpdate()
	print("BehaviourTest2 FixedUpdate called")
end

function OnDestroy()
	print("BehaviourTest2 OnDestroy called")
end
