// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct GetLocation : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static GetLocation GetRootAsGetLocation(ByteBuffer _bb) { return GetRootAsGetLocation(_bb, new GetLocation()); }
  public static GetLocation GetRootAsGetLocation(ByteBuffer _bb, GetLocation obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public GetLocation __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Name { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(4); }

  public static Offset<GetLocation> CreateGetLocation(FlatBufferBuilder builder,
      StringOffset nameOffset = default(StringOffset)) {
    builder.StartObject(1);
    GetLocation.AddName(builder, nameOffset);
    return GetLocation.EndGetLocation(builder);
  }

  public static void StartGetLocation(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static Offset<GetLocation> EndGetLocation(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetLocation>(o);
  }
};


}
