--Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
module('Protol.prototype_pb')

EMESSAGEID = protobuf.EnumDescriptor();
EMESSAGEID_TICK_CMD_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_TICK_CLIENT_CMD_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_ERROR_CMD_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_ERROR_CODE_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_LOGIN_CMD_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_VERIFY_VERSION_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_LOGIN_LOGIN_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_LOGIN_LOGIN_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_LOGIN_GATEW_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_LOGIN_GATEW_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_LOGIN_CROSS_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_LOGIN_CROSS_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_USER_CMD_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_USER_LIST_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_CREATE_USER_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_CREATE_USER_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_USER_ONLINE_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_USER_OFFLINE_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_USER_BASE_DATA_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_DATA_LOAD_OK_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_MODULE_DATA_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_MARQUEE_INFO_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_ITEM_CMD_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_ITEM_LIST_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_UPDATE_ITEM_LIST_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_REMOVE_ITEM_LIST_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_SELL_ITEM_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_SELL_ITEM_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_USE_ITEM_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_USE_ITEM_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_HERO_CMD_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_HERO_LIST_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_UPDATE_HERO_LIST_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_REMOVE_HERO_LIST_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_HERO_LEVEL_UP_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_HERO_LEVEL_UP_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_HERO_QUALITY_UP_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_HERO_QUALITY_UP_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_HERO_STAR_UP_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_HERO_STAR_UP_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_CHAT_CMD_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_CHAT_PRIVATE_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_CHAT_PRIVATE_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_CHAT_WORLD_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_CHAT_WORLD_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_CHAT_UNION_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_CHAT_UNION_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_UTILS_CMD_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_SERVER_TIME_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_SERVER_TIME_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_UTILS_ECHO_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_PVP_FRAME_DATA_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_PVP_FRAME_ACTION_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_PVP_KEY_ACTION_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_PVP_KEY_ACTION_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_PVP_UNIT_INFO_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_PVP_RESULT_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_PVP_CMD_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_PVP_MATCH_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_PVP_MATCH_SC_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_PVP_MATCH_CANCEL_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_BATTLE_INFO_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_BATTLE_CLIENT_READY_CS_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_BATTLE_ALL_READY_S_ENUM = protobuf.EnumValueDescriptor();
EMESSAGEID_BATTLE_COUNTDOWN_S_ENUM = protobuf.EnumValueDescriptor();

