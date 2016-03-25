using System;

internal struct Command
{
	/******************************* Send *********************************/
	
	// login
	internal const UInt32 CLIENT2DIR_LOGIN_REQ 						= 0x12440000;
	internal const UInt32 CLIENT2LOBBY_LOGIN_TOKEN_REQ 				= 0x12410000;
	internal const UInt32 CLIENT2LOBBY_CREATE_CHAR_REQ 				= 0x12410002;
	internal const UInt32 CLIENT2LOBBY_LOADINSTANCE_REQ 			= 0x12410201;
	internal const UInt32 CLIENT2LOBBY_CHALLENGE_INSTANCE_REQ 		= 0x12410202;//通知服务器战斗开始
	internal const UInt32 CLIENT2LOBBY_CHALLENGE_RESULT_REQ 		= 0x12410203;//
	internal const UInt32 CLIENT2LOBBY_BATTLEREZ_REQ				= 0x12410204;//发送给服务器请求复活
	internal const UInt32 CLIENT2LOBBY_RECOMMENDFRIEND_REQ			= 0x12410205;//获取助战好友列表
	
	//card
	internal const UInt32 CLIENT2LOBBY_UPDATE_FORMATION_REQ 		= 0x12410103;
	internal const UInt32 CLIENT2LOBBY_LV_UP_REQ 					= 0x12410104;
	internal const UInt32 CLIENT2LOBBY_CARD_EVOLUTION_REQ 			= 0x12410105;
	internal const UInt32 CLIENT2LOBBY_SALE_SOLDIER_REQ 			= 0x12410106;
	internal const UInt32 CLIENT2LOBBY_SALE_TRIBUTE_REQ 			= 0x12410107;
	internal const UInt32 CLIENT2LOBBY_CHANGE_EQUIP_REQ 			= 0x12410108;
	
	//friend
	internal const UInt32 CLIENT2LOBBY_GAIN_FRIEND_REQ 				= 0x12410301;		//向服务器请求好友列表
	internal const UInt32 CLIENT2LOBBY_APPLY_FRIEND_REQ 			= 0x12410302;		//向服务器请求邀请好友列表
	internal const UInt32 CLIENT2LOBBY_ADD_FRIEND_REQ 				= 0x12410303;		//向服务器请求添加好友
	internal const UInt32 CLIENT2LOBBY_DELETE_FRIEND_REQ 			= 0x12410304;		//删除好友请求
	internal const UInt32 CLIENT2LOBBY_OP_APPLY_FRIEND_REQ 			= 0x12410305;		//处理好友请求
	internal const UInt32 CLIENT2LOBBY_SEARCH_FRIEND_REQ 			= 0x12410306;		//ID搜索好友请求
	//task
	internal const UInt32 CLIENT2LOBBY_QUERY_ACHIEVE_REQ			= 0x12410401;		//向服务器请求成就信息列表
	internal const UInt32 CLIENT2LOBBY_QUERY_QUEST_REQ				= 0x12410402;		//向服务器请求任务列表信息
	internal const UInt32 CLIENT2LOBBY_COMMIT_QUEST_REQ				= 0x12410403;		//通知服务领取某个奖励
	
	//mail
	internal const UInt32 CLIENT2LOBBY_MAIL_LIST_REQ 				= 0x12410601;		//向服务器请求邮件列表
	internal const UInt32 CLIENT2LOBBY_MAIL_READ_REQ 				= 0x12410602;		//读取一封邮件
	internal const UInt32 CLIENT2LOBBY_MAIL_DELETE_REQ 				= 0x12410603;		//删除一封邮件
	internal const UInt32 CLIENT2LOBBY_MAIL_ACCEPT_ATTACHMENT_REQ 	= 0x12410604;		//收取附件
	
