// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct GetUser : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static GetUser GetRootAsGetUser(ByteBuffer _bb) { return GetRootAsGetUser(_bb, new GetUser()); }
  public static GetUser GetRootAsGetUser(ByteBuffer _bb, GetUser obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public GetUser __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public User? Data { get { int o = __p.__offset(4); return o != 0 ? (User?)(new User()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }

  public static Offset<GetUser> CreateGetUser(FlatBufferBuilder builder,
      Offset<User> dataOffset = default(Offset<User>)) {
    builder.StartObject(1);
    GetUser.AddData(builder, dataOffset);
    return GetUser.EndGetUser(builder);
  }

  public static void StartGetUser(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddData(FlatBufferBuilder builder, Offset<User> dataOffset) { builder.AddOffset(0, dataOffset.Value, 0); }
  public static Offset<GetUser> EndGetUser(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GetUser>(o);
  }
};


}