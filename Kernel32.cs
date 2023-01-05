﻿// Decompiled with JetBrains decompiler
// Type: ProxyBase.Kernel32
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;
using System.Runtime.InteropServices;

namespace ProxyBase
{
  public static class Kernel32
  {
    [DllImport("kernel32.dll")]
    public static extern bool CloseHandle(IntPtr handle);

    [DllImport("kernel32.dll")]
    public static extern bool CreateProcess(
      string applicationName,
      string commandLine,
      IntPtr processAttributes,
      IntPtr threadAttributes,
      bool inheritHandles,
      ProcessCreationFlags creationFlags,
      IntPtr environment,
      string currentDirectory,
      ref StartupInfo startupInfo,
      out ProcessInformation processInfo);

    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(
      ProcessAccess access,
      bool inheritHandle,
      int processId);

    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(
      IntPtr hProcess,
      IntPtr baseAddress,
      IntPtr buffer,
      int count,
      out int bytesRead);

    [DllImport("kernel32.dll")]
    public static extern int ResumeThread(IntPtr hThread);

    [DllImport("kernel32.dll")]
    public static extern WaitEventResult WaitForSingleObject(
      IntPtr hObject,
      int timeout);

    [DllImport("kernel32.dll")]
    public static extern bool WriteProcessMemory(
      IntPtr hProcess,
      IntPtr baseAddress,
      IntPtr buffer,
      int count,
      out int bytesWritten);
  }
}
