// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct DmxDevice : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static DmxDevice GetRootAsDmxDevice(ByteBuffer _bb) { return GetRootAsDmxDevice(_bb, new DmxDevice()); }
  public static DmxDevice GetRootAsDmxDevice(ByteBuffer _bb, DmxDevice obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public DmxDevice __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Name { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(4); }
  public bool Disabled { get { int o = __p.__offset(6); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public bool TestMode { get { int o = __p.__offset(8); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public uint ChannelCount { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint SettingCount { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }

  public static Offset<DmxDevice> CreateDmxDevice(FlatBufferBuilder builder,
      StringOffset nameOffset = default(StringOffset),
      bool disabled = false,
      bool testMode = false,
      uint channelCount = 0,
      uint settingCount = 0) {
    builder.StartObject(5);
    DmxDevice.AddSettingCount(builder, settingCount);
    DmxDevice.AddChannelCount(builder, channelCount);
    DmxDevice.AddName(builder, nameOffset);
    DmxDevice.AddTestMode(builder, testMode);
    DmxDevice.AddDisabled(builder, disabled);
    return DmxDevice.EndDmxDevice(builder);
  }

  public static void StartDmxDevice(FlatBufferBuilder builder) { builder.StartObject(5); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddDisabled(FlatBufferBuilder builder, bool disabled) { builder.AddBool(1, disabled, false); }
  public static void AddTestMode(FlatBufferBuilder builder, bool testMode) { builder.AddBool(2, testMode, false); }
  public static void AddChannelCount(FlatBufferBuilder builder, uint channelCount) { builder.AddUint(3, channelCount, 0); }
  public static void AddSettingCount(FlatBufferBuilder builder, uint settingCount) { builder.AddUint(4, settingCount, 0); }
  public static Offset<DmxDevice> EndDmxDevice(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<DmxDevice>(o);
  }
};


}