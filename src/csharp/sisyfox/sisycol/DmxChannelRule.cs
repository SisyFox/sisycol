// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol
{

using global::System;
using global::FlatBuffers;

public struct DmxChannelRule : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public DmxChannelRule __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int StorageRef { get { return __p.bb.GetInt(__p.bb_pos + 0); } }
  public DmxChannelRuleType Type { get { return (DmxChannelRuleType)__p.bb.GetSbyte(__p.bb_pos + 4); } }
  public int On { get { return __p.bb.GetInt(__p.bb_pos + 8); } }
  public int CalcOn { get { return __p.bb.GetInt(__p.bb_pos + 12); } }
  public int Off { get { return __p.bb.GetInt(__p.bb_pos + 16); } }
  public int CalcOff { get { return __p.bb.GetInt(__p.bb_pos + 20); } }
  public byte Start { get { return __p.bb.Get(__p.bb_pos + 24); } }
  public byte CalcStart { get { return __p.bb.Get(__p.bb_pos + 25); } }
  public float Step { get { return __p.bb.GetFloat(__p.bb_pos + 28); } }
  public float CalcStep { get { return __p.bb.GetFloat(__p.bb_pos + 32); } }

  public static Offset<DmxChannelRule> CreateDmxChannelRule(FlatBufferBuilder builder, int StorageRef, DmxChannelRuleType Type, int On, int CalcOn, int Off, int CalcOff, byte Start, byte CalcStart, float Step, float CalcStep) {
    builder.Prep(4, 36);
    builder.PutFloat(CalcStep);
    builder.PutFloat(Step);
    builder.Pad(2);
    builder.PutByte(CalcStart);
    builder.PutByte(Start);
    builder.PutInt(CalcOff);
    builder.PutInt(Off);
    builder.PutInt(CalcOn);
    builder.PutInt(On);
    builder.Pad(3);
    builder.PutSbyte((sbyte)Type);
    builder.PutInt(StorageRef);
    return new Offset<DmxChannelRule>(builder.Offset);
  }
};


}