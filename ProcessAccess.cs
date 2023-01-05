// Decompiled with JetBrains decompiler
// Type: ProxyBase.ProcessAccess
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;

namespace ProxyBase
{
  [Flags]
  public enum ProcessAccess
  {
    None = 0,
    Terminate = 1,
    CreateThread = 2,
    VmOperation = 8,
    VmRead = 16, // 0x00000010
    VmWrite = 32, // 0x00000020
    DuplicateHandle = 64, // 0x00000040
    CreateProcess = 128, // 0x00000080
    SetQuota = 256, // 0x00000100
    SetInformation = 512, // 0x00000200
    QueryInformation = 1024, // 0x00000400
    SuspendResume = 2048, // 0x00000800
    QueryLimitedInformation = 4096, // 0x00001000
  }
}
