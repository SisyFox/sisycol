// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct GetSetting : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static GetSetting GetRootAsGetSetting(ByteBuffer _bb) { return GetRootAsGetSetting(_bb, new GetSetting()); }
  public static GetSetting GetRootAsGetSetting(ByteBuffer _bb, GetSetting obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public GetSetting __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public sisyfox.sisycol.SettingType Type { get { int o = __p.__offset(4); return o != 0 ? (sisyfox.sisycol.SettingType)__p.bb.Get(o + __p.bb_pos) : sisyfox.sisycol.SettingType.GAME_LANGUAGE; } }

  public static Offset<GetSetting> CreateGetSetting(FlatBufferBuilder builder,
      sisyfox.sisycol.SettingType type = sisyfox.sisycol.SettingType.GAME_LANGUAGE) {
    builder.StartObject(1);
    GetSetting.AddType(builder, type);
    return GetSetting.EndGetSetting(builder);
  }

  public static void StartGetSetting(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddType(FlatBufferBuilder builder, sisyfox.sisycol.SettingType type) { builder.AddByte(0, (byte)type, 0); }
  public static Offset<GetSetting> EndGetSetting(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetSetting>(o);
  }
};


}
