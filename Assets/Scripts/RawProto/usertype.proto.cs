//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: usertype.proto
// Note: requires additional types generated from: prototype.proto
namespace Cmd
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UserBase")]
  public partial class UserBase : global::ProtoBuf.IExtensible
  {
    public UserBase() {}
    
    private ulong _userid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"userid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong userid
    {
      get { return _userid; }
      set { _userid = value; }
    }
    private byte[] _username;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"username", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] username
    {
      get { return _username; }
      set { _username = value; }
    }
    private uint _type;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint type
    {
      get { return _type; }
      set { _type = value; }
    }
    private uint _level;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint level
    {
      get { return _level; }
      set { _level = value; }
    }
    private Cmd.Avatar _avat;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"avat", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public Cmd.Avatar avat
    {
      get { return _avat; }
      set { _avat = value; }
    }
    private uint _dressid = default(uint);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"dressid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint dressid
    {
      get { return _dressid; }
      set { _dressid = value; }
    }
    private uint _dresslv = default(uint);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"dresslv", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint dresslv
    {
      get { return _dresslv; }
      set { _dresslv = value; }
    }
    private uint _bp = default(uint);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"bp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint bp
    {
      get { return _bp; }
      set { _bp = value; }
    }
    private uint _viplv = default(uint);
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"viplv", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint viplv
    {
      get { return _viplv; }
      set { _viplv = value; }
    }
    private uint _bladeid = default(uint);
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"bladeid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint bladeid
    {
      get { return _bladeid; }
      set { _bladeid = value; }
    }
    private uint _lockstage = default(uint);
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"lockstage", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint lockstage
    {
      get { return _lockstage; }
      set { _lockstage = value; }
    }
    private uint _totallike = default(uint);
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"totallike", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint totallike
    {
      get { return _totallike; }
      set { _totallike = value; }
    }
    private uint _title = default(uint);
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"title", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint title
    {
      get { return _title; }
      set { _title = value; }
    }
    private uint _unionid = default(uint);
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"unionid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint unionid
    {
      get { return _unionid; }
      set { _unionid = value; }
    }
    private byte[] _unionname = null;
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"unionname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] unionname
    {
      get { return _unionname; }
      set { _unionname = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Avatar")]
  public partial class Avatar : global::ProtoBuf.IExtensible
  {
    public Avatar() {}
    
    private uint _eye;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"eye", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint eye
    {
      get { return _eye; }
      set { _eye = value; }
    }
    private uint _nose;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"nose", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint nose
    {
      get { return _nose; }
      set { _nose = value; }
    }
    private uint _mouth;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"mouth", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint mouth
    {
      get { return _mouth; }
      set { _mouth = value; }
    }
    private uint _hair;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"hair", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint hair
    {
      get { return _hair; }
      set { _hair = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UserInfo")]
  public partial class UserInfo : global::ProtoBuf.IExtensible
  {
    public UserInfo() {}
    
    private ulong _userid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"userid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong userid
    {
      get { return _userid; }
      set { _userid = value; }
    }
    private byte[] _username;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"username", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] username
    {
      get { return _username; }
      set { _username = value; }
    }
    private uint _type;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint type
    {
      get { return _type; }
      set { _type = value; }
    }
    private ulong _accid;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"accid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong accid
    {
      get { return _accid; }
      set { _accid = value; }
    }
    private uint _mapid;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"mapid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint mapid
    {
      get { return _mapid; }
      set { _mapid = value; }
    }
    private ulong _gold;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"gold", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong gold
    {
      get { return _gold; }
      set { _gold = value; }
    }
    private uint _cash;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"cash", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint cash
    {
      get { return _cash; }
      set { _cash = value; }
    }
    private ulong _exp;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"exp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong exp
    {
      get { return _exp; }
      set { _exp = value; }
    }
    private uint _strength;
    [global::ProtoBuf.ProtoMember(11, IsRequired = true, Name=@"strength", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint strength
    {
      get { return _strength; }
      set { _strength = value; }
    }
    private uint _vipexp;
    [global::ProtoBuf.ProtoMember(12, IsRequired = true, Name=@"vipexp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint vipexp
    {
      get { return _vipexp; }
      set { _vipexp = value; }
    }
    private uint _totalpay;
    [global::ProtoBuf.ProtoMember(13, IsRequired = true, Name=@"totalpay", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint totalpay
    {
      get { return _totalpay; }
      set { _totalpay = value; }
    }
    private uint _totalconsume;
    [global::ProtoBuf.ProtoMember(14, IsRequired = true, Name=@"totalconsume", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint totalconsume
    {
      get { return _totalconsume; }
      set { _totalconsume = value; }
    }
    private ulong _moduleflag;
    [global::ProtoBuf.ProtoMember(15, IsRequired = true, Name=@"moduleflag", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong moduleflag
    {
      get { return _moduleflag; }
      set { _moduleflag = value; }
    }
    private uint _strengthtime;
    [global::ProtoBuf.ProtoMember(17, IsRequired = true, Name=@"strengthtime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint strengthtime
    {
      get { return _strengthtime; }
      set { _strengthtime = value; }
    }
    private uint _buyEnergyCount = default(uint);
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"buyEnergyCount", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint buyEnergyCount
    {
      get { return _buyEnergyCount; }
      set { _buyEnergyCount = value; }
    }
    private uint _guide = default(uint);
    [global::ProtoBuf.ProtoMember(21, IsRequired = false, Name=@"guide", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint guide
    {
      get { return _guide; }
      set { _guide = value; }
    }
    private uint _vipLevel;
    [global::ProtoBuf.ProtoMember(23, IsRequired = true, Name=@"vipLevel", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint vipLevel
    {
      get { return _vipLevel; }
      set { _vipLevel = value; }
    }
    private uint _copyStars;
    [global::ProtoBuf.ProtoMember(24, IsRequired = true, Name=@"copyStars", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint copyStars
    {
      get { return _copyStars; }
      set { _copyStars = value; }
    }
    private uint _banChat;
    [global::ProtoBuf.ProtoMember(26, IsRequired = true, Name=@"banChat", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint banChat
    {
      get { return _banChat; }
      set { _banChat = value; }
    }
    private uint _firstRecharge;
    [global::ProtoBuf.ProtoMember(28, IsRequired = true, Name=@"firstRecharge", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint firstRecharge
    {
      get { return _firstRecharge; }
      set { _firstRecharge = value; }
    }
    private uint _vipFlag;
    [global::ProtoBuf.ProtoMember(29, IsRequired = true, Name=@"vipFlag", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint vipFlag
    {
      get { return _vipFlag; }
      set { _vipFlag = value; }
    }
    private ulong _keyid;
    [global::ProtoBuf.ProtoMember(37, IsRequired = true, Name=@"keyid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong keyid
    {
      get { return _keyid; }
      set { _keyid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UserAttrPair")]
  public partial class UserAttrPair : global::ProtoBuf.IExtensible
  {
    public UserAttrPair() {}
    
    private Cmd.UserAttr _key;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"key", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Cmd.UserAttr key
    {
      get { return _key; }
      set { _key = value; }
    }
    private ulong _value;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"value", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong value
    {
      get { return _value; }
      set { _value = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BuffUnit")]
  public partial class BuffUnit : global::ProtoBuf.IExtensible
  {
    public BuffUnit() {}
    
    private uint _buffid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"buffid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint buffid
    {
      get { return _buffid; }
      set { _buffid = value; }
    }
    private ulong _acttime;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"acttime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong acttime
    {
      get { return _acttime; }
      set { _acttime = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DressRetUnit")]
  public partial class DressRetUnit : global::ProtoBuf.IExtensible
  {
    public DressRetUnit() {}
    
    private uint _dressid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"dressid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint dressid
    {
      get { return _dressid; }
      set { _dressid = value; }
    }
    private uint _lv;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"lv", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint lv
    {
      get { return _lv; }
      set { _lv = value; }
    }
    private uint _exp;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"exp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint exp
    {
      get { return _exp; }
      set { _exp = value; }
    }
    private bool _isequip;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"isequip", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool isequip
    {
      get { return _isequip; }
      set { _isequip = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BladeUnit")]
  public partial class BladeUnit : global::ProtoBuf.IExtensible
  {
    public BladeUnit() {}
    
    private uint _bladeid = default(uint);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"bladeid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint bladeid
    {
      get { return _bladeid; }
      set { _bladeid = value; }
    }
    private uint _star = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"star", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint star
    {
      get { return _star; }
      set { _star = value; }
    }
    private uint _quality = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"quality", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint quality
    {
      get { return _quality; }
      set { _quality = value; }
    }
    private uint _strengthlv = default(uint);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"strengthlv", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint strengthlv
    {
      get { return _strengthlv; }
      set { _strengthlv = value; }
    }
    private uint _equipindex = default(uint);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"equipindex", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint equipindex
    {
      get { return _equipindex; }
      set { _equipindex = value; }
    }
    private ulong _liberationnode = default(ulong);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"liberationnode", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong liberationnode
    {
      get { return _liberationnode; }
      set { _liberationnode = value; }
    }
    private uint _skillid1 = default(uint);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"skillid1", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint skillid1
    {
      get { return _skillid1; }
      set { _skillid1 = value; }
    }
    private uint _level1 = default(uint);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"level1", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint level1
    {
      get { return _level1; }
      set { _level1 = value; }
    }
    private uint _skillid2 = default(uint);
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"skillid2", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint skillid2
    {
      get { return _skillid2; }
      set { _skillid2 = value; }
    }
    private uint _level2 = default(uint);
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"level2", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint level2
    {
      get { return _level2; }
      set { _level2 = value; }
    }
    private uint _skillid3 = default(uint);
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"skillid3", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint skillid3
    {
      get { return _skillid3; }
      set { _skillid3 = value; }
    }
    private uint _level3 = default(uint);
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"level3", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint level3
    {
      get { return _level3; }
      set { _level3 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SoulCoreUnit")]
  public partial class SoulCoreUnit : global::ProtoBuf.IExtensible
  {
    public SoulCoreUnit() {}
    
    private int _maxhp = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"maxhp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int maxhp
    {
      get { return _maxhp; }
      set { _maxhp = value; }
    }
    private int _patt = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"patt", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int patt
    {
      get { return _patt; }
      set { _patt = value; }
    }
    private int _pdef = default(int);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"pdef", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int pdef
    {
      get { return _pdef; }
      set { _pdef = value; }
    }
    private int _catt = default(int);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"catt", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int catt
    {
      get { return _catt; }
      set { _catt = value; }
    }
    private int _cdef = default(int);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"cdef", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int cdef
    {
      get { return _cdef; }
      set { _cdef = value; }
    }
    private int _cpstren = default(int);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"cpstren", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int cpstren
    {
      get { return _cpstren; }
      set { _cpstren = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SoulUnit")]
  public partial class SoulUnit : global::ProtoBuf.IExtensible
  {
    public SoulUnit() {}
    
    private uint _soulid = default(uint);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"soulid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint soulid
    {
      get { return _soulid; }
      set { _soulid = value; }
    }
    private uint _star = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"star", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint star
    {
      get { return _star; }
      set { _star = value; }
    }
    private uint _lv = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"lv", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint lv
    {
      get { return _lv; }
      set { _lv = value; }
    }
    private uint _grade = default(uint);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"grade", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint grade
    {
      get { return _grade; }
      set { _grade = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ActionUnit")]
  public partial class ActionUnit : global::ProtoBuf.IExtensible
  {
    public ActionUnit() {}
    
    private uint _actionid = default(uint);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"actionid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint actionid
    {
      get { return _actionid; }
      set { _actionid = value; }
    }
    private uint _condid = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"condid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint condid
    {
      get { return _condid; }
      set { _condid = value; }
    }
    private uint _count = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint count
    {
      get { return _count; }
      set { _count = value; }
    }
    private bool _issubmit = default(bool);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"issubmit", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool issubmit
    {
      get { return _issubmit; }
      set { _issubmit = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ArenaUserBPInfo")]
  public partial class ArenaUserBPInfo : global::ProtoBuf.IExtensible
  {
    public ArenaUserBPInfo() {}
    
    private ulong _userid = default(ulong);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"userid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong userid
    {
      get { return _userid; }
      set { _userid = value; }
    }
    private uint _bp;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"bp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint bp
    {
      get { return _bp; }
      set { _bp = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ActionRankUnit")]
  public partial class ActionRankUnit : global::ProtoBuf.IExtensible
  {
    public ActionRankUnit() {}
    
    private uint _rank = default(uint);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"rank", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint rank
    {
      get { return _rank; }
      set { _rank = value; }
    }
    private ulong _uid = default(ulong);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"uid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong uid
    {
      get { return _uid; }
      set { _uid = value; }
    }
    private uint _score = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint score
    {
      get { return _score; }
      set { _score = value; }
    }
    private string _name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"TestFeedBack2Unit")]
  public partial class TestFeedBack2Unit : global::ProtoBuf.IExtensible
  {
    public TestFeedBack2Unit() {}
    
    private uint _itemid = default(uint);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"itemid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint itemid
    {
      get { return _itemid; }
      set { _itemid = value; }
    }
    private uint _count = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint count
    {
      get { return _count; }
      set { _count = value; }
    }
    private uint _flag = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"flag", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint flag
    {
      get { return _flag; }
      set { _flag = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MsgUserUnitInfo")]
  public partial class MsgUserUnitInfo : global::ProtoBuf.IExtensible
  {
    public MsgUserUnitInfo() {}
    
    private ulong _userid = default(ulong);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"userid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong userid
    {
      get { return _userid; }
      set { _userid = value; }
    }
    private string _name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private uint _bp = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"bp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint bp
    {
      get { return _bp; }
      set { _bp = value; }
    }
    private uint _point = default(uint);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"point", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint point
    {
      get { return _point; }
      set { _point = value; }
    }
    private uint _lastlogin = default(uint);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"lastlogin", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint lastlogin
    {
      get { return _lastlogin; }
      set { _lastlogin = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"TitleUnit")]
  public partial class TitleUnit : global::ProtoBuf.IExtensible
  {
    public TitleUnit() {}
    
    private uint _titleid = default(uint);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"titleid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint titleid
    {
      get { return _titleid; }
      set { _titleid = value; }
    }
    private uint _cond = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"cond", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint cond
    {
      get { return _cond; }
      set { _cond = value; }
    }
    private uint _flag = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"flag", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint flag
    {
      get { return _flag; }
      set { _flag = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"UserAttr")]
    public enum UserAttr
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_Gold", Value=12800001)]
      eUserAttr_Gold = 12800001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_Cash", Value=12800002)]
      eUserAttr_Cash = 12800002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_Exp", Value=12800003)]
      eUserAttr_Exp = 12800003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_SkillPoint", Value=12800004)]
      eUserAttr_SkillPoint = 12800004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_Strength", Value=12800005)]
      eUserAttr_Strength = 12800005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_VipExp", Value=12800006)]
      eUserAttr_VipExp = 12800006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_ReviveCoin", Value=12800009)]
      eUserAttr_ReviveCoin = 12800009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_CreditCoin", Value=12800010)]
      eUserAttr_CreditCoin = 12800010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_SoulDust", Value=12800012)]
      eUserAttr_SoulDust = 12800012,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_StrengthTime", Value=12800211)]
      eUserAttr_StrengthTime = 12800211,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_Totalpay", Value=12800308)]
      eUserAttr_Totalpay = 12800308,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_TotalGet", Value=12800309)]
      eUserAttr_TotalGet = 12800309,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_TotalConsume", Value=12800310)]
      eUserAttr_TotalConsume = 12800310,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_CopyStars", Value=12801000)]
      eUserAttr_CopyStars = 12801000,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_BSCOIN", Value=12800011)]
      eUserAttr_BSCOIN = 12800011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"eUserAttr_UNIONSPOINT", Value=12800015)]
      eUserAttr_UNIONSPOINT = 12800015
    }
  
}