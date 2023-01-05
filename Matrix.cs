// Decompiled with JetBrains decompiler
// Type: ProxyBase.Matrix
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProxyBase
{
  public class Matrix : UserControl
  {
    private IContainer components = (IContainer) null;
    private int _MatrixSize = 10;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.Name = nameof (Matrix);
      this.ResumeLayout(false);
    }

    public Client Client { get; set; }

    public int MaxtrixSize
    {
      get
      {
        return this._MatrixSize;
      }
      set
      {
        this._MatrixSize = value;
        this.Invalidate();
      }
    }

    public Graphics G
    {
      get
      {
        return this._G;
      }
    }

    private Graphics _G
    {
      get
      {
        try
        {
          return Graphics.FromHwnd(this.Handle);
        }
        catch
        {
          return (Graphics) null;
        }
      }
    }
  }
}
