// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct AddRule : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static AddRule GetRootAsAddRule(ByteBuffer _bb) { return GetRootAsAddRule(_bb, new AddRule()); }
  public static AddRule GetRootAsAddRule(ByteBuffer _bb, AddRule obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public AddRule __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }

  public static Offset<AddRule> CreateAddRule(FlatBufferBuilder builder,
      uint id = 0) {
    builder.StartObject(1);
    AddRule.AddId(builder, id);
    return AddRule.EndAddRule(builder);
  }

  public static void StartAddRule(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddId(FlatBufferBuilder builder, uint id) { builder.AddUint(0, id, 0); }
  public static Offset<AddRule> EndAddRule(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<AddRule>(o);
  }
};


}
