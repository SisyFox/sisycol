// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct GetLiveData : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static GetLiveData GetRootAsGetLiveData(ByteBuffer _bb) { return GetRootAsGetLiveData(_bb, new GetLiveData()); }
  public static GetLiveData GetRootAsGetLiveData(ByteBuffer _bb, GetLiveData obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public GetLiveData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }


  public static void StartGetLiveData(FlatBufferBuilder builder) { builder.StartObject(0); }
  public static Offset<GetLiveData> EndGetLiveData(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetLiveData>(o);
  }
};


}
