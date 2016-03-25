
Ü=

role.protoCmdbasetype.protoroletype.protomasktype.protoscenetype.protoitemtype.proto"V
RoleList)
id (2.Cmd.EProtoId:SEND_ROLE_LIST
rolebase (2.Cmd.RoleBase"Q
SelectRoleOnline-
id (2.Cmd.EProtoId:SELECT_ROLE_ONLINE
roleid ("E
CurrentRoleOffline/
id (2.Cmd.EProtoId:CURRENT_ROLE_OFFLINE"o
CreateRoleReq*
id (2.Cmd.EProtoId:CREATE_ROLE_REQ
roletype (
rolename (
avatar ("\
CreateRoleRet*
id (2.Cmd.EProtoId:CREATE_ROLE_RET
rolebase (2.Cmd.RoleBase"Z
SendRoleData)
id (2.Cmd.EProtoId:SEND_ROLE_DATA
roleinfo (2.Cmd.RoleInfo"f
RoleAttrChange-
id (2.Cmd.EProtoId:ROLE_ATTRCHANGES_S%

changelist (2.Cmd.RoleAttrPair";
GetRoleBuffReq)
id (2.Cmd.EProtoId:ROLE_GETBUFF_C"X
GetRoleBuffRet)
id (2.Cmd.EProtoId:ROLE_GETBUFF_S
list (2.Cmd.BuffUnit";
GoldMachineReq)
id (2.Cmd.EProtoId:GOLD_MACHINE_C"•
GoldMachineRet)
id (2.Cmd.EProtoId:GOLD_MACHINE_S
goldnum (
criticalrate (
goldMachineCount (
lastGoldMachine ("7
BuyEnergyReq'
id (2.Cmd.EProtoId:BUY_ENERGY_C"_
BuyEnergyRet'
id (2.Cmd.EProtoId:BUY_ENERGY_S
energy (
buyEnergyCount ("P
RoleChangeNickReq-
id (2.Cmd.EProtoId:ROLE_CHANGE_NICK_C
name (	"P
RoleChangeNickRet-
id (2.Cmd.EProtoId:ROLE_CHANGE_NICK_S
name (	"]
BuyUseMbReq'
id (2.Cmd.EProtoId:BUY_USE_MB_C
transactionId (	
itemid ("|
BuyUseMbRet'
id (2.Cmd.EProtoId:BUY_USE_MB_S
itemid (
cash (
	extraCash (
doubleTimes ("Q
UpdateGuideStepReq,
id (2.Cmd.EProtoId:UPDATE_GUIDE_STEP
guide ("`
VipChangeNotiRet,
id (2.Cmd.EProtoId:VIP_CHANGE_NOTI_S
oldVip (
newVip ("<
MessageGetDressReq&
id (2.Cmd.EProtoId:GET_DRESS_C"n
MessageGetDressRet&
id (2.Cmd.EProtoId:GET_DRESS_S
list (2.Cmd.DressRetUnit
equipid ("d
MessageEquipDressReq(
id (2.Cmd.EProtoId:EQUIP_DRESS_C
equipid (
	unequipid ("d
MessageEquipDressRet(
id (2.Cmd.EProtoId:EQUIP_DRESS_S
equipid (
	unequipid ("e
MessageUpGradeDressReq*
id (2.Cmd.EProtoId:UPGRADE_DRESS_C
dressid (
isauto ("n
MessageUpGradeDressRet*
id (2.Cmd.EProtoId:UPGRADE_DRESS_S
dressid (

lv (
exp ("D
MessageLockKontOpenReq*
id (2.Cmd.EProtoId:LOCKKONT_OPEN_C"f
MessageLockKontOpenRet*
id (2.Cmd.EProtoId:LOCKKONT_OPEN_S
lockId (
copyStar ("h
MessageSyncDressNotice,
id (2.Cmd.EProtoId:SYNC_EQUIPDRESS_S 
equip (2.Cmd.DressRetUnit"“
MessageMarqueeNotice)
id (2.Cmd.EProtoId:MARQUEE_NOTI_S
priority (
content (
interval (
count (
type ("F
MessageGetClimbTowerReq+
id (2.Cmd.EProtoId:GET_CLIMBTOWER_C"Æ
MessageGetClimbTowerRet+
id (2.Cmd.EProtoId:GET_CLIMBTOWER_S
type (
diff (
copyid (

resettimes (
revivetimes (

rewardtime (
buyresettimes ("_
MessageSelectClimbTowerReq3
id (2.Cmd.EProtoId:SELECT_CLIMBTOWER_TYPE_C
type ("€
MessageSelectClimbTowerRet3
id (2.Cmd.EProtoId:SELECT_CLIMBTOWER_TYPE_S
type (
diff (
	curcopyid ("O
MessageResetClimbTowerReq2
id (2.Cmd.EProtoId:RESET_CLIMBTOWER_COPY_C"^
MessageResetClimbTowerRet2
id (2.Cmd.EProtoId:RESET_CLIMBTOWER_COPY_S
times ("K
MessageBuyResetTimesReq0
id (2.Cmd.EProtoId:BUY_CLIMBTOWERTIMES_C"l
MessageBuyResetTimesRet0
id (2.Cmd.EProtoId:BUY_CLIMBTOWERTIMES_S
times (
buytimes ("k
!MessageObtainClimbTowerRewardsReq4
id (2.Cmd.EProtoId:OBTAIN_CLIMBTOWERREWARD_C
isdouble ("Y
!MessageObtainClimbTowerRewardsRet4
id (2.Cmd.EProtoId:OBTAIN_CLIMBTOWERREWARD_S"R
MessageGetRoleInfoReq)
id (2.Cmd.EProtoId:GET_ROLEINFO_C
roleid ("è
MessageGetRoleInfoRet)
id (2.Cmd.EProtoId:GET_ROLEiNFO_S
rolebase (2.Cmd.RoleBase
blades (2.Cmd.BladeUnit
souls (2.Cmd.SoulUnit 
dress (2.Cmd.DressRetUnit#
soulcore (2.Cmd.SoulCoreUnit">
RoleDataLoadOk,
id (2.Cmd.EProtoId:ROLE_DATA_LOAD_OK">
MessageGetActionReq'
id (2.Cmd.EProtoId:GET_ACTION_C"w
MessageGetActionRankReq+
id (2.Cmd.EProtoId:GET_ACTIONRANK_C
actid (
startpos (
offset ("m
MessageGetActionRewardsReq-
id (2.Cmd.EProtoId:GET_ACTIONREWARD_C
actionid (
condid ("K
MessageGetActionRewardsRet-
id (2.Cmd.EProtoId:GET_ACTIONREWARD_S"b
MessageSendActionNotify(
id (2.Cmd.EProtoId:SEND_ACTION_S
info (2.Cmd.ActionUnit"¸
MessageSendActionRankNotify,
id (2.Cmd.EProtoId:SEND_ACTIONRANK_S
actid (
count (
rank (
score (
isget (!
list (2.Cmd.ActionRankUnit"[
MessageSendRedPointNotify+
id (2.Cmd.EProtoId:SEND_RED_POINT_S
	from_type ("5
UpdateBpReq&
id (2.Cmd.EProtoId:UPDATE_BP_C"K
MessageGetRechargeInfoReq.
id (2.Cmd.EProtoId:GET_RECHARGE_INFO_C"m
MessageGetRechargeInfoRet.
id (2.Cmd.EProtoId:GET_RECHARGE_INFO_S 
item (2.Cmd.ItemCountType"Y
GetRoleListReq)
id (2.Cmd.EProtoId:GET_ROLELIST_C
roleId (
type ("\
GetRoleListRet)
id (2.Cmd.EProtoId:GET_ROLELIST_S
rolebase (2.Cmd.RoleBase"R
ChatBanNoti%
id (2.Cmd.EProtoId:
CHAT_BAN_S
min (
banChat ("O
GetFirstChargeRewardReq4
id (2.Cmd.EProtoId:GET_FIRST_CHARGE_REWARD_C"‡
GetFirstChargeRewardRet4
id (2.Cmd.EProtoId:GET_FIRST_CHARGE_REWARD_S
firstRecharge (
item (2.Cmd.ItemNotiType"}
GetTestFeedbackInfoRet3
id (2.Cmd.EProtoId:GET_TEST_FEEDBACK_INFO_S
level (
	arenaRank (
flag ("[
GetTestFeedbackGiftReq3
id (2.Cmd.EProtoId:GET_TEST_FEEDBACK_GIFT_C
type ("[
GetTestFeedbackGiftRet3
id (2.Cmd.EProtoId:GET_TEST_FEEDBACK_GIFT_S
flag ("q
GetChargeFeedbackInfoRet5
id (2.Cmd.EProtoId:GET_CHARGE_FEEDBACK_INFO_S
totalPay (
flag ("s
GetChargeFeedbackGiftReq5
id (2.Cmd.EProtoId:GET_CHARGE_FEEDBACK_GIFT_C

activityId (
type ("_
GetChargeFeedbackGiftRet5
id (2.Cmd.EProtoId:GET_CHARGE_FEEDBACK_GIFT_S
flag ("P
GetVipRewardReq+
id (2.Cmd.EProtoId:GET_VIP_REWARD_C
vipLevel ("O
GetVipRewardRet+
id (2.Cmd.EProtoId:GET_VIP_REWARD_S
vipFlag ("D
SoulCoreGetInfoReq.
id (2.Cmd.EProtoId:SOULCORE_GET_INFO_C"—
SoulCoreGetInfoRet.
id (2.Cmd.EProtoId:SOULCORE_GET_INFO_S
frees ( 
total (2.Cmd.SoulCoreUnit 
cache (2.Cmd.SoulCoreUnit"a
SoulCorePracticeReq.
id (2.Cmd.EProtoId:SOULCORE_PRACTICE_C
type (
cost ("¬
SoulCorePracticeRet.
id (2.Cmd.EProtoId:SOULCORE_PRACTICE_S
maxhp (
pAtt (
pDef (
cAtt (
cDef (
cpStren (
frees ("K
SoulCoreSaveReq*
id (2.Cmd.EProtoId:SOULCORE_SAVE_C
type ("=
SoulCoreSaveRet*
id (2.Cmd.EProtoId:SOULCORE_SAVE_S"N
GetFreeRewardReq,
id (2.Cmd.EProtoId:GET_FREE_REWARD_C
type ("X
GetFreeRewardRet,
id (2.Cmd.EProtoId:GET_FREE_REWARD_S
freeRewardFlag ("S
MessageGetStrongRewardReq'
id (2.Cmd.EProtoId:GET_STRONG_C
index ("S
MessageGetStrongRewardRet'
id (2.Cmd.EProtoId:GET_STRONG_S
index ("u
GetTestFeedback2InfoRet4
id (2.Cmd.EProtoId:GET_TEST_FEEDBACK2_INFO_S$
gift (2.Cmd.TestFeedBack2Unit"_
GetTestFeedback2GiftReq4
id (2.Cmd.EProtoId:GET_TEST_FEEDBACK2_GIFT_C
itemid ("u
GetTestFeedback2GiftRet4
id (2.Cmd.EProtoId:GET_TEST_FEEDBACK2_GIFT_S$
gift (2.Cmd.TestFeedBack2Unit