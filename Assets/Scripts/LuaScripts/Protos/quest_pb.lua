--Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
local basetype_pb = require("basetype_pb")
local questtype_pb = require("questtype_pb")
module('Protol.quest_pb')

MESSAGEGETQUESTLIST = protobuf.Descriptor();
MESSAGEGETQUESTLIST_ID_FIELD = protobuf.FieldDescriptor();
MESSAGEQUESTLIST = protobuf.Descriptor();
MESSAGEQUESTLIST_ID_FIELD = protobuf.FieldDescriptor();
MESSAGEQUESTLIST_SHOWIDS_FIELD = protobuf.FieldDescriptor();
MESSAGEQUESTLIST_ACCEPTIDS_FIELD = protobuf.FieldDescriptor();
MESSAGEQUESTLIST_DOINGS_FIELD = protobuf.FieldDescriptor();
MESSAGEGETDAILYQUESTLIST = protobuf.Descriptor();
MESSAGEGETDAILYQUESTLIST_ID_FIELD = protobuf.FieldDescriptor();
MESSAGEDAILYQUESTLIST = protobuf.Descriptor();
MESSAGEDAILYQUESTLIST_ID_FIELD = protobuf.FieldDescriptor();
MESSAGEDAILYQUESTLIST_TIME_FIELD = protobuf.FieldDescriptor();
MESSAGEDAILYQUESTLIST_LISTS_FIELD = protobuf.FieldDescriptor();
MESSAGEDAILYQUESTLIST_NOWTIME_FIELD = protobuf.FieldDescriptor();
MESSAGEACCEPTQUESTREQUEST = protobuf.Descriptor();
MESSAGEACCEPTQUESTREQUEST_ID_FIELD = protobuf.FieldDescriptor();
MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD = protobuf.FieldDescriptor();
MESSAGEACCEPTQUESTRESPONSE = protobuf.Descriptor();
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD = protobuf.FieldDescriptor();
MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD = protobuf.FieldDescriptor();
MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD = protobuf.FieldDescriptor();
MESSAGESUBMITQUESTREQUEST = protobuf.Descriptor();
MESSAGESUBMITQUESTREQUEST_ID_FIELD = protobuf.FieldDescriptor();
MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD = protobuf.FieldDescriptor();
MESSAGESUBMITQUESTRESPONSE = protobuf.Descriptor();
MESSAGESUBMITQUESTRESPONSE_ID_FIELD = protobuf.FieldDescriptor();
MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD = protobuf.FieldDescriptor();
MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD = protobuf.FieldDescriptor();
MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD = protobuf.FieldDescriptor();
MESSAGEQUESTPROGRESSNOTICE = protobuf.Descriptor();
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD = protobuf.FieldDescriptor();
MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD = protobuf.FieldDescriptor();

MESSAGEGETQUESTLIST_ID_FIELD.name = "id"
MESSAGEGETQUESTLIST_ID_FIELD.full_name = ".Cmd.MessageGetQuestList.id"
MESSAGEGETQUESTLIST_ID_FIELD.number = 1
MESSAGEGETQUESTLIST_ID_FIELD.index = 0
MESSAGEGETQUESTLIST_ID_FIELD.label = 1
MESSAGEGETQUESTLIST_ID_FIELD.has_default_value = true
MESSAGEGETQUESTLIST_ID_FIELD.default_value = GET_QUESTLIST_C
MESSAGEGETQUESTLIST_ID_FIELD.enum_type = basetype_pb.EPROTOID
MESSAGEGETQUESTLIST_ID_FIELD.type = 14
MESSAGEGETQUESTLIST_ID_FIELD.cpp_type = 8

