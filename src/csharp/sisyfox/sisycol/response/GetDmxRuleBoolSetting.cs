// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct GetDmxRuleBoolSetting : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static GetDmxRuleBoolSetting GetRootAsGetDmxRuleBoolSetting(ByteBuffer _bb) { return GetRootAsGetDmxRuleBoolSetting(_bb, new GetDmxRuleBoolSetting()); }
  public static GetDmxRuleBoolSetting GetRootAsGetDmxRuleBoolSetting(ByteBuffer _bb, GetDmxRuleBoolSetting obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public GetDmxRuleBoolSetting __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint DeviceId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint SettingId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint RuleSettingId { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public sisyfox.sisycol.DmxRuleBoolSetting? RuleSetting { get { int o = __p.__offset(10); return o != 0 ? (sisyfox.sisycol.DmxRuleBoolSetting?)(new sisyfox.sisycol.DmxRuleBoolSetting()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartGetDmxRuleBoolSetting(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddDeviceId(FlatBufferBuilder builder, uint deviceId) { builder.AddUint(0, deviceId, 0); }
  public static void AddSettingId(FlatBufferBuilder builder, uint settingId) { builder.AddUint(1, settingId, 0); }
  public static void AddRuleSettingId(FlatBufferBuilder builder, uint ruleSettingId) { builder.AddUint(2, ruleSettingId, 0); }
  public static void AddRuleSetting(FlatBufferBuilder builder, Offset<sisyfox.sisycol.DmxRuleBoolSetting> ruleSettingOffset) { builder.AddStruct(3, ruleSettingOffset.Value, 0); }
  public static Offset<GetDmxRuleBoolSetting> EndGetDmxRuleBoolSetting(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetDmxRuleBoolSetting>(o);
  }
};


}