EMESSAGEID_TICK_CMD_ENUM.name = "TICK_CMD"
EMESSAGEID_TICK_CMD_ENUM.index = 0
EMESSAGEID_TICK_CMD_ENUM.number = 0
EMESSAGEID_TICK_CLIENT_CMD_ENUM.name = "TICK_CLIENT_CMD"
EMESSAGEID_TICK_CLIENT_CMD_ENUM.index = 1
EMESSAGEID_TICK_CLIENT_CMD_ENUM.number = 1
EMESSAGEID_ERROR_CMD_ENUM.name = "ERROR_CMD"
EMESSAGEID_ERROR_CMD_ENUM.index = 2
EMESSAGEID_ERROR_CMD_ENUM.number = 65280
EMESSAGEID_ERROR_CODE_S_ENUM.name = "ERROR_CODE_S"
EMESSAGEID_ERROR_CODE_S_ENUM.index = 3
EMESSAGEID_ERROR_CODE_S_ENUM.number = 65281
EMESSAGEID_LOGIN_CMD_ENUM.name = "LOGIN_CMD"
EMESSAGEID_LOGIN_CMD_ENUM.index = 4
EMESSAGEID_LOGIN_CMD_ENUM.number = 256
EMESSAGEID_VERIFY_VERSION_CS_ENUM.name = "VERIFY_VERSION_CS"
EMESSAGEID_VERIFY_VERSION_CS_ENUM.index = 5
EMESSAGEID_VERIFY_VERSION_CS_ENUM.number = 257
EMESSAGEID_LOGIN_LOGIN_CS_ENUM.name = "LOGIN_LOGIN_CS"
EMESSAGEID_LOGIN_LOGIN_CS_ENUM.index = 6
EMESSAGEID_LOGIN_LOGIN_CS_ENUM.number = 258
EMESSAGEID_LOGIN_LOGIN_SC_ENUM.name = "LOGIN_LOGIN_SC"
EMESSAGEID_LOGIN_LOGIN_SC_ENUM.index = 7
EMESSAGEID_LOGIN_LOGIN_SC_ENUM.number = 259
EMESSAGEID_LOGIN_GATEW_CS_ENUM.name = "LOGIN_GATEW_CS"
EMESSAGEID_LOGIN_GATEW_CS_ENUM.index = 8
EMESSAGEID_LOGIN_GATEW_CS_ENUM.number = 260
EMESSAGEID_LOGIN_GATEW_SC_ENUM.name = "LOGIN_GATEW_SC"
EMESSAGEID_LOGIN_GATEW_SC_ENUM.index = 9
EMESSAGEID_LOGIN_GATEW_SC_ENUM.number = 261
EMESSAGEID_LOGIN_CROSS_CS_ENUM.name = "LOGIN_CROSS_CS"
EMESSAGEID_LOGIN_CROSS_CS_ENUM.index = 10
EMESSAGEID_LOGIN_CROSS_CS_ENUM.number = 267
EMESSAGEID_LOGIN_CROSS_SC_ENUM.name = "LOGIN_CROSS_SC"
EMESSAGEID_LOGIN_CROSS_SC_ENUM.index = 11
EMESSAGEID_LOGIN_CROSS_SC_ENUM.number = 268
EMESSAGEID_USER_CMD_ENUM.name = "USER_CMD"
EMESSAGEID_USER_CMD_ENUM.index = 12
EMESSAGEID_USER_CMD_ENUM.number = 512
EMESSAGEID_USER_LIST_S_ENUM.name = "USER_LIST_S"
EMESSAGEID_USER_LIST_S_ENUM.index = 13
EMESSAGEID_USER_LIST_S_ENUM.number = 513
EMESSAGEID_CREATE_USER_CS_ENUM.name = "CREATE_USER_CS"
EMESSAGEID_CREATE_USER_CS_ENUM.index = 14
EMESSAGEID_CREATE_USER_CS_ENUM.number = 515
EMESSAGEID_CREATE_USER_SC_ENUM.name = "CREATE_USER_SC"
EMESSAGEID_CREATE_USER_SC_ENUM.index = 15
EMESSAGEID_CREATE_USER_SC_ENUM.number = 516
EMESSAGEID_USER_ONLINE_CS_ENUM.name = "USER_ONLINE_CS"
EMESSAGEID_USER_ONLINE_CS_ENUM.index = 16
EMESSAGEID_USER_ONLINE_CS_ENUM.number = 514
EMESSAGEID_USER_OFFLINE_CS_ENUM.name = "USER_OFFLINE_CS"
EMESSAGEID_USER_OFFLINE_CS_ENUM.index = 17
EMESSAGEID_USER_OFFLINE_CS_ENUM.number = 534
EMESSAGEID_USER_BASE_DATA_SC_ENUM.name = "USER_BASE_DATA_SC"
EMESSAGEID_USER_BASE_DATA_SC_ENUM.index = 18
EMESSAGEID_USER_BASE_DATA_SC_ENUM.number = 517
EMESSAGEID_DATA_LOAD_OK_S_ENUM.name = "DATA_LOAD_OK_S"
EMESSAGEID_DATA_LOAD_OK_S_ENUM.index = 19
EMESSAGEID_DATA_LOAD_OK_S_ENUM.number = 547
EMESSAGEID_MODULE_DATA_CS_ENUM.name = "MODULE_DATA_CS"
EMESSAGEID_MODULE_DATA_CS_ENUM.index = 20
EMESSAGEID_MODULE_DATA_CS_ENUM.number = 635
EMESSAGEID_MARQUEE_INFO_S_ENUM.name = "MARQUEE_INFO_S"
EMESSAGEID_MARQUEE_INFO_S_ENUM.index = 21
EMESSAGEID_MARQUEE_INFO_S_ENUM.number = 548
EMESSAGEID_ITEM_CMD_ENUM.name = "ITEM_CMD"
EMESSAGEID_ITEM_CMD_ENUM.index = 22
EMESSAGEID_ITEM_CMD_ENUM.number = 768
EMESSAGEID_ITEM_LIST_S_ENUM.name = "ITEM_LIST_S"
EMESSAGEID_ITEM_LIST_S_ENUM.index = 23
EMESSAGEID_ITEM_LIST_S_ENUM.number = 769
EMESSAGEID_UPDATE_ITEM_LIST_S_ENUM.name = "UPDATE_ITEM_LIST_S"
EMESSAGEID_UPDATE_ITEM_LIST_S_ENUM.index = 24
EMESSAGEID_UPDATE_ITEM_LIST_S_ENUM.number = 770
EMESSAGEID_REMOVE_ITEM_LIST_S_ENUM.name = "REMOVE_ITEM_LIST_S"
EMESSAGEID_REMOVE_ITEM_LIST_S_ENUM.index = 25
EMESSAGEID_REMOVE_ITEM_LIST_S_ENUM.number = 771
EMESSAGEID_SELL_ITEM_CS_ENUM.name = "SELL_ITEM_CS"
EMESSAGEID_SELL_ITEM_CS_ENUM.index = 26
EMESSAGEID_SELL_ITEM_CS_ENUM.number = 772
EMESSAGEID_SELL_ITEM_SC_ENUM.name = "SELL_ITEM_SC"
EMESSAGEID_SELL_ITEM_SC_ENUM.index = 27
EMESSAGEID_SELL_ITEM_SC_ENUM.number = 773
EMESSAGEID_USE_ITEM_CS_ENUM.name = "USE_ITEM_CS"
EMESSAGEID_USE_ITEM_CS_ENUM.index = 28
EMESSAGEID_USE_ITEM_CS_ENUM.number = 774
EMESSAGEID_USE_ITEM_SC_ENUM.name = "USE_ITEM_SC"
EMESSAGEID_USE_ITEM_SC_ENUM.index = 29
EMESSAGEID_USE_ITEM_SC_ENUM.number = 775
EMESSAGEID_HERO_CMD_ENUM.name = "HERO_CMD"
EMESSAGEID_HERO_CMD_ENUM.index = 30
EMESSAGEID_HERO_CMD_ENUM.number = 1024
EMESSAGEID_HERO_LIST_S_ENUM.name = "HERO_LIST_S"
EMESSAGEID_HERO_LIST_S_ENUM.index = 31
EMESSAGEID_HERO_LIST_S_ENUM.number = 1025
EMESSAGEID_UPDATE_HERO_LIST_S_ENUM.name = "UPDATE_HERO_LIST_S"
EMESSAGEID_UPDATE_HERO_LIST_S_ENUM.index = 32
EMESSAGEID_UPDATE_HERO_LIST_S_ENUM.number = 1026
EMESSAGEID_REMOVE_HERO_LIST_S_ENUM.name = "REMOVE_HERO_LIST_S"
EMESSAGEID_REMOVE_HERO_LIST_S_ENUM.index = 33
EMESSAGEID_REMOVE_HERO_LIST_S_ENUM.number = 1027
EMESSAGEID_HERO_LEVEL_UP_CS_ENUM.name = "HERO_LEVEL_UP_CS"
EMESSAGEID_HERO_LEVEL_UP_CS_ENUM.index = 34
EMESSAGEID_HERO_LEVEL_UP_CS_ENUM.number = 1028
EMESSAGEID_HERO_LEVEL_UP_SC_ENUM.name = "HERO_LEVEL_UP_SC"
EMESSAGEID_HERO_LEVEL_UP_SC_ENUM.index = 35
EMESSAGEID_HERO_LEVEL_UP_SC_ENUM.number = 1029
EMESSAGEID_HERO_QUALITY_UP_CS_ENUM.name = "HERO_QUALITY_UP_CS"
EMESSAGEID_HERO_QUALITY_UP_CS_ENUM.index = 36
EMESSAGEID_HERO_QUALITY_UP_CS_ENUM.number = 1030
EMESSAGEID_HERO_QUALITY_UP_SC_ENUM.name = "HERO_QUALITY_UP_SC"
EMESSAGEID_HERO_QUALITY_UP_SC_ENUM.index = 37
EMESSAGEID_HERO_QUALITY_UP_SC_ENUM.number = 1031
EMESSAGEID_HERO_STAR_UP_CS_ENUM.name = "HERO_STAR_UP_CS"
EMESSAGEID_HERO_STAR_UP_CS_ENUM.index = 38
EMESSAGEID_HERO_STAR_UP_CS_ENUM.number = 1032
EMESSAGEID_HERO_STAR_UP_SC_ENUM.name = "HERO_STAR_UP_SC"
EMESSAGEID_HERO_STAR_UP_SC_ENUM.index = 39
EMESSAGEID_HERO_STAR_UP_SC_ENUM.number = 1033
EMESSAGEID_CHAT_CMD_ENUM.name = "CHAT_CMD"
EMESSAGEID_CHAT_CMD_ENUM.index = 40
EMESSAGEID_CHAT_CMD_ENUM.number = 4352
EMESSAGEID_CHAT_PRIVATE_CS_ENUM.name = "CHAT_PRIVATE_CS"
EMESSAGEID_CHAT_PRIVATE_CS_ENUM.index = 41
EMESSAGEID_CHAT_PRIVATE_CS_ENUM.number = 4353
EMESSAGEID_CHAT_PRIVATE_SC_ENUM.name = "CHAT_PRIVATE_SC"
EMESSAGEID_CHAT_PRIVATE_SC_ENUM.index = 42
EMESSAGEID_CHAT_PRIVATE_SC_ENUM.number = 4354
EMESSAGEID_CHAT_WORLD_CS_ENUM.name = "CHAT_WORLD_CS"
EMESSAGEID_CHAT_WORLD_CS_ENUM.index = 43
EMESSAGEID_CHAT_WORLD_CS_ENUM.number = 4355
EMESSAGEID_CHAT_WORLD_SC_ENUM.name = "CHAT_WORLD_SC"
EMESSAGEID_CHAT_WORLD_SC_ENUM.index = 44
EMESSAGEID_CHAT_WORLD_SC_ENUM.number = 4356
EMESSAGEID_CHAT_UNION_CS_ENUM.name = "CHAT_UNION_CS"
EMESSAGEID_CHAT_UNION_CS_ENUM.index = 45
EMESSAGEID_CHAT_UNION_CS_ENUM.number = 4358
EMESSAGEID_CHAT_UNION_SC_ENUM.name = "CHAT_UNION_SC"
EMESSAGEID_CHAT_UNION_SC_ENUM.index = 46
EMESSAGEID_CHAT_UNION_SC_ENUM.number = 4359
EMESSAGEID_UTILS_CMD_ENUM.name = "UTILS_CMD"
EMESSAGEID_UTILS_CMD_ENUM.index = 47
EMESSAGEID_UTILS_CMD_ENUM.number = 2304
EMESSAGEID_SERVER_TIME_CS_ENUM.name = "SERVER_TIME_CS"
EMESSAGEID_SERVER_TIME_CS_ENUM.index = 48
EMESSAGEID_SERVER_TIME_CS_ENUM.number = 2305
EMESSAGEID_SERVER_TIME_SC_ENUM.name = "SERVER_TIME_SC"
EMESSAGEID_SERVER_TIME_SC_ENUM.index = 49
EMESSAGEID_SERVER_TIME_SC_ENUM.number = 2306
EMESSAGEID_UTILS_ECHO_ENUM.name = "UTILS_ECHO"
EMESSAGEID_UTILS_ECHO_ENUM.index = 50
EMESSAGEID_UTILS_ECHO_ENUM.number = 2307
EMESSAGEID_PVP_FRAME_DATA_CS_ENUM.name = "PVP_FRAME_DATA_CS"
EMESSAGEID_PVP_FRAME_DATA_CS_ENUM.index = 51
EMESSAGEID_PVP_FRAME_DATA_CS_ENUM.number = 4148
EMESSAGEID_PVP_FRAME_ACTION_S_ENUM.name = "PVP_FRAME_ACTION_S"
EMESSAGEID_PVP_FRAME_ACTION_S_ENUM.index = 52
EMESSAGEID_PVP_FRAME_ACTION_S_ENUM.number = 4149
EMESSAGEID_PVP_KEY_ACTION_CS_ENUM.name = "PVP_KEY_ACTION_CS"
EMESSAGEID_PVP_KEY_ACTION_CS_ENUM.index = 53
EMESSAGEID_PVP_KEY_ACTION_CS_ENUM.number = 4145
EMESSAGEID_PVP_KEY_ACTION_SC_ENUM.name = "PVP_KEY_ACTION_SC"
EMESSAGEID_PVP_KEY_ACTION_SC_ENUM.index = 54
EMESSAGEID_PVP_KEY_ACTION_SC_ENUM.number = 4147
EMESSAGEID_PVP_UNIT_INFO_S_ENUM.name = "PVP_UNIT_INFO_S"
EMESSAGEID_PVP_UNIT_INFO_S_ENUM.index = 55
EMESSAGEID_PVP_UNIT_INFO_S_ENUM.number = 4146
EMESSAGEID_PVP_RESULT_S_ENUM.name = "PVP_RESULT_S"
EMESSAGEID_PVP_RESULT_S_ENUM.index = 56
EMESSAGEID_PVP_RESULT_S_ENUM.number = 4150
EMESSAGEID_PVP_CMD_ENUM.name = "PVP_CMD"
EMESSAGEID_PVP_CMD_ENUM.index = 57
EMESSAGEID_PVP_CMD_ENUM.number = 7168
EMESSAGEID_PVP_MATCH_CS_ENUM.name = "PVP_MATCH_CS"
EMESSAGEID_PVP_MATCH_CS_ENUM.index = 58
EMESSAGEID_PVP_MATCH_CS_ENUM.number = 7169
EMESSAGEID_PVP_MATCH_SC_ENUM.name = "PVP_MATCH_SC"
EMESSAGEID_PVP_MATCH_SC_ENUM.index = 59
EMESSAGEID_PVP_MATCH_SC_ENUM.number = 7171
EMESSAGEID_PVP_MATCH_CANCEL_CS_ENUM.name = "PVP_MATCH_CANCEL_CS"
EMESSAGEID_PVP_MATCH_CANCEL_CS_ENUM.index = 60
EMESSAGEID_PVP_MATCH_CANCEL_CS_ENUM.number = 7170
EMESSAGEID_BATTLE_INFO_S_ENUM.name = "BATTLE_INFO_S"
EMESSAGEID_BATTLE_INFO_S_ENUM.index = 61
EMESSAGEID_BATTLE_INFO_S_ENUM.number = 7172
EMESSAGEID_BATTLE_CLIENT_READY_CS_ENUM.name = "BATTLE_CLIENT_READY_CS"
EMESSAGEID_BATTLE_CLIENT_READY_CS_ENUM.index = 62
EMESSAGEID_BATTLE_CLIENT_READY_CS_ENUM.number = 7173
EMESSAGEID_BATTLE_ALL_READY_S_ENUM.name = "BATTLE_ALL_READY_S"
EMESSAGEID_BATTLE_ALL_READY_S_ENUM.index = 63
EMESSAGEID_BATTLE_ALL_READY_S_ENUM.number = 7174
EMESSAGEID_BATTLE_COUNTDOWN_S_ENUM.name = "BATTLE_COUNTDOWN_S"
EMESSAGEID_BATTLE_COUNTDOWN_S_ENUM.index = 64
EMESSAGEID_BATTLE_COUNTDOWN_S_ENUM.number = 7175
EMESSAGEID.name = "EMessageID"
EMESSAGEID.full_name = ".Cmd.EMessageID"
EMESSAGEID.values = {EMESSAGEID_TICK_CMD_ENUM,EMESSAGEID_TICK_CLIENT_CMD_ENUM,EMESSAGEID_ERROR_CMD_ENUM,EMESSAGEID_ERROR_CODE_S_ENUM,EMESSAGEID_LOGIN_CMD_ENUM,EMESSAGEID_VERIFY_VERSION_CS_ENUM,EMESSAGEID_LOGIN_LOGIN_CS_ENUM,EMESSAGEID_LOGIN_LOGIN_SC_ENUM,EMESSAGEID_LOGIN_GATEW_CS_ENUM,EMESSAGEID_LOGIN_GATEW_SC_ENUM,EMESSAGEID_LOGIN_CROSS_CS_ENUM,EMESSAGEID_LOGIN_CROSS_SC_ENUM,EMESSAGEID_USER_CMD_ENUM,EMESSAGEID_USER_LIST_S_ENUM,EMESSAGEID_CREATE_USER_CS_ENUM,EMESSAGEID_CREATE_USER_SC_ENUM,EMESSAGEID_USER_ONLINE_CS_ENUM,EMESSAGEID_USER_OFFLINE_CS_ENUM,EMESSAGEID_USER_BASE_DATA_SC_ENUM,EMESSAGEID_DATA_LOAD_OK_S_ENUM,EMESSAGEID_MODULE_DATA_CS_ENUM,EMESSAGEID_MARQUEE_INFO_S_ENUM,EMESSAGEID_ITEM_CMD_ENUM,EMESSAGEID_ITEM_LIST_S_ENUM,EMESSAGEID_UPDATE_ITEM_LIST_S_ENUM,EMESSAGEID_REMOVE_ITEM_LIST_S_ENUM,EMESSAGEID_SELL_ITEM_CS_ENUM,EMESSAGEID_SELL_ITEM_SC_ENUM,EMESSAGEID_USE_ITEM_CS_ENUM,EMESSAGEID_USE_ITEM_SC_ENUM,EMESSAGEID_HERO_CMD_ENUM,EMESSAGEID_HERO_LIST_S_ENUM,EMESSAGEID_UPDATE_HERO_LIST_S_ENUM,EMESSAGEID_REMOVE_HERO_LIST_S_ENUM,EMESSAGEID_HERO_LEVEL_UP_CS_ENUM,EMESSAGEID_HERO_LEVEL_UP_SC_ENUM,EMESSAGEID_HERO_QUALITY_UP_CS_ENUM,EMESSAGEID_HERO_QUALITY_UP_SC_ENUM,EMESSAGEID_HERO_STAR_UP_CS_ENUM,EMESSAGEID_HERO_STAR_UP_SC_ENUM,EMESSAGEID_CHAT_CMD_ENUM,EMESSAGEID_CHAT_PRIVATE_CS_ENUM,EMESSAGEID_CHAT_PRIVATE_SC_ENUM,EMESSAGEID_CHAT_WORLD_CS_ENUM,EMESSAGEID_CHAT_WORLD_SC_ENUM,EMESSAGEID_CHAT_UNION_CS_ENUM,EMESSAGEID_CHAT_UNION_SC_ENUM,EMESSAGEID_UTILS_CMD_ENUM,EMESSAGEID_SERVER_TIME_CS_ENUM,EMESSAGEID_SERVER_TIME_SC_ENUM,EMESSAGEID_UTILS_ECHO_ENUM,EMESSAGEID_PVP_FRAME_DATA_CS_ENUM,EMESSAGEID_PVP_FRAME_ACTION_S_ENUM,EMESSAGEID_PVP_KEY_ACTION_CS_ENUM,EMESSAGEID_PVP_KEY_ACTION_SC_ENUM,EMESSAGEID_PVP_UNIT_INFO_S_ENUM,EMESSAGEID_PVP_RESULT_S_ENUM,EMESSAGEID_PVP_CMD_ENUM,EMESSAGEID_PVP_MATCH_CS_ENUM,EMESSAGEID_PVP_MATCH_SC_ENUM,EMESSAGEID_PVP_MATCH_CANCEL_CS_ENUM,EMESSAGEID_BATTLE_INFO_S_ENUM,EMESSAGEID_BATTLE_CLIENT_READY_CS_ENUM,EMESSAGEID_BATTLE_ALL_READY_S_ENUM,EMESSAGEID_BATTLE_COUNTDOWN_S_ENUM}