MESSAGEGETQUESTLIST.name = "MessageGetQuestList"
MESSAGEGETQUESTLIST.full_name = ".Cmd.MessageGetQuestList"
MESSAGEGETQUESTLIST.nested_types = {}
MESSAGEGETQUESTLIST.enum_types = {}
MESSAGEGETQUESTLIST.fields = {MESSAGEGETQUESTLIST_ID_FIELD}
MESSAGEGETQUESTLIST.is_extendable = false
MESSAGEGETQUESTLIST.extensions = {}
MESSAGEQUESTLIST_ID_FIELD.name = "id"
MESSAGEQUESTLIST_ID_FIELD.full_name = ".Cmd.MessageQuestList.id"
MESSAGEQUESTLIST_ID_FIELD.number = 1
MESSAGEQUESTLIST_ID_FIELD.index = 0
MESSAGEQUESTLIST_ID_FIELD.label = 1
MESSAGEQUESTLIST_ID_FIELD.has_default_value = true
MESSAGEQUESTLIST_ID_FIELD.default_value = GET_QUESTLIST_S
MESSAGEQUESTLIST_ID_FIELD.enum_type = basetype_pb.EPROTOID
MESSAGEQUESTLIST_ID_FIELD.type = 14
MESSAGEQUESTLIST_ID_FIELD.cpp_type = 8

MESSAGEQUESTLIST_SHOWIDS_FIELD.name = "showids"
MESSAGEQUESTLIST_SHOWIDS_FIELD.full_name = ".Cmd.MessageQuestList.showids"
MESSAGEQUESTLIST_SHOWIDS_FIELD.number = 2
MESSAGEQUESTLIST_SHOWIDS_FIELD.index = 1
MESSAGEQUESTLIST_SHOWIDS_FIELD.label = 3
MESSAGEQUESTLIST_SHOWIDS_FIELD.has_default_value = false
MESSAGEQUESTLIST_SHOWIDS_FIELD.default_value = {}
MESSAGEQUESTLIST_SHOWIDS_FIELD.type = 5
MESSAGEQUESTLIST_SHOWIDS_FIELD.cpp_type = 1

MESSAGEQUESTLIST_ACCEPTIDS_FIELD.name = "acceptids"
MESSAGEQUESTLIST_ACCEPTIDS_FIELD.full_name = ".Cmd.MessageQuestList.acceptids"
MESSAGEQUESTLIST_ACCEPTIDS_FIELD.number = 3
MESSAGEQUESTLIST_ACCEPTIDS_FIELD.index = 2
MESSAGEQUESTLIST_ACCEPTIDS_FIELD.label = 3
MESSAGEQUESTLIST_ACCEPTIDS_FIELD.has_default_value = false
MESSAGEQUESTLIST_ACCEPTIDS_FIELD.default_value = {}
MESSAGEQUESTLIST_ACCEPTIDS_FIELD.type = 5
MESSAGEQUESTLIST_ACCEPTIDS_FIELD.cpp_type = 1

MESSAGEQUESTLIST_DOINGS_FIELD.name = "doings"
MESSAGEQUESTLIST_DOINGS_FIELD.full_name = ".Cmd.MessageQuestList.doings"
MESSAGEQUESTLIST_DOINGS_FIELD.number = 4
MESSAGEQUESTLIST_DOINGS_FIELD.index = 3
MESSAGEQUESTLIST_DOINGS_FIELD.label = 3
MESSAGEQUESTLIST_DOINGS_FIELD.has_default_value = false
MESSAGEQUESTLIST_DOINGS_FIELD.default_value = {}
MESSAGEQUESTLIST_DOINGS_FIELD.message_type = questtype_pb.QUESTINFOBASE
MESSAGEQUESTLIST_DOINGS_FIELD.type = 11
MESSAGEQUESTLIST_DOINGS_FIELD.cpp_type = 10

MESSAGEQUESTLIST.name = "MessageQuestList"
MESSAGEQUESTLIST.full_name = ".Cmd.MessageQuestList"
MESSAGEQUESTLIST.nested_types = {}
MESSAGEQUESTLIST.enum_types = {}
MESSAGEQUESTLIST.fields = {MESSAGEQUESTLIST_ID_FIELD, MESSAGEQUESTLIST_SHOWIDS_FIELD, MESSAGEQUESTLIST_ACCEPTIDS_FIELD, MESSAGEQUESTLIST_DOINGS_FIELD}
MESSAGEQUESTLIST.is_extendable = false
MESSAGEQUESTLIST.extensions = {}
MESSAGEGETDAILYQUESTLIST_ID_FIELD.name = "id"
MESSAGEGETDAILYQUESTLIST_ID_FIELD.full_name = ".Cmd.MessageGetDailyQuestList.id"
MESSAGEGETDAILYQUESTLIST_ID_FIELD.number = 1
MESSAGEGETDAILYQUESTLIST_ID_FIELD.index = 0
MESSAGEGETDAILYQUESTLIST_ID_FIELD.label = 1
MESSAGEGETDAILYQUESTLIST_ID_FIELD.has_default_value = true
MESSAGEGETDAILYQUESTLIST_ID_FIELD.default_value = GET_DAILYQUEST_C
MESSAGEGETDAILYQUESTLIST_ID_FIELD.enum_type = basetype_pb.EPROTOID
MESSAGEGETDAILYQUESTLIST_ID_FIELD.type = 14
MESSAGEGETDAILYQUESTLIST_ID_FIELD.cpp_type = 8

