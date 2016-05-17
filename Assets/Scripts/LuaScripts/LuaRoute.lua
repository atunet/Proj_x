
require ("Proto.basetype_pb")
local BaseTypePb = _G['Protol/basetype_pb']

require ("Login.LoginSvr")
require ("Role.Role")
require ("Error.Error")

module(..., package.seeall)

controllers = 
{
	[BaseTypePb.LOGIN_LOGIN_RET] 	= 	Login.LoginSvr.ParseLoginRet,
	[BaseTypePb.LOGIN_GATEW_RET] 	= 	Login.LoginSvr.ParseLoginGateRet,
	[BaseTypePb.SEND_ROLE_LIST] 		= 	Role.Role.ParseRoleList,
	[BaseTypePb.CREATE_ROLE_RET]	=	Role.Role.ParseCreateRoleRet,
	[BaseTypePb.ERROR_CODE_S]		= 	Error.Error.ParseError,
}
