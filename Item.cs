// Decompiled with JetBrains decompiler
// Type: ProxyBase.Item
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;

namespace ProxyBase
{
  public class Item
  {
    public uint Amount = 1;
    public bool Gone = false;
    public bool IsIdentified = false;

    public string Name { get; set; }

    public int InventorySlot { get; set; }

    public DateTime NextUse { get; set; }

    public ushort Icon { get; set; }

    public byte IconPal { get; set; }

    public byte Stackable { get; set; }

    public uint CurrentDurability { get; set; }

    public uint MaximumDurability { get; set; }

    public Item()
    {
      this.NextUse = DateTime.UtcNow;
    }

    public override string ToString()
    {
      return this.Name;
    }
  }
}
