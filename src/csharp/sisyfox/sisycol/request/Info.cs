// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct Info : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Info GetRootAsInfo(ByteBuffer _bb) { return GetRootAsInfo(_bb, new Info()); }
  public static Info GetRootAsInfo(ByteBuffer _bb, Info obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Info __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }


  public static void StartInfo(FlatBufferBuilder builder) { builder.StartObject(0); }
  public static Offset<Info> EndInfo(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Info>(o);
  }
};


}