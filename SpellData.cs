// Decompiled with JetBrains decompiler
// Type: ProxyBase.SpellData
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

namespace ProxyBase
{
  public class SpellData
  {
    public string Name { get; set; }

    public int ManaCost { get; set; }

    public int BaseLines { get; set; }

    public SpellData(string name, int manacost, int baselines)
    {
      this.Name = name;
      this.ManaCost = manacost;
      this.BaseLines = baselines;
    }
  }
}
