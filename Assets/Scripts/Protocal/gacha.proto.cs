//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: gacha.proto
// Note: requires additional types generated from: basetype.proto
// Note: requires additional types generated from: itemtype.proto
namespace Cmd
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BladeIndexChip")]
  public partial class BladeIndexChip : global::ProtoBuf.IExtensible
  {
    public BladeIndexChip() {}
    
    private uint _index = default(uint);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"index", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint index
    {
      get { return _index; }
      set { _index = value; }
    }
    private uint _itemid = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"itemid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint itemid
    {
      get { return _itemid; }
      set { _itemid = value; }
    }
    private uint _count = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint count
    {
      get { return _count; }
      set { _count = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MessageGachaInfoReq")]
  public partial class MessageGachaInfoReq : global::ProtoBuf.IExtensible
  {
    public MessageGachaInfoReq() {}
    
    private Cmd.EProtoId _id = Cmd.EProtoId.GACHA_INFO_REQ;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Cmd.EProtoId.GACHA_INFO_REQ)]
    public Cmd.EProtoId id
    {
      get { return _id; }
      set { _id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MessageGachaInfoRet")]
  public partial class MessageGachaInfoRet : global::ProtoBuf.IExtensible
  {
    public MessageGachaInfoRet() {}
    
    private Cmd.EProtoId _id = Cmd.EProtoId.GACHA_INFO_RET;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Cmd.EProtoId.GACHA_INFO_RET)]
    public Cmd.EProtoId id
    {
      get { return _id; }
      set { _id = value; }
    }
    private uint _goldTimes = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"goldTimes", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint goldTimes
    {
      get { return _goldTimes; }
      set { _goldTimes = value; }
    }
    private uint _goldCd = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"goldCd", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint goldCd
    {
      get { return _goldCd; }
      set { _goldCd = value; }
    }
    private uint _cashCd = default(uint);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"cashCd", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint cashCd
    {
      get { return _cashCd; }
      set { _cashCd = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MessageGachaExecReq")]
  public partial class MessageGachaExecReq : global::ProtoBuf.IExtensible
  {
    public MessageGachaExecReq() {}
    
    private Cmd.EProtoId _id = Cmd.EProtoId.GACHA_EXEC_REQ;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Cmd.EProtoId.GACHA_EXEC_REQ)]
    public Cmd.EProtoId id
    {
      get { return _id; }
      set { _id = value; }
    }
    private Cmd.EGachaType _gachaType;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"gachaType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Cmd.EGachaType gachaType
    {
      get { return _gachaType; }
      set { _gachaType = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MessageGachaExecRet")]
  public partial class MessageGachaExecRet : global::ProtoBuf.IExtensible
  {
    public MessageGachaExecRet() {}
    
    private Cmd.EProtoId _id = Cmd.EProtoId.GACHA_EXEC_RET;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Cmd.EProtoId.GACHA_EXEC_RET)]
    public Cmd.EProtoId id
    {
      get { return _id; }
      set { _id = value; }
    }
    private uint _count = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint count
    {
      get { return _count; }
      set { _count = value; }
    }
    private readonly global::System.Collections.Generic.List<Cmd.ItemNotiType> _items = new global::System.Collections.Generic.List<Cmd.ItemNotiType>();
    [global::ProtoBuf.ProtoMember(3, Name=@"items", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Cmd.ItemNotiType> items
    {
      get { return _items; }
    }
  
    private readonly global::System.Collections.Generic.List<Cmd.BladeIndexChip> _chips = new global::System.Collections.Generic.List<Cmd.BladeIndexChip>();
    [global::ProtoBuf.ProtoMember(4, Name=@"chips", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Cmd.BladeIndexChip> chips
    {
      get { return _chips; }
    }
  
    private readonly global::System.Collections.Generic.List<uint> _firstShow = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(5, Name=@"firstShow", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> firstShow
    {
      get { return _firstShow; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"EGachaType")]
    public enum EGachaType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"GACHA_TYPE_GOLD_1", Value=1)]
      GACHA_TYPE_GOLD_1 = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GACHA_TYPE_GOLD_10", Value=2)]
      GACHA_TYPE_GOLD_10 = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GACHA_TYPE_CASH_1", Value=3)]
      GACHA_TYPE_CASH_1 = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GACHA_TYPE_CASH_10", Value=4)]
      GACHA_TYPE_CASH_10 = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GACHA_TYPE_VIP", Value=5)]
      GACHA_TYPE_VIP = 5
    }
  
}