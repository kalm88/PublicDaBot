// Decompiled with JetBrains decompiler
// Type: ProxyBase.ListViewItemComparer
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Collections;
using System.Windows.Forms;

namespace ProxyBase
{
  internal class ListViewItemComparer : IComparer
  {
    private int col;
    private SortOrder order;

    public ListViewItemComparer()
    {
      this.col = 0;
      this.order = SortOrder.Ascending;
    }

    public ListViewItemComparer(int column, SortOrder order)
    {
      this.col = column;
      this.order = order;
    }

    public int Compare(object x, object y)
    {
      int num = -1;
      try
      {
        num = string.Compare(((ListViewItem) x).SubItems[this.col].Text, ((ListViewItem) y).SubItems[this.col].Text);
        if (this.order == SortOrder.Descending)
          num *= -1;
      }
      catch
      {
        return num;
      }
      return num;
    }
  }
}
