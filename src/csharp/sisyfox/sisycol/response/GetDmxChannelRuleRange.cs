// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct GetDmxChannelRuleRange : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static GetDmxChannelRuleRange GetRootAsGetDmxChannelRuleRange(ByteBuffer _bb) { return GetRootAsGetDmxChannelRuleRange(_bb, new GetDmxChannelRuleRange()); }
  public static GetDmxChannelRuleRange GetRootAsGetDmxChannelRuleRange(ByteBuffer _bb, GetDmxChannelRuleRange obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public GetDmxChannelRuleRange __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint DeviceId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint ChannelId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint RuleId { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public sisyfox.sisycol.DmxChannelRule? Rule(int j) { int o = __p.__offset(10); return o != 0 ? (sisyfox.sisycol.DmxChannelRule?)(new sisyfox.sisycol.DmxChannelRule()).__assign(__p.__vector(o) + j * 36, __p.bb) : null; }
  public int RuleLength { get { int o = __p.__offset(10); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<GetDmxChannelRuleRange> CreateGetDmxChannelRuleRange(FlatBufferBuilder builder,
      uint deviceId = 0,
      uint channelId = 0,
      uint ruleId = 0,
      VectorOffset ruleOffset = default(VectorOffset)) {
    builder.StartObject(4);
    GetDmxChannelRuleRange.AddRule(builder, ruleOffset);
    GetDmxChannelRuleRange.AddRuleId(builder, ruleId);
    GetDmxChannelRuleRange.AddChannelId(builder, channelId);
    GetDmxChannelRuleRange.AddDeviceId(builder, deviceId);
    return GetDmxChannelRuleRange.EndGetDmxChannelRuleRange(builder);
  }

  public static void StartGetDmxChannelRuleRange(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddDeviceId(FlatBufferBuilder builder, uint deviceId) { builder.AddUint(0, deviceId, 0); }
  public static void AddChannelId(FlatBufferBuilder builder, uint channelId) { builder.AddUint(1, channelId, 0); }
  public static void AddRuleId(FlatBufferBuilder builder, uint ruleId) { builder.AddUint(2, ruleId, 0); }
  public static void AddRule(FlatBufferBuilder builder, VectorOffset ruleOffset) { builder.AddOffset(3, ruleOffset.Value, 0); }
  public static void StartRuleVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(36, numElems, 4); }
  public static Offset<GetDmxChannelRuleRange> EndGetDmxChannelRuleRange(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetDmxChannelRuleRange>(o);
  }
};


}
