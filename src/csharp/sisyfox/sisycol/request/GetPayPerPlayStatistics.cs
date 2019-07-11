// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct GetPayPerPlayStatistics : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static GetPayPerPlayStatistics GetRootAsGetPayPerPlayStatistics(ByteBuffer _bb) { return GetRootAsGetPayPerPlayStatistics(_bb, new GetPayPerPlayStatistics()); }
  public static GetPayPerPlayStatistics GetRootAsGetPayPerPlayStatistics(ByteBuffer _bb, GetPayPerPlayStatistics obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public GetPayPerPlayStatistics __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public ulong TimestampBegin { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUlong(o + __p.bb_pos) : (ulong)0; } }
  public ulong TimestampEnd { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUlong(o + __p.bb_pos) : (ulong)0; } }
  public byte Range { get { int o = __p.__offset(8); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public uint Offset { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }

  public static Offset<GetPayPerPlayStatistics> CreateGetPayPerPlayStatistics(FlatBufferBuilder builder,
      ulong timestamp_begin = 0,
      ulong timestamp_end = 0,
      byte range = 0,
      uint offset = 0) {
    builder.StartObject(4);
    GetPayPerPlayStatistics.AddTimestampEnd(builder, timestamp_end);
    GetPayPerPlayStatistics.AddTimestampBegin(builder, timestamp_begin);
    GetPayPerPlayStatistics.AddOffset(builder, offset);
    GetPayPerPlayStatistics.AddRange(builder, range);
    return GetPayPerPlayStatistics.EndGetPayPerPlayStatistics(builder);
  }

  public static void StartGetPayPerPlayStatistics(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddTimestampBegin(FlatBufferBuilder builder, ulong timestampBegin) { builder.AddUlong(0, timestampBegin, 0); }
  public static void AddTimestampEnd(FlatBufferBuilder builder, ulong timestampEnd) { builder.AddUlong(1, timestampEnd, 0); }
  public static void AddRange(FlatBufferBuilder builder, byte range) { builder.AddByte(2, range, 0); }
  public static void AddOffset(FlatBufferBuilder builder, uint offset) { builder.AddUint(3, offset, 0); }
  public static Offset<GetPayPerPlayStatistics> EndGetPayPerPlayStatistics(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetPayPerPlayStatistics>(o);
  }
};


}
