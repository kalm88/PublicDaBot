// Decompiled with JetBrains decompiler
// Type: ProxyBase.MappedMaps
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Collections.Generic;

namespace ProxyBase
{
  public class MappedMaps
  {
    public bool Checked = false;
    public bool Deadend = false;
    public Dictionary<int, Location> ConnectedTo = new Dictionary<int, Location>();
    public Location Default = (Location) null;
    public int Routes = 0;
    public Dictionary<int, List<int>> RoutesDic = new Dictionary<int, List<int>>();

    public int Number { get; set; }
  }
}
