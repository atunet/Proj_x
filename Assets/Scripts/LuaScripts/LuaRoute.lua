
require ("basetype_pb")
local BaseTypePb = _G['Protol/basetype_pb']

require ("Login.LoginSvr")
require ("Role.RoleBase")

module(..., package.seeall)

controllers = 
{
	[BaseTypePb.LOGIN_LOGIN_RET] 	= Login.LoginSvr.ParseLoginRet,
	[BaseTypePb.LOGIN_GATEW_RET] 	= Login.LoginSvr.ParseLoginGateRet,
	[BaseTypePb.SEND_ROLE_LIST] 		= Role.RoleBase.ParseRoleList,
}
