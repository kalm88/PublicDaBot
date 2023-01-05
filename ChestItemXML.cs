// Decompiled with JetBrains decompiler
// Type: ProxyBase.ChestItemXML
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Collections.Generic;

namespace ProxyBase
{
  public class ChestItemXML
  {
    public Dictionary<string, int> Treasure = new Dictionary<string, int>();

    public string Name { get; set; }

    public uint OpenedCount { get; set; }

    public ChestItemXML(string name, uint opened)
    {
      this.Name = name;
      this.OpenedCount = opened;
      this.Treasure = new Dictionary<string, int>();
    }
  }
}
