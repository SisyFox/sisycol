// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
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

  public Device_DEPRECATED? Devices(int j) { int o = __p.__offset(4); return o != 0 ? (Device_DEPRECATED?)(new Device_DEPRECATED()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DevicesLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<GetDetectedDevices_DEPRECATED> CreateGetDetectedDevices_DEPRECATED(FlatBufferBuilder builder,
      VectorOffset devicesOffset = default(VectorOffset)) {
    builder.StartObject(1);
    GetDetectedDevices_DEPRECATED.AddDevices(builder, devicesOffset);
    return GetDetectedDevices_DEPRECATED.EndGetDetectedDevices_DEPRECATED(builder);
  }

  public static void StartGetDetectedDevices_DEPRECATED(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddDevices(FlatBufferBuilder builder, VectorOffset devicesOffset) { builder.AddOffset(0, devicesOffset.Value, 0); }
  public static VectorOffset CreateDevicesVector(FlatBufferBuilder builder, Offset<Device_DEPRECATED>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartDevicesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<GetDetectedDevices_DEPRECATED> EndGetDetectedDevices_DEPRECATED(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetDetectedDevices_DEPRECATED>(o);
  }
};


}