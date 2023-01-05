// Decompiled with JetBrains decompiler
// Type: ProxyBase.Spell
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;

namespace ProxyBase
{
  public class Spell
  {
    public string Name { get; set; }

    public int CastLines { get; set; }

    public int SpellSlot { get; set; }

    public string[] Captions { get; set; }

    public DateTime NextUse { get; set; }

    public int CurrentLevel { get; set; }

    public int MaximumLevel { get; set; }

    public string Prompt { get; set; }

    public int Type { get; set; }

    public int Icon { get; set; }

    public Spell()
    {
      this.Captions = new string[10];
      this.NextUse = DateTime.UtcNow;
    }

    public override string ToString()
    {
      return string.Format("{0} (Lev:{1}/{2})", (object) this.Name, (object) this.CurrentLevel, (object) this.MaximumLevel);
    }
  }
}
