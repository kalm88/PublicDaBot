// Decompiled with JetBrains decompiler
// Type: ProxyBase.Mail
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

namespace ProxyBase
{
  public class Mail
  {
    public string Body = string.Empty;

    public string Sender { get; set; }

    public string Title { get; set; }

    public ushort Number { get; set; }
  }
}
