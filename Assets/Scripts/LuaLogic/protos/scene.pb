
Ω
scene.protoCmdbasetype.protoscenetype.proto"P
MessageEnterCity,
id (2.Cmd.EProtoId:SCENE_ENTERCITY_C
cityid ("P
MessageEnterCopy,
id (2.Cmd.EProtoId:SCENE_ENTERCOPY_C
copyid ("¿
MessageEnterCopyNotify,
id (2.Cmd.EProtoId:SCENE_ENTERCOPY_S
copyid (
mode (2.Cmd.FightMode
buffseed (
monsterseed (#
unitlist (2.Cmd.CopyUnitInfo"Å
MessageEnterCopyPkNotify.
id (2.Cmd.EProtoId:SCENE_ENTERCOPYPK_S
copyid (%
unitlist (2.Cmd.PkCopyUnitInfo"N
MessageCopyReady,
id (2.Cmd.EProtoId:SCENE_COPYREADY_C
time ("B
MessageStartFight-
id (2.Cmd.EProtoId:SCENE_STARTFIGHT_S">
MessageExitCopy+
id (2.Cmd.EProtoId:SCENE_EXITCOPY_C"q
MessageEnterScene-
id (2.Cmd.EProtoId:SCENE_ENTERSCENE_S
sceneid (
pos_x (
pos_y ("B
MessageLeaveScene-
id (2.Cmd.EProtoId:SCENE_LEAVESCENE_S"R
MessageTalkNpcRequest*
id (2.Cmd.EProtoId:SCENE_TALKNPC_C
npcid ("E
MessageCopyListRequest+
id (2.Cmd.EProtoId:SCENE_COPYLIST_C"i
MessageCopyListResponse+
id (2.Cmd.EProtoId:SCENE_COPYLIST_S!
list (2.Cmd.CopyStatusInfo"e
MessageBuyItemRequest*
id (2.Cmd.EProtoId:SCENE_BUYITME_C
shopid (
shoptype ("á
MessageBuyItemResponse*
id (2.Cmd.EProtoId:SCENE_BUYITEM_S
shopid (
num (

creditcoin (
shoptype ("k
MessageRefreshShopRequest.
id (2.Cmd.EProtoId:SCENE_REFRESHSHOP_C
type (
shoptype ("q
MessageRefreshShopResponse.
id (2.Cmd.EProtoId:SCENE_REFRESHSHOP_S
	timestamp (
shoptype ("R
MessageGetShopRequest+
id (2.Cmd.EProtoId:SCENE_GETSHOPS_C
type ("î
MessageShopsNotice,
id (2.Cmd.EProtoId:SCENE_SENDSHOPS_S
list (2.Cmd.ShopUnitInfo
count (

creditcoin (
type ("o
MessageBattleReviveRequest/
id (2.Cmd.EProtoId:SCENE_BATTLEREVIVE_C
isfree (
sequence ("r
MessageMonsterReviveRequest0
id (2.Cmd.EProtoId:SCENE_MONSTERREVIVE_C
unitids (
sequence ("g
MessageAgreePKRequest*
id (2.Cmd.EProtoId:SCENE_AGREEPK_C
inviteid (
serverid ("p
MessageStartSweepRequest(
id (2.Cmd.EProtoId:SCENE_SWEEP_C
copyid (
nums (
type ("h
MessageEndSweepResponse(
id (2.Cmd.EProtoId:SCENE_SWEEP_S#
rewards (2.Cmd.SweepUnitInfo"g
MessageBuyCopyNumRequest-
id (2.Cmd.EProtoId:SCENE_BUYCOPYNUM_C
copyid (
type ("h
MessageBuyCopyNumResponse-
id (2.Cmd.EProtoId:SCENE_BUYCOPYNUM_S
copyid (
nums ("j
"MessageGetChapterRewardInfoRequest4
id (2.Cmd.EProtoId:SCENE_CHAPTERREWARDINFO_C
teleid ("z
#MessageGetChapterRewardInfoResponse4
id (2.Cmd.EProtoId:SCENE_CHAPTERREWARDINFO_S
teleid (
value ("Ñ
MessageGetChapterRewardRequest0
id (2.Cmd.EProtoId:SCENE_CHAPTERREWARD_C
teleid (
rwdtype (
teltype ("á
MessageGetChapterRewardResponse0
id (2.Cmd.EProtoId:SCENE_CHAPTERREWARD_S!
rewards (2.Cmd.CopyRewards
rwdtype ("Q
MessageGetGiftRequest*
id (2.Cmd.EProtoId:SCENE_GETGIFT_C
gift (	"g
MessageGetGiftResponse*
id (2.Cmd.EProtoId:SCENE_GETGIFT_S!
rewards (2.Cmd.CopyRewards"A
MessageRobotsRequest)
id (2.Cmd.EProtoId:SCENE_ROBOTS_C"r
MessageRobotsResponse)
id (2.Cmd.EProtoId:SCENE_ROBOTS_S
robots (2.Cmd.RobotUnit
isover ("^
MessageEnterSoulFightNotify,
id (2.Cmd.EProtoId:SCENE_SOULFIGHT_S
	perfectID ("S
MessageOpenCityNotify+
id (2.Cmd.EProtoId:SCENE_OPENCITY_S
citys ("X
MessageEnterClimbTowerCopyReq7
id (2.Cmd.EProtoId:SCENE_ENTER_CLIMBTOWERCOPY_C"ê
MessageEnterWorldCopyRet2
id (2.Cmd.EProtoId:SCENE_ENTER_WORLDCOPY_S
bossid (
bosshp (
hitdown (
unitids ("E
MessageWait4StartReq-
id (2.Cmd.EProtoId:SCENE_WAIT4START_C