// Decompiled with JetBrains decompiler
// Type: ListViewColumnSorter
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System.Collections;
using System.Windows.Forms;

public class ListViewColumnSorter : IComparer
{
  private int ColumnToSort;
  private SortOrder OrderOfSort;
  private CaseInsensitiveComparer ObjectCompare;

  public ListViewColumnSorter()
  {
    this.ColumnToSort = 0;
    this.OrderOfSort = SortOrder.None;
    this.ObjectCompare = new CaseInsensitiveComparer();
  }

  public int Compare(object x, object y)
  {
    int num = this.ObjectCompare.Compare((object) ((ListViewItem) x).SubItems[this.ColumnToSort].Text, (object) ((ListViewItem) y).SubItems[this.ColumnToSort].Text);
    if (this.OrderOfSort == SortOrder.Ascending)
      return num;
    return this.OrderOfSort == SortOrder.Descending ? -num : 0;
  }

  public int SortColumn
  {
    set
    {
      this.ColumnToSort = value;
    }
    get
    {
      return this.ColumnToSort;
    }
  }

  public SortOrder Order
  {
    set
    {
      this.OrderOfSort = value;
    }
    get
    {
      return this.OrderOfSort;
    }
  }
}
