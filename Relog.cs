// Decompiled with JetBrains decompiler
// Type: ProxyBase.Relog
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Diagnostics;

namespace ProxyBase
{
  public class Relog
  {
    public string Name { get; set; }

    public Process Process { get; set; }

    public bool WaitForOk { get; set; }

    public bool Redirected { get; set; }

    public bool ServerReset { get; set; }
  }
}
