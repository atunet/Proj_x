--Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
local basetype_pb = require("basetype_pb")
local utilstype_pb = require("utilstype_pb")
module('Protol.utils_pb')

SERVERTIMEREQ = protobuf.Descriptor();
SERVERTIMEREQ_ID_FIELD = protobuf.FieldDescriptor();
SERVERTIMERET = protobuf.Descriptor();
SERVERTIMERET_ID_FIELD = protobuf.FieldDescriptor();
SERVERTIMERET_SERVERTIME_FIELD = protobuf.FieldDescriptor();
UTILSECHO = protobuf.Descriptor();
UTILSECHO_ID_FIELD = protobuf.FieldDescriptor();

SERVERTIMEREQ_ID_FIELD.name = "id"
SERVERTIMEREQ_ID_FIELD.full_name = ".Cmd.ServerTimeReq.id"
SERVERTIMEREQ_ID_FIELD.number = 1
SERVERTIMEREQ_ID_FIELD.index = 0
SERVERTIMEREQ_ID_FIELD.label = 1
SERVERTIMEREQ_ID_FIELD.has_default_value = true
SERVERTIMEREQ_ID_FIELD.default_value = SERVER_TIME_REQ
SERVERTIMEREQ_ID_FIELD.enum_type = basetype_pb.EPROTOID
SERVERTIMEREQ_ID_FIELD.type = 14
SERVERTIMEREQ_ID_FIELD.cpp_type = 8

SERVERTIMEREQ.name = "ServerTimeReq"
SERVERTIMEREQ.full_name = ".Cmd.ServerTimeReq"
SERVERTIMEREQ.nested_types = {}
SERVERTIMEREQ.enum_types = {}
SERVERTIMEREQ.fields = {SERVERTIMEREQ_ID_FIELD}
SERVERTIMEREQ.is_extendable = false
SERVERTIMEREQ.extensions = {}
SERVERTIMERET_ID_FIELD.name = "id"
SERVERTIMERET_ID_FIELD.full_name = ".Cmd.ServerTimeRet.id"
SERVERTIMERET_ID_FIELD.number = 1
SERVERTIMERET_ID_FIELD.index = 0
SERVERTIMERET_ID_FIELD.label = 1
SERVERTIMERET_ID_FIELD.has_default_value = true
SERVERTIMERET_ID_FIELD.default_value = SERVER_TIME_RET
SERVERTIMERET_ID_FIELD.enum_type = basetype_pb.EPROTOID
SERVERTIMERET_ID_FIELD.type = 14
SERVERTIMERET_ID_FIELD.cpp_type = 8

SERVERTIMERET_SERVERTIME_FIELD.name = "servertime"
SERVERTIMERET_SERVERTIME_FIELD.full_name = ".Cmd.ServerTimeRet.servertime"
SERVERTIMERET_SERVERTIME_FIELD.number = 2
SERVERTIMERET_SERVERTIME_FIELD.index = 1
SERVERTIMERET_SERVERTIME_FIELD.label = 2
SERVERTIMERET_SERVERTIME_FIELD.has_default_value = false
SERVERTIMERET_SERVERTIME_FIELD.default_value = 0
SERVERTIMERET_SERVERTIME_FIELD.type = 13
SERVERTIMERET_SERVERTIME_FIELD.cpp_type = 3

SERVERTIMERET.name = "ServerTimeRet"
SERVERTIMERET.full_name = ".Cmd.ServerTimeRet"
SERVERTIMERET.nested_types = {}
SERVERTIMERET.enum_types = {}
SERVERTIMERET.fields = {SERVERTIMERET_ID_FIELD, SERVERTIMERET_SERVERTIME_FIELD}
SERVERTIMERET.is_extendable = false
SERVERTIMERET.extensions = {}
UTILSECHO_ID_FIELD.name = "id"
UTILSECHO_ID_FIELD.full_name = ".Cmd.UtilsEcho.id"
UTILSECHO_ID_FIELD.number = 1
UTILSECHO_ID_FIELD.index = 0
UTILSECHO_ID_FIELD.label = 1
UTILSECHO_ID_FIELD.has_default_value = true
UTILSECHO_ID_FIELD.default_value = UTILS_ECHO
UTILSECHO_ID_FIELD.enum_type = basetype_pb.EPROTOID
UTILSECHO_ID_FIELD.type = 14
UTILSECHO_ID_FIELD.cpp_type = 8

UTILSECHO.name = "UtilsEcho"
UTILSECHO.full_name = ".Cmd.UtilsEcho"
UTILSECHO.nested_types = {}
UTILSECHO.enum_types = {}
UTILSECHO.fields = {UTILSECHO_ID_FIELD}
UTILSECHO.is_extendable = false
UTILSECHO.extensions = {}

ServerTimeReq = protobuf.Message(SERVERTIMEREQ)
ServerTimeRet = protobuf.Message(SERVERTIMERET)
UtilsEcho = protobuf.Message(UTILSECHO)

