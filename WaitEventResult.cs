// Decompiled with JetBrains decompiler
// Type: ProxyBase.WaitEventResult
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

namespace ProxyBase
{
  public enum WaitEventResult
  {
    Signaled = 0,
    Abandoned = 128, // 0x00000080
    Timeout = 258, // 0x00000102
  }
}
