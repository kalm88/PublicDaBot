// Decompiled with JetBrains decompiler
// Type: ProxyBase.ItemMonsterXML
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Collections.Generic;

namespace ProxyBase
{
  public class ItemMonsterXML
  {
    public Dictionary<string, Item2XML> Drops = new Dictionary<string, Item2XML>();
    public List<string> GoldAmounts = new List<string>();

    public string Name { get; set; }

    public int Image { get; set; }

    public uint KillCount { get; set; }
  }
}
