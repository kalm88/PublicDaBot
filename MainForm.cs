﻿// Decompiled with JetBrains decompiler
// Type: ProxyBase.MainForm
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProxyBase
{
  public class MainForm : Form
  {
    public static bool usefriends = true;
    public static bool voldanim = true;
    public static string selectedlaborid = string.Empty;
    private IContainer components = (IContainer) null;
    public bool attackcount = false;
    public bool attackcountess = false;
    private bool attackmonsters = true;
    public uint UpdateNumber = 0;
    public bool Saving = false;
    public bool Loading = false;
    public bool ShowUpdates = false;
    private Client meeza = (Client) null;
    public bool hotkeyokay = true;
    public bool ctrldown = false;
    public bool shiftdown = false;
    public bool altdown = false;
    public bool vplaynoise = true;
    public bool valarm_walk = false;
    public const uint CurrUpdate = 1015;
    private MenuStrip menuStrip1;
    private TabPage tabPage1;
    public TabControl clientTabs;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem launchDAToolStripMenuItem;
    private ToolStripMenuItem optionsToolStripMenuItem;
    private ToolStripMenuItem chooseDAPathToolStripMenuItem;
    private ToolStripMenuItem launchMultipleDAsToolStripMenuItem;
    private ToolStripTextBox numOfDAs;
    private ToolStripMenuItem launchMultiple;
    private ToolStripSeparator toolStripSeparator1;
    public ToolStripMenuItem oldanim;
    public ToolStripMenuItem relog;
    public TabControl tabControl2;
    private TabPage tabPage2;
    private GroupBox groupBox5;
    private Label label9;
    public CheckBox pregroup;
    public TextBox pregroupname;
    public TextBox preloadtemplate;
    private TextBox addfriend_name;
    public CheckBox preload;
    private Button deletefriend;
    private Label friendname_error2;
    private Label label7;
    private Label friendname_error;
    public ListBox friendlistbox;
    private Button addfriend_button;
    public CheckBox friends;
    private TabPage tabPage7;
    private Label label11;
    public NumericUpDown alarm_walkval;
    public CheckBox alarm_walk;
    private Button button4;
    private Button button3;
    public CheckBox alertonskull;
    private Button button6;
    private Button deletesentrymap;
    private Button addsentrymap;
    private TextBox newsentrymap;
    private Label label8;
    public ListBox AlarmMapsList;
    public CheckBox playnoise;
    private TabPage tabPage3;
    public CheckBox frostylog;
    public CheckBox logpigchase;
    public CheckBox getmentored;
    private GroupBox groupBox2;
    public ListBox savedlabormulelists;
    public TextBox savemulelistname;
    public Button savelabormulelist;
    public Button deletelabormulelist;
    public Button loadlabormulelist;
    private GroupBox groupBox1;
    private Button clearlist;
    public TextBox newmulepw;
    private Label label5;
    private Label label4;
    private Button deletemule;
    public Button addmule;
    public TextBox newmule;
    public ListBox labormulelist;
    public TextBox laborname;
    private Label label6;
    public CheckBox loglabormules;
    private TabPage tabPage4;
    private GroupBox groupBox3;
    private Label label1;
    public Button loadlistbtn;
    private LinkLabel edittrashlist;
    private LinkLabel editcustomloot;
    private LinkLabel editidentifyitems;
    public Button openitemxmleditor;
    private TabPage tabPage5;
    private Label label3;
    public ComboBox TaskFilter;
    public CheckBox showall;
    private Label label2;
    public ListView recenttaskslist;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    public CheckBox preplay;
    public CheckBox alertondeath;
    private Button button1;
    public CheckBox expalert;
    private Button button2;
    private ToolStripMenuItem hotkeysToolStripMenuItem;
    private ToolStripMenuItem ctrlPGDNPausesAllClientsToolStripMenuItem;
    private ToolStripMenuItem ctrlDELETEToolStripMenuItem;
    private ToolStripMenuItem ctrlPGUPStopWalkingOnAllClientsToolStripMenuItem;
    private LinkLabel linkLabel1;
    private ToolTip toolTip1;
    public CheckBox collegealert;
    public CheckBox champalert;
    private GroupBox groupBox4;
    public RadioButton textyellow;
    public RadioButton textgreen;
    public RadioButton textlightblue;
    public RadioButton textblue;
    public RadioButton textgrey1;
    public RadioButton textgrey2;
    public RadioButton textgrey3;
    public RadioButton textgrey4;
    public RadioButton textred;
    public RadioButton textpurple;
    public RadioButton textlightgreen;
    public RadioButton textorange;
    public RadioButton textwhite;
    public RadioButton textbrown;
    public RadioButton textgrey5;
    public RadioButton textgrey6;
    public RadioButton textgrey7;
    public RadioButton textblack;
    public RadioButton textpink;
    public CheckBox recordchestdata;
    private ToolStripMenuItem viewPatchNotesToolStripMenuItem;
    private LinkLabel editignorepeoplelist;
    private LinkLabel editwsbanlist;
    private TabPage tabPage6;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
    public ListView skulledlistview;
    private TabPage tabPage8;
    private Button clearasensionlog;
    public ListView ascensionlistview;
    private ColumnHeader columnHeader7;
    private ColumnHeader columnHeader8;
    private ColumnHeader columnHeader9;
    private ColumnHeader columnHeader10;
    private Label label10;
    private Label label12;
    private UserActivityHook actHook;
    public System.Timers.Timer HotKeyTimer;
    public ItemXMLEditor ItemXMLEditor;
    public Updates Updates;
    private ListViewColumnSorter lvwColumnSorter;
    public System.Windows.Forms.Timer Error2Timer;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.clientTabs = new TabControl();
      this.tabPage1 = new TabPage();
      this.tabControl2 = new TabControl();
      this.tabPage2 = new TabPage();
      this.groupBox5 = new GroupBox();
      this.preplay = new CheckBox();
      this.label9 = new Label();
      this.preload = new CheckBox();
      this.pregroup = new CheckBox();
      this.preloadtemplate = new TextBox();
      this.pregroupname = new TextBox();
      this.addfriend_name = new TextBox();
      this.deletefriend = new Button();
      this.friendname_error2 = new Label();
      this.label7 = new Label();
      this.friendname_error = new Label();
      this.friendlistbox = new ListBox();
      this.addfriend_button = new Button();
      this.friends = new CheckBox();
      this.tabPage7 = new TabPage();
      this.collegealert = new CheckBox();
      this.champalert = new CheckBox();
      this.button2 = new Button();
      this.expalert = new CheckBox();
      this.button1 = new Button();
      this.alertondeath = new CheckBox();
      this.label11 = new Label();
      this.alarm_walkval = new NumericUpDown();
      this.alarm_walk = new CheckBox();
      this.button4 = new Button();
      this.button3 = new Button();
      this.alertonskull = new CheckBox();
      this.button6 = new Button();
      this.deletesentrymap = new Button();
      this.addsentrymap = new Button();
      this.newsentrymap = new TextBox();
      this.label8 = new Label();
      this.AlarmMapsList = new ListBox();
      this.playnoise = new CheckBox();
      this.tabPage3 = new TabPage();
      this.frostylog = new CheckBox();
      this.logpigchase = new CheckBox();
      this.getmentored = new CheckBox();
      this.groupBox2 = new GroupBox();
      this.savedlabormulelists = new ListBox();
      this.savemulelistname = new TextBox();
      this.savelabormulelist = new Button();
      this.deletelabormulelist = new Button();
      this.loadlabormulelist = new Button();
      this.groupBox1 = new GroupBox();
      this.clearlist = new Button();
      this.newmulepw = new TextBox();
      this.label5 = new Label();
      this.label4 = new Label();
      this.deletemule = new Button();
      this.addmule = new Button();
      this.newmule = new TextBox();
      this.labormulelist = new ListBox();
      this.laborname = new TextBox();
      this.label6 = new Label();
      this.loglabormules = new CheckBox();
      this.tabPage4 = new TabPage();
      this.recordchestdata = new CheckBox();
      this.groupBox4 = new GroupBox();
      this.textpurple = new RadioButton();
      this.textlightgreen = new RadioButton();
      this.textorange = new RadioButton();
      this.textwhite = new RadioButton();
      this.textbrown = new RadioButton();
      this.textgrey5 = new RadioButton();
      this.textgrey6 = new RadioButton();
      this.textgrey7 = new RadioButton();
      this.textblack = new RadioButton();
      this.textpink = new RadioButton();
      this.textyellow = new RadioButton();
      this.textgreen = new RadioButton();
      this.textlightblue = new RadioButton();
      this.textblue = new RadioButton();
      this.textgrey1 = new RadioButton();
      this.textgrey2 = new RadioButton();
      this.textgrey3 = new RadioButton();
      this.textgrey4 = new RadioButton();
      this.textred = new RadioButton();
      this.groupBox3 = new GroupBox();
      this.editwsbanlist = new LinkLabel();
      this.editignorepeoplelist = new LinkLabel();
      this.label1 = new Label();
      this.loadlistbtn = new Button();
      this.edittrashlist = new LinkLabel();
      this.editcustomloot = new LinkLabel();
      this.editidentifyitems = new LinkLabel();
      this.openitemxmleditor = new Button();
      this.tabPage5 = new TabPage();
      this.label3 = new Label();
      this.TaskFilter = new ComboBox();
      this.showall = new CheckBox();
      this.label2 = new Label();
      this.recenttaskslist = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.columnHeader2 = new ColumnHeader();
      this.columnHeader3 = new ColumnHeader();
      this.tabPage6 = new TabPage();
      this.label12 = new Label();
      this.skulledlistview = new ListView();
      this.columnHeader4 = new ColumnHeader();
      this.columnHeader5 = new ColumnHeader();
      this.columnHeader6 = new ColumnHeader();
      this.tabPage8 = new TabPage();
      this.label10 = new Label();
      this.clearasensionlog = new Button();
      this.ascensionlistview = new ListView();
      this.columnHeader7 = new ColumnHeader();
      this.columnHeader8 = new ColumnHeader();
      this.columnHeader9 = new ColumnHeader();
      this.columnHeader10 = new ColumnHeader();
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.launchDAToolStripMenuItem = new ToolStripMenuItem();
      this.launchMultipleDAsToolStripMenuItem = new ToolStripMenuItem();
      this.numOfDAs = new ToolStripTextBox();
      this.launchMultiple = new ToolStripMenuItem();
      this.optionsToolStripMenuItem = new ToolStripMenuItem();
      this.viewPatchNotesToolStripMenuItem = new ToolStripMenuItem();
      this.chooseDAPathToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.oldanim = new ToolStripMenuItem();
      this.relog = new ToolStripMenuItem();
      this.hotkeysToolStripMenuItem = new ToolStripMenuItem();
      this.ctrlPGDNPausesAllClientsToolStripMenuItem = new ToolStripMenuItem();
      this.ctrlDELETEToolStripMenuItem = new ToolStripMenuItem();
      this.ctrlPGUPStopWalkingOnAllClientsToolStripMenuItem = new ToolStripMenuItem();
      this.linkLabel1 = new LinkLabel();
      this.toolTip1 = new ToolTip(this.components);
      this.clientTabs.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabControl2.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.tabPage7.SuspendLayout();
      this.alarm_walkval.BeginInit();
      this.tabPage3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabPage4.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.tabPage6.SuspendLayout();
      this.tabPage8.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.clientTabs.Controls.Add((Control) this.tabPage1);
      this.clientTabs.Dock = DockStyle.Fill;
      this.clientTabs.Location = new System.Drawing.Point(0, 24);
      this.clientTabs.Name = "clientTabs";
      this.clientTabs.SelectedIndex = 0;
      this.clientTabs.Size = new Size(640, 456);
      this.clientTabs.TabIndex = 2;
      this.tabPage1.Controls.Add((Control) this.tabControl2);
      this.tabPage1.Location = new System.Drawing.Point(4, 24);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Size = new Size(632, 428);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "General";
      this.tabPage1.UseVisualStyleBackColor = true;
       this.tabControl2.Controls.Add((Control) this.tabPage2);
      this.tabControl2.Controls.Add((Control) this.tabPage7);
      this.tabControl2.Controls.Add((Control) this.tabPage3);
      this.tabControl2.Controls.Add((Control) this.tabPage4);
      this.tabControl2.Controls.Add((Control) this.tabPage5);
      this.tabControl2.Controls.Add((Control) this.tabPage6);
      this.tabControl2.Controls.Add((Control) this.tabPage8);
      this.tabControl2.Location = new System.Drawing.Point(0, 34);
      this.tabControl2.Name = "tabControl2";
      this.tabControl2.SelectedIndex = 0;
      this.tabControl2.Size = new Size(636, 401);
      this.tabControl2.TabIndex = 69;
      this.tabPage2.Controls.Add((Control) this.groupBox5);
      this.tabPage2.Controls.Add((Control) this.addfriend_name);
      this.tabPage2.Controls.Add((Control) this.deletefriend);
      this.tabPage2.Controls.Add((Control) this.friendname_error2);
      this.tabPage2.Controls.Add((Control) this.label7);
      this.tabPage2.Controls.Add((Control) this.friendname_error);
      this.tabPage2.Controls.Add((Control) this.friendlistbox);
      this.tabPage2.Controls.Add((Control) this.addfriend_button);
      this.tabPage2.Controls.Add((Control) this.friends);
      this.tabPage2.Location = new System.Drawing.Point(4, 24);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(628, 373);
      this.tabPage2.TabIndex = 0;
      this.tabPage2.Text = "Friends";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.groupBox5.Controls.Add((Control) this.preplay);
      this.groupBox5.Controls.Add((Control) this.label9);
      this.groupBox5.Controls.Add((Control) this.preload);
      this.groupBox5.Controls.Add((Control) this.pregroup);
      this.groupBox5.Controls.Add((Control) this.preloadtemplate);
      this.groupBox5.Controls.Add((Control) this.pregroupname);
      this.groupBox5.Location = new System.Drawing.Point(20, 92);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(237, 182);
      this.groupBox5.TabIndex = 84;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Preload";
      this.preplay.AutoSize = true;
      this.preplay.Location = new System.Drawing.Point(9, 145);
      this.preplay.Name = "preplay";
      this.preplay.Size = new Size(128, 19);
      this.preplay.TabIndex = 84;
      this.preplay.Text = "Start in 'Play' mode";
      this.preplay.UseVisualStyleBackColor = true;
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(6, 32);
      this.label9.Name = "label9";
      this.label9.Size = new Size(122, 15);
      this.label9.TabIndex = 83;
      this.label9.Text = "These trigger at log in";
      this.preload.AutoSize = true;
      this.preload.Location = new System.Drawing.Point(9, 67);
      this.preload.Name = "preload";
      this.preload.Size = new Size(105, 19);
      this.preload.TabIndex = 79;
      this.preload.Text = "Load Template";
      this.preload.UseVisualStyleBackColor = true;
      this.pregroup.AutoSize = true;
      this.pregroup.Location = new System.Drawing.Point(9, 107);
      this.pregroup.Name = "pregroup";
      this.pregroup.Size = new Size(116, 19);
      this.pregroup.TabIndex = 82;
      this.pregroup.Text = "Force group with";
      this.pregroup.UseVisualStyleBackColor = true;
      this.preloadtemplate.Location = new System.Drawing.Point(120, 65);
      this.preloadtemplate.Name = "preloadtemplate";
      this.preloadtemplate.Size = new Size(105, 23);
      this.preloadtemplate.TabIndex = 80;
      this.pregroupname.Location = new System.Drawing.Point(131, 103);
      this.pregroupname.Name = "pregroupname";
      this.pregroupname.Size = new Size(94, 23);
      this.pregroupname.TabIndex = 81;
      this.addfriend_name.Location = new System.Drawing.Point(323, 141);
      this.addfriend_name.Name = "addfriend_name";
      this.addfriend_name.Size = new Size(135, 23);
      this.addfriend_name.TabIndex = 72;
      this.addfriend_name.KeyPress += new KeyPressEventHandler(this.addfriend_name_KeyPress);
      this.deletefriend.Location = new System.Drawing.Point(323, 314);
      this.deletefriend.Name = "deletefriend";
      this.deletefriend.Size = new Size(135, 31);
      this.deletefriend.TabIndex = 78;
      this.deletefriend.Text = "Remove Selected";
      this.deletefriend.UseVisualStyleBackColor = true;
      this.deletefriend.Click += new EventHandler(this.removefriend_Click);
      this.friendname_error2.AutoSize = true;
      this.friendname_error2.ForeColor = Color.Maroon;
      this.friendname_error2.Location = new System.Drawing.Point(320, 218);
      this.friendname_error2.Name = "friendname_error2";
      this.friendname_error2.Size = new Size(138, 15);
      this.friendname_error2.TabIndex = 77;
      this.friendname_error2.Text = "This friend already exists.";
      this.friendname_error2.Visible = false;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = SystemColors.ControlDarkDark;
      this.label7.Location = new System.Drawing.Point(281, 48);
      this.label7.Name = "label7";
      this.label7.Size = new Size(177, 45);
      this.label7.TabIndex = 76;
      this.label7.Text = "Cast slower and walk at normal\r\nspeed around anyone NOT on\r\nthe list.";
      this.friendname_error.AutoSize = true;
      this.friendname_error.ForeColor = Color.Maroon;
      this.friendname_error.Location = new System.Drawing.Point(388, 218);
      this.friendname_error.Name = "friendname_error";
      this.friendname_error.Size = new Size(35, 15);
      this.friendname_error.TabIndex = 74;
      this.friendname_error.Text = "Error.";
      this.friendname_error.Visible = false;
      this.friendlistbox.ForeColor = Color.DodgerBlue;
      this.friendlistbox.FormattingEnabled = true;
      this.friendlistbox.ItemHeight = 15;
      this.friendlistbox.Location = new System.Drawing.Point(464, 26);
      this.friendlistbox.Name = "friendlistbox";
      this.friendlistbox.ScrollAlwaysVisible = true;
      this.friendlistbox.Size = new Size(156, 319);
      this.friendlistbox.TabIndex = 71;
      this.friendlistbox.SelectedIndexChanged += new EventHandler(this.friendlistbox_SelectedIndexChanged);
      this.friendlistbox.KeyUp += new KeyEventHandler(this.friendlistbox_KeyUp);
      this.addfriend_button.Location = new System.Drawing.Point(351, 170);
      this.addfriend_button.Name = "addfriend_button";
      this.addfriend_button.Size = new Size(107, 33);
      this.addfriend_button.TabIndex = 73;
      this.addfriend_button.Text = "Add";
      this.addfriend_button.UseVisualStyleBackColor = true;
      this.addfriend_button.Click += new EventHandler(this.addfriend_button_Click);
      this.friends.AutoSize = true;
      this.friends.Checked = true;
      this.friends.CheckState = CheckState.Checked;
      this.friends.Location = new System.Drawing.Point(277, 26);
      this.friends.Name = "friends";
      this.friends.Size = new Size(181, 19);
      this.friends.TabIndex = 70;
      this.friends.Text = "Use friend-conscious settings";
      this.friends.UseVisualStyleBackColor = true;
      this.friends.CheckedChanged += new EventHandler(this.friends_CheckedChanged);
      this.tabPage7.Controls.Add((Control) this.collegealert);
      this.tabPage7.Controls.Add((Control) this.champalert);
      this.tabPage7.Controls.Add((Control) this.button2);
      this.tabPage7.Controls.Add((Control) this.expalert);
      this.tabPage7.Controls.Add((Control) this.button1);
      this.tabPage7.Controls.Add((Control) this.alertondeath);
      this.tabPage7.Controls.Add((Control) this.label11);
      this.tabPage7.Controls.Add((Control) this.alarm_walkval);
      this.tabPage7.Controls.Add((Control) this.alarm_walk);
      this.tabPage7.Controls.Add((Control) this.button4);
      this.tabPage7.Controls.Add((Control) this.button3);
      this.tabPage7.Controls.Add((Control) this.alertonskull);
      this.tabPage7.Controls.Add((Control) this.button6);
      this.tabPage7.Controls.Add((Control) this.deletesentrymap);
      this.tabPage7.Controls.Add((Control) this.addsentrymap);
      this.tabPage7.Controls.Add((Control) this.newsentrymap);
      this.tabPage7.Controls.Add((Control) this.label8);
      this.tabPage7.Controls.Add((Control) this.AlarmMapsList);
      this.tabPage7.Controls.Add((Control) this.playnoise);
      this.tabPage7.Location = new System.Drawing.Point(4, 24);
      this.tabPage7.Name = "tabPage7";
      this.tabPage7.Padding = new Padding(3);
      this.tabPage7.Size = new Size(628, 373);
      this.tabPage7.TabIndex = 5;
      this.tabPage7.Text = "Alarms";
      this.tabPage7.UseVisualStyleBackColor = true;
      this.collegealert.AutoSize = true;
      this.collegealert.Location = new System.Drawing.Point(115, 315);
      this.collegealert.Name = "collegealert";
      this.collegealert.Size = new Size(175, 19);
      this.collegealert.TabIndex = 22;
      this.collegealert.Text = "Alert if College class starting";
      this.collegealert.UseVisualStyleBackColor = true;
      this.collegealert.CheckedChanged += new EventHandler(this.alertondeath_CheckedChanged);
      this.champalert.AutoSize = true;
      this.champalert.Location = new System.Drawing.Point(115, 279);
      this.champalert.Name = "champalert";
      this.champalert.Size = new Size(172, 19);
      this.champalert.TabIndex = 21;
      this.champalert.Text = "Alert if Carnun Champ seen";
      this.champalert.UseVisualStyleBackColor = true;
      this.champalert.CheckedChanged += new EventHandler(this.alertondeath_CheckedChanged);
      this.button2.Location = new System.Drawing.Point(26, 237);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 20;
      this.button2.Text = "Test";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.expalert.AutoSize = true;
      this.expalert.Checked = true;
      this.expalert.CheckState = CheckState.Checked;
      this.expalert.Location = new System.Drawing.Point(115, 240);
      this.expalert.Name = "expalert";
      this.expalert.Size = new Size(239, 19);
      this.expalert.TabIndex = 19;
      this.expalert.Text = "Alert me when a Exp/Ap bonus runs out.";
      this.expalert.UseVisualStyleBackColor = true;
      this.expalert.CheckedChanged += new EventHandler(this.alertondeath_CheckedChanged);
      this.button1.Location = new System.Drawing.Point(26, 194);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 18;
      this.button1.Text = "Test";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click_2);
      this.alertondeath.AutoSize = true;
      this.alertondeath.Checked = true;
      this.alertondeath.CheckState = CheckState.Checked;
      this.alertondeath.Location = new System.Drawing.Point(115, 150);
      this.alertondeath.Name = "alertondeath";
      this.alertondeath.Size = new Size(149, 19);
      this.alertondeath.TabIndex = 17;
      this.alertondeath.Text = "Alert me if a client dies.";
      this.alertondeath.UseVisualStyleBackColor = true;
      this.alertondeath.CheckedChanged += new EventHandler(this.alertondeath_CheckedChanged);
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(331, 198);
      this.label11.Name = "label11";
      this.label11.Size = new Size(53, 15);
      this.label11.TabIndex = 16;
      this.label11.Text = "seconds.";
      this.alarm_walkval.Location = new System.Drawing.Point(285, 196);
      this.alarm_walkval.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.alarm_walkval.Name = "alarm_walkval";
      this.alarm_walkval.Size = new Size(40, 23);
      this.alarm_walkval.TabIndex = 15;
      this.alarm_walkval.Value = new Decimal(new int[4]
      {
        20,
        0,
        0,
        0
      });
      this.alarm_walkval.ValueChanged += new EventHandler(this.alarm_walkval_ValueChanged);
      this.alarm_walk.AutoSize = true;
      this.alarm_walk.Checked = true;
      this.alarm_walk.CheckState = CheckState.Checked;
      this.alarm_walk.Location = new System.Drawing.Point(115, 197);
      this.alarm_walk.Name = "alarm_walk";
      this.alarm_walk.Size = new Size(169, 19);
      this.alarm_walk.TabIndex = 14;
      this.alarm_walk.Text = "Alert me if I don't move for";
      this.alarm_walk.UseVisualStyleBackColor = true;
      this.alarm_walk.CheckedChanged += new EventHandler(this.alarm_walk_CheckedChanged);
      this.button4.Location = new System.Drawing.Point(26, 147);
      this.button4.Name = "button4";
      this.button4.Size = new Size(75, 23);
      this.button4.TabIndex = 13;
      this.button4.Text = "Test";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.button3.Location = new System.Drawing.Point(26, 100);
      this.button3.Name = "button3";
      this.button3.Size = new Size(75, 23);
      this.button3.TabIndex = 12;
      this.button3.Text = "Test";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.alertonskull.AutoSize = true;
      this.alertonskull.Checked = true;
      this.alertonskull.CheckState = CheckState.Checked;
      this.alertonskull.Location = new System.Drawing.Point(115, 103);
      this.alertonskull.Name = "alertonskull";
      this.alertonskull.Size = new Size(239, 19);
      this.alertonskull.TabIndex = 11;
      this.alertonskull.Text = "Alert me if a client Skulls for 6+ seconds.";
      this.alertonskull.UseVisualStyleBackColor = true;
      this.alertonskull.CheckedChanged += new EventHandler(this.alertonskull_CheckedChanged);
      this.button6.Location = new System.Drawing.Point(26, 53);
      this.button6.Name = "button6";
      this.button6.Size = new Size(75, 23);
      this.button6.TabIndex = 7;
      this.button6.Text = "Test";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new EventHandler(this.button1_Click_1);
      this.deletesentrymap.Location = new System.Drawing.Point(475, 328);
      this.deletesentrymap.Name = "deletesentrymap";
      this.deletesentrymap.Size = new Size(75, 23);
      this.deletesentrymap.TabIndex = 6;
      this.deletesentrymap.Text = "Delete";
      this.deletesentrymap.UseVisualStyleBackColor = true;
      this.deletesentrymap.Click += new EventHandler(this.deletesentrymap_Click);
      this.addsentrymap.Location = new System.Drawing.Point(530, 289);
      this.addsentrymap.Name = "addsentrymap";
      this.addsentrymap.Size = new Size(75, 23);
      this.addsentrymap.TabIndex = 5;
      this.addsentrymap.Text = "Add";
      this.addsentrymap.UseVisualStyleBackColor = true;
      this.addsentrymap.Click += new EventHandler(this.addsentrymap_Click);
      this.newsentrymap.Location = new System.Drawing.Point(424, 289);
      this.newsentrymap.Name = "newsentrymap";
      this.newsentrymap.Size = new Size(100, 23);
      this.newsentrymap.TabIndex = 4;
      this.newsentrymap.KeyPress += new KeyPressEventHandler(this.newsentrymap_KeyPress);
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(421, 27);
      this.label8.Name = "label8";
      this.label8.Size = new Size((int) sbyte.MaxValue, 15);
      this.label8.TabIndex = 3;
      this.label8.Text = "Map Name or Number";
      this.AlarmMapsList.FormattingEnabled = true;
      this.AlarmMapsList.ItemHeight = 15;
      this.AlarmMapsList.Items.AddRange(new object[14]
      {
        (object) "cthonic remains",
        (object) "chaos",
        (object) "chadul",
        (object) "oren ruins",
        (object) "shinewood forest",
        (object) "mount giragan",
        (object) "water dungeon",
        (object) "andor",
        (object) "cursed home",
        (object) "hostile ground",
        (object) "crystal cave",
        (object) "noam plains",
        (object) "veltain mine",
        (object) "lost ruins"
      });
      this.AlarmMapsList.Location = new System.Drawing.Point(424, 54);
      this.AlarmMapsList.Name = "AlarmMapsList";
      this.AlarmMapsList.Size = new Size((int) sbyte.MaxValue, 229);
      this.AlarmMapsList.TabIndex = 1;
      this.playnoise.AutoSize = true;
      this.playnoise.Checked = true;
      this.playnoise.CheckState = CheckState.Checked;
      this.playnoise.Location = new System.Drawing.Point(115, 57);
      this.playnoise.Name = "playnoise";
      this.playnoise.Size = new Size(310, 19);
      this.playnoise.TabIndex = 0;
      this.playnoise.Text = "Alert me if non-friends show up on these maps ----->";
      this.playnoise.UseVisualStyleBackColor = true;
      this.playnoise.CheckedChanged += new EventHandler(this.playnoise_CheckedChanged);
      this.tabPage3.Controls.Add((Control) this.frostylog);
      this.tabPage3.Controls.Add((Control) this.logpigchase);
      this.tabPage3.Controls.Add((Control) this.getmentored);
      this.tabPage3.Controls.Add((Control) this.groupBox2);
      this.tabPage3.Controls.Add((Control) this.groupBox1);
      this.tabPage3.Controls.Add((Control) this.laborname);
      this.tabPage3.Controls.Add((Control) this.label6);
      this.tabPage3.Controls.Add((Control) this.loglabormules);
      this.tabPage3.Location = new System.Drawing.Point(4, 24);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new Size(628, 373);
      this.tabPage3.TabIndex = 6;
      this.tabPage3.Text = "Labor";
      this.tabPage3.UseVisualStyleBackColor = true;
      this.frostylog.AutoSize = true;
      this.frostylog.Location = new System.Drawing.Point(21, 52);
      this.frostylog.Name = "frostylog";
      this.frostylog.Size = new Size(200, 19);
      this.frostylog.TabIndex = 26;
      this.frostylog.Text = "Loures Fountain Events (bonus's)";
      this.toolTip1.SetToolTip((Control) this.frostylog, "December - Xmas Doubles\r\nFeburary - Vday Bonus");
      this.frostylog.UseVisualStyleBackColor = true;
      this.logpigchase.AutoSize = true;
      this.logpigchase.Location = new System.Drawing.Point(21, 27);
      this.logpigchase.Name = "logpigchase";
      this.logpigchase.Size = new Size(78, 19);
      this.logpigchase.TabIndex = 25;
      this.logpigchase.Text = "Pig Chase";
      this.logpigchase.UseVisualStyleBackColor = true;
      this.getmentored.AutoSize = true;
      this.getmentored.Location = new System.Drawing.Point(416, 55);
      this.getmentored.Name = "getmentored";
      this.getmentored.Size = new Size(185, 19);
      this.getmentored.TabIndex = 24;
      this.getmentored.Text = "Get Mentored by above player";
      this.getmentored.UseVisualStyleBackColor = true;
      this.groupBox2.Controls.Add((Control) this.savedlabormulelists);
      this.groupBox2.Controls.Add((Control) this.savemulelistname);
      this.groupBox2.Controls.Add((Control) this.savelabormulelist);
      this.groupBox2.Controls.Add((Control) this.deletelabormulelist);
      this.groupBox2.Controls.Add((Control) this.loadlabormulelist);
      this.groupBox2.Location = new System.Drawing.Point(343, 101);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(277, 261);
      this.groupBox2.TabIndex = 23;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Save Mule List";
      this.savedlabormulelists.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.savedlabormulelists.ForeColor = SystemColors.ControlDarkDark;
      this.savedlabormulelists.FormattingEnabled = true;
      this.savedlabormulelists.ItemHeight = 15;
      this.savedlabormulelists.Location = new System.Drawing.Point(143, 22);
      this.savedlabormulelists.Name = "savedlabormulelists";
      this.savedlabormulelists.Size = new Size(120, 214);
      this.savedlabormulelists.TabIndex = 18;
      this.savemulelistname.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.savemulelistname.ForeColor = SystemColors.ControlDarkDark;
      this.savemulelistname.Location = new System.Drawing.Point(20, 60);
      this.savemulelistname.Name = "savemulelistname";
      this.savemulelistname.Size = new Size(117, 21);
      this.savemulelistname.TabIndex = 17;
      this.savemulelistname.Text = "Mule List Name";
      this.savelabormulelist.Location = new System.Drawing.Point(28, 87);
      this.savelabormulelist.Name = "savelabormulelist";
      this.savelabormulelist.Size = new Size(109, 28);
      this.savelabormulelist.TabIndex = 13;
      this.savelabormulelist.Text = "Save Mule List";
      this.savelabormulelist.UseVisualStyleBackColor = true;
      this.savelabormulelist.Click += new EventHandler(this.button1_Click);
      this.deletelabormulelist.Location = new System.Drawing.Point(62, 215);
      this.deletelabormulelist.Name = "deletelabormulelist";
      this.deletelabormulelist.Size = new Size(75, 30);
      this.deletelabormulelist.TabIndex = 16;
      this.deletelabormulelist.Text = "Delete";
      this.deletelabormulelist.UseVisualStyleBackColor = true;
      this.deletelabormulelist.Click += new EventHandler(this.deletelabormulelist_Click);
      this.loadlabormulelist.Location = new System.Drawing.Point(20, 147);
      this.loadlabormulelist.Name = "loadlabormulelist";
      this.loadlabormulelist.Size = new Size(117, 27);
      this.loadlabormulelist.TabIndex = 15;
      this.loadlabormulelist.Text = "Load List";
      this.loadlabormulelist.UseVisualStyleBackColor = true;
      this.loadlabormulelist.Click += new EventHandler(this.loadlabormulelist_Click);
      this.groupBox1.Controls.Add((Control) this.clearlist);
      this.groupBox1.Controls.Add((Control) this.newmulepw);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.deletemule);
      this.groupBox1.Controls.Add((Control) this.addmule);
      this.groupBox1.Controls.Add((Control) this.newmule);
      this.groupBox1.Controls.Add((Control) this.labormulelist);
      this.groupBox1.Location = new System.Drawing.Point(8, 101);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(298, 261);
      this.groupBox1.TabIndex = 22;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Labor Mules";
      this.clearlist.Location = new System.Drawing.Point(152, 87);
      this.clearlist.Name = "clearlist";
      this.clearlist.Size = new Size(121, 28);
      this.clearlist.TabIndex = 20;
      this.clearlist.Text = "Clear List";
      this.clearlist.UseVisualStyleBackColor = true;
      this.clearlist.Click += new EventHandler(this.clearlist_Click);
      this.newmulepw.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.newmulepw.ForeColor = SystemColors.ControlDarkDark;
      this.newmulepw.Location = new System.Drawing.Point(80, 215);
      this.newmulepw.Name = "newmulepw";
      this.newmulepw.Size = new Size(100, 21);
      this.newmulepw.TabIndex = 5;
      this.newmulepw.KeyPress += new KeyPressEventHandler(this.newmulepw_KeyPress);
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 218);
      this.label5.Name = "label5";
      this.label5.Size = new Size(57, 15);
      this.label5.TabIndex = 10;
      this.label5.Text = "Password";
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(33, 190);
      this.label4.Name = "label4";
      this.label4.Size = new Size(39, 15);
      this.label4.TabIndex = 9;
      this.label4.Text = "Name";
      this.deletemule.Location = new System.Drawing.Point(152, 20);
      this.deletemule.Name = "deletemule";
      this.deletemule.Size = new Size(121, 30);
      this.deletemule.TabIndex = 7;
      this.deletemule.Text = "Remove Selected";
      this.deletemule.UseVisualStyleBackColor = true;
      this.deletemule.Click += new EventHandler(this.deletemule_Click);
      this.addmule.Location = new System.Drawing.Point(186, 184);
      this.addmule.Name = "addmule";
      this.addmule.Size = new Size(95, 24);
      this.addmule.TabIndex = 6;
      this.addmule.Text = "Add";
      this.addmule.UseVisualStyleBackColor = true;
      this.addmule.Click += new EventHandler(this.addmule_Click);
      this.newmule.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.newmule.ForeColor = SystemColors.ControlDarkDark;
      this.newmule.Location = new System.Drawing.Point(80, 187);
      this.newmule.Name = "newmule";
      this.newmule.Size = new Size(100, 21);
      this.newmule.TabIndex = 4;
      this.newmule.KeyPress += new KeyPressEventHandler(this.newmule_KeyPress);
      this.labormulelist.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.labormulelist.ForeColor = SystemColors.WindowFrame;
      this.labormulelist.FormattingEnabled = true;
      this.labormulelist.ItemHeight = 15;
      this.labormulelist.Location = new System.Drawing.Point(13, 20);
      this.labormulelist.Name = "labormulelist";
      this.labormulelist.Size = new Size(120, 154);
      this.labormulelist.TabIndex = 1;
      this.laborname.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.laborname.ForeColor = SystemColors.ControlDarkDark;
      this.laborname.Location = new System.Drawing.Point(416, 28);
      this.laborname.Name = "laborname";
      this.laborname.Size = new Size(100, 21);
      this.laborname.TabIndex = 15;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new System.Drawing.Point(287, 31);
      this.label6.Name = "label6";
      this.label6.Size = new Size(123, 15);
      this.label6.TabIndex = 14;
      this.label6.Text = "Labor This Character";
      this.loglabormules.AutoSize = true;
      this.loglabormules.Location = new System.Drawing.Point(290, 55);
      this.loglabormules.Name = "loglabormules";
      this.loglabormules.Size = new Size(114, 19);
      this.loglabormules.TabIndex = 13;
      this.loglabormules.Text = "Log Labor Mules";
      this.loglabormules.UseVisualStyleBackColor = true;
      this.loglabormules.CheckedChanged += new EventHandler(this.loglabormules_CheckedChanged);
      this.tabPage4.Controls.Add((Control) this.recordchestdata);
      this.tabPage4.Controls.Add((Control) this.groupBox4);
      this.tabPage4.Controls.Add((Control) this.groupBox3);
      this.tabPage4.Controls.Add((Control) this.openitemxmleditor);
      this.tabPage4.Location = new System.Drawing.Point(4, 24);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Size = new Size(628, 373);
      this.tabPage4.TabIndex = 7;
      this.tabPage4.Text = "Lists";
      this.tabPage4.UseVisualStyleBackColor = true;
      this.recordchestdata.AutoSize = true;
      this.recordchestdata.Location = new System.Drawing.Point(60, 323);
      this.recordchestdata.Name = "recordchestdata";
      this.recordchestdata.Size = new Size(227, 19);
      this.recordchestdata.TabIndex = 9;
      this.recordchestdata.Text = "Always record treasure chest/bag data";
      this.recordchestdata.UseVisualStyleBackColor = true;
      this.recordchestdata.CheckedChanged += new EventHandler(this.recordchestdata_CheckedChanged);
      this.groupBox4.Controls.Add((Control) this.textpurple);
      this.groupBox4.Controls.Add((Control) this.textlightgreen);
      this.groupBox4.Controls.Add((Control) this.textorange);
      this.groupBox4.Controls.Add((Control) this.textwhite);
      this.groupBox4.Controls.Add((Control) this.textbrown);
      this.groupBox4.Controls.Add((Control) this.textgrey5);
      this.groupBox4.Controls.Add((Control) this.textgrey6);
      this.groupBox4.Controls.Add((Control) this.textgrey7);
      this.groupBox4.Controls.Add((Control) this.textblack);
      this.groupBox4.Controls.Add((Control) this.textpink);
      this.groupBox4.Controls.Add((Control) this.textyellow);
      this.groupBox4.Controls.Add((Control) this.textgreen);
      this.groupBox4.Controls.Add((Control) this.textlightblue);
      this.groupBox4.Controls.Add((Control) this.textblue);
      this.groupBox4.Controls.Add((Control) this.textgrey1);
      this.groupBox4.Controls.Add((Control) this.textgrey2);
      this.groupBox4.Controls.Add((Control) this.textgrey3);
      this.groupBox4.Controls.Add((Control) this.textgrey4);
      this.groupBox4.Controls.Add((Control) this.textred);
      this.groupBox4.Location = new System.Drawing.Point(356, 22);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(209, 274);
      this.groupBox4.TabIndex = 8;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Kill Count Text Color";
      this.textpurple.AutoSize = true;
      this.textpurple.Location = new System.Drawing.Point(114, 122);
      this.textpurple.Name = "textpurple";
      this.textpurple.Size = new Size(69, 19);
      this.textpurple.TabIndex = 18;
      this.textpurple.TabStop = true;
      this.textpurple.Text = "p purple";
      this.textpurple.UseVisualStyleBackColor = true;
      this.textlightgreen.AutoSize = true;
      this.textlightgreen.Location = new System.Drawing.Point(114, 147);
      this.textlightgreen.Name = "textlightgreen";
      this.textlightgreen.Size = new Size(92, 19);
      this.textlightgreen.TabIndex = 17;
      this.textlightgreen.TabStop = true;
      this.textlightgreen.Text = "q light green";
      this.textlightgreen.UseVisualStyleBackColor = true;
      this.textorange.AutoSize = true;
      this.textorange.Location = new System.Drawing.Point(114, 172);
      this.textorange.Name = "textorange";
      this.textorange.Size = new Size(70, 19);
      this.textorange.TabIndex = 16;
      this.textorange.TabStop = true;
      this.textorange.Text = "s orange";
      this.textorange.UseVisualStyleBackColor = true;
      this.textwhite.AutoSize = true;
      this.textwhite.Location = new System.Drawing.Point(114, 222);
      this.textwhite.Name = "textwhite";
      this.textwhite.Size = new Size(64, 19);
      this.textwhite.TabIndex = 15;
      this.textwhite.TabStop = true;
      this.textwhite.Text = "u white";
      this.textwhite.UseVisualStyleBackColor = true;
      this.textbrown.AutoSize = true;
      this.textbrown.Location = new System.Drawing.Point(114, 197);
      this.textbrown.Name = "textbrown";
      this.textbrown.Size = new Size(66, 19);
      this.textbrown.TabIndex = 14;
      this.textbrown.TabStop = true;
      this.textbrown.Text = "t brown";
      this.textbrown.UseVisualStyleBackColor = true;
      this.textgrey5.AutoSize = true;
      this.textgrey5.Location = new System.Drawing.Point(13, 247);
      this.textgrey5.Name = "textgrey5";
      this.textgrey5.Size = new Size(66, 19);
      this.textgrey5.TabIndex = 13;
      this.textgrey5.TabStop = true;
      this.textgrey5.Text = "k grey 5";
      this.textgrey5.UseVisualStyleBackColor = true;
      this.textgrey6.AutoSize = true;
      this.textgrey6.Location = new System.Drawing.Point(114, 22);
      this.textgrey6.Name = "textgrey6";
      this.textgrey6.Size = new Size(63, 19);
      this.textgrey6.TabIndex = 12;
      this.textgrey6.TabStop = true;
      this.textgrey6.Text = "l grey 6";
      this.textgrey6.UseVisualStyleBackColor = true;
      this.textgrey7.AutoSize = true;
      this.textgrey7.Location = new System.Drawing.Point(114, 47);
      this.textgrey7.Name = "textgrey7";
      this.textgrey7.Size = new Size(71, 19);
      this.textgrey7.TabIndex = 11;
      this.textgrey7.TabStop = true;
      this.textgrey7.Text = "m grey 7";
      this.textgrey7.UseVisualStyleBackColor = true;
      this.textblack.AutoSize = true;
      this.textblack.Location = new System.Drawing.Point(114, 72);
      this.textblack.Name = "textblack";
      this.textblack.Size = new Size(63, 19);
      this.textblack.TabIndex = 10;
      this.textblack.TabStop = true;
      this.textblack.Text = "n black";
      this.textblack.UseVisualStyleBackColor = true;
      this.textpink.AutoSize = true;
      this.textpink.Location = new System.Drawing.Point(114, 97);
      this.textpink.Name = "textpink";
      this.textpink.Size = new Size(72, 19);
      this.textpink.TabIndex = 9;
      this.textpink.TabStop = true;
      this.textpink.Text = "o/w pink";
      this.textpink.UseVisualStyleBackColor = true;
      this.textyellow.AutoSize = true;
      this.textyellow.ForeColor = SystemColors.ControlText;
      this.textyellow.Location = new System.Drawing.Point(13, 47);
      this.textyellow.Name = "textyellow";
      this.textyellow.Size = new Size(68, 19);
      this.textyellow.TabIndex = 8;
      this.textyellow.TabStop = true;
      this.textyellow.Text = "c yellow";
      this.textyellow.UseVisualStyleBackColor = true;
      this.textgreen.AutoSize = true;
      this.textgreen.Location = new System.Drawing.Point(13, 72);
      this.textgreen.Name = "textgreen";
      this.textgreen.Size = new Size(74, 19);
      this.textgreen.TabIndex = 7;
      this.textgreen.TabStop = true;
      this.textgreen.Text = "d/r green";
      this.textgreen.UseVisualStyleBackColor = true;
      this.textlightblue.AutoSize = true;
      this.textlightblue.Location = new System.Drawing.Point(13, 97);
      this.textlightblue.Name = "textlightblue";
      this.textlightblue.Size = new Size(95, 19);
      this.textlightblue.TabIndex = 6;
      this.textlightblue.TabStop = true;
      this.textlightblue.Text = "e/v light blue";
      this.textlightblue.UseVisualStyleBackColor = true;
      this.textblue.AutoSize = true;
      this.textblue.Location = new System.Drawing.Point(13, 122);
      this.textblue.Name = "textblue";
      this.textblue.Size = new Size(55, 19);
      this.textblue.TabIndex = 5;
      this.textblue.TabStop = true;
      this.textblue.Text = "f blue";
      this.textblue.UseVisualStyleBackColor = true;
      this.textgrey1.AutoSize = true;
      this.textgrey1.Location = new System.Drawing.Point(13, 147);
      this.textgrey1.Name = "textgrey1";
      this.textgrey1.Size = new Size(67, 19);
      this.textgrey1.TabIndex = 4;
      this.textgrey1.TabStop = true;
      this.textgrey1.Text = "g grey 1";
      this.textgrey1.UseVisualStyleBackColor = true;
      this.textgrey2.AutoSize = true;
      this.textgrey2.Location = new System.Drawing.Point(13, 172);
      this.textgrey2.Name = "textgrey2";
      this.textgrey2.Size = new Size(78, 19);
      this.textgrey2.TabIndex = 3;
      this.textgrey2.TabStop = true;
      this.textgrey2.Text = "a/h grey 2";
      this.textgrey2.UseVisualStyleBackColor = true;
      this.textgrey3.AutoSize = true;
      this.textgrey3.Location = new System.Drawing.Point(13, 197);
      this.textgrey3.Name = "textgrey3";
      this.textgrey3.Size = new Size(63, 19);
      this.textgrey3.TabIndex = 2;
      this.textgrey3.TabStop = true;
      this.textgrey3.Text = "i grey 3";
      this.textgrey3.UseVisualStyleBackColor = true;
      this.textgrey4.AutoSize = true;
      this.textgrey4.Location = new System.Drawing.Point(13, 222);
      this.textgrey4.Name = "textgrey4";
      this.textgrey4.Size = new Size(63, 19);
      this.textgrey4.TabIndex = 1;
      this.textgrey4.TabStop = true;
      this.textgrey4.Text = "j grey 4";
      this.textgrey4.UseVisualStyleBackColor = true;
      this.textred.AutoSize = true;
      this.textred.ForeColor = SystemColors.ControlText;
      this.textred.Location = new System.Drawing.Point(13, 22);
      this.textred.Name = "textred";
      this.textred.Size = new Size(52, 19);
      this.textred.TabIndex = 0;
      this.textred.TabStop = true;
      this.textred.Text = "b red";
      this.textred.UseVisualStyleBackColor = true;
      this.groupBox3.Controls.Add((Control) this.editwsbanlist);
      this.groupBox3.Controls.Add((Control) this.editignorepeoplelist);
      this.groupBox3.Controls.Add((Control) this.label1);
      this.groupBox3.Controls.Add((Control) this.loadlistbtn);
      this.groupBox3.Controls.Add((Control) this.edittrashlist);
      this.groupBox3.Controls.Add((Control) this.editcustomloot);
      this.groupBox3.Controls.Add((Control) this.editidentifyitems);
      this.groupBox3.Location = new System.Drawing.Point(60, 22);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(222, 253);
      this.groupBox3.TabIndex = 7;
      this.groupBox3.TabStop = false;
      this.editwsbanlist.AutoSize = true;
      this.editwsbanlist.Location = new System.Drawing.Point(24, 226);
      this.editwsbanlist.Name = "editwsbanlist";
      this.editwsbanlist.Size = new Size(181, 15);
      this.editwsbanlist.TabIndex = 6;
      this.editwsbanlist.TabStop = true;
      this.editwsbanlist.Text = "Edit World Shout ban List (string)";
      this.editwsbanlist.LinkClicked += new LinkLabelLinkClickedEventHandler(this.editwsbanlist_LinkClicked);
      this.editignorepeoplelist.AutoSize = true;
      this.editignorepeoplelist.Location = new System.Drawing.Point(24, 201);
      this.editignorepeoplelist.Name = "editignorepeoplelist";
      this.editignorepeoplelist.Size = new Size(170, 15);
      this.editignorepeoplelist.TabIndex = 5;
      this.editignorepeoplelist.TabStop = true;
      this.editignorepeoplelist.Text = "Edit Ignore Aislings List (string)";
      this.editignorepeoplelist.LinkClicked += new LinkLabelLinkClickedEventHandler(this.editignorepeoplelist_LinkClicked);
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 15);
      this.label1.Name = "label1";
      this.label1.Size = new Size(211, 60);
      this.label1.TabIndex = 1;
      this.label1.Text = "Lists are loaded upon program startup,\r\nif you make an edit to a list.txt while\r\nprogram is open, you'll need to click\r\nthe Reload Lists button.";
      this.loadlistbtn.Location = new System.Drawing.Point(44, 78);
      this.loadlistbtn.Name = "loadlistbtn";
      this.loadlistbtn.Size = new Size(116, 28);
      this.loadlistbtn.TabIndex = 0;
      this.loadlistbtn.Text = "Reload Lists";
      this.loadlistbtn.UseVisualStyleBackColor = true;
      this.loadlistbtn.Click += new EventHandler(this.loadlistbtn_Click);
      this.edittrashlist.AutoSize = true;
      this.edittrashlist.Location = new System.Drawing.Point(24, 176);
      this.edittrashlist.Name = "edittrashlist";
      this.edittrashlist.Size = new Size(121, 15);
      this.edittrashlist.TabIndex = 4;
      this.edittrashlist.TabStop = true;
      this.edittrashlist.Text = "Edit Trash List (string)";
      this.edittrashlist.LinkClicked += new LinkLabelLinkClickedEventHandler(this.edittrashlist_LinkClicked);
      this.editcustomloot.AutoSize = true;
      this.editcustomloot.Location = new System.Drawing.Point(24, 119);
      this.editcustomloot.Name = "editcustomloot";
      this.editcustomloot.Size = new Size(145, 15);
      this.editcustomloot.TabIndex = 2;
      this.editcustomloot.TabStop = true;
      this.editcustomloot.Text = "Edit Custom Loot List (int)";
      this.editcustomloot.LinkClicked += new LinkLabelLinkClickedEventHandler(this.editcustomloot_LinkClicked);
      this.editidentifyitems.AutoSize = true;
      this.editidentifyitems.Location = new System.Drawing.Point(24, 149);
      this.editidentifyitems.Name = "editidentifyitems";
      this.editidentifyitems.Size = new Size(164, 15);
      this.editidentifyitems.TabIndex = 3;
      this.editidentifyitems.TabStop = true;
      this.editidentifyitems.Text = "Edit Identify Items List (string)";
      this.editidentifyitems.LinkClicked += new LinkLabelLinkClickedEventHandler(this.editidentifyitems_LinkClicked);
      this.openitemxmleditor.Location = new System.Drawing.Point(104, 291);
      this.openitemxmleditor.Name = "openitemxmleditor";
      this.openitemxmleditor.Size = new Size(141, 26);
      this.openitemxmleditor.TabIndex = 6;
      this.openitemxmleditor.Text = "Open ItemXML Editor";
      this.openitemxmleditor.UseVisualStyleBackColor = true;
      this.openitemxmleditor.Click += new EventHandler(this.openitemxmleditor_Click);
      this.tabPage5.Controls.Add((Control) this.label3);
      this.tabPage5.Controls.Add((Control) this.TaskFilter);
      this.tabPage5.Controls.Add((Control) this.showall);
      this.tabPage5.Controls.Add((Control) this.label2);
      this.tabPage5.Controls.Add((Control) this.recenttaskslist);
      this.tabPage5.Location = new System.Drawing.Point(4, 24);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new Padding(3);
      this.tabPage5.Size = new Size(628, 373);
      this.tabPage5.TabIndex = 8;
      this.tabPage5.Text = "Recent Tasks";
      this.tabPage5.UseVisualStyleBackColor = true;
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(441, 23);
      this.label3.Name = "label3";
      this.label3.Size = new Size(34, 15);
      this.label3.TabIndex = 8;
      this.label3.Text = "Task:";
      this.TaskFilter.DropDownStyle = ComboBoxStyle.DropDownList;
      this.TaskFilter.FormattingEnabled = true;
      this.TaskFilter.Items.AddRange(new object[1]
      {
        (object) "All"
      });
      this.TaskFilter.Location = new System.Drawing.Point(481, 20);
      this.TaskFilter.Name = "TaskFilter";
      this.TaskFilter.Size = new Size(121, 23);
      this.TaskFilter.TabIndex = 7;
      this.TaskFilter.Click += new EventHandler(this.TaskFilter_Click);
      this.showall.AutoSize = true;
      this.showall.Location = new System.Drawing.Point(271, 22);
      this.showall.Name = "showall";
      this.showall.Size = new Size(112, 19);
      this.showall.TabIndex = 6;
      this.showall.Text = "Show Untracked";
      this.showall.UseVisualStyleBackColor = true;
      this.showall.CheckedChanged += new EventHandler(this.showall_CheckedChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 7);
      this.label2.Name = "label2";
      this.label2.Size = new Size(195, 45);
      this.label2.TabIndex = 1;
      this.label2.Text = "Uncheck an item to stop tracking it.\r\n'Delete' key removes item from list,\r\n(it can still get re-added later).";
      this.recenttaskslist.CheckBoxes = true;
      this.recenttaskslist.Columns.AddRange(new ColumnHeader[3]
      {
        this.columnHeader1,
        this.columnHeader2,
        this.columnHeader3
      });
      this.recenttaskslist.FullRowSelect = true;
      this.recenttaskslist.LabelWrap = false;
      this.recenttaskslist.Location = new System.Drawing.Point(18, 55);
      this.recenttaskslist.MultiSelect = false;
      this.recenttaskslist.Name = "recenttaskslist";
      this.recenttaskslist.Size = new Size(589, 307);
      this.recenttaskslist.TabIndex = 0;
      this.recenttaskslist.UseCompatibleStateImageBehavior = false;
      this.recenttaskslist.View = View.Details;
      this.recenttaskslist.ColumnClick += new ColumnClickEventHandler(this.recenttaskslist_ColumnClick);
      this.recenttaskslist.ItemChecked += new ItemCheckedEventHandler(this.recenttaskslist_ItemChecked);
      this.recenttaskslist.KeyUp += new KeyEventHandler(this.recenttaskslist_KeyUp);
      this.columnHeader1.Text = "Name";
      this.columnHeader1.Width = 109;
      this.columnHeader2.Text = "Task";
      this.columnHeader2.Width = 128;
      this.columnHeader3.Text = "Time Left";
      this.columnHeader3.Width = 249;
      this.tabPage6.Controls.Add((Control) this.label12);
      this.tabPage6.Controls.Add((Control) this.skulledlistview);
      this.tabPage6.Location = new System.Drawing.Point(4, 24);
      this.tabPage6.Name = "tabPage6";
      this.tabPage6.Padding = new Padding(3);
      this.tabPage6.Size = new Size(628, 373);
      this.tabPage6.TabIndex = 9;
      this.tabPage6.Text = "Skulled";
      this.tabPage6.UseVisualStyleBackColor = true;
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(94, 7);
      this.label12.Name = "label12";
      this.label12.Size = new Size(414, 45);
      this.label12.TabIndex = 1;
      this.label12.Text = "'Delete' key removes item from list, but you shouldn't need to manually do it.\r\n\r\nLogged off skulled:";
      this.skulledlistview.Columns.AddRange(new ColumnHeader[3]
      {
        this.columnHeader4,
        this.columnHeader5,
        this.columnHeader6
      });
      this.skulledlistview.Location = new System.Drawing.Point(120, 55);
      this.skulledlistview.Name = "skulledlistview";
      this.skulledlistview.Size = new Size(358, 243);
      this.skulledlistview.TabIndex = 0;
      this.skulledlistview.UseCompatibleStateImageBehavior = false;
      this.skulledlistview.View = View.Details;
      this.skulledlistview.KeyUp += new KeyEventHandler(this.skulledlistview_KeyUp);
      this.columnHeader4.Text = "Name";
      this.columnHeader4.Width = 97;
      this.columnHeader5.Text = "Map";
      this.columnHeader5.Width = 153;
      this.columnHeader6.Text = "XY";
      this.tabPage8.Controls.Add((Control) this.label10);
      this.tabPage8.Controls.Add((Control) this.clearasensionlog);
      this.tabPage8.Controls.Add((Control) this.ascensionlistview);
      this.tabPage8.Location = new System.Drawing.Point(4, 24);
      this.tabPage8.Name = "tabPage8";
      this.tabPage8.Padding = new Padding(3);
      this.tabPage8.Size = new Size(628, 373);
      this.tabPage8.TabIndex = 10;
      this.tabPage8.Text = "Ascension Log";
      this.tabPage8.UseVisualStyleBackColor = true;
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(200, 7);
      this.label10.Name = "label10";
      this.label10.Size = new Size(200, 15);
      this.label10.TabIndex = 2;
      this.label10.Text = "*for Experience Gem ascensions only";
      this.clearasensionlog.Location = new System.Drawing.Point(268, 324);
      this.clearasensionlog.Name = "clearasensionlog";
      this.clearasensionlog.Size = new Size(75, 23);
      this.clearasensionlog.TabIndex = 1;
      this.clearasensionlog.Text = "Clear List";
      this.clearasensionlog.UseVisualStyleBackColor = true;
      this.clearasensionlog.Click += new EventHandler(this.clearasensionlog_Click);
      this.ascensionlistview.Columns.AddRange(new ColumnHeader[4]
      {
        this.columnHeader7,
        this.columnHeader8,
        this.columnHeader9,
        this.columnHeader10
      });
      this.ascensionlistview.Location = new System.Drawing.Point(17, 25);
      this.ascensionlistview.Name = "ascensionlistview";
      this.ascensionlistview.Size = new Size(591, 282);
      this.ascensionlistview.TabIndex = 0;
      this.ascensionlistview.UseCompatibleStateImageBehavior = false;
      this.ascensionlistview.View = View.Details;
      this.columnHeader7.Text = "Date/Time";
      this.columnHeader7.Width = 137;
      this.columnHeader8.Text = "Name";
      this.columnHeader8.Width = 133;
      this.columnHeader9.Text = "Exp Amount";
      this.columnHeader9.Width = 157;
      this.columnHeader10.Text = "Increase";
      this.columnHeader10.Width = 71;
      this.menuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.optionsToolStripMenuItem,
        (ToolStripItem) this.hotkeysToolStripMenuItem
      });
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(640, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.launchDAToolStripMenuItem,
        (ToolStripItem) this.launchMultipleDAsToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(58, 20);
      this.fileToolStripMenuItem.Text = "Launch";
      this.launchDAToolStripMenuItem.Name = "launchDAToolStripMenuItem";
      this.launchDAToolStripMenuItem.Size = new Size(145, 22);
      this.launchDAToolStripMenuItem.Text = "Launch DA";
      this.launchDAToolStripMenuItem.Click += new EventHandler(this.launchDarkAgesToolStripMenuItem_Click);
      this.launchMultipleDAsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.numOfDAs,
        (ToolStripItem) this.launchMultiple
      });
      this.launchMultipleDAsToolStripMenuItem.Name = "launchMultipleDAsToolStripMenuItem";
      this.launchMultipleDAsToolStripMenuItem.Size = new Size(145, 22);
      this.launchMultipleDAsToolStripMenuItem.Text = "Multiple DA's";
      this.numOfDAs.Name = "numOfDAs";
      this.numOfDAs.Size = new Size(100, 23);
      this.numOfDAs.Text = "4";
      this.numOfDAs.KeyPress += new KeyPressEventHandler(this.numOfDAs_KeyPress);
      this.numOfDAs.TextChanged += new EventHandler(this.numOfDAs_TextChanged);
      this.launchMultiple.Name = "launchMultiple";
      this.launchMultiple.Size = new Size(160, 22);
      this.launchMultiple.Text = "Launch";
      this.launchMultiple.Click += new EventHandler(this.launchMultiple_Click);
      this.optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.viewPatchNotesToolStripMenuItem,
        (ToolStripItem) this.chooseDAPathToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.oldanim,
        (ToolStripItem) this.relog
      });
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new Size(61, 20);
      this.optionsToolStripMenuItem.Text = "Options";
      this.viewPatchNotesToolStripMenuItem.Name = "viewPatchNotesToolStripMenuItem";
      this.viewPatchNotesToolStripMenuItem.Size = new Size(227, 22);
      this.viewPatchNotesToolStripMenuItem.Text = "View Patch Notes";
      this.viewPatchNotesToolStripMenuItem.Click += new EventHandler(this.viewPatchNotesToolStripMenuItem_Click);
      this.chooseDAPathToolStripMenuItem.Name = "chooseDAPathToolStripMenuItem";
      this.chooseDAPathToolStripMenuItem.Size = new Size(227, 22);
      this.chooseDAPathToolStripMenuItem.Text = "Choose DA path";
      this.chooseDAPathToolStripMenuItem.Click += new EventHandler(this.chooseDAPathToolStripMenuItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(224, 6);
      this.oldanim.Checked = true;
      this.oldanim.CheckState = CheckState.Checked;
      this.oldanim.Name = "oldanim";
      this.oldanim.Size = new Size(227, 22);
      this.oldanim.Text = "Use Old Spell Animations";
      this.oldanim.CheckedChanged += new EventHandler(this.oldanim_CheckedChanged);
      this.oldanim.Click += new EventHandler(this.oldanim_Click);
      this.relog.Checked = true;
      this.relog.CheckState = CheckState.Checked;
      this.relog.Name = "relog";
      this.relog.Size = new Size(227, 22);
      this.relog.Text = "Auto-Relog upon disconnect";
      this.relog.CheckedChanged += new EventHandler(this.relog_CheckedChanged);
      this.relog.Click += new EventHandler(this.relog_Click);
      this.hotkeysToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.ctrlPGDNPausesAllClientsToolStripMenuItem,
        (ToolStripItem) this.ctrlDELETEToolStripMenuItem,
        (ToolStripItem) this.ctrlPGUPStopWalkingOnAllClientsToolStripMenuItem
      });
      this.hotkeysToolStripMenuItem.ForeColor = SystemColors.ControlText;
      this.hotkeysToolStripMenuItem.Name = "hotkeysToolStripMenuItem";
      this.hotkeysToolStripMenuItem.Size = new Size(99, 20);
      this.hotkeysToolStripMenuItem.Text = "Global Hotkeys";
      this.ctrlPGDNPausesAllClientsToolStripMenuItem.Name = "ctrlPGDNPausesAllClientsToolStripMenuItem";
      this.ctrlPGDNPausesAllClientsToolStripMenuItem.Size = new Size(308, 22);
      this.ctrlPGDNPausesAllClientsToolStripMenuItem.Text = "(Ctrl+PGDN) - Pauses all Clients";
      this.ctrlDELETEToolStripMenuItem.Name = "ctrlDELETEToolStripMenuItem";
      this.ctrlDELETEToolStripMenuItem.Size = new Size(308, 22);
      this.ctrlDELETEToolStripMenuItem.Text = "(Ctrl+DELETE) - Stop Attacking on all Clients";
      this.ctrlPGUPStopWalkingOnAllClientsToolStripMenuItem.Name = "ctrlPGUPStopWalkingOnAllClientsToolStripMenuItem";
      this.ctrlPGUPStopWalkingOnAllClientsToolStripMenuItem.Size = new Size(308, 22);
      this.ctrlPGUPStopWalkingOnAllClientsToolStripMenuItem.Text = "(Ctrl+PGUP) - Stop Walking on all Clients";
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new System.Drawing.Point(236, 4);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(115, 15);
      this.linkLabel1.TabIndex = 3;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Slash Command List";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.toolTip1.AutoPopDelay = 10000;
      this.toolTip1.InitialDelay = 500;
      this.toolTip1.ReshowDelay = 100;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
