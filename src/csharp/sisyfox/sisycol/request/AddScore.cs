// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct AddScore : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static AddScore GetRootAsAddScore(ByteBuffer _bb) { return GetRootAsAddScore(_bb, new AddScore()); }
  public static AddScore GetRootAsAddScore(ByteBuffer _bb, AddScore obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public AddScore __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Goal { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int MaxGoal { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Time { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public sisyfox.sisycol.EndReason Reason { get { int o = __p.__offset(10); return o != 0 ? (sisyfox.sisycol.EndReason)__p.bb.Get(o + __p.bb_pos) : sisyfox.sisycol.EndReason.WIN; } }
  public byte Level { get { int o = __p.__offset(12); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public byte World { get { int o = __p.__offset(14); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public sisyfox.sisycol.GameMode GameMode { get { int o = __p.__offset(16); return o != 0 ? (sisyfox.sisycol.GameMode)__p.bb.Get(o + __p.bb_pos) : sisyfox.sisycol.GameMode.CLIMB; } }
  public sisyfox.sisycol.Difficulty Difficulty { get { int o = __p.__offset(18); return o != 0 ? (sisyfox.sisycol.Difficulty)__p.bb.Get(o + __p.bb_pos) : sisyfox.sisycol.Difficulty.VERY_EASY; } }
  public int ModeSpecificValue { get { int o = __p.__offset(20); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public sisyfox.sisycol.Coordinates? EndPosition { get { int o = __p.__offset(22); return o != 0 ? (sisyfox.sisycol.Coordinates?)(new sisyfox.sisycol.Coordinates()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public byte Game { get { int o = __p.__offset(24); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public byte Hash(int j) { int o = __p.__offset(26); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int HashLength { get { int o = __p.__offset(26); return o != 0 ? __p.__vector_len(o) : 0; } }
  public ArraySegment<byte>? GetHashBytes() { return __p.__vector_as_arraysegment(26); }
  public bool Multiplayer { get { int o = __p.__offset(28); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }

  public static void StartAddScore(FlatBufferBuilder builder) { builder.StartObject(13); }
  public static void AddGoal(FlatBufferBuilder builder, int goal) { builder.AddInt(0, goal, 0); }
  public static void AddMaxGoal(FlatBufferBuilder builder, int maxGoal) { builder.AddInt(1, maxGoal, 0); }
  public static void AddTime(FlatBufferBuilder builder, int time) { builder.AddInt(2, time, 0); }
  public static void AddReason(FlatBufferBuilder builder, sisyfox.sisycol.EndReason reason) { builder.AddByte(3, (byte)reason, 0); }
  public static void AddLevel(FlatBufferBuilder builder, byte level) { builder.AddByte(4, level, 0); }
  public static void AddWorld(FlatBufferBuilder builder, byte world) { builder.AddByte(5, world, 0); }
  public static void AddGameMode(FlatBufferBuilder builder, sisyfox.sisycol.GameMode gameMode) { builder.AddByte(6, (byte)gameMode, 0); }
  public static void AddDifficulty(FlatBufferBuilder builder, sisyfox.sisycol.Difficulty difficulty) { builder.AddByte(7, (byte)difficulty, 0); }
  public static void AddModeSpecificValue(FlatBufferBuilder builder, int modeSpecificValue) { builder.AddInt(8, modeSpecificValue, 0); }
  public static void AddEndPosition(FlatBufferBuilder builder, Offset<sisyfox.sisycol.Coordinates> endPositionOffset) { builder.AddStruct(9, endPositionOffset.Value, 0); }
  public static void AddGame(FlatBufferBuilder builder, byte game) { builder.AddByte(10, game, 0); }
  public static void AddHash(FlatBufferBuilder builder, VectorOffset hashOffset) { builder.AddOffset(11, hashOffset.Value, 0); }
  public static VectorOffset CreateHashVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static void StartHashVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddMultiplayer(FlatBufferBuilder builder, bool multiplayer) { builder.AddBool(12, multiplayer, false); }
  public static Offset<AddScore> EndAddScore(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<AddScore>(o);
  }
};


}
