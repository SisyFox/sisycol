// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct AddDmxChannelRule : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static AddDmxChannelRule GetRootAsAddDmxChannelRule(ByteBuffer _bb) { return GetRootAsAddDmxChannelRule(_bb, new AddDmxChannelRule()); }
  public static AddDmxChannelRule GetRootAsAddDmxChannelRule(ByteBuffer _bb, AddDmxChannelRule obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public AddDmxChannelRule __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint DeviceId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint ChannelId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint RuleId { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }

  public static Offset<AddDmxChannelRule> CreateAddDmxChannelRule(FlatBufferBuilder builder,
      uint deviceId = 0,
      uint channelId = 0,
      uint ruleId = 0) {
    builder.StartObject(3);
    AddDmxChannelRule.AddRuleId(builder, ruleId);
    AddDmxChannelRule.AddChannelId(builder, channelId);
    AddDmxChannelRule.AddDeviceId(builder, deviceId);
    return AddDmxChannelRule.EndAddDmxChannelRule(builder);
  }

  public static void StartAddDmxChannelRule(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddDeviceId(FlatBufferBuilder builder, uint deviceId) { builder.AddUint(0, deviceId, 0); }
  public static void AddChannelId(FlatBufferBuilder builder, uint channelId) { builder.AddUint(1, channelId, 0); }
  public static void AddRuleId(FlatBufferBuilder builder, uint ruleId) { builder.AddUint(2, ruleId, 0); }
  public static Offset<AddDmxChannelRule> EndAddDmxChannelRule(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<AddDmxChannelRule>(o);
  }
};


}