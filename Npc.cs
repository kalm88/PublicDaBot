// Decompiled with JetBrains decompiler
// Type: ProxyBase.Npc
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

namespace ProxyBase
{
  public class Npc : Character
  {
    public int Image { get; set; }

    public Npc.NpcType Type { get; set; }

    public byte Color { get; set; }

    public enum NpcType
    {
      NormalMonster,
      PassableMonster,
      Mundane,
      Item,
    }
  }
}
