--Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
module('Protol.itemtype_pb')

ITEMINFO = protobuf.Descriptor();
ITEMINFO_THISID_FIELD = protobuf.FieldDescriptor();
ITEMINFO_ITEMID_FIELD = protobuf.FieldDescriptor();
ITEMINFO_CREATETIME_FIELD = protobuf.FieldDescriptor();
ITEMINFO_NUM_FIELD = protobuf.FieldDescriptor();
ITEMNOTITYPE = protobuf.Descriptor();
ITEMNOTITYPE_TYPE_FIELD = protobuf.FieldDescriptor();
ITEMNOTITYPE_ITEMID_FIELD = protobuf.FieldDescriptor();
ITEMNOTITYPE_COUNT_FIELD = protobuf.FieldDescriptor();
ITEMCOUNTTYPE = protobuf.Descriptor();
ITEMCOUNTTYPE_ITEMID_FIELD = protobuf.FieldDescriptor();
ITEMCOUNTTYPE_COUNT_FIELD = protobuf.FieldDescriptor();

ITEMINFO_THISID_FIELD.name = "thisid"
ITEMINFO_THISID_FIELD.full_name = ".Cmd.ItemInfo.thisid"
ITEMINFO_THISID_FIELD.number = 1
ITEMINFO_THISID_FIELD.index = 0
ITEMINFO_THISID_FIELD.label = 2
ITEMINFO_THISID_FIELD.has_default_value = false
ITEMINFO_THISID_FIELD.default_value = 0
ITEMINFO_THISID_FIELD.type = 4
ITEMINFO_THISID_FIELD.cpp_type = 4

ITEMINFO_ITEMID_FIELD.name = "itemid"
ITEMINFO_ITEMID_FIELD.full_name = ".Cmd.ItemInfo.itemid"
ITEMINFO_ITEMID_FIELD.number = 2
ITEMINFO_ITEMID_FIELD.index = 1
ITEMINFO_ITEMID_FIELD.label = 2
ITEMINFO_ITEMID_FIELD.has_default_value = false
ITEMINFO_ITEMID_FIELD.default_value = 0
ITEMINFO_ITEMID_FIELD.type = 13
ITEMINFO_ITEMID_FIELD.cpp_type = 3

ITEMINFO_CREATETIME_FIELD.name = "createtime"
ITEMINFO_CREATETIME_FIELD.full_name = ".Cmd.ItemInfo.createtime"
ITEMINFO_CREATETIME_FIELD.number = 3
ITEMINFO_CREATETIME_FIELD.index = 2
ITEMINFO_CREATETIME_FIELD.label = 2
ITEMINFO_CREATETIME_FIELD.has_default_value = false
ITEMINFO_CREATETIME_FIELD.default_value = 0
ITEMINFO_CREATETIME_FIELD.type = 13
ITEMINFO_CREATETIME_FIELD.cpp_type = 3

ITEMINFO_NUM_FIELD.name = "num"
ITEMINFO_NUM_FIELD.full_name = ".Cmd.ItemInfo.num"
ITEMINFO_NUM_FIELD.number = 4
ITEMINFO_NUM_FIELD.index = 3
ITEMINFO_NUM_FIELD.label = 2
ITEMINFO_NUM_FIELD.has_default_value = false
ITEMINFO_NUM_FIELD.default_value = 0
ITEMINFO_NUM_FIELD.type = 13
ITEMINFO_NUM_FIELD.cpp_type = 3

ITEMINFO.name = "ItemInfo"
ITEMINFO.full_name = ".Cmd.ItemInfo"
ITEMINFO.nested_types = {}
ITEMINFO.enum_types = {}
ITEMINFO.fields = {ITEMINFO_THISID_FIELD, ITEMINFO_ITEMID_FIELD, ITEMINFO_CREATETIME_FIELD, ITEMINFO_NUM_FIELD}
ITEMINFO.is_extendable = false
ITEMINFO.extensions = {}
ITEMNOTITYPE_TYPE_FIELD.name = "type"
ITEMNOTITYPE_TYPE_FIELD.full_name = ".Cmd.ItemNotiType.type"
ITEMNOTITYPE_TYPE_FIELD.number = 1
ITEMNOTITYPE_TYPE_FIELD.index = 0
ITEMNOTITYPE_TYPE_FIELD.label = 2
ITEMNOTITYPE_TYPE_FIELD.has_default_value = false
ITEMNOTITYPE_TYPE_FIELD.default_value = 0
ITEMNOTITYPE_TYPE_FIELD.type = 13
ITEMNOTITYPE_TYPE_FIELD.cpp_type = 3

