// Decompiled with JetBrains decompiler
// Type: ProxyBase.Updates
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProxyBase
{
  public class Updates : Form
  {
    private IContainer components = (IContainer) null;
    private RichTextBox richTextBox1;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Updates));
      this.richTextBox1 = new RichTextBox();
      this.SuspendLayout();
      this.richTextBox1.Location = new System.Drawing.Point(-1, 1);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.ReadOnly = true;
      this.richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
      this.richTextBox1.Size = new Size(407, 502);
      this.richTextBox1.TabIndex = 0;
      this.richTextBox1.Text = componentResourceManager.GetString("richTextBox1.Text");
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(408, 505);
      this.Controls.Add((Control) this.richTextBox1);
      this.Name = nameof (Updates);
      this.Text = nameof (Updates);
      this.FormClosing += new FormClosingEventHandler(this.Updates_FormClosing);
      this.ResumeLayout(false);
    }

    public Updates()
    {
      this.InitializeComponent();
    }

    private void Updates_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
    }
  }
}
