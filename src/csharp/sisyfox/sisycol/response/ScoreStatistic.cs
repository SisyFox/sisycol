// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.response
{

using global::System;
using global::FlatBuffers;

public struct ScoreStatistic : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static ScoreStatistic GetRootAsScoreStatistic(ByteBuffer _bb) { return GetRootAsScoreStatistic(_bb, new ScoreStatistic()); }
  public static ScoreStatistic GetRootAsScoreStatistic(ByteBuffer _bb, ScoreStatistic obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public ScoreStatistic __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public ulong Timestamp { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUlong(o + __p.bb_pos) : (ulong)0; } }
  public byte Game { get { int o = __p.__offset(6); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public sisyfox.sisycol.GameMode GameMode { get { int o = __p.__offset(8); return o != 0 ? (sisyfox.sisycol.GameMode)__p.bb.Get(o + __p.bb_pos) : sisyfox.sisycol.GameMode.CLIMB; } }
  public uint Playtime { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint GamesCount { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }

  public static Offset<ScoreStatistic> CreateScoreStatistic(FlatBufferBuilder builder,
      ulong timestamp = 0,
      byte game = 0,
      sisyfox.sisycol.GameMode gameMode = sisyfox.sisycol.GameMode.CLIMB,
      uint playtime = 0,
      uint gamesCount = 0) {
    builder.StartObject(5);
    ScoreStatistic.AddTimestamp(builder, timestamp);
    ScoreStatistic.AddGamesCount(builder, gamesCount);
    ScoreStatistic.AddPlaytime(builder, playtime);
    ScoreStatistic.AddGameMode(builder, gameMode);
    ScoreStatistic.AddGame(builder, game);
    return ScoreStatistic.EndScoreStatistic(builder);
  }

  public static void StartScoreStatistic(FlatBufferBuilder builder) { builder.StartObject(5); }
  public static void AddTimestamp(FlatBufferBuilder builder, ulong timestamp) { builder.AddUlong(0, timestamp, 0); }
  public static void AddGame(FlatBufferBuilder builder, byte game) { builder.AddByte(1, game, 0); }
  public static void AddGameMode(FlatBufferBuilder builder, sisyfox.sisycol.GameMode gameMode) { builder.AddByte(2, (byte)gameMode, 0); }
  public static void AddPlaytime(FlatBufferBuilder builder, uint playtime) { builder.AddUint(3, playtime, 0); }
  public static void AddGamesCount(FlatBufferBuilder builder, uint gamesCount) { builder.AddUint(4, gamesCount, 0); }
  public static Offset<ScoreStatistic> EndScoreStatistic(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ScoreStatistic>(o);
  }
};


}