	// shop
	internal const UInt32 CLIENT2LOBBY_EXPEND_FRIEND_LIMIT_REQ		= 0x12410501;
	internal const UInt32 CLIENT2LOBBY_EXPEND_CARD_LIMIT_REQ		= 0x12410502;
	internal const UInt32 CLIENT2LOBBY_EXTRACT_CARD_REQ				= 0x12410503;		//通知服务器要抽取的卡牌类型
	internal const UInt32 LOBBY2CLIENT_DEAL_REQ						= 0x12410504;
	
	
	/******************************* Recieve *********************************/
	
	
	internal const UInt32 DIR2CLIENT_LOGIN_RET 						= 0x11090000;
	internal const UInt32 LOBBY2CLIENT_LOGIN_FAILED 				= 0x10490001;
	internal const UInt32 LOBBY2CLIENT_CREATE_CHARACTER_CMD 		= 0x10490002;
	internal const UInt32 LOBBY2CLIENT_CREATE_CHAR_FAILED 			= 0x10490003;
	internal const UInt32 LOBBY2CLIENT_CHARACTER_INFO_NTF 			= 0x10490004;
	internal const UInt32 LOBBY2CLIENT_STAMINA_INFO_UPDATE	 		= 0x10490005;
	internal const UInt32 LOBBY2CLIENT_Diamond_Update	 			= 0x10490008;		//更新钻石
	internal const UInt32 LOBBY2CLIENT_FRIENDPOINT_UPDATE			= 0x10490009;		//更新友情点
	internal const UInt32 LOBBY2CLIENT_LOADINSTANCE_RET 			= 0x10490201;
	internal const UInt32 LOBBY2CLIENT_CHALLENGEINSTANCE_RET 		= 0x10490202;
	internal const UInt32 LOBBY2CLIENT_BATTLEREZ_RET 				= 0x10490204;		//复活武将结果
	internal const UInt32 LOBBY2CLIENT_EXPEND_FRIEND_LIMIT_RET		= 0x10490501;
	internal const UInt32 LOBBY2CLIENT_EXPEND_CARD_LIMIT_RET 		= 0x10490502;
	internal const UInt32 LOBBY2CLIENT_EXTRACT_CARD_RET 			= 0x10490503;		//s回复抽奖结果
	internal const UInt32 LOBBY2CLIENT_DEAL_RET						= 0x10490504;
	
	
	internal const byte CMD_LOGON							=	0x00;
	internal const byte CMD_CARD							=	0x01;
	internal const byte CMD_INSTANCE						=	0x02;
	internal const byte CMD_FRIEND							=	0x03;
	internal const byte CMD_TASK							=   0x04;
	internal const byte CMD_SHOP							=	0x05;
	internal const byte CMD_MAIL							=	0x06;
	
	//CMD LOGIN/USER DATA 相关
	internal const byte PARA_LOGON_DIR_RET					=	0x00;
	internal const byte PARA_LOGON_LOBBY_FAILED				=	0x01;
	internal const byte PARA_NOTIFY_CREATE_ROLE				=	0x02;
	internal const byte PARA_RET_CREATE_ROLE				=	0x03;
	internal const byte PARA_RET_CHARACTER_INFO				=	0x04;
	internal const byte PARA_NOTIFY_UPDATE_STAMINA			=	0x05;
	internal const byte PARA_NOTIFY_UPDATE_GOLD				=	0x07;
	internal const byte PARA_NOTIFY_Diamond_Update			=	0x08;
	internal const byte PARA_NOTIFY_FRIENDPOINT_UPDATE		=   0x09;
	
	//CMD_CARD 卡牌相关
	internal const byte PARA_CARD_INFO_LIST					=	0x01;						//进入游戏时角色拥有的卡牌列表更新
	internal const byte PARA_CARD_TRIBUTE_LIST				=	0x02;						//进入游戏时角色拥有的贡品列表更新
	internal const byte PARA_CARD_UPDATE_FORMATION			=	0x03;						//更新阵形消息
	internal const byte PARA_CARD_LV_UP_LIST				=	0x04;						//武将吞噬结果消息
	internal const byte PARA_CARD_EVOLUTION_RET				=	0x05;						//武将进化结果消息
	internal const byte PARA_CARD_SOLDIER_SALE_RET			=	0x06;						//武将出售消息
	internal const byte PARA_CARD_TRIBUTE_SALE_RET			=	0x07;						//贡品出售消息
	internal const byte PARA_CARD_ADD_CARD_RET				=	0x08;						//增加卡牌消息
	internal const byte PARA_CARD_DEL_CARD_RET				=	0x09;						//删除卡牌消息
	internal const byte PARA_CARD_UPDATE_TRIBUTE_RET		=	0x0A;						//更新贡品信息消息
	internal const byte PARA_CARD_ADD_EQUIP_RET				=	0x0B;						//更新装备信息消息(包括 武器、防具、饰品、技能书)
	internal const byte PARA_CARD_CHANGE_EQUIP_RET			=	0x0C;						//更换装备(包括 更换 武器、防具、饰品、技能书)
	