BATTLE_ALL_READY_S = 7174
BATTLE_CLIENT_READY_CS = 7173
BATTLE_COUNTDOWN_S = 7175
BATTLE_INFO_S = 7172
CHAT_CMD = 4352
CHAT_PRIVATE_CS = 4353
CHAT_PRIVATE_SC = 4354
CHAT_UNION_CS = 4358
CHAT_UNION_SC = 4359
CHAT_WORLD_CS = 4355
CHAT_WORLD_SC = 4356
CREATE_USER_CS = 515
CREATE_USER_SC = 516
DATA_LOAD_OK_S = 547
ERROR_CMD = 65280
ERROR_CODE_S = 65281
HERO_CMD = 1024
HERO_LEVEL_UP_CS = 1028
HERO_LEVEL_UP_SC = 1029
HERO_LIST_S = 1025
HERO_QUALITY_UP_CS = 1030
HERO_QUALITY_UP_SC = 1031
HERO_STAR_UP_CS = 1032
HERO_STAR_UP_SC = 1033
ITEM_CMD = 768
ITEM_LIST_S = 769
LOGIN_CMD = 256
LOGIN_CROSS_CS = 267
LOGIN_CROSS_SC = 268
LOGIN_GATEW_CS = 260
LOGIN_GATEW_SC = 261
LOGIN_LOGIN_CS = 258
LOGIN_LOGIN_SC = 259
MARQUEE_INFO_S = 548
MODULE_DATA_CS = 635
PVP_CMD = 7168
PVP_FRAME_ACTION_S = 4149
PVP_FRAME_DATA_CS = 4148
PVP_KEY_ACTION_CS = 4145
PVP_KEY_ACTION_SC = 4147
PVP_MATCH_CANCEL_CS = 7170
PVP_MATCH_CS = 7169
PVP_MATCH_SC = 7171
PVP_RESULT_S = 4150
PVP_UNIT_INFO_S = 4146
REMOVE_HERO_LIST_S = 1027
REMOVE_ITEM_LIST_S = 771
SELL_ITEM_CS = 772
SELL_ITEM_SC = 773
SERVER_TIME_CS = 2305
SERVER_TIME_SC = 2306
TICK_CLIENT_CMD = 1
TICK_CMD = 0
UPDATE_HERO_LIST_S = 1026
UPDATE_ITEM_LIST_S = 770
USER_BASE_DATA_SC = 517
USER_CMD = 512
USER_LIST_S = 513
USER_OFFLINE_CS = 534
USER_ONLINE_CS = 514
USE_ITEM_CS = 774
USE_ITEM_SC = 775
UTILS_CMD = 2304
UTILS_ECHO = 2307
VERIFY_VERSION_CS = 257

