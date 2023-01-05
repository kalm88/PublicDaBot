// Decompiled with JetBrains decompiler
// Type: ProxyBase.Marks
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

namespace ProxyBase
{
  public class Marks
  {
    public string Name { get; set; }

    public string Cat { get; set; }

    public Marks(string name, string cat)
    {
      this.Name = name;
      this.Cat = cat;
    }

    public override string ToString()
    {
      return this.Name;
    }
  }
}
