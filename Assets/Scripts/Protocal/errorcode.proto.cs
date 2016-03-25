//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: errorcode.proto
// Note: requires additional types generated from: basetype.proto
namespace Cmd
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MessageErrorCode")]
  public partial class MessageErrorCode : global::ProtoBuf.IExtensible
  {
    public MessageErrorCode() {}
    
    private Cmd.EProtoId _id = Cmd.EProtoId.ERROR_CODE_S;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Cmd.EProtoId.ERROR_CODE_S)]
    public Cmd.EProtoId id
    {
      get { return _id; }
      set { _id = value; }
    }
    private Cmd.EErrorCode _code;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"code", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Cmd.EErrorCode code
    {
      get { return _code; }
      set { _code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"EErrorCode")]
    public enum EErrorCode
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"FAILED", Value=401014783)]
      FAILED = 401014783,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SUCCESS", Value=400949248)]
      SUCCESS = 400949248,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DB_ERROR", Value=400949249)]
      DB_ERROR = 400949249,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CONF_ERROR", Value=400949250)]
      CONF_ERROR = 400949250,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NAME_EXISTED", Value=400949251)]
      NAME_EXISTED = 400949251,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAX_ITEM_NUM", Value=400949252)]
      MAX_ITEM_NUM = 400949252,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ROLE_LV_LIMIT", Value=400949253)]
      ROLE_LV_LIMIT = 400949253,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LV_NOT_ENOUGH", Value=400949254)]
      LV_NOT_ENOUGH = 400949254,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TOKEN_OVERDUE", Value=400949255)]
      TOKEN_OVERDUE = 400949255,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SERVER_IS_BUSY", Value=400949256)]
      SERVER_IS_BUSY = 400949256,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SDK_OPT_ERROR", Value=400949257)]
      SDK_OPT_ERROR = 400949257,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CASH_NOT_ENOUGH", Value=400949264)]
      CASH_NOT_ENOUGH = 400949264,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GOLD_NOT_ENOUGH", Value=400949265)]
      GOLD_NOT_ENOUGH = 400949265,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NAME_LEN_INVALID", Value=400949266)]
      NAME_LEN_INVALID = 400949266,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CONTENT_HAVE_DIRTY", Value=400949267)]
      CONTENT_HAVE_DIRTY = 400949267,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PROTO_INVALID", Value=400949268)]
      PROTO_INVALID = 400949268,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_NOT_FIND", Value=400949269)]
      ITEM_NOT_FIND = 400949269,
            
      [global::ProtoBuf.ProtoEnum(Name=@"VIP_NOT_SATISFY", Value=400949270)]
      VIP_NOT_SATISFY = 400949270,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BANK_OPEN_FAILED", Value=400949271)]
      BANK_OPEN_FAILED = 400949271,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BANK_CLOSED_FAILED", Value=400949272)]
      BANK_CLOSED_FAILED = 400949272,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TOKEN_NOT_FOUND", Value=400949273)]
      TOKEN_NOT_FOUND = 400949273,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TOKEN_ERROR", Value=400949274)]
      TOKEN_ERROR = 400949274,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IDLE_TIMEOUT", Value=400949275)]
      IDLE_TIMEOUT = 400949275,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DAILY_REACH_LIMIT", Value=400949276)]
      DAILY_REACH_LIMIT = 400949276,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IN_FORBID_TIME", Value=400949277)]
      IN_FORBID_TIME = 400949277,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FULL_OF_ROLE", Value=400949278)]
      FULL_OF_ROLE = 400949278,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REWARD_HAVE_GOT", Value=400949279)]
      REWARD_HAVE_GOT = 400949279,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REWARD_TIME_LIMIT", Value=400949280)]
      REWARD_TIME_LIMIT = 400949280,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOULDUST_NOT_ENOUGH", Value=400949281)]
      SOULDUST_NOT_ENOUGH = 400949281,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ON_CREATING_ROLE", Value=400949282)]
      ON_CREATING_ROLE = 400949282,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAX_ROLE_NUM_LIMIT", Value=400949283)]
      MAX_ROLE_NUM_LIMIT = 400949283,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CREATE_SAME_ROLE_FORBID", Value=400949284)]
      CREATE_SAME_ROLE_FORBID = 400949284,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TIMES_REACH_LIMIT", Value=400949285)]
      TIMES_REACH_LIMIT = 400949285,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SYSTEM_NOT_OPEN", Value=400949286)]
      SYSTEM_NOT_OPEN = 400949286,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_ID_ERROR", Value=400949505)]
      USER_ID_ERROR = 400949505,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LOGIN_TOO_OFTEN", Value=400949506)]
      LOGIN_TOO_OFTEN = 400949506,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_RE_LOGIN", Value=400949507)]
      USER_RE_LOGIN = 400949507,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GATEWAY_NOT_FOUND", Value=400949508)]
      GATEWAY_NOT_FOUND = 400949508,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SYSTEM_KICK_OFF", Value=400949509)]
      SYSTEM_KICK_OFF = 400949509,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DRESS_NOT_FIND", Value=400949761)]
      DRESS_NOT_FIND = 400949761,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DRESS_LV_MAX", Value=400949762)]
      DRESS_LV_MAX = 400949762,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DRESSCONF_NOT_FIND", Value=400949763)]
      DRESSCONF_NOT_FIND = 400949763,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DRESSCONF_COSTITEM_ERROR", Value=400949764)]
      DRESSCONF_COSTITEM_ERROR = 400949764,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DRESS_ITEM_NOT_ENOUGH", Value=400949765)]
      DRESS_ITEM_NOT_ENOUGH = 400949765,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STAR_NOT_ENOUGH", Value=400949766)]
      STAR_NOT_ENOUGH = 400949766,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BP_NOT_ENOUGH", Value=400949767)]
      BP_NOT_ENOUGH = 400949767,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CONSUME_NOT_ENOUGH", Value=400949768)]
      CONSUME_NOT_ENOUGH = 400949768,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DUNGEON_NOT_ENOUGH", Value=400949769)]
      DUNGEON_NOT_ENOUGH = 400949769,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ROLE_DATA_ERROR", Value=400949776)]
      ROLE_DATA_ERROR = 400949776,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DRESS_EXP_FULL", Value=400949777)]
      DRESS_EXP_FULL = 400949777,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CLIMBTOWER_IS_NULL", Value=400949778)]
      CLIMBTOWER_IS_NULL = 400949778,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SELECT_TOWER_TYPE_ERROR", Value=400949779)]
      SELECT_TOWER_TYPE_ERROR = 400949779,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HAVE_BEEN_SELECT", Value=400949780)]
      HAVE_BEEN_SELECT = 400949780,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FIRST_TOWER_COPY_ERROR", Value=400949781)]
      FIRST_TOWER_COPY_ERROR = 400949781,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TOWER_RESETTIMES_FULL", Value=400949782)]
      TOWER_RESETTIMES_FULL = 400949782,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COST_CASH_IS_NULL", Value=400949783)]
      COST_CASH_IS_NULL = 400949783,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RESETTOWER_NOREWARDS", Value=400949784)]
      RESETTOWER_NOREWARDS = 400949784,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HAVE_BEEN_RESET", Value=400949785)]
      HAVE_BEEN_RESET = 400949785,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RESETTIMES_NOT_ENOUGHT", Value=400949786)]
      RESETTIMES_NOT_ENOUGHT = 400949786,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CLIMBTOWER_REWARD_GET", Value=400949787)]
      CLIMBTOWER_REWARD_GET = 400949787,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NO_CLIMBTOWER_RWARD", Value=400949788)]
      NO_CLIMBTOWER_RWARD = 400949788,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CLIMBTOWER_REWARD_INDEX_ERR", Value=400949789)]
      CLIMBTOWER_REWARD_INDEX_ERR = 400949789,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CLIMBTOWER_REWARD_DROP_ERR", Value=400949790)]
      CLIMBTOWER_REWARD_DROP_ERR = 400949790,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CLIMBTOWER_IS_TOP", Value=400949791)]
      CLIMBTOWER_IS_TOP = 400949791,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CLIMBTOWER_REVIVE_NULL", Value=400949792)]
      CLIMBTOWER_REVIVE_NULL = 400949792,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CLIMBTOWER_VIP_NOT_REW", Value=400949793)]
      CLIMBTOWER_VIP_NOT_REW = 400949793,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CLIMBTOWER_CASH_NOT_REW", Value=400949794)]
      CLIMBTOWER_CASH_NOT_REW = 400949794,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_ISNOT_EXIST", Value=400949795)]
      ACTION_ISNOT_EXIST = 400949795,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_ISCLOSE", Value=400949796)]
      ACTION_ISCLOSE = 400949796,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_COND_ISNOT_EXIST", Value=400949797)]
      ACTION_COND_ISNOT_EXIST = 400949797,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_COND_ISDONE", Value=400949798)]
      ACTION_COND_ISDONE = 400949798,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_NOT_COMPLEATE", Value=400949799)]
      ACTION_NOT_COMPLEATE = 400949799,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_NOT_REWARD_GET", Value=400949800)]
      ACTION_NOT_REWARD_GET = 400949800,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_REWARDTIME_NOTARRI", Value=400949801)]
      ACTION_REWARDTIME_NOTARRI = 400949801,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_RANKREWARD_GET", Value=400949802)]
      ACTION_RANKREWARD_GET = 400949802,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_NOTIN_RANK", Value=400949803)]
      ACTION_NOTIN_RANK = 400949803,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_SETGETREWARD_ERR", Value=400949804)]
      ACTION_SETGETREWARD_ERR = 400949804,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_NO_SPECIAL", Value=400949805)]
      ACTION_NO_SPECIAL = 400949805,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTION_EXCHANGE_NOT_OK", Value=400949806)]
      ACTION_EXCHANGE_NOT_OK = 400949806,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LEADEROFFLINE", Value=400950017)]
      LEADEROFFLINE = 400950017,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MEMBEROFFLINE", Value=400950018)]
      MEMBEROFFLINE = 400950018,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COPYINVALID", Value=400950019)]
      COPYINVALID = 400950019,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CREATECOPYFAIL", Value=400950020)]
      CREATECOPYFAIL = 400950020,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INICOPYFAIL", Value=400950021)]
      INICOPYFAIL = 400950021,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLAYINFIGHT", Value=400950022)]
      PLAYINFIGHT = 400950022,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLAYSTRNOTENOUGH", Value=400950023)]
      PLAYSTRNOTENOUGH = 400950023,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CITYINVALID", Value=400950024)]
      CITYINVALID = 400950024,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CITY_NOT_OPEN", Value=400950025)]
      CITY_NOT_OPEN = 400950025,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INVALID", Value=400950026)]
      INVALID = 400950026,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BEINSCENE", Value=400950027)]
      BEINSCENE = 400950027,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INCOPY", Value=400950028)]
      INCOPY = 400950028,
            
      [global::ProtoBuf.ProtoEnum(Name=@"READYCOPYINVALID", Value=400950029)]
      READYCOPYINVALID = 400950029,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NOTINCOPY", Value=400950030)]
      NOTINCOPY = 400950030,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NOTHASBLADE", Value=400950031)]
      NOTHASBLADE = 400950031,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COPYNOTACTIVE", Value=400950032)]
      COPYNOTACTIVE = 400950032,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TELEIDFAILED", Value=400950033)]
      TELEIDFAILED = 400950033,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REVIVEFAILED", Value=400950034)]
      REVIVEFAILED = 400950034,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REVIVECOINNOTENOUGH", Value=400950035)]
      REVIVECOINNOTENOUGH = 400950035,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REVIVETIMESNOTENOUGH", Value=400950036)]
      REVIVETIMESNOTENOUGH = 400950036,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REVIVECASHNOTENOUGH", Value=400950037)]
      REVIVECASHNOTENOUGH = 400950037,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REFRESHSHOPCASHFAIL", Value=400950038)]
      REFRESHSHOPCASHFAIL = 400950038,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REFRESHSHOPFAIL", Value=400950039)]
      REFRESHSHOPFAIL = 400950039,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOPSNOTEXIST", Value=400950040)]
      SHOPSNOTEXIST = 400950040,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOPSNOTENOUGH", Value=400950041)]
      SHOPSNOTENOUGH = 400950041,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUYITEMRESNOTENOUGH", Value=400950042)]
      BUYITEMRESNOTENOUGH = 400950042,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COPYIDINVALID", Value=400950043)]
      COPYIDINVALID = 400950043,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COPYNOTALLOWRUSH", Value=400950044)]
      COPYNOTALLOWRUSH = 400950044,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RUSHSTARNOTENOUGH", Value=400950045)]
      RUSHSTARNOTENOUGH = 400950045,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SWEEPITEMNOTENOUGH", Value=400950046)]
      SWEEPITEMNOTENOUGH = 400950046,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SWEEPCASHNOTENOUGH", Value=400950047)]
      SWEEPCASHNOTENOUGH = 400950047,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SWEEPNUMSNOTENOUGH", Value=400950048)]
      SWEEPNUMSNOTENOUGH = 400950048,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SWEEPPAYTYPEERROR", Value=400950049)]
      SWEEPPAYTYPEERROR = 400950049,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COPYNUMNOTENOUGH", Value=400950050)]
      COPYNUMNOTENOUGH = 400950050,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUYCOPYNUMTYPEERROR", Value=400950051)]
      BUYCOPYNUMTYPEERROR = 400950051,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COPYNUMNOTUSEOUT", Value=400950052)]
      COPYNUMNOTUSEOUT = 400950052,
            
      [global::ProtoBuf.ProtoEnum(Name=@"VIPCONFFAIL", Value=400950053)]
      VIPCONFFAIL = 400950053,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COPYNUMUSEOUT", Value=400950054)]
      COPYNUMUSEOUT = 400950054,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUYCOPYNUMCASHNOTENOUGH", Value=400950055)]
      BUYCOPYNUMCASHNOTENOUGH = 400950055,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CHAPTERREWARD_STARERROR", Value=400950056)]
      CHAPTERREWARD_STARERROR = 400950056,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SWEEP_NOTUSECASH_VIP", Value=400950057)]
      SWEEP_NOTUSECASH_VIP = 400950057,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SWEEP_NUMS_ERROR", Value=400950058)]
      SWEEP_NUMS_ERROR = 400950058,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SWEEP_NOTTEN_VIP", Value=400950059)]
      SWEEP_NOTTEN_VIP = 400950059,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CHAPTER_REWARD_GET_DONE", Value=400950060)]
      CHAPTER_REWARD_GET_DONE = 400950060,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CHAPTER_REWARD_TYPE_ERROR", Value=400950061)]
      CHAPTER_REWARD_TYPE_ERROR = 400950061,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CHAPTER_REWARD_VIP_FAIL", Value=400950062)]
      CHAPTER_REWARD_VIP_FAIL = 400950062,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DB_OPERATOR_ERROR", Value=400950063)]
      DB_OPERATOR_ERROR = 400950063,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HAVE_NO_THIS_GIFT", Value=400950064)]
      HAVE_NO_THIS_GIFT = 400950064,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DB_UPDATE_ERROR", Value=400950065)]
      DB_UPDATE_ERROR = 400950065,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_SOME_CONFIG_USED", Value=400950066)]
      GIFT_SOME_CONFIG_USED = 400950066,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DB_INSERT_ERROR", Value=400950067)]
      DB_INSERT_ERROR = 400950067,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_GROUP_ERROR", Value=400950068)]
      GIFT_GROUP_ERROR = 400950068,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_SOME_GROUP_USED", Value=400950069)]
      GIFT_SOME_GROUP_USED = 400950069,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_LIMITNUM_ERROR", Value=400950070)]
      GIFT_LIMITNUM_ERROR = 400950070,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_NOTIMES_TO_USE", Value=400950071)]
      GIFT_NOTIMES_TO_USE = 400950071,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_TYPE_ERROR", Value=400950072)]
      GIFT_TYPE_ERROR = 400950072,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_LEN_ERROR", Value=400950073)]
      GIFT_LEN_ERROR = 400950073,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_REWARD_PARSEERROR", Value=400950074)]
      GIFT_REWARD_PARSEERROR = 400950074,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_STARTTIME_ERROR", Value=400950075)]
      GIFT_STARTTIME_ERROR = 400950075,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_ENDTIME_EXPIRE", Value=400950076)]
      GIFT_ENDTIME_EXPIRE = 400950076,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GIFT_HAVE_USED", Value=400950077)]
      GIFT_HAVE_USED = 400950077,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLESQUARE_NOT_OPEN", Value=400950078)]
      BATTLESQUARE_NOT_OPEN = 400950078,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLESQUARE_HAVE_BET", Value=400950079)]
      BATTLESQUARE_HAVE_BET = 400950079,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLESQUARE_WIN_NOTENOUGH", Value=400950080)]
      BATTLESQUARE_WIN_NOTENOUGH = 400950080,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLESQUARE_WINRWD_GET", Value=400950081)]
      BATTLESQUARE_WINRWD_GET = 400950081,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLESQUARE_DROP_ERROR", Value=400950082)]
      BATTLESQUARE_DROP_ERROR = 400950082,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLESQUARE_BETCONF_ERR", Value=400950083)]
      BATTLESQUARE_BETCONF_ERR = 400950083,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLESQUARE_VIP_NOTBET", Value=400950084)]
      BATTLESQUARE_VIP_NOTBET = 400950084,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STRONGREWARD_HAVE_GOT", Value=400950085)]
      STRONGREWARD_HAVE_GOT = 400950085,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STRONGREWARD_INDEX_ERR", Value=400950086)]
      STRONGREWARD_INDEX_ERR = 400950086,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STRONGREWARD_BP_NOTENOU", Value=400950087)]
      STRONGREWARD_BP_NOTENOU = 400950087,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STRONGREWARD_DROP_ERR", Value=400950088)]
      STRONGREWARD_DROP_ERR = 400950088,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BSCOIN_NOT_ENOUGHT", Value=400950089)]
      BSCOIN_NOT_ENOUGHT = 400950089,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAX_STRENGTH_LV", Value=400950273)]
      MAX_STRENGTH_LV = 400950273,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_NOT_ENOUGH", Value=400950274)]
      ITEM_NOT_ENOUGH = 400950274,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAX_BREAK_LV", Value=400950275)]
      MAX_BREAK_LV = 400950275,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SKILL_POINT_NOT_ENOUGH", Value=400950276)]
      SKILL_POINT_NOT_ENOUGH = 400950276,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAX_SKILL_LV", Value=400950277)]
      MAX_SKILL_LV = 400950277,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ILLEGAL_SKILL_ID", Value=400950278)]
      ILLEGAL_SKILL_ID = 400950278,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FRONT_NODE_1ST", Value=400950279)]
      FRONT_NODE_1ST = 400950279,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUY_LIBERATION_LIMIT", Value=400950280)]
      BUY_LIBERATION_LIMIT = 400950280,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_SELL_FORBID", Value=400950529)]
      ITEM_SELL_FORBID = 400950529,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_OUT_OF_DATE", Value=400950530)]
      ITEM_OUT_OF_DATE = 400950530,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_SELL_NUM_ERR", Value=400950531)]
      ITEM_SELL_NUM_ERR = 400950531,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALREADY_IN_TEAM", Value=400950785)]
      ALREADY_IN_TEAM = 400950785,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAX_MEMBER_NUM", Value=400950786)]
      MAX_MEMBER_NUM = 400950786,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MEMBER_NOT_FOUND", Value=400950787)]
      MEMBER_NOT_FOUND = 400950787,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_INVALID", Value=400951041)]
      QUEST_INVALID = 400951041,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_STARTNPC_ERROR", Value=400951042)]
      QUEST_STARTNPC_ERROR = 400951042,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_ISDOING", Value=400951043)]
      QUEST_ISDOING = 400951043,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_CANNOT_ACCEPT", Value=400951044)]
      QUEST_CANNOT_ACCEPT = 400951044,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_ACCEPT_FAILED", Value=400951045)]
      QUEST_ACCEPT_FAILED = 400951045,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_NOT_DOING", Value=400951046)]
      QUEST_NOT_DOING = 400951046,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_NOT_COMPLETE", Value=400951047)]
      QUEST_NOT_COMPLETE = 400951047,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_ENDNPC_ERROR", Value=400951048)]
      QUEST_ENDNPC_ERROR = 400951048,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_REWARD_DROP_ERROR", Value=400951049)]
      QUEST_REWARD_DROP_ERROR = 400951049,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_ALREADY_ACCEPTED", Value=400951297)]
      MAIL_ALREADY_ACCEPTED = 400951297,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_NOT_FOUND", Value=400951298)]
      MAIL_NOT_FOUND = 400951298,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_HAVE_EXPIRED", Value=400951299)]
      MAIL_HAVE_EXPIRED = 400951299,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOUL_NUM_LIMIT", Value=400951553)]
      SOUL_NUM_LIMIT = 400951553,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_INDEX_NOT_FIX", Value=400951554)]
      TYPE_INDEX_NOT_FIX = 400951554,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SAME_INDEX_FORBID", Value=400951555)]
      SAME_INDEX_FORBID = 400951555,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOUL_INDEX_ILLEGAL", Value=400951556)]
      SOUL_INDEX_ILLEGAL = 400951556,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SAME_EQUIP_SOUL_FORBID", Value=400951557)]
      SAME_EQUIP_SOUL_FORBID = 400951557,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MERGE_NUM_LIMIT", Value=400951558)]
      MERGE_NUM_LIMIT = 400951558,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FOUND_SAME_SOUL", Value=400951559)]
      FOUND_SAME_SOUL = 400951559,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOUL_NOT_FOUND", Value=400951560)]
      SOUL_NOT_FOUND = 400951560,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOUL_LV_MAX", Value=400951561)]
      SOUL_LV_MAX = 400951561,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOUL_GRADE_MAX", Value=400951562)]
      SOUL_GRADE_MAX = 400951562,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOULFIGHT_REWARD_NOT_GET", Value=400951584)]
      SOULFIGHT_REWARD_NOT_GET = 400951584,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOULFIGHT_CARD_HVAE_GOT", Value=400951585)]
      SOULFIGHT_CARD_HVAE_GOT = 400951585,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOULFIGHT_INVALID_STAGE", Value=400951586)]
      SOULFIGHT_INVALID_STAGE = 400951586,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOULFIGHT_NO_BLADE", Value=400951587)]
      SOULFIGHT_NO_BLADE = 400951587,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOULFIGHT_PLAYER_NULL", Value=400951588)]
      SOULFIGHT_PLAYER_NULL = 400951588,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOULFIGHT_STAGE_ERROR", Value=400951589)]
      SOULFIGHT_STAGE_ERROR = 400951589,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOULFIGHT_COPYID_ERROR", Value=400951590)]
      SOULFIGHT_COPYID_ERROR = 400951590,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOULFIGHT_SP_NOT_ZERO", Value=400951591)]
      SOULFIGHT_SP_NOT_ZERO = 400951591,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_IS_OVER", Value=400953345)]
      BATTLE_IS_OVER = 400953345,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_HAS_CALCULATE", Value=400953346)]
      BATTLE_HAS_CALCULATE = 400953346,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_OBJECT_NOTIN", Value=400953347)]
      BATTLE_OBJECT_NOTIN = 400953347,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_CHANGESWORD_FAILED", Value=400953348)]
      BATTLE_CHANGESWORD_FAILED = 400953348,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_CROSSSCENE_FAILED", Value=400953349)]
      BATTLE_CROSSSCENE_FAILED = 400953349,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_NOTHAVEBUFF", Value=400953350)]
      BATTLE_NOTHAVEBUFF = 400953350,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_CDNOTCLEAR", Value=400953351)]
      BATTLE_CDNOTCLEAR = 400953351,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_NOTTHISSPELL", Value=400953352)]
      BATTLE_NOTTHISSPELL = 400953352,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_INSKILLCD", Value=400953353)]
      BATTLE_INSKILLCD = 400953353,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_EXPLODESWORD_NOTSKILL", Value=400953354)]
      BATTLE_EXPLODESWORD_NOTSKILL = 400953354,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_CPNOTENOUGH", Value=400953355)]
      BATTLE_CPNOTENOUGH = 400953355,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_SKILLNOTFIND", Value=400953356)]
      BATTLE_SKILLNOTFIND = 400953356,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_HASNOTBULLETINSPELL", Value=400953357)]
      BATTLE_HASNOTBULLETINSPELL = 400953357,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_NOTTHISBULLET", Value=400953358)]
      BATTLE_NOTTHISBULLET = 400953358,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_PVE_CANFIGHTAGAIN", Value=400953359)]
      BATTLE_PVE_CANFIGHTAGAIN = 400953359,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_NOTEND_FIGHTAGAIN", Value=400953360)]
      BATTLE_NOTEND_FIGHTAGAIN = 400953360,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_SOULBAG_ISFULL", Value=400953361)]
      BATTLE_SOULBAG_ISFULL = 400953361,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_SPELL_NOSUMMON", Value=400953362)]
      BATTLE_SPELL_NOSUMMON = 400953362,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_CALLSUMMON_TYPE_ERR", Value=400953363)]
      BATTLE_CALLSUMMON_TYPE_ERR = 400953363,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_RELEASEBULLET_TYPE_ERROR", Value=400953364)]
      BATTLE_RELEASEBULLET_TYPE_ERROR = 400953364,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_BUFF_NOTEXIST", Value=400953365)]
      BATTLE_BUFF_NOTEXIST = 400953365,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_REVIVE_CD_NOT", Value=400953366)]
      BATTLE_REVIVE_CD_NOT = 400953366,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_NOT_CALCULATE", Value=400953367)]
      BATTLE_NOT_CALCULATE = 400953367,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BATTLE_SEQUENCE_ERROR", Value=400953368)]
      BATTLE_SEQUENCE_ERROR = 400953368,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ARENA_IS_NOT_OPEN", Value=400953601)]
      ARENA_IS_NOT_OPEN = 400953601,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ARENA_ROLE_ILLEGAL", Value=400953602)]
      ARENA_ROLE_ILLEGAL = 400953602,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ARENA_OUT_OF_FREE_TIMES", Value=400953603)]
      ARENA_OUT_OF_FREE_TIMES = 400953603,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ARENA_IN_CD", Value=400953604)]
      ARENA_IN_CD = 400953604,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ARENA_BUY_TIMES_LIMIT", Value=400953605)]
      ARENA_BUY_TIMES_LIMIT = 400953605,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ARENA_HAVE_FREE_TIMES", Value=400953606)]
      ARENA_HAVE_FREE_TIMES = 400953606,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ARENA_HAVE_BUY_TIMES", Value=400953607)]
      ARENA_HAVE_BUY_TIMES = 400953607,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ARENA_CHALLENGE_FORBID", Value=400953608)]
      ARENA_CHALLENGE_FORBID = 400953608,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ARENA_MATCHED_ROLE_1ST", Value=400953609)]
      ARENA_MATCHED_ROLE_1ST = 400953609,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ARENA_MATCHED_TIMEOUT", Value=400953610)]
      ARENA_MATCHED_TIMEOUT = 400953610,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TRAINING_CD_NOT_END", Value=400953857)]
      TRAINING_CD_NOT_END = 400953857,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TRAINING_TIMES_LIMIT", Value=400953858)]
      TRAINING_TIMES_LIMIT = 400953858,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TRAINING_TIME_INVALID", Value=400953859)]
      TRAINING_TIME_INVALID = 400953859,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TRAINING_REQ_INVALID", Value=400953860)]
      TRAINING_REQ_INVALID = 400953860,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TRAINING_LV_NOT_STATISFY", Value=400953861)]
      TRAINING_LV_NOT_STATISFY = 400953861,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TRAINING_COPY_INVALID", Value=400953862)]
      TRAINING_COPY_INVALID = 400953862,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GACHA_REQ_INVALID", Value=400954113)]
      GACHA_REQ_INVALID = 400954113,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GACHA_GOLD_NOT_ENOUGH", Value=400954114)]
      GACHA_GOLD_NOT_ENOUGH = 400954114,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GACHA_CASH_NOT_ENOUGH", Value=400954115)]
      GACHA_CASH_NOT_ENOUGH = 400954115,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GACHA_CONF_INVALID", Value=400954116)]
      GACHA_CONF_INVALID = 400954116,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_REQ_INVALID", Value=400954369)]
      SHOP_REQ_INVALID = 400954369,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GOODS_HAVE_BUY", Value=400954370)]
      GOODS_HAVE_BUY = 400954370,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BOSS_IS_NOT_OPEN", Value=400954625)]
      BOSS_IS_NOT_OPEN = 400954625,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BOSS_OUT_OF_TIMES", Value=400954626)]
      BOSS_OUT_OF_TIMES = 400954626,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BOSS_KENSEI_RUNING", Value=400954627)]
      BOSS_KENSEI_RUNING = 400954627,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BOSS_IN_CD", Value=400954628)]
      BOSS_IN_CD = 400954628,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BOSS_CURRENT_NOT_OPEN", Value=400954629)]
      BOSS_CURRENT_NOT_OPEN = 400954629,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BOSS_ROLE_NUM_LIMIT", Value=400954630)]
      BOSS_ROLE_NUM_LIMIT = 400954630,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BOSS_YAMMY_OVER", Value=400954631)]
      BOSS_YAMMY_OVER = 400954631,
            
      [global::ProtoBuf.ProtoEnum(Name=@"KEISEI_JOIN_TIMES_LIMIT", Value=400954632)]
      KEISEI_JOIN_TIMES_LIMIT = 400954632
    }
  
}