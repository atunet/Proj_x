-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf/protobuf"
module('Protol/questtype_pb')


local QUESTTARGETBASE = protobuf.Descriptor();
local QUESTTARGETBASE_TARGET_FIELD = protobuf.FieldDescriptor();
local QUESTTARGETBASE_COUNT_FIELD = protobuf.FieldDescriptor();
local QUESTINFOBASE = protobuf.Descriptor();
local QUESTINFOBASE_QUEST_FIELD = protobuf.FieldDescriptor();
local QUESTINFOBASE_COUNTER_FIELD = protobuf.FieldDescriptor();
local QUESTINFOBASE_TYPE_FIELD = protobuf.FieldDescriptor();
local QUESTRESOURCEREWARD = protobuf.Descriptor();
local QUESTRESOURCEREWARD_KEY_FIELD = protobuf.FieldDescriptor();
local QUESTRESOURCEREWARD_VALUE_FIELD = protobuf.FieldDescriptor();
local QUESTITEMREWARD = protobuf.Descriptor();
local QUESTITEMREWARD_KEY_FIELD = protobuf.FieldDescriptor();
local QUESTITEMREWARD_VALUE_FIELD = protobuf.FieldDescriptor();
local QUESTITEMREWARD_TYPE_FIELD = protobuf.FieldDescriptor();

QUESTTARGETBASE_TARGET_FIELD.name = "target"
QUESTTARGETBASE_TARGET_FIELD.full_name = ".Cmd.QuestTargetBase.target"
QUESTTARGETBASE_TARGET_FIELD.number = 1
QUESTTARGETBASE_TARGET_FIELD.index = 0
QUESTTARGETBASE_TARGET_FIELD.label = 2
QUESTTARGETBASE_TARGET_FIELD.has_default_value = false
QUESTTARGETBASE_TARGET_FIELD.default_value = 0
QUESTTARGETBASE_TARGET_FIELD.type = 5
QUESTTARGETBASE_TARGET_FIELD.cpp_type = 1

QUESTTARGETBASE_COUNT_FIELD.name = "count"
QUESTTARGETBASE_COUNT_FIELD.full_name = ".Cmd.QuestTargetBase.count"
QUESTTARGETBASE_COUNT_FIELD.number = 2
QUESTTARGETBASE_COUNT_FIELD.index = 1
QUESTTARGETBASE_COUNT_FIELD.label = 2
QUESTTARGETBASE_COUNT_FIELD.has_default_value = false
QUESTTARGETBASE_COUNT_FIELD.default_value = 0
QUESTTARGETBASE_COUNT_FIELD.type = 5
QUESTTARGETBASE_COUNT_FIELD.cpp_type = 1

QUESTTARGETBASE.name = "QuestTargetBase"
QUESTTARGETBASE.full_name = ".Cmd.QuestTargetBase"
QUESTTARGETBASE.nested_types = {}
QUESTTARGETBASE.enum_types = {}
QUESTTARGETBASE.fields = {QUESTTARGETBASE_TARGET_FIELD, QUESTTARGETBASE_COUNT_FIELD}
QUESTTARGETBASE.is_extendable = false
QUESTTARGETBASE.extensions = {}
QUESTINFOBASE_QUEST_FIELD.name = "quest"
QUESTINFOBASE_QUEST_FIELD.full_name = ".Cmd.QuestInfoBase.quest"
QUESTINFOBASE_QUEST_FIELD.number = 1
QUESTINFOBASE_QUEST_FIELD.index = 0
QUESTINFOBASE_QUEST_FIELD.label = 2
QUESTINFOBASE_QUEST_FIELD.has_default_value = false
QUESTINFOBASE_QUEST_FIELD.default_value = 0
QUESTINFOBASE_QUEST_FIELD.type = 5
QUESTINFOBASE_QUEST_FIELD.cpp_type = 1

QUESTINFOBASE_COUNTER_FIELD.name = "counter"
QUESTINFOBASE_COUNTER_FIELD.full_name = ".Cmd.QuestInfoBase.counter"
QUESTINFOBASE_COUNTER_FIELD.number = 2
QUESTINFOBASE_COUNTER_FIELD.index = 1
QUESTINFOBASE_COUNTER_FIELD.label = 2
QUESTINFOBASE_COUNTER_FIELD.has_default_value = false
QUESTINFOBASE_COUNTER_FIELD.default_value = 0
QUESTINFOBASE_COUNTER_FIELD.type = 5
QUESTINFOBASE_COUNTER_FIELD.cpp_type = 1

QUESTINFOBASE_TYPE_FIELD.name = "type"
QUESTINFOBASE_TYPE_FIELD.full_name = ".Cmd.QuestInfoBase.type"
QUESTINFOBASE_TYPE_FIELD.number = 3
QUESTINFOBASE_TYPE_FIELD.index = 2
QUESTINFOBASE_TYPE_FIELD.label = 1
QUESTINFOBASE_TYPE_FIELD.has_default_value = false
QUESTINFOBASE_TYPE_FIELD.default_value = 0
QUESTINFOBASE_TYPE_FIELD.type = 5
QUESTINFOBASE_TYPE_FIELD.cpp_type = 1

