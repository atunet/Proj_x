
require ("protos.basetype_pb")

globalRoute =
{
	[EPROTOID_VERIFY_VERSION_ENUM.number]	=	login.login.verify_version;
	[EPROTOID_LOGIN_LOGIN_REQ_ENUM.number]	=	login.login.login_req;
	[EPROTOID_LOGIN_GATEW_REQ_ENUM.number]	=	login.gateway.login_req;

}