MESSAGEGETDAILYQUESTLIST.name = "MessageGetDailyQuestList"
MESSAGEGETDAILYQUESTLIST.full_name = ".Cmd.MessageGetDailyQuestList"
MESSAGEGETDAILYQUESTLIST.nested_types = {}
MESSAGEGETDAILYQUESTLIST.enum_types = {}
MESSAGEGETDAILYQUESTLIST.fields = {MESSAGEGETDAILYQUESTLIST_ID_FIELD}
MESSAGEGETDAILYQUESTLIST.is_extendable = false
MESSAGEGETDAILYQUESTLIST.extensions = {}
MESSAGEDAILYQUESTLIST_ID_FIELD.name = "id"
MESSAGEDAILYQUESTLIST_ID_FIELD.full_name = ".Cmd.MessageDailyQuestList.id"
MESSAGEDAILYQUESTLIST_ID_FIELD.number = 1
MESSAGEDAILYQUESTLIST_ID_FIELD.index = 0
MESSAGEDAILYQUESTLIST_ID_FIELD.label = 1
MESSAGEDAILYQUESTLIST_ID_FIELD.has_default_value = true
MESSAGEDAILYQUESTLIST_ID_FIELD.default_value = GET_DAILYQUEST_S
MESSAGEDAILYQUESTLIST_ID_FIELD.enum_type = basetype_pb.EPROTOID
MESSAGEDAILYQUESTLIST_ID_FIELD.type = 14
MESSAGEDAILYQUESTLIST_ID_FIELD.cpp_type = 8

MESSAGEDAILYQUESTLIST_TIME_FIELD.name = "time"
MESSAGEDAILYQUESTLIST_TIME_FIELD.full_name = ".Cmd.MessageDailyQuestList.time"
MESSAGEDAILYQUESTLIST_TIME_FIELD.number = 2
MESSAGEDAILYQUESTLIST_TIME_FIELD.index = 1
MESSAGEDAILYQUESTLIST_TIME_FIELD.label = 1
MESSAGEDAILYQUESTLIST_TIME_FIELD.has_default_value = false
MESSAGEDAILYQUESTLIST_TIME_FIELD.default_value = 0
MESSAGEDAILYQUESTLIST_TIME_FIELD.type = 13
MESSAGEDAILYQUESTLIST_TIME_FIELD.cpp_type = 3

MESSAGEDAILYQUESTLIST_LISTS_FIELD.name = "lists"
MESSAGEDAILYQUESTLIST_LISTS_FIELD.full_name = ".Cmd.MessageDailyQuestList.lists"
MESSAGEDAILYQUESTLIST_LISTS_FIELD.number = 3
MESSAGEDAILYQUESTLIST_LISTS_FIELD.index = 2
MESSAGEDAILYQUESTLIST_LISTS_FIELD.label = 3
MESSAGEDAILYQUESTLIST_LISTS_FIELD.has_default_value = false
MESSAGEDAILYQUESTLIST_LISTS_FIELD.default_value = {}
MESSAGEDAILYQUESTLIST_LISTS_FIELD.message_type = questtype_pb.QUESTINFOBASE
MESSAGEDAILYQUESTLIST_LISTS_FIELD.type = 11
MESSAGEDAILYQUESTLIST_LISTS_FIELD.cpp_type = 10

