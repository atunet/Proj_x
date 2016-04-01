//=======================================================================

// ***	Copyright(c) 2012 中卓网络. 
// ***	All rights reserved.

// ***	@File	  CharBase.h
// ***	@Author	  tufeixiang at 14:14:30 2012/05/22
// ***	@Brief	  角色数据信息结构定义
// ***	@Version  $Id: CharBase.h 2960 2012-12-12 09:34:45Z fangwenlai $

//=======================================================================

#ifndef _CHARBASE_H
#define _CHARBASE_H

#include "Type.h"

#pragma pack(1)

/**
 *	@brief	角色信息
 */
struct CharBase
{
    DWORD   roleID;							/**< 角色ID */
	char	roleName[MAX_NAME_SIZE+1];		/**< 角色名称 */
	QWORD	accId;							/**< 玩家帐号 */
	BYTE	sex;							/**< 角色性别 */
	BYTE	figure;							/**< 角色类型 创建角色时选择的形象 */
	BYTE	level;							/**< 角色等级 */
	DWORD	mapID;							/**< 所在地图 */
	stPos	pos;							/**< 坐标 */
    DWORD   gold;							/**< 游戏币 */
    DWORD   rmb;							/**< 人民币 */
    WORD	mask;							/**< 标志位 */

    CharBase() 
	{
		bzero(this, sizeof(*this));
	}
};

/**
 *	@brief	EMask枚举,CharBase中mask各位含义
 */
enum EMask
{
	NOT_LOGON_YET	=	0,		/**< 是否登录过游戏,0:未登录过;1:已登录过 */
};

#pragma pack()

#endif /* _CHARBASE_H */
