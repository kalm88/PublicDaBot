// Decompiled with JetBrains decompiler
// Type: ProxyBase.ProcessInformation
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;

namespace ProxyBase
{
  public struct ProcessInformation
  {
    public IntPtr ProcessHandle { get; set; }

    public IntPtr ThreadHandle { get; set; }

    public int ProcessId { get; set; }

    public int ThreadId { get; set; }
  }
}