ITEMNOTITYPE_ITEMID_FIELD.name = "itemid"
ITEMNOTITYPE_ITEMID_FIELD.full_name = ".Cmd.ItemNotiType.itemid"
ITEMNOTITYPE_ITEMID_FIELD.number = 2
ITEMNOTITYPE_ITEMID_FIELD.index = 1
ITEMNOTITYPE_ITEMID_FIELD.label = 2
ITEMNOTITYPE_ITEMID_FIELD.has_default_value = false
ITEMNOTITYPE_ITEMID_FIELD.default_value = 0
ITEMNOTITYPE_ITEMID_FIELD.type = 13
ITEMNOTITYPE_ITEMID_FIELD.cpp_type = 3

ITEMNOTITYPE_COUNT_FIELD.name = "count"
ITEMNOTITYPE_COUNT_FIELD.full_name = ".Cmd.ItemNotiType.count"
ITEMNOTITYPE_COUNT_FIELD.number = 3
ITEMNOTITYPE_COUNT_FIELD.index = 2
ITEMNOTITYPE_COUNT_FIELD.label = 2
ITEMNOTITYPE_COUNT_FIELD.has_default_value = false
ITEMNOTITYPE_COUNT_FIELD.default_value = 0
ITEMNOTITYPE_COUNT_FIELD.type = 13
ITEMNOTITYPE_COUNT_FIELD.cpp_type = 3

ITEMNOTITYPE.name = "ItemNotiType"
ITEMNOTITYPE.full_name = ".Cmd.ItemNotiType"
ITEMNOTITYPE.nested_types = {}
ITEMNOTITYPE.enum_types = {}
ITEMNOTITYPE.fields = {ITEMNOTITYPE_TYPE_FIELD, ITEMNOTITYPE_ITEMID_FIELD, ITEMNOTITYPE_COUNT_FIELD}
ITEMNOTITYPE.is_extendable = false
ITEMNOTITYPE.extensions = {}
ITEMCOUNTTYPE_ITEMID_FIELD.name = "itemid"
ITEMCOUNTTYPE_ITEMID_FIELD.full_name = ".Cmd.ItemCountType.itemid"
ITEMCOUNTTYPE_ITEMID_FIELD.number = 1
ITEMCOUNTTYPE_ITEMID_FIELD.index = 0
ITEMCOUNTTYPE_ITEMID_FIELD.label = 2
ITEMCOUNTTYPE_ITEMID_FIELD.has_default_value = false
ITEMCOUNTTYPE_ITEMID_FIELD.default_value = 0
ITEMCOUNTTYPE_ITEMID_FIELD.type = 13
ITEMCOUNTTYPE_ITEMID_FIELD.cpp_type = 3

ITEMCOUNTTYPE_COUNT_FIELD.name = "count"
ITEMCOUNTTYPE_COUNT_FIELD.full_name = ".Cmd.ItemCountType.count"
ITEMCOUNTTYPE_COUNT_FIELD.number = 2
ITEMCOUNTTYPE_COUNT_FIELD.index = 1
ITEMCOUNTTYPE_COUNT_FIELD.label = 2
ITEMCOUNTTYPE_COUNT_FIELD.has_default_value = false
ITEMCOUNTTYPE_COUNT_FIELD.default_value = 0
ITEMCOUNTTYPE_COUNT_FIELD.type = 13
ITEMCOUNTTYPE_COUNT_FIELD.cpp_type = 3

ITEMCOUNTTYPE.name = "ItemCountType"
ITEMCOUNTTYPE.full_name = ".Cmd.ItemCountType"
ITEMCOUNTTYPE.nested_types = {}
ITEMCOUNTTYPE.enum_types = {}
ITEMCOUNTTYPE.fields = {ITEMCOUNTTYPE_ITEMID_FIELD, ITEMCOUNTTYPE_COUNT_FIELD}
ITEMCOUNTTYPE.is_extendable = false
ITEMCOUNTTYPE.extensions = {}

ItemCountType = protobuf.Message(ITEMCOUNTTYPE)
ItemInfo = protobuf.Message(ITEMINFO)
ItemNotiType = protobuf.Message(ITEMNOTITYPE)

