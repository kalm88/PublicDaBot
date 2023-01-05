// Decompiled with JetBrains decompiler
// Type: ProxyBase.Tailors
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Collections.Generic;

namespace ProxyBase
{
  public class Tailors
  {
    public Dictionary<string, ProxyBase.TailorLevCounts> TailorLevCounts = new Dictionary<string, ProxyBase.TailorLevCounts>();
    public bool UseAssistant = false;
    public List<string> Armors = new List<string>();

    public string CharName { get; set; }
  }
}
