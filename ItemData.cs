// Decompiled with JetBrains decompiler
// Type: ProxyBase.ItemData
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

namespace ProxyBase
{
  public class ItemData
  {
    public string Name { get; set; }

    public int MaxStack { get; set; }

    public ItemData(string name, int maxstack)
    {
      this.Name = name;
      this.MaxStack = maxstack;
    }
  }
}
