// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct GetScoreRange : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static GetScoreRange GetRootAsGetScoreRange(ByteBuffer _bb) { return GetRootAsGetScoreRange(_bb, new GetScoreRange()); }
  public static GetScoreRange GetRootAsGetScoreRange(ByteBuffer _bb, GetScoreRange obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public GetScoreRange __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public sisyfox.sisycol.Score? Data(int j) { int o = __p.__offset(4); return o != 0 ? (sisyfox.sisycol.Score?)(new sisyfox.sisycol.Score()).__assign(__p.__vector(o) + j * 56, __p.bb) : null; }
  public int DataLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<GetScoreRange> CreateGetScoreRange(FlatBufferBuilder builder,
      VectorOffset dataOffset = default(VectorOffset)) {
    builder.StartObject(1);
    GetScoreRange.AddData(builder, dataOffset);
    return GetScoreRange.EndGetScoreRange(builder);
  }

  public static void StartGetScoreRange(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddData(FlatBufferBuilder builder, VectorOffset dataOffset) { builder.AddOffset(0, dataOffset.Value, 0); }
  public static void StartDataVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(56, numElems, 8); }
  public static Offset<GetScoreRange> EndGetScoreRange(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetScoreRange>(o);
  }
};


}