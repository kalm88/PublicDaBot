// Decompiled with JetBrains decompiler
// Type: ProxyBase.Skill
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;

namespace ProxyBase
{
  public class Skill
  {
    public bool moved = false;

    public string Name { get; set; }

    public int SkillSlot { get; set; }

    public DateTime NextUse { get; set; }

    public string Caption { get; set; }

    public int CurrentLevel { get; set; }

    public int MaximumLevel { get; set; }

    public int Icon { get; set; }

    public int NewSlot { get; set; }

    public Skill()
    {
      this.NextUse = DateTime.UtcNow;
    }

    public override string ToString()
    {
      return string.Format("{0} (Lev:{1}/{2})", (object) this.Name, (object) this.CurrentLevel, (object) this.MaximumLevel);
    }
  }
}
