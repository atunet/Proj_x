//===================================================================

// **	Copyright(c) 2012 中卓网络. 
// **	All rights reserved.

// **	@File     Type.h	  
// **	@Author	  tufeixiang at 13:04:30 2012/05/31
// **	@Brief	  游戏系统基本类型定义
// **	@Version  $Id: Type.h 2896 2012-12-10 13:11:45Z tufeixiang $

//===================================================================

#ifndef _TYPE_H
#define _TYPE_H


#include <string.h>

#include "xType.h"
#include "xObject.h"
#include "xTime.h"

#pragma pack(1)

// 帐号最大长度
#define MAX_ACCOUNT_SIZE 48

// 文字段落最大长度
#define MAX_TEXT_SIZE 128 

// HTTP请求的URL最大长度
#define MAX_URL_SIZE 256 

/// 密保密码最大长度
#define MAX_PSPOD_SIZE 8

/// MAC地址最大长度
#define MAX_MAC_LEN 12

///	GM指令参数最大长度
#define MAX_GMPARA_SIZE	200

/// 最大角色数量
#define MAX_ROLE_NUM 3

/**
 *	@brief	3d世界坐标
 */
struct stPos
{
	DWORD x;
	DWORD y;
	DWORD z;
	stPos() : x(0), y(0), z(0) {}
};

struct stRoleBaseInfo 
{
	DWORD roleId;
	char roleName[MAX_NAME_SIZE+1];
	BYTE sex;
	BYTE level;
	DWORD mapId;
	stPos pos;

	stRoleBaseInfo() : roleId(0), sex(0), level(0), mapId(0) {}
};

/**
 *	@brief	货币类型
 */
enum EMoneyType
{
	GOLD	=	1 << 0,		/**< 游戏币 */
	RMB		=	1 << 1,		/**< 人民币 */
};

#define MAX_GOLD_NUM		999999999		/**< 游戏币最大值 */
#define MAX_RMB_NUM			999999999		/**< 人民币最大值 */

/**
 *	@brief	商城中的道具信息结构
 */
struct stShopObjInfo
{
	QWORD objectID;		/**< 道具ID */
	BYTE levelLimit;	/**< 等级限制 */
	BYTE discount;		/**< 折扣，最大100 */

	stShopObjInfo() : objectID(0), levelLimit(0), discount(0) {}
};

/**
 *	@brief 道具基本类型宏定义
 */
#define BASE_TYPE_BUILDING	1	/**< 建筑类 */
#define BASE_TYPE_ADORN		2	/**< 装饰类 */
#define BASE_TYPE_EQUIP		3	/**< 服装类 */
#define BASE_TYPE_PROPERTY	4	/**< 道具类 */
#define BASE_TYPE_STUFF		5	/**< 材料类 */

/**
 *	@brief 道具子类型宏定义
 */
#define SUB_TYPE_BUILDING_FUNCTION	1	/**< 功能性建筑 */
#define SUB_TYPE_BUILDING_SECTION	2	/**< 科室建筑 */
#define SUB_TYPE_ADORN_HONOR		3	/**< 华丽建筑 */
#define SUB_TYPE_ADORN_GROUND		4	/**< 地面 */
#define SUB_TYPE_ADORN_HANG			5	/**< 挂饰 */
#define SUB_TYPE_ADORN_WALLPAPER	6	/**< 墙纸 */
#define SUB_TYPE_ADORN_FLOOR		7	/**< 地板 */
#define SUB_TYPE_ADORN_BGOURD		8	/**< 背景 */
#define SUB_TYPE_ADORN_POT			9	/**< 盆栽 */
#define SUB_TYPE_ADORN_ROCKERY		10	/**< 假山 */
#define SUB_TYPE_ADORN_TREE			11	/**< 树木 */
#define SUB_TYPE_ADORN_POOL			12	/**< 池水 */
#define SUB_TYPE_EQUIP_SUIT			13	/**< 套装 */
#define SUB_TYPE_EQUIP_HAIR			14	/**< 发型 */
#define SUB_TYPE_EQUIP_HAT			15	/**< 帽子 */
#define SUB_TYPE_EQUIP_FACE			16	/**< 脸型 */
#define SUB_TYPE_EQUIP_JAKET		17	/**< 上装 */
#define SUB_TYPE_EQUIP_TROUSER		18	/**< 下装 */
#define SUB_TYPE_PROPERTY_SPEED		19	/**< 加速类 */
#define SUB_TYPE_PROPERTY_INCREASE	20	/**< 增强类 */
#define SUB_TYPE_PROPERTY_SKILL		21	/**< 技能类 */
#define SUB_TYPE_PROPERTY_SPECAIL	22	/**< 特殊类 */
#define SUB_TYPE_PROPERTY_CAR		23	/**< 汽车类 */
#define SUB_TYPE_STUFF_STUFF		24	/**< 材料类 */
#define SUB_TYPE_STUFF_SPALL		25	/**< 技能碎片 */
#define SUB_TYPE_STONE_BUILDING		26	/**< 科室宝石 */
#define SUB_TYPE_GIFT_BAG   		28	/**< 礼包 */

/**
 *	@brief	部分道具ID宏定义
 */
#define OBJECT_ID_MAIN_BUILDING		1		// 院长室	
//#define OJBECT_ID_ACQ_BUILDING      2       // 诊断室
#define OBJECT_ID_HR_BUILDING		3		// 人事部
#define OBJECT_ID_STEAM_BUILDING	4		// 蒸汽室
#define OBJECT_ID_PREBOOK_BUILDING	5		// 预约台
#define OBJECT_ID_CASHIER_BUILDING  15		// 收银台
#define OBJECT_ID_AGATE_FRAGMENT	6001	// 玛瑙碎片	
#define OBJECT_ID_AGATE				6002	// 玛瑙	
#define OBJECT_ID_RECRUIT			5001	// 纳贤榜 
#define OBJECT_ID_CALL_ABLE			5002	// 招贤榜

/**
 *	@brief	强制用户下线原因
 */
enum EForceOffline
{
	FORCE_OFFLINE_SYSTEM_ERR	=	0,				/**< 系统错误 */
	FORCE_OFFLINE_RE_LOGON		=	1,				/**< 重复上线 */
	FORCE_OFFLINE_NO_SCENE_SVR  =	2,				/**< 没有可用的场景服 */
};


#pragma pack()

#endif /* _TYPE_H */
