// Decompiled with JetBrains decompiler
// Type: ProxyBase.MapNum
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Collections.Generic;

namespace ProxyBase
{
  public class MapNum
  {
    public int Number = int.MinValue;
    public Dictionary<Location, string> Regions = new Dictionary<Location, string>();
    public Dictionary<Location, string> Previous = new Dictionary<Location, string>();
    public Location LastPoint = (Location) null;
  }
}
