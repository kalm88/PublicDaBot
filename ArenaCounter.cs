﻿// Decompiled with JetBrains decompiler
// Type: ProxyBase.ArenaCounter
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProxyBase
{
  public class ArenaCounter : Form
  {
    private IContainer components = (IContainer) null;
    private int sortColumn = -1;
    public Button startbtn;
    public Button stopbtn;
    public Button resetbtn;
    public ListView arenacounterlist;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    public MainForm parent;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.startbtn = new Button();
      this.stopbtn = new Button();
      this.resetbtn = new Button();
      this.arenacounterlist = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.columnHeader2 = new ColumnHeader();
      this.columnHeader3 = new ColumnHeader();
      this.SuspendLayout();
      this.startbtn.Location = new System.Drawing.Point(12, 29);
      this.startbtn.Name = "startbtn";
      this.startbtn.Size = new Size(74, 31);
      this.startbtn.TabIndex = 0;
      this.startbtn.Text = "Start";
      this.startbtn.UseVisualStyleBackColor = true;
      this.startbtn.Click += new EventHandler(this.Startbtn_Click);
      this.stopbtn.Enabled = false;
      this.stopbtn.Location = new System.Drawing.Point(133, 29);
      this.stopbtn.Name = "stopbtn";
      this.stopbtn.Size = new Size(74, 31);
      this.stopbtn.TabIndex = 1;
      this.stopbtn.Text = "Stop";
      this.stopbtn.UseVisualStyleBackColor = true;
      this.stopbtn.Click += new EventHandler(this.Stopbtn_Click);
      this.resetbtn.Location = new System.Drawing.Point(249, 29);
      this.resetbtn.Name = "resetbtn";
      this.resetbtn.Size = new Size(74, 31);
      this.resetbtn.TabIndex = 2;
      this.resetbtn.Text = "Reset";
      this.resetbtn.UseVisualStyleBackColor = true;
      this.resetbtn.Click += new EventHandler(this.Resetbtn_Click);
      this.arenacounterlist.Columns.AddRange(new ColumnHeader[3]
      {
        this.columnHeader1,
        this.columnHeader2,
        this.columnHeader3
      });
      this.arenacounterlist.FullRowSelect = true;
      this.arenacounterlist.Location = new System.Drawing.Point(12, 87);
      this.arenacounterlist.MultiSelect = false;
      this.arenacounterlist.Name = "arenacounterlist";
      this.arenacounterlist.Size = new Size(311, 288);
      this.arenacounterlist.TabIndex = 3;
      this.arenacounterlist.UseCompatibleStateImageBehavior = false;
      this.arenacounterlist.View = View.Details;
      this.arenacounterlist.ColumnClick += new ColumnClickEventHandler(this.Arenacounterlist_ColumnClick);
      this.columnHeader1.Text = "Name";
      this.columnHeader1.Width = 128;
      this.columnHeader2.Text = "Kills";
      this.columnHeader2.TextAlign = HorizontalAlignment.Center;
      this.columnHeader3.Text = "Deaths";
      this.columnHeader3.TextAlign = HorizontalAlignment.Center;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(336, 387);
      this.Controls.Add((Control) this.arenacounterlist);
      this.Controls.Add((Control) this.resetbtn);
      this.Controls.Add((Control) this.stopbtn);
      this.Controls.Add((Control) this.startbtn);
      this.Name = nameof (ArenaCounter);
      this.Text = nameof (ArenaCounter);
      this.FormClosing += new FormClosingEventHandler(this.ArenaCounter_FormClosing);
      this.ResumeLayout(false);
    }

    public Client Client { get; private set; }

    public ArenaCounter(Client client)
    {
      this.parent = Program.MainForm;
      this.Client = client;
      this.InitializeComponent();
    }

    private void ArenaCounter_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
      this.Client.Tab.openarenaform.Enabled = true;
    }

    private void Startbtn_Click(object sender, EventArgs e)
    {
      this.startbtn.Enabled = false;
      this.stopbtn.Enabled = true;
      this.Client.countarena = true;
    }

    private void Stopbtn_Click(object sender, EventArgs e)
    {
      this.startbtn.Enabled = true;
      this.stopbtn.Enabled = false;
      this.Client.countarena = false;
    }

    private void Resetbtn_Click(object sender, EventArgs e)
    {
      this.arenacounterlist.BeginUpdate();
      this.Client.ArenaCounter.Clear();
      this.arenacounterlist.Items.Clear();
      this.arenacounterlist.EndUpdate();
    }

    private void Arenacounterlist_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (e.Column != this.sortColumn)
      {
        this.sortColumn = e.Column;
        this.arenacounterlist.Sorting = SortOrder.Ascending;
      }
      else
        this.arenacounterlist.Sorting = this.arenacounterlist.Sorting != SortOrder.Ascending ? SortOrder.Ascending : SortOrder.Descending;
      this.arenacounterlist.Sort();
      this.arenacounterlist.ListViewItemSorter = (IComparer) new ListViewItemComparer(e.Column, this.arenacounterlist.Sorting);
    }
  }
}
