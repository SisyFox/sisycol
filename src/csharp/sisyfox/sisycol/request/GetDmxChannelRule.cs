// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct GetDmxChannelRule : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static GetDmxChannelRule GetRootAsGetDmxChannelRule(ByteBuffer _bb) { return GetRootAsGetDmxChannelRule(_bb, new GetDmxChannelRule()); }
  public static GetDmxChannelRule GetRootAsGetDmxChannelRule(ByteBuffer _bb, GetDmxChannelRule obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public GetDmxChannelRule __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint DeviceId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint ChannelId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint RuleId { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }

  public static Offset<GetDmxChannelRule> CreateGetDmxChannelRule(FlatBufferBuilder builder,
      uint deviceId = 0,
      uint channelId = 0,
      uint ruleId = 0) {
    builder.StartObject(3);
    GetDmxChannelRule.AddRuleId(builder, ruleId);
    GetDmxChannelRule.AddChannelId(builder, channelId);
    GetDmxChannelRule.AddDeviceId(builder, deviceId);
    return GetDmxChannelRule.EndGetDmxChannelRule(builder);
  }

  public static void StartGetDmxChannelRule(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddDeviceId(FlatBufferBuilder builder, uint deviceId) { builder.AddUint(0, deviceId, 0); }
  public static void AddChannelId(FlatBufferBuilder builder, uint channelId) { builder.AddUint(1, channelId, 0); }
  public static void AddRuleId(FlatBufferBuilder builder, uint ruleId) { builder.AddUint(2, ruleId, 0); }
  public static Offset<GetDmxChannelRule> EndGetDmxChannelRule(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetDmxChannelRule>(o);
  }
};


}