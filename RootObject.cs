// Decompiled with JetBrains decompiler
// Type: ProxyBase.RootObject
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Collections.Generic;

namespace ProxyBase
{
  public class RootObject
  {
    public string mapnum { get; set; }

    public string mapname { get; set; }

    public string width { get; set; }

    public string height { get; set; }

    public List<Spawnarea> spawnareas { get; set; }

    public List<To> to { get; set; }
  }
}
