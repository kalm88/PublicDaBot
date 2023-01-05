// Decompiled with JetBrains decompiler
// Type: ProxyBase.StartupInfo
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;

namespace ProxyBase
{
  public struct StartupInfo
  {
    public int Size { get; set; }

    public string Reserved { get; set; }

    public string Desktop { get; set; }

    public string Title { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int XCountChars { get; set; }

    public int YCountChars { get; set; }

    public int FillAttribute { get; set; }

    public int Flags { get; set; }

    public short ShowWindow { get; set; }

    public short Reserved2 { get; set; }

    public IntPtr Reserved3 { get; set; }

    public IntPtr StdInputHandle { get; set; }

    public IntPtr StdOutputHandle { get; set; }

    public IntPtr StdErrorHandle { get; set; }
  }
}