QUESTINFOBASE.name = "QuestInfoBase"
QUESTINFOBASE.full_name = ".Cmd.QuestInfoBase"
QUESTINFOBASE.nested_types = {}
QUESTINFOBASE.enum_types = {}
QUESTINFOBASE.fields = {QUESTINFOBASE_QUEST_FIELD, QUESTINFOBASE_COUNTER_FIELD, QUESTINFOBASE_TYPE_FIELD}
QUESTINFOBASE.is_extendable = false
QUESTINFOBASE.extensions = {}
QUESTRESOURCEREWARD_KEY_FIELD.name = "key"
QUESTRESOURCEREWARD_KEY_FIELD.full_name = ".Cmd.QuestResourceReward.key"
QUESTRESOURCEREWARD_KEY_FIELD.number = 1
QUESTRESOURCEREWARD_KEY_FIELD.index = 0
QUESTRESOURCEREWARD_KEY_FIELD.label = 2
QUESTRESOURCEREWARD_KEY_FIELD.has_default_value = false
QUESTRESOURCEREWARD_KEY_FIELD.default_value = 0
QUESTRESOURCEREWARD_KEY_FIELD.type = 13
QUESTRESOURCEREWARD_KEY_FIELD.cpp_type = 3

QUESTRESOURCEREWARD_VALUE_FIELD.name = "value"
QUESTRESOURCEREWARD_VALUE_FIELD.full_name = ".Cmd.QuestResourceReward.value"
QUESTRESOURCEREWARD_VALUE_FIELD.number = 2
QUESTRESOURCEREWARD_VALUE_FIELD.index = 1
QUESTRESOURCEREWARD_VALUE_FIELD.label = 2
QUESTRESOURCEREWARD_VALUE_FIELD.has_default_value = false
QUESTRESOURCEREWARD_VALUE_FIELD.default_value = 0
QUESTRESOURCEREWARD_VALUE_FIELD.type = 13
QUESTRESOURCEREWARD_VALUE_FIELD.cpp_type = 3

QUESTRESOURCEREWARD.name = "QuestResourceReward"
QUESTRESOURCEREWARD.full_name = ".Cmd.QuestResourceReward"
QUESTRESOURCEREWARD.nested_types = {}
QUESTRESOURCEREWARD.enum_types = {}
QUESTRESOURCEREWARD.fields = {QUESTRESOURCEREWARD_KEY_FIELD, QUESTRESOURCEREWARD_VALUE_FIELD}
QUESTRESOURCEREWARD.is_extendable = false
QUESTRESOURCEREWARD.extensions = {}
QUESTITEMREWARD_KEY_FIELD.name = "key"
QUESTITEMREWARD_KEY_FIELD.full_name = ".Cmd.QuestItemReward.key"
QUESTITEMREWARD_KEY_FIELD.number = 1
QUESTITEMREWARD_KEY_FIELD.index = 0
QUESTITEMREWARD_KEY_FIELD.label = 2
QUESTITEMREWARD_KEY_FIELD.has_default_value = false
QUESTITEMREWARD_KEY_FIELD.default_value = 0
QUESTITEMREWARD_KEY_FIELD.type = 13
QUESTITEMREWARD_KEY_FIELD.cpp_type = 3

QUESTITEMREWARD_VALUE_FIELD.name = "value"
QUESTITEMREWARD_VALUE_FIELD.full_name = ".Cmd.QuestItemReward.value"
QUESTITEMREWARD_VALUE_FIELD.number = 2
QUESTITEMREWARD_VALUE_FIELD.index = 1
QUESTITEMREWARD_VALUE_FIELD.label = 2
QUESTITEMREWARD_VALUE_FIELD.has_default_value = false
QUESTITEMREWARD_VALUE_FIELD.default_value = 0
QUESTITEMREWARD_VALUE_FIELD.type = 13
QUESTITEMREWARD_VALUE_FIELD.cpp_type = 3

QUESTITEMREWARD_TYPE_FIELD.name = "type"
QUESTITEMREWARD_TYPE_FIELD.full_name = ".Cmd.QuestItemReward.type"
QUESTITEMREWARD_TYPE_FIELD.number = 3
QUESTITEMREWARD_TYPE_FIELD.index = 2
QUESTITEMREWARD_TYPE_FIELD.label = 2
QUESTITEMREWARD_TYPE_FIELD.has_default_value = false
QUESTITEMREWARD_TYPE_FIELD.default_value = 0
QUESTITEMREWARD_TYPE_FIELD.type = 13
QUESTITEMREWARD_TYPE_FIELD.cpp_type = 3

QUESTITEMREWARD.name = "QuestItemReward"
QUESTITEMREWARD.full_name = ".Cmd.QuestItemReward"
QUESTITEMREWARD.nested_types = {}
QUESTITEMREWARD.enum_types = {}
QUESTITEMREWARD.fields = {QUESTITEMREWARD_KEY_FIELD, QUESTITEMREWARD_VALUE_FIELD, QUESTITEMREWARD_TYPE_FIELD}
QUESTITEMREWARD.is_extendable = false
QUESTITEMREWARD.extensions = {}

QuestInfoBase = protobuf.Message(QUESTINFOBASE)
QuestItemReward = protobuf.Message(QUESTITEMREWARD)
QuestResourceReward = protobuf.Message(QUESTRESOURCEREWARD)
QuestTargetBase = protobuf.Message(QUESTTARGETBASE)

