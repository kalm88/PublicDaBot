// Decompiled with JetBrains decompiler
// Type: ProxyBase.Rect
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

namespace ProxyBase
{
  public struct Rect
  {
    public int left;
    public int top;
    public int right;
    public int bottom;

    public int Width
    {
      get
      {
        return this.right - this.left;
      }
    }

    public int Height
    {
      get
      {
        return this.bottom - this.top;
      }
    }
  }
}
