
require ("Protol.prototype_pb")
local ProtoTypePb = Protol.prototype_pb --_G['Protol.prototype_pb']

require ("User.User")
require ("Error.Error")

module(..., package.seeall)

controllers = 
{
	[ProtoTypePb.ERROR_CODE_S]			= 	Error.Error.ParseError,
	[ProtoTypePb.USER_LIST_S] 			= 	User.User.ParseUserList,
	[ProtoTypePb.CREATE_USER_SC]		=	User.User.ParseCreateUserRet,
	[ProtoTypePb.USER_BASE_DATA_SC]		=	User.User.ParseUserBaseData,
	[ProtoTypePb.DATA_LOAD_OK_S]		=	User.User.ParseUserDataLoadOk,
}
