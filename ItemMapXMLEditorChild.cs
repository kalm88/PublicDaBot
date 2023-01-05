// Decompiled with JetBrains decompiler
// Type: ProxyBase.ItemMapXMLEditorChild
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ProxyBase
{
  public class ItemMapXMLEditorChild : Form
  {
    private IContainer components = (IContainer) null;
    private GroupBox groupBox2;
    private Splitter splitter1;
    public Button saveform;
    public Label mapnumber;
    public Label mapname;
    public ListView monsterlist;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private GroupBox groupBox1;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    public ListView itemlist;
    private GroupBox groupBox3;
    private ColumnHeader columnHeader5;
    public Button closebtn;
    public ListView goldlist;
    public Label charname;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.groupBox2 = new GroupBox();
      this.monsterlist = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.columnHeader2 = new ColumnHeader();
      this.splitter1 = new Splitter();
      this.saveform = new Button();
      this.mapnumber = new Label();
      this.mapname = new Label();
      this.groupBox1 = new GroupBox();
      this.itemlist = new ListView();
      this.columnHeader3 = new ColumnHeader();
      this.columnHeader4 = new ColumnHeader();
      this.groupBox3 = new GroupBox();
      this.goldlist = new ListView();
      this.columnHeader5 = new ColumnHeader();
      this.closebtn = new Button();
      this.charname = new Label();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      this.groupBox2.Controls.Add((Control) this.monsterlist);
      this.groupBox2.Location = new System.Drawing.Point(12, 121);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(219, 266);
      this.groupBox2.TabIndex = 39;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Monster";
      this.monsterlist.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnHeader1,
        this.columnHeader2
      });
      this.monsterlist.FullRowSelect = true;
      this.monsterlist.Location = new System.Drawing.Point(6, 19);
      this.monsterlist.MultiSelect = false;
      this.monsterlist.Name = "monsterlist";
      this.monsterlist.Size = new Size(207, 241);
      this.monsterlist.TabIndex = 0;
      this.monsterlist.UseCompatibleStateImageBehavior = false;
      this.monsterlist.View = View.Details;
      this.monsterlist.SelectedIndexChanged += new EventHandler(this.monsterlist_SelectedIndexChanged);
      this.columnHeader1.Text = "Image/Name";
      this.columnHeader1.Width = 132;
      this.columnHeader2.Text = "Kill Count";
      this.columnHeader2.TextAlign = HorizontalAlignment.Center;
      this.columnHeader2.Width = 70;
      this.splitter1.BackColor = SystemColors.Control;
      this.splitter1.BorderStyle = BorderStyle.FixedSingle;
      this.splitter1.Cursor = Cursors.Default;
      this.splitter1.Dock = DockStyle.Top;
      this.splitter1.Location = new System.Drawing.Point(0, 0);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new Size(613, 43);
      this.splitter1.TabIndex = 40;
      this.splitter1.TabStop = false;
      this.saveform.Location = new System.Drawing.Point(123, 0);
      this.saveform.Name = "saveform";
      this.saveform.Size = new Size(122, 43);
      this.saveform.TabIndex = 43;
      this.saveform.Text = "Save";
      this.saveform.UseVisualStyleBackColor = true;
      this.saveform.Click += new EventHandler(this.saveform_Click);
      this.mapnumber.AutoSize = true;
      this.mapnumber.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.mapnumber.Location = new System.Drawing.Point(41, 89);
      this.mapnumber.Name = "mapnumber";
      this.mapnumber.Size = new Size(51, 17);
      this.mapnumber.TabIndex = 44;
      this.mapnumber.Text = "Map #:";
      this.mapname.AutoSize = true;
      this.mapname.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.mapname.Location = new System.Drawing.Point(12, 61);
      this.mapname.Name = "mapname";
      this.mapname.Size = new Size(80, 17);
      this.mapname.TabIndex = 45;
      this.mapname.Text = "Map Name:";
      this.groupBox1.Controls.Add((Control) this.itemlist);
      this.groupBox1.Location = new System.Drawing.Point(237, 121);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(250, 266);
      this.groupBox1.TabIndex = 46;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Items";
      this.itemlist.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnHeader3,
        this.columnHeader4
      });
      this.itemlist.FullRowSelect = true;
      this.itemlist.Location = new System.Drawing.Point(6, 19);
      this.itemlist.MultiSelect = false;
      this.itemlist.Name = "itemlist";
      this.itemlist.Size = new Size(238, 241);
      this.itemlist.TabIndex = 0;
      this.itemlist.UseCompatibleStateImageBehavior = false;
      this.itemlist.View = View.Details;
      this.columnHeader3.Text = "Image/Name";
      this.columnHeader3.Width = 162;
      this.columnHeader4.Text = "Drop Count";
      this.columnHeader4.TextAlign = HorizontalAlignment.Center;
      this.columnHeader4.Width = 70;
      this.groupBox3.Controls.Add((Control) this.goldlist);
      this.groupBox3.Location = new System.Drawing.Point(493, 121);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(108, 266);
      this.groupBox3.TabIndex = 47;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Gold";
      this.goldlist.Columns.AddRange(new ColumnHeader[1]
      {
        this.columnHeader5
      });
      this.goldlist.FullRowSelect = true;
      this.goldlist.Location = new System.Drawing.Point(6, 19);
      this.goldlist.MultiSelect = false;
      this.goldlist.Name = "goldlist";
      this.goldlist.Size = new Size(96, 241);
      this.goldlist.TabIndex = 0;
      this.goldlist.UseCompatibleStateImageBehavior = false;
      this.goldlist.View = View.Details;
      this.columnHeader5.Text = "Gold Amounts";
      this.columnHeader5.Width = 90;
      this.closebtn.Location = new System.Drawing.Point(365, 0);
      this.closebtn.Name = "closebtn";
      this.closebtn.Size = new Size(122, 43);
      this.closebtn.TabIndex = 48;
      this.closebtn.Text = "Close";
      this.closebtn.UseVisualStyleBackColor = true;
      this.closebtn.Click += new EventHandler(this.closebtn_Click);
      this.charname.AutoSize = true;
      this.charname.Location = new System.Drawing.Point(446, 63);
      this.charname.Name = "charname";
      this.charname.Size = new Size(0, 13);
      this.charname.TabIndex = 49;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(613, 394);
      this.Controls.Add((Control) this.charname);
      this.Controls.Add((Control) this.closebtn);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.mapname);
      this.Controls.Add((Control) this.mapnumber);
      this.Controls.Add((Control) this.saveform);
      this.Controls.Add((Control) this.splitter1);
      this.Controls.Add((Control) this.groupBox2);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.Name = nameof (ItemMapXMLEditorChild);
      this.Text = "name";
      this.FormClosing += new FormClosingEventHandler(this.ItemMapXMLEditorChild_FormClosing);
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public ItemMapXMLEditorChild()
    {
      this.InitializeComponent();
    }

    public void Save(string name, bool allfive = false)
    {
      if (!(this.charname.Text != string.Empty) || !(name == this.charname.Text))
        return;
      string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\DaItemDB\\";
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      XmlDocument xmlDocument = new XmlDocument();
      string str = path + "maps.xml";
      if (allfive)
        str = path + "mapsallfive.xml";
      string text = this.Text;
      bool flag1 = false;
      ItemMapXML itemMapXml = Server.ItemMapDatabase[text];
      if (!File.Exists(str))
      {
        XmlNode element = (XmlNode) xmlDocument.CreateElement("DarkAgesMaps");
        xmlDocument.AppendChild(element);
        xmlDocument.Save(str);
      }
      if (File.Exists(str))
      {
        xmlDocument.Load(str);
        XmlNode documentElement = (XmlNode) xmlDocument.DocumentElement;
        foreach (XmlNode childNode1 in documentElement.ChildNodes)
        {
          foreach (XmlNode childNode2 in childNode1.ChildNodes)
          {
            if (childNode2.Name == "MapName" && childNode2.InnerText == text)
            {
              foreach (string key1 in itemMapXml.Monsters.Keys)
              {
                bool flag2 = false;
                ItemMonsterXML monster = itemMapXml.Monsters[key1];
                foreach (XmlNode childNode3 in childNode1.ChildNodes)
                {
                  foreach (XmlNode childNode4 in childNode3.ChildNodes)
                  {
                    if (childNode4.Name == "MonsterName" && childNode4.InnerText == key1)
                    {
                      foreach (XmlNode childNode5 in childNode3.ChildNodes)
                      {
                        if (childNode5.Name == "KillCount")
                          childNode5.InnerText = (uint.Parse(childNode5.InnerText) + monster.KillCount).ToString();
                      }
                      foreach (string goldAmount in monster.GoldAmounts)
                      {
                        bool flag3 = false;
                        foreach (XmlNode childNode5 in childNode3.ChildNodes)
                        {
                          if (childNode5.Name == "GoldAmounts")
                          {
                            foreach (XmlNode childNode6 in childNode5.ChildNodes)
                            {
                              if (childNode6.Name == "Gold" && childNode6.InnerText == goldAmount)
                              {
                                flag3 = true;
                                break;
                              }
                            }
                            if (!flag3)
                            {
                              XmlNode element = (XmlNode) xmlDocument.CreateElement("Gold");
                              element.InnerText = goldAmount;
                              childNode5.AppendChild(element);
                            }
                          }
                          if (flag3)
                            break;
                        }
                      }
                      foreach (string key2 in monster.Drops.Keys)
                      {
                        bool flag3 = false;
                        Item2XML drop = monster.Drops[key2];
                        foreach (XmlNode childNode5 in childNode3.ChildNodes)
                        {
                          foreach (XmlNode childNode6 in childNode5.ChildNodes)
                          {
                            if (childNode6.Name == "ItemName" && childNode6.InnerText == key2)
                            {
                              foreach (XmlNode childNode7 in childNode5.ChildNodes)
                              {
                                if (childNode7.Name == "DropCount")
                                  childNode7.InnerText = (uint.Parse(childNode7.InnerText) + drop.DropCount).ToString();
                                else if (childNode7.Name == "SecondName" && childNode7.InnerText == string.Empty)
                                  childNode7.InnerText = drop.SecondName;
                              }
                              flag3 = true;
                              break;
                            }
                          }
                          if (flag3)
                            break;
                        }
                        if (!flag3)
                        {
                          XmlNode element1 = (XmlNode) xmlDocument.CreateElement("Item");
                          childNode3.AppendChild(element1);
                          XmlNode element2 = (XmlNode) xmlDocument.CreateElement("ItemName");
                          element2.InnerText = key2;
                          element1.AppendChild(element2);
                          XmlNode element3 = (XmlNode) xmlDocument.CreateElement("SecondName");
                          element3.InnerText = drop.SecondName;
                          element1.AppendChild(element3);
                          XmlNode element4 = (XmlNode) xmlDocument.CreateElement("DropCount");
                          element4.InnerText = drop.DropCount.ToString();
                          element1.AppendChild(element4);
                        }
                      }
                      flag2 = true;
                      break;
                    }
                  }
                  if (flag2)
                    break;
                }
                if (!flag2)
                {
                  XmlNode element1 = (XmlNode) xmlDocument.CreateElement("Monster");
                  childNode1.AppendChild(element1);
                  XmlNode element2 = (XmlNode) xmlDocument.CreateElement("MonsterName");
                  element2.InnerText = key1;
                  element1.AppendChild(element2);
                  XmlNode element3 = (XmlNode) xmlDocument.CreateElement("KillCount");
                  element3.InnerText = monster.KillCount.ToString();
                  element1.AppendChild(element3);
                  XmlNode element4 = (XmlNode) xmlDocument.CreateElement("GoldAmounts");
                  element1.AppendChild(element4);
                  foreach (string goldAmount in monster.GoldAmounts)
                  {
                    XmlNode element5 = (XmlNode) xmlDocument.CreateElement("Gold");
                    element5.InnerText = goldAmount;
                    element4.AppendChild(element5);
                  }
                  foreach (string key2 in monster.Drops.Keys)
                  {
                    Item2XML drop = monster.Drops[key2];
                    XmlNode element5 = (XmlNode) xmlDocument.CreateElement("Item");
                    element1.AppendChild(element5);
                    XmlNode element6 = (XmlNode) xmlDocument.CreateElement("ItemName");
                    element6.InnerText = key2;
                    element5.AppendChild(element6);
                    XmlNode element7 = (XmlNode) xmlDocument.CreateElement("SecondName");
                    element7.InnerText = drop.SecondName;
                    element5.AppendChild(element7);
                    XmlNode element8 = (XmlNode) xmlDocument.CreateElement("DropCount");
                    element8.InnerText = drop.DropCount.ToString();
                    element5.AppendChild(element8);
                  }
                }
              }
              flag1 = true;
              break;
            }
          }
          if (flag1)
            break;
        }
        if (!flag1)
        {
          XmlNode element1 = (XmlNode) xmlDocument.CreateElement("Map");
          documentElement.AppendChild(element1);
          XmlNode element2 = (XmlNode) xmlDocument.CreateElement("MapName");
          element2.InnerText = text;
          element1.AppendChild(element2);
          foreach (string key1 in itemMapXml.Monsters.Keys)
          {
            ItemMonsterXML monster = itemMapXml.Monsters[key1];
            XmlNode element3 = (XmlNode) xmlDocument.CreateElement("Monster");
            element1.AppendChild(element3);
            XmlNode element4 = (XmlNode) xmlDocument.CreateElement("MonsterName");
            element4.InnerText = key1;
            element3.AppendChild(element4);
            XmlNode element5 = (XmlNode) xmlDocument.CreateElement("KillCount");
            element5.InnerText = monster.KillCount.ToString();
            element3.AppendChild(element5);
            XmlNode element6 = (XmlNode) xmlDocument.CreateElement("GoldAmounts");
            element3.AppendChild(element6);
            foreach (string goldAmount in monster.GoldAmounts)
            {
              XmlNode element7 = (XmlNode) xmlDocument.CreateElement("Gold");
              element7.InnerText = goldAmount;
              element6.AppendChild(element7);
            }
            foreach (string key2 in monster.Drops.Keys)
            {
              Item2XML drop = monster.Drops[key2];
              XmlNode element7 = (XmlNode) xmlDocument.CreateElement("Item");
              element3.AppendChild(element7);
              XmlNode element8 = (XmlNode) xmlDocument.CreateElement("ItemName");
              element8.InnerText = key2;
              element7.AppendChild(element8);
              XmlNode element9 = (XmlNode) xmlDocument.CreateElement("SecondName");
              element9.InnerText = drop.SecondName;
              element7.AppendChild(element9);
              XmlNode element10 = (XmlNode) xmlDocument.CreateElement("DropCount");
              element10.InnerText = drop.DropCount.ToString();
              element7.AppendChild(element10);
            }
          }
        }
        xmlDocument.Save(str);
      }
      Server.ItemMapDatabase.Remove(text);
      this.Close();
      if (Program.MainForm.ItemXMLEditor.HasChildren)
      {
        foreach (Form mdiChild in Program.MainForm.ItemXMLEditor.MdiChildren)
        {
          if (mdiChild != null && mdiChild.Text != text)
            mdiChild.Refresh();
        }
      }
    }

    private void saveform_Click(object sender, EventArgs e)
    {
      if (!(this.charname.Text != string.Empty))
        return;
      this.Save(this.charname.Text, false);
    }

    private void monsterlist_SelectedIndexChanged(object sender, EventArgs e)
    {
      string mapkey = this.Text;
      if (this.monsterlist.SelectedItems.Count != 1)
        return;
      this.goldlist.Items.Clear();
      this.itemlist.Items.Clear();
      if (Server.ItemMapDatabase.ContainsKey(mapkey))
        Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateMapForm(Server.ItemMapDatabase[mapkey], (string) null)));
    }

    private void closebtn_Click(object sender, EventArgs e)
    {
      Server.ItemMapDatabase.Remove(this.Text);
      this.Close();
    }

    private void ItemMapXMLEditorChild_FormClosing(object sender, FormClosingEventArgs e)
    {
      Server.ItemMapDatabase.Remove(this.Text);
      this.Close();
    }
  }
}
