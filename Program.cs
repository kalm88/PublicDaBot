// Decompiled with JetBrains decompiler
// Type: ProxyBase.Program
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProxyBase
{
  internal static class Program
  {
    public static object SyncObj = new object();
    private static string appGuid = "8dj7f74d66j2sk49fu3d89";

    public static MainForm MainForm { get; private set; }

    public static string StartupPath { get; private set; }

    [STAThread]
    public static void Main()
    {
      using (Mutex mutex = new Mutex(false, "Global\\" + Program.appGuid))
      {
        if (!mutex.WaitOne(0, false))
          return;
        Program.StartupPath = Application.StartupPath;
        Options.Load();
        Options.Save();
        Control.CheckForIllegalCrossThreadCalls = false;
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.CurrentDomain_UnhandledException);
        Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run((Form) (Program.MainForm = new MainForm()));
      }
    }

    private static void CurrentDomain_UnhandledException(
      object sender,
      UnhandledExceptionEventArgs e)
    {
      try
      {
        Exception exceptionObject = (Exception) e.ExceptionObject;
        int num = (int) MessageBox.Show("Warning! Program will crash upon closing this popup,\nplease contact the developers with the following information:\n\n" + exceptionObject.Message + exceptionObject.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      finally
      {
        Application.Exit();
      }
    }

    public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      DialogResult dialogResult = DialogResult.Abort;
      try
      {
        dialogResult = MessageBox.Show("Whoops! Please contact the developers with the following information:\n\n" + e.Exception.Message + e.Exception.StackTrace, "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
      }
      finally
      {
        if (dialogResult == DialogResult.Abort)
          Application.Exit();
      }
    }

    public static string GetHashString(string value)
    {
      return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(value))).Replace("-", string.Empty).ToLower();
    }
  }
}
