// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct SetLiveData : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static SetLiveData GetRootAsSetLiveData(ByteBuffer _bb) { return GetRootAsSetLiveData(_bb, new SetLiveData()); }
  public static SetLiveData GetRootAsSetLiveData(ByteBuffer _bb, SetLiveData obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public SetLiveData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public sisyfox.sisycol.LiveData? LiveData { get { int o = __p.__offset(4); return o != 0 ? (sisyfox.sisycol.LiveData?)(new sisyfox.sisycol.LiveData()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartSetLiveData(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddLiveData(FlatBufferBuilder builder, Offset<sisyfox.sisycol.LiveData> liveDataOffset) { builder.AddStruct(0, liveDataOffset.Value, 0); }
  public static Offset<SetLiveData> EndSetLiveData(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<SetLiveData>(o);
  }
};


}
