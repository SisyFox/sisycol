// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace sisyfox.sisycol.request
{

using global::System;
using global::FlatBuffers;

public struct CreditStatus : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static CreditStatus GetRootAsCreditStatus(ByteBuffer _bb) { return GetRootAsCreditStatus(_bb, new CreditStatus()); }
  public static CreditStatus GetRootAsCreditStatus(ByteBuffer _bb, CreditStatus obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public CreditStatus __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }


  public static void StartCreditStatus(FlatBufferBuilder builder) { builder.StartObject(0); }
  public static Offset<CreditStatus> EndCreditStatus(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<CreditStatus>(o);
  }
};


}