MESSAGEDAILYQUESTLIST_NOWTIME_FIELD.name = "nowtime"
MESSAGEDAILYQUESTLIST_NOWTIME_FIELD.full_name = ".Cmd.MessageDailyQuestList.nowtime"
MESSAGEDAILYQUESTLIST_NOWTIME_FIELD.number = 4
MESSAGEDAILYQUESTLIST_NOWTIME_FIELD.index = 3
MESSAGEDAILYQUESTLIST_NOWTIME_FIELD.label = 1
MESSAGEDAILYQUESTLIST_NOWTIME_FIELD.has_default_value = false
MESSAGEDAILYQUESTLIST_NOWTIME_FIELD.default_value = 0
MESSAGEDAILYQUESTLIST_NOWTIME_FIELD.type = 13
MESSAGEDAILYQUESTLIST_NOWTIME_FIELD.cpp_type = 3

MESSAGEDAILYQUESTLIST.name = "MessageDailyQuestList"
MESSAGEDAILYQUESTLIST.full_name = ".Cmd.MessageDailyQuestList"
MESSAGEDAILYQUESTLIST.nested_types = {}
MESSAGEDAILYQUESTLIST.enum_types = {}
MESSAGEDAILYQUESTLIST.fields = {MESSAGEDAILYQUESTLIST_ID_FIELD, MESSAGEDAILYQUESTLIST_TIME_FIELD, MESSAGEDAILYQUESTLIST_LISTS_FIELD, MESSAGEDAILYQUESTLIST_NOWTIME_FIELD}
MESSAGEDAILYQUESTLIST.is_extendable = false
MESSAGEDAILYQUESTLIST.extensions = {}
MESSAGEACCEPTQUESTREQUEST_ID_FIELD.name = "id"
MESSAGEACCEPTQUESTREQUEST_ID_FIELD.full_name = ".Cmd.MessageAcceptQuestRequest.id"
MESSAGEACCEPTQUESTREQUEST_ID_FIELD.number = 1
MESSAGEACCEPTQUESTREQUEST_ID_FIELD.index = 0
MESSAGEACCEPTQUESTREQUEST_ID_FIELD.label = 1
MESSAGEACCEPTQUESTREQUEST_ID_FIELD.has_default_value = true
MESSAGEACCEPTQUESTREQUEST_ID_FIELD.default_value = ACCEPT_QUEST_C
MESSAGEACCEPTQUESTREQUEST_ID_FIELD.enum_type = basetype_pb.EPROTOID
MESSAGEACCEPTQUESTREQUEST_ID_FIELD.type = 14
MESSAGEACCEPTQUESTREQUEST_ID_FIELD.cpp_type = 8

MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD.name = "questid"
MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD.full_name = ".Cmd.MessageAcceptQuestRequest.questid"
MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD.number = 2
MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD.index = 1
MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD.label = 2
MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD.has_default_value = false
MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD.default_value = 0
MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD.type = 5
MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD.cpp_type = 1

MESSAGEACCEPTQUESTREQUEST.name = "MessageAcceptQuestRequest"
MESSAGEACCEPTQUESTREQUEST.full_name = ".Cmd.MessageAcceptQuestRequest"
MESSAGEACCEPTQUESTREQUEST.nested_types = {}
MESSAGEACCEPTQUESTREQUEST.enum_types = {}
MESSAGEACCEPTQUESTREQUEST.fields = {MESSAGEACCEPTQUESTREQUEST_ID_FIELD, MESSAGEACCEPTQUESTREQUEST_QUESTID_FIELD}
MESSAGEACCEPTQUESTREQUEST.is_extendable = false
MESSAGEACCEPTQUESTREQUEST.extensions = {}
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD.name = "id"
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD.full_name = ".Cmd.MessageAcceptQuestResponse.id"
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD.number = 1
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD.index = 0
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD.label = 1
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD.has_default_value = true
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD.default_value = ACCEPT_QUEST_S
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD.enum_type = basetype_pb.EPROTOID
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD.type = 14
MESSAGEACCEPTQUESTRESPONSE_ID_FIELD.cpp_type = 8

MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD.name = "questid"
MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD.full_name = ".Cmd.MessageAcceptQuestResponse.questid"
MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD.number = 2
MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD.index = 1
MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD.label = 2
MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD.has_default_value = false
MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD.default_value = 0
MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD.type = 5
MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD.cpp_type = 1

MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD.name = "progress"
MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD.full_name = ".Cmd.MessageAcceptQuestResponse.progress"
MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD.number = 3
MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD.index = 2
MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD.label = 2
MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD.has_default_value = false
MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD.default_value = nil
MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD.message_type = questtype_pb.QUESTINFOBASE
MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD.type = 11
MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD.cpp_type = 10

MESSAGEACCEPTQUESTRESPONSE.name = "MessageAcceptQuestResponse"
MESSAGEACCEPTQUESTRESPONSE.full_name = ".Cmd.MessageAcceptQuestResponse"
MESSAGEACCEPTQUESTRESPONSE.nested_types = {}
MESSAGEACCEPTQUESTRESPONSE.enum_types = {}
MESSAGEACCEPTQUESTRESPONSE.fields = {MESSAGEACCEPTQUESTRESPONSE_ID_FIELD, MESSAGEACCEPTQUESTRESPONSE_QUESTID_FIELD, MESSAGEACCEPTQUESTRESPONSE_PROGRESS_FIELD}
MESSAGEACCEPTQUESTRESPONSE.is_extendable = false
MESSAGEACCEPTQUESTRESPONSE.extensions = {}
MESSAGESUBMITQUESTREQUEST_ID_FIELD.name = "id"
MESSAGESUBMITQUESTREQUEST_ID_FIELD.full_name = ".Cmd.MessageSubmitQuestRequest.id"
MESSAGESUBMITQUESTREQUEST_ID_FIELD.number = 1
MESSAGESUBMITQUESTREQUEST_ID_FIELD.index = 0
MESSAGESUBMITQUESTREQUEST_ID_FIELD.label = 1
MESSAGESUBMITQUESTREQUEST_ID_FIELD.has_default_value = true
MESSAGESUBMITQUESTREQUEST_ID_FIELD.default_value = SUBMIT_QUEST_C
MESSAGESUBMITQUESTREQUEST_ID_FIELD.enum_type = basetype_pb.EPROTOID
MESSAGESUBMITQUESTREQUEST_ID_FIELD.type = 14
MESSAGESUBMITQUESTREQUEST_ID_FIELD.cpp_type = 8

MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD.name = "questid"
MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD.full_name = ".Cmd.MessageSubmitQuestRequest.questid"
MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD.number = 2
MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD.index = 1
MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD.label = 2
MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD.has_default_value = false
MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD.default_value = 0
MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD.type = 5
MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD.cpp_type = 1

MESSAGESUBMITQUESTREQUEST.name = "MessageSubmitQuestRequest"
MESSAGESUBMITQUESTREQUEST.full_name = ".Cmd.MessageSubmitQuestRequest"
MESSAGESUBMITQUESTREQUEST.nested_types = {}
MESSAGESUBMITQUESTREQUEST.enum_types = {}
MESSAGESUBMITQUESTREQUEST.fields = {MESSAGESUBMITQUESTREQUEST_ID_FIELD, MESSAGESUBMITQUESTREQUEST_QUESTID_FIELD}
MESSAGESUBMITQUESTREQUEST.is_extendable = false
MESSAGESUBMITQUESTREQUEST.extensions = {}
MESSAGESUBMITQUESTRESPONSE_ID_FIELD.name = "id"
MESSAGESUBMITQUESTRESPONSE_ID_FIELD.full_name = ".Cmd.MessageSubmitQuestResponse.id"
MESSAGESUBMITQUESTRESPONSE_ID_FIELD.number = 1
MESSAGESUBMITQUESTRESPONSE_ID_FIELD.index = 0
MESSAGESUBMITQUESTRESPONSE_ID_FIELD.label = 1
MESSAGESUBMITQUESTRESPONSE_ID_FIELD.has_default_value = true
MESSAGESUBMITQUESTRESPONSE_ID_FIELD.default_value = SUBMIT_QUEST_S
MESSAGESUBMITQUESTRESPONSE_ID_FIELD.enum_type = basetype_pb.EPROTOID
MESSAGESUBMITQUESTRESPONSE_ID_FIELD.type = 14
MESSAGESUBMITQUESTRESPONSE_ID_FIELD.cpp_type = 8

MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD.name = "questid"
MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD.full_name = ".Cmd.MessageSubmitQuestResponse.questid"
MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD.number = 2
MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD.index = 1
MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD.label = 2
MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD.has_default_value = false
MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD.default_value = 0
MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD.type = 13
MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD.cpp_type = 3

MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD.name = "resource"
MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD.full_name = ".Cmd.MessageSubmitQuestResponse.resource"
MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD.number = 3
MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD.index = 2
MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD.label = 3
MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD.has_default_value = false
MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD.default_value = {}
MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD.message_type = questtype_pb.QUESTRESOURCEREWARD
MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD.type = 11
MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD.cpp_type = 10

MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD.name = "items"
MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD.full_name = ".Cmd.MessageSubmitQuestResponse.items"
MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD.number = 4
MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD.index = 3
MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD.label = 3
MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD.has_default_value = false
MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD.default_value = {}
MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD.message_type = questtype_pb.QUESTITEMREWARD
MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD.type = 11
MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD.cpp_type = 10

MESSAGESUBMITQUESTRESPONSE.name = "MessageSubmitQuestResponse"
MESSAGESUBMITQUESTRESPONSE.full_name = ".Cmd.MessageSubmitQuestResponse"
MESSAGESUBMITQUESTRESPONSE.nested_types = {}
MESSAGESUBMITQUESTRESPONSE.enum_types = {}
MESSAGESUBMITQUESTRESPONSE.fields = {MESSAGESUBMITQUESTRESPONSE_ID_FIELD, MESSAGESUBMITQUESTRESPONSE_QUESTID_FIELD, MESSAGESUBMITQUESTRESPONSE_RESOURCE_FIELD, MESSAGESUBMITQUESTRESPONSE_ITEMS_FIELD}
MESSAGESUBMITQUESTRESPONSE.is_extendable = false
MESSAGESUBMITQUESTRESPONSE.extensions = {}
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD.name = "id"
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD.full_name = ".Cmd.MessageQuestProgressNotice.id"
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD.number = 1
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD.index = 0
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD.label = 1
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD.has_default_value = true
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD.default_value = QUEST_PROGRESS_S
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD.enum_type = basetype_pb.EPROTOID
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD.type = 14
MESSAGEQUESTPROGRESSNOTICE_ID_FIELD.cpp_type = 8

MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD.name = "progress"
MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD.full_name = ".Cmd.MessageQuestProgressNotice.progress"
MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD.number = 2
MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD.index = 1
MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD.label = 1
MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD.has_default_value = false
MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD.default_value = nil
MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD.message_type = questtype_pb.QUESTINFOBASE
MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD.type = 11
MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD.cpp_type = 10

MESSAGEQUESTPROGRESSNOTICE.name = "MessageQuestProgressNotice"
MESSAGEQUESTPROGRESSNOTICE.full_name = ".Cmd.MessageQuestProgressNotice"
MESSAGEQUESTPROGRESSNOTICE.nested_types = {}
MESSAGEQUESTPROGRESSNOTICE.enum_types = {}
MESSAGEQUESTPROGRESSNOTICE.fields = {MESSAGEQUESTPROGRESSNOTICE_ID_FIELD, MESSAGEQUESTPROGRESSNOTICE_PROGRESS_FIELD}
MESSAGEQUESTPROGRESSNOTICE.is_extendable = false
MESSAGEQUESTPROGRESSNOTICE.extensions = {}

MessageAcceptQuestRequest = protobuf.Message(MESSAGEACCEPTQUESTREQUEST)
MessageAcceptQuestResponse = protobuf.Message(MESSAGEACCEPTQUESTRESPONSE)
MessageDailyQuestList = protobuf.Message(MESSAGEDAILYQUESTLIST)
MessageGetDailyQuestList = protobuf.Message(MESSAGEGETDAILYQUESTLIST)
MessageGetQuestList = protobuf.Message(MESSAGEGETQUESTLIST)
MessageQuestList = protobuf.Message(MESSAGEQUESTLIST)
MessageQuestProgressNotice = protobuf.Message(MESSAGEQUESTPROGRESSNOTICE)
MessageSubmitQuestRequest = protobuf.Message(MESSAGESUBMITQUESTREQUEST)
MessageSubmitQuestResponse = protobuf.Message(MESSAGESUBMITQUESTRESPONSE)

