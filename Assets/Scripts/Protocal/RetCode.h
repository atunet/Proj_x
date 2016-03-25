#ifndef _RET_CODE_H
#define _RET_CODE_H

/**
 *	@brief	登录交互码枚举定义
 */
enum ELogonCode
{
	LOGON_FAILED				=	-1,		/**< 登录失败 */
	LOGON_SUCCESS				=	0,		/**< 登录成功 */
	LOGON_TOO_OFTEN				=	1,		/**< 登录太频繁 */
	LOGON_PSWD_ERR				=	2,		/**< 密码错误 */
	LOGON_GATEWAY_NOT_FOUND		=	3,		/**< 找不到可用的网关 */
};

/**
 *	@brief	游戏功能指令交互码枚举定义
 */
enum ERetCode
{
	FAILED						=	-1,		/**< 操作失败 */
	SUCCESS						=	0,		/**< 操作成功 */
	DB_ERROR					=	1,		/**< 数据库操作出错 */
	NAME_EXISTED				=	2,		/**< 角色名称已存在 */
};

#endif /* _RET_CODE_H */
