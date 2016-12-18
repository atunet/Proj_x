
require ("Protol.prototype_pb")
local ProtoTypePb = Protol.prototype_pb --_G['Protol.prototype_pb']

require ("Login.LoginSvr")
require ("Role.Role")
require ("Error.Error")

module(..., package.seeall)

controllers = 
{
	[ProtoTypePb.LOGIN_LOGIN_SC] 		= 	Login.LoginSvr.ParseLoginRet,
	[ProtoTypePb.LOGIN_GATEW_SC] 		= 	Login.LoginSvr.ParseLoginGateRet,
	[ProtoTypePb.USER_LIST_S] 			= 	Role.Role.ParseRoleList,
	[ProtoTypePb.CREATE_USER_SC]		=	Role.Role.ParseCreateRoleRet,
	[ProtoTypePb.ERROR_CODE_S]			= 	Error.Error.ParseError,
	[ProtoTypePb.DATA_LOAD_OK_S]		=	Role.Role.ParseRoleDataLoadOk,
}
