// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct AddDmxRuleRangeSetting : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static AddDmxRuleRangeSetting GetRootAsAddDmxRuleRangeSetting(ByteBuffer _bb) { return GetRootAsAddDmxRuleRangeSetting(_bb, new AddDmxRuleRangeSetting()); }
  public static AddDmxRuleRangeSetting GetRootAsAddDmxRuleRangeSetting(ByteBuffer _bb, AddDmxRuleRangeSetting obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public AddDmxRuleRangeSetting __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint DeviceId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint SettingId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint ChannelId { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint RuleId { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public float On { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public float Off { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public float Start { get { int o = __p.__offset(16); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public float Step { get { int o = __p.__offset(18); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }

  public static Offset<AddDmxRuleRangeSetting> CreateAddDmxRuleRangeSetting(FlatBufferBuilder builder,
      uint deviceId = 0,
      uint settingId = 0,
      uint channelId = 0,
      uint ruleId = 0,
      float on = 0.0f,
      float off = 0.0f,
      float start = 0.0f,
      float step = 0.0f) {
    builder.StartObject(8);
    AddDmxRuleRangeSetting.AddStep(builder, step);
    AddDmxRuleRangeSetting.AddStart(builder, start);
    AddDmxRuleRangeSetting.AddOff(builder, off);
    AddDmxRuleRangeSetting.AddOn(builder, on);
    AddDmxRuleRangeSetting.AddRuleId(builder, ruleId);
    AddDmxRuleRangeSetting.AddChannelId(builder, channelId);
    AddDmxRuleRangeSetting.AddSettingId(builder, settingId);
    AddDmxRuleRangeSetting.AddDeviceId(builder, deviceId);
    return AddDmxRuleRangeSetting.EndAddDmxRuleRangeSetting(builder);
  }

  public static void StartAddDmxRuleRangeSetting(FlatBufferBuilder builder) { builder.StartObject(8); }
  public static void AddDeviceId(FlatBufferBuilder builder, uint deviceId) { builder.AddUint(0, deviceId, 0); }
  public static void AddSettingId(FlatBufferBuilder builder, uint settingId) { builder.AddUint(1, settingId, 0); }
  public static void AddChannelId(FlatBufferBuilder builder, uint channelId) { builder.AddUint(2, channelId, 0); }
  public static void AddRuleId(FlatBufferBuilder builder, uint ruleId) { builder.AddUint(3, ruleId, 0); }
  public static void AddOn(FlatBufferBuilder builder, float on) { builder.AddFloat(4, on, 0.0f); }
  public static void AddOff(FlatBufferBuilder builder, float off) { builder.AddFloat(5, off, 0.0f); }
  public static void AddStart(FlatBufferBuilder builder, float start) { builder.AddFloat(6, start, 0.0f); }
  public static void AddStep(FlatBufferBuilder builder, float step) { builder.AddFloat(7, step, 0.0f); }
  public static Offset<AddDmxRuleRangeSetting> EndAddDmxRuleRangeSetting(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<AddDmxRuleRangeSetting>(o);
  }
};


}
