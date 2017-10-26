// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol
{

using global::System;
using global::FlatBuffers;

public struct DmxDeviceChannel : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public DmxDeviceChannel __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int StorageRef { get { return __p.bb.GetInt(__p.bb_pos + 0); } }
  public uint Channel { get { return __p.bb.GetUint(__p.bb_pos + 4); } }
  public byte Test { get { return __p.bb.Get(__p.bb_pos + 8); } }
  public byte Norm { get { return __p.bb.Get(__p.bb_pos + 9); } }
  public uint RuleCount { get { return __p.bb.GetUint(__p.bb_pos + 12); } }

  public static Offset<DmxDeviceChannel> CreateDmxDeviceChannel(FlatBufferBuilder builder, int StorageRef, uint Channel, byte Test, byte Norm, uint RuleCount) {
    builder.Prep(4, 16);
    builder.PutUint(RuleCount);
    builder.Pad(2);
    builder.PutByte(Norm);
    builder.PutByte(Test);
    builder.PutUint(Channel);
    builder.PutInt(StorageRef);
    return new Offset<DmxDeviceChannel>(builder.Offset);
  }
};


}