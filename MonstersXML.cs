// Decompiled with JetBrains decompiler
// Type: ProxyBase.MonstersXML
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Collections.Generic;

namespace ProxyBase
{
  public class MonstersXML
  {
    public List<string> ItemDrops = new List<string>();

    public string Name { get; set; }

    public ushort Image { get; set; }

    public ushort GoldDropMin { get; set; }

    public ushort GoldDropMax { get; set; }
  }
}