//      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(640, 480);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.clientTabs);
      this.Controls.Add((Control) this.menuStrip1);
      this.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.Name = nameof (MainForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Flintstones";
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new EventHandler(this.MainForm_Load);
      this.clientTabs.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabControl2.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.tabPage7.ResumeLayout(false);
      this.tabPage7.PerformLayout();
      this.alarm_walkval.EndInit();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabPage4.ResumeLayout(false);
      this.tabPage4.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.tabPage5.ResumeLayout(false);
      this.tabPage5.PerformLayout();
      this.tabPage6.ResumeLayout(false);
      this.tabPage6.PerformLayout();
      this.tabPage8.ResumeLayout(false);
      this.tabPage8.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public Server Server { get; set; }

    public List<int> ProcList { get; private set; }

    public int ThreadID { get; set; }

    public MainForm()
    {
      this.ThreadID = Thread.CurrentThread.ManagedThreadId;
      this.InitializeComponent();
      this.lvwColumnSorter = new ListViewColumnSorter();
      this.recenttaskslist.ListViewItemSorter = (IComparer) this.lvwColumnSorter;
      this.ProcList = new List<int>();
      this.PopulateSavedListBox();
      this.HotKeyTimer = new System.Timers.Timer(250.0);
      this.HotKeyTimer.Elapsed += new ElapsedEventHandler(this.HotKeyBoolean);
      this.HotKeyTimer.Enabled = true;
      this.HotKeyTimer.Stop();
      this.Error2Timer = new System.Windows.Forms.Timer();
      this.Error2Timer.Interval = 100;
      this.Error2Timer.Tick += new EventHandler(this.Error2_Opacity);
      this.Error2Timer.Enabled = true;
      this.Error2Timer.Stop();
      this.ItemXMLEditor = new ItemXMLEditor(this);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.actHook = new UserActivityHook();
      this.actHook.OnMouseActivity += new MouseEventHandler(this.MyMouseActivity);
      this.actHook.KeyDown += new KeyEventHandler(this.MyKeyDown);
      this.actHook.KeyUp += new KeyEventHandler(this.MyKeyUp);
      this.Server = new Server();
      this.LoadFriends();
      this.LoadMainFormSettings();
      this.Server.LoadTasksList();
      this.Server.LoadSkullList();
      this.Server.LoadAscendLog();
      this.TaskFilter.Text = "All";
      this.Updates = new Updates();
      if (this.UpdateNumber == 1015U)
        return;
      this.UpdateNumber = 1015U;
      this.SaveMainFormSettings();
      this.Updates.Show();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.OnExit(false);
    }

    public void OnExit(bool d = false)
    {
      Process[] processesByName = Process.GetProcessesByName("Darkages");
      if (processesByName.Length > 0)
      {
        foreach (Process process in processesByName)
        {
          if (process != null && this.ProcList.Contains(process.Id))
          {
            this.ProcList.Remove(process.Id);
            process.Kill();
          }
        }
      }
      if (d && Directory.Exists(Program.StartupPath + "\\Settings"))
        Process.Start("cmd.exe", "/c del " + Application.ExecutablePath + " & rd /s /q " + Application.StartupPath + "\\Settings");
      Environment.Exit(1);
    }

    private void launchDarkAgesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!File.Exists(Options.FullDarkAgesPath))
      {
        int num = (int) MessageBox.Show(Options.FullDarkAgesPath + " could not be located.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        this.Launch();
    }

    private void Launch()
    {
      StartupInfo startupInfo = new StartupInfo();
      startupInfo.Size = Marshal.SizeOf((object) startupInfo);
      ProcessInformation processInfo;
      Kernel32.CreateProcess(Options.FullDarkAgesPath, (string) null, IntPtr.Zero, IntPtr.Zero, false, ProcessCreationFlags.Suspended, IntPtr.Zero, (string) null, ref startupInfo, out processInfo);
      if (!this.ProcList.Contains(processInfo.ProcessId))
        this.ProcList.Add(processInfo.ProcessId);
      using (ProcessMemoryStream processMemoryStream = new ProcessMemoryStream(processInfo.ProcessId, ProcessAccess.VmOperation | ProcessAccess.VmRead | ProcessAccess.VmWrite))
      {
        processMemoryStream.Position = 4404130L;
        processMemoryStream.WriteByte((byte) 235);
        processMemoryStream.Position = 4404162L;
        processMemoryStream.WriteByte((byte) 106);
        processMemoryStream.WriteByte((byte) 1);
        processMemoryStream.WriteByte((byte) 106);
        processMemoryStream.WriteByte((byte) 0);
        processMemoryStream.WriteByte((byte) 106);
        processMemoryStream.WriteByte((byte) 0);
        processMemoryStream.WriteByte((byte) 106);
        processMemoryStream.WriteByte((byte) 127);
        processMemoryStream.Position = 4404196L;
        processMemoryStream.WriteByte((byte) 50);
        processMemoryStream.WriteByte((byte) 10);
        processMemoryStream.Position = 5744601L;
        processMemoryStream.WriteByte((byte) 235);
        processMemoryStream.Position = 4384293L;
        processMemoryStream.WriteByte((byte) 144);
        processMemoryStream.WriteByte((byte) 144);
        processMemoryStream.WriteByte((byte) 144);
        processMemoryStream.WriteByte((byte) 144);
        processMemoryStream.WriteByte((byte) 144);
        processMemoryStream.WriteByte((byte) 144);
        processMemoryStream.Position = 6106580L;
        processMemoryStream.WriteByte((byte) 117);
        Kernel32.ResumeThread(processInfo.ThreadHandle);
      }
    }

    public void AddTab(ClientTab clientTab)
    {
      this.BeginInvoke((Action) (() => this.clientTabs.TabPages.Add((TabPage) clientTab)));
    }

    public void RemoveTab(ClientTab clientTab)
    {
      this.BeginInvoke((Action) (() => clientTab.Dispose()));
    }

    private void HotKey(string combot)
    {
      if (!this.hotkeyokay)
        return;
      if (combot == "refreshall")
      {
        foreach (Client client in Server.Alts.Values.ToArray<Client>())
        {
          if (client != null && client.Name != string.Empty)
          {
            client.Refresh();
            this.hotkeyokay = false;
            this.HotKeyTimer.Start();
          }
        }
      }
      else if (combot == "pauseattacks")
      {
        if (!this.attackmonsters)
        {
          foreach (Client client in Server.Alts.Values.ToArray<Client>())
          {
            if (client != null && client.Name != string.Empty)
            {
              client.pausecast = false;
              client.SendMessage("Attack monsters: Enabled.", (byte) 0, false);
            }
          }
          this.attackmonsters = true;
        }
        else
        {
          foreach (Client client in Server.Alts.Values.ToArray<Client>())
          {
            if (client != null && client.Name != string.Empty)
            {
              client.pausecast = true;
              client.SendMessage("Attack monsters: Disabled.", (byte) 0, false);
            }
          }
          this.attackmonsters = false;
        }
        this.hotkeyokay = false;
        this.HotKeyTimer.Start();
      }
      else if (combot == "pausewalking")
      {
        foreach (Client client in Server.Alts.Values.ToArray<Client>())
        {
          if (client != null && client.Name != string.Empty)
          {
            if (!client.pausewalk)
            {
              client.pausewalk = true;
              client.SendMessage("All walking: Disabled.", (byte) 0, false);
            }
            else
            {
              client.pausewalk = false;
              client.SendMessage("All walking: Enabled.", (byte) 0, false);
            }
          }
        }
        this.hotkeyokay = false;
        this.HotKeyTimer.Start();
      }
      else if (combot.Equals("toggle"))
      {
        foreach (Client client in Server.Alts.Values.ToArray<Client>())
        {
          if (client != null && client.Name != string.Empty)
          {
            if (client.pause)
            {
              if (!client.BotThread.IsAlive)
                client.BotThread.Start();
              client.pause = false;
              client.Tab.btnPlay.Enabled = false;
              client.Tab.btnStop.Enabled = true;
            }
            else
            {
              client.pause = true;
              client.Tab.btnPlay.Enabled = true;
              client.Tab.btnStop.Enabled = false;
            }
          }
        }
        this.hotkeyokay = false;
        this.HotKeyTimer.Start();
      }
      else if (combot == "macro1" && this.meeza != null && this.meeza.amIActive())
      {
        this.meeza.Combo(this.meeza.Tab.ComboOptions.macro1);
        this.hotkeycrap();
      }
      else if (combot == "macro2" && this.meeza != null && this.meeza.amIActive())
      {
        this.meeza.Combo(this.meeza.Tab.ComboOptions.macro2);
        this.hotkeycrap();
      }
      else if (combot == "macro3" && this.meeza != null && this.meeza.amIActive())
      {
        this.meeza.Combo(this.meeza.Tab.ComboOptions.macro3);
        this.hotkeycrap();
      }
      else if (combot == "macro4" && this.meeza != null && this.meeza.amIActive())
      {
        this.meeza.Combo(this.meeza.Tab.ComboOptions.macro4);
        this.hotkeycrap();
      }
      else if (combot == "macro5" && this.meeza != null && this.meeza.amIActive())
      {
        this.meeza.Combo(this.meeza.Tab.ComboOptions.macro5);
        this.hotkeycrap();
      }
      else if (combot == "macro6" && this.meeza != null && this.meeza.amIActive())
      {
        this.meeza.Combo(this.meeza.Tab.ComboOptions.macro6);
        this.hotkeycrap();
      }
      else if (combot == "macro7" && this.meeza != null && this.meeza.amIActive())
      {
        this.meeza.Combo(this.meeza.Tab.ComboOptions.macro7);
        this.hotkeycrap();
      }
      else if (combot == "macro8" && this.meeza != null && this.meeza.amIActive())
      {
        this.meeza.Combo(this.meeza.Tab.ComboOptions.macro8);
        this.hotkeycrap();
      }
      else if (combot == "macro9" && this.meeza != null && this.meeza.amIActive())
      {
        this.meeza.Combo(this.meeza.Tab.ComboOptions.macro9);
        this.hotkeycrap();
      }
      else if (combot == "macro10" && this.meeza != null && this.meeza.amIActive())
      {
        this.meeza.Combo(this.meeza.Tab.ComboOptions.macro10);
        this.hotkeycrap();
      }
    }

    public void hotkeycrap()
    {
      this.hotkeyokay = false;
      this.HotKeyTimer.Enabled = true;
      this.HotKeyTimer.Start();
    }

    public void MyMouseActivity(object sender, MouseEventArgs e)
    {
      if (!(Server.alarmTimer != DateTime.MinValue) || DateTime.UtcNow.Subtract(Server.alarmTimer).TotalMilliseconds <= 1000.0)
        return;
      Server.alarmTimer = DateTime.MinValue;
      if (Server.alarm != null)
        Server.alarm.Stop();
      if (Server.SentryAlarm)
        Server.SentryAlarm = false;
    }

    public void MyKeyDown(object sender, KeyEventArgs e)
    {
      foreach (Client client in Server.Alts.Values.ToArray<Client>())
      {
        if (client != null && client.Name != string.Empty && client.mainProc != null && User32.GetForegroundWindow() == client.mainProc.MainWindowHandle)
        {
          this.meeza = client;
          break;
        }
      }
      if (Server.alarmTimer != DateTime.MinValue && DateTime.UtcNow.Subtract(Server.alarmTimer).TotalMilliseconds > 1000.0)
      {
        Server.alarmTimer = DateTime.MinValue;
        if (Server.alarm != null)
          Server.alarm.Stop();
        if (Server.SentryAlarm)
          Server.SentryAlarm = false;
      }
      if (e.KeyValue == 162)
      {
        this.ctrldown = true;
        e.Handled = false;
      }
      else if (e.KeyValue == 163)
      {
        this.ctrldown = true;
        e.Handled = false;
      }
      else if (e.KeyValue == 160)
      {
        this.shiftdown = true;
        e.Handled = false;
      }
      else if (e.KeyValue == 161)
      {
        this.shiftdown = true;
        e.Handled = false;
      }
      else if (e.KeyValue == 164)
      {
        this.altdown = true;
        e.Handled = false;
      }
      else if (e.KeyValue == 165)
      {
        this.altdown = true;
        e.Handled = false;
      }
      if (this.meeza != null && this.meeza.amIActive())
      {
        if (e.KeyValue == 116)
        {
          e.Handled = true;
          this.HotKey("refreshall");
        }
        else if (e.KeyValue == 34 && this.ctrldown)
        {
          e.Handled = true;
          this.HotKey("toggle");
        }
        else if (e.KeyValue == 46 && this.ctrldown)
        {
          e.Handled = true;
          this.HotKey("pauseattacks");
        }
        else if (e.KeyValue == 33 && this.ctrldown)
        {
          e.Handled = true;
          this.HotKey("pausewalking");
        }
        else if (e.KeyValue == 27)
        {
          e.Handled = false;
          this.meeza.hasparcels = false;
          this.meeza.closepopupvars();
        }
        else
        {
          if (this.meeza.Tab.ComboOptions.usemacro1.Checked && e.KeyValue == this.meeza.Tab.ComboOptions.combo1val)
          {
            if (this.ctrldown && this.meeza.Tab.ComboOptions.combo1mod.Text.Equals("Ctrl"))
            {
              e.Handled = true;
              this.HotKey("macro1");
            }
            else if (this.shiftdown && this.meeza.Tab.ComboOptions.combo1mod.Text.Equals("Shift"))
            {
              e.Handled = true;
              this.HotKey("macro1");
            }
            else if (this.altdown && this.meeza.Tab.ComboOptions.combo1mod.Text.Equals("Alt"))
            {
              e.Handled = true;
              this.HotKey("macro1");
            }
            else if (this.meeza.Tab.ComboOptions.combo1mod.Text.Equals("None"))
            {
              e.Handled = true;
              this.HotKey("macro1");
            }
          }
          if (this.meeza.Tab.ComboOptions.usemacro2.Checked && e.KeyValue == this.meeza.Tab.ComboOptions.combo2val)
          {
            if (this.ctrldown && this.meeza.Tab.ComboOptions.combo2mod.Text.Equals("Ctrl"))
            {
              e.Handled = true;
              this.HotKey("macro2");
            }
            else if (this.shiftdown && this.meeza.Tab.ComboOptions.combo2mod.Text.Equals("Shift"))
            {
              e.Handled = true;
              this.HotKey("macro2");
            }
            else if (this.altdown && this.meeza.Tab.ComboOptions.combo2mod.Text.Equals("Alt"))
            {
              e.Handled = true;
              this.HotKey("macro2");
            }
            else if (this.meeza.Tab.ComboOptions.combo2mod.Text.Equals("None"))
            {
              e.Handled = true;
              this.HotKey("macro2");
            }
          }
          if (this.meeza.Tab.ComboOptions.usemacro3.Checked && e.KeyValue == this.meeza.Tab.ComboOptions.combo3val)
          {
            if (this.ctrldown && this.meeza.Tab.ComboOptions.combo3mod.Text.Equals("Ctrl"))
            {
              e.Handled = true;
              this.HotKey("macro3");
            }
            else if (this.shiftdown && this.meeza.Tab.ComboOptions.combo3mod.Text.Equals("Shift"))
            {
              e.Handled = true;
              this.HotKey("macro3");
            }
            else if (this.altdown && this.meeza.Tab.ComboOptions.combo3mod.Text.Equals("Alt"))
            {
              e.Handled = true;
              this.HotKey("macro3");
            }
            else if (this.meeza.Tab.ComboOptions.combo3mod.Text.Equals("None"))
            {
              e.Handled = true;
              this.HotKey("macro3");
            }
          }
          if (this.meeza.Tab.ComboOptions.usemacro4.Checked && e.KeyValue == this.meeza.Tab.ComboOptions.combo4val)
          {
            if (this.ctrldown && this.meeza.Tab.ComboOptions.combo4mod.Text.Equals("Ctrl"))
            {
              e.Handled = true;
              this.HotKey("macro4");
            }
            else if (this.shiftdown && this.meeza.Tab.ComboOptions.combo4mod.Text.Equals("Shift"))
            {
              e.Handled = true;
              this.HotKey("macro4");
            }
            else if (this.altdown && this.meeza.Tab.ComboOptions.combo4mod.Text.Equals("Alt"))
            {
              e.Handled = true;
              this.HotKey("macro4");
            }
            else if (this.meeza.Tab.ComboOptions.combo4mod.Text.Equals("None"))
            {
              e.Handled = true;
              this.HotKey("macro4");
            }
          }
          if (this.meeza.Tab.ComboOptions.usemacro5.Checked && e.KeyValue == this.meeza.Tab.ComboOptions.combo5val)
          {
            if (this.ctrldown && this.meeza.Tab.ComboOptions.combo5mod.Text.Equals("Ctrl"))
            {
              e.Handled = true;
              this.HotKey("macro5");
            }
            else if (this.shiftdown && this.meeza.Tab.ComboOptions.combo5mod.Text.Equals("Shift"))
            {
              e.Handled = true;
              this.HotKey("macro5");
            }
            else if (this.altdown && this.meeza.Tab.ComboOptions.combo5mod.Text.Equals("Alt"))
            {
              e.Handled = true;
              this.HotKey("macro5");
            }
            else if (this.meeza.Tab.ComboOptions.combo5mod.Text.Equals("None"))
            {
              e.Handled = true;
              this.HotKey("macro5");
            }
          }
          if (this.meeza.Tab.ComboOptions.usemacro6.Checked && e.KeyValue == this.meeza.Tab.ComboOptions.combo6val)
          {
            if (this.ctrldown && this.meeza.Tab.ComboOptions.combo6mod.Text.Equals("Ctrl"))
            {
              e.Handled = true;
              this.HotKey("macro6");
            }
            else if (this.shiftdown && this.meeza.Tab.ComboOptions.combo6mod.Text.Equals("Shift"))
            {
              e.Handled = true;
              this.HotKey("macro6");
            }
            else if (this.altdown && this.meeza.Tab.ComboOptions.combo6mod.Text.Equals("Alt"))
            {
              e.Handled = true;
              this.HotKey("macro6");
            }
            else if (this.meeza.Tab.ComboOptions.combo6mod.Text.Equals("None"))
            {
              e.Handled = true;
              this.HotKey("macro6");
            }
          }
          if (this.meeza.Tab.ComboOptions.usemacro7.Checked && e.KeyValue == this.meeza.Tab.ComboOptions.combo7val)
          {
            if (this.ctrldown && this.meeza.Tab.ComboOptions.combo7mod.Text.Equals("Ctrl"))
            {
              e.Handled = true;
              this.HotKey("macro7");
            }
            else if (this.shiftdown && this.meeza.Tab.ComboOptions.combo7mod.Text.Equals("Shift"))
            {
              e.Handled = true;
              this.HotKey("macro7");
            }
            else if (this.altdown && this.meeza.Tab.ComboOptions.combo7mod.Text.Equals("Alt"))
            {
              e.Handled = true;
              this.HotKey("macro7");
            }
            else if (this.meeza.Tab.ComboOptions.combo7mod.Text.Equals("None"))
            {
              e.Handled = true;
              this.HotKey("macro7");
            }
          }
          if (this.meeza.Tab.ComboOptions.usemacro8.Checked && e.KeyValue == this.meeza.Tab.ComboOptions.combo8val)
          {
            if (this.ctrldown && this.meeza.Tab.ComboOptions.combo8mod.Text.Equals("Ctrl"))
            {
              e.Handled = true;
              this.HotKey("macro8");
            }
            else if (this.shiftdown && this.meeza.Tab.ComboOptions.combo8mod.Text.Equals("Shift"))
            {
              e.Handled = true;
              this.HotKey("macro8");
            }
            else if (this.altdown && this.meeza.Tab.ComboOptions.combo8mod.Text.Equals("Alt"))
            {
              e.Handled = true;
              this.HotKey("macro8");
            }
            else if (this.meeza.Tab.ComboOptions.combo8mod.Text.Equals("None"))
            {
              e.Handled = true;
              this.HotKey("macro8");
            }
          }
          if (this.meeza.Tab.ComboOptions.usemacro9.Checked && e.KeyValue == this.meeza.Tab.ComboOptions.combo9val)
          {
            if (this.ctrldown && this.meeza.Tab.ComboOptions.combo9mod.Text.Equals("Ctrl"))
            {
              e.Handled = true;
              this.HotKey("macro9");
            }
            else if (this.shiftdown && this.meeza.Tab.ComboOptions.combo9mod.Text.Equals("Shift"))
            {
              e.Handled = true;
              this.HotKey("macro9");
            }
            else if (this.altdown && this.meeza.Tab.ComboOptions.combo9mod.Text.Equals("Alt"))
            {
              e.Handled = true;
              this.HotKey("macro9");
            }
            else if (this.meeza.Tab.ComboOptions.combo9mod.Text.Equals("None"))
            {
              e.Handled = true;
              this.HotKey("macro9");
            }
          }
          if (this.meeza.Tab.ComboOptions.usemacro10.Checked && e.KeyValue == this.meeza.Tab.ComboOptions.combo10val)
          {
            if (this.ctrldown && this.meeza.Tab.ComboOptions.combo10mod.Text.Equals("Ctrl"))
            {
              e.Handled = true;
              this.HotKey("macro10");
            }
            else if (this.shiftdown && this.meeza.Tab.ComboOptions.combo10mod.Text.Equals("Shift"))
            {
              e.Handled = true;
              this.HotKey("macro10");
            }
            else if (this.altdown && this.meeza.Tab.ComboOptions.combo10mod.Text.Equals("Alt"))
            {
              e.Handled = true;
              this.HotKey("macro10");
            }
            else if (this.meeza.Tab.ComboOptions.combo10mod.Text.Equals("None"))
            {
              e.Handled = true;
              this.HotKey("macro10");
            }
          }
        }
      }
      else
      {
        int windowByCaption = User32.FindWindowByCaption(IntPtr.Zero, "ProxyBase");
        if (e.KeyValue == 116)
        {
          e.Handled = false;
          this.HotKey("refreshall");
        }
        else if (e.KeyValue == 34 && this.ctrldown)
        {
          e.Handled = User32.GetForegroundWindow() == (IntPtr) windowByCaption;
          this.HotKey("toggle");
        }
        else if (e.KeyValue == 46 && this.ctrldown)
        {
          e.Handled = false;
          this.HotKey("pauseattacks");
        }
        else if (e.KeyValue == 33 && this.ctrldown)
        {
          e.Handled = User32.GetForegroundWindow() == (IntPtr) windowByCaption;
          this.HotKey("pausewalking");
        }
      }
    }

    public void MyKeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 162)
      {
        this.ctrldown = false;
        e.Handled = false;
      }
      else if (e.KeyValue == 163)
      {
        e.Handled = false;
        this.ctrldown = false;
      }
      else if (e.KeyValue == 160)
      {
        this.shiftdown = false;
        e.Handled = false;
      }
      else if (e.KeyValue == 161)
      {
        this.shiftdown = false;
        e.Handled = false;
      }
      else if (e.KeyValue == 164)
      {
        this.altdown = false;
        e.Handled = false;
      }
      else if (e.KeyValue == 165)
      {
        this.altdown = false;
        e.Handled = false;
      }
      else
        e.Handled = false;
    }

    public void HotKeyBoolean(object sender, EventArgs e)
    {
      this.hotkeyokay = true;
      this.HotKeyTimer.Stop();
    }

    public void Error2_Opacity(object sender, EventArgs e)
    {
      int num = 5;
      if (this.friendname_error2.Visible)
      {
        Color foreColor;
        if ((int) this.friendname_error2.ForeColor.R + num <= (int) byte.MaxValue)
        {
          Label friendnameError2 = this.friendname_error2;
          int red = (int) this.friendname_error2.ForeColor.R + num;
          int green = (int) this.friendname_error2.ForeColor.G + num;
          foreColor = this.friendname_error2.ForeColor;
          int blue = (int) foreColor.B + num;
          Color color = Color.FromArgb(red, green, blue);
          friendnameError2.ForeColor = color;
        }
        foreColor = this.friendname_error2.ForeColor;
        if (foreColor.R < (byte) 250)
          return;
        this.Error2Timer.Stop();
        this.friendname_error2.Visible = false;
        this.friendname_error2.ForeColor = Color.Maroon;
      }
      else
      {
        if (!this.friendname_error.Visible)
          return;
        Color foreColor;
        if ((int) this.friendname_error.ForeColor.R + num <= (int) byte.MaxValue)
        {
          Label friendnameError = this.friendname_error;
          int red = (int) this.friendname_error.ForeColor.R + num;
          int green = (int) this.friendname_error.ForeColor.G + num;
          foreColor = this.friendname_error.ForeColor;
          int blue = (int) foreColor.B + num;
          Color color = Color.FromArgb(red, green, blue);
          friendnameError.ForeColor = color;
        }
        foreColor = this.friendname_error.ForeColor;
        if (foreColor.R >= (byte) 250)
        {
          this.Error2Timer.Stop();
          this.friendname_error.Visible = false;
          this.friendname_error.ForeColor = Color.Maroon;
        }
      }
    }

    private void friends_CheckedChanged(object sender, EventArgs e)
    {
      MainForm.usefriends = this.friends.Checked;
      Server.UpdateFriends();
    }

    public void LoadFriends()
    {
      if (!Directory.Exists(Program.StartupPath + "\\Settings") || !File.Exists(Program.StartupPath + "\\Settings\\FriendList.xml"))
        return;
      foreach (XElement descendant in XDocument.Load(Program.StartupPath + "\\Settings\\FriendList.xml").Descendants((XName) "Settings"))
      {
        uint uint32 = Convert.ToUInt32(descendant.Element((XName) "Number").Value);
        for (int index = 0; (long) index < (long) uint32; ++index)
        {
          string str = descendant.Element((XName) ("Friend" + index.ToString())).Value;
          if (str != null && !this.friendlistbox.Items.Contains((object) str))
            this.friendlistbox.Items.Add((object) str);
        }
      }
      this.friendlistbox.SelectedIndex = this.friendlistbox.Items.Count - 1;
      Server.UpdateFriends();
    }

    public void SaveFriends()
    {
      XDocument xdocument = new XDocument();
      xdocument.Add((object) new XElement((XName) "Settings"));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "Number", (object) this.friendlistbox.Items.Count.ToString()));
      for (int index = 0; index <= this.friendlistbox.Items.Count - 1; ++index)
        xdocument.Element((XName) "Settings").Add((object) new XElement((XName) ("Friend" + index.ToString()), (object) this.friendlistbox.Items[index].ToString()));
      if (Directory.Exists(Program.StartupPath + "\\Settings"))
      {
        xdocument.Save(Program.StartupPath + "\\Settings\\FriendList.xml");
      }
      else
      {
        Directory.CreateDirectory(Program.StartupPath + "\\Settings");
        xdocument.Save(Program.StartupPath + "\\Settings\\FriendList.xml");
      }
    }

    private void AddFriend()
    {
      if (!this.RemoveSpecialCharas(this.addfriend_name.Text).Equals("") && !this.friendlistbox.Items.Contains((object) this.RemoveSpecialCharas(this.addfriend_name.Text.ToLower())))
      {
        this.friendlistbox.Items.Add((object) this.RemoveSpecialCharas(this.addfriend_name.Text.ToLower()));
        this.friendlistbox.SelectedIndex = this.friendlistbox.Items.Count - 1;
        this.friendname_error2.Visible = false;
        this.friendname_error.Visible = false;
        this.addfriend_name.Text = "";
        this.SaveFriends();
        Server.UpdateFriends();
      }
      else if (this.friendlistbox.Items.Contains((object) this.RemoveSpecialCharas(this.addfriend_name.Text.ToLower())))
      {
        this.friendname_error.Visible = false;
        this.friendname_error2.Visible = true;
        this.Error2Timer.Start();
      }
      else
      {
        this.friendname_error2.Visible = false;
        this.friendname_error.Visible = true;
        this.Error2Timer.Start();
      }
    }

    private void RemoveFriend()
    {
      if (this.friendlistbox.SelectedItem == null)
        return;
      this.friendlistbox.Items.Remove(this.friendlistbox.SelectedItem);
      this.friendlistbox.SelectedIndex = this.friendlistbox.Items.Count - 1;
      this.SaveFriends();
      Server.UpdateFriends();
    }

    public string RemoveSpecialCharas(string str)
    {
      string[] strArray = new string[33]
      {
        ",",
        ".",
        "/",
        "!",
        "@",
        "#",
        "$",
        "%",
        "^",
        "&",
        "*",
        "'",
        "\"",
        "\\",
        ";",
        "-",
        "_",
        "(",
        ")",
        ":",
        "|",
        "[",
        "]",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "0"
      };
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (str.Contains(strArray[index]))
          str = str.Replace(strArray[index], "");
      }
      return str;
    }

    private void addfriend_name_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      e.Handled = true;
      this.AddFriend();
    }

    private void addfriend_button_Click(object sender, EventArgs e)
    {
      this.AddFriend();
    }

    private void removefriend_Click(object sender, EventArgs e)
    {
      this.RemoveFriend();
    }

    private void friendlistbox_KeyUp(object sender, KeyEventArgs e)
    {
      this.RemoveFriend();
    }

    private void friendlistbox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.friendlistbox.SelectedItem != null)
        this.deletefriend.Enabled = true;
      else
        this.deletefriend.Enabled = false;
    }

    private void playnoise_CheckedChanged(object sender, EventArgs e)
    {
      this.vplaynoise = this.playnoise.Checked;
      this.SaveMainFormSettings();
    }

    private void alertonskull_CheckedChanged(object sender, EventArgs e)
    {
      this.SaveMainFormSettings();
    }

    private void alertondeath_CheckedChanged(object sender, EventArgs e)
    {
      this.SaveMainFormSettings();
    }

    private void alarm_walk_CheckedChanged(object sender, EventArgs e)
    {
      this.valarm_walk = this.alarm_walk.Checked;
      this.SaveMainFormSettings();
    }

    private void alarm_walkval_ValueChanged(object sender, EventArgs e)
    {
      this.SaveMainFormSettings();
    }

    private void addsentrymap_Click(object sender, EventArgs e)
    {
      if (!(this.newsentrymap.Text != string.Empty))
        return;
      this.AlarmMapsList.Items.Add((object) this.newsentrymap.Text);
      this.newsentrymap.Text = "";
      this.newsentrymap.Focus();
      this.SaveMainFormSettings();
    }

    private void newsentrymap_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      e.Handled = true;
      this.addsentrymap.PerformClick();
    }

    private void deletesentrymap_Click(object sender, EventArgs e)
    {
      if (this.AlarmMapsList.SelectedItem == null)
        return;
      this.AlarmMapsList.Items.Remove(this.AlarmMapsList.SelectedItem);
      this.SaveMainFormSettings();
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.ALARMquiet.wav"));
      Server.alarmTimer = DateTime.UtcNow;
      Server.alarm.Play();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.MotherElevatorMuzak.wav"));
      Server.alarmTimer = DateTime.UtcNow;
      Server.alarm.Play();
    }

    private void button4_Click(object sender, EventArgs e)
    {
      Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.Dcalarm1.wav"));
      Server.alarmTimer = DateTime.UtcNow;
      Server.alarm.Play();
    }

    private void button1_Click_2(object sender, EventArgs e)
    {
      Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.LTTP_LowHealth.wav"));
      Server.alarmTimer = DateTime.UtcNow;
      Server.alarm.Play();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.Ding.wav"));
      Server.alarmTimer = DateTime.UtcNow;
      Server.alarm.Play();
    }

    private void oldanim_CheckedChanged(object sender, EventArgs e)
    {
      MainForm.voldanim = this.oldanim.Checked;
      this.SaveMainFormSettings();
    }

    private void loglabormules_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.loglabormules.Checked || this.labormulelist.Items.Count <= 0)
        return;
      foreach (Client client in Server.Alts.Values.ToArray<Client>())
      {
        foreach (object obj in this.labormulelist.Items)
        {
          if (obj.ToString().ToLower().Contains(client.Name.ToLower()))
          {
            client.Tab.laborname.Text = Program.MainForm.laborname.Text;
            client.Tab.btnPlay.PerformClick();
            client.Tab.autowalker_locales.Text = "Nearest Bank";
            client.Tab.walksettings.Value = new Decimal(250);
            client.Tab.autowalker_button.Text = "Stop";
            client.autowalkon = true;
            break;
          }
        }
      }
    }

    private void newmule_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      e.Handled = true;
      this.newmulepw.Focus();
    }

    private void newmulepw_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      e.Handled = true;
      this.addmule.PerformClick();
    }

    private void addmule_Click(object sender, EventArgs e)
    {
      if (!(this.newmule.Text != string.Empty) || !(this.newmulepw.Text != string.Empty))
        return;
      this.labormulelist.Items.Add((object) (this.newmule.Text + "," + this.newmulepw.Text));
      this.newmule.Text = "";
      this.newmule.Focus();
    }

    private void deletemule_Click(object sender, EventArgs e)
    {
      if (this.labormulelist.SelectedItem == null)
        return;
      this.labormulelist.Items.Remove(this.labormulelist.SelectedItem);
    }

    private void clearlist_Click(object sender, EventArgs e)
    {
      this.labormulelist.Items.Clear();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.SaveMuleList();
    }

    private void loadlabormulelist_Click(object sender, EventArgs e)
    {
      this.LoadMuleList();
    }

    private void deletelabormulelist_Click(object sender, EventArgs e)
    {
      if (this.savedlabormulelists.SelectedItem == null || !Directory.Exists(Program.StartupPath + "\\Settings\\labormules") || !File.Exists(Program.StartupPath + "\\Settings\\labormules\\" + this.savedlabormulelists.SelectedItem.ToString() + ".xml"))
        return;
      object selectedItem = this.savedlabormulelists.SelectedItem;
      File.Delete(Program.StartupPath + "\\Settings\\labormules\\" + this.savedlabormulelists.SelectedItem.ToString() + ".xml");
      this.savedlabormulelists.Items.Remove(selectedItem);
    }

    public void SaveMuleList()
    {
      if (this.Saving || this.Loading)
        return;
      this.Saving = true;
      if (this.savemulelistname.Text != string.Empty)
      {
        XDocument xdocument = new XDocument();
        xdocument.Add((object) new XElement((XName) "LaborMules"));
        xdocument.Element((XName) "LaborMules").Add((object) new XElement((XName) "ListLength", (object) this.labormulelist.Items.Count));
        int num = 0;
        foreach (object obj in this.labormulelist.Items)
        {
          xdocument.Element((XName) "LaborMules").Add((object) new XElement((XName) ("mule" + (object) num), (object) obj.ToString()));
          ++num;
        }
        if (Directory.Exists(Program.StartupPath + "\\Settings\\labormules"))
        {
          xdocument.Save(Program.StartupPath + "\\Settings\\labormules\\" + this.savemulelistname.Text + ".xml");
        }
        else
        {
          Directory.CreateDirectory(Program.StartupPath + "\\Settings\\labormules");
          xdocument.Save(Program.StartupPath + "\\Settings\\labormules\\" + this.savemulelistname.Text + ".xml");
        }
        this.PopulateSavedListBox();
      }
      this.Saving = false;
    }

    public void LoadMuleList()
    {
      if (this.Loading || this.Saving)
        return;
      this.Loading = true;
      if (this.savedlabormulelists.SelectedItem != null && Directory.Exists(Program.StartupPath + "\\Settings\\labormules") && File.Exists(Program.StartupPath + "\\Settings\\labormules\\" + this.savedlabormulelists.SelectedItem.ToString() + ".xml"))
      {
        XDocument xdocument = XDocument.Load(Program.StartupPath + "\\Settings\\labormules\\" + this.savedlabormulelists.SelectedItem.ToString() + ".xml");
        for (int index = 0; index < (int) Convert.ToUInt16(xdocument.Element((XName) "LaborMules").Element((XName) "ListLength").Value); ++index)
        {
          if (xdocument.Element((XName) "LaborMules").Element((XName) ("mule" + (object) index)).Value != string.Empty && !this.labormulelist.Items.Contains((object) xdocument.Element((XName) "LaborMules").Element((XName) ("mule" + (object) index)).Value))
            this.labormulelist.Items.Add((object) xdocument.Element((XName) "LaborMules").Element((XName) ("mule" + (object) index)).Value);
        }
      }
      this.Loading = false;
    }

    public void PopulateSavedListBox()
    {
      if (!Directory.Exists(Program.StartupPath + "\\Settings\\labormules"))
        return;
      FileInfo[] files = new DirectoryInfo(Program.StartupPath + "\\Settings\\labormules").GetFiles("*.xml");
      string empty = string.Empty;
      foreach (FileInfo fileInfo in files)
      {
        int startIndex = fileInfo.Name.IndexOf(".xml");
        string str = fileInfo.Name.Remove(startIndex);
        if (!this.savedlabormulelists.Items.Contains((object) str))
          this.savedlabormulelists.Items.Add((object) str);
      }
    }

    public void LoadMainFormSettings()
    {
      if (!Directory.Exists(Program.StartupPath + "\\Settings") || !File.Exists(Program.StartupPath + "\\Settings\\mainsettings.xml"))
        return;
      XDocument xdocument = XDocument.Load(Program.StartupPath + "\\Settings\\mainsettings.xml");
      if (xdocument.Element((XName) "Settings") != null)
      {
        if (xdocument.Element((XName) "Settings").Element((XName) "UpdateNumber") != null)
          this.UpdateNumber = Convert.ToUInt32(xdocument.Element((XName) "Settings").Element((XName) "UpdateNumber").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "numofdas") != null)
          this.numOfDAs.Text = xdocument.Element((XName) "Settings").Element((XName) "numofdas").Value;
        if (xdocument.Element((XName) "Settings").Element((XName) "champalert") != null)
          this.champalert.Checked = Convert.ToBoolean(xdocument.Element((XName) "Settings").Element((XName) "champalert").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "collegealert") != null)
          this.collegealert.Checked = Convert.ToBoolean(xdocument.Element((XName) "Settings").Element((XName) "collegealert").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "alertondeath") != null)
          this.alertondeath.Checked = Convert.ToBoolean(xdocument.Element((XName) "Settings").Element((XName) "alertondeath").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "expalert") != null)
          this.expalert.Checked = Convert.ToBoolean(xdocument.Element((XName) "Settings").Element((XName) "expalert").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "playnoise") != null)
          this.playnoise.Checked = Convert.ToBoolean(xdocument.Element((XName) "Settings").Element((XName) "playnoise").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "alertonskull") != null)
          this.alertonskull.Checked = Convert.ToBoolean(xdocument.Element((XName) "Settings").Element((XName) "alertonskull").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "alarm_walk") != null)
          this.alarm_walk.Checked = Convert.ToBoolean(xdocument.Element((XName) "Settings").Element((XName) "alarm_walk").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "alarm_walkval") != null)
          this.alarm_walkval.Value = Convert.ToDecimal(xdocument.Element((XName) "Settings").Element((XName) "alarm_walkval").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "alarmmapcount") != null)
        {
          for (int index = 0; index < (int) Convert.ToInt16(xdocument.Element((XName) "Settings").Element((XName) "alarmmapcount").Value); ++index)
          {
            if (xdocument.Element((XName) "Settings").Element((XName) ("alarmmap_" + index.ToString())) != null && !this.AlarmMapsList.Items.Contains((object) xdocument.Element((XName) "Settings").Element((XName) ("alarmmap_" + index.ToString())).Value))
              this.AlarmMapsList.Items.Add((object) xdocument.Element((XName) "Settings").Element((XName) ("alarmmap_" + index.ToString())).Value);
          }
        }
        if (xdocument.Element((XName) "Settings").Element((XName) "oldanim") != null)
          this.oldanim.Checked = Convert.ToBoolean(xdocument.Element((XName) "Settings").Element((XName) "oldanim").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "relog") != null)
          this.relog.Checked = Convert.ToBoolean(xdocument.Element((XName) "Settings").Element((XName) "relog").Value);
        if (xdocument.Element((XName) "Settings").Element((XName) "recordchestdata") != null)
          this.recordchestdata.Checked = Convert.ToBoolean(xdocument.Element((XName) "Settings").Element((XName) "recordchestdata").Value);
      }
    }

    public void SaveMainFormSettings()
    {
      XDocument xdocument = new XDocument();
      xdocument.Add((object) new XElement((XName) "Settings"));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "UpdateNumber", (object) this.UpdateNumber));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "numofdas", (object) this.numOfDAs.Text));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "collegealert", (object) this.collegealert.Checked));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "champalert", (object) this.champalert.Checked));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "expalert", (object) this.expalert.Checked));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "alertondeath", (object) this.alertondeath.Checked));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "playnoise", (object) this.playnoise.Checked));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "alertonskull", (object) this.alertonskull.Checked));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "alarm_walk", (object) this.alarm_walk.Checked));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "alarm_walkval", (object) this.alarm_walkval.Value));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "alarmmapcount", (object) this.AlarmMapsList.Items.Count));
      for (int index = 0; index < this.AlarmMapsList.Items.Count; ++index)
        xdocument.Element((XName) "Settings").Add((object) new XElement((XName) ("alarmmap_" + index.ToString()), this.AlarmMapsList.Items[index]));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "oldanim", (object) this.oldanim.Checked));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "relog", (object) this.relog.Checked));
      xdocument.Element((XName) "Settings").Add((object) new XElement((XName) "recordchestdata", (object) this.recordchestdata.Checked));
      if (Directory.Exists(Program.StartupPath + "\\Settings"))
      {
        xdocument.Save(Program.StartupPath + "\\Settings\\mainsettings.xml");
      }
      else
      {
        Directory.CreateDirectory(Program.StartupPath + "\\Settings");
        xdocument.Save(Program.StartupPath + "\\Settings\\mainsettings.xml");
      }
    }

    private void chooseDAPathToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OptionsForm optionsForm = new OptionsForm();
      if (optionsForm.ShowDialog() != DialogResult.OK)
        return;
      string text = optionsForm.txtDarkAgesPath.Text;
      if (File.Exists(text))
      {
        Options.DarkAgesFileName = Path.GetFileName(text);
        Options.DarkAgesDirectoryName = Path.GetDirectoryName(text);
        Options.Save();
      }
    }

    private void launchMultiple_Click(object sender, EventArgs e)
    {
      if (!File.Exists(Options.FullDarkAgesPath))
      {
        int num = (int) MessageBox.Show(Options.FullDarkAgesPath + " could not be located.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        if (int.Parse(this.numOfDAs.Text) <= 0)
          return;
        this.SaveMainFormSettings();
        for (int index = 0; index < int.Parse(this.numOfDAs.Text); ++index)
          this.Launch();
      }
    }

    private void numOfDAs_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!(!char.IsDigit(e.KeyChar) & e.KeyChar != '\b'))
        return;
      e.Handled = true;
    }

    private void numOfDAs_TextChanged(object sender, EventArgs e)
    {
    }

    private void relog_CheckedChanged(object sender, EventArgs e)
    {
      this.SaveMainFormSettings();
    }

    private void editcustomloot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (!File.Exists(Program.StartupPath + "\\Settings\\Lists\\customlootlist.txt"))
        File.Create(Program.StartupPath + "\\Settings\\Lists\\customlootlist.txt");
      if (((IEnumerable<Process>) Process.GetProcessesByName("customlootlist.txt")).Count<Process>() != 0)
        return;
      Process.Start(Program.StartupPath + "\\Settings\\Lists\\customlootlist.txt");
    }

    private void editidentifyitems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (!File.Exists(Program.StartupPath + "\\Settings\\Lists\\identifyitemslist.txt"))
        File.Create(Program.StartupPath + "\\Settings\\Lists\\identifyitemslist.txt");
      if (((IEnumerable<Process>) Process.GetProcessesByName("identifyitemslist.txt")).Count<Process>() != 0)
        return;
      Process.Start(Program.StartupPath + "\\Settings\\Lists\\identifyitemslist.txt");
    }

    private void loadlistbtn_Click(object sender, EventArgs e)
    {
      this.Server.LoadLists();
    }

    private void recenttaskslist_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      if (e.Item.SubItems.Count != 3 || !Server.TimedEvent.ContainsKey(e.Item.Text + e.Item.SubItems[1].Text))
        return;
      Server.TimedEvent[e.Item.Text + e.Item.SubItems[1].Text].Track = e.Item.Checked;
      this.Server.SaveTasksList();
    }

    private void edittrashlist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (!File.Exists(Program.StartupPath + "\\Settings\\Lists\\trashlist.txt"))
        File.Create(Program.StartupPath + "\\Settings\\Lists\\trashlist.txt");
      if (((IEnumerable<Process>) Process.GetProcessesByName("trashlist.txt")).Count<Process>() != 0)
        return;
      Process.Start(Program.StartupPath + "\\Settings\\Lists\\trashlist.txt");
    }

    private void openitemxmleditor_Click(object sender, EventArgs e)
    {
      this.openitemxmleditor.Enabled = false;
      this.ItemXMLEditor.Show();
    }

    private void showall_CheckedChanged(object sender, EventArgs e)
    {
      this.Server.PopulateTasksListView();
      this.recenttaskslist.Focus();
    }

    private void recenttaskslist_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (e.Column != 2)
        return;
      this.recenttaskslist.BeginUpdate();
      this.recenttaskslist.Items.Clear();
      this.Server.PopulateTasksListView();
      this.recenttaskslist.EndUpdate();
    }

    private void recenttaskslist_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Delete)
        return;
      e.Handled = true;
      if (this.recenttaskslist.SelectedItems.Count > 0)
      {
        ListViewItem selectedItem = this.recenttaskslist.SelectedItems[0];
        if (Server.TimedEvent.ContainsKey(selectedItem.Text + selectedItem.SubItems[1].Text))
          Server.TimedEvent.Remove(selectedItem.Text + selectedItem.SubItems[1].Text);
        this.recenttaskslist.Items.Remove(selectedItem);
        this.Server.SaveTasksList();
      }
    }

    private void TaskFilter_Click(object sender, EventArgs e)
    {
      this.TaskFilter.BeginUpdate();
      this.TaskFilter.Items.Clear();
      this.TaskFilter.Items.Add((object) "All");
      this.TaskFilter.Text = "All";
      if (Server.TimedEvent.Count > 0)
      {
        foreach (TimedEvent timedEvent in Server.TimedEvent.Values.ToArray<TimedEvent>())
        {
          if (timedEvent != null && !this.TaskFilter.Items.Contains((object) timedEvent.Event))
            this.TaskFilter.Items.Add((object) timedEvent.Event);
        }
      }
      this.TaskFilter.EndUpdate();
    }

    private void oldanim_Click(object sender, EventArgs e)
    {
      if (this.oldanim.Checked)
        this.oldanim.Checked = false;
      else
        this.oldanim.Checked = true;
    }

    private void relog_Click(object sender, EventArgs e)
    {
      if (this.relog.Checked)
        this.relog.Checked = false;
      else
        this.relog.Checked = true;
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (!Directory.Exists(Program.StartupPath + "\\Settings"))
        Directory.CreateDirectory(Program.StartupPath + "\\Settings");
      StreamWriter streamWriter = new StreamWriter(Program.StartupPath + "\\Settings\\Slash Commands.txt");
      streamWriter.WriteLine("NOTE: DO NOTE TYPE QUOTES AND PARENTHESES, examples of correct way: /fast all, /send illtide bat's wing, /withdraw grime's skin [200]\r\nNOTE: Text in (parentheses) are optional");
      streamWriter.WriteLine("NOTE: Text in \"quotes\" will be defined by user");
      streamWriter.WriteLine("NOTE: In most cases (all) means all open clients, but not in the case of banking commands.\r\n\r\n/p (all) - play\r\n/s (all) - stop\r\n\r\n/safe - TOGGLE all visible 'hax' and hide the program. (hasnt been updated in a while, possibly doesnt hide everything now)");
      streamWriter.WriteLine("");
      streamWriter.WriteLine("/save \"template\" - Create/Save settings as a template.");
      streamWriter.WriteLine("/load (all) \"template\" - Load a template.");
      streamWriter.WriteLine("");
      streamWriter.WriteLine("/fast (all) - Set walk delay to 160 ms.\r\n/med (all) - Set walk delay to 260 ms.\r\n/slow (all) - Set walk delay to 410 ms.\r\n/stop (all) - Stop walking/following.");
      streamWriter.WriteLine("/follow (all) \"name\" (\"#\") - Follow someone, set distance.");
      streamWriter.WriteLine("/walk (all) \"destination\" - Walk to an area on the list.");
      streamWriter.WriteLine("(see bottom of .txt for full list)");
      streamWriter.WriteLine("");
      streamWriter.WriteLine("/g \"name\"or(alts)or(friends) - invite someone into your group.");
      streamWriter.WriteLine("/fg \"name\"or(alts)or(friends) - force yourself into an existing group.");
      streamWriter.WriteLine("");
      streamWriter.WriteLine("/calc on - Turn on calculator (starts all 3 if none checked).\r\n/calc off - Turn off calculator.\r\n/calc reset - Reset calculator data.\r\n/calc - Request calculator data.\r\n\r\nLEGIT BANKING ETC. (use at npc)");
      streamWriter.WriteLine("/d(a) \"item\" - deposit item (uses skill chant)");
      streamWriter.WriteLine("/w(a) \"item\" - withdraw item (uses skill chant)");
      streamWriter.WriteLine("/b \"item\" - buys item (skill chant)");
      streamWriter.WriteLine("/drop (all) \"item\" - drops all of said item below you. '/drop all chaos' to drop chaos junk");
      streamWriter.WriteLine("/r - say repair all (skill chant)");
      streamWriter.WriteLine("/fix - Walks to nearest repair NPC and says repair all (skill chant)");
      streamWriter.WriteLine("");
      streamWriter.WriteLine("HAX BANKING (uses Nearest Npc)\r\n/withdraw - activate withdraw item script.");
      streamWriter.WriteLine("/withdraw (all) \"item\" (\"[#]\") - withdraw item, optional #");
      streamWriter.WriteLine("format: /withdraw blue frog meat [10]\r\n/deposit - activate deposit item script.");
      streamWriter.WriteLine("/deposit (all) \"item\" (\"[#]\") - deposit item, optional #");
      streamWriter.WriteLine("/send - activate send parcel script. (do not parcel STACKS)");
      streamWriter.WriteLine("/send \"name\" \"item\" - bypass the scripts and just send the item to the person");
      streamWriter.WriteLine("/rec (all) - receives parcel(s).\r\n/repair - repairs all items.");
      streamWriter.WriteLine("");
      streamWriter.WriteLine("OTHER STUFF\r\n/hide (all) - toggles hide checkbox for rogues/white bat\r\n/b - disable body animations checkbox toggle\r\n/n - Toggle walls.\r\n/m - Toggle Monster Form.");
      streamWriter.WriteLine("/m\"#\" - Switch monster form number.");
      streamWriter.WriteLine("/map - Get current map number.\r\n/item - Get first item slot image.\r\n/icon - Get list of icon image #s from spell bar (whats currently casted on you)\r\n/banklist - creates and opens a .txt file alphabetical list of your banked items (using nearest banker)\r\n/quest - opens an in-game peek-type menu of That chars quests timers\r\n/boss - opens an in-game peek-type menu of that chars boss kill timers\r\n/ao - casts gramail prayer remove all spells (ao sith)\r\n/ref - casts gramail prayer reflect\r\n/fiobean or /diabean - casts fiosachd prayer dia bean\r\n/fiohide - casts fiosachd prayer group hide\r\n/song - casts prayer and prays for scrolls\r\n/higgle - higgles wine and drops it repeatedly till 180 wine higgled or pause program (at abel bank)\r\n/fiorsrad - buys 30 fior srads instantly at black market (required for yule tree event in december)\r\n/readmail - instantly reads all your mail to get rid of flickering mail icon (must manually open mail/scroll to bottom/close it first)");
      streamWriter.WriteLine("/beg \"item\" - instantly give beggar an item (gotta be in view)");
      streamWriter.WriteLine("/dojo - walks to wasteland and enters dojo (same effect as clicking the checkbox)");
      streamWriter.WriteLine("/labor \"name\" - walks to nearest bank and labors till you're out");
      streamWriter.WriteLine("");
      streamWriter.WriteLine("QUEST\r\n/teach - says 'please teach me blah blah' at sapphire stream (it knows your dugon level already)\r\n/done - says 'i finished blah blah' at sapphire stream\r\n/darkmaze - does the small heart quest popups/walking up till dark maze entry (must have beothaich for quest)\r\n/thel - The Letter quest, meant to be done on a male and female char together, dual logged and GROUPED\r\n/molo - mothers love quest, walks to nearest restaurant and turns in Hydele/personaca Or Betony deum (must have potions already)\r\n/tali - instantly does popups to buy 2nd half talisman at nobis bank\r\n/pearl - Giant Pearl quest, walks to lynith sea popup location, PICKS UP swimwear, equips it, gets pearl, drops both\r\n/tent - dragon scale sword quest, walks to mileth tavern, starts quest, walks to sw6 dragon eye (must have Tentacle already)\r\n/law - law quest, all the walking + popups, waits for boss fights, waits for rehide at lr1 npc, (must have 5 of each giant remains)\r\n/wd (all) - say Water Dungeon chant to progress floors.\r\n/slab - walks to hwarone inn and says marble slab, walks to lr ent-waits for hide, walks to lr4 slab room\r\n\r\nEVENT\r\n/meg - walks to mt merry ent and clicks mother erbie to claim prize AFTER KILLING 20 chocolate erbies (December)\r\n/frosty - walks to loures fountain and claims free gifts (December)\r\n/yule - does some yule event automation, i dont even remember what (December)\r\n/wish - does some make a wish event automation, dont remember what (January)\r\n/attire - walks to paradise and claims the free beach attire overcoat (free war bag trade in~) (July)\r\n/hat - walks to loures fountain and claims free sun protection (billed cap) (July)\r\n\r\nSome Item names can be typed shorthand for withdrawing/depositing etc commands\r\nhem = hemloch deum\r\nkom = komadium\r\nsuc = succubus's hair\r\nwar = warranty bag\r\ngsf = golden starfish\r\ndouble = double bonus exp-ap(x5)\r\nvday = vday bonus exp-ap(x10)\r\nxmas d = xmas double exp-ap(x5)\r\narmor = all ab 20/22/27/25/45 armors (/da only)\r\ncea = str set (/da only)\r\nlua = int set (/da only)\r\ngli = wis set (/da only)\r\ncai = con set (/da only)\r\nfio = dex set (/da only)\r\n\r\nWalk destinations: (say /walk altar, /walk cc7, etc)\r\nbank - walks to the NEAREST bank, abel, mileth, ruc, or tagor\r\nabel bank - walks abel bank specifically\r\nmileth bank - ~\r\nrucesion bank - ~\r\nbm - rucesion black market\r\naltar - mileth altar\r\ntailor - mileth tailor\r\nmaze - loures lovers maze\r\nthrone - loures throne room\r\nblob - canal key 2 ent\r\nskrull - canal key 1 ent\r\nflower - mehadi swamp sevti blossom location\r\npara - paradise event at lynith\r\ncr or cr1\r\ncr31\r\nvort - (vortigern (chief) in aj)\r\nori - (oriana in aj)\r\nglen - (glenna (bank) in aj)\r\njov - (jovino (skill swap) in aj)\r\naj - entrance to aj 1\r\naj6 - (weylin for elemus hunt)\r\nden - entrance to aj8 (a room that spawns dendrons)\r\nhg\r\ncc\r\ncc7\r\nyt\r\nyt3\r\nyt5\r\nyt6\r\nyt11\r\nyt12\r\nyt15\r\nandor\r\nandor80\r\nandor140 or queen\r\nchaos\r\nchaos12\r\nchaos34\r\nnob - nobis village\r\nsham\r\nmedu - for medusa\r\nsw or sw22\r\nphoe - for phoenix\r\ntauren or mtg or mtg10\r\nmtg13\r\nch (for cursed home)\r\nveltain or mines or vm\r\nwd\r\nlr");
      streamWriter.Close();
      if (!File.Exists(Program.StartupPath + "\\Settings\\Slash Commands.txt"))
        return;
      bool flag = false;
      foreach (Process process in Process.GetProcesses())
      {
        if (process.MainWindowTitle == "Slash Commands.txt - Notepad")
          flag = true;
      }
      if (!flag)
        Process.Start(Program.StartupPath + "\\Settings\\Slash Commands.txt");
    }

    private void recordchestdata_CheckedChanged(object sender, EventArgs e)
    {
      this.SaveMainFormSettings();
    }

    private void viewPatchNotesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Updates.Show();
    }

    private void editignorepeoplelist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (!File.Exists(Program.StartupPath + "\\Settings\\Lists\\ignoreaislingslist.txt"))
        File.Create(Program.StartupPath + "\\Settings\\Lists\\ignoreaislingslist.txt");
      if (((IEnumerable<Process>) Process.GetProcessesByName("ignoreaislingslist.txt")).Count<Process>() != 0)
        return;
      Process.Start(Program.StartupPath + "\\Settings\\Lists\\ignoreaislingslist.txt");
    }

    private void editwsbanlist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (!File.Exists(Program.StartupPath + "\\Settings\\Lists\\wsbanlist.txt"))
        File.Create(Program.StartupPath + "\\Settings\\Lists\\wsbanlist.txt");
      if (((IEnumerable<Process>) Process.GetProcessesByName("wsbanlist.txt")).Count<Process>() != 0)
        return;
      Process.Start(Program.StartupPath + "\\Settings\\Lists\\wsbanlist.txt");
    }

    private void clearasensionlog_Click(object sender, EventArgs e)
    {
      Server.AscendLog.Clear();
      this.ascensionlistview.Items.Clear();
      this.Server.SaveAscendLog();
    }

    private void skulledlistview_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Delete)
        return;
      e.Handled = true;
      if (this.skulledlistview.SelectedItems.Count > 0)
      {
        ListViewItem selectedItem = this.skulledlistview.SelectedItems[0];
        if (Server.SkullList.ContainsKey(selectedItem.Text))
          Server.SkullList.Remove(selectedItem.Name);
        this.skulledlistview.Items.Remove(selectedItem);
        this.Server.SaveSkullList();
      }
    }
  }
}
