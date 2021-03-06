// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol
{

using global::System;
using global::FlatBuffers;

public struct Score : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Score GetRootAsScore(ByteBuffer _bb) { return GetRootAsScore(_bb, new Score()); }
  public static Score GetRootAsScore(ByteBuffer _bb, Score obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Score __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public int Goal { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int MaxGoal { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Time { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public uint Rank { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public long Timestamp { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetLong(o + __p.bb_pos) : (long)0; } }
  public byte Level { get { int o = __p.__offset(16); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public byte World { get { int o = __p.__offset(18); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public GameMode GameMode { get { int o = __p.__offset(20); return o != 0 ? (GameMode)__p.bb.Get(o + __p.bb_pos) : GameMode.CLIMB; } }
  public Difficulty Difficulty { get { int o = __p.__offset(22); return o != 0 ? (Difficulty)__p.bb.Get(o + __p.bb_pos) : Difficulty.VERY_EASY; } }
  public EndReason Reason { get { int o = __p.__offset(24); return o != 0 ? (EndReason)__p.bb.Get(o + __p.bb_pos) : EndReason.WIN; } }
  public int GoalScore { get { int o = __p.__offset(26); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int TimeScore { get { int o = __p.__offset(28); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int TotalScore { get { int o = __p.__offset(30); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Rating { get { int o = __p.__offset(32); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int ModeSpecifcValue { get { int o = __p.__offset(34); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public Coordinates? EndPosition { get { int o = __p.__offset(36); return o != 0 ? (Coordinates?)(new Coordinates()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public byte Game { get { int o = __p.__offset(38); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public byte Hash(int j) { int o = __p.__offset(40); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int HashLength { get { int o = __p.__offset(40); return o != 0 ? __p.__vector_len(o) : 0; } }
  public ArraySegment<byte>? GetHashBytes() { return __p.__vector_as_arraysegment(40); }
  public bool Multiplayer { get { int o = __p.__offset(42); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public Initials? Initials { get { int o = __p.__offset(44); return o != 0 ? (Initials?)(new Initials()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartScore(FlatBufferBuilder builder) { builder.StartObject(21); }
  public static void AddId(FlatBufferBuilder builder, uint id) { builder.AddUint(0, id, 0); }
  public static void AddGoal(FlatBufferBuilder builder, int goal) { builder.AddInt(1, goal, 0); }
  public static void AddMaxGoal(FlatBufferBuilder builder, int maxGoal) { builder.AddInt(2, maxGoal, 0); }
  public static void AddTime(FlatBufferBuilder builder, int time) { builder.AddInt(3, time, 0); }
  public static void AddRank(FlatBufferBuilder builder, uint rank) { builder.AddUint(4, rank, 0); }
  public static void AddTimestamp(FlatBufferBuilder builder, long timestamp) { builder.AddLong(5, timestamp, 0); }
  public static void AddLevel(FlatBufferBuilder builder, byte level) { builder.AddByte(6, level, 0); }
  public static void AddWorld(FlatBufferBuilder builder, byte world) { builder.AddByte(7, world, 0); }
  public static void AddGameMode(FlatBufferBuilder builder, GameMode gameMode) { builder.AddByte(8, (byte)gameMode, 0); }
  public static void AddDifficulty(FlatBufferBuilder builder, Difficulty difficulty) { builder.AddByte(9, (byte)difficulty, 0); }
  public static void AddReason(FlatBufferBuilder builder, EndReason reason) { builder.AddByte(10, (byte)reason, 0); }
  public static void AddGoalScore(FlatBufferBuilder builder, int goalScore) { builder.AddInt(11, goalScore, 0); }
  public static void AddTimeScore(FlatBufferBuilder builder, int timeScore) { builder.AddInt(12, timeScore, 0); }
  public static void AddTotalScore(FlatBufferBuilder builder, int totalScore) { builder.AddInt(13, totalScore, 0); }
  public static void AddRating(FlatBufferBuilder builder, int rating) { builder.AddInt(14, rating, 0); }
  public static void AddModeSpecifcValue(FlatBufferBuilder builder, int modeSpecifcValue) { builder.AddInt(15, modeSpecifcValue, 0); }
  public static void AddEndPosition(FlatBufferBuilder builder, Offset<Coordinates> endPositionOffset) { builder.AddStruct(16, endPositionOffset.Value, 0); }
  public static void AddGame(FlatBufferBuilder builder, byte game) { builder.AddByte(17, game, 0); }
  public static void AddHash(FlatBufferBuilder builder, VectorOffset hashOffset) { builder.AddOffset(18, hashOffset.Value, 0); }
  public static VectorOffset CreateHashVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static void StartHashVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddMultiplayer(FlatBufferBuilder builder, bool multiplayer) { builder.AddBool(19, multiplayer, false); }
  public static void AddInitials(FlatBufferBuilder builder, Offset<Initials> initialsOffset) { builder.AddStruct(20, initialsOffset.Value, 0); }
  public static Offset<Score> EndScore(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Score>(o);
  }
};


}
