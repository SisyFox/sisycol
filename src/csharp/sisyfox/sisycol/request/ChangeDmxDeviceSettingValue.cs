// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct ChangeDmxDeviceSettingValue : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static ChangeDmxDeviceSettingValue GetRootAsChangeDmxDeviceSettingValue(ByteBuffer _bb) { return GetRootAsChangeDmxDeviceSettingValue(_bb, new ChangeDmxDeviceSettingValue()); }
  public static ChangeDmxDeviceSettingValue GetRootAsChangeDmxDeviceSettingValue(ByteBuffer _bb, ChangeDmxDeviceSettingValue obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public ChangeDmxDeviceSettingValue __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint DeviceId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint SettingId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public sbyte Value { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetSbyte(o + __p.bb_pos) : (sbyte)0; } }

  public static Offset<ChangeDmxDeviceSettingValue> CreateChangeDmxDeviceSettingValue(FlatBufferBuilder builder,
      uint deviceId = 0,
      uint settingId = 0,
      sbyte value = 0) {
    builder.StartObject(3);
    ChangeDmxDeviceSettingValue.AddSettingId(builder, settingId);
    ChangeDmxDeviceSettingValue.AddDeviceId(builder, deviceId);
    ChangeDmxDeviceSettingValue.AddValue(builder, value);
    return ChangeDmxDeviceSettingValue.EndChangeDmxDeviceSettingValue(builder);
  }

  public static void StartChangeDmxDeviceSettingValue(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddDeviceId(FlatBufferBuilder builder, uint deviceId) { builder.AddUint(0, deviceId, 0); }
  public static void AddSettingId(FlatBufferBuilder builder, uint settingId) { builder.AddUint(1, settingId, 0); }
  public static void AddValue(FlatBufferBuilder builder, sbyte value) { builder.AddSbyte(2, value, 0); }
  public static Offset<ChangeDmxDeviceSettingValue> EndChangeDmxDeviceSettingValue(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ChangeDmxDeviceSettingValue>(o);
  }
};


}