// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol
{

using global::System;
using global::FlatBuffers;

public struct DmxRuleBoolSetting : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public DmxRuleBoolSetting __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int StorageRef { get { return __p.bb.GetInt(__p.bb_pos + 0); } }
  public uint Channel { get { return __p.bb.GetUint(__p.bb_pos + 4); } }
  public uint RuleNo { get { return __p.bb.GetUint(__p.bb_pos + 8); } }
  public int On { get { return __p.bb.GetInt(__p.bb_pos + 12); } }
  public int Off { get { return __p.bb.GetInt(__p.bb_pos + 16); } }
  public byte Start { get { return __p.bb.Get(__p.bb_pos + 20); } }
  public float Step { get { return __p.bb.GetFloat(__p.bb_pos + 24); } }

  public static Offset<DmxRuleBoolSetting> CreateDmxRuleBoolSetting(FlatBufferBuilder builder, int StorageRef, uint Channel, uint RuleNo, int On, int Off, byte Start, float Step) {
    builder.Prep(4, 28);
    builder.PutFloat(Step);
    builder.Pad(3);
    builder.PutByte(Start);
    builder.PutInt(Off);
    builder.PutInt(On);
    builder.PutUint(RuleNo);
    builder.PutUint(Channel);
    builder.PutInt(StorageRef);
    return new Offset<DmxRuleBoolSetting>(builder.Offset);
  }
};


}