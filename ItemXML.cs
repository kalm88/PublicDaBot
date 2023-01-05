// Decompiled with JetBrains decompiler
// Type: ProxyBase.ItemXML
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Collections.Generic;

namespace ProxyBase
{
  public class ItemXML
  {
    public List<string> Usedfor = new List<string>();
    public List<string> Obtainedby = new List<string>();

    public string Name { get; set; }

    public string SecondName { get; set; }

    public int Image { get; set; }
  }
}
