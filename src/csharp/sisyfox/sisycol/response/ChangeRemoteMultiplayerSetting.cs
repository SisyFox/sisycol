// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct ChangeRemoteMultiplayerSetting : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static ChangeRemoteMultiplayerSetting GetRootAsChangeRemoteMultiplayerSetting(ByteBuffer _bb) { return GetRootAsChangeRemoteMultiplayerSetting(_bb, new ChangeRemoteMultiplayerSetting()); }
  public static ChangeRemoteMultiplayerSetting GetRootAsChangeRemoteMultiplayerSetting(ByteBuffer _bb, ChangeRemoteMultiplayerSetting obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public ChangeRemoteMultiplayerSetting __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }


  public static void StartChangeRemoteMultiplayerSetting(FlatBufferBuilder builder) { builder.StartObject(0); }
  public static Offset<ChangeRemoteMultiplayerSetting> EndChangeRemoteMultiplayerSetting(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ChangeRemoteMultiplayerSetting>(o);
  }
};


}
