// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct GetDetectedDevices_DEPRECATED : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static GetDetectedDevices_DEPRECATED GetRootAsGetDetectedDevices_DEPRECATED(ByteBuffer _bb) { return GetRootAsGetDetectedDevices_DEPRECATED(_bb, new GetDetectedDevices_DEPRECATED()); }
  public static GetDetectedDevices_DEPRECATED GetRootAsGetDetectedDevices_DEPRECATED(ByteBuffer _bb, GetDetectedDevices_DEPRECATED obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public GetDetectedDevices_DEPRECATED __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }


  public static void StartGetDetectedDevices_DEPRECATED(FlatBufferBuilder builder) { builder.StartObject(0); }
  public static Offset<GetDetectedDevices_DEPRECATED> EndGetDetectedDevices_DEPRECATED(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetDetectedDevices_DEPRECATED>(o);
  }
};


}