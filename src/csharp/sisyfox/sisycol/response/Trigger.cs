// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct Trigger : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Trigger GetRootAsTrigger(ByteBuffer _bb) { return GetRootAsTrigger(_bb, new Trigger()); }
  public static Trigger GetRootAsTrigger(ByteBuffer _bb, Trigger obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Trigger __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public sisyfox.sisycol.TriggerType Type { get { int o = __p.__offset(4); return o != 0 ? (sisyfox.sisycol.TriggerType)__p.bb.Get(o + __p.bb_pos) : sisyfox.sisycol.TriggerType.NEW_ROUND; } }

  public static Offset<Trigger> CreateTrigger(FlatBufferBuilder builder,
      sisyfox.sisycol.TriggerType type = sisyfox.sisycol.TriggerType.NEW_ROUND) {
    builder.StartObject(1);
    Trigger.AddType(builder, type);
    return Trigger.EndTrigger(builder);
  }

  public static void StartTrigger(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddType(FlatBufferBuilder builder, sisyfox.sisycol.TriggerType type) { builder.AddByte(0, (byte)type, 0); }
  public static Offset<Trigger> EndTrigger(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Trigger>(o);
  }
};


}