	//CMD_FRIEND 好友相关
	internal const byte PARA_FRIEND_INFO_LIST				=	0x01;						//服务器发来好友列表消息
	internal const byte PARA_FRIEND_APPLY_LIST				=	0x02;						//服务器发来好友申请列表消息
	internal const byte PARA_FRIEND_APPLY_ADD				=	0x04;						//服务器发来好友申请消息
	internal const byte PARA_FRIEND_DELETE_BACK				=	0x05;						//服务器发来删除好友还回消息(主动删除好友的角色收到的删除好友的处理结果)
	internal const byte PARA_FRIEND_DELETE_RET				=	0x06;						//服务器发来删除好友的消息(主动删除好友的角色和被删除的角色都会收到此消息)
	internal const byte PARA_FRIEND_APPLY_OP_RESULT			=	0x07;						//服务器发来申请列表中三个操作的结果
	internal const byte PARA_FRIEND_ADD_RET					=	0x08;						//服务器发来添加好友消息
	internal const byte PARA_FRIEND_SEARCH_RESULT			=	0x09;						//服务器发来ID搜索结果
	//CMD_TASK
	internal const byte PARA_TASK_QUERYACHIEVERET			= 	0x01;						//服务器发送过来的成就列表信息
	internal const byte PARA_TASK_DONEACHIEVENTF			=   0x02;						//服务器通知完成了某个成就
	internal const byte PARA_TASK_QUERYQUESTRET				= 	0x03;						//服务器发送过来的任务列表信息
	internal const byte PARA_TASK_DONEQUESTNTF				=	0x04;						//服务器通知完成了某个任务
	internal const byte PARA_TASK_NEWQUESTNTF				= 	0x05;						//服务器通知开启了某个新任务
	internal const byte PARA_TASK_COMMITQUESTRET			=   0x06;						//领取任务奖励是否成功
	
	//CMD_MAIL 邮件相关
	internal const byte PARA_MAIL_INFO_LIST					=	0x01;						//服务器发来邮件列表消息
	internal const byte PARA_MAIL_READ_RET					=	0x02;						//读取邮件返回消息
	internal const byte PARA_MAIL_DELETE_RET				=	0x03;						//删除邮件返回消息
	internal const byte PARA_MAIL_ACCEPT_ATTACHMENT_RET		=	0x04;						//收取附件返回消息
	internal const byte PARA_MAIL_ADD						=	0x05;						//新增邮件
	
	// CMD INSTANCE 副本相关
	internal const byte PARA_RET_INSTANCE_INFO				=	0x01;
	internal const byte PARA_RET_CHALLENGE_INSTANCE_RESULT 	= 	0x02;						//进入副本前服务器判断能否进入回馈
	internal const byte PARA_RET_CHALLENGE_RESULT			=   0x03;  						//副本挑战结果
	internal const byte PARA_RET_RELIVERESULT				=	0x04;
	internal const byte PARA_RET_RECOMMEND_FRIEND			=	0x05;						//接收助戰好友列表
	
	// CMD SHOP 商店相关
	internal const byte PARA_RET_EXPEND_FRIEND_LIMIT		=	0x01;
	internal const byte PARA_RET_EXPEND_CARD_LIMIT			=	0x02;
	internal const byte PARA_EXTRACT_CARD					=	0x03;
	internal const byte PARA_DEAL_RET						=	0x04;
}