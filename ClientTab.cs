// Decompiled with JetBrains decompiler
// Type: ProxyBase.ClientTab
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProxyBase
{
    public class ClientTab : TabPage
    {
        private IContainer components = (IContainer)null;
        public targetGroup targetgroup = (targetGroup)null;
        public TargetAllMonster allMonsters = (TargetAllMonster)null;
        public TargetMonster Monsters = (TargetMonster)null;
        public targetPlayer Players = (targetPlayer)null;
        public targetMonsterbyPlayer MonstersByPlayer = (targetMonsterbyPlayer)null;
        public targetAlts allalts = (targetAlts)null;
        public SpellData lurespellwith = (SpellData)null;
        private int macroonce = 1;
        private int comboonce = 1;
        private int ascendonce = 1;
        private int hideonce = 1;
        private int arecoonce = 1;
        private int swaponce = 1;
        public bool vslash_commands = true;
        public bool vdisableallbody = false;
        public bool vdisableallspell = false;
        public bool vusemonster = false;
        public int vusemonsterid = 1;
        public bool vmonitordion = false;
        public bool vmonitorcurses = false;
        public bool vmonitorspells = false;
        public bool vfriendspeak = false;
        public bool vautobuyhems = false;
        public bool vautobuykoms = true;
        public bool vwayregionson = false;
        public int vfollowdist = 3;
        public int vwalksettings = 410;
        public bool vfollowplayer = false;
        public string vfollowtarget = string.Empty;
        public bool vcastwhilefollow = false;
        public string vwalklocaleslist = string.Empty;
        public string vautowalker_locales = string.Empty;
        public string vselfaitetype = string.Empty;
        public string vselffastype = string.Empty;
        public string vioctype = string.Empty;
        public string vfscond = "3000";
        public int viocselfcond = 80;
        public bool vaegissphere = false;
        public bool vstaffswitch = true;
        public bool vselfaite = false;
        public bool vselffas = false;
        public bool vselfbean = false;
        public bool vselffasdeireas = false;
        public bool vselfcreagneart = false;
        public bool vselfmist = false;
        public bool vselfregen = false;
        public bool vselfca = false;
        public bool vselfaosuain = false;
        public bool vselfaopuinsein = false;
        public bool vaocurse = false;
        public bool vselfbc = false;
        public bool vselfarm = false;
        public bool vselfhide = false;
        public bool vdisenchanter = false;
        public bool vdruidform = false;
        public bool viocself = false;
        public bool vfs = false;
        public bool vgetimage = false;
        public double startexp = -1.0;
        public double startap = -1.0;
        public double startgold = -1.0;
        public double apcounter = 0.0;
        public double totaltime = 0.0;
        public double endexp = 0.0;
        public double endap = 0.0;
        public double endgold = 0.0;
        public bool vwaitonmonsters = false;
        public bool vactonlyinmobs = false;
        public bool vredaislings = true;
        public bool vpotion = false;
        public int vpotioncond = 1;
        public bool vmantidscent = false;
        public bool vinsectcloak = false;
        public bool vassassinscroll = false;
        public bool vfungusbeetleextract = false;
        public bool vdragonsfire = false;
        public bool vdragonsscale = false;
        public bool vmusclestimulant = false;
        public bool vnervestimulant = false;
        public bool vwakescroll = true;
        public bool vicebottle = true;
        public bool velemusmount = false;
        public bool vdropitemson = false;
        public string vlootlocale = string.Empty;
        public bool vwalktoloot = false;
        public string vrescueascendername = string.Empty;
        public bool vrescueascender = false;
        public bool vassistonthischar = false;
        public bool vimpskillbutton = false;
        public bool vlaborbutton = false;
        public bool vpraybutton = false;
        private RichTextBox textConsoleOutput;
        private Panel panel1;
        private RichTextBox textConsoleInput;
        private Button buttonSend;
        private Button buttonRecv;
        private CheckBox checkRecv;
        private CheckBox checkSend;
        public CheckBox usemonster;
        private TabControl mainOptions;
        private TabPage tabPage1;
        private TabPage tabPage2;
        public NumericUpDown usemonsterid;
        public CheckBox noblind;
        public CheckBox seeinvis;
        public CheckBox nowalls;
        private TabPage tabPage3;
        private ToolStrip toolStrip1;
        public ToolStripButton btnPlay;
        public CheckBox monitorspells;
        public CheckBox monitorcurses;
        public CheckBox monitordion;
        public CheckBox disableallspell;
        public CheckBox disableallbody;
        public CheckBox slash_commands;
        public ToolStripButton btnStop;
        private TabPage tabPage4;
        private Label label1;
        public NumericUpDown walksettings;
        public NumericUpDown followdist;
        private Label label2;
        public CheckBox fastwalk;
        public CheckBox mediumwalk;
        public TextBox followtarget;
        public CheckBox followplayer;
        public CheckBox castwhilefollow;
        private Label label3;
        public ComboBox autowalker_locales;
        public ListBox walklocaleslist;
        public Button autowalker_button;
        public Button walkconfig;
        public CheckBox wayregionson;
        public CheckBox dfmonsters;
        public CheckBox asgallmonsters;
        public CheckBox aegissphere;
        public CheckBox selfmist;
        public CheckBox druidform;
        public ComboBox selffastype;
        public ComboBox selfaitetype;
        public CheckBox selfca;
        public CheckBox selfregen;
        public CheckBox selfhide;
        public CheckBox staffswitch;
        public CheckBox disenchanter;
        public CheckBox selfcreagneart;
        public CheckBox selfbc;
        public CheckBox aocurse;
        public CheckBox selfaopuinsein;
        public CheckBox selfaosuain;
        public CheckBox selfarm;
        public CheckBox selffasdeireas;
        public CheckBox selfbean;
        public CheckBox selffas;
        public CheckBox selfaite;
        public GroupBox group_dion;
        private Label label19;
        public NumericUpDown dion_enemiesonscreenvalue;
        public CheckBox dion_enemiesonscreen;
        private Label label27;
        public NumericUpDown dion_enemiesnextcount;
        public CheckBox dion_enemiesnext;
        public ComboBox diontype;
        public CheckBox dion_aosith;
        private Label label5;
        public NumericUpDown dion_hpcond;
        public CheckBox dion_lowhp;
        public ComboBox ioctype;
        public NumericUpDown iocselfcond;
        private Label label4;
        public CheckBox fs;
        public CheckBox iocself;
        public TextBox fscond;
        public CheckBox safemode;
        public CheckBox friendspeak;
        public CheckBox autobuyhems;
        public CheckBox autobuykoms;
        private TabPage tabPage5;
        private GroupBox groupBox3;
        private Label currenttemplateupdated;
        private Button updatecurrent;
        public Label loadedtemplate;
        private GroupBox groupBox5;
        public Label templatedeleted;
        public Label templateupdated2;
        private Button loaddefault;
        private Label template_loaded_message;
        private Button delete_template;
        public Button loadtemplate;
        public ListBox template_lists;
        private GroupBox groupBox21;
        public Label templatesaved;
        public Label newtemplate_error;
        public Button newtemplate_save;
        private Label label22;
        public TextBox newtemplate_name;
        private TabPage tabPage6;
        private GroupBox groupBox45;
        private Label label46;
        public NumericUpDown nolongermobbed;
        private Label label39;
        public NumericUpDown mobdistance;
        private Label dumbtext;
        private Label label7;
        public NumericUpDown mobsize;
        public CheckBox actonlyinmobs;
        private GroupBox groupBox16;
        public CheckBox calc_message;
        public Button calc_reset;
        public Button calc_toggle;
        private CheckBox calc_gold;
        private CheckBox calc_ap;
        private CheckBox calc_exp;
        private GroupBox groupBox4;
        public RadioButton lurewithskills;
        public RadioButton lurewithspells;
        public RadioButton waitonmonsters;
        private TabPage tabPage7;
        public GroupBox trinket_holder;
        public CheckBox elemusmount;
        public CheckBox insectcloak;
        public CheckBox assassinscroll;
        public CheckBox nervestimulant;
        public CheckBox musclestimulant;
        public CheckBox dragonsscale;
        public CheckBox dragonsfire;
        public CheckBox fungusbeetleextract;
        public CheckBox wakescroll;
        public CheckBox icebottle;
        public CheckBox mantidscent;
        public CheckBox walktoloot;
        public ComboBox lootlocale;
        private GroupBox groupBox1;
        private GroupBox groupBox46;
        public TextBox dropitemstext;
        public Button dropitemsremove;
        public Button dropitemsadd;
        public ListBox dropitemslist;
        public CheckBox dropitemson;
        public TextBox newitem;
        public Button removeitem;
        public Button additem;
        public ListBox autodepositlistbox;
        public CheckBox autodepositon;
        private GroupBox groupBox2;
        private TabPage playertab;
        private TabPage newTarget;
        private TabPage tabPage10;
        private TabPage monstertab;
        public TabControl spellTargets;
        public TabControl spellgroup;
        public CheckBox newalts;
        public TextBox newplayername;
        private Button createnewtarget;
        public CheckBox newallgrouped;
        public CheckBox newplayer;
        public TabControl spellMonsters;
        private TabPage tabPage8;
        public CheckBox newmonster;
        public CheckBox getimage;
        public CheckBox newallmonsters;
        public Button createnewmonster;
        public CheckBox newmonsterbyplayer;
        public TextBox newmonstername;
        public NumericUpDown potioncond;
        private Label label10;
        public CheckBox potion;
        public CheckBox redaislings;
        public Button openpriorityform;
        public CheckBox looton;
        public Label monsterexists;
        public TextBox newmonsterbyplayername;
        public Label alreadyexists;
        public ComboBox lurespells;
        public RadioButton lurewithlamh;
        public CheckBox expapbonus;
        public TextBox onlylurewithmpamount;
        public CheckBox onlylurewithmp;
        public RadioButton nolure;
        public CheckBox dojo;
        public CheckBox walktored;
        private TabPage tabPage9;
        private GroupBox groupBox9;
        public CheckBox comboscroll;
        public CheckBox comboscrollnoshield;
        private GroupBox groupBox7;
        public CheckBox pramhedonly;
        public CheckBox cursedonly;
        public CheckBox fasedonly;
        private GroupBox groupBox8;
        public CheckBox useskills;
        public CheckBox asrs;
        public CheckBox useskillshidden;
        public CheckBox attackinfinitemr;
        public CheckBox walktomonster;
        public CheckBox assail;
        public CheckBox pd;
        public CheckBox pf;
        public CheckBox equipshield;
        public CheckBox equipweapon;
        public CheckBox aodall;
        private TabPage tabPage11;
        public CheckBox respondflower;
        private TabPage tabPage12;
        private GroupBox groupBox25;
        public TextBox requestlabormessagetext;
        private Label label48;
        public TextBox requestlabornametext;
        public CheckBox requestlabor;
        public TextBox impskillinresponsetext;
        public CheckBox impskillinresponse;
        public Button impskillbutton;
        public TextBox skillassistant;
        public CheckBox useskillassistant;
        public ComboBox improveskill;
        private GroupBox groupBox26;
        public ComboBox prayernecklist;
        private GroupBox groupBox47;
        public TextBox prayxytext;
        public RadioButton prayxy;
        public RadioButton prayhere;
        public Button praybutton;
        public TextBox prayerassistant;
        public CheckBox useprayassistant;
        public RadioButton praytemple;
        public RadioButton praynecklace;
        private GroupBox groupBox24;
        public TextBox laborinresponsetext;
        public CheckBox laborinresponse;
        public CheckBox laborlogoff;
        public TextBox laborwhispertext;
        public CheckBox laborwhisper;
        public Button laborbutton;
        public TextBox laborname;
        public CheckBox assistonthischar;
        public Button openmacroform;
        public Button opencomboform;
        public Button openascendform;
        public TextBox rescueascendername;
        public CheckBox rescueascender;
        private TabPage tabPage13;
        private Label label9;
        private Label label8;
        private Label label11;
        public NumericUpDown reactdelaya;
        public CheckBox openveltchest;
        public CheckBox iditems;
        public CheckBox insectassail;
        private GroupBox groupBox32;
        public TextBox requesttextflower;
        public TextBox requesttextred;
        public TextBox requesttextfas;
        public TextBox requesttextaite;
        public NumericUpDown requestflowercond;
        public CheckBox requestred;
        public CheckBox requestflower;
        public CheckBox requestfas;
        public CheckBox requestaite;
        private GroupBox groupBox11;
        public CheckBox respondfas;
        public CheckBox respondaite;
        public CheckBox pigwalk;
        private GroupBox groupBox13;
        public CheckBox buygems;
        public RadioButton ruby;
        public RadioButton coral;
        public RadioButton beryl;
        public CheckBox recorditemdata;
        public Button vanishingelixir;
        public CheckBox usecrasher;
        public CheckBox clickladder;
        public CheckBox openmedchest;
        public CheckBox bubblenorajo;
        public CheckBox halfcast;
        public NumericUpDown lootdelayb;
        private Label label13;
        public NumericUpDown lootdelaya;
        private Label label12;
        public NumericUpDown reactdelayb;
        private Label label14;
        public NumericUpDown newtargetdelayb;
        private Label label15;
        public NumericUpDown newtargetdelaya;
        private Label label16;
        private Label label21;
        public NumericUpDown switchtargetdelayb;
        private Label label18;
        public NumericUpDown switchtargetdelaya;
        private Label label20;
        private Label label17;
        private TabPage tabPage14;
        public NumericUpDown spellaninum;
        private Label label6;
        public NumericUpDown testnum;
        private Button button1;
        private GroupBox groupBox31;
        public NumericUpDown duovercoatnum;
        public CheckBox duovercoat;
        private Label label23;
        public NumericUpDown duacc2color;
        public NumericUpDown duacc1color;
        public NumericUpDown dubootcolor;
        public NumericUpDown duhatcolor;
        private Label label24;
        public NumericUpDown dupantsnum;
        public CheckBox dupants;
        public NumericUpDown duacc2num;
        public NumericUpDown duacc1num;
        public CheckBox duacc2;
        public CheckBox duacc1;
        public NumericUpDown duskinnum;
        public NumericUpDown dufacenum;
        public CheckBox duskin;
        public CheckBox duface;
        public NumericUpDown dubootsnum;
        public NumericUpDown duarmornum;
        public NumericUpDown duweaponnum;
        public NumericUpDown dushieldnum;
        public NumericUpDown duhatnum;
        public CheckBox duboots;
        public CheckBox dushield;
        public CheckBox duweapon;
        public CheckBox duarmor;
        public CheckBox duhat;
        public NumericUpDown duacc3color;
        public NumericUpDown duacc3num;
        public CheckBox duacc3;
        public NumericUpDown duovercoatcolor;
        public NumericUpDown duunknown2;
        private Label label25;
        public Button openarenaform;
        public CheckBox disableitemsnstuff;
        public CheckBox useskillbonus;
        public NumericUpDown pfmonsters;
        private ToolTip toolTip1;
        public CheckBox tradeincostumes;
        public CheckBox throwtotems;
        private GroupBox groupBox6;
        public TextBox DAid1;
        public TextBox p4;
        public TextBox DAid2;
        public Button button4;
        public CheckBox useambush;
        private GroupBox gbpurewar;
        private Label purewarlabel;
        public CheckBox monitords;
        public Button openswapform;
        public CheckBox reequiparmor;
        public CheckBox chattimestamp;
        public CheckBox usefrost;
        public CheckBox walkclosebyonly;
        public NumericUpDown labordays;
        private Label label26;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label28;
        public CheckBox walkeverytile;
        public TextBox bottomx;
        public TextBox bottomy;
        public TextBox topy;
        public TextBox topx;
        private Label label32;
        public CheckBox altar;
        public CheckBox haltwalknonfriends;
        private Button button2;
        public NumericUpDown scriptidb;
        private Label label34;
        private Label label33;
        public NumericUpDown npcid;
        public Button togglehaxloop;
        private Label label35;
        public NumericUpDown haxtimenum;
        public CheckBox trashorbs;
        private Label label36;
        public NumericUpDown drophaxnpcid;
        private Button drophaxbtn;
        public TextBox drophaxtxt;
        private Label label37;
        public CheckBox xpshroom;
        public CheckBox abrune;
        private GroupBox groupBox10;
        public CheckBox getmonsterid2;
        public CheckBox haxdeposit;
        public CheckBox ignorewalkall;
        public TextBox openveltchestgold;
        private Label label38;
        public CheckBox walktowards;
        public CheckBox getrealnames;
        private Label label41;
        private Label label40;
        public NumericUpDown itemColor;
        public NumericUpDown itemNum;
        public CheckBox all5classes;
        public CheckBox briescantattack;
        public CheckBox enterbugs;
        public NumericUpDown skillgrouprangenum;
        public CheckBox skillgrouprange;
        public CheckBox castbries;
        public CheckBox attackleaderstarget;
        public CheckBox disablesnow;
        public Button legendopen;
        public CheckBox studycreaturetxt;
        public CheckBox walkao;
        public CheckBox walkdion;
        public CheckBox walkambush;
        public CheckBox walkheal;
        public CheckBox switchneck;
        public CheckBox stopfollow;
        public CheckBox useexpgem;
        public CheckBox expgemmp;
        public NumericUpDown brieshits;
        private Label label42;
        public CheckBox uncheckloot;
        private GroupBox groupBox14;
        private GroupBox groupBox12;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private GroupBox groupBox15;
        private Label label43;
        private Label label44;
        public CheckBox destroytonics;
        public CheckBox recordmaps;
        public CheckBox beadummy;
        public NumericUpDown scriptida;
        public Wayregion Wayregion;
        public System.Windows.Forms.Timer TemplateSaveTimer;
        public SkillSwap SkillSwap;
        public LegendMarks LegendMarks;
        public ArenaCounter ArenaCounter;
        public MacroOptions MacroOptions;
        public ComboOptions1 ComboOptions;
        public AscendOptions AscendOptions;
        public HideTrinketOptions HideTrinketOptions;
        public ExternalChat ExternalChat;
        public SpellPriority SpellPriority;
        public System.Timers.Timer calctimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ClientTab));
            this.textConsoleOutput = new RichTextBox();
            this.panel1 = new Panel();
            this.textConsoleInput = new RichTextBox();
            this.buttonSend = new Button();
            this.buttonRecv = new Button();
            this.checkRecv = new CheckBox();
            this.checkSend = new CheckBox();
            this.usemonster = new CheckBox();
            this.mainOptions = new TabControl();
            this.tabPage3 = new TabPage();
            this.spellgroup = new TabControl();
            this.tabPage10 = new TabPage();
            this.spellTargets = new TabControl();
            this.playertab = new TabPage();
            this.halfcast = new CheckBox();
            this.bubblenorajo = new CheckBox();
            this.aodall = new CheckBox();
            this.openpriorityform = new Button();
            this.staffswitch = new CheckBox();
            this.group_dion = new GroupBox();
            this.label19 = new Label();
            this.dion_enemiesonscreenvalue = new NumericUpDown();
            this.dion_enemiesonscreen = new CheckBox();
            this.label27 = new Label();
            this.dion_enemiesnextcount = new NumericUpDown();
            this.dion_enemiesnext = new CheckBox();
            this.diontype = new ComboBox();
            this.dion_aosith = new CheckBox();
            this.label5 = new Label();
            this.dion_hpcond = new NumericUpDown();
            this.dion_lowhp = new CheckBox();
            this.selfaite = new CheckBox();
            this.ioctype = new ComboBox();
            this.selffas = new CheckBox();
            this.iocselfcond = new NumericUpDown();
            this.selfbean = new CheckBox();
            this.label4 = new Label();
            this.selffasdeireas = new CheckBox();
            this.fs = new CheckBox();
            this.selfarm = new CheckBox();
            this.iocself = new CheckBox();
            this.selfaosuain = new CheckBox();
            this.fscond = new TextBox();
            this.selfaopuinsein = new CheckBox();
            this.dfmonsters = new CheckBox();
            this.aocurse = new CheckBox();
            this.asgallmonsters = new CheckBox();
            this.selfbc = new CheckBox();
            this.aegissphere = new CheckBox();
            this.selfcreagneart = new CheckBox();
            this.selfmist = new CheckBox();
            this.disenchanter = new CheckBox();
            this.druidform = new CheckBox();
            this.selfhide = new CheckBox();
            this.selffastype = new ComboBox();
            this.selfregen = new CheckBox();
            this.selfaitetype = new ComboBox();
            this.selfca = new CheckBox();
            this.newTarget = new TabPage();
            this.alreadyexists = new Label();
            this.newalts = new CheckBox();
            this.newplayername = new TextBox();
            this.createnewtarget = new Button();
            this.newallgrouped = new CheckBox();
            this.newplayer = new CheckBox();
            this.monstertab = new TabPage();
            this.spellMonsters = new TabControl();
            this.tabPage8 = new TabPage();
            this.label44 = new Label();
            this.groupBox15 = new GroupBox();
            this.label43 = new Label();
            this.label42 = new Label();
            this.brieshits = new NumericUpDown();
            this.briescantattack = new CheckBox();
            this.newmonster = new CheckBox();
            this.getimage = new CheckBox();
            this.newallmonsters = new CheckBox();
            this.newmonsterbyplayername = new TextBox();
            this.createnewmonster = new Button();
            this.newmonsterbyplayer = new CheckBox();
            this.newmonstername = new TextBox();
            this.monsterexists = new Label();
            this.tabPage9 = new TabPage();
            this.attackleaderstarget = new CheckBox();
            this.skillgrouprangenum = new NumericUpDown();
            this.skillgrouprange = new CheckBox();
            this.insectassail = new CheckBox();
            this.groupBox9 = new GroupBox();
            this.switchneck = new CheckBox();
            this.comboscroll = new CheckBox();
            this.comboscrollnoshield = new CheckBox();
            this.gbpurewar = new GroupBox();
            this.pfmonsters = new NumericUpDown();
            this.purewarlabel = new Label();
            this.pd = new CheckBox();
            this.pf = new CheckBox();
            this.groupBox8 = new GroupBox();
            this.castbries = new CheckBox();
            this.usefrost = new CheckBox();
            this.useambush = new CheckBox();
            this.usecrasher = new CheckBox();
            this.useskills = new CheckBox();
            this.asrs = new CheckBox();
            this.useskillshidden = new CheckBox();
            this.groupBox7 = new GroupBox();
            this.pramhedonly = new CheckBox();
            this.cursedonly = new CheckBox();
            this.fasedonly = new CheckBox();
            this.equipshield = new CheckBox();
            this.attackinfinitemr = new CheckBox();
            this.equipweapon = new CheckBox();
            this.walktomonster = new CheckBox();
            this.assail = new CheckBox();
            this.tabPage7 = new TabPage();
            this.iditems = new CheckBox();
            this.walktored = new CheckBox();
            this.potioncond = new NumericUpDown();
            this.label10 = new Label();
            this.potion = new CheckBox();
            this.groupBox2 = new GroupBox();
            this.uncheckloot = new CheckBox();
            this.walktoloot = new CheckBox();
            this.looton = new CheckBox();
            this.lootlocale = new ComboBox();
            this.groupBox1 = new GroupBox();
            this.haxdeposit = new CheckBox();
            this.newitem = new TextBox();
            this.removeitem = new Button();
            this.additem = new Button();
            this.autodepositlistbox = new ListBox();
            this.autodepositon = new CheckBox();
            this.groupBox46 = new GroupBox();
            this.dropitemstext = new TextBox();
            this.dropitemsremove = new Button();
            this.dropitemsadd = new Button();
            this.dropitemslist = new ListBox();
            this.dropitemson = new CheckBox();
            this.trinket_holder = new GroupBox();
            this.vanishingelixir = new Button();
            this.elemusmount = new CheckBox();
            this.insectcloak = new CheckBox();
            this.assassinscroll = new CheckBox();
            this.nervestimulant = new CheckBox();
            this.musclestimulant = new CheckBox();
            this.dragonsscale = new CheckBox();
            this.dragonsfire = new CheckBox();
            this.fungusbeetleextract = new CheckBox();
            this.wakescroll = new CheckBox();
            this.icebottle = new CheckBox();
            this.mantidscent = new CheckBox();
            this.redaislings = new CheckBox();
            this.tabPage6 = new TabPage();
            this.destroytonics = new CheckBox();
            this.expgemmp = new CheckBox();
            this.useexpgem = new CheckBox();
            this.openveltchestgold = new TextBox();
            this.label38 = new Label();
            this.xpshroom = new CheckBox();
            this.abrune = new CheckBox();
            this.reequiparmor = new CheckBox();
            this.throwtotems = new CheckBox();
            this.openmedchest = new CheckBox();
            this.pigwalk = new CheckBox();
            this.openveltchest = new CheckBox();
            this.expapbonus = new CheckBox();
            this.groupBox4 = new GroupBox();
            this.onlylurewithmpamount = new TextBox();
            this.onlylurewithmp = new CheckBox();
            this.nolure = new RadioButton();
            this.lurewithlamh = new RadioButton();
            this.lurespells = new ComboBox();
            this.lurewithskills = new RadioButton();
            this.lurewithspells = new RadioButton();
            this.waitonmonsters = new RadioButton();
            this.groupBox45 = new GroupBox();
            this.label46 = new Label();
            this.nolongermobbed = new NumericUpDown();
            this.actonlyinmobs = new CheckBox();
            this.label39 = new Label();
            this.mobdistance = new NumericUpDown();
            this.mobsize = new NumericUpDown();
            this.dumbtext = new Label();
            this.label7 = new Label();
            this.groupBox16 = new GroupBox();
            this.calc_gold = new CheckBox();
            this.calc_message = new CheckBox();
            this.calc_ap = new CheckBox();
            this.calc_reset = new Button();
            this.calc_exp = new CheckBox();
            this.calc_toggle = new Button();
            this.tabPage11 = new TabPage();
            this.groupBox11 = new GroupBox();
            this.respondflower = new CheckBox();
            this.respondfas = new CheckBox();
            this.respondaite = new CheckBox();
            this.groupBox32 = new GroupBox();
            this.requesttextflower = new TextBox();
            this.requesttextred = new TextBox();
            this.requesttextfas = new TextBox();
            this.requesttextaite = new TextBox();
            this.requestflowercond = new NumericUpDown();
            this.requestred = new CheckBox();
            this.requestflower = new CheckBox();
            this.requestfas = new CheckBox();
            this.requestaite = new CheckBox();
            this.tabPage4 = new TabPage();
            this.stopfollow = new CheckBox();
            this.walkao = new CheckBox();
            this.walkdion = new CheckBox();
            this.walkambush = new CheckBox();
            this.walkheal = new CheckBox();
            this.walktowards = new CheckBox();
            this.ignorewalkall = new CheckBox();
            this.haltwalknonfriends = new CheckBox();
            this.label32 = new Label();
            this.label31 = new Label();
            this.label30 = new Label();
            this.label29 = new Label();
            this.label28 = new Label();
            this.walkeverytile = new CheckBox();
            this.bottomx = new TextBox();
            this.bottomy = new TextBox();
            this.topy = new TextBox();
            this.topx = new TextBox();
            this.walkclosebyonly = new CheckBox();
            this.label25 = new Label();
            this.autowalker_button = new Button();
            this.walklocaleslist = new ListBox();
            this.autowalker_locales = new ComboBox();
            this.label3 = new Label();
            this.walkconfig = new Button();
            this.wayregionson = new CheckBox();
            this.castwhilefollow = new CheckBox();
            this.followdist = new NumericUpDown();
            this.label2 = new Label();
            this.followtarget = new TextBox();
            this.followplayer = new CheckBox();
            this.mediumwalk = new CheckBox();
            this.label1 = new Label();
            this.walksettings = new NumericUpDown();
            this.fastwalk = new CheckBox();
            this.tabPage12 = new TabPage();
            this.groupBox13 = new GroupBox();
            this.ruby = new RadioButton();
            this.coral = new RadioButton();
            this.beryl = new RadioButton();
            this.buygems = new CheckBox();
            this.rescueascendername = new TextBox();
            this.rescueascender = new CheckBox();
            this.openascendform = new Button();
            this.assistonthischar = new CheckBox();
            this.groupBox26 = new GroupBox();
            this.prayernecklist = new ComboBox();
            this.groupBox47 = new GroupBox();
            this.prayxytext = new TextBox();
            this.prayxy = new RadioButton();
            this.prayhere = new RadioButton();
            this.praybutton = new Button();
            this.prayerassistant = new TextBox();
            this.useprayassistant = new CheckBox();
            this.praytemple = new RadioButton();
            this.praynecklace = new RadioButton();
            this.groupBox24 = new GroupBox();
            this.labordays = new NumericUpDown();
            this.label26 = new Label();
            this.laborinresponsetext = new TextBox();
            this.laborinresponse = new CheckBox();
            this.laborlogoff = new CheckBox();
            this.laborwhispertext = new TextBox();
            this.laborwhisper = new CheckBox();
            this.laborbutton = new Button();
            this.laborname = new TextBox();
            this.groupBox25 = new GroupBox();
            this.requestlabormessagetext = new TextBox();
            this.label48 = new Label();
            this.requestlabornametext = new TextBox();
            this.requestlabor = new CheckBox();
            this.impskillinresponsetext = new TextBox();
            this.impskillinresponse = new CheckBox();
            this.impskillbutton = new Button();
            this.skillassistant = new TextBox();
            this.useskillassistant = new CheckBox();
            this.improveskill = new ComboBox();
            this.tabPage1 = new TabPage();
            this.studycreaturetxt = new CheckBox();
            this.legendopen = new Button();
            this.disablesnow = new CheckBox();
            this.enterbugs = new CheckBox();
            this.all5classes = new CheckBox();
            this.altar = new CheckBox();
            this.chattimestamp = new CheckBox();
            this.openswapform = new Button();
            this.monitords = new CheckBox();
            this.tradeincostumes = new CheckBox();
            this.useskillbonus = new CheckBox();
            this.disableitemsnstuff = new CheckBox();
            this.openarenaform = new Button();
            this.clickladder = new CheckBox();
            this.recorditemdata = new CheckBox();
            this.opencomboform = new Button();
            this.openmacroform = new Button();
            this.dojo = new CheckBox();
            this.friendspeak = new CheckBox();
            this.autobuyhems = new CheckBox();
            this.autobuykoms = new CheckBox();
            this.safemode = new CheckBox();
            this.slash_commands = new CheckBox();
            this.disableallbody = new CheckBox();
            this.disableallspell = new CheckBox();
            this.monitorspells = new CheckBox();
            this.monitorcurses = new CheckBox();
            this.monitordion = new CheckBox();
            this.noblind = new CheckBox();
            this.seeinvis = new CheckBox();
            this.nowalls = new CheckBox();
            this.usemonsterid = new NumericUpDown();
            this.tabPage5 = new TabPage();
            this.groupBox3 = new GroupBox();
            this.currenttemplateupdated = new Label();
            this.updatecurrent = new Button();
            this.loadedtemplate = new Label();
            this.groupBox5 = new GroupBox();
            this.templatedeleted = new Label();
            this.templateupdated2 = new Label();
            this.loaddefault = new Button();
            this.template_loaded_message = new Label();
            this.delete_template = new Button();
            this.loadtemplate = new Button();
            this.template_lists = new ListBox();
            this.groupBox21 = new GroupBox();
            this.templatesaved = new Label();
            this.newtemplate_error = new Label();
            this.newtemplate_save = new Button();
            this.label22 = new Label();
            this.newtemplate_name = new TextBox();
            this.tabPage13 = new TabPage();
            this.groupBox14 = new GroupBox();
            this.label9 = new Label();
            this.label8 = new Label();
            this.label21 = new Label();
            this.reactdelaya = new NumericUpDown();
            this.switchtargetdelayb = new NumericUpDown();
            this.label11 = new Label();
            this.label18 = new Label();
            this.label12 = new Label();
            this.switchtargetdelaya = new NumericUpDown();
            this.lootdelaya = new NumericUpDown();
            this.label20 = new Label();
            this.label13 = new Label();
            this.label17 = new Label();
            this.lootdelayb = new NumericUpDown();
            this.newtargetdelayb = new NumericUpDown();
            this.label14 = new Label();
            this.label15 = new Label();
            this.reactdelayb = new NumericUpDown();
            this.newtargetdelaya = new NumericUpDown();
            this.label16 = new Label();
            this.groupBox12 = new GroupBox();
            this.checkBox4 = new CheckBox();
            this.checkBox3 = new CheckBox();
            this.checkBox2 = new CheckBox();
            this.checkBox1 = new CheckBox();
            this.tabPage14 = new TabPage();
            this.beadummy = new CheckBox();
            this.recordmaps = new CheckBox();
            this.label41 = new Label();
            this.label40 = new Label();
            this.itemColor = new NumericUpDown();
            this.itemNum = new NumericUpDown();
            this.getrealnames = new CheckBox();
            this.getmonsterid2 = new CheckBox();
            this.groupBox10 = new GroupBox();
            this.togglehaxloop = new Button();
            this.haxtimenum = new NumericUpDown();
            this.label35 = new Label();
            this.trashorbs = new CheckBox();
            this.label37 = new Label();
            this.drophaxtxt = new TextBox();
            this.label36 = new Label();
            this.drophaxnpcid = new NumericUpDown();
            this.drophaxbtn = new Button();
            this.npcid = new NumericUpDown();
            this.label34 = new Label();
            this.label33 = new Label();
            this.scriptidb = new NumericUpDown();
            this.button2 = new Button();
            this.groupBox6 = new GroupBox();
            this.button4 = new Button();
            this.DAid1 = new TextBox();
            this.p4 = new TextBox();
            this.DAid2 = new TextBox();
            this.groupBox31 = new GroupBox();
            this.duunknown2 = new NumericUpDown();
            this.duovercoatcolor = new NumericUpDown();
            this.duacc3color = new NumericUpDown();
            this.duacc3num = new NumericUpDown();
            this.duacc3 = new CheckBox();
            this.duovercoatnum = new NumericUpDown();
            this.duovercoat = new CheckBox();
            this.label23 = new Label();
            this.duacc2color = new NumericUpDown();
            this.duacc1color = new NumericUpDown();
            this.dubootcolor = new NumericUpDown();
            this.duhatcolor = new NumericUpDown();
            this.label24 = new Label();
            this.dupantsnum = new NumericUpDown();
            this.dupants = new CheckBox();
            this.duacc2num = new NumericUpDown();
            this.duacc1num = new NumericUpDown();
            this.duacc2 = new CheckBox();
            this.duacc1 = new CheckBox();
            this.duskinnum = new NumericUpDown();
            this.dufacenum = new NumericUpDown();
            this.duskin = new CheckBox();
            this.duface = new CheckBox();
            this.dubootsnum = new NumericUpDown();
            this.duarmornum = new NumericUpDown();
            this.duweaponnum = new NumericUpDown();
            this.dushieldnum = new NumericUpDown();
            this.duhatnum = new NumericUpDown();
            this.duboots = new CheckBox();
            this.dushield = new CheckBox();
            this.duweapon = new CheckBox();
            this.duarmor = new CheckBox();
            this.duhat = new CheckBox();
            this.spellaninum = new NumericUpDown();
            this.label6 = new Label();
            this.testnum = new NumericUpDown();
            this.button1 = new Button();
            this.tabPage2 = new TabPage();
            this.toolStrip1 = new ToolStrip();
            this.btnPlay = new ToolStripButton();
            this.btnStop = new ToolStripButton();
            this.toolTip1 = new ToolTip(this.components);
            this.scriptida = new NumericUpDown();
            this.mainOptions.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.spellgroup.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.spellTargets.SuspendLayout();
            this.playertab.SuspendLayout();
            this.group_dion.SuspendLayout();
            this.dion_enemiesonscreenvalue.BeginInit();
            this.dion_enemiesnextcount.BeginInit();
            this.dion_hpcond.BeginInit();
            this.iocselfcond.BeginInit();
            this.newTarget.SuspendLayout();
            this.monstertab.SuspendLayout();
            this.spellMonsters.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.brieshits.BeginInit();
            this.tabPage9.SuspendLayout();
            this.skillgrouprangenum.BeginInit();
            this.groupBox9.SuspendLayout();
            this.gbpurewar.SuspendLayout();
            this.pfmonsters.BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.potioncond.BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox46.SuspendLayout();
            this.trinket_holder.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.nolongermobbed.BeginInit();
            this.mobdistance.BeginInit();
            this.mobsize.BeginInit();
            this.groupBox16.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.requestflowercond.BeginInit();
            this.tabPage4.SuspendLayout();
            this.followdist.BeginInit();
            this.walksettings.BeginInit();
            this.tabPage12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox47.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.labordays.BeginInit();
            this.groupBox25.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.usemonsterid.BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.reactdelaya.BeginInit();
            this.switchtargetdelayb.BeginInit();
            this.switchtargetdelaya.BeginInit();
            this.lootdelaya.BeginInit();
            this.lootdelayb.BeginInit();
            this.newtargetdelayb.BeginInit();
            this.reactdelayb.BeginInit();
            this.newtargetdelaya.BeginInit();
            this.groupBox12.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.itemColor.BeginInit();
            this.itemNum.BeginInit();
            this.groupBox10.SuspendLayout();
            this.haxtimenum.BeginInit();
            this.drophaxnpcid.BeginInit();
            this.npcid.BeginInit();
            this.scriptidb.BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.duunknown2.BeginInit();
            this.duovercoatcolor.BeginInit();
            this.duacc3color.BeginInit();
            this.duacc3num.BeginInit();
            this.duovercoatnum.BeginInit();
            this.duacc2color.BeginInit();
            this.duacc1color.BeginInit();
            this.dubootcolor.BeginInit();
            this.duhatcolor.BeginInit();
            this.dupantsnum.BeginInit();
            this.duacc2num.BeginInit();
            this.duacc1num.BeginInit();
            this.duskinnum.BeginInit();
            this.dufacenum.BeginInit();
            this.dubootsnum.BeginInit();
            this.duarmornum.BeginInit();
            this.duweaponnum.BeginInit();
            this.dushieldnum.BeginInit();
            this.duhatnum.BeginInit();
            this.spellaninum.BeginInit();
            this.testnum.BeginInit();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.scriptida.BeginInit();
            this.SuspendLayout();
            this.textConsoleOutput.Font = new Font("Consolas", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.textConsoleOutput.Location = new System.Drawing.Point(3, 33);
            this.textConsoleOutput.Name = "textConsoleOutput";
            this.textConsoleOutput.Size = new Size(618, 258);
            this.textConsoleOutput.TabIndex = 3;
            this.textConsoleOutput.Text = "";
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(632, 75);
            this.panel1.TabIndex = 4;
            this.textConsoleInput.Font = new Font("Consolas", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.textConsoleInput.Location = new System.Drawing.Point(3, 290);
            this.textConsoleInput.Name = "textConsoleInput";
            this.textConsoleInput.Size = new Size(456, 75);
            this.textConsoleInput.TabIndex = 1;
            this.textConsoleInput.Text = "";
            this.buttonSend.Location = new System.Drawing.Point(462, 290);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new Size(75, 75);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new EventHandler(this.buttonSend_Click);
            this.buttonRecv.Location = new System.Drawing.Point(543, 290);
            this.buttonRecv.Name = "buttonRecv";
            this.buttonRecv.Size = new Size(75, 75);
            this.buttonRecv.TabIndex = 3;
            this.buttonRecv.Text = "Recv";
            this.buttonRecv.UseVisualStyleBackColor = true;
            this.buttonRecv.Click += new EventHandler(this.buttonRecv_Click);
            this.checkRecv.AutoSize = true;
            this.checkRecv.Location = new System.Drawing.Point(130, 8);
            this.checkRecv.Name = "checkRecv";
            this.checkRecv.Size = new Size(120, 19);
            this.checkRecv.TabIndex = 5;
            this.checkRecv.Text = "Incoming Packets";
            this.checkRecv.UseVisualStyleBackColor = true;
            this.checkSend.AutoSize = true;
            this.checkSend.Location = new System.Drawing.Point(296, 8);
            this.checkSend.Name = "checkSend";
            this.checkSend.Size = new Size(120, 19);
            this.checkSend.TabIndex = 6;
            this.checkSend.Text = "Outgoing Packets";
            this.checkSend.UseVisualStyleBackColor = true;
            this.usemonster.AutoSize = true;
            this.usemonster.Location = new System.Drawing.Point(33, 21);
            this.usemonster.Name = "usemonster";
            this.usemonster.Size = new Size(101, 19);
            this.usemonster.TabIndex = 7;
            this.usemonster.Text = "Monster Form";
            this.usemonster.UseVisualStyleBackColor = true;
            this.usemonster.CheckedChanged += new EventHandler(this.usemonsterform_CheckedChanged);
            this.mainOptions.Controls.Add((Control)this.tabPage3);
            this.mainOptions.Controls.Add((Control)this.tabPage9);
            this.mainOptions.Controls.Add((Control)this.tabPage7);
            this.mainOptions.Controls.Add((Control)this.tabPage6);
            this.mainOptions.Controls.Add((Control)this.tabPage11);
            this.mainOptions.Controls.Add((Control)this.tabPage4);
            this.mainOptions.Controls.Add((Control)this.tabPage12);
            this.mainOptions.Controls.Add((Control)this.tabPage1);
            this.mainOptions.Controls.Add((Control)this.tabPage5);
            this.mainOptions.Controls.Add((Control)this.tabPage13);
            this.mainOptions.Controls.Add((Control)this.tabPage14);
            this.mainOptions.Controls.Add((Control)this.tabPage2);
            this.mainOptions.Location = new System.Drawing.Point(0, 34);
            this.mainOptions.Name = "mainOptions";
            this.mainOptions.SelectedIndex = 0;
            this.mainOptions.Size = new Size(642, 403);
            this.mainOptions.TabIndex = 8;
            this.tabPage3.Controls.Add((Control)this.spellgroup);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new Padding(3);
            this.tabPage3.Size = new Size(634, 375);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Spells";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.spellgroup.Controls.Add((Control)this.tabPage10);
            this.spellgroup.Controls.Add((Control)this.monstertab);
            this.spellgroup.Dock = DockStyle.Fill;
            this.spellgroup.Location = new System.Drawing.Point(3, 3);
            this.spellgroup.Name = "spellgroup";
            this.spellgroup.SelectedIndex = 0;
            this.spellgroup.Size = new Size(628, 369);
            this.spellgroup.TabIndex = 195;
            this.tabPage10.Controls.Add((Control)this.spellTargets);
            this.tabPage10.Location = new System.Drawing.Point(4, 24);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new Padding(3);
            this.tabPage10.Size = new Size(620, 341);
            this.tabPage10.TabIndex = 0;
            this.tabPage10.Text = "Players";
            this.tabPage10.UseVisualStyleBackColor = true;
            this.spellTargets.Controls.Add((Control)this.playertab);
            this.spellTargets.Controls.Add((Control)this.newTarget);
            this.spellTargets.Dock = DockStyle.Fill;
            this.spellTargets.Location = new System.Drawing.Point(3, 3);
            this.spellTargets.Name = "spellTargets";
            this.spellTargets.SelectedIndex = 0;
            this.spellTargets.Size = new Size(614, 335);
            this.spellTargets.TabIndex = 194;
            this.playertab.Controls.Add((Control)this.halfcast);
            this.playertab.Controls.Add((Control)this.bubblenorajo);
            this.playertab.Controls.Add((Control)this.aodall);
            this.playertab.Controls.Add((Control)this.openpriorityform);
            this.playertab.Controls.Add((Control)this.staffswitch);
            this.playertab.Controls.Add((Control)this.group_dion);
            this.playertab.Controls.Add((Control)this.selfaite);
            this.playertab.Controls.Add((Control)this.ioctype);
            this.playertab.Controls.Add((Control)this.selffas);
            this.playertab.Controls.Add((Control)this.iocselfcond);
            this.playertab.Controls.Add((Control)this.selfbean);
            this.playertab.Controls.Add((Control)this.label4);
            this.playertab.Controls.Add((Control)this.selffasdeireas);
            this.playertab.Controls.Add((Control)this.fs);
            this.playertab.Controls.Add((Control)this.selfarm);
            this.playertab.Controls.Add((Control)this.iocself);
            this.playertab.Controls.Add((Control)this.selfaosuain);
            this.playertab.Controls.Add((Control)this.fscond);
            this.playertab.Controls.Add((Control)this.selfaopuinsein);
            this.playertab.Controls.Add((Control)this.dfmonsters);
            this.playertab.Controls.Add((Control)this.aocurse);
            this.playertab.Controls.Add((Control)this.asgallmonsters);
            this.playertab.Controls.Add((Control)this.selfbc);
            this.playertab.Controls.Add((Control)this.aegissphere);
            this.playertab.Controls.Add((Control)this.selfcreagneart);
            this.playertab.Controls.Add((Control)this.selfmist);
            this.playertab.Controls.Add((Control)this.disenchanter);
            this.playertab.Controls.Add((Control)this.druidform);
            this.playertab.Controls.Add((Control)this.selfhide);
            this.playertab.Controls.Add((Control)this.selffastype);
            this.playertab.Controls.Add((Control)this.selfregen);
            this.playertab.Controls.Add((Control)this.selfaitetype);
            this.playertab.Controls.Add((Control)this.selfca);
            this.playertab.Location = new System.Drawing.Point(4, 24);
            this.playertab.Name = "playertab";
            this.playertab.Padding = new Padding(3);
            this.playertab.Size = new Size(606, 307);
            this.playertab.TabIndex = 0;
            this.playertab.Text = "Self";
            this.playertab.UseVisualStyleBackColor = true;
            this.halfcast.AutoSize = true;
            this.halfcast.Location = new System.Drawing.Point(326, 250);
            this.halfcast.Name = "halfcast";
            this.halfcast.Size = new Size(145, 19);
            this.halfcast.TabIndex = 198;
            this.halfcast.Text = "Disable 1/2 spell speed";
            this.halfcast.UseVisualStyleBackColor = true;
            this.bubblenorajo.AutoSize = true;
            this.bubblenorajo.Location = new System.Drawing.Point(176, 270);
            this.bubblenorajo.Name = "bubblenorajo";
            this.bubblenorajo.Size = new Size(128, 19);
            this.bubblenorajo.TabIndex = 197;
            this.bubblenorajo.Text = "Bubble near Norajo";
            this.bubblenorajo.UseVisualStyleBackColor = true;
            this.bubblenorajo.Visible = false;
            this.aodall.AutoSize = true;
            this.aodall.Checked = true;
            this.aodall.CheckState = CheckState.Checked;
            this.aodall.Location = new System.Drawing.Point(28, 276);
            this.aodall.Name = "aodall";
            this.aodall.Size = new Size(114, 19);
            this.aodall.TabIndex = 196;
            this.aodall.Text = "ao dall near GMs";
            this.aodall.UseVisualStyleBackColor = true;
            this.aodall.Visible = false;
            this.openpriorityform.Location = new System.Drawing.Point(458, 275);
            this.openpriorityform.Name = "openpriorityform";
            this.openpriorityform.Size = new Size(142, 26);
            this.openpriorityform.TabIndex = 194;
            this.openpriorityform.Text = "Configure Spell Priority";
            this.openpriorityform.UseVisualStyleBackColor = true;
            this.openpriorityform.Click += new EventHandler(this.openpriorityform_Click);
            this.staffswitch.AutoSize = true;
            this.staffswitch.Checked = true;
            this.staffswitch.CheckState = CheckState.Checked;
            this.staffswitch.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.staffswitch.Location = new System.Drawing.Point(28, 22);
            this.staffswitch.Name = "staffswitch";
            this.staffswitch.Size = new Size(114, 19);
            this.staffswitch.TabIndex = 176;
            this.staffswitch.Text = "Auto staff switch";
            this.staffswitch.UseVisualStyleBackColor = true;
            this.staffswitch.CheckedChanged += new EventHandler(this.staffswitch_CheckedChanged);
            this.group_dion.Controls.Add((Control)this.label19);
            this.group_dion.Controls.Add((Control)this.dion_enemiesonscreenvalue);
            this.group_dion.Controls.Add((Control)this.dion_enemiesonscreen);
            this.group_dion.Controls.Add((Control)this.label27);
            this.group_dion.Controls.Add((Control)this.dion_enemiesnextcount);
            this.group_dion.Controls.Add((Control)this.dion_enemiesnext);
            this.group_dion.Controls.Add((Control)this.diontype);
            this.group_dion.Controls.Add((Control)this.dion_aosith);
            this.group_dion.Controls.Add((Control)this.label5);
            this.group_dion.Controls.Add((Control)this.dion_hpcond);
            this.group_dion.Controls.Add((Control)this.dion_lowhp);
            this.group_dion.Location = new System.Drawing.Point(320, 77);
            this.group_dion.Name = "group_dion";
            this.group_dion.Size = new Size(262, 162);
            this.group_dion.TabIndex = 193;
            this.group_dion.TabStop = false;
            this.group_dion.Text = "dion";
            this.group_dion.Visible = false;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(81, 80);
            this.label19.Name = "label19";
            this.label19.Size = new Size(141, 15);
            this.label19.TabIndex = 169;
            this.label19.Text = "or more monsters in view";
            this.dion_enemiesonscreenvalue.Enabled = false;
            this.dion_enemiesonscreenvalue.Location = new System.Drawing.Point(44, 78);
            this.dion_enemiesonscreenvalue.Maximum = new Decimal(new int[4]
            {
        4,
        0,
        0,
        0
            });
            this.dion_enemiesonscreenvalue.Name = "dion_enemiesonscreenvalue";
            this.dion_enemiesonscreenvalue.Size = new Size(31, 23);
            this.dion_enemiesonscreenvalue.TabIndex = 168;
            this.dion_enemiesonscreenvalue.Value = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.dion_enemiesonscreen.AutoSize = true;
            this.dion_enemiesonscreen.Location = new System.Drawing.Point(6, 79);
            this.dion_enemiesonscreen.Name = "dion_enemiesonscreen";
            this.dion_enemiesonscreen.Size = new Size(33, 19);
            this.dion_enemiesonscreen.TabIndex = 165;
            this.dion_enemiesonscreen.Text = "If";
            this.dion_enemiesonscreen.UseVisualStyleBackColor = true;
            this.dion_enemiesonscreen.CheckedChanged += new EventHandler(this.dion_enemiesnext_CheckedChanged);
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(156, 57);
            this.label27.Name = "label27";
            this.label27.Size = new Size(101, 15);
            this.label27.TabIndex = 164;
            this.label27.Text = "or more monsters";
            this.dion_enemiesnextcount.Enabled = false;
            this.dion_enemiesnextcount.Location = new System.Drawing.Point(119, 55);
            this.dion_enemiesnextcount.Maximum = new Decimal(new int[4]
            {
        4,
        0,
        0,
        0
            });
            this.dion_enemiesnextcount.Name = "dion_enemiesnextcount";
            this.dion_enemiesnextcount.Size = new Size(31, 23);
            this.dion_enemiesnextcount.TabIndex = 163;
            this.dion_enemiesnextcount.Value = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.dion_enemiesnext.AutoSize = true;
            this.dion_enemiesnext.Location = new System.Drawing.Point(6, 56);
            this.dion_enemiesnext.Name = "dion_enemiesnext";
            this.dion_enemiesnext.Size = new Size(104, 19);
            this.dion_enemiesnext.TabIndex = 162;
            this.dion_enemiesnext.Text = "Surrounded by";
            this.dion_enemiesnext.UseVisualStyleBackColor = true;
            this.dion_enemiesnext.CheckedChanged += new EventHandler(this.dion_enemiesnext_CheckedChanged);
            this.diontype.DropDownStyle = ComboBoxStyle.DropDownList;
            this.diontype.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.diontype.FormattingEnabled = true;
            this.diontype.Location = new System.Drawing.Point(30, 20);
            this.diontype.Name = "diontype";
            this.diontype.Size = new Size(162, 23);
            this.diontype.TabIndex = 161;
            this.dion_aosith.Location = new System.Drawing.Point(6, 133);
            this.dion_aosith.Name = "dion_aosith";
            this.dion_aosith.Size = new Size(128, 19);
            this.dion_aosith.TabIndex = 160;
            this.dion_aosith.Text = "If lacking aite or fas";
            this.dion_aosith.UseVisualStyleBackColor = true;
            this.dion_aosith.CheckedChanged += new EventHandler(this.dion_enemiesnext_CheckedChanged);
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 108);
            this.label5.Name = "label5";
            this.label5.Size = new Size(17, 15);
            this.label5.TabIndex = 159;
            this.label5.Text = "%";
            this.dion_hpcond.Enabled = false;
            this.dion_hpcond.Location = new System.Drawing.Point(65, 106);
            this.dion_hpcond.Name = "dion_hpcond";
            this.dion_hpcond.Size = new Size(47, 23);
            this.dion_hpcond.TabIndex = 158;
            this.dion_hpcond.Value = new Decimal(new int[4]
            {
        20,
        0,
        0,
        0
            });
            this.dion_lowhp.AutoSize = true;
            this.dion_lowhp.Location = new System.Drawing.Point(6, 107);
            this.dion_lowhp.Name = "dion_lowhp";
            this.dion_lowhp.Size = new Size(63, 19);
            this.dion_lowhp.TabIndex = 157;
            this.dion_lowhp.Text = "If Hp <";
            this.dion_lowhp.UseVisualStyleBackColor = true;
            this.dion_lowhp.CheckedChanged += new EventHandler(this.dion_enemiesnext_CheckedChanged);
            this.selfaite.AutoSize = true;
            this.selfaite.Location = new System.Drawing.Point(28, 47);
            this.selfaite.Name = "selfaite";
            this.selfaite.Size = new Size(15, 14);
            this.selfaite.TabIndex = 165;
            this.selfaite.UseVisualStyleBackColor = true;
            this.selfaite.Visible = false;
            this.selfaite.CheckedChanged += new EventHandler(this.selfaite_CheckedChanged);
            this.ioctype.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ioctype.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.ioctype.FormattingEnabled = true;
            this.ioctype.Location = new System.Drawing.Point(350, 20);
            this.ioctype.Name = "ioctype";
            this.ioctype.Size = new Size(98, 23);
            this.ioctype.TabIndex = 192;
            this.ioctype.Visible = false;
            this.ioctype.SelectedIndexChanged += new EventHandler(this.ioctype_SelectedIndexChanged);
            this.selffas.AutoSize = true;
            this.selffas.Location = new System.Drawing.Point(28, 76);
            this.selffas.Name = "selffas";
            this.selffas.Size = new Size(15, 14);
            this.selffas.TabIndex = 166;
            this.selffas.UseVisualStyleBackColor = true;
            this.selffas.Visible = false;
            this.selffas.CheckedChanged += new EventHandler(this.selffas_CheckedChanged);
            this.iocselfcond.Enabled = false;
            this.iocselfcond.Location = new System.Drawing.Point(457, 19);
            this.iocselfcond.Name = "iocselfcond";
            this.iocselfcond.Size = new Size(46, 23);
            this.iocselfcond.TabIndex = 191;
            this.iocselfcond.Value = new Decimal(new int[4]
            {
        80,
        0,
        0,
        0
            });
            this.iocselfcond.Visible = false;
            this.iocselfcond.ValueChanged += new EventHandler(this.iocselfcond_ValueChanged);
            this.selfbean.AutoSize = true;
            this.selfbean.Location = new System.Drawing.Point(176, 22);
            this.selfbean.Name = "selfbean";
            this.selfbean.Size = new Size(81, 19);
            this.selfbean.TabIndex = 167;
            this.selfbean.Text = "beannaich";
            this.selfbean.UseVisualStyleBackColor = true;
            this.selfbean.Visible = false;
            this.selfbean.CheckedChanged += new EventHandler(this.selfbean_CheckedChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 21);
            this.label4.Name = "label4";
            this.label4.Size = new Size(17, 15);
            this.label4.TabIndex = 190;
            this.label4.Text = "%";
            this.label4.Visible = false;
            this.selffasdeireas.AutoSize = true;
            this.selffasdeireas.Location = new System.Drawing.Point(176, 48);
            this.selffasdeireas.Name = "selffasdeireas";
            this.selffasdeireas.Size = new Size(81, 19);
            this.selffasdeireas.TabIndex = 168;
            this.selffasdeireas.Text = "fas deireas";
            this.selffasdeireas.UseVisualStyleBackColor = true;
            this.selffasdeireas.Visible = false;
            this.selffasdeireas.CheckedChanged += new EventHandler(this.selffasdeireas_CheckedChanged);
            this.fs.AutoSize = true;
            this.fs.Location = new System.Drawing.Point(329, 50);
            this.fs.Name = "fs";
            this.fs.Size = new Size(147, 19);
            this.fs.TabIndex = 189;
            this.fs.Text = "fas spiorad when Mp <";
            this.fs.UseVisualStyleBackColor = true;
            this.fs.Visible = false;
            this.fs.CheckedChanged += new EventHandler(this.fs_CheckedChanged_1);
            this.selfarm.AutoSize = true;
            this.selfarm.Location = new System.Drawing.Point(28, 101);
            this.selfarm.Name = "selfarm";
            this.selfarm.Size = new Size(73, 19);
            this.selfarm.TabIndex = 169;
            this.selfarm.Text = "armachd";
            this.selfarm.UseVisualStyleBackColor = true;
            this.selfarm.Visible = false;
            this.selfarm.CheckedChanged += new EventHandler(this.selfarm_CheckedChanged);
            this.iocself.AutoSize = true;
            this.iocself.Location = new System.Drawing.Point(329, 24);
            this.iocself.Name = "iocself";
            this.iocself.Size = new Size(15, 14);
            this.iocself.TabIndex = 188;
            this.iocself.UseVisualStyleBackColor = true;
            this.iocself.Visible = false;
            this.iocself.CheckedChanged += new EventHandler(this.iocself_CheckedChanged_1);
            this.selfaosuain.AutoSize = true;
            this.selfaosuain.Location = new System.Drawing.Point(28, 176);
            this.selfaosuain.Name = "selfaosuain";
            this.selfaosuain.Size = new Size(104, 19);
            this.selfaosuain.TabIndex = 170;
            this.selfaosuain.Text = "ao suain/Chirp";
            this.selfaosuain.UseVisualStyleBackColor = true;
            this.selfaosuain.Visible = false;
            this.selfaosuain.CheckedChanged += new EventHandler(this.selfaosuain_CheckedChanged);
            this.fscond.Enabled = false;
            this.fscond.Location = new System.Drawing.Point(484, 48);
            this.fscond.MaxLength = 6;
            this.fscond.Name = "fscond";
            this.fscond.Size = new Size(52, 23);
            this.fscond.TabIndex = 187;
            this.fscond.Text = "3000";
            this.fscond.Visible = false;
            this.fscond.TextChanged += new EventHandler(this.fscond_TextChanged);
            this.selfaopuinsein.AutoSize = true;
            this.selfaopuinsein.Location = new System.Drawing.Point(28, 201);
            this.selfaopuinsein.Name = "selfaopuinsein";
            this.selfaopuinsein.Size = new Size(87, 19);
            this.selfaopuinsein.TabIndex = 171;
            this.selfaopuinsein.Text = "ao puinsein";
            this.selfaopuinsein.UseVisualStyleBackColor = true;
            this.selfaopuinsein.Visible = false;
            this.selfaopuinsein.CheckedChanged += new EventHandler(this.selfaopuinsein_CheckedChanged);
            this.dfmonsters.AutoSize = true;
            this.dfmonsters.Location = new System.Drawing.Point(28, 226);
            this.dfmonsters.Name = "dfmonsters";
            this.dfmonsters.Size = new Size(99, 19);
            this.dfmonsters.TabIndex = 186;
            this.dfmonsters.Text = "deireas faileas";
            this.dfmonsters.UseVisualStyleBackColor = true;
            this.dfmonsters.Visible = false;
            this.aocurse.AutoSize = true;
            this.aocurse.Location = new System.Drawing.Point(28, 151);
            this.aocurse.Name = "aocurse";
            this.aocurse.Size = new Size(75, 19);
            this.aocurse.TabIndex = 172;
            this.aocurse.Text = "ao curses";
            this.aocurse.UseVisualStyleBackColor = true;
            this.aocurse.Visible = false;
            this.aocurse.CheckedChanged += new EventHandler(this.aocurse_CheckedChanged);
            this.asgallmonsters.AutoSize = true;
            this.asgallmonsters.Location = new System.Drawing.Point(176, 195);
            this.asgallmonsters.Name = "asgallmonsters";
            this.asgallmonsters.Size = new Size(92, 19);
            this.asgallmonsters.TabIndex = 185;
            this.asgallmonsters.Text = "asgall faileas";
            this.asgallmonsters.UseVisualStyleBackColor = true;
            this.asgallmonsters.Visible = false;
            this.selfbc.AutoSize = true;
            this.selfbc.Location = new System.Drawing.Point(28, 126);
            this.selfbc.Name = "selfbc";
            this.selfbc.Size = new Size(85, 19);
            this.selfbc.TabIndex = 173;
            this.selfbc.Text = "beag cradh";
            this.selfbc.UseVisualStyleBackColor = true;
            this.selfbc.Visible = false;
            this.selfbc.CheckedChanged += new EventHandler(this.selfbc_CheckedChanged);
            this.aegissphere.AutoSize = true;
            this.aegissphere.Location = new System.Drawing.Point(176, 145);
            this.aegissphere.Name = "aegissphere";
            this.aegissphere.Size = new Size(94, 19);
            this.aegissphere.TabIndex = 184;
            this.aegissphere.Text = "Aegis Sphere";
            this.aegissphere.UseVisualStyleBackColor = true;
            this.aegissphere.Visible = false;
            this.aegissphere.CheckedChanged += new EventHandler(this.aegissphere_CheckedChanged);
            this.selfcreagneart.AutoSize = true;
            this.selfcreagneart.Location = new System.Drawing.Point(176, 72);
            this.selfcreagneart.Name = "selfcreagneart";
            this.selfcreagneart.Size = new Size(85, 19);
            this.selfcreagneart.TabIndex = 174;
            this.selfcreagneart.Text = "creag neart";
            this.selfcreagneart.UseVisualStyleBackColor = true;
            this.selfcreagneart.Visible = false;
            this.selfcreagneart.CheckedChanged += new EventHandler(this.selfcreagneart_CheckedChanged);
            this.selfmist.AutoSize = true;
            this.selfmist.Location = new System.Drawing.Point(176, 95);
            this.selfmist.Name = "selfmist";
            this.selfmist.Size = new Size(49, 19);
            this.selfmist.TabIndex = 183;
            this.selfmist.Text = "Mist";
            this.selfmist.UseVisualStyleBackColor = true;
            this.selfmist.Visible = false;
            this.selfmist.CheckedChanged += new EventHandler(this.selfmist_CheckedChanged);
            this.disenchanter.AutoSize = true;
            this.disenchanter.Location = new System.Drawing.Point(28, 251);
            this.disenchanter.Name = "disenchanter";
            this.disenchanter.Size = new Size(95, 19);
            this.disenchanter.TabIndex = 175;
            this.disenchanter.Text = "Disenchanter";
            this.disenchanter.UseVisualStyleBackColor = true;
            this.disenchanter.Visible = false;
            this.disenchanter.CheckedChanged += new EventHandler(this.disenchanter_CheckedChanged);
            this.druidform.AutoSize = true;
            this.druidform.Location = new System.Drawing.Point(176, 120);
            this.druidform.Name = "druidform";
            this.druidform.Size = new Size(86, 19);
            this.druidform.TabIndex = 182;
            this.druidform.Text = "Druid Form";
            this.druidform.UseVisualStyleBackColor = true;
            this.druidform.Visible = false;
            this.druidform.CheckedChanged += new EventHandler(this.druidform_CheckedChanged);
            this.selfhide.AutoSize = true;
            this.selfhide.Location = new System.Drawing.Point(176, 170);
            this.selfhide.Name = "selfhide";
            this.selfhide.Size = new Size(51, 19);
            this.selfhide.TabIndex = 177;
            this.selfhide.Text = "Hide";
            this.selfhide.UseVisualStyleBackColor = true;
            this.selfhide.Visible = false;
            this.selfhide.CheckedChanged += new EventHandler(this.selfhide_CheckedChanged);
            this.selffastype.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selffastype.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.selffastype.FormattingEnabled = true;
            this.selffastype.Location = new System.Drawing.Point(49, 74);
            this.selffastype.Name = "selffastype";
            this.selffastype.Size = new Size(109, 23);
            this.selffastype.TabIndex = 181;
            this.selffastype.Visible = false;
            this.selffastype.SelectedIndexChanged += new EventHandler(this.selffastype_SelectedIndexChanged);
            this.selfregen.AutoSize = true;
            this.selfregen.Location = new System.Drawing.Point(176, 220);
            this.selfregen.Name = "selfregen";
            this.selfregen.Size = new Size(96, 19);
            this.selfregen.TabIndex = 178;
            this.selfregen.Text = "Regeneration";
            this.selfregen.UseVisualStyleBackColor = true;
            this.selfregen.Visible = false;
            this.selfregen.CheckedChanged += new EventHandler(this.selfregen_CheckedChanged);
            this.selfaitetype.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selfaitetype.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.selfaitetype.FormattingEnabled = true;
            this.selfaitetype.Location = new System.Drawing.Point(49, 45);
            this.selfaitetype.Name = "selfaitetype";
            this.selfaitetype.Size = new Size(109, 23);
            this.selfaitetype.TabIndex = 180;
            this.selfaitetype.Visible = false;
            this.selfaitetype.SelectedIndexChanged += new EventHandler(this.selfaitetype_SelectedIndexChanged);
            this.selfca.AutoSize = true;
            this.selfca.Location = new System.Drawing.Point(176, 245);
            this.selfca.Name = "selfca";
            this.selfca.Size = new Size(106, 19);
            this.selfca.TabIndex = 179;
            this.selfca.Text = "Counter Attack";
            this.selfca.UseVisualStyleBackColor = true;
            this.selfca.Visible = false;
            this.selfca.CheckedChanged += new EventHandler(this.selfca_CheckedChanged);
            this.newTarget.Controls.Add((Control)this.alreadyexists);
            this.newTarget.Controls.Add((Control)this.newalts);
            this.newTarget.Controls.Add((Control)this.newplayername);
            this.newTarget.Controls.Add((Control)this.createnewtarget);
            this.newTarget.Controls.Add((Control)this.newallgrouped);
            this.newTarget.Controls.Add((Control)this.newplayer);
            this.newTarget.Location = new System.Drawing.Point(4, 22);
            this.newTarget.Name = "newTarget";
            this.newTarget.Padding = new Padding(3);
            this.newTarget.Size = new Size(606, 309);
            this.newTarget.TabIndex = 1;
            this.newTarget.Text = "New Player";
            this.newTarget.UseVisualStyleBackColor = true;
            this.alreadyexists.AutoSize = true;
            this.alreadyexists.ForeColor = Color.Maroon;
            this.alreadyexists.Location = new System.Drawing.Point(285, 226);
            this.alreadyexists.Name = "alreadyexists";
            this.alreadyexists.Size = new Size(166, 15);
            this.alreadyexists.TabIndex = 17;
            this.alreadyexists.Text = "This player is already targeted.";
            this.alreadyexists.Visible = false;
            this.newalts.AutoSize = true;
            this.newalts.Location = new System.Drawing.Point(156, 103);
            this.newalts.Name = "newalts";
            this.newalts.Size = new Size(107, 19);
            this.newalts.TabIndex = 16;
            this.newalts.Text = "All open clients";
            this.newalts.UseVisualStyleBackColor = true;
            this.newalts.CheckedChanged += new EventHandler(this.newalts_CheckedChanged);
            this.newplayername.Enabled = false;
            this.newplayername.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.newplayername.Location = new System.Drawing.Point(251, 66);
            this.newplayername.MaxLength = 12;
            this.newplayername.Name = "newplayername";
            this.newplayername.Size = new Size(86, 21);
            this.newplayername.TabIndex = 15;
            this.newplayername.TextChanged += new EventHandler(this.newplayername_TextChanged);
            this.newplayername.KeyPress += new KeyPressEventHandler(this.newplayername_KeyPress);
            this.createnewtarget.Enabled = false;
            this.createnewtarget.Location = new System.Drawing.Point(283, 178);
            this.createnewtarget.Name = "createnewtarget";
            this.createnewtarget.Size = new Size(148, 34);
            this.createnewtarget.TabIndex = 14;
            this.createnewtarget.Text = "Create";
            this.createnewtarget.UseVisualStyleBackColor = true;
            this.createnewtarget.Click += new EventHandler(this.createnewtarget_Click);
            this.newallgrouped.AutoSize = true;
            this.newallgrouped.Location = new System.Drawing.Point(156, 141);
            this.newallgrouped.Name = "newallgrouped";
            this.newallgrouped.Size = new Size(88, 19);
            this.newallgrouped.TabIndex = 13;
            this.newallgrouped.Text = "All grouped";
            this.newallgrouped.UseVisualStyleBackColor = true;
            this.newallgrouped.CheckedChanged += new EventHandler(this.newallgrouped_CheckedChanged);
            this.newplayer.AutoSize = true;
            this.newplayer.Location = new System.Drawing.Point(156, 68);
            this.newplayer.Name = "newplayer";
            this.newplayer.Size = new Size(85, 19);
            this.newplayer.TabIndex = 12;
            this.newplayer.Text = "New player";
            this.newplayer.UseVisualStyleBackColor = true;
            this.newplayer.CheckedChanged += new EventHandler(this.newplayer_CheckedChanged);
            this.monstertab.Controls.Add((Control)this.spellMonsters);
            this.monstertab.Location = new System.Drawing.Point(4, 22);
            this.monstertab.Name = "monstertab";
            this.monstertab.Padding = new Padding(3);
            this.monstertab.Size = new Size(620, 343);
            this.monstertab.TabIndex = 1;
            this.monstertab.Text = "Monsters";
            this.monstertab.UseVisualStyleBackColor = true;
            this.spellMonsters.Controls.Add((Control)this.tabPage8);
            this.spellMonsters.Dock = DockStyle.Fill;
            this.spellMonsters.Location = new System.Drawing.Point(3, 3);
            this.spellMonsters.Name = "spellMonsters";
            this.spellMonsters.SelectedIndex = 0;
            this.spellMonsters.Size = new Size(614, 337);
            this.spellMonsters.TabIndex = 0;
            this.tabPage8.Controls.Add((Control)this.label44);
            this.tabPage8.Controls.Add((Control)this.groupBox15);
            this.tabPage8.Controls.Add((Control)this.label42);
            this.tabPage8.Controls.Add((Control)this.brieshits);
            this.tabPage8.Controls.Add((Control)this.briescantattack);
            this.tabPage8.Controls.Add((Control)this.newmonster);
            this.tabPage8.Controls.Add((Control)this.getimage);
            this.tabPage8.Controls.Add((Control)this.newallmonsters);
            this.tabPage8.Controls.Add((Control)this.newmonsterbyplayername);
            this.tabPage8.Controls.Add((Control)this.createnewmonster);
            this.tabPage8.Controls.Add((Control)this.newmonsterbyplayer);
            this.tabPage8.Controls.Add((Control)this.newmonstername);
            this.tabPage8.Controls.Add((Control)this.monsterexists);
            this.tabPage8.Location = new System.Drawing.Point(4, 24);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new Padding(3);
            this.tabPage8.Size = new Size(606, 309);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "New Monster";
            this.tabPage8.UseVisualStyleBackColor = true;
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(286, 3);
            this.label44.Name = "label44";
            this.label44.Size = new Size(308, 15);
            this.label44.TabIndex = 28;
            this.label44.Text = "*It will attack all monsters anywhere else, so BE CAREFUL!";
            this.groupBox15.Controls.Add((Control)this.label43);
            this.groupBox15.Location = new System.Drawing.Point(469, 18);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new Size(131, 267);
            this.groupBox15.TabIndex = 27;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Hardcoded Areas*";
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(18, 19);
            this.label43.Name = "label43";
            this.label43.Size = new Size(94, 180);
            this.label43.TabIndex = 0;
            this.label43.Text = "Mtg\r\nNobis\r\nSW 20+\r\nChaos\r\nChadul\r\n\r\nAndor\r\nLost Ruins\r\nWater Dungeon\r\nDesert Dunes\r\nYowien Territory\r\n(NOT AJ)";
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(117, 233);
            this.label42.Name = "label42";
            this.label42.Size = new Size(68, 15);
            this.label42.TabIndex = 26;
            this.label42.Text = "(mspg/hof)";
            this.brieshits.Location = new System.Drawing.Point(223, 215);
            this.brieshits.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.brieshits.Name = "brieshits";
            this.brieshits.Size = new Size(42, 23);
            this.brieshits.TabIndex = 25;
            this.brieshits.Value = new Decimal(new int[4]
            {
        4,
        0,
        0,
        0
            });
            this.briescantattack.AutoSize = true;
            this.briescantattack.Location = new System.Drawing.Point(29, 216);
            this.briescantattack.Name = "briescantattack";
            this.briescantattack.Size = new Size(197, 19);
            this.briescantattack.TabIndex = 24;
            this.briescantattack.Text = "breisleich after # of hits to curse:";
            this.briescantattack.UseVisualStyleBackColor = true;
            this.newmonster.AutoSize = true;
            this.newmonster.Location = new System.Drawing.Point(143, 36);
            this.newmonster.Name = "newmonster";
            this.newmonster.Size = new Size(132, 19);
            this.newmonster.TabIndex = 16;
            this.newmonster.Text = "Monster by image #";
            this.newmonster.UseVisualStyleBackColor = true;
            this.newmonster.CheckedChanged += new EventHandler(this.newmonster_CheckedChanged);
            this.getimage.AutoSize = true;
            this.getimage.Location = new System.Drawing.Point(18, 28);
            this.getimage.Name = "getimage";
            this.getimage.Size = new Size(90, 34);
            this.getimage.TabIndex = 23;
            this.getimage.Text = "Get image #\r\nby clicking";
            this.getimage.UseVisualStyleBackColor = true;
            this.getimage.CheckedChanged += new EventHandler(this.getimage_CheckedChanged);
            this.newallmonsters.AutoSize = true;
            this.newallmonsters.Location = new System.Drawing.Point(143, 113);
            this.newallmonsters.Name = "newallmonsters";
            this.newallmonsters.Size = new Size(92, 19);
            this.newallmonsters.TabIndex = 17;
            this.newallmonsters.Text = "All monsters";
            this.newallmonsters.UseVisualStyleBackColor = true;
            this.newallmonsters.CheckedChanged += new EventHandler(this.newallmonsters_CheckedChanged);
            this.newmonsterbyplayername.Enabled = false;
            this.newmonsterbyplayername.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.newmonsterbyplayername.Location = new System.Drawing.Point(357, 76);
            this.newmonsterbyplayername.MaxLength = 25;
            this.newmonsterbyplayername.Name = "newmonsterbyplayername";
            this.newmonsterbyplayername.Size = new Size(84, 21);
            this.newmonsterbyplayername.TabIndex = 22;
            this.newmonsterbyplayername.TextChanged += new EventHandler(this.newmonsterbyplayername_TextChanged);
            this.newmonsterbyplayername.KeyPress += new KeyPressEventHandler(this.newmonsterbyplayername_KeyPress);
            this.createnewmonster.Enabled = false;
            this.createnewmonster.Location = new System.Drawing.Point(266, 125);
            this.createnewmonster.Name = "createnewmonster";
            this.createnewmonster.Size = new Size(148, 34);
            this.createnewmonster.TabIndex = 18;
            this.createnewmonster.Text = "Create";
            this.createnewmonster.UseVisualStyleBackColor = true;
            this.createnewmonster.Click += new EventHandler(this.createnewmonster_Click);
            this.newmonsterbyplayer.AutoSize = true;
            this.newmonsterbyplayer.Location = new System.Drawing.Point(143, 76);
            this.newmonsterbyplayer.Name = "newmonsterbyplayer";
            this.newmonsterbyplayer.Size = new Size(208, 19);
            this.newmonsterbyplayer.TabIndex = 21;
            this.newmonsterbyplayer.Text = "Other player's target thats been hit";
            this.newmonsterbyplayer.UseVisualStyleBackColor = true;
            this.newmonsterbyplayer.Click += new EventHandler(this.newmonsterbyplayer_Click);
            this.newmonstername.Enabled = false;
            this.newmonstername.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.newmonstername.Location = new System.Drawing.Point(290, 34);
            this.newmonstername.MaxLength = 25;
            this.newmonstername.Name = "newmonstername";
            this.newmonstername.Size = new Size(84, 21);
            this.newmonstername.TabIndex = 19;
            this.newmonstername.TextChanged += new EventHandler(this.newmonstername_TextChanged);
            this.newmonstername.KeyPress += new KeyPressEventHandler(this.newmonstername_KeyPress);
            this.monsterexists.AutoSize = true;
            this.monsterexists.ForeColor = Color.Maroon;
            this.monsterexists.Location = new System.Drawing.Point(263, 178);
            this.monsterexists.Name = "monsterexists";
            this.monsterexists.Size = new Size(178, 15);
            this.monsterexists.TabIndex = 20;
            this.monsterexists.Text = "This monster is already targeted.";
            this.monsterexists.Visible = false;
            this.tabPage9.Controls.Add((Control)this.attackleaderstarget);
            this.tabPage9.Controls.Add((Control)this.skillgrouprangenum);
            this.tabPage9.Controls.Add((Control)this.skillgrouprange);
            this.tabPage9.Controls.Add((Control)this.insectassail);
            this.tabPage9.Controls.Add((Control)this.groupBox9);
            this.tabPage9.Controls.Add((Control)this.gbpurewar);
            this.tabPage9.Controls.Add((Control)this.groupBox8);
            this.tabPage9.Controls.Add((Control)this.useskillshidden);
            this.tabPage9.Controls.Add((Control)this.groupBox7);
            this.tabPage9.Controls.Add((Control)this.equipshield);
            this.tabPage9.Controls.Add((Control)this.attackinfinitemr);
            this.tabPage9.Controls.Add((Control)this.equipweapon);
            this.tabPage9.Controls.Add((Control)this.walktomonster);
            this.tabPage9.Controls.Add((Control)this.assail);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new Size(634, 377);
            this.tabPage9.TabIndex = 7;
            this.tabPage9.Text = "Skills";
            this.tabPage9.UseVisualStyleBackColor = true;
            this.attackleaderstarget.AutoSize = true;
            this.attackleaderstarget.Location = new System.Drawing.Point(44, 348);
            this.attackleaderstarget.Name = "attackleaderstarget";
            this.attackleaderstarget.Size = new Size(269, 19);
            this.attackleaderstarget.TabIndex = 19;
            this.attackleaderstarget.Text = "Always attack Leaders target first (if following)";
            this.attackleaderstarget.UseVisualStyleBackColor = true;
            this.skillgrouprangenum.Location = new System.Drawing.Point(317, 323);
            this.skillgrouprangenum.Maximum = new Decimal(new int[4]
            {
        12,
        0,
        0,
        0
            });
            this.skillgrouprangenum.Name = "skillgrouprangenum";
            this.skillgrouprangenum.Size = new Size(40, 23);
            this.skillgrouprangenum.TabIndex = 18;
            this.skillgrouprangenum.Value = new Decimal(new int[4]
            {
        7,
        0,
        0,
        0
            });
            this.skillgrouprange.AutoSize = true;
            this.skillgrouprange.Location = new System.Drawing.Point(44, 324);
            this.skillgrouprange.Name = "skillgrouprange";
            this.skillgrouprange.Size = new Size(267, 19);
            this.skillgrouprange.TabIndex = 17;
            this.skillgrouprange.Text = "Only use skills if Group members are in range:";
            this.skillgrouprange.UseVisualStyleBackColor = true;
            this.insectassail.AutoSize = true;
            this.insectassail.Location = new System.Drawing.Point(188, 55);
            this.insectassail.Name = "insectassail";
            this.insectassail.Size = new Size(122, 19);
            this.insectassail.TabIndex = 16;
            this.insectassail.Text = "Insect Event Assail";
            this.insectassail.UseVisualStyleBackColor = true;
            this.groupBox9.Controls.Add((Control)this.switchneck);
            this.groupBox9.Controls.Add((Control)this.comboscroll);
            this.groupBox9.Controls.Add((Control)this.comboscrollnoshield);
            this.groupBox9.Location = new System.Drawing.Point(35, 198);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new Size(550, 41);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            this.switchneck.AutoSize = true;
            this.switchneck.Checked = true;
            this.switchneck.CheckState = CheckState.Checked;
            this.switchneck.Location = new System.Drawing.Point(348, 16);
            this.switchneck.Name = "switchneck";
            this.switchneck.Size = new Size(112, 19);
            this.switchneck.TabIndex = 9;
            this.switchneck.Text = "Switch Necklace";
            this.switchneck.UseVisualStyleBackColor = true;
            this.comboscroll.AutoSize = true;
            this.comboscroll.Location = new System.Drawing.Point(9, 16);
            this.comboscroll.Name = "comboscroll";
            this.comboscroll.Size = new Size(119, 19);
            this.comboscroll.TabIndex = 8;
            this.comboscroll.Text = "Combo Scroll -->";
            this.comboscroll.UseVisualStyleBackColor = true;
            this.comboscrollnoshield.AutoSize = true;
            this.comboscrollnoshield.Location = new System.Drawing.Point(134, 16);
            this.comboscrollnoshield.Name = "comboscrollnoshield";
            this.comboscrollnoshield.Size = new Size(108, 19);
            this.comboscrollnoshield.TabIndex = 7;
            this.comboscrollnoshield.Text = "(take off shield)";
            this.comboscrollnoshield.UseVisualStyleBackColor = true;
            this.gbpurewar.Controls.Add((Control)this.pfmonsters);
            this.gbpurewar.Controls.Add((Control)this.purewarlabel);
            this.gbpurewar.Controls.Add((Control)this.pd);
            this.gbpurewar.Controls.Add((Control)this.pf);
            this.gbpurewar.Location = new System.Drawing.Point(35, 242);
            this.gbpurewar.Name = "gbpurewar";
            this.gbpurewar.Size = new Size(550, 67);
            this.gbpurewar.TabIndex = 15;
            this.gbpurewar.TabStop = false;
            this.pfmonsters.Location = new System.Drawing.Point(119, 32);
            this.pfmonsters.Name = "pfmonsters";
            this.pfmonsters.Size = new Size(35, 23);
            this.pfmonsters.TabIndex = 13;
            this.pfmonsters.Value = new Decimal(new int[4]
            {
        3,
        0,
        0,
        0
            });
            this.purewarlabel.AutoSize = true;
            this.purewarlabel.Location = new System.Drawing.Point(6, 38);
            this.purewarlabel.Name = "purewarlabel";
            this.purewarlabel.Size = new Size(106, 15);
            this.purewarlabel.TabIndex = 12;
            this.purewarlabel.Text = "if monsters in view";
            this.pd.AutoSize = true;
            this.pd.Location = new System.Drawing.Point(222, 16);
            this.pd.Name = "pd";
            this.pd.Size = new Size(108, 19);
            this.pd.TabIndex = 11;
            this.pd.Text = "Perfect Defense";
            this.pd.UseVisualStyleBackColor = true;
            this.pf.AutoSize = true;
            this.pf.Location = new System.Drawing.Point(9, 16);
            this.pf.Name = "pf";
            this.pf.Size = new Size(101, 19);
            this.pf.TabIndex = 10;
            this.pf.Text = "Paralyze Force";
            this.pf.UseVisualStyleBackColor = true;
            this.groupBox8.Controls.Add((Control)this.castbries);
            this.groupBox8.Controls.Add((Control)this.usefrost);
            this.groupBox8.Controls.Add((Control)this.useambush);
            this.groupBox8.Controls.Add((Control)this.usecrasher);
            this.groupBox8.Controls.Add((Control)this.useskills);
            this.groupBox8.Controls.Add((Control)this.asrs);
            this.groupBox8.Location = new System.Drawing.Point(35, 125);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new Size(550, 71);
            this.groupBox8.TabIndex = 13;
            this.groupBox8.TabStop = false;
            this.castbries.AutoSize = true;
            this.castbries.Location = new System.Drawing.Point(179, 16);
            this.castbries.Name = "castbries";
            this.castbries.Size = new Size(121, 19);
            this.castbries.TabIndex = 20;
            this.castbries.Text = "cast bries for as/rs";
            this.castbries.UseVisualStyleBackColor = true;
            this.usefrost.AutoSize = true;
            this.usefrost.Location = new System.Drawing.Point(222, 41);
            this.usefrost.Name = "usefrost";
            this.usefrost.Size = new Size(84, 19);
            this.usefrost.TabIndex = 19;
            this.usefrost.Text = "Frost Strike";
            this.usefrost.UseVisualStyleBackColor = true;
            this.useambush.AutoSize = true;
            this.useambush.Location = new System.Drawing.Point(9, 41);
            this.useambush.Name = "useambush";
            this.useambush.Size = new Size(155, 19);
            this.useambush.TabIndex = 18;
            this.useambush.Text = "Use Ambush (if suained)";
            this.useambush.UseVisualStyleBackColor = true;
            this.usecrasher.AutoSize = true;
            this.usecrasher.Location = new System.Drawing.Point(348, 16);
            this.usecrasher.Name = "usecrasher";
            this.usecrasher.Size = new Size(120, 19);
            this.usecrasher.TabIndex = 10;
            this.usecrasher.Text = "Crasher after dion";
            this.usecrasher.UseVisualStyleBackColor = true;
            this.useskills.AutoSize = true;
            this.useskills.Location = new System.Drawing.Point(9, 16);
            this.useskills.Name = "useskills";
            this.useskills.Size = new Size(74, 19);
            this.useskills.TabIndex = 6;
            this.useskills.Text = "Use Skills";
            this.useskills.UseVisualStyleBackColor = true;
            this.asrs.AutoSize = true;
            this.asrs.Location = new System.Drawing.Point(115, 16);
            this.asrs.Name = "asrs";
            this.asrs.Size = new Size(58, 19);
            this.asrs.TabIndex = 2;
            this.asrs.Text = "AS/RS";
            this.asrs.UseVisualStyleBackColor = true;
            this.useskillshidden.AutoSize = true;
            this.useskillshidden.ForeColor = Color.DarkRed;
            this.useskillshidden.Location = new System.Drawing.Point(441, 324);
            this.useskillshidden.Name = "useskillshidden";
            this.useskillshidden.Size = new Size(144, 19);
            this.useskillshidden.TabIndex = 9;
            this.useskillshidden.Text = "Use skills while hidden";
            this.useskillshidden.UseVisualStyleBackColor = true;
            this.groupBox7.Controls.Add((Control)this.pramhedonly);
            this.groupBox7.Controls.Add((Control)this.cursedonly);
            this.groupBox7.Controls.Add((Control)this.fasedonly);
            this.groupBox7.Location = new System.Drawing.Point(35, 80);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new Size(550, 41);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Skills";
            this.pramhedonly.AutoSize = true;
            this.pramhedonly.Location = new System.Drawing.Point(222, 16);
            this.pramhedonly.Name = "pramhedonly";
            this.pramhedonly.Size = new Size(100, 19);
            this.pramhedonly.TabIndex = 5;
            this.pramhedonly.Text = "Pramhed only";
            this.pramhedonly.UseVisualStyleBackColor = true;
            this.cursedonly.AutoSize = true;
            this.cursedonly.Location = new System.Drawing.Point(115, 16);
            this.cursedonly.Name = "cursedonly";
            this.cursedonly.Size = new Size(89, 19);
            this.cursedonly.TabIndex = 4;
            this.cursedonly.Text = "Cursed only";
            this.cursedonly.UseVisualStyleBackColor = true;
            this.fasedonly.AutoSize = true;
            this.fasedonly.Location = new System.Drawing.Point(9, 16);
            this.fasedonly.Name = "fasedonly";
            this.fasedonly.Size = new Size(82, 19);
            this.fasedonly.TabIndex = 3;
            this.fasedonly.Text = "Fased only";
            this.fasedonly.UseVisualStyleBackColor = true;
            this.equipshield.AutoSize = true;
            this.equipshield.Location = new System.Drawing.Point(457, 55);
            this.equipshield.Name = "equipshield";
            this.equipshield.Size = new Size(91, 19);
            this.equipshield.TabIndex = 11;
            this.equipshield.Text = "Equip Shield";
            this.equipshield.UseVisualStyleBackColor = true;
            this.attackinfinitemr.AutoSize = true;
            this.attackinfinitemr.Location = new System.Drawing.Point(188, 30);
            this.attackinfinitemr.Name = "attackinfinitemr";
            this.attackinfinitemr.Size = new Size(211, 19);
            this.attackinfinitemr.TabIndex = 7;
            this.attackinfinitemr.Text = "Attack infinite MR mobs (ie; AJ/YT)";
            this.attackinfinitemr.UseVisualStyleBackColor = true;
            this.equipweapon.AutoSize = true;
            this.equipweapon.Location = new System.Drawing.Point(457, 30);
            this.equipweapon.Name = "equipweapon";
            this.equipweapon.Size = new Size(128, 19);
            this.equipweapon.TabIndex = 10;
            this.equipweapon.Text = "Equip Best Weapon";
            this.equipweapon.UseVisualStyleBackColor = true;
            this.walktomonster.AutoSize = true;
            this.walktomonster.Location = new System.Drawing.Point(44, 55);
            this.walktomonster.Name = "walktomonster";
            this.walktomonster.Size = new Size(118, 19);
            this.walktomonster.TabIndex = 1;
            this.walktomonster.Text = "Walk to Monsters";
            this.walktomonster.UseVisualStyleBackColor = true;
            this.assail.AutoSize = true;
            this.assail.Location = new System.Drawing.Point(44, 30);
            this.assail.Name = "assail";
            this.assail.Size = new Size(56, 19);
            this.assail.TabIndex = 0;
            this.assail.Text = "Assail";
            this.assail.UseVisualStyleBackColor = true;
            this.tabPage7.Controls.Add((Control)this.iditems);
            this.tabPage7.Controls.Add((Control)this.walktored);
            this.tabPage7.Controls.Add((Control)this.potioncond);
            this.tabPage7.Controls.Add((Control)this.label10);
            this.tabPage7.Controls.Add((Control)this.potion);
            this.tabPage7.Controls.Add((Control)this.groupBox2);
            this.tabPage7.Controls.Add((Control)this.groupBox1);
            this.tabPage7.Controls.Add((Control)this.groupBox46);
            this.tabPage7.Controls.Add((Control)this.trinket_holder);
            this.tabPage7.Controls.Add((Control)this.redaislings);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new Size(634, 377);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Items";
            this.tabPage7.UseVisualStyleBackColor = true;
            this.iditems.AutoSize = true;
            this.iditems.Location = new System.Drawing.Point(253, 98);
            this.iditems.Name = "iditems";
            this.iditems.Size = new Size(98, 19);
            this.iditems.TabIndex = 162;
            this.iditems.Text = "Identify Items";
            this.iditems.UseVisualStyleBackColor = true;
            this.walktored.AutoSize = true;
            this.walktored.Checked = true;
            this.walktored.CheckState = CheckState.Checked;
            this.walktored.Location = new System.Drawing.Point(277, 25);
            this.walktored.Name = "walktored";
            this.walktored.Size = new Size(58, 19);
            this.walktored.TabIndex = 161;
            this.walktored.Text = "(walk)";
            this.walktored.UseVisualStyleBackColor = true;
            this.potioncond.Enabled = false;
            this.potioncond.Location = new System.Drawing.Point(354, 60);
            this.potioncond.Name = "potioncond";
            this.potioncond.Size = new Size(46, 23);
            this.potioncond.TabIndex = 160;
            this.potioncond.Value = new Decimal(new int[4]
            {
        5,
        0,
        0,
        0
            });
            this.potioncond.ValueChanged += new EventHandler(this.potioncond_ValueChanged);
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(406, 62);
            this.label10.Name = "label10";
            this.label10.Size = new Size(36, 15);
            this.label10.TabIndex = 159;
            this.label10.Text = "% HP";
            this.potion.AutoSize = true;
            this.potion.Location = new System.Drawing.Point(253, 61);
            this.potion.Name = "potion";
            this.potion.Size = new Size(95, 19);
            this.potion.TabIndex = 158;
            this.potion.Text = "Eat Hydele at";
            this.potion.UseVisualStyleBackColor = true;
            this.potion.CheckedChanged += new EventHandler(this.potion_CheckedChanged_1);
            this.groupBox2.Controls.Add((Control)this.uncheckloot);
            this.groupBox2.Controls.Add((Control)this.walktoloot);
            this.groupBox2.Controls.Add((Control)this.looton);
            this.groupBox2.Controls.Add((Control)this.lootlocale);
            this.groupBox2.Location = new System.Drawing.Point(17, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(212, 108);
            this.groupBox2.TabIndex = 157;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loot Items";
            this.uncheckloot.AutoSize = true;
            this.uncheckloot.Checked = true;
            this.uncheckloot.CheckState = CheckState.Checked;
            this.uncheckloot.Location = new System.Drawing.Point(16, 43);
            this.uncheckloot.Name = "uncheckloot";
            this.uncheckloot.Size = new Size(178, 19);
            this.uncheckloot.TabIndex = 5;
            this.uncheckloot.Text = "auto-disable near nonfriends";
            this.uncheckloot.UseVisualStyleBackColor = true;
            this.walktoloot.AutoSize = true;
            this.walktoloot.Location = new System.Drawing.Point(92, 22);
            this.walktoloot.Name = "walktoloot";
            this.walktoloot.Size = new Size(96, 19);
            this.walktoloot.TabIndex = 4;
            this.walktoloot.Text = "Walk To Loot";
            this.walktoloot.UseVisualStyleBackColor = true;
            this.walktoloot.CheckedChanged += new EventHandler(this.walktoloot_CheckedChanged);
            this.looton.AutoSize = true;
            this.looton.Location = new System.Drawing.Point(16, 22);
            this.looton.Name = "looton";
            this.looton.Size = new Size(42, 19);
            this.looton.TabIndex = 0;
            this.looton.Text = "On";
            this.looton.UseVisualStyleBackColor = true;
            this.looton.CheckedChanged += new EventHandler(this.looton_CheckedChanged);
            this.lootlocale.DropDownStyle = ComboBoxStyle.DropDownList;
            this.lootlocale.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.lootlocale.FormattingEnabled = true;
            this.lootlocale.Items.AddRange(new object[14]
            {
        (object) "Custom #s",
        (object) "Everything",
        (object) "Event",
        (object) "Gold",
        (object) "Pyramid",
        (object) "Desert Dunes",
        (object) "Blossom Garden",
        (object) "Veltain Mines",
        (object) "Noam",
        (object) "Lost Ruins",
        (object) "Chaos",
        (object) "Andor",
        (object) "Aman Jungle",
        (object) "Shinewood Fruits"
            });
            this.lootlocale.Location = new System.Drawing.Point(18, 72);
            this.lootlocale.Name = "lootlocale";
            this.lootlocale.Size = new Size(172, 23);
            this.lootlocale.TabIndex = 1;
            this.lootlocale.SelectedIndexChanged += new EventHandler(this.lootlocale_SelectedIndexChanged);
            this.groupBox1.Controls.Add((Control)this.haxdeposit);
            this.groupBox1.Controls.Add((Control)this.newitem);
            this.groupBox1.Controls.Add((Control)this.removeitem);
            this.groupBox1.Controls.Add((Control)this.additem);
            this.groupBox1.Controls.Add((Control)this.autodepositlistbox);
            this.groupBox1.Controls.Add((Control)this.autodepositon);
            this.groupBox1.Location = new System.Drawing.Point(235, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(207, 222);
            this.groupBox1.TabIndex = 156;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto-Deposit (at bank)";
            this.haxdeposit.AutoSize = true;
            this.haxdeposit.Location = new System.Drawing.Point(66, 20);
            this.haxdeposit.Name = "haxdeposit";
            this.haxdeposit.Size = new Size(44, 19);
            this.haxdeposit.TabIndex = 10;
            this.haxdeposit.Text = "hax";
            this.haxdeposit.UseVisualStyleBackColor = true;
            this.newitem.AutoCompleteCustomSource.AddRange(new string[30]
            {
        "Ruby Earrings",
        "Beryl Earrings",
        "Coral Earrings",
        "Jade Ring",
        "Grave Ring",
        "Lapis Ring",
        "Talos Ore",
        "Bent Crux",
        "Goblin's Skull",
        "Hobgoblin's Skull",
        "Kobold's Skull",
        "Wooden Club",
        "Large Feather",
        "fior sal",
        "fior srad",
        "fior creag",
        "fior athar",
        "Passion Flower",
        "Light Belt",
        "Gold Jade Necklace",
        "Amber Necklace",
        "Iron Greaves",
        "Mythril Greaves",
        "Mythril Gauntlet",
        "Cordovan Boots",
        "Shagreen Boots",
        "Saffian Boots",
        "Magma Boots",
        "Enchanted Boots",
        "Hy-brasyl Boots"
            });
            this.newitem.AutoCompleteMode = AutoCompleteMode.Append;
            this.newitem.Location = new System.Drawing.Point(6, 160);
            this.newitem.Name = "newitem";
            this.newitem.Size = new Size(142, 23);
            this.newitem.TabIndex = 9;
            this.newitem.KeyPress += new KeyPressEventHandler(this.newitem_KeyPress);
            this.removeitem.Location = new System.Drawing.Point(64, 189);
            this.removeitem.Name = "removeitem";
            this.removeitem.Size = new Size(84, 23);
            this.removeitem.TabIndex = 8;
            this.removeitem.Text = "Remove";
            this.removeitem.UseVisualStyleBackColor = true;
            this.removeitem.Click += new EventHandler(this.removeitem_Click);
            this.additem.Location = new System.Drawing.Point(154, 155);
            this.additem.Name = "additem";
            this.additem.Size = new Size(47, 30);
            this.additem.TabIndex = 7;
            this.additem.Text = "Add";
            this.additem.UseVisualStyleBackColor = true;
            this.additem.Click += new EventHandler(this.additem_Click);
            this.autodepositlistbox.FormattingEnabled = true;
            this.autodepositlistbox.ItemHeight = 15;
            this.autodepositlistbox.Location = new System.Drawing.Point(6, 40);
            this.autodepositlistbox.Name = "autodepositlistbox";
            this.autodepositlistbox.Size = new Size(195, 109);
            this.autodepositlistbox.TabIndex = 6;
            this.autodepositon.Location = new System.Drawing.Point(18, 20);
            this.autodepositon.Name = "autodepositon";
            this.autodepositon.Size = new Size(42, 19);
            this.autodepositon.TabIndex = 5;
            this.autodepositon.Text = "On";
            this.autodepositon.UseVisualStyleBackColor = true;
            this.autodepositon.CheckedChanged += new EventHandler(this.autodepositon_CheckedChanged);
            this.groupBox46.Controls.Add((Control)this.dropitemstext);
            this.groupBox46.Controls.Add((Control)this.dropitemsremove);
            this.groupBox46.Controls.Add((Control)this.dropitemsadd);
            this.groupBox46.Controls.Add((Control)this.dropitemslist);
            this.groupBox46.Controls.Add((Control)this.dropitemson);
            this.groupBox46.Location = new System.Drawing.Point(17, 136);
            this.groupBox46.Name = "groupBox46";
            this.groupBox46.Size = new Size(212, 222);
            this.groupBox46.TabIndex = 155;
            this.groupBox46.TabStop = false;
            this.groupBox46.Text = "Drop Items";
            this.dropitemstext.AutoCompleteCustomSource.AddRange(new string[30]
            {
        "Ruby Earrings",
        "Beryl Earrings",
        "Coral Earrings",
        "Jade Ring",
        "Grave Ring",
        "Lapis Ring",
        "Talos Ore",
        "Bent Crux",
        "Goblin's Skull",
        "Hobgoblin's Skull",
        "Kobold's Skull",
        "Wooden Club",
        "Large Feather",
        "fior sal",
        "fior srad",
        "fior creag",
        "fior athar",
        "Passion Flower",
        "Light Belt",
        "Gold Jade Necklace",
        "Amber Necklace",
        "Iron Greaves",
        "Mythril Greaves",
        "Mythril Gauntlet",
        "Cordovan Boots",
        "Shagreen Boots",
        "Saffian Boots",
        "Magma Boots",
        "Enchanted Boots",
        "Hy-brasyl Boots"
            });
            this.dropitemstext.AutoCompleteMode = AutoCompleteMode.Append;
            this.dropitemstext.Location = new System.Drawing.Point(6, 160);
            this.dropitemstext.Name = "dropitemstext";
            this.dropitemstext.Size = new Size(144, 23);
            this.dropitemstext.TabIndex = 5;
            this.dropitemstext.KeyPress += new KeyPressEventHandler(this.dropitemstext_KeyPress);
            this.dropitemsremove.Location = new System.Drawing.Point(67, 192);
            this.dropitemsremove.Name = "dropitemsremove";
            this.dropitemsremove.Size = new Size(83, 23);
            this.dropitemsremove.TabIndex = 4;
            this.dropitemsremove.Text = "Remove";
            this.dropitemsremove.UseVisualStyleBackColor = true;
            this.dropitemsremove.Click += new EventHandler(this.dropitemsremove_Click);
            this.dropitemsadd.Location = new System.Drawing.Point(156, 153);
            this.dropitemsadd.Name = "dropitemsadd";
            this.dropitemsadd.Size = new Size(50, 34);
            this.dropitemsadd.TabIndex = 3;
            this.dropitemsadd.Text = "Add";
            this.dropitemsadd.UseVisualStyleBackColor = true;
            this.dropitemsadd.Click += new EventHandler(this.dropitemsadd_Click);
            this.dropitemslist.FormattingEnabled = true;
            this.dropitemslist.ItemHeight = 15;
            this.dropitemslist.Location = new System.Drawing.Point(6, 38);
            this.dropitemslist.Name = "dropitemslist";
            this.dropitemslist.Size = new Size(200, 109);
            this.dropitemslist.TabIndex = 2;
            this.dropitemson.Location = new System.Drawing.Point(18, 20);
            this.dropitemson.Name = "dropitemson";
            this.dropitemson.Size = new Size(42, 19);
            this.dropitemson.TabIndex = 1;
            this.dropitemson.Text = "On";
            this.dropitemson.UseVisualStyleBackColor = true;
            this.dropitemson.CheckedChanged += new EventHandler(this.dropitemson_CheckedChanged);
            this.trinket_holder.Controls.Add((Control)this.vanishingelixir);
            this.trinket_holder.Controls.Add((Control)this.elemusmount);
            this.trinket_holder.Controls.Add((Control)this.insectcloak);
            this.trinket_holder.Controls.Add((Control)this.assassinscroll);
            this.trinket_holder.Controls.Add((Control)this.nervestimulant);
            this.trinket_holder.Controls.Add((Control)this.musclestimulant);
            this.trinket_holder.Controls.Add((Control)this.dragonsscale);
            this.trinket_holder.Controls.Add((Control)this.dragonsfire);
            this.trinket_holder.Controls.Add((Control)this.fungusbeetleextract);
            this.trinket_holder.Controls.Add((Control)this.wakescroll);
            this.trinket_holder.Controls.Add((Control)this.icebottle);
            this.trinket_holder.Controls.Add((Control)this.mantidscent);
            this.trinket_holder.Location = new System.Drawing.Point(448, 22);
            this.trinket_holder.Name = "trinket_holder";
            this.trinket_holder.Size = new Size(156, 336);
            this.trinket_holder.TabIndex = 3;
            this.trinket_holder.TabStop = false;
            this.trinket_holder.Text = "Trinkets";
            this.vanishingelixir.Location = new System.Drawing.Point(15, 43);
            this.vanishingelixir.Name = "vanishingelixir";
            this.vanishingelixir.Size = new Size(118, 23);
            this.vanishingelixir.TabIndex = 15;
            this.vanishingelixir.Text = "Vanishing Elixir";
            this.vanishingelixir.UseVisualStyleBackColor = true;
            this.vanishingelixir.Visible = false;
            this.vanishingelixir.Click += new EventHandler(this.vanishingelixir_Click);
            this.elemusmount.AutoSize = true;
            this.elemusmount.Location = new System.Drawing.Point(15, 297);
            this.elemusmount.Name = "elemusmount";
            this.elemusmount.Size = new Size(103, 19);
            this.elemusmount.TabIndex = 14;
            this.elemusmount.Text = "Elemus Mount";
            this.elemusmount.UseVisualStyleBackColor = true;
            this.elemusmount.Visible = false;
            this.elemusmount.CheckedChanged += new EventHandler(this.elemusmount_CheckedChanged);
            this.insectcloak.AutoSize = true;
            this.insectcloak.Location = new System.Drawing.Point(15, 272);
            this.insectcloak.Name = "insectcloak";
            this.insectcloak.Size = new Size(90, 19);
            this.insectcloak.TabIndex = 13;
            this.insectcloak.Text = "Insect Cloak";
            this.insectcloak.UseVisualStyleBackColor = true;
            this.insectcloak.Visible = false;
            this.insectcloak.CheckedChanged += new EventHandler(this.insectcloak_CheckedChanged);
            this.assassinscroll.AutoSize = true;
            this.assassinscroll.Enabled = false;
            this.assassinscroll.Location = new System.Drawing.Point(15, 72);
            this.assassinscroll.Name = "assassinscroll";
            this.assassinscroll.Size = new Size(110, 19);
            this.assassinscroll.TabIndex = 11;
            this.assassinscroll.Text = "Assassin's Scroll";
            this.assassinscroll.UseVisualStyleBackColor = true;
            this.assassinscroll.Visible = false;
            this.assassinscroll.CheckedChanged += new EventHandler(this.assassinscroll_CheckedChanged);
            this.nervestimulant.AutoSize = true;
            this.nervestimulant.Location = new System.Drawing.Point(15, 222);
            this.nervestimulant.Name = "nervestimulant";
            this.nervestimulant.Size = new Size(111, 19);
            this.nervestimulant.TabIndex = 10;
            this.nervestimulant.Text = "Nerve Stimulant";
            this.nervestimulant.UseVisualStyleBackColor = true;
            this.nervestimulant.Visible = false;
            this.nervestimulant.CheckedChanged += new EventHandler(this.nervestimulant_CheckedChanged);
            this.musclestimulant.AutoSize = true;
            this.musclestimulant.Location = new System.Drawing.Point(15, 197);
            this.musclestimulant.Name = "musclestimulant";
            this.musclestimulant.Size = new Size(118, 19);
            this.musclestimulant.TabIndex = 9;
            this.musclestimulant.Text = "Muscle Stimulant";
            this.musclestimulant.UseVisualStyleBackColor = true;
            this.musclestimulant.Visible = false;
            this.musclestimulant.CheckedChanged += new EventHandler(this.musclestimulant_CheckedChanged);
            this.dragonsscale.AutoSize = true;
            this.dragonsscale.Location = new System.Drawing.Point(15, 172);
            this.dragonsscale.Name = "dragonsscale";
            this.dragonsscale.Size = new Size(103, 19);
            this.dragonsscale.TabIndex = 8;
            this.dragonsscale.Text = "Dragon's Scale";
            this.dragonsscale.UseVisualStyleBackColor = true;
            this.dragonsscale.Visible = false;
            this.dragonsscale.CheckedChanged += new EventHandler(this.dragonsscale_CheckedChanged);
            this.dragonsfire.AutoSize = true;
            this.dragonsfire.Location = new System.Drawing.Point(15, 147);
            this.dragonsfire.Name = "dragonsfire";
            this.dragonsfire.Size = new Size(95, 19);
            this.dragonsfire.TabIndex = 7;
            this.dragonsfire.Text = "Dragon's Fire";
            this.dragonsfire.UseVisualStyleBackColor = true;
            this.dragonsfire.Visible = false;
            this.dragonsfire.CheckedChanged += new EventHandler(this.dragonsfire_CheckedChanged);
            this.fungusbeetleextract.AutoSize = true;
            this.fungusbeetleextract.Location = new System.Drawing.Point(15, 122);
            this.fungusbeetleextract.Name = "fungusbeetleextract";
            this.fungusbeetleextract.Size = new Size(138, 19);
            this.fungusbeetleextract.TabIndex = 6;
            this.fungusbeetleextract.Text = "Fungus Beetle Extract";
            this.fungusbeetleextract.UseVisualStyleBackColor = true;
            this.fungusbeetleextract.Visible = false;
            this.fungusbeetleextract.CheckedChanged += new EventHandler(this.fungusbeetleextract_CheckedChanged);
            this.wakescroll.AutoSize = true;
            this.wakescroll.Checked = true;
            this.wakescroll.CheckState = CheckState.Checked;
            this.wakescroll.Location = new System.Drawing.Point(15, 247);
            this.wakescroll.Name = "wakescroll";
            this.wakescroll.Size = new Size(87, 19);
            this.wakescroll.TabIndex = 5;
            this.wakescroll.Text = "Wake Scroll";
            this.wakescroll.UseVisualStyleBackColor = true;
            this.wakescroll.Visible = false;
            this.wakescroll.CheckedChanged += new EventHandler(this.wakescroll_CheckedChanged);
            this.icebottle.AutoSize = true;
            this.icebottle.Checked = true;
            this.icebottle.CheckState = CheckState.Checked;
            this.icebottle.Location = new System.Drawing.Point(15, 97);
            this.icebottle.Name = "icebottle";
            this.icebottle.Size = new Size(80, 19);
            this.icebottle.TabIndex = 3;
            this.icebottle.Text = "Ice Bottles";
            this.icebottle.UseVisualStyleBackColor = true;
            this.icebottle.Visible = false;
            this.icebottle.CheckedChanged += new EventHandler(this.icebottle_CheckedChanged);
            this.mantidscent.AutoSize = true;
            this.mantidscent.Location = new System.Drawing.Point(15, 22);
            this.mantidscent.Name = "mantidscent";
            this.mantidscent.Size = new Size(96, 19);
            this.mantidscent.TabIndex = 0;
            this.mantidscent.Text = "Mantid Scent";
            this.mantidscent.UseVisualStyleBackColor = true;
            this.mantidscent.Visible = false;
            this.mantidscent.CheckedChanged += new EventHandler(this.mantidscent_CheckedChanged);
            this.redaislings.AutoSize = true;
            this.redaislings.Checked = true;
            this.redaislings.CheckState = CheckState.Checked;
            this.redaislings.Location = new System.Drawing.Point(259, 11);
            this.redaislings.Name = "redaislings";
            this.redaislings.Size = new Size(164, 19);
            this.redaislings.TabIndex = 0;
            this.redaislings.Text = "Revive Alts/Friends/Group";
            this.redaislings.UseVisualStyleBackColor = true;
            this.redaislings.CheckedChanged += new EventHandler(this.redaislings_CheckedChanged);
            this.tabPage6.Controls.Add((Control)this.destroytonics);
            this.tabPage6.Controls.Add((Control)this.expgemmp);
            this.tabPage6.Controls.Add((Control)this.useexpgem);
            this.tabPage6.Controls.Add((Control)this.openveltchestgold);
            this.tabPage6.Controls.Add((Control)this.label38);
            this.tabPage6.Controls.Add((Control)this.xpshroom);
            this.tabPage6.Controls.Add((Control)this.abrune);
            this.tabPage6.Controls.Add((Control)this.reequiparmor);
            this.tabPage6.Controls.Add((Control)this.throwtotems);
            this.tabPage6.Controls.Add((Control)this.openmedchest);
            this.tabPage6.Controls.Add((Control)this.pigwalk);
            this.tabPage6.Controls.Add((Control)this.openveltchest);
            this.tabPage6.Controls.Add((Control)this.expapbonus);
            this.tabPage6.Controls.Add((Control)this.groupBox4);
            this.tabPage6.Controls.Add((Control)this.groupBox45);
            this.tabPage6.Controls.Add((Control)this.groupBox16);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new Padding(3);
            this.tabPage6.Size = new Size(634, 377);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Hunting";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.destroytonics.AutoSize = true;
            this.destroytonics.Location = new System.Drawing.Point(24, 337);
            this.destroytonics.Name = "destroytonics";
            this.destroytonics.Size = new Size((int)sbyte.MaxValue, 19);
            this.destroytonics.TabIndex = 62;
            this.destroytonics.Text = "Destroy ALL Tonics";
            this.destroytonics.UseVisualStyleBackColor = true;
            this.expgemmp.AutoSize = true;
            this.expgemmp.Location = new System.Drawing.Point(186, 170);
            this.expgemmp.Name = "expgemmp";
            this.expgemmp.Size = new Size(92, 19);
            this.expgemmp.TabIndex = 61;
            this.expgemmp.Text = "(ascend MP)";
            this.expgemmp.UseVisualStyleBackColor = true;
            this.useexpgem.AutoSize = true;
            this.useexpgem.Location = new System.Drawing.Point(24, 170);
            this.useexpgem.Name = "useexpgem";
            this.useexpgem.Size = new Size(154, 19);
            this.useexpgem.TabIndex = 60;
            this.useexpgem.Text = "Use Exp Gem at Max Box";
            this.useexpgem.UseVisualStyleBackColor = true;
            this.openveltchestgold.Location = new System.Drawing.Point(181, 259);
            this.openveltchestgold.Name = "openveltchestgold";
            this.openveltchestgold.Size = new Size(72, 23);
            this.openveltchestgold.TabIndex = 59;
            this.openveltchestgold.Text = "1";
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(259, 246);
            this.label38.Name = "label38";
            this.label38.Size = new Size(31, 15);
            this.label38.TabIndex = 58;
            this.label38.Text = "gold";
            this.xpshroom.AutoSize = true;
            this.xpshroom.Location = new System.Drawing.Point(214, 145);
            this.xpshroom.Name = "xpshroom";
            this.xpshroom.Size = new Size(85, 19);
            this.xpshroom.TabIndex = 57;
            this.xpshroom.Text = "XP Shroom";
            this.xpshroom.UseVisualStyleBackColor = true;
            this.abrune.AutoSize = true;
            this.abrune.Location = new System.Drawing.Point(144, 145);
            this.abrune.Name = "abrune";
            this.abrune.Size = new Size(71, 19);
            this.abrune.TabIndex = 56;
            this.abrune.Text = "Ab Rune";
            this.abrune.UseVisualStyleBackColor = true;
            this.reequiparmor.AutoSize = true;
            this.reequiparmor.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.reequiparmor.Location = new System.Drawing.Point(24, 312);
            this.reequiparmor.Name = "reequiparmor";
            this.reequiparmor.Size = new Size(167, 19);
            this.reequiparmor.TabIndex = 55;
            this.reequiparmor.Text = "Re-Equip Armor (disrobe)";
            this.reequiparmor.UseVisualStyleBackColor = true;
            this.throwtotems.AutoSize = true;
            this.throwtotems.Location = new System.Drawing.Point(24, 211);
            this.throwtotems.Name = "throwtotems";
            this.throwtotems.Size = new Size(196, 19);
            this.throwtotems.TabIndex = 54;
            this.throwtotems.Text = "Tail Slam Totems (yowien vines)";
            this.throwtotems.UseVisualStyleBackColor = true;
            this.openmedchest.AutoSize = true;
            this.openmedchest.Location = new System.Drawing.Point(24, 236);
            this.openmedchest.Name = "openmedchest";
            this.openmedchest.Size = new Size(184, 19);
            this.openmedchest.TabIndex = 53;
            this.openmedchest.Text = "Open Medenia Chests (asilon)";
            this.openmedchest.UseVisualStyleBackColor = true;
            this.openmedchest.CheckedChanged += new EventHandler(this.openmedchest_CheckedChanged);
            this.pigwalk.AutoSize = true;
            this.pigwalk.Location = new System.Drawing.Point(24, 286);
            this.pigwalk.Name = "pigwalk";
            this.pigwalk.Size = new Size(123, 19);
            this.pigwalk.TabIndex = 51;
            this.pigwalk.Text = "Chase pigs (Event)";
            this.pigwalk.UseVisualStyleBackColor = true;
            this.openveltchest.AutoSize = true;
            this.openveltchest.Location = new System.Drawing.Point(24, 261);
            this.openveltchest.Name = "openveltchest";
            this.openveltchest.Size = new Size(155, 19);
            this.openveltchest.TabIndex = 50;
            this.openveltchest.Text = "Open veltain chests with";
            this.openveltchest.UseVisualStyleBackColor = true;
            this.expapbonus.AutoSize = true;
            this.expapbonus.Location = new System.Drawing.Point(24, 145);
            this.expapbonus.Name = "expapbonus";
            this.expapbonus.Size = new Size(122, 19);
            this.expapbonus.TabIndex = 49;
            this.expapbonus.Text = "Use Exp-Ap Bonus";
            this.expapbonus.UseVisualStyleBackColor = true;
            this.groupBox4.Controls.Add((Control)this.onlylurewithmpamount);
            this.groupBox4.Controls.Add((Control)this.onlylurewithmp);
            this.groupBox4.Controls.Add((Control)this.nolure);
            this.groupBox4.Controls.Add((Control)this.lurewithlamh);
            this.groupBox4.Controls.Add((Control)this.lurespells);
            this.groupBox4.Controls.Add((Control)this.lurewithskills);
            this.groupBox4.Controls.Add((Control)this.lurewithspells);
            this.groupBox4.Controls.Add((Control)this.waitonmonsters);
            this.groupBox4.Location = new System.Drawing.Point(316, 189);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(305, 158);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lure Settings (Mob Settings must be on)";
            this.onlylurewithmpamount.Enabled = false;
            this.onlylurewithmpamount.Location = new System.Drawing.Point(156, 122);
            this.onlylurewithmpamount.Name = "onlylurewithmpamount";
            this.onlylurewithmpamount.Size = new Size(79, 23);
            this.onlylurewithmpamount.TabIndex = 10;
            this.onlylurewithmpamount.Text = "10000";
            this.onlylurewithmp.AutoSize = true;
            this.onlylurewithmp.Enabled = false;
            this.onlylurewithmp.Location = new System.Drawing.Point(36, 124);
            this.onlylurewithmp.Name = "onlylurewithmp";
            this.onlylurewithmp.Size = new Size(119, 19);
            this.onlylurewithmp.TabIndex = 9;
            this.onlylurewithmp.Text = "Only Cast if MP >";
            this.onlylurewithmp.UseVisualStyleBackColor = true;
            this.nolure.AutoSize = true;
            this.nolure.Checked = true;
            this.nolure.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.nolure.Location = new System.Drawing.Point(210, 46);
            this.nolure.Name = "nolure";
            this.nolure.Size = new Size(55, 19);
            this.nolure.TabIndex = 8;
            this.nolure.TabStop = true;
            this.nolure.Text = "None";
            this.nolure.UseVisualStyleBackColor = true;
            this.lurewithlamh.AutoSize = true;
            this.lurewithlamh.Location = new System.Drawing.Point(17, 71);
            this.lurewithlamh.Name = "lurewithlamh";
            this.lurewithlamh.Size = new Size(104, 19);
            this.lurewithlamh.TabIndex = 7;
            this.lurewithlamh.Text = "Lure with lamh";
            this.lurewithlamh.UseVisualStyleBackColor = true;
            this.lurespells.DropDownStyle = ComboBoxStyle.DropDownList;
            this.lurespells.FormattingEnabled = true;
            this.lurespells.Location = new System.Drawing.Point(125, 95);
            this.lurespells.Name = "lurespells";
            this.lurespells.Size = new Size(139, 23);
            this.lurespells.TabIndex = 6;
            this.lurespells.SelectedIndexChanged += new EventHandler(this.lurespells_SelectedIndexChanged);
            this.lurewithskills.Enabled = false;
            this.lurewithskills.Location = new System.Drawing.Point(17, 47);
            this.lurewithskills.Name = "lurewithskills";
            this.lurewithskills.Size = new Size(138, 19);
            this.lurewithskills.TabIndex = 5;
            this.lurewithskills.Text = "Lure with Assail/Skills";
            this.lurewithskills.UseVisualStyleBackColor = true;
            this.lurewithspells.Location = new System.Drawing.Point(17, 96);
            this.lurewithspells.Name = "lurewithspells";
            this.lurewithspells.Size = new Size(102, 19);
            this.lurewithspells.TabIndex = 4;
            this.lurewithspells.Text = "Lure with Spell";
            this.lurewithspells.UseVisualStyleBackColor = true;
            this.lurewithspells.CheckedChanged += new EventHandler(this.lurespells_SelectedIndexChanged);
            this.waitonmonsters.Location = new System.Drawing.Point(17, 22);
            this.waitonmonsters.Name = "waitonmonsters";
            this.waitonmonsters.Size = new Size(118, 19);
            this.waitonmonsters.TabIndex = 3;
            this.waitonmonsters.Text = "Wait on monsters";
            this.waitonmonsters.UseVisualStyleBackColor = true;
            this.waitonmonsters.CheckedChanged += new EventHandler(this.waitonmonsters_CheckedChanged);
            this.groupBox45.Controls.Add((Control)this.label46);
            this.groupBox45.Controls.Add((Control)this.nolongermobbed);
            this.groupBox45.Controls.Add((Control)this.actonlyinmobs);
            this.groupBox45.Controls.Add((Control)this.label39);
            this.groupBox45.Controls.Add((Control)this.mobdistance);
            this.groupBox45.Controls.Add((Control)this.mobsize);
            this.groupBox45.Controls.Add((Control)this.dumbtext);
            this.groupBox45.Controls.Add((Control)this.label7);
            this.groupBox45.Location = new System.Drawing.Point(316, 17);
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Size = new Size(305, 156);
            this.groupBox45.TabIndex = 43;
            this.groupBox45.TabStop = false;
            this.groupBox45.Text = "Mob Settings";
            this.label46.Location = new System.Drawing.Point(221, 116);
            this.label46.Name = "label46";
            this.label46.Size = new Size(44, 15);
            this.label46.TabIndex = 6;
            this.label46.Text = "remain";
            this.nolongermobbed.Location = new System.Drawing.Point(173, 114);
            this.nolongermobbed.Maximum = new Decimal(new int[4]
            {
        10,
        0,
        0,
        0
            });
            this.nolongermobbed.Name = "nolongermobbed";
            this.nolongermobbed.Size = new Size(42, 23);
            this.nolongermobbed.TabIndex = 5;
            this.actonlyinmobs.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.actonlyinmobs.Location = new System.Drawing.Point(74, 39);
            this.actonlyinmobs.Name = "actonlyinmobs";
            this.actonlyinmobs.Size = new Size(149, 19);
            this.actonlyinmobs.TabIndex = 10;
            this.actonlyinmobs.Text = "Activate mob settings";
            this.actonlyinmobs.UseVisualStyleBackColor = true;
            this.actonlyinmobs.CheckedChanged += new EventHandler(this.actonlyinmobs_CheckedChanged);
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(21, 116);
            this.label39.Name = "label39";
            this.label39.Size = new Size(146, 15);
            this.label39.TabIndex = 4;
            this.label39.Text = "No longer 'mobbed' when";
            this.mobdistance.Location = new System.Drawing.Point(204, 76);
            this.mobdistance.Maximum = new Decimal(new int[4]
            {
        12,
        0,
        0,
        0
            });
            this.mobdistance.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.mobdistance.Name = "mobdistance";
            this.mobdistance.Size = new Size(42, 23);
            this.mobdistance.TabIndex = 3;
            this.mobdistance.Value = new Decimal(new int[4]
            {
        12,
        0,
        0,
        0
            });
            this.mobsize.Location = new System.Drawing.Point(85, 76);
            this.mobsize.Maximum = new Decimal(new int[4]
            {
        60,
        0,
        0,
        0
            });
            this.mobsize.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.mobsize.Name = "mobsize";
            this.mobsize.Size = new Size(42, 23);
            this.mobsize.TabIndex = 0;
            this.mobsize.Value = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.dumbtext.Location = new System.Drawing.Point(133, 78);
            this.dumbtext.Name = "dumbtext";
            this.dumbtext.Size = new Size(65, 15);
            this.dumbtext.TabIndex = 2;
            this.dumbtext.Text = "Mob range";
            this.label7.Location = new System.Drawing.Point(25, 78);
            this.label7.Name = "label7";
            this.label7.Size = new Size(54, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Mob size";
            this.groupBox16.Controls.Add((Control)this.calc_gold);
            this.groupBox16.Controls.Add((Control)this.calc_message);
            this.groupBox16.Controls.Add((Control)this.calc_ap);
            this.groupBox16.Controls.Add((Control)this.calc_reset);
            this.groupBox16.Controls.Add((Control)this.calc_exp);
            this.groupBox16.Controls.Add((Control)this.calc_toggle);
            this.groupBox16.Location = new System.Drawing.Point(8, 17);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new Size(293, 109);
            this.groupBox16.TabIndex = 40;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Calculator";
            this.calc_gold.Location = new System.Drawing.Point(197, 22);
            this.calc_gold.Name = "calc_gold";
            this.calc_gold.Size = new Size(51, 19);
            this.calc_gold.TabIndex = 2;
            this.calc_gold.Text = "Gold";
            this.calc_gold.UseVisualStyleBackColor = true;
            this.calc_gold.CheckedChanged += new EventHandler(this.calc_gold_CheckedChanged);
            this.calc_message.Checked = true;
            this.calc_message.CheckState = CheckState.Checked;
            this.calc_message.Location = new System.Drawing.Point(16, 80);
            this.calc_message.Name = "calc_message";
            this.calc_message.Size = new Size(254, 19);
            this.calc_message.TabIndex = 7;
            this.calc_message.Text = "Receive in-game updates every 10 minutes.";
            this.calc_message.UseVisualStyleBackColor = true;
            this.calc_ap.Location = new System.Drawing.Point(122, 22);
            this.calc_ap.Name = "calc_ap";
            this.calc_ap.Size = new Size(60, 19);
            this.calc_ap.TabIndex = 1;
            this.calc_ap.Text = "Ability";
            this.calc_ap.UseVisualStyleBackColor = true;
            this.calc_ap.CheckedChanged += new EventHandler(this.calc_ap_CheckedChanged);
            this.calc_reset.Enabled = false;
            this.calc_reset.Location = new System.Drawing.Point(147, 47);
            this.calc_reset.Name = "calc_reset";
            this.calc_reset.Size = new Size(76, 25);
            this.calc_reset.TabIndex = 5;
            this.calc_reset.Text = "Reset";
            this.calc_reset.UseVisualStyleBackColor = true;
            this.calc_reset.Click += new EventHandler(this.calc_reset_Click);
            this.calc_exp.Location = new System.Drawing.Point(27, 22);
            this.calc_exp.Name = "calc_exp";
            this.calc_exp.Size = new Size(82, 19);
            this.calc_exp.TabIndex = 0;
            this.calc_exp.Text = "Experience";
            this.calc_exp.UseVisualStyleBackColor = true;
            this.calc_exp.CheckedChanged += new EventHandler(this.calc_exp_CheckedChanged);
            this.calc_toggle.Enabled = false;
            this.calc_toggle.Location = new System.Drawing.Point(42, 47);
            this.calc_toggle.Name = "calc_toggle";
            this.calc_toggle.Size = new Size(77, 25);
            this.calc_toggle.TabIndex = 4;
            this.calc_toggle.Text = "Start";
            this.calc_toggle.UseVisualStyleBackColor = true;
            this.calc_toggle.Click += new EventHandler(this.calc_toggle_Click);
            this.tabPage11.Controls.Add((Control)this.groupBox11);
            this.tabPage11.Controls.Add((Control)this.groupBox32);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new Padding(3);
            this.tabPage11.Size = new Size(634, 377);
            this.tabPage11.TabIndex = 8;
            this.tabPage11.Text = "Speech";
            this.tabPage11.UseVisualStyleBackColor = true;
            this.groupBox11.Controls.Add((Control)this.respondflower);
            this.groupBox11.Controls.Add((Control)this.respondfas);
            this.groupBox11.Controls.Add((Control)this.respondaite);
            this.groupBox11.Location = new System.Drawing.Point(19, 31);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new Size(217, 178);
            this.groupBox11.TabIndex = 43;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Respond to Speech";
            this.respondflower.AutoSize = true;
            this.respondflower.Location = new System.Drawing.Point(26, 83);
            this.respondflower.Name = "respondflower";
            this.respondflower.Size = new Size(61, 19);
            this.respondflower.TabIndex = 0;
            this.respondflower.Text = "Flower";
            this.respondflower.UseVisualStyleBackColor = true;
            this.respondfas.AutoSize = true;
            this.respondfas.Location = new System.Drawing.Point(26, 58);
            this.respondfas.Name = "respondfas";
            this.respondfas.Size = new Size(43, 19);
            this.respondfas.TabIndex = 42;
            this.respondfas.Text = "Fas";
            this.respondfas.UseVisualStyleBackColor = true;
            this.respondaite.AutoSize = true;
            this.respondaite.Location = new System.Drawing.Point(26, 33);
            this.respondaite.Name = "respondaite";
            this.respondaite.Size = new Size(47, 19);
            this.respondaite.TabIndex = 41;
            this.respondaite.Text = "Aite";
            this.respondaite.UseVisualStyleBackColor = true;
            this.groupBox32.Controls.Add((Control)this.requesttextflower);
            this.groupBox32.Controls.Add((Control)this.requesttextred);
            this.groupBox32.Controls.Add((Control)this.requesttextfas);
            this.groupBox32.Controls.Add((Control)this.requesttextaite);
            this.groupBox32.Controls.Add((Control)this.requestflowercond);
            this.groupBox32.Controls.Add((Control)this.requestred);
            this.groupBox32.Controls.Add((Control)this.requestflower);
            this.groupBox32.Controls.Add((Control)this.requestfas);
            this.groupBox32.Controls.Add((Control)this.requestaite);
            this.groupBox32.Location = new System.Drawing.Point(259, 27);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new Size(327, 182);
            this.groupBox32.TabIndex = 40;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "Request Something";
            this.requesttextflower.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.requesttextflower.ForeColor = SystemColors.ControlText;
            this.requesttextflower.Location = new System.Drawing.Point(201, 122);
            this.requesttextflower.MaxLength = 25;
            this.requesttextflower.Name = "requesttextflower";
            this.requesttextflower.Size = new Size(100, 21);
            this.requesttextflower.TabIndex = 41;
            this.requesttextflower.Text = "f";
            this.requesttextred.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.requesttextred.ForeColor = SystemColors.ControlText;
            this.requesttextred.Location = new System.Drawing.Point(201, 89);
            this.requesttextred.MaxLength = 25;
            this.requesttextred.Name = "requesttextred";
            this.requesttextred.Size = new Size(100, 21);
            this.requesttextred.TabIndex = 40;
            this.requesttextred.Text = "red";
            this.requesttextfas.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.requesttextfas.ForeColor = SystemColors.ControlText;
            this.requesttextfas.Location = new System.Drawing.Point(201, 60);
            this.requesttextfas.MaxLength = 25;
            this.requesttextfas.Name = "requesttextfas";
            this.requesttextfas.Size = new Size(100, 21);
            this.requesttextfas.TabIndex = 38;
            this.requesttextfas.Text = "fas";
            this.requesttextaite.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.requesttextaite.ForeColor = SystemColors.ControlText;
            this.requesttextaite.Location = new System.Drawing.Point(201, 35);
            this.requesttextaite.MaxLength = 25;
            this.requesttextaite.Name = "requesttextaite";
            this.requesttextaite.Size = new Size(100, 21);
            this.requesttextaite.TabIndex = 37;
            this.requesttextaite.Text = "aite";
            this.requestflowercond.Increment = new Decimal(new int[4]
            {
        500,
        0,
        0,
        0
            });
            this.requestflowercond.Location = new System.Drawing.Point((int)sbyte.MaxValue, 123);
            this.requestflowercond.Maximum = new Decimal(new int[4]
            {
        1000000,
        0,
        0,
        0
            });
            this.requestflowercond.Name = "requestflowercond";
            this.requestflowercond.Size = new Size(55, 23);
            this.requestflowercond.TabIndex = 36;
            this.requestflowercond.Value = new Decimal(new int[4]
            {
        6000,
        0,
        0,
        0
            });
            this.requestred.AutoSize = true;
            this.requestred.Location = new System.Drawing.Point(22, 91);
            this.requestred.Name = "requestred";
            this.requestred.Size = new Size(88, 19);
            this.requestred.TabIndex = 34;
            this.requestred.Text = "Request red";
            this.requestred.UseVisualStyleBackColor = true;
            this.requestflower.AutoSize = true;
            this.requestflower.Location = new System.Drawing.Point(22, 116);
            this.requestflower.Name = "requestflower";
            this.requestflower.Size = new Size(104, 34);
            this.requestflower.TabIndex = 35;
            this.requestflower.Text = "Request flower\r\nwhen mp <";
            this.requestflower.UseVisualStyleBackColor = true;
            this.requestfas.AutoSize = true;
            this.requestfas.Location = new System.Drawing.Point(22, 64);
            this.requestfas.Name = "requestfas";
            this.requestfas.Size = new Size(86, 19);
            this.requestfas.TabIndex = 32;
            this.requestfas.Text = "Request fas";
            this.requestfas.UseVisualStyleBackColor = true;
            this.requestaite.AutoSize = true;
            this.requestaite.Location = new System.Drawing.Point(22, 37);
            this.requestaite.Name = "requestaite";
            this.requestaite.Size = new Size(90, 19);
            this.requestaite.TabIndex = 31;
            this.requestaite.Text = "Request aite";
            this.requestaite.UseVisualStyleBackColor = true;
            this.tabPage4.Controls.Add((Control)this.stopfollow);
            this.tabPage4.Controls.Add((Control)this.walkao);
            this.tabPage4.Controls.Add((Control)this.walkdion);
            this.tabPage4.Controls.Add((Control)this.walkambush);
            this.tabPage4.Controls.Add((Control)this.walkheal);
            this.tabPage4.Controls.Add((Control)this.walktowards);
            this.tabPage4.Controls.Add((Control)this.ignorewalkall);
            this.tabPage4.Controls.Add((Control)this.haltwalknonfriends);
            this.tabPage4.Controls.Add((Control)this.label32);
            this.tabPage4.Controls.Add((Control)this.label31);
            this.tabPage4.Controls.Add((Control)this.label30);
            this.tabPage4.Controls.Add((Control)this.label29);
            this.tabPage4.Controls.Add((Control)this.label28);
            this.tabPage4.Controls.Add((Control)this.walkeverytile);
            this.tabPage4.Controls.Add((Control)this.bottomx);
            this.tabPage4.Controls.Add((Control)this.bottomy);
            this.tabPage4.Controls.Add((Control)this.topy);
            this.tabPage4.Controls.Add((Control)this.topx);
            this.tabPage4.Controls.Add((Control)this.walkclosebyonly);
            this.tabPage4.Controls.Add((Control)this.label25);
            this.tabPage4.Controls.Add((Control)this.autowalker_button);
            this.tabPage4.Controls.Add((Control)this.walklocaleslist);
            this.tabPage4.Controls.Add((Control)this.autowalker_locales);
            this.tabPage4.Controls.Add((Control)this.label3);
            this.tabPage4.Controls.Add((Control)this.walkconfig);
            this.tabPage4.Controls.Add((Control)this.wayregionson);
            this.tabPage4.Controls.Add((Control)this.castwhilefollow);
            this.tabPage4.Controls.Add((Control)this.followdist);
            this.tabPage4.Controls.Add((Control)this.label2);
            this.tabPage4.Controls.Add((Control)this.followtarget);
            this.tabPage4.Controls.Add((Control)this.followplayer);
            this.tabPage4.Controls.Add((Control)this.mediumwalk);
            this.tabPage4.Controls.Add((Control)this.label1);
            this.tabPage4.Controls.Add((Control)this.walksettings);
            this.tabPage4.Controls.Add((Control)this.fastwalk);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new Size(634, 377);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Walk";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.stopfollow.AutoSize = true;
            this.stopfollow.Checked = true;
            this.stopfollow.CheckState = CheckState.Checked;
            this.stopfollow.Location = new System.Drawing.Point(11, 61);
            this.stopfollow.Name = "stopfollow";
            this.stopfollow.Size = new Size(190, 19);
            this.stopfollow.TabIndex = 34;
            this.stopfollow.Text = "Halt follow around non-friends";
            this.stopfollow.UseVisualStyleBackColor = true;
            this.stopfollow.Visible = false;
            this.walkao.AutoSize = true;
            this.walkao.Location = new System.Drawing.Point(172, 285);
            this.walkao.Name = "walkao";
            this.walkao.Size = new Size(39, 19);
            this.walkao.TabIndex = 33;
            this.walkao.Text = "ao";
            this.walkao.UseVisualStyleBackColor = true;
            this.walkao.Visible = false;
            this.walkdion.AutoSize = true;
            this.walkdion.Location = new System.Drawing.Point(172, 310);
            this.walkdion.Name = "walkdion";
            this.walkdion.Size = new Size(50, 19);
            this.walkdion.TabIndex = 32;
            this.walkdion.Text = "dion";
            this.walkdion.UseVisualStyleBackColor = true;
            this.walkdion.Visible = false;
            this.walkambush.AutoSize = true;
            this.walkambush.Location = new System.Drawing.Point(172, 335);
            this.walkambush.Name = "walkambush";
            this.walkambush.Size = new Size(69, 19);
            this.walkambush.TabIndex = 31;
            this.walkambush.Text = "ambush";
            this.walkambush.UseVisualStyleBackColor = true;
            this.walkambush.Visible = false;
            this.walkheal.AutoSize = true;
            this.walkheal.Location = new System.Drawing.Point(172, 261);
            this.walkheal.Name = "walkheal";
            this.walkheal.Size = new Size(48, 19);
            this.walkheal.TabIndex = 30;
            this.walkheal.Text = "heal";
            this.walkheal.UseVisualStyleBackColor = true;
            this.walkheal.Visible = false;
            this.walktowards.AutoSize = true;
            this.walktowards.Location = new System.Drawing.Point(376, 112);
            this.walktowards.Name = "walktowards";
            this.walktowards.Size = new Size(147, 19);
            this.walktowards.TabIndex = 29;
            this.walktowards.Text = "Walk Towards Monster";
            this.toolTip1.SetToolTip((Control)this.walktowards, "This is to be used on a caster on waypoints if you want him to walk towards the monster slightly before killing it, this option also narrows the spell attack distance from 12 tiles to 8 tiles.");
            this.walktowards.UseVisualStyleBackColor = true;
            this.ignorewalkall.AutoSize = true;
            this.ignorewalkall.Location = new System.Drawing.Point(412, 19);
            this.ignorewalkall.Name = "ignorewalkall";
            this.ignorewalkall.Size = new Size(171, 19);
            this.ignorewalkall.TabIndex = 28;
            this.ignorewalkall.Text = "Ignore '/walk all' command";
            this.ignorewalkall.UseVisualStyleBackColor = true;
            this.haltwalknonfriends.AutoSize = true;
            this.haltwalknonfriends.Checked = true;
            this.haltwalknonfriends.CheckState = CheckState.Checked;
            this.haltwalknonfriends.Location = new System.Drawing.Point(11, 132);
            this.haltwalknonfriends.Name = "haltwalknonfriends";
            this.haltwalknonfriends.Size = new Size(211, 19);
            this.haltwalknonfriends.TabIndex = 27;
            this.haltwalknonfriends.Text = "Halt waypoints around non-friends";
            this.haltwalknonfriends.UseVisualStyleBackColor = true;
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(376, 217);
            this.label32.Name = "label32";
            this.label32.Size = new Size(204, 15);
            this.label32.TabIndex = 26;
            this.label32.Text = "(Place Blocks in configure waypoints)";
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(469, 238);
            this.label31.Name = "label31";
            this.label31.Size = new Size(54, 15);
            this.label31.TabIndex = 25;
            this.label31.Text = "bottomX";
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(469, 277);
            this.label30.Name = "label30";
            this.label30.Size = new Size(54, 15);
            this.label30.TabIndex = 24;
            this.label30.Text = "bottomY";
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(384, 277);
            this.label29.Name = "label29";
            this.label29.Size = new Size(32, 15);
            this.label29.TabIndex = 23;
            this.label29.Text = "topY";
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(384, 238);
            this.label28.Name = "label28";
            this.label28.Size = new Size(32, 15);
            this.label28.TabIndex = 22;
            this.label28.Text = "topX";
            this.walkeverytile.AutoSize = true;
            this.walkeverytile.Location = new System.Drawing.Point(418, 195);
            this.walkeverytile.Name = "walkeverytile";
            this.walkeverytile.Size = new Size(105, 19);
            this.walkeverytile.TabIndex = 21;
            this.walkeverytile.Text = "Walk Every Tile";
            this.toolTip1.SetToolTip((Control)this.walkeverytile, "This option is useful for:\r\nfinding house key in water\r\nbotting eingren/bnc maps etc etc.");
            this.walkeverytile.UseVisualStyleBackColor = true;
            this.bottomx.Location = new System.Drawing.Point(418, 274);
            this.bottomx.Name = "bottomx";
            this.bottomx.Size = new Size(40, 23);
            this.bottomx.TabIndex = 20;
            this.bottomx.Text = "0";
            this.bottomy.Location = new System.Drawing.Point(526, 274);
            this.bottomy.Name = "bottomy";
            this.bottomy.Size = new Size(40, 23);
            this.bottomy.TabIndex = 19;
            this.bottomy.Text = "255";
            this.topy.Location = new System.Drawing.Point(526, 235);
            this.topy.Name = "topy";
            this.topy.Size = new Size(40, 23);
            this.topy.TabIndex = 18;
            this.topy.Text = "255";
            this.topx.Location = new System.Drawing.Point(418, 235);
            this.topx.Name = "topx";
            this.topx.Size = new Size(40, 23);
            this.topx.TabIndex = 17;
            this.topx.Text = "0";
            this.walkclosebyonly.AutoSize = true;
            this.walkclosebyonly.Location = new System.Drawing.Point(11, 112);
            this.walkclosebyonly.Name = "walkclosebyonly";
            this.walkclosebyonly.Size = new Size(340, 19);
            this.walkclosebyonly.TabIndex = 16;
            this.walkclosebyonly.Text = "Only walk to monsters within 10 spaces of current waypoint";
            this.toolTip1.SetToolTip((Control)this.walkclosebyonly, "(works best if waypoints are placed every several spaces,\r\nand mobbed setting set higher than 1 monster)");
            this.walkclosebyonly.UseVisualStyleBackColor = true;
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(340, 94);
            this.label25.Name = "label25";
            this.label25.Size = new Size(250, 15);
            this.label25.TabIndex = 15;
            this.label25.Text = "(Works with Mobbed settings on Hunting tab)";
            this.autowalker_button.Location = new System.Drawing.Point(164, 217);
            this.autowalker_button.Name = "autowalker_button";
            this.autowalker_button.Size = new Size(90, 23);
            this.autowalker_button.TabIndex = 14;
            this.autowalker_button.Text = "Start";
            this.autowalker_button.UseVisualStyleBackColor = true;
            this.autowalker_button.Click += new EventHandler(this.autowalker_button_Click);
            this.walklocaleslist.FormattingEnabled = true;
            this.walklocaleslist.ItemHeight = 15;
            this.walklocaleslist.Location = new System.Drawing.Point(11, 195);
            this.walklocaleslist.Name = "walklocaleslist";
            this.walklocaleslist.Size = new Size(147, 169);
            this.walklocaleslist.TabIndex = 13;
            this.walklocaleslist.SelectedIndexChanged += new EventHandler(this.walklocaleslist_SelectedIndexChanged);
            this.autowalker_locales.DropDownStyle = ComboBoxStyle.DropDownList;
            this.autowalker_locales.FormattingEnabled = true;
            this.autowalker_locales.Items.AddRange(new object[34]
            {
        (object) "Veltain Mines",
        (object) "Aman Jungle",
        (object) "Lost Ruins",
        (object) "Water Dungeon",
        (object) "Hwarone",
        (object) "Andor",
        (object) "Desert Dunes",
        (object) "Noam",
        (object) "Asilon",
        (object) "Chaos",
        (object) "Mehadi",
        (object) "Shinewood",
        (object) "Lynith",
        (object) "Karlopos",
        (object) "Nobis",
        (object) "Mount Giragan",
        (object) "Cthonic Remains",
        (object) "Mileth",
        (object) "Abel",
        (object) "Pravat",
        (object) "Arena",
        (object) "Piet",
        (object) "Loures",
        (object) "Rucesion",
        (object) "Tagor",
        (object) "Eingren Manor",
        (object) "Undine",
        (object) "Astrid",
        (object) "Suomi",
        (object) "Mt Merry",
        (object) "Count",
        (object) "Balanced Arena",
        (object) "Nearest Restaurant",
        (object) "Nearest Bank"
            });
            this.autowalker_locales.Location = new System.Drawing.Point(133, 166);
            this.autowalker_locales.Name = "autowalker_locales";
            this.autowalker_locales.Size = new Size(121, 23);
            this.autowalker_locales.TabIndex = 12;
            this.autowalker_locales.SelectedIndexChanged += new EventHandler(this.autowalker_locales_SelectedIndexChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 169);
            this.label3.Name = "label3";
            this.label3.Size = new Size(110, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Walk to Destination";
            this.walkconfig.Location = new System.Drawing.Point(196, 90);
            this.walkconfig.Name = "walkconfig";
            this.walkconfig.Size = new Size(138, 23);
            this.walkconfig.TabIndex = 10;
            this.walkconfig.Text = "Configure Waypoints";
            this.walkconfig.UseVisualStyleBackColor = true;
            this.walkconfig.Click += new EventHandler(this.walkconfig_Click);
            this.wayregionson.AutoSize = true;
            this.wayregionson.Location = new System.Drawing.Point(11, 93);
            this.wayregionson.Name = "wayregionson";
            this.wayregionson.Size = new Size(167, 19);
            this.wayregionson.TabIndex = 9;
            this.wayregionson.Text = "Use Configured Waypoints";
            this.wayregionson.UseVisualStyleBackColor = true;
            this.wayregionson.CheckedChanged += new EventHandler(this.wayregionson_CheckedChanged);
            this.castwhilefollow.AutoSize = true;
            this.castwhilefollow.Location = new System.Drawing.Point(379, 51);
            this.castwhilefollow.Name = "castwhilefollow";
            this.castwhilefollow.Size = new Size(193, 19);
            this.castwhilefollow.TabIndex = 8;
            this.castwhilefollow.Text = "Halt walking to cast 1 line spells";
            this.castwhilefollow.UseVisualStyleBackColor = true;
            this.castwhilefollow.CheckedChanged += new EventHandler(this.castwhilefollow_CheckedChanged);
            this.followdist.Location = new System.Drawing.Point(276, 36);
            this.followdist.Maximum = new Decimal(new int[4]
            {
        12,
        0,
        0,
        0
            });
            this.followdist.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.followdist.Name = "followdist";
            this.followdist.Size = new Size(34, 23);
            this.followdist.TabIndex = 7;
            this.followdist.Value = new Decimal(new int[4]
            {
        3,
        0,
        0,
        0
            });
            this.followdist.ValueChanged += new EventHandler(this.followdist_ValueChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 38);
            this.label2.Name = "label2";
            this.label2.Size = new Size(51, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "distance";
            this.followtarget.Location = new System.Drawing.Point(113, 35);
            this.followtarget.Name = "followtarget";
            this.followtarget.Size = new Size(100, 23);
            this.followtarget.TabIndex = 5;
            this.followtarget.TextChanged += new EventHandler(this.followtarget_TextChanged);
            this.followplayer.AutoSize = true;
            this.followplayer.Location = new System.Drawing.Point(11, 37);
            this.followplayer.Name = "followplayer";
            this.followplayer.Size = new Size(96, 19);
            this.followplayer.TabIndex = 4;
            this.followplayer.Text = "Follow Player";
            this.followplayer.UseVisualStyleBackColor = true;
            this.followplayer.CheckedChanged += new EventHandler(this.followplayer_CheckedChanged);
            this.mediumwalk.AutoSize = true;
            this.mediumwalk.Location = new System.Drawing.Point(243, 8);
            this.mediumwalk.Name = "mediumwalk";
            this.mediumwalk.Size = new Size(71, 19);
            this.mediumwalk.TabIndex = 3;
            this.mediumwalk.Text = "Medium";
            this.mediumwalk.UseVisualStyleBackColor = true;
            this.mediumwalk.CheckedChanged += new EventHandler(this.mediumwalk_CheckedChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(99, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Auto-Walk Speed";
            this.walksettings.Increment = new Decimal(new int[4]
            {
        50,
        0,
        0,
        0
            });
            this.walksettings.Location = new System.Drawing.Point(113, 7);
            this.walksettings.Maximum = new Decimal(new int[4]
            {
        410,
        0,
        0,
        0
            });
            this.walksettings.Minimum = new Decimal(new int[4]
            {
        110,
        0,
        0,
        0
            });
            this.walksettings.Name = "walksettings";
            this.walksettings.Size = new Size(44, 23);
            this.walksettings.TabIndex = 1;
            this.walksettings.Value = new Decimal(new int[4]
            {
        410,
        0,
        0,
        0
            });
            this.walksettings.ValueChanged += new EventHandler(this.walksettings_ValueChanged);
            this.fastwalk.AutoSize = true;
            this.fastwalk.Location = new System.Drawing.Point(180, 8);
            this.fastwalk.Name = "fastwalk";
            this.fastwalk.Size = new Size(47, 19);
            this.fastwalk.TabIndex = 0;
            this.fastwalk.Text = "Fast";
            this.fastwalk.UseVisualStyleBackColor = true;
            this.fastwalk.CheckedChanged += new EventHandler(this.fastwalk_CheckedChanged);
            this.tabPage12.Controls.Add((Control)this.groupBox13);
            this.tabPage12.Controls.Add((Control)this.rescueascendername);
            this.tabPage12.Controls.Add((Control)this.rescueascender);
            this.tabPage12.Controls.Add((Control)this.openascendform);
            this.tabPage12.Controls.Add((Control)this.assistonthischar);
            this.tabPage12.Controls.Add((Control)this.groupBox26);
            this.tabPage12.Controls.Add((Control)this.groupBox24);
            this.tabPage12.Controls.Add((Control)this.groupBox25);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new Size(634, 377);
            this.tabPage12.TabIndex = 9;
            this.tabPage12.Text = "Tasks";
            this.tabPage12.UseVisualStyleBackColor = true;
            this.groupBox13.Controls.Add((Control)this.ruby);
            this.groupBox13.Controls.Add((Control)this.coral);
            this.groupBox13.Controls.Add((Control)this.beryl);
            this.groupBox13.Controls.Add((Control)this.buygems);
            this.groupBox13.Location = new System.Drawing.Point(19, 100);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new Size(277, 56);
            this.groupBox13.TabIndex = 16;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Black Market";
            this.ruby.AutoSize = true;
            this.ruby.Location = new System.Drawing.Point(214, 25);
            this.ruby.Name = "ruby";
            this.ruby.Size = new Size(32, 19);
            this.ruby.TabIndex = 3;
            this.ruby.Text = "R";
            this.ruby.UseVisualStyleBackColor = true;
            this.coral.AutoSize = true;
            this.coral.Location = new System.Drawing.Point(163, 25);
            this.coral.Name = "coral";
            this.coral.Size = new Size(33, 19);
            this.coral.TabIndex = 2;
            this.coral.Text = "C";
            this.coral.UseVisualStyleBackColor = true;
            this.beryl.AutoSize = true;
            this.beryl.Checked = true;
            this.beryl.Location = new System.Drawing.Point(112, 25);
            this.beryl.Name = "beryl";
            this.beryl.Size = new Size(32, 19);
            this.beryl.TabIndex = 1;
            this.beryl.TabStop = true;
            this.beryl.Text = "B";
            this.beryl.UseVisualStyleBackColor = true;
            this.buygems.AutoSize = true;
            this.buygems.Location = new System.Drawing.Point(9, 25);
            this.buygems.Name = "buygems";
            this.buygems.Size = new Size(79, 19);
            this.buygems.TabIndex = 0;
            this.buygems.Text = "Buy Gems";
            this.buygems.UseVisualStyleBackColor = true;
            this.rescueascendername.Location = new System.Drawing.Point(161, 73);
            this.rescueascendername.Name = "rescueascendername";
            this.rescueascendername.Size = new Size(100, 23);
            this.rescueascendername.TabIndex = 15;
            this.rescueascendername.TextChanged += new EventHandler(this.rescueascendername_TextChanged);
            this.rescueascender.AutoSize = true;
            this.rescueascender.Location = new System.Drawing.Point(36, 75);
            this.rescueascender.Name = "rescueascender";
            this.rescueascender.Size = new Size(118, 19);
            this.rescueascender.TabIndex = 14;
            this.rescueascender.Text = "Rescue Ascender:";
            this.rescueascender.UseVisualStyleBackColor = true;
            this.rescueascender.CheckedChanged += new EventHandler(this.rescueascender_CheckedChanged);
            this.openascendform.Location = new System.Drawing.Point(36, 37);
            this.openascendform.Name = "openascendform";
            this.openascendform.Size = new Size(148, 32);
            this.openascendform.TabIndex = 13;
            this.openascendform.Text = "Ascension Options";
            this.openascendform.UseVisualStyleBackColor = true;
            this.openascendform.Click += new EventHandler(this.openascendform_Click);
            this.assistonthischar.AutoSize = true;
            this.assistonthischar.Location = new System.Drawing.Point(36, 12);
            this.assistonthischar.Name = "assistonthischar";
            this.assistonthischar.Size = new Size(194, 19);
            this.assistonthischar.TabIndex = 12;
            this.assistonthischar.Text = "Automatically assist (prayer etc)";
            this.assistonthischar.UseVisualStyleBackColor = true;
            this.assistonthischar.CheckedChanged += new EventHandler(this.assistonthischar_CheckedChanged);
            this.groupBox26.Controls.Add((Control)this.prayernecklist);
            this.groupBox26.Controls.Add((Control)this.groupBox47);
            this.groupBox26.Controls.Add((Control)this.praybutton);
            this.groupBox26.Controls.Add((Control)this.prayerassistant);
            this.groupBox26.Controls.Add((Control)this.useprayassistant);
            this.groupBox26.Controls.Add((Control)this.praytemple);
            this.groupBox26.Controls.Add((Control)this.praynecklace);
            this.groupBox26.Location = new System.Drawing.Point(302, 171);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new Size(314, 187);
            this.groupBox26.TabIndex = 11;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Pray";
            this.prayernecklist.DropDownStyle = ComboBoxStyle.DropDownList;
            this.prayernecklist.FormattingEnabled = true;
            this.prayernecklist.Location = new System.Drawing.Point(54, 20);
            this.prayernecklist.Name = "prayernecklist";
            this.prayernecklist.Size = new Size(186, 23);
            this.prayernecklist.TabIndex = 8;
            this.prayernecklist.Tag = (object)"Fiosachd Prayer Necklace";
            this.prayernecklist.SelectedIndexChanged += new EventHandler(this.prayernecklist_SelectedIndexChanged);
            this.groupBox47.Controls.Add((Control)this.prayxytext);
            this.groupBox47.Controls.Add((Control)this.prayxy);
            this.groupBox47.Controls.Add((Control)this.prayhere);
            this.groupBox47.Location = new System.Drawing.Point(10, 103);
            this.groupBox47.Name = "groupBox47";
            this.groupBox47.Size = new Size(144, 79);
            this.groupBox47.TabIndex = 7;
            this.groupBox47.TabStop = false;
            this.prayxytext.Enabled = false;
            this.prayxytext.Location = new System.Drawing.Point(56, 45);
            this.prayxytext.Name = "prayxytext";
            this.prayxytext.Size = new Size(69, 23);
            this.prayxytext.TabIndex = 2;
            this.prayxy.AutoSize = true;
            this.prayxy.Enabled = false;
            this.prayxy.Location = new System.Drawing.Point(9, 46);
            this.prayxy.Name = "prayxy";
            this.prayxy.Size = new Size(42, 19);
            this.prayxy.TabIndex = 1;
            this.prayxy.TabStop = true;
            this.prayxy.Text = "x,y:";
            this.prayxy.UseVisualStyleBackColor = true;
            this.prayhere.AutoSize = true;
            this.prayhere.Enabled = false;
            this.prayhere.Location = new System.Drawing.Point(9, 20);
            this.prayhere.Name = "prayhere";
            this.prayhere.Size = new Size(107, 19);
            this.prayhere.TabIndex = 0;
            this.prayhere.TabStop = true;
            this.prayhere.Text = "here (cast spell)";
            this.prayhere.UseVisualStyleBackColor = true;
            this.praybutton.Location = new System.Drawing.Point(175, 141);
            this.praybutton.Name = "praybutton";
            this.praybutton.Size = new Size(90, 33);
            this.praybutton.TabIndex = 6;
            this.praybutton.Text = "Start";
            this.praybutton.UseVisualStyleBackColor = true;
            this.praybutton.TextChanged += new EventHandler(this.praybutton_TextChanged);
            this.praybutton.Click += new EventHandler(this.praybutton_Click);
            this.prayerassistant.Location = new System.Drawing.Point(140, 74);
            this.prayerassistant.MaxLength = 15;
            this.prayerassistant.Name = "prayerassistant";
            this.prayerassistant.Size = new Size(100, 23);
            this.prayerassistant.TabIndex = 5;
            this.useprayassistant.AutoSize = true;
            this.useprayassistant.Location = new System.Drawing.Point(37, 76);
            this.useprayassistant.Name = "useprayassistant";
            this.useprayassistant.Size = new Size(93, 19);
            this.useprayassistant.TabIndex = 4;
            this.useprayassistant.Text = "Use assistant";
            this.useprayassistant.UseVisualStyleBackColor = true;
            this.praytemple.AutoSize = true;
            this.praytemple.Location = new System.Drawing.Point(150, 49);
            this.praytemple.Name = "praytemple";
            this.praytemple.Size = new Size(101, 19);
            this.praytemple.TabIndex = 1;
            this.praytemple.TabStop = true;
            this.praytemple.Text = "Temple prayer";
            this.praytemple.UseVisualStyleBackColor = true;
            this.praytemple.CheckedChanged += new EventHandler(this.praytemple_CheckedChanged);
            this.praynecklace.AutoSize = true;
            this.praynecklace.Location = new System.Drawing.Point(17, 49);
            this.praynecklace.Name = "praynecklace";
            this.praynecklace.Size = new Size(104, 19);
            this.praynecklace.TabIndex = 0;
            this.praynecklace.TabStop = true;
            this.praynecklace.Text = "Pray with Neck";
            this.praynecklace.UseVisualStyleBackColor = true;
            this.praynecklace.CheckedChanged += new EventHandler(this.praynecklace_CheckedChanged);
            this.groupBox24.Controls.Add((Control)this.labordays);
            this.groupBox24.Controls.Add((Control)this.label26);
            this.groupBox24.Controls.Add((Control)this.laborinresponsetext);
            this.groupBox24.Controls.Add((Control)this.laborinresponse);
            this.groupBox24.Controls.Add((Control)this.laborlogoff);
            this.groupBox24.Controls.Add((Control)this.laborwhispertext);
            this.groupBox24.Controls.Add((Control)this.laborwhisper);
            this.groupBox24.Controls.Add((Control)this.laborbutton);
            this.groupBox24.Controls.Add((Control)this.laborname);
            this.groupBox24.Location = new System.Drawing.Point(302, 12);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new Size(314, 151);
            this.groupBox24.TabIndex = 10;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Labor this character";
            this.labordays.Location = new System.Drawing.Point(252, 94);
            this.labordays.Maximum = new Decimal(new int[4]
            {
        6,
        0,
        0,
        0
            });
            this.labordays.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.labordays.Name = "labordays";
            this.labordays.Size = new Size(32, 23);
            this.labordays.TabIndex = 11;
            this.labordays.TextAlign = HorizontalAlignment.Center;
            this.labordays.Value = new Decimal(new int[4]
            {
        6,
        0,
        0,
        0
            });
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(238, 75);
            this.label26.Name = "label26";
            this.label26.Size = new Size(59, 15);
            this.label26.TabIndex = 10;
            this.label26.Text = "# of Days:";
            this.laborinresponsetext.Location = new System.Drawing.Point(165, 69);
            this.laborinresponsetext.Name = "laborinresponsetext";
            this.laborinresponsetext.Size = new Size(41, 23);
            this.laborinresponsetext.TabIndex = 9;
            this.laborinresponsetext.Text = "k";
            this.laborinresponse.AutoSize = true;
            this.laborinresponse.Checked = true;
            this.laborinresponse.CheckState = CheckState.Checked;
            this.laborinresponse.Location = new System.Drawing.Point(20, 71);
            this.laborinresponse.Name = "laborinresponse";
            this.laborinresponse.Size = new Size(136, 19);
            this.laborinresponse.TabIndex = 8;
            this.laborinresponse.Text = "Labor in response to:";
            this.laborinresponse.UseVisualStyleBackColor = true;
            this.laborlogoff.AutoSize = true;
            this.laborlogoff.Checked = true;
            this.laborlogoff.CheckState = CheckState.Checked;
            this.laborlogoff.Location = new System.Drawing.Point(20, 125);
            this.laborlogoff.Name = "laborlogoff";
            this.laborlogoff.Size = new Size(161, 19);
            this.laborlogoff.TabIndex = 7;
            this.laborlogoff.Text = "Log off when out of labor";
            this.laborlogoff.UseVisualStyleBackColor = true;
            this.laborwhispertext.Location = new System.Drawing.Point(165, 96);
            this.laborwhispertext.Name = "laborwhispertext";
            this.laborwhispertext.Size = new Size(41, 23);
            this.laborwhispertext.TabIndex = 6;
            this.laborwhispertext.Text = "k";
            this.laborwhisper.AutoSize = true;
            this.laborwhisper.Checked = true;
            this.laborwhisper.CheckState = CheckState.Checked;
            this.laborwhisper.Location = new System.Drawing.Point(20, 98);
            this.laborwhisper.Name = "laborwhisper";
            this.laborwhisper.Size = new Size(134, 19);
            this.laborwhisper.TabIndex = 5;
            this.laborwhisper.Text = "Whisper when done:";
            this.laborwhisper.UseVisualStyleBackColor = true;
            this.laborbutton.Location = new System.Drawing.Point(172, 25);
            this.laborbutton.Name = "laborbutton";
            this.laborbutton.Size = new Size(90, 33);
            this.laborbutton.TabIndex = 4;
            this.laborbutton.Text = "Start";
            this.laborbutton.UseVisualStyleBackColor = true;
            this.laborbutton.TextChanged += new EventHandler(this.laborbutton_TextChanged);
            this.laborbutton.Click += new EventHandler(this.laborbutton_Click);
            this.laborname.Location = new System.Drawing.Point(16, 29);
            this.laborname.MaxLength = 15;
            this.laborname.Name = "laborname";
            this.laborname.Size = new Size(121, 23);
            this.laborname.TabIndex = 1;
            this.groupBox25.Controls.Add((Control)this.requestlabormessagetext);
            this.groupBox25.Controls.Add((Control)this.label48);
            this.groupBox25.Controls.Add((Control)this.requestlabornametext);
            this.groupBox25.Controls.Add((Control)this.requestlabor);
            this.groupBox25.Controls.Add((Control)this.impskillinresponsetext);
            this.groupBox25.Controls.Add((Control)this.impskillinresponse);
            this.groupBox25.Controls.Add((Control)this.impskillbutton);
            this.groupBox25.Controls.Add((Control)this.skillassistant);
            this.groupBox25.Controls.Add((Control)this.useskillassistant);
            this.groupBox25.Controls.Add((Control)this.improveskill);
            this.groupBox25.Location = new System.Drawing.Point(19, 157);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new Size(277, 201);
            this.groupBox25.TabIndex = 9;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Improve profession";
            this.requestlabormessagetext.Location = new System.Drawing.Point(147, 165);
            this.requestlabormessagetext.Name = "requestlabormessagetext";
            this.requestlabormessagetext.Size = new Size(100, 23);
            this.requestlabormessagetext.TabIndex = 9;
            this.requestlabormessagetext.Text = "k";
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(109, 168);
            this.label48.Name = "label48";
            this.label48.Size = new Size(33, 15);
            this.label48.TabIndex = 8;
            this.label48.Text = "with:";
            this.requestlabornametext.Location = new System.Drawing.Point(147, 138);
            this.requestlabornametext.Name = "requestlabornametext";
            this.requestlabornametext.Size = new Size(100, 23);
            this.requestlabornametext.TabIndex = 7;
            this.requestlabor.AutoSize = true;
            this.requestlabor.Checked = true;
            this.requestlabor.CheckState = CheckState.Checked;
            this.requestlabor.Location = new System.Drawing.Point(6, 140);
            this.requestlabor.Name = "requestlabor";
            this.requestlabor.Size = new Size(130, 19);
            this.requestlabor.TabIndex = 6;
            this.requestlabor.Text = "Request labor from:";
            this.requestlabor.UseVisualStyleBackColor = true;
            this.impskillinresponsetext.Location = new System.Drawing.Point(163, 106);
            this.impskillinresponsetext.Name = "impskillinresponsetext";
            this.impskillinresponsetext.Size = new Size(83, 23);
            this.impskillinresponsetext.TabIndex = 5;
            this.impskillinresponsetext.Text = "k";
            this.impskillinresponse.AutoSize = true;
            this.impskillinresponse.Checked = true;
            this.impskillinresponse.CheckState = CheckState.Checked;
            this.impskillinresponse.Location = new System.Drawing.Point(6, 108);
            this.impskillinresponse.Name = "impskillinresponse";
            this.impskillinresponse.Size = new Size(142, 19);
            this.impskillinresponse.TabIndex = 4;
            this.impskillinresponse.Text = "Restart in response to:";
            this.impskillinresponse.UseVisualStyleBackColor = true;
            this.impskillbutton.Location = new System.Drawing.Point(70, 78);
            this.impskillbutton.Name = "impskillbutton";
            this.impskillbutton.Size = new Size(78, 24);
            this.impskillbutton.TabIndex = 3;
            this.impskillbutton.Text = "Start";
            this.impskillbutton.UseVisualStyleBackColor = true;
            this.impskillbutton.TextChanged += new EventHandler(this.impskillbutton_TextChanged);
            this.impskillbutton.Click += new EventHandler(this.impskillbutton_Click);
            this.skillassistant.Location = new System.Drawing.Point(132, 51);
            this.skillassistant.MaxLength = 15;
            this.skillassistant.Name = "skillassistant";
            this.skillassistant.Size = new Size(100, 23);
            this.skillassistant.TabIndex = 2;
            this.useskillassistant.AutoSize = true;
            this.useskillassistant.Location = new System.Drawing.Point(9, 53);
            this.useskillassistant.Name = "useskillassistant";
            this.useskillassistant.Size = new Size(93, 19);
            this.useskillassistant.TabIndex = 1;
            this.useskillassistant.Text = "Use assistant";
            this.useskillassistant.UseVisualStyleBackColor = true;
            this.improveskill.DropDownStyle = ComboBoxStyle.DropDownList;
            this.improveskill.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.improveskill.FormattingEnabled = true;
            this.improveskill.Items.AddRange(new object[11]
            {
        (object) "Tailoring (cowl)",
        (object) "Tailoring",
        (object) "Gem Polishing",
        (object) "Blade Smith",
        (object) "Herbalist",
        (object) "Herbalist (hydele)",
        (object) "Herbalist (betony)",
        (object) "Herbalist (personaca)",
        (object) "Wizardry Researcher",
        (object) "Elementalist",
        (object) "Mentor (rucesion)"
            });
            this.improveskill.Location = new System.Drawing.Point(70, 22);
            this.improveskill.Name = "improveskill";
            this.improveskill.Size = new Size(162, 23);
            this.improveskill.TabIndex = 0;
            this.tabPage1.Controls.Add((Control)this.studycreaturetxt);
            this.tabPage1.Controls.Add((Control)this.legendopen);
            this.tabPage1.Controls.Add((Control)this.disablesnow);
            this.tabPage1.Controls.Add((Control)this.enterbugs);
            this.tabPage1.Controls.Add((Control)this.all5classes);
            this.tabPage1.Controls.Add((Control)this.altar);
            this.tabPage1.Controls.Add((Control)this.chattimestamp);
            this.tabPage1.Controls.Add((Control)this.openswapform);
            this.tabPage1.Controls.Add((Control)this.monitords);
            this.tabPage1.Controls.Add((Control)this.tradeincostumes);
            this.tabPage1.Controls.Add((Control)this.useskillbonus);
            this.tabPage1.Controls.Add((Control)this.disableitemsnstuff);
            this.tabPage1.Controls.Add((Control)this.openarenaform);
            this.tabPage1.Controls.Add((Control)this.clickladder);
            this.tabPage1.Controls.Add((Control)this.recorditemdata);
            this.tabPage1.Controls.Add((Control)this.opencomboform);
            this.tabPage1.Controls.Add((Control)this.openmacroform);
            this.tabPage1.Controls.Add((Control)this.dojo);
            this.tabPage1.Controls.Add((Control)this.friendspeak);
            this.tabPage1.Controls.Add((Control)this.autobuyhems);
            this.tabPage1.Controls.Add((Control)this.autobuykoms);
            this.tabPage1.Controls.Add((Control)this.safemode);
            this.tabPage1.Controls.Add((Control)this.slash_commands);
            this.tabPage1.Controls.Add((Control)this.disableallbody);
            this.tabPage1.Controls.Add((Control)this.disableallspell);
            this.tabPage1.Controls.Add((Control)this.monitorspells);
            this.tabPage1.Controls.Add((Control)this.monitorcurses);
            this.tabPage1.Controls.Add((Control)this.monitordion);
            this.tabPage1.Controls.Add((Control)this.noblind);
            this.tabPage1.Controls.Add((Control)this.seeinvis);
            this.tabPage1.Controls.Add((Control)this.nowalls);
            this.tabPage1.Controls.Add((Control)this.usemonsterid);
            this.tabPage1.Controls.Add((Control)this.usemonster);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(634, 377);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Misc.";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.studycreaturetxt.AutoSize = true;
            this.studycreaturetxt.Location = new System.Drawing.Point(502, 339);
            this.studycreaturetxt.Name = "studycreaturetxt";
            this.studycreaturetxt.Size = new Size(114, 19);
            this.studycreaturetxt.TabIndex = 95;
            this.studycreaturetxt.Text = "studycreature.txt";
            this.studycreaturetxt.UseVisualStyleBackColor = true;
            this.legendopen.Location = new System.Drawing.Point(286, 238);
            this.legendopen.Name = "legendopen";
            this.legendopen.Size = new Size(111, 23);
            this.legendopen.TabIndex = 94;
            this.legendopen.Text = "Legend Checklist";
            this.legendopen.UseVisualStyleBackColor = true;
            this.legendopen.Click += new EventHandler(this.legendopen_Click);
            this.disablesnow.AutoSize = true;
            this.disablesnow.Location = new System.Drawing.Point(140, 96);
            this.disablesnow.Name = "disablesnow";
            this.disablesnow.Size = new Size(96, 19);
            this.disablesnow.TabIndex = 93;
            this.disablesnow.Text = "Disable Snow";
            this.disablesnow.UseVisualStyleBackColor = true;
            this.enterbugs.AutoSize = true;
            this.enterbugs.Location = new System.Drawing.Point(33, 348);
            this.enterbugs.Name = "enterbugs";
            this.enterbugs.Size = new Size(169, 19);
            this.enterbugs.TabIndex = 92;
            this.enterbugs.Text = "Re-enter Insect Event maps";
            this.enterbugs.UseVisualStyleBackColor = true;
            this.all5classes.AutoSize = true;
            this.all5classes.Location = new System.Drawing.Point(301, 339);
            this.all5classes.Name = "all5classes";
            this.all5classes.Size = new Size(145, 19);
            this.all5classes.TabIndex = 91;
            this.all5classes.Text = "save to 5 class data file";
            this.all5classes.UseVisualStyleBackColor = true;
            this.altar.AutoSize = true;
            this.altar.Location = new System.Drawing.Point(286, 271);
            this.altar.Name = "altar";
            this.altar.Size = new Size(196, 19);
            this.altar.TabIndex = 90;
            this.altar.Text = "Drop Wine in Altar every 3 hours";
            this.altar.UseVisualStyleBackColor = true;
            this.chattimestamp.AutoSize = true;
            this.chattimestamp.Location = new System.Drawing.Point(286, 208);
            this.chattimestamp.Name = "chattimestamp";
            this.chattimestamp.Size = new Size(111, 19);
            this.chattimestamp.TabIndex = 89;
            this.chattimestamp.Text = "Chat timestamp";
            this.chattimestamp.UseVisualStyleBackColor = true;
            this.openswapform.Location = new System.Drawing.Point(455, 233);
            this.openswapform.Name = "openswapform";
            this.openswapform.Size = new Size(117, 32);
            this.openswapform.TabIndex = 88;
            this.openswapform.Text = "Swap Skills/Spells";
            this.openswapform.UseVisualStyleBackColor = true;
            this.openswapform.Click += new EventHandler(this.openswapform_Click);
            this.monitords.AutoSize = true;
            this.monitords.Location = new System.Drawing.Point(286, 71);
            this.monitords.Name = "monitords";
            this.monitords.Size = new Size(107, 19);
            this.monitords.TabIndex = 87;
            this.monitords.Text = "DS/DS2 Tracker";
            this.monitords.UseVisualStyleBackColor = true;
            this.monitords.CheckedChanged += new EventHandler(this.monitords_CheckedChanged);
            this.tradeincostumes.AutoSize = true;
            this.tradeincostumes.Location = new System.Drawing.Point(286, 296);
            this.tradeincostumes.Name = "tradeincostumes";
            this.tradeincostumes.Size = new Size(289, 19);
            this.tradeincostumes.TabIndex = 86;
            this.tradeincostumes.Text = "Trade in Event Costumes for War Bags (abel bank)";
            this.tradeincostumes.UseVisualStyleBackColor = true;
            this.useskillbonus.AutoSize = true;
            this.useskillbonus.Location = new System.Drawing.Point(286, 183);
            this.useskillbonus.Name = "useskillbonus";
            this.useskillbonus.Size = new Size(159, 19);
            this.useskillbonus.TabIndex = 85;
            this.useskillbonus.Text = "Use Skill/Spell Imp Bonus";
            this.useskillbonus.UseVisualStyleBackColor = true;
            this.disableitemsnstuff.AutoSize = true;
            this.disableitemsnstuff.Location = new System.Drawing.Point(33, 171);
            this.disableitemsnstuff.Name = "disableitemsnstuff";
            this.disableitemsnstuff.Size = new Size(214, 19);
            this.disableitemsnstuff.TabIndex = 84;
            this.disableitemsnstuff.Text = "Disable Everyones Body Animations";
            this.disableitemsnstuff.UseVisualStyleBackColor = true;
            this.openarenaform.Location = new System.Drawing.Point(455, 21);
            this.openarenaform.Name = "openarenaform";
            this.openarenaform.Size = new Size(117, 33);
            this.openarenaform.TabIndex = 83;
            this.openarenaform.Text = "Arena Counter";
            this.openarenaform.UseVisualStyleBackColor = true;
            this.openarenaform.Click += new EventHandler(this.openarenaform_Click);
            this.clickladder.AutoSize = true;
            this.clickladder.Location = new System.Drawing.Point(286, 121);
            this.clickladder.Name = "clickladder";
            this.clickladder.Size = new Size(139, 19);
            this.clickladder.TabIndex = 82;
            this.clickladder.Text = "Click Ladder in Castle";
            this.clickladder.UseVisualStyleBackColor = true;
            this.recorditemdata.AutoSize = true;
            this.recorditemdata.Location = new System.Drawing.Point(286, 323);
            this.recorditemdata.Name = "recorditemdata";
            this.recorditemdata.Size = new Size(303, 19);
            this.recorditemdata.TabIndex = 81;
            this.recorditemdata.Text = "Record All Item Drops (dont bother using this, folks!)";
            this.recorditemdata.UseVisualStyleBackColor = true;
            this.recorditemdata.CheckedChanged += new EventHandler(this.recorditemdata_CheckedChanged);
            this.opencomboform.Location = new System.Drawing.Point(455, 88);
            this.opencomboform.Name = "opencomboform";
            this.opencomboform.Size = new Size(117, 32);
            this.opencomboform.TabIndex = 80;
            this.opencomboform.Text = "Combo Options";
            this.opencomboform.UseVisualStyleBackColor = true;
            this.opencomboform.Click += new EventHandler(this.opencomboform_Click);
            this.openmacroform.Location = new System.Drawing.Point(455, 163);
            this.openmacroform.Name = "openmacroform";
            this.openmacroform.Size = new Size(117, 32);
            this.openmacroform.TabIndex = 79;
            this.openmacroform.Text = "Macro Options";
            this.openmacroform.UseVisualStyleBackColor = true;
            this.openmacroform.Click += new EventHandler(this.openmacroform_Click);
            this.dojo.AutoSize = true;
            this.dojo.Location = new System.Drawing.Point(286, 158);
            this.dojo.Name = "dojo";
            this.dojo.Size = new Size(146, 19);
            this.dojo.TabIndex = 68;
            this.dojo.Text = "Re-enter Training Dojo";
            this.dojo.UseVisualStyleBackColor = true;
            this.dojo.CheckedChanged += new EventHandler(this.dojo_CheckedChanged);
            this.friendspeak.AutoSize = true;
            this.friendspeak.Location = new System.Drawing.Point(33, 271);
            this.friendspeak.Name = "friendspeak";
            this.friendspeak.Size = new Size(211, 19);
            this.friendspeak.TabIndex = 64;
            this.friendspeak.Text = "Allow friends to speak through you";
            this.toolTip1.SetToolTip((Control)this.friendspeak, "To have a friend speak through you,\r\nthey must whisper you text starting with 'say'\r\nexample; friend whispers you 'say hello mr ranger!'\r\nyou say outloud 'hello mr ranger!'");
            this.friendspeak.UseVisualStyleBackColor = true;
            this.friendspeak.CheckedChanged += new EventHandler(this.friendspeak_CheckedChanged);
            this.autobuyhems.AutoSize = true;
            this.autobuyhems.Location = new System.Drawing.Point(33, 246);
            this.autobuyhems.Name = "autobuyhems";
            this.autobuyhems.Size = new Size(179, 19);
            this.autobuyhems.TabIndex = 63;
            this.autobuyhems.Text = "Auto buy hemlochs in Noam";
            this.autobuyhems.UseVisualStyleBackColor = true;
            this.autobuyhems.CheckedChanged += new EventHandler(this.autobuyhems_CheckedChanged);
            this.autobuykoms.AutoSize = true;
            this.autobuykoms.Checked = true;
            this.autobuykoms.CheckState = CheckState.Checked;
            this.autobuykoms.Location = new System.Drawing.Point(33, 221);
            this.autobuykoms.Name = "autobuykoms";
            this.autobuykoms.Size = new Size(149, 19);
            this.autobuykoms.TabIndex = 62;
            this.autobuykoms.Text = "Auto buy reds in Noam";
            this.autobuykoms.UseVisualStyleBackColor = true;
            this.autobuykoms.CheckedChanged += new EventHandler(this.autobuykoms_CheckedChanged);
            this.safemode.AutoSize = true;
            this.safemode.Location = new System.Drawing.Point(32, 308);
            this.safemode.Name = "safemode";
            this.safemode.Size = new Size(170, 19);
            this.safemode.TabIndex = 18;
            this.safemode.Text = "Safe Mode (/safe to toggle)";
            this.toolTip1.SetToolTip((Control)this.safemode, "this will toggle all 'hax' and program messages,\r\nas well as hides the program on the desktop.\r\n(making it safe to take a screenshot to show\r\nother people somethin)");
            this.safemode.UseVisualStyleBackColor = true;
            this.safemode.CheckedChanged += new EventHandler(this.safemode_CheckedChanged);
            this.slash_commands.AutoSize = true;
            this.slash_commands.Checked = true;
            this.slash_commands.CheckState = CheckState.Checked;
            this.slash_commands.Location = new System.Drawing.Point(33, 196);
            this.slash_commands.Name = "slash_commands";
            this.slash_commands.Size = new Size(140, 19);
            this.slash_commands.TabIndex = 17;
            this.slash_commands.Text = "Enable '/' Commands";
            this.slash_commands.UseVisualStyleBackColor = true;
            this.slash_commands.CheckedChanged += new EventHandler(this.Slash_commands_CheckedChanged);
            this.disableallbody.AutoSize = true;
            this.disableallbody.Location = new System.Drawing.Point(33, 146);
            this.disableallbody.Name = "disableallbody";
            this.disableallbody.Size = new Size(186, 19);
            this.disableallbody.TabIndex = 16;
            this.disableallbody.Text = "Disable Your Body Animations";
            this.disableallbody.UseVisualStyleBackColor = true;
            this.disableallbody.CheckedChanged += new EventHandler(this.Disableallbody_CheckedChanged);
            this.disableallspell.AutoSize = true;
            this.disableallspell.Location = new System.Drawing.Point(33, 121);
            this.disableallspell.Name = "disableallspell";
            this.disableallspell.Size = new Size(156, 19);
            this.disableallspell.TabIndex = 15;
            this.disableallspell.Text = "Disable Spell Animations";
            this.disableallspell.UseVisualStyleBackColor = true;
            this.disableallspell.CheckedChanged += new EventHandler(this.disableallspell_CheckedChanged);
            this.monitorspells.AutoSize = true;
            this.monitorspells.Location = new System.Drawing.Point(286, 96);
            this.monitorspells.Name = "monitorspells";
            this.monitorspells.Size = new Size(111, 19);
            this.monitorspells.TabIndex = 14;
            this.monitorspells.Text = "Aite/Fas Tracker";
            this.monitorspells.UseVisualStyleBackColor = true;
            this.monitorspells.CheckedChanged += new EventHandler(this.monitorspells_CheckedChanged);
            this.monitorcurses.AutoSize = true;
            this.monitorcurses.Location = new System.Drawing.Point(286, 46);
            this.monitorcurses.Name = "monitorcurses";
            this.monitorcurses.Size = new Size(118, 19);
            this.monitorcurses.TabIndex = 13;
            this.monitorcurses.Text = "ard cradh Tracker";
            this.monitorcurses.UseVisualStyleBackColor = true;
            this.monitorcurses.CheckedChanged += new EventHandler(this.monitorcurses_CheckedChanged);
            this.monitordion.AutoSize = true;
            this.monitordion.Location = new System.Drawing.Point(286, 21);
            this.monitordion.Name = "monitordion";
            this.monitordion.Size = new Size(85, 19);
            this.monitordion.TabIndex = 12;
            this.monitordion.Text = "Dion Timer";
            this.monitordion.UseVisualStyleBackColor = true;
            this.monitordion.CheckedChanged += new EventHandler(this.monitordion_CheckedChanged);
            this.noblind.AutoSize = true;
            this.noblind.Checked = true;
            this.noblind.CheckState = CheckState.Checked;
            this.noblind.Location = new System.Drawing.Point(33, 96);
            this.noblind.Name = "noblind";
            this.noblind.Size = new Size(72, 19);
            this.noblind.TabIndex = 11;
            this.noblind.Text = "No Blind";
            this.noblind.UseVisualStyleBackColor = true;
            this.noblind.CheckedChanged += new EventHandler(this.noblind_CheckedChanged);
            this.seeinvis.AutoSize = true;
            this.seeinvis.Checked = true;
            this.seeinvis.CheckState = CheckState.Checked;
            this.seeinvis.Location = new System.Drawing.Point(33, 71);
            this.seeinvis.Name = "seeinvis";
            this.seeinvis.Size = new Size(71, 19);
            this.seeinvis.TabIndex = 10;
            this.seeinvis.Text = "See Invis";
            this.seeinvis.UseVisualStyleBackColor = true;
            this.seeinvis.CheckedChanged += new EventHandler(this.seeinvis_CheckedChanged);
            this.nowalls.AutoSize = true;
            this.nowalls.Location = new System.Drawing.Point(33, 46);
            this.nowalls.Name = "nowalls";
            this.nowalls.Size = new Size(73, 19);
            this.nowalls.TabIndex = 9;
            this.nowalls.Text = "No Walls";
            this.nowalls.UseVisualStyleBackColor = true;
            this.nowalls.CheckedChanged += new EventHandler(this.nowalls_CheckedChanged);
            this.usemonsterid.Location = new System.Drawing.Point(140, 20);
            this.usemonsterid.Maximum = new Decimal(new int[4]
            {
        999,
        0,
        0,
        0
            });
            this.usemonsterid.Name = "usemonsterid";
            this.usemonsterid.Size = new Size(57, 23);
            this.usemonsterid.TabIndex = 8;
            this.usemonsterid.TextAlign = HorizontalAlignment.Right;
            this.usemonsterid.Value = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.usemonsterid.ValueChanged += new EventHandler(this.usemonsterform_CheckedChanged);
            this.tabPage5.Controls.Add((Control)this.groupBox3);
            this.tabPage5.Controls.Add((Control)this.groupBox5);
            this.tabPage5.Controls.Add((Control)this.groupBox21);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new Padding(3);
            this.tabPage5.Size = new Size(634, 377);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Settings";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.groupBox3.Controls.Add((Control)this.currenttemplateupdated);
            this.groupBox3.Controls.Add((Control)this.updatecurrent);
            this.groupBox3.Controls.Add((Control)this.loadedtemplate);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(263, 143);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Template";
            this.currenttemplateupdated.AutoSize = true;
            this.currenttemplateupdated.ForeColor = SystemColors.Highlight;
            this.currenttemplateupdated.Location = new System.Drawing.Point(78, 102);
            this.currenttemplateupdated.Name = "currenttemplateupdated";
            this.currenttemplateupdated.Size = new Size(107, 15);
            this.currenttemplateupdated.TabIndex = 2;
            this.currenttemplateupdated.Text = "Template updated.";
            this.currenttemplateupdated.Visible = false;
            this.updatecurrent.Location = new System.Drawing.Point(47, 61);
            this.updatecurrent.Name = "updatecurrent";
            this.updatecurrent.Size = new Size(169, 24);
            this.updatecurrent.TabIndex = 1;
            this.updatecurrent.Text = "Save Settings as Current";
            this.updatecurrent.UseVisualStyleBackColor = true;
            this.updatecurrent.Click += new EventHandler(this.updatecurrent_Click);
            this.loadedtemplate.AutoSize = true;
            this.loadedtemplate.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.loadedtemplate.ForeColor = SystemColors.Highlight;
            this.loadedtemplate.Location = new System.Drawing.Point(105, 28);
            this.loadedtemplate.Name = "loadedtemplate";
            this.loadedtemplate.Size = new Size(46, 15);
            this.loadedtemplate.TabIndex = 0;
            this.loadedtemplate.Text = "default";
            this.groupBox5.Controls.Add((Control)this.templatedeleted);
            this.groupBox5.Controls.Add((Control)this.templateupdated2);
            this.groupBox5.Controls.Add((Control)this.loaddefault);
            this.groupBox5.Controls.Add((Control)this.template_loaded_message);
            this.groupBox5.Controls.Add((Control)this.delete_template);
            this.groupBox5.Controls.Add((Control)this.loadtemplate);
            this.groupBox5.Controls.Add((Control)this.template_lists);
            this.groupBox5.Location = new System.Drawing.Point(297, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(319, 358);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Existing Templates";
            this.templatedeleted.AutoSize = true;
            this.templatedeleted.ForeColor = Color.Maroon;
            this.templatedeleted.Location = new System.Drawing.Point(16, 28);
            this.templatedeleted.Name = "templatedeleted";
            this.templatedeleted.Size = new Size(49, 15);
            this.templatedeleted.TabIndex = 6;
            this.templatedeleted.Text = "deleted.";
            this.templatedeleted.Visible = false;
            this.templateupdated2.AutoSize = true;
            this.templateupdated2.ForeColor = SystemColors.MenuHighlight;
            this.templateupdated2.Location = new System.Drawing.Point(16, 28);
            this.templateupdated2.Name = "templateupdated2";
            this.templateupdated2.Size = new Size(107, 15);
            this.templateupdated2.TabIndex = 5;
            this.templateupdated2.Text = "Template updated.";
            this.templateupdated2.Visible = false;
            this.loaddefault.Location = new System.Drawing.Point(180, 132);
            this.loaddefault.Name = "loaddefault";
            this.loaddefault.Size = new Size(122, 30);
            this.loaddefault.TabIndex = 4;
            this.loaddefault.Text = "Load Default";
            this.loaddefault.UseVisualStyleBackColor = true;
            this.loaddefault.Click += new EventHandler(this.loaddefault_Click);
            this.template_loaded_message.AutoSize = true;
            this.template_loaded_message.ForeColor = SystemColors.MenuHighlight;
            this.template_loaded_message.Location = new System.Drawing.Point(16, 28);
            this.template_loaded_message.Name = "template_loaded_message";
            this.template_loaded_message.Size = new Size(99, 15);
            this.template_loaded_message.TabIndex = 3;
            this.template_loaded_message.Text = "Template loaded.";
            this.template_loaded_message.Visible = false;
            this.delete_template.Enabled = false;
            this.delete_template.Location = new System.Drawing.Point(180, 264);
            this.delete_template.Name = "delete_template";
            this.delete_template.Size = new Size(122, 30);
            this.delete_template.TabIndex = 2;
            this.delete_template.Text = "Delete Selected";
            this.delete_template.UseVisualStyleBackColor = true;
            this.delete_template.Click += new EventHandler(this.delete_template_Click);
            this.loadtemplate.BackColor = Color.Transparent;
            this.loadtemplate.Enabled = false;
            this.loadtemplate.Location = new System.Drawing.Point(180, 61);
            this.loadtemplate.Name = "loadtemplate";
            this.loadtemplate.Size = new Size(122, 30);
            this.loadtemplate.TabIndex = 1;
            this.loadtemplate.Text = "Load Selected";
            this.loadtemplate.UseVisualStyleBackColor = false;
            this.loadtemplate.Click += new EventHandler(this.loadtemplate_Click);
            this.template_lists.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.template_lists.FormattingEnabled = true;
            this.template_lists.ItemHeight = 15;
            this.template_lists.Location = new System.Drawing.Point(10, 58);
            this.template_lists.Name = "template_lists";
            this.template_lists.ScrollAlwaysVisible = true;
            this.template_lists.Size = new Size(153, 289);
            this.template_lists.TabIndex = 0;
            this.template_lists.SelectedIndexChanged += new EventHandler(this.template_lists_SelectedIndexChanged);
            this.groupBox21.Controls.Add((Control)this.templatesaved);
            this.groupBox21.Controls.Add((Control)this.newtemplate_error);
            this.groupBox21.Controls.Add((Control)this.newtemplate_save);
            this.groupBox21.Controls.Add((Control)this.label22);
            this.groupBox21.Controls.Add((Control)this.newtemplate_name);
            this.groupBox21.Location = new System.Drawing.Point(8, 186);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new Size(263, 172);
            this.groupBox21.TabIndex = 12;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "New Template";
            this.templatesaved.AutoSize = true;
            this.templatesaved.ForeColor = SystemColors.MenuHighlight;
            this.templatesaved.Location = new System.Drawing.Point(78, 130);
            this.templatesaved.Name = "templatesaved";
            this.templatesaved.Size = new Size(102, 15);
            this.templatesaved.TabIndex = 9;
            this.templatesaved.Text = "Template created.";
            this.templatesaved.Visible = false;
            this.newtemplate_error.AutoSize = true;
            this.newtemplate_error.ForeColor = Color.Maroon;
            this.newtemplate_error.Location = new System.Drawing.Point(63, 130);
            this.newtemplate_error.Name = "newtemplate_error";
            this.newtemplate_error.Size = new Size(131, 15);
            this.newtemplate_error.TabIndex = 8;
            this.newtemplate_error.Text = "Error in template name.";
            this.newtemplate_error.Visible = false;
            this.newtemplate_save.Location = new System.Drawing.Point(42, 81);
            this.newtemplate_save.Name = "newtemplate_save";
            this.newtemplate_save.Size = new Size(174, 33);
            this.newtemplate_save.TabIndex = 7;
            this.newtemplate_save.Text = "Save Settings as Template";
            this.newtemplate_save.UseVisualStyleBackColor = true;
            this.newtemplate_save.Click += new EventHandler(this.newtemplate_save_Click);
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(29, 42);
            this.label22.Name = "label22";
            this.label22.Size = new Size(95, 15);
            this.label22.TabIndex = 6;
            this.label22.Text = "Template Name:";
            this.newtemplate_name.Font = new Font("Arial", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.newtemplate_name.Location = new System.Drawing.Point((int)sbyte.MaxValue, 39);
            this.newtemplate_name.MaxLength = 20;
            this.newtemplate_name.Name = "newtemplate_name";
            this.newtemplate_name.Size = new Size(103, 21);
            this.newtemplate_name.TabIndex = 5;
            this.newtemplate_name.KeyPress += new KeyPressEventHandler(this.newtemplate_name_KeyPress);
            this.tabPage13.Controls.Add((Control)this.groupBox14);
            this.tabPage13.Controls.Add((Control)this.groupBox12);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new Size(634, 377);
            this.tabPage13.TabIndex = 10;
            this.tabPage13.Text = "Realistic";
            this.tabPage13.UseVisualStyleBackColor = true;
            this.groupBox14.Controls.Add((Control)this.label9);
            this.groupBox14.Controls.Add((Control)this.label8);
            this.groupBox14.Controls.Add((Control)this.label21);
            this.groupBox14.Controls.Add((Control)this.reactdelaya);
            this.groupBox14.Controls.Add((Control)this.switchtargetdelayb);
            this.groupBox14.Controls.Add((Control)this.label11);
            this.groupBox14.Controls.Add((Control)this.label18);
            this.groupBox14.Controls.Add((Control)this.label12);
            this.groupBox14.Controls.Add((Control)this.switchtargetdelaya);
            this.groupBox14.Controls.Add((Control)this.lootdelaya);
            this.groupBox14.Controls.Add((Control)this.label20);
            this.groupBox14.Controls.Add((Control)this.label13);
            this.groupBox14.Controls.Add((Control)this.label17);
            this.groupBox14.Controls.Add((Control)this.lootdelayb);
            this.groupBox14.Controls.Add((Control)this.newtargetdelayb);
            this.groupBox14.Controls.Add((Control)this.label14);
            this.groupBox14.Controls.Add((Control)this.label15);
            this.groupBox14.Controls.Add((Control)this.reactdelayb);
            this.groupBox14.Controls.Add((Control)this.newtargetdelaya);
            this.groupBox14.Controls.Add((Control)this.label16);
            this.groupBox14.Location = new System.Drawing.Point(152, 18);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new Size(333, 321);
            this.groupBox14.TabIndex = 21;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "'Realistic' casting near non-friends";
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 19);
            this.label9.Name = "label9";
            this.label9.Size = new Size(304, 45);
            this.label9.TabIndex = 1;
            this.label9.Text = "all delays are in milliseconds, these delays DO NOT SAVE\r\nlet me know if you have a better delay time suggestion\r\nand i'll change the default values.";
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 101);
            this.label8.Name = "label8";
            this.label8.Size = new Size(116, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "delay before casting:";
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(27, 248);
            this.label21.Name = "label21";
            this.label21.Size = new Size(155, 15);
            this.label21.TabIndex = 19;
            this.label21.Text = "(applies to 0 line spells only)";
            this.reactdelaya.Location = new System.Drawing.Point(136, 99);
            this.reactdelaya.Maximum = new Decimal(new int[4]
            {
        10000,
        0,
        0,
        0
            });
            this.reactdelaya.Name = "reactdelaya";
            this.reactdelaya.Size = new Size(61, 23);
            this.reactdelaya.TabIndex = 2;
            this.reactdelaya.Value = new Decimal(new int[4]
            {
        800,
        0,
        0,
        0
            });
            this.switchtargetdelayb.Location = new System.Drawing.Point(220, 222);
            this.switchtargetdelayb.Maximum = new Decimal(new int[4]
            {
        10000,
        0,
        0,
        0
            });
            this.switchtargetdelayb.Name = "switchtargetdelayb";
            this.switchtargetdelayb.Size = new Size(61, 23);
            this.switchtargetdelayb.TabIndex = 18;
            this.switchtargetdelayb.Value = new Decimal(new int[4]
            {
        1200,
        0,
        0,
        0
            });
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 125);
            this.label11.Name = "label11";
            this.label11.Size = new Size(301, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "heals, ao suain, ao poison, ao dall, ao cradhs, ao trinkets";
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(196, 224);
            this.label18.Name = "label18";
            this.label18.Size = new Size(18, 15);
            this.label18.TabIndex = 17;
            this.label18.Text = "to";
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 289);
            this.label12.Name = "label12";
            this.label12.Size = new Size(116, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "delay before looting:";
            this.switchtargetdelaya.Location = new System.Drawing.Point(129, 222);
            this.switchtargetdelaya.Maximum = new Decimal(new int[4]
            {
        10000,
        0,
        0,
        0
            });
            this.switchtargetdelaya.Name = "switchtargetdelaya";
            this.switchtargetdelaya.Size = new Size(61, 23);
            this.switchtargetdelaya.TabIndex = 16;
            this.switchtargetdelaya.Value = new Decimal(new int[4]
            {
        700,
        0,
        0,
        0
            });
            this.lootdelaya.Location = new System.Drawing.Point(136, 287);
            this.lootdelaya.Maximum = new Decimal(new int[4]
            {
        10000,
        0,
        0,
        0
            });
            this.lootdelaya.Name = "lootdelaya";
            this.lootdelaya.Size = new Size(61, 23);
            this.lootdelaya.TabIndex = 5;
            this.lootdelaya.Value = new Decimal(new int[4]
            {
        800,
        0,
        0,
        0
            });
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 224);
            this.label20.Name = "label20";
            this.label20.Size = new Size(109, 15);
            this.label20.TabIndex = 15;
            this.label20.Text = "target switch delay:";
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(203, 289);
            this.label13.Name = "label13";
            this.label13.Size = new Size(18, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "to";
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(27, 188);
            this.label17.Name = "label17";
            this.label17.Size = new Size(211, 15);
            this.label17.TabIndex = 14;
            this.label17.Text = "(when a monster first spawns/appears)";
            this.lootdelayb.Location = new System.Drawing.Point(227, 287);
            this.lootdelayb.Maximum = new Decimal(new int[4]
            {
        10000,
        0,
        0,
        0
            });
            this.lootdelayb.Name = "lootdelayb";
            this.lootdelayb.Size = new Size(61, 23);
            this.lootdelayb.TabIndex = 7;
            this.lootdelayb.Value = new Decimal(new int[4]
            {
        1750,
        0,
        0,
        0
            });
            this.newtargetdelayb.Location = new System.Drawing.Point(244, 162);
            this.newtargetdelayb.Maximum = new Decimal(new int[4]
            {
        10000,
        0,
        0,
        0
            });
            this.newtargetdelayb.Name = "newtargetdelayb";
            this.newtargetdelayb.Size = new Size(61, 23);
            this.newtargetdelayb.TabIndex = 13;
            this.newtargetdelayb.Value = new Decimal(new int[4]
            {
        3000,
        0,
        0,
        0
            });
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(203, 101);
            this.label14.Name = "label14";
            this.label14.Size = new Size(18, 15);
            this.label14.TabIndex = 8;
            this.label14.Text = "to";
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(220, 164);
            this.label15.Name = "label15";
            this.label15.Size = new Size(18, 15);
            this.label15.TabIndex = 12;
            this.label15.Text = "to";
            this.reactdelayb.Location = new System.Drawing.Point(227, 99);
            this.reactdelayb.Maximum = new Decimal(new int[4]
            {
        10000,
        0,
        0,
        0
            });
            this.reactdelayb.Name = "reactdelayb";
            this.reactdelayb.Size = new Size(61, 23);
            this.reactdelayb.TabIndex = 9;
            this.reactdelayb.Value = new Decimal(new int[4]
            {
        1750,
        0,
        0,
        0
            });
            this.newtargetdelaya.Location = new System.Drawing.Point(153, 162);
            this.newtargetdelaya.Maximum = new Decimal(new int[4]
            {
        10000,
        0,
        0,
        0
            });
            this.newtargetdelaya.Name = "newtargetdelaya";
            this.newtargetdelaya.Size = new Size(61, 23);
            this.newtargetdelaya.TabIndex = 11;
            this.newtargetdelaya.Value = new Decimal(new int[4]
            {
        1500,
        0,
        0,
        0
            });
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 164);
            this.label16.Name = "label16";
            this.label16.Size = new Size(133, 15);
            this.label16.TabIndex = 10;
            this.label16.Text = "newly seen target delay:";
            this.groupBox12.Controls.Add((Control)this.checkBox4);
            this.groupBox12.Controls.Add((Control)this.checkBox3);
            this.groupBox12.Controls.Add((Control)this.checkBox2);
            this.groupBox12.Controls.Add((Control)this.checkBox1);
            this.groupBox12.Location = new System.Drawing.Point(8, 18);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new Size(183, 162);
            this.groupBox12.TabIndex = 20;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Stop casting near non-friends";
            this.groupBox12.Visible = false;
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(21, 119);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new Size(93, 19);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "fas monsters";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(21, 94);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new Size(106, 19);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "curse monsters";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(21, 57);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(81, 19);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "fas players";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(21, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(50, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "aites";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.tabPage14.Controls.Add((Control)this.scriptida);
            this.tabPage14.Controls.Add((Control)this.beadummy);
            this.tabPage14.Controls.Add((Control)this.recordmaps);
            this.tabPage14.Controls.Add((Control)this.label41);
            this.tabPage14.Controls.Add((Control)this.label40);
            this.tabPage14.Controls.Add((Control)this.itemColor);
            this.tabPage14.Controls.Add((Control)this.itemNum);
            this.tabPage14.Controls.Add((Control)this.getrealnames);
            this.tabPage14.Controls.Add((Control)this.getmonsterid2);
            this.tabPage14.Controls.Add((Control)this.groupBox10);
            this.tabPage14.Controls.Add((Control)this.label37);
            this.tabPage14.Controls.Add((Control)this.drophaxtxt);
            this.tabPage14.Controls.Add((Control)this.label36);
            this.tabPage14.Controls.Add((Control)this.drophaxnpcid);
            this.tabPage14.Controls.Add((Control)this.drophaxbtn);
            this.tabPage14.Controls.Add((Control)this.npcid);
            this.tabPage14.Controls.Add((Control)this.label34);
            this.tabPage14.Controls.Add((Control)this.label33);
            this.tabPage14.Controls.Add((Control)this.scriptidb);
            this.tabPage14.Controls.Add((Control)this.button2);
            this.tabPage14.Controls.Add((Control)this.groupBox6);
            this.tabPage14.Controls.Add((Control)this.groupBox31);
            this.tabPage14.Controls.Add((Control)this.spellaninum);
            this.tabPage14.Controls.Add((Control)this.label6);
            this.tabPage14.Controls.Add((Control)this.testnum);
            this.tabPage14.Controls.Add((Control)this.button1);
            this.tabPage14.Location = new System.Drawing.Point(4, 24);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new Padding(3);
            this.tabPage14.Size = new Size(634, 375);
            this.tabPage14.TabIndex = 11;
            this.tabPage14.Text = "Test";
            this.tabPage14.UseVisualStyleBackColor = true;
            this.beadummy.AutoSize = true;
            this.beadummy.Location = new System.Drawing.Point(227, 188);
            this.beadummy.Name = "beadummy";
            this.beadummy.Size = new Size(141, 19);
            this.beadummy.TabIndex = 109;
            this.beadummy.Text = "Be a Training Dummy";
            this.beadummy.UseVisualStyleBackColor = true;
            this.recordmaps.AutoSize = true;
            this.recordmaps.Location = new System.Drawing.Point(227, 150);
            this.recordmaps.Name = "recordmaps";
            this.recordmaps.Size = new Size(148, 19);
            this.recordmaps.TabIndex = 108;
            this.recordmaps.Text = "record map/portal/npc";
            this.recordmaps.UseVisualStyleBackColor = true;
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(338, 316);
            this.label41.Name = "label41";
            this.label41.Size = new Size(34, 15);
            this.label41.TabIndex = 107;
            this.label41.Text = "color";
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(215, 338);
            this.label40.Name = "label40";
            this.label40.Size = new Size(57, 15);
            this.label40.TabIndex = 106;
            this.label40.Text = "ItemSlot1";
            this.itemColor.Location = new System.Drawing.Point(334, 333);
            this.itemColor.Maximum = new Decimal(new int[4]
            {
        (int) byte.MaxValue,
        0,
        0,
        0
            });
            this.itemColor.Name = "itemColor";
            this.itemColor.Size = new Size(50, 23);
            this.itemColor.TabIndex = 105;
            this.itemColor.ValueChanged += new EventHandler(this.itemNum_ValueChanged);
            this.itemNum.Location = new System.Drawing.Point(278, 333);
            this.itemNum.Maximum = new Decimal(new int[4]
            {
        60000,
        0,
        0,
        0
            });
            this.itemNum.Name = "itemNum";
            this.itemNum.Size = new Size(50, 23);
            this.itemNum.TabIndex = 104;
            this.itemNum.ValueChanged += new EventHandler(this.itemNum_ValueChanged);
            this.getrealnames.AutoSize = true;
            this.getrealnames.Location = new System.Drawing.Point(227, 227);
            this.getrealnames.Name = "getrealnames";
            this.getrealnames.Size = new Size(179, 19);
            this.getrealnames.TabIndex = 103;
            this.getrealnames.Text = "Get real names upon clicking";
            this.getrealnames.UseVisualStyleBackColor = true;
            this.getmonsterid2.AutoSize = true;
            this.getmonsterid2.Location = new System.Drawing.Point(227, 21);
            this.getmonsterid2.Name = "getmonsterid2";
            this.getmonsterid2.Size = new Size(206, 19);
            this.getmonsterid2.TabIndex = 102;
            this.getmonsterid2.Text = "Get monster id (click the monster)";
            this.getmonsterid2.UseVisualStyleBackColor = true;
            this.getmonsterid2.CheckedChanged += new EventHandler(this.getmonsterid2_CheckedChanged);
            this.groupBox10.Controls.Add((Control)this.togglehaxloop);
            this.groupBox10.Controls.Add((Control)this.haxtimenum);
            this.groupBox10.Controls.Add((Control)this.label35);
            this.groupBox10.Controls.Add((Control)this.trashorbs);
            this.groupBox10.Location = new System.Drawing.Point(489, 79);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new Size(130, 104);
            this.groupBox10.TabIndex = 101;
            this.groupBox10.TabStop = false;
            this.togglehaxloop.Location = new System.Drawing.Point(40, 44);
            this.togglehaxloop.Name = "togglehaxloop";
            this.togglehaxloop.Size = new Size(75, 23);
            this.togglehaxloop.TabIndex = 92;
            this.togglehaxloop.Text = "start";
            this.togglehaxloop.UseVisualStyleBackColor = true;
            this.togglehaxloop.Click += new EventHandler(this.togglehaxloop_Click);
            this.haxtimenum.Location = new System.Drawing.Point(66, 71);
            this.haxtimenum.Maximum = new Decimal(new int[4]
            {
        60,
        0,
        0,
        0
            });
            this.haxtimenum.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.haxtimenum.Name = "haxtimenum";
            this.haxtimenum.Size = new Size(49, 23);
            this.haxtimenum.TabIndex = 93;
            this.haxtimenum.Value = new Decimal(new int[4]
            {
        5,
        0,
        0,
        0
            });
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(10, 73);
            this.label35.Name = "label35";
            this.label35.Size = new Size(50, 15);
            this.label35.TabIndex = 94;
            this.label35.Text = "seconds";
            this.trashorbs.AutoSize = true;
            this.trashorbs.Location = new System.Drawing.Point(40, 18);
            this.trashorbs.Name = "trashorbs";
            this.trashorbs.Size = new Size(52, 19);
            this.trashorbs.TabIndex = 95;
            this.trashorbs.Text = "trash";
            this.trashorbs.UseVisualStyleBackColor = true;
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(224, 98);
            this.label37.Name = "label37";
            this.label37.Size = new Size(64, 15);
            this.label37.TabIndex = 100;
            this.label37.Text = "item name";
            this.drophaxtxt.Location = new System.Drawing.Point(227, 74);
            this.drophaxtxt.Name = "drophaxtxt";
            this.drophaxtxt.Size = new Size(108, 23);
            this.drophaxtxt.TabIndex = 99;
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(233, 48);
            this.label36.Name = "label36";
            this.label36.Size = new Size(45, 15);
            this.label36.TabIndex = 98;
            this.label36.Text = "mon id";
            this.drophaxnpcid.Location = new System.Drawing.Point(284, 46);
            this.drophaxnpcid.Maximum = new Decimal(new int[4]
            {
        -294967296,
        0,
        0,
        0
            });
            this.drophaxnpcid.Name = "drophaxnpcid";
            this.drophaxnpcid.Size = new Size(61, 23);
            this.drophaxnpcid.TabIndex = 97;
            this.drophaxbtn.Location = new System.Drawing.Point(341, 76);
            this.drophaxbtn.Name = "drophaxbtn";
            this.drophaxbtn.Size = new Size(59, 23);
            this.drophaxbtn.TabIndex = 96;
            this.drophaxbtn.Text = "drop";
            this.drophaxbtn.UseVisualStyleBackColor = true;
            this.drophaxbtn.Click += new EventHandler(this.drophaxbtn_Click);
            this.npcid.Location = new System.Drawing.Point(521, 184);
            this.npcid.Maximum = new Decimal(new int[4]
            {
        -294967296,
        0,
        0,
        0
            });
            this.npcid.Name = "npcid";
            this.npcid.Size = new Size(95, 23);
            this.npcid.TabIndex = 91;
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(435, 221);
            this.label34.Name = "label34";
            this.label34.Size = new Size(46, 15);
            this.label34.TabIndex = 88;
            this.label34.Text = "scriptid";
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(478, 186);
            this.label33.Name = "label33";
            this.label33.Size = new Size(37, 15);
            this.label33.TabIndex = 87;
            this.label33.Text = "npcid";
            this.scriptidb.Location = new System.Drawing.Point(555, 219);
            this.scriptidb.Maximum = new Decimal(new int[4]
            {
        60000,
        0,
        0,
        0
            });
            this.scriptidb.Name = "scriptidb";
            this.scriptidb.Size = new Size(62, 23);
            this.scriptidb.TabIndex = 86;
            this.button2.Location = new System.Drawing.Point(522, 250);
            this.button2.Name = "button2";
            this.button2.Size = new Size(94, 23);
            this.button2.TabIndex = 85;
            this.button2.Text = "send 0x39";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.groupBox6.Controls.Add((Control)this.button4);
            this.groupBox6.Controls.Add((Control)this.DAid1);
            this.groupBox6.Controls.Add((Control)this.p4);
            this.groupBox6.Controls.Add((Control)this.DAid2);
            this.groupBox6.Location = new System.Drawing.Point(405, 281);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(220, 84);
            this.groupBox6.TabIndex = 84;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dark Artifact Search";
            this.button4.Location = new System.Drawing.Point(125, 25);
            this.button4.Name = "button4";
            this.button4.Size = new Size(89, 23);
            this.button4.TabIndex = 75;
            this.button4.Text = "search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.DAid1.Location = new System.Drawing.Point(5, 25);
            this.DAid1.Name = "DAid1";
            this.DAid1.Size = new Size(54, 23);
            this.DAid1.TabIndex = 72;
            this.DAid1.Text = "50000";
            this.p4.Location = new System.Drawing.Point(41, 54);
            this.p4.Name = "p4";
            this.p4.Size = new Size(68, 23);
            this.p4.TabIndex = 74;
            this.DAid2.Location = new System.Drawing.Point(65, 26);
            this.DAid2.Name = "DAid2";
            this.DAid2.Size = new Size(54, 23);
            this.DAid2.TabIndex = 73;
            this.DAid2.Text = "150000";
            this.groupBox31.Controls.Add((Control)this.duunknown2);
            this.groupBox31.Controls.Add((Control)this.duovercoatcolor);
            this.groupBox31.Controls.Add((Control)this.duacc3color);
            this.groupBox31.Controls.Add((Control)this.duacc3num);
            this.groupBox31.Controls.Add((Control)this.duacc3);
            this.groupBox31.Controls.Add((Control)this.duovercoatnum);
            this.groupBox31.Controls.Add((Control)this.duovercoat);
            this.groupBox31.Controls.Add((Control)this.label23);
            this.groupBox31.Controls.Add((Control)this.duacc2color);
            this.groupBox31.Controls.Add((Control)this.duacc1color);
            this.groupBox31.Controls.Add((Control)this.dubootcolor);
            this.groupBox31.Controls.Add((Control)this.duhatcolor);
            this.groupBox31.Controls.Add((Control)this.label24);
            this.groupBox31.Controls.Add((Control)this.dupantsnum);
            this.groupBox31.Controls.Add((Control)this.dupants);
            this.groupBox31.Controls.Add((Control)this.duacc2num);
            this.groupBox31.Controls.Add((Control)this.duacc1num);
            this.groupBox31.Controls.Add((Control)this.duacc2);
            this.groupBox31.Controls.Add((Control)this.duacc1);
            this.groupBox31.Controls.Add((Control)this.duskinnum);
            this.groupBox31.Controls.Add((Control)this.dufacenum);
            this.groupBox31.Controls.Add((Control)this.duskin);
            this.groupBox31.Controls.Add((Control)this.duface);
            this.groupBox31.Controls.Add((Control)this.dubootsnum);
            this.groupBox31.Controls.Add((Control)this.duarmornum);
            this.groupBox31.Controls.Add((Control)this.duweaponnum);
            this.groupBox31.Controls.Add((Control)this.dushieldnum);
            this.groupBox31.Controls.Add((Control)this.duhatnum);
            this.groupBox31.Controls.Add((Control)this.duboots);
            this.groupBox31.Controls.Add((Control)this.dushield);
            this.groupBox31.Controls.Add((Control)this.duweapon);
            this.groupBox31.Controls.Add((Control)this.duarmor);
            this.groupBox31.Controls.Add((Control)this.duhat);
            this.groupBox31.Location = new System.Drawing.Point(8, 15);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new Size(201, 352);
            this.groupBox31.TabIndex = 83;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Dress Up";
            this.duunknown2.Location = new System.Drawing.Point(142, 186);
            this.duunknown2.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duunknown2.Name = "duunknown2";
            this.duunknown2.Size = new Size(49, 23);
            this.duunknown2.TabIndex = 47;
            this.duunknown2.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duovercoatcolor.Location = new System.Drawing.Point(142, 159);
            this.duovercoatcolor.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duovercoatcolor.Name = "duovercoatcolor";
            this.duovercoatcolor.Size = new Size(49, 23);
            this.duovercoatcolor.TabIndex = 46;
            this.duovercoatcolor.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duacc3color.Location = new System.Drawing.Point(142, 318);
            this.duacc3color.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duacc3color.Name = "duacc3color";
            this.duacc3color.Size = new Size(49, 23);
            this.duacc3color.TabIndex = 45;
            this.duacc3color.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duacc3num.Location = new System.Drawing.Point(87, 317);
            this.duacc3num.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duacc3num.Name = "duacc3num";
            this.duacc3num.Size = new Size(49, 23);
            this.duacc3num.TabIndex = 44;
            this.duacc3num.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duacc3.AutoSize = true;
            this.duacc3.Location = new System.Drawing.Point(6, 318);
            this.duacc3.Name = "duacc3";
            this.duacc3.Size = new Size(55, 19);
            this.duacc3.TabIndex = 43;
            this.duacc3.Text = "Acc 3";
            this.duacc3.UseVisualStyleBackColor = true;
            this.duacc3.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duovercoatnum.Location = new System.Drawing.Point(87, 159);
            this.duovercoatnum.Maximum = new Decimal(new int[4]
            {
        2000,
        0,
        0,
        0
            });
            this.duovercoatnum.Name = "duovercoatnum";
            this.duovercoatnum.Size = new Size(49, 23);
            this.duovercoatnum.TabIndex = 39;
            this.duovercoatnum.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duovercoat.AutoSize = true;
            this.duovercoat.Location = new System.Drawing.Point(6, 159);
            this.duovercoat.Name = "duovercoat";
            this.duovercoat.Size = new Size(74, 19);
            this.duovercoat.TabIndex = 38;
            this.duovercoat.Text = "Overcoat";
            this.duovercoat.UseVisualStyleBackColor = true;
            this.duovercoat.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.label23.AutoSize = true;
            this.label23.ForeColor = SystemColors.ControlDarkDark;
            this.label23.Location = new System.Drawing.Point(90, 13);
            this.label23.Name = "label23";
            this.label23.Size = new Size(36, 15);
            this.label23.TabIndex = 37;
            this.label23.Text = "Value";
            this.duacc2color.Location = new System.Drawing.Point(142, 293);
            this.duacc2color.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duacc2color.Name = "duacc2color";
            this.duacc2color.Size = new Size(49, 23);
            this.duacc2color.TabIndex = 36;
            this.duacc2color.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duacc1color.Location = new System.Drawing.Point(142, 266);
            this.duacc1color.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duacc1color.Name = "duacc1color";
            this.duacc1color.Size = new Size(49, 23);
            this.duacc1color.TabIndex = 34;
            this.duacc1color.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.dubootcolor.Location = new System.Drawing.Point(142, 239);
            this.dubootcolor.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.dubootcolor.Name = "dubootcolor";
            this.dubootcolor.Size = new Size(49, 23);
            this.dubootcolor.TabIndex = 32;
            this.dubootcolor.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duhatcolor.Location = new System.Drawing.Point(142, 134);
            this.duhatcolor.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duhatcolor.Name = "duhatcolor";
            this.duhatcolor.Size = new Size(49, 23);
            this.duhatcolor.TabIndex = 26;
            this.duhatcolor.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.label24.AutoSize = true;
            this.label24.ForeColor = SystemColors.ControlDarkDark;
            this.label24.Location = new System.Drawing.Point(145, 13);
            this.label24.Name = "label24";
            this.label24.Size = new Size(36, 15);
            this.label24.TabIndex = 25;
            this.label24.Text = "Color";
            this.dupantsnum.Location = new System.Drawing.Point(87, 212);
            this.dupantsnum.Maximum = new Decimal(new int[4]
            {
        2000,
        0,
        0,
        0
            });
            this.dupantsnum.Name = "dupantsnum";
            this.dupantsnum.Size = new Size(49, 23);
            this.dupantsnum.TabIndex = 24;
            this.dupantsnum.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.dupants.AutoSize = true;
            this.dupants.Location = new System.Drawing.Point(6, 213);
            this.dupants.Name = "dupants";
            this.dupants.Size = new Size(54, 19);
            this.dupants.TabIndex = 23;
            this.dupants.Text = "Arms";
            this.dupants.UseVisualStyleBackColor = true;
            this.dupants.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duacc2num.Location = new System.Drawing.Point(87, 292);
            this.duacc2num.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duacc2num.Name = "duacc2num";
            this.duacc2num.Size = new Size(49, 23);
            this.duacc2num.TabIndex = 22;
            this.duacc2num.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duacc1num.Location = new System.Drawing.Point(87, 265);
            this.duacc1num.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duacc1num.Name = "duacc1num";
            this.duacc1num.Size = new Size(49, 23);
            this.duacc1num.TabIndex = 19;
            this.duacc1num.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duacc2.AutoSize = true;
            this.duacc2.Location = new System.Drawing.Point(6, 293);
            this.duacc2.Name = "duacc2";
            this.duacc2.Size = new Size(55, 19);
            this.duacc2.TabIndex = 15;
            this.duacc2.Text = "Acc 2";
            this.duacc2.UseVisualStyleBackColor = true;
            this.duacc2.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duacc1.AutoSize = true;
            this.duacc1.Location = new System.Drawing.Point(6, 266);
            this.duacc1.Name = "duacc1";
            this.duacc1.Size = new Size(55, 19);
            this.duacc1.TabIndex = 14;
            this.duacc1.Text = "Acc 1";
            this.duacc1.UseVisualStyleBackColor = true;
            this.duacc1.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duskinnum.Location = new System.Drawing.Point(87, 56);
            this.duskinnum.Maximum = new Decimal(new int[4]
            {
        (int) byte.MaxValue,
        0,
        0,
        0
            });
            this.duskinnum.Name = "duskinnum";
            this.duskinnum.Size = new Size(49, 23);
            this.duskinnum.TabIndex = 13;
            this.duskinnum.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.dufacenum.Location = new System.Drawing.Point(87, 31);
            this.dufacenum.Maximum = new Decimal(new int[4]
            {
        (int) byte.MaxValue,
        0,
        0,
        0
            });
            this.dufacenum.Name = "dufacenum";
            this.dufacenum.Size = new Size(49, 23);
            this.dufacenum.TabIndex = 12;
            this.dufacenum.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duskin.AutoSize = true;
            this.duskin.Location = new System.Drawing.Point(6, 57);
            this.duskin.Name = "duskin";
            this.duskin.Size = new Size(78, 19);
            this.duskin.TabIndex = 11;
            this.duskin.Text = "Skin color";
            this.duskin.UseVisualStyleBackColor = true;
            this.duskin.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duface.AutoSize = true;
            this.duface.Location = new System.Drawing.Point(6, 32);
            this.duface.Name = "duface";
            this.duface.Size = new Size(50, 19);
            this.duface.TabIndex = 10;
            this.duface.Text = "Face";
            this.duface.UseVisualStyleBackColor = true;
            this.duface.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.dubootsnum.Location = new System.Drawing.Point(87, 239);
            this.dubootsnum.Maximum = new Decimal(new int[4]
            {
        (int) byte.MaxValue,
        0,
        0,
        0
            });
            this.dubootsnum.Name = "dubootsnum";
            this.dubootsnum.Size = new Size(49, 23);
            this.dubootsnum.TabIndex = 9;
            this.dubootsnum.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duarmornum.Location = new System.Drawing.Point(87, 185);
            this.duarmornum.Maximum = new Decimal(new int[4]
            {
        2000,
        0,
        0,
        0
            });
            this.duarmornum.Name = "duarmornum";
            this.duarmornum.Size = new Size(49, 23);
            this.duarmornum.TabIndex = 8;
            this.duarmornum.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duweaponnum.Location = new System.Drawing.Point(87, 83);
            this.duweaponnum.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duweaponnum.Name = "duweaponnum";
            this.duweaponnum.Size = new Size(49, 23);
            this.duweaponnum.TabIndex = 7;
            this.duweaponnum.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.dushieldnum.Location = new System.Drawing.Point(87, 108);
            this.dushieldnum.Maximum = new Decimal(new int[4]
            {
        (int) byte.MaxValue,
        0,
        0,
        0
            });
            this.dushieldnum.Name = "dushieldnum";
            this.dushieldnum.Size = new Size(49, 23);
            this.dushieldnum.TabIndex = 6;
            this.dushieldnum.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duhatnum.Location = new System.Drawing.Point(87, 133);
            this.duhatnum.Maximum = new Decimal(new int[4]
            {
        1000,
        0,
        0,
        0
            });
            this.duhatnum.Name = "duhatnum";
            this.duhatnum.Size = new Size(49, 23);
            this.duhatnum.TabIndex = 5;
            this.duhatnum.ValueChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duboots.AutoSize = true;
            this.duboots.Location = new System.Drawing.Point(6, 239);
            this.duboots.Name = "duboots";
            this.duboots.Size = new Size(56, 19);
            this.duboots.TabIndex = 4;
            this.duboots.Text = "Boots";
            this.duboots.UseVisualStyleBackColor = true;
            this.duboots.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.dushield.AutoSize = true;
            this.dushield.Location = new System.Drawing.Point(6, 109);
            this.dushield.Name = "dushield";
            this.dushield.Size = new Size(58, 19);
            this.dushield.TabIndex = 3;
            this.dushield.Text = "Shield";
            this.dushield.UseVisualStyleBackColor = true;
            this.dushield.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duweapon.AutoSize = true;
            this.duweapon.Location = new System.Drawing.Point(6, 84);
            this.duweapon.Name = "duweapon";
            this.duweapon.Size = new Size(70, 19);
            this.duweapon.TabIndex = 2;
            this.duweapon.Text = "Weapon";
            this.duweapon.UseVisualStyleBackColor = true;
            this.duweapon.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duarmor.AutoSize = true;
            this.duarmor.Location = new System.Drawing.Point(6, 186);
            this.duarmor.Name = "duarmor";
            this.duarmor.Size = new Size(60, 19);
            this.duarmor.TabIndex = 1;
            this.duarmor.Text = "Armor";
            this.duarmor.UseVisualStyleBackColor = true;
            this.duarmor.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.duhat.AutoSize = true;
            this.duhat.Location = new System.Drawing.Point(6, 134);
            this.duhat.Name = "duhat";
            this.duhat.Size = new Size(45, 19);
            this.duhat.TabIndex = 0;
            this.duhat.Text = "Hat";
            this.duhat.UseVisualStyleBackColor = true;
            this.duhat.CheckedChanged += new EventHandler(this.duarmor_CheckedChanged);
            this.spellaninum.Location = new System.Drawing.Point(540, 57);
            this.spellaninum.Maximum = new Decimal(new int[4]
            {
        10000,
        0,
        0,
        0
            });
            this.spellaninum.Name = "spellaninum";
            this.spellaninum.Size = new Size(66, 23);
            this.spellaninum.TabIndex = 82;
            this.spellaninum.ValueChanged += new EventHandler(this.spellaninum_ValueChanged);
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(438, 59);
            this.label6.Name = "label6";
            this.label6.Size = new Size(96, 15);
            this.label6.TabIndex = 81;
            this.label6.Text = "Spell Animations";
            this.testnum.Location = new System.Drawing.Point(540, 28);
            this.testnum.Maximum = new Decimal(new int[4]
            {
        100000,
        0,
        0,
        0
            });
            this.testnum.Name = "testnum";
            this.testnum.Size = new Size(60, 23);
            this.testnum.TabIndex = 80;
            this.testnum.ValueChanged += new EventHandler(this.testnum_ValueChanged);
            this.button1.Location = new System.Drawing.Point(456, 28);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 79;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.tabPage2.Controls.Add((Control)this.buttonRecv);
            this.tabPage2.Controls.Add((Control)this.buttonSend);
            this.tabPage2.Controls.Add((Control)this.textConsoleInput);
            this.tabPage2.Controls.Add((Control)this.checkRecv);
            this.tabPage2.Controls.Add((Control)this.checkSend);
            this.tabPage2.Controls.Add((Control)this.textConsoleOutput);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(634, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Packets";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new Size(24, 24);
            this.toolStrip1.Items.AddRange(new ToolStripItem[2]
            {
        (ToolStripItem) this.btnPlay,
        (ToolStripItem) this.btnStop
            });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(632, 31);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            this.btnPlay.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.btnPlay.Image = (Image)componentResourceManager.GetObject("btnPlay.Image");
            this.btnPlay.ImageTransparentColor = Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new Size(28, 28);
            this.btnPlay.CheckedChanged += new EventHandler(this.btnPlay_CheckedChanged);
            this.btnPlay.Click += new EventHandler(this.Play_Click);
            this.btnStop.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.btnStop.Enabled = false;
            this.btnStop.Image = (Image)componentResourceManager.GetObject("btnStop.Image");
            this.btnStop.ImageTransparentColor = Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new Size(28, 28);
            this.btnStop.Click += new EventHandler(this.Stop_Click);
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.Tag = (object)"";
            this.scriptida.Location = new System.Drawing.Point(487, 219);
            this.scriptida.Maximum = new Decimal(new int[4]
            {
        60000,
        0,
        0,
        0
            });
            this.scriptida.Name = "scriptida";
            this.scriptida.Size = new Size(62, 23);
            this.scriptida.TabIndex = 110;
            this.ClientSize = new Size(632, 428);
            this.Controls.Add((Control)this.toolStrip1);
            this.Controls.Add((Control)this.mainOptions);
            this.Controls.Add((Control)this.panel1);
            this.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.Name = nameof(ClientTab);
            this.Text = nameof(ClientTab);
            this.mainOptions.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.spellgroup.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.spellTargets.ResumeLayout(false);
            this.playertab.ResumeLayout(false);
            this.playertab.PerformLayout();
            this.group_dion.ResumeLayout(false);
            this.group_dion.PerformLayout();
            this.dion_enemiesonscreenvalue.EndInit();
            this.dion_enemiesnextcount.EndInit();
            this.dion_hpcond.EndInit();
            this.iocselfcond.EndInit();
            this.newTarget.ResumeLayout(false);
            this.newTarget.PerformLayout();
            this.monstertab.ResumeLayout(false);
            this.spellMonsters.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.brieshits.EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.skillgrouprangenum.EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.gbpurewar.ResumeLayout(false);
            this.gbpurewar.PerformLayout();
            this.pfmonsters.EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.potioncond.EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox46.ResumeLayout(false);
            this.groupBox46.PerformLayout();
            this.trinket_holder.ResumeLayout(false);
            this.trinket_holder.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox45.ResumeLayout(false);
            this.groupBox45.PerformLayout();
            this.nolongermobbed.EndInit();
            this.mobdistance.EndInit();
            this.mobsize.EndInit();
            this.groupBox16.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.requestflowercond.EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.followdist.EndInit();
            this.walksettings.EndInit();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.groupBox47.ResumeLayout(false);
            this.groupBox47.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.labordays.EndInit();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.usemonsterid.EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.tabPage13.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.reactdelaya.EndInit();
            this.switchtargetdelayb.EndInit();
            this.switchtargetdelaya.EndInit();
            this.lootdelaya.EndInit();
            this.lootdelayb.EndInit();
            this.newtargetdelayb.EndInit();
            this.reactdelayb.EndInit();
            this.newtargetdelaya.EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.itemColor.EndInit();
            this.itemNum.EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.haxtimenum.EndInit();
            this.drophaxnpcid.EndInit();
            this.npcid.EndInit();
            this.scriptidb.EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            this.duunknown2.EndInit();
            this.duovercoatcolor.EndInit();
            this.duacc3color.EndInit();
            this.duacc3num.EndInit();
            this.duovercoatnum.EndInit();
            this.duacc2color.EndInit();
            this.duacc1color.EndInit();
            this.dubootcolor.EndInit();
            this.duhatcolor.EndInit();
            this.dupantsnum.EndInit();
            this.duacc2num.EndInit();
            this.duacc1num.EndInit();
            this.duskinnum.EndInit();
            this.dufacenum.EndInit();
            this.dubootsnum.EndInit();
            this.duarmornum.EndInit();
            this.duweaponnum.EndInit();
            this.dushieldnum.EndInit();
            this.duhatnum.EndInit();
            this.spellaninum.EndInit();
            this.testnum.EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.scriptida.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public Client Client { get; set; }

        public ClientTab(Client client)
        {
            this.InitializeComponent();
            this.Client = client;
            this.newTarget.TabIndex = 2;
            this.Wayregion = new Wayregion(client);
            this.SkillSwap = new SkillSwap(client);
            this.LegendMarks = new LegendMarks(client);
            this.ArenaCounter = new ArenaCounter(client);
            this.HideTrinketOptions = new HideTrinketOptions(client);
            this.SpellPriority = new SpellPriority(client);
            this.MacroOptions = new MacroOptions(client);
            this.ComboOptions = new ComboOptions1(client);
            this.AscendOptions = new AscendOptions(client);
            this.ExternalChat = new ExternalChat(client);
            this.TemplateSaveTimer = new System.Windows.Forms.Timer();
            this.TemplateSaveTimer.Interval = 2100;
            this.TemplateSaveTimer.Tick += new EventHandler(this.TemplateSaveMessage_Opacity);
            this.calctimer = new System.Timers.Timer(20000.0);
            this.calctimer.Elapsed += new ElapsedEventHandler(this.Update_Calculator);
            this.lootlocale.SelectedIndex = 2;
            this.improveskill.SelectedIndex = 0;
            this.autowalker_locales.SelectedIndex = 0;
            if (Map.LoadSotp(Options.DarkAgesDirectoryName + "\\ia.dat"))
                return;
            int num = (int)MessageBox.Show("Dark Ages path is incorrect; map pathfinding functions will not work for this client.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Play_Click(object sender, EventArgs e)
        {
            this.btnPlay.Enabled = false;
            this.btnStop.Enabled = true;
            this.Client.pause = false;
            this.Client.lastaction = DateTime.UtcNow;
            this.Client.laststep = DateTime.UtcNow;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            this.btnPlay.Enabled = true;
            this.btnStop.Enabled = false;
            this.Client.pause = true;
            this.Client.lastaction = DateTime.UtcNow;
            this.Client.laststep = DateTime.UtcNow;
        }

        private void Slash_commands_CheckedChanged(object sender, EventArgs e)
        {
            this.vslash_commands = this.slash_commands.Checked;
        }

        private void Disableallbody_CheckedChanged(object sender, EventArgs e)
        {
            this.vdisableallbody = this.disableallbody.Checked;
        }

        private void disableallspell_CheckedChanged(object sender, EventArgs e)
        {
            this.vdisableallspell = this.disableallspell.Checked;
        }

        private void usemonsterform_CheckedChanged(object sender, EventArgs e)
        {
            this.vusemonster = this.usemonster.Checked;
            this.vusemonsterid = (int)this.usemonsterid.Value;
            if (!this.Client.Loaded)
                return;
            this.Client.UseMonsterForm();
        }

        private void nowalls_CheckedChanged(object sender, EventArgs e)
        {
            if (this.nowalls.Checked)
                this.Client.DisableWalls();
            else
                this.Client.EnableWalls();
            this.Client.Refresh();
        }

        private void seeinvis_CheckedChanged(object sender, EventArgs e)
        {
            this.Client.Refresh();
        }

        private void noblind_CheckedChanged(object sender, EventArgs e)
        {
            if (this.noblind.Checked)
                this.Client.DisableBlind();
            else
                this.Client.EnableBlind();
            this.Client.Refresh();
        }

        private void monitordion_CheckedChanged(object sender, EventArgs e)
        {
            this.vmonitordion = this.monitordion.Checked;
            lock (this.Client.Characters)
            {
                foreach (Character character in this.Client.Characters.Values.ToArray<Character>())
                {
                    if (character is Player && character.Name != this.Client.Name)
                        this.Client.UpdatePlayerImage(character as Player);
                }
            }
        }

        private void monitorcurses_CheckedChanged(object sender, EventArgs e)
        {
            this.vmonitorcurses = this.monitorcurses.Checked;
            lock (this.Client.Characters)
            {
                foreach (Character character in this.Client.Characters.Values.ToArray<Character>())
                {
                    if (character is Player && character.Name != this.Client.Name)
                        this.Client.UpdatePlayerImage(character as Player);
                }
            }
        }

        private void monitords_CheckedChanged(object sender, EventArgs e)
        {
            lock (this.Client.Characters)
            {
                foreach (Character character in this.Client.Characters.Values.ToArray<Character>())
                {
                    if (character is Player && character.Name != this.Client.Name)
                        this.Client.UpdatePlayerImage(character as Player);
                }
            }
        }

        private void monitorspells_CheckedChanged(object sender, EventArgs e)
        {
            this.vmonitorspells = this.monitorspells.Checked;
            lock (this.Client.Characters)
            {
                foreach (Character character in this.Client.Characters.Values.ToArray<Character>())
                {
                    if (character is Player && character.Name != this.Client.Name)
                        this.Client.UpdatePlayerImage(character as Player);
                }
            }
        }

        private void safemode_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.safemode.Checked)
                return;
            foreach (Client client in Server.Clients)
            {
                if (client != null)
                {
                    client.SendMessage("", (byte)18, false);
                    client.safemode = true;
                    client.DisableSeeInvis();
                    client.EnableWalls();
                    client.Refresh();
                }
            }
            User32.Hide();
        }

        private void friendspeak_CheckedChanged(object sender, EventArgs e)
        {
            this.vfriendspeak = this.friendspeak.Checked;
        }

        private void autobuyhems_CheckedChanged(object sender, EventArgs e)
        {
            this.vautobuyhems = this.autobuyhems.Checked;
            if (!this.autobuyhems.Checked || this.Client.DistanceFrom(this.Client.poiloc) >= 21 && this.Client.DistanceFrom(this.Client.muettaloc) >= 21 || this.Client.Statistics.Gold <= 500U)
                return;
            this.Client.BuyItem("Hemloch", 30U - this.Client.ItemCount("Hemloch"));
        }

        private void autobuykoms_CheckedChanged(object sender, EventArgs e)
        {
            this.vautobuykoms = this.autobuykoms.Checked;
            if (!this.autobuykoms.Checked || this.Client.DistanceFrom(this.Client.poiloc) >= 21 || this.Client.Statistics.Gold <= 1000U)
                return;
            this.Client.BuyItem("Komadium", 52U - this.Client.ItemCount("Komadium"));
        }

        private void dojo_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.dojo.Checked)
                return;
            this.autowalker_locales.SelectedItem = (object)"Mehadi";
            this.walklocaleslist.SelectedItem = (object)"Entrance";
            this.autowalker_button.Text = "Stop";
            this.Client.autowalkon = true;
            if (!this.Client.BotThread.IsAlive)
                this.Client.BotThread.Start();
            this.Client.pause = false;
            this.btnPlay.Enabled = false;
            this.btnStop.Enabled = true;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string text = this.textConsoleInput.Text;
            char[] separator1 = new char[2] { '\r', '\n' };
            foreach (string str1 in text.Split(separator1, StringSplitOptions.RemoveEmptyEntries))
            {
                ClientPacket msg = (ClientPacket)null;
                string str2 = str1;
                char[] separator2 = new char[1] { ' ' };
                foreach (string s in str2.Split(separator2, StringSplitOptions.RemoveEmptyEntries))
                {
                    byte result;
                    if (byte.TryParse(s, NumberStyles.HexNumber, (IFormatProvider)null, out result))
                    {
                        if (msg == null)
                            msg = new ClientPacket(result);
                        else
                            msg.WriteByte(result);
                    }
                }
                if (msg.Opcode == (byte)57 || msg.Opcode == (byte)58)
                    msg.GenerateDialogHeader();
                if (msg.UseDefaultKey)
                {
                    msg.WriteByte((byte)0);
                }
                else
                {
                    msg.WriteByte((byte)0);
                    msg.WriteByte(msg.Opcode);
                }
                msg.Write(new byte[7]);
                this.Client.Enqueue(msg);
            }
        }

        private void buttonRecv_Click(object sender, EventArgs e)
        {
            string text = this.textConsoleInput.Text;
            char[] separator1 = new char[2] { '\r', '\n' };
            foreach (string str1 in text.Split(separator1, StringSplitOptions.RemoveEmptyEntries))
            {
                ServerPacket msg = (ServerPacket)null;
                string str2 = str1;
                char[] separator2 = new char[1] { ' ' };
                foreach (string s in str2.Split(separator2, StringSplitOptions.RemoveEmptyEntries))
                {
                    byte result;
                    if (byte.TryParse(s, NumberStyles.HexNumber, (IFormatProvider)null, out result))
                    {
                        if (msg == null)
                            msg = new ServerPacket(result);
                        else
                            msg.WriteByte(result);
                    }
                }
                msg.Write(new byte[3]);
                this.Client.Enqueue(msg);
            }
        }

        public void LogIncomingPacket(string format, params object[] args)
        {
            if (this.InvokeRequired)
                this.Invoke((Action)(() => this.LogIncomingPacket(format, args)));
            else if (this.checkRecv.Checked)
            {
                this.textConsoleOutput.AppendText(string.Format(format, args));
                this.textConsoleOutput.AppendText(Environment.NewLine);
                this.textConsoleOutput.ScrollToCaret();
            }
        }

        public void LogOutgoingPacket(string format, params object[] args)
        {
            if (this.InvokeRequired)
                this.Invoke((Action)(() => this.LogOutgoingPacket(format, args)));
            else if (this.checkSend.Checked)
            {
                this.textConsoleOutput.AppendText(string.Format(format, args));
                this.textConsoleOutput.AppendText(Environment.NewLine);
                this.textConsoleOutput.ScrollToCaret();
            }
        }

        public void UpdateWalkLocales()
        {
            this.vautowalker_locales = this.autowalker_locales.SelectedItem.ToString();
            this.walklocaleslist.Items.Clear();
            if (this.autowalker_locales.SelectedItem.ToString() == "Aman Jungle")
            {
                this.walklocaleslist.Items.Add((object)"Vortigern");
                this.walklocaleslist.Items.Add((object)"Oriana");
                this.walklocaleslist.Items.Add((object)"Jovino");
                this.walklocaleslist.Items.Add((object)"Bank");
                this.walklocaleslist.Items.Add((object)"AJ 0 End");
                this.walklocaleslist.Items.Add((object)"AJ 6");
                this.walklocaleslist.Items.Add((object)"AJ 7 End (dendrons)");
                this.walklocaleslist.Items.Add((object)"HG ent");
                this.walklocaleslist.Items.Add((object)"HG end");
                this.walklocaleslist.Items.Add((object)"CC ent");
                this.walklocaleslist.Items.Add((object)"CC 7");
                this.walklocaleslist.Items.Add((object)"CC end");
                this.walklocaleslist.Items.Add((object)"YT ent");
                this.walklocaleslist.Items.Add((object)"YT 3");
                this.walklocaleslist.Items.Add((object)"YT 4");
                this.walklocaleslist.Items.Add((object)"YT 5");
                this.walklocaleslist.Items.Add((object)"YT 6");
                this.walklocaleslist.Items.Add((object)"YT 11");
                this.walklocaleslist.Items.Add((object)"YT 12");
                this.walklocaleslist.Items.Add((object)"Yellow Vines");
                this.walklocaleslist.Items.Add((object)"YT 15");
                this.walklocaleslist.Items.Add((object)"YT Boss");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Hwarone")
            {
                this.walklocaleslist.Items.Add((object)"Inn");
                this.walklocaleslist.Items.Add((object)"Cursed Home");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Asilon")
            {
                this.walklocaleslist.Items.Add((object)"Bank");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Noam")
            {
                this.walklocaleslist.Items.Add((object)"Bank");
                this.walklocaleslist.Items.Add((object)"Noam 17");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Andor")
            {
                this.walklocaleslist.Items.Add((object)"Andor Lobby");
                this.walklocaleslist.Items.Add((object)"Andor 80");
                this.walklocaleslist.Items.Add((object)"Andor 140");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Desert Dunes")
            {
                this.walklocaleslist.Items.Add((object)"DD ent");
                this.walklocaleslist.Items.Add((object)"Pyramid ent");
                this.walklocaleslist.Items.Add((object)"Pyramid center");
                this.walklocaleslist.Items.Add((object)"Oasis");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Chaos")
            {
                this.walklocaleslist.Items.Add((object)"Chaos ent");
                this.walklocaleslist.Items.Add((object)"Chaos 3 exit");
                this.walklocaleslist.Items.Add((object)"Chaos 12 exit");
                this.walklocaleslist.Items.Add((object)"Chaos 25 side");
                this.walklocaleslist.Items.Add((object)"Chaos 34");
                this.walklocaleslist.Items.Add((object)"Chaos 34 End");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Mehadi")
            {
                this.walklocaleslist.Items.Add((object)"Entrance");
                this.walklocaleslist.Items.Add((object)"Flower");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Shinewood")
            {
                this.walklocaleslist.Items.Add((object)"SW 8 (DSS)");
                this.walklocaleslist.Items.Add((object)"SW 12");
                this.walklocaleslist.Items.Add((object)"SW 17 (hut)");
                this.walklocaleslist.Items.Add((object)"Giant Ant");
                this.walklocaleslist.Items.Add((object)"Red Mantis");
                this.walklocaleslist.Items.Add((object)"SW 22");
                this.walklocaleslist.Items.Add((object)"SW 30 (hut)");
                this.walklocaleslist.Items.Add((object)"Phoenix Altar");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Mt Merry")
            {
                this.walklocaleslist.Items.Add((object)"Entrance");
                this.walklocaleslist.Items.Add((object)"Mother Erbie");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Lynith")
            {
                this.walklocaleslist.Items.Add((object)"Giant Pearl");
                this.walklocaleslist.Items.Add((object)"Paradise");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Nobis")
            {
                this.walklocaleslist.Items.Add((object)"Oren Fountain");
                this.walklocaleslist.Items.Add((object)"Tower Maze");
                this.walklocaleslist.Items.Add((object)"Shamensyth ent");
                this.walklocaleslist.Items.Add((object)"Jungle ent");
                this.walklocaleslist.Items.Add((object)"Nobis ent");
                this.walklocaleslist.Items.Add((object)"Mob 2-5");
                this.walklocaleslist.Items.Add((object)"Mob 2-11");
                this.walklocaleslist.Items.Add((object)"dig bones (east)");
                this.walklocaleslist.Items.Add((object)"dig bones (north)");
                this.walklocaleslist.Items.Add((object)"dig bones (middle)");
                this.walklocaleslist.Items.Add((object)"1st Summon");
                this.walklocaleslist.Items.Add((object)"2nd Summon");
                this.walklocaleslist.Items.Add((object)"3rd Summon");
                this.walklocaleslist.Items.Add((object)"4th Summon");
                this.walklocaleslist.Items.Add((object)"Medusa");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Mount Giragan")
            {
                this.walklocaleslist.Items.Add((object)"Mtg 1");
                this.walklocaleslist.Items.Add((object)"tauren horn");
                this.walklocaleslist.Items.Add((object)"tauren nose ring");
                this.walklocaleslist.Items.Add((object)"Mtg 18 (belt)");
                this.walklocaleslist.Items.Add((object)"Mtg 10");
                this.walklocaleslist.Items.Add((object)"Mtg 13");
                this.walklocaleslist.Items.Add((object)"Tauren");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Cthonic Remains")
            {
                this.walklocaleslist.Items.Add((object)"CR 1");
                this.walklocaleslist.Items.Add((object)"CR 31");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Mileth")
            {
                this.walklocaleslist.Items.Add((object)"Altar");
                this.walklocaleslist.Items.Add((object)"Tailor");
                this.walklocaleslist.Items.Add((object)"Bank");
                this.walklocaleslist.Items.Add((object)"Inn");
                this.walklocaleslist.Items.Add((object)"Tavern");
                this.walklocaleslist.Items.Add((object)"Restaurant");
                this.walklocaleslist.Items.Add((object)"Church");
                this.walklocaleslist.Items.Add((object)"Crypt");
                this.walklocaleslist.Items.Add((object)"Crypt 4");
                this.walklocaleslist.Items.Add((object)"Crypt 11");
                this.walklocaleslist.Items.Add((object)"Crypt 27");
                this.walklocaleslist.Items.Add((object)"Enchanted Garden");
                this.walklocaleslist.Items.Add((object)"Wasteland");
                this.walklocaleslist.Items.Add((object)"EW 15 Glade");
                this.walklocaleslist.Items.Add((object)"EW 20 Glade");
                this.walklocaleslist.Items.Add((object)"Temple of Choosing");
                this.walklocaleslist.Items.Add((object)"ToC Warrior");
                this.walklocaleslist.Items.Add((object)"ToC Monk");
                this.walklocaleslist.Items.Add((object)"ToC Rogue");
                this.walklocaleslist.Items.Add((object)"ToC Priest");
                this.walklocaleslist.Items.Add((object)"ToC Wizard");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Abel")
            {
                this.walklocaleslist.Items.Add((object)"Entrance");
                this.walklocaleslist.Items.Add((object)"Bank");
                this.walklocaleslist.Items.Add((object)"Tavern");
                this.walklocaleslist.Items.Add((object)"Inn");
                this.walklocaleslist.Items.Add((object)"Dungeon");
                this.walklocaleslist.Items.Add((object)"Dungeon 5 Cave");
                this.walklocaleslist.Items.Add((object)"Dungeon 10 Cave");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Piet")
            {
                this.walklocaleslist.Items.Add((object)"Bank");
                this.walklocaleslist.Items.Add((object)"Inn");
                this.walklocaleslist.Items.Add((object)"Dungeon");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Pravat")
            {
                this.walklocaleslist.Items.Add((object)"Bank");
                this.walklocaleslist.Items.Add((object)"Cross");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Loures")
            {
                this.walklocaleslist.Items.Add((object)"Canal Ent");
                this.walklocaleslist.Items.Add((object)"Canal Key 1 (skrull)");
                this.walklocaleslist.Items.Add((object)"Canal Key 2 (blob)");
                this.walklocaleslist.Items.Add((object)"Library");
                this.walklocaleslist.Items.Add((object)"Throne Room");
                this.walklocaleslist.Items.Add((object)"2nd Floor Weapon");
                this.walklocaleslist.Items.Add((object)"Maze");
                this.walklocaleslist.Items.Add((object)"1st Floor Weapon");
                this.walklocaleslist.Items.Add((object)"Dungeon (aite)");
                this.walklocaleslist.Items.Add((object)"Dark Maze");
                this.walklocaleslist.Items.Add((object)"Jean");
                this.walklocaleslist.Items.Add((object)"Frosty (x-mas)");
                this.walklocaleslist.Items.Add((object)"Francis (summer)");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Rucesion")
            {
                this.walklocaleslist.Items.Add((object)"Bank");
                this.walklocaleslist.Items.Add((object)"Skill Master");
                this.walklocaleslist.Items.Add((object)"Black Market");
                this.walklocaleslist.Items.Add((object)"Armor Shop");
                this.walklocaleslist.Items.Add((object)"Inn");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Tagor")
            {
                this.walklocaleslist.Items.Add((object)"Bank");
                this.walklocaleslist.Items.Add((object)"Inn");
                this.walklocaleslist.Items.Add((object)"Lost Path");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Undine")
            {
                this.walklocaleslist.Items.Add((object)"Bank");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Astrid")
            {
                this.walklocaleslist.Items.Add((object)"Octagram");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else if (this.autowalker_locales.SelectedItem.ToString() == "Suomi")
            {
                this.walklocaleslist.Items.Add((object)"Inn");
                this.walklocaleslist.Items.Add((object)"Weapon Shop");
                this.walklocaleslist.SelectedIndex = 0;
            }
            else
            {
                if (!(this.autowalker_locales.SelectedItem.ToString() == "Lost Ruins"))
                    return;
                this.walklocaleslist.Items.Add((object)"Nairn");
                this.walklocaleslist.Items.Add((object)"LR2 Rocks");
                this.walklocaleslist.Items.Add((object)"LR3 Rocks");
                this.walklocaleslist.Items.Add((object)"Ass Dungeon");
                this.walklocaleslist.Items.Add((object)"LR4 Rocks");
                this.walklocaleslist.Items.Add((object)"Marble Vault");
                this.walklocaleslist.Items.Add((object)"LR5 Altar");
                this.walklocaleslist.Items.Add((object)"Dung Field");
                this.walklocaleslist.Items.Add((object)"Law");
                this.walklocaleslist.SelectedIndex = 0;
            }
        }

        private void wayregionson_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Client.lastaction != DateTime.MinValue)
                this.Client.lastaction = DateTime.UtcNow;
            this.vwayregionson = this.wayregionson.Checked;
            this.followplayer.Checked = false;
            if (!this.wayregionson.Checked)
                return;
            this.castwhilefollow.Checked = true;
            this.actonlyinmobs.Checked = true;
        }

        private void walkconfig_Click(object sender, EventArgs e)
        {
            this.walkconfig.Enabled = false;
            this.Wayregion.Show();
            this.Wayregion.StartDrawing();
        }

        private void followdist_ValueChanged(object sender, EventArgs e)
        {
            this.vfollowdist = (int)this.followdist.Value;
        }

        private void walksettings_ValueChanged(object sender, EventArgs e)
        {
            this.vwalksettings = (int)this.walksettings.Value;
        }

        private void fastwalk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.fastwalk.Checked)
            {
                this.mediumwalk.Checked = false;
                this.walksettings.Value = new Decimal(160);
            }
            else
                this.walksettings.Value = new Decimal(410);
        }

        private void mediumwalk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.mediumwalk.Checked)
            {
                this.fastwalk.Checked = false;
                this.walksettings.Value = new Decimal(260);
            }
            else
                this.walksettings.Value = new Decimal(410);
        }

        private void followplayer_CheckedChanged(object sender, EventArgs e)
        {
            this.vfollowplayer = this.followplayer.Checked;
            this.wayregionson.Checked = false;
        }

        private void followtarget_TextChanged(object sender, EventArgs e)
        {
            this.vfollowtarget = this.followtarget.Text;
        }

        private void castwhilefollow_CheckedChanged(object sender, EventArgs e)
        {
            this.vcastwhilefollow = this.castwhilefollow.Checked;
        }

        private void walklocaleslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (MappedMaps mappedMaps in this.Client.AutoWalkMaps.Values)
                mappedMaps.Deadend = false;
            this.Client.CurAWDest = (Location)null;
            this.Client.HasAWPath = false;
            this.vwalklocaleslist = this.walklocaleslist.SelectedItem.ToString();
        }

        private void autowalker_button_Click(object sender, EventArgs e)
        {
            if (this.autowalker_button.Text.Equals("Start"))
            {
                this.autowalker_button.Text = "Stop";
                this.Client.autowalkon = true;
                this.castwhilefollow.Checked = true;
                if (this.iocself.Visible)
                    this.iocself.Checked = true;
                if (this.iocself.Visible && this.ioctype.Text == "nuadhaich")
                    this.ioctype.Text = "ard ioc";
                if (this.aocurse.Visible)
                    this.aocurse.Checked = true;
                if (this.dion_enemiesnext.Visible)
                    this.dion_enemiesnext.Checked = true;
                if (this.dion_enemiesnext.Visible)
                    this.dion_enemiesnextcount.Value = new Decimal(1);
                if (this.selfaopuinsein.Visible)
                    this.selfaopuinsein.Checked = true;
                if (!this.selfaosuain.Visible)
                    return;
                this.selfaosuain.Checked = true;
            }
            else
            {
                this.autowalker_button.Text = "Start";
                this.Client.autowalkon = false;
            }
        }

        private void autowalker_locales_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateWalkLocales();
        }

        private void dion_enemiesnext_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dion_enemiesnext.Checked || this.dion_enemiesonscreen.Checked || this.dion_lowhp.Checked || this.dion_aosith.Checked)
            {
                if (this.dion_enemiesnext.Checked)
                    this.dion_enemiesnextcount.Enabled = true;
                if (this.dion_enemiesonscreen.Checked)
                    this.dion_enemiesonscreenvalue.Enabled = true;
                if (this.dion_lowhp.Checked)
                    this.dion_hpcond.Enabled = true;
            }
            if (!this.dion_enemiesnext.Checked)
                this.dion_enemiesnextcount.Enabled = false;
            if (!this.dion_enemiesonscreen.Checked)
                this.dion_enemiesonscreenvalue.Enabled = false;
            if (this.dion_lowhp.Checked)
                return;
            this.dion_hpcond.Enabled = false;
        }

        private void orangebartrack_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void openpriorityform_Click(object sender, EventArgs e)
        {
            this.openpriorityform.Enabled = false;
            this.SpellPriority.Text = this.Client.Name + " - Priority";
            this.SpellPriority.Show();
        }

        private void iocself_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.iocself.Checked)
            {
                this.viocself = true;
                this.iocselfcond.Enabled = true;
            }
            else
            {
                this.viocself = false;
                this.iocselfcond.Enabled = false;
            }
        }

        private void fs_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.fs.Checked)
            {
                this.vfs = true;
                this.fscond.Enabled = true;
            }
            else
            {
                this.vfs = false;
                this.fscond.Enabled = false;
            }
        }

        private void disenchanter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.disenchanter.Checked)
            {
                this.vdisenchanter = true;
                this.Client.disIsSummoned = false;
                this.Client.distime = DateTime.MinValue;
            }
            else
                this.vdisenchanter = false;
        }

        private void druidform_CheckedChanged(object sender, EventArgs e)
        {
            if (this.druidform.Checked)
            {
                foreach (Spell spell in this.Client.SpellBook)
                {
                    if (spell != null && (spell.Name.Contains("Feral Form") || spell.Name.Contains("Komodas Form") || spell.Name.Contains("Karura Form")))
                    {
                        this.Client.druidform = Server.SpellList[spell.Name];
                        break;
                    }
                }
                this.vdruidform = true;
            }
            else
                this.vdruidform = false;
        }

        private void aegissphere_CheckedChanged(object sender, EventArgs e)
        {
            if (this.aegissphere.Checked)
                this.vaegissphere = true;
            else
                this.vaegissphere = false;
        }

        private void staffswitch_CheckedChanged(object sender, EventArgs e)
        {
            if (this.staffswitch.Checked)
                this.vstaffswitch = true;
            else
                this.vstaffswitch = false;
        }

        private void selfaite_CheckedChanged(object sender, EventArgs e)
        {
            this.vselfaite = this.selfaite.Checked;
        }

        private void selffas_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selffas.Checked)
                this.vselffas = true;
            else
                this.vselffas = false;
        }

        private void selfbean_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selfbean.Checked)
                this.vselfbean = true;
            else
                this.vselfbean = false;
        }

        private void selffasdeireas_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selffasdeireas.Checked)
                this.vselffasdeireas = true;
            else
                this.vselffasdeireas = false;
        }

        private void selfcreagneart_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selfcreagneart.Checked)
                this.vselfcreagneart = true;
            else
                this.vselfcreagneart = false;
        }

        private void selfmist_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selfmist.Checked)
                this.vselfmist = true;
            else
                this.vselfmist = false;
        }

        private void selfregen_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selfregen.Checked)
                this.vselfregen = true;
            else
                this.vselfregen = false;
        }

        private void selfca_CheckedChanged(object sender, EventArgs e)
        {
            this.vselfca = this.selfca.Checked;
        }

        private void selfaosuain_CheckedChanged(object sender, EventArgs e)
        {
            this.vselfaosuain = this.selfaosuain.Checked;
        }

        private void selfaopuinsein_CheckedChanged(object sender, EventArgs e)
        {
            this.vselfaopuinsein = this.selfaopuinsein.Checked;
        }

        private void aocurse_CheckedChanged(object sender, EventArgs e)
        {
            this.vaocurse = this.aocurse.Checked;
        }

        private void selfbc_CheckedChanged(object sender, EventArgs e)
        {
            this.vselfbc = this.selfbc.Checked;
        }

        private void selfarm_CheckedChanged(object sender, EventArgs e)
        {
            this.vselfarm = this.selfarm.Checked;
        }

        private void selfhide_CheckedChanged(object sender, EventArgs e)
        {
            this.vselfhide = this.selfhide.Checked;
        }

        private void selfaitetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.vselfaitetype = this.selfaitetype.SelectedItem.ToString();
        }

        private void selffastype_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.vselffastype = this.selffastype.SelectedItem.ToString();
        }

        private void ioctype_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.vioctype = this.ioctype.SelectedItem.ToString();
        }

        private void iocselfcond_ValueChanged(object sender, EventArgs e)
        {
            this.viocselfcond = (int)this.iocselfcond.Value;
        }

        private void fscond_TextChanged(object sender, EventArgs e)
        {
            this.vfscond = this.fscond.Text;
        }

        private void MakePlayerTarget(targetPlayer newPlayers)
        {
            this.Client.targetplayer.Add(newPlayers);
            this.alreadyexists.Visible = false;
            this.newplayer.Checked = false;
            this.newplayername.Text = "";
            if (this.Client.targetplayer != null)
            {
                foreach (targetPlayer targetPlayer in this.Client.targetplayer)
                    targetPlayer.updatePlayerTargets();
            }
            this.spellTargets.SelectedIndex = 0;
        }

        private void MakeThePlayers(string thename)
        {
            this.Players = new targetPlayer(thename, this, false);
        }

        private void CreateGroupTarget(ClientTab newText)
        {
            this.targetgroup = new targetGroup(this);
            this.alreadyexists.Visible = false;
            this.spellTargets.TabPages.Add((TabPage)this.targetgroup);
            this.spellTargets.SelectedTab = (TabPage)this.targetgroup;
            this.targetgroup.TabIndex = this.spellTargets.TabCount + 1;
            this.newallgrouped.Checked = false;
            this.newallgrouped.Enabled = false;
        }

        private void MakeAlts(ClientTab newText)
        {
            this.allalts = new targetAlts(this);
            this.alreadyexists.Visible = false;
            this.spellTargets.TabPages.Add((TabPage)this.allalts);
            this.spellTargets.SelectedTab = (TabPage)this.allalts;
            this.allalts.TabIndex = this.spellTargets.TabCount + 1;
            this.newalts.Checked = false;
            this.newalts.Enabled = false;
        }

        private void newplayer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.newplayer.Checked && !this.newplayer.Text.Equals(""))
            {
                this.newplayername.Enabled = true;
                this.createnewtarget.Enabled = true;
            }
            else if (this.newplayer.Checked)
                this.newplayername.Enabled = true;
            else
                this.newplayername.Enabled = false;
            if (this.newalts.Checked || this.newmonster.Checked || (this.newallmonsters.Checked || this.newplayer.Checked) || this.newallgrouped.Checked)
                return;
            this.createnewtarget.Enabled = false;
        }

        private void newplayername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar != '\r')
                    return;
                e.Handled = true;
                this.createnewtarget.PerformClick();
            }
        }

        private void newplayername_TextChanged(object sender, EventArgs e)
        {
            if (this.newplayername.Text != "")
            {
                this.createnewtarget.Enabled = true;
            }
            else
            {
                if (!(this.newplayername.Text == ""))
                    return;
                this.createnewtarget.Enabled = false;
            }
        }

        private void newalts_CheckedChanged(object sender, EventArgs e)
        {
            if (this.newalts.Checked)
                this.createnewtarget.Enabled = true;
            if (this.newalts.Checked || this.newmonster.Checked || (this.newallmonsters.Checked || this.newplayer.Checked) || this.newallgrouped.Checked)
                return;
            this.createnewtarget.Enabled = false;
        }

        private void newallgrouped_CheckedChanged(object sender, EventArgs e)
        {
            if (this.newallgrouped.Checked)
            {
                this.createnewtarget.Enabled = true;
            }
            else
            {
                if (this.newalts.Checked || this.newmonster.Checked || (this.newallmonsters.Checked || this.newplayer.Checked) || this.newallgrouped.Checked)
                    return;
                this.createnewtarget.Enabled = false;
            }
        }

        private void createnewtarget_Click(object sender, EventArgs e)
        {
            if (this.newallgrouped.Checked && this.targetgroup == null)
                this.BeginInvoke((Delegate)new ClientTab.MakeGroupTarget(this.CreateGroupTarget), (object)this);
            else if (this.targetgroup != null)
                this.alreadyexists.Visible = true;
            if (this.newalts.Checked && this.allalts == null)
                this.BeginInvoke((Delegate)new ClientTab.MakeGroupTarget(this.MakeAlts), (object)this);
            else if (this.allalts != null)
                this.alreadyexists.Visible = true;
            if (this.newplayer.Checked && this.newplayername.Text != "" && this.newplayername.Text != this.Client.Name)
            {
                bool match = false;
                if (this.Client.targetplayer.Count > 0)
                {
                    int matched = 0;
                    this.Client.targetplayer.ForEach((Action<targetPlayer>)(player =>
                   {
                       if (!string.Equals(player.Text, this.newplayername.Text, StringComparison.CurrentCultureIgnoreCase))
                           return;
                       ++matched;
                   }));
                    if (matched == 0)
                    {
                        Server.Clients.ForEach((Action<Client>)(ident =>
                       {
                           if (!this.newplayername.Text.Equals(ident.Name, StringComparison.OrdinalIgnoreCase))
                               return;
                           match = true;
                       }));
                        if (match)
                        {
                            this.Client.targetplayer.Add(new targetPlayer(this.newplayername.Text, this, true));
                            this.Client.alts.Add((object)this.newplayername.Text.ToLower());
                            this.alreadyexists.Visible = false;
                            this.newplayer.Checked = false;
                            this.newplayername.Text = "";
                        }
                        else
                        {
                            this.Client.targetplayer.Add(new targetPlayer(this.newplayername.Text, this, false));
                            this.alreadyexists.Visible = false;
                            this.newplayer.Checked = false;
                            this.newplayername.Text = "";
                        }
                    }
                    else
                        this.alreadyexists.Visible = true;
                }
                else
                {
                    Server.Clients.ForEach((Action<Client>)(ident =>
                   {
                       if (!this.newplayername.Text.Equals(ident.Name, StringComparison.CurrentCultureIgnoreCase))
                           return;
                       match = true;
                   }));
                    if (match)
                    {
                        this.Client.targetplayer.Add(new targetPlayer(this.newplayername.Text, this, true));
                        this.Client.alts.Add((object)this.newplayername.Text.ToLower());
                        this.alreadyexists.Visible = false;
                        this.newplayer.Checked = false;
                        this.newplayername.Text = "";
                    }
                    else
                    {
                        this.Client.targetplayer.Add(new targetPlayer(this.newplayername.Text, this, false));
                        this.alreadyexists.Visible = false;
                        this.newplayer.Checked = false;
                        this.newplayername.Text = "";
                    }
                }
            }
            else
            {
                if (!this.newplayername.Text.Equals(this.Client.Name, StringComparison.CurrentCultureIgnoreCase))
                    return;
                this.alreadyexists.Visible = true;
            }
        }

        private void MakeAllMonsters()
        {
            this.allMonsters = new TargetAllMonster(this);
            this.spellMonsters.TabPages.Add((TabPage)this.allMonsters);
            this.spellMonsters.SelectedTab = (TabPage)this.allMonsters;
            this.monsterexists.Visible = false;
            this.allMonsters.TabIndex = this.spellTargets.TabCount + 1;
            this.newmonsterbyplayer.Checked = false;
            this.newmonster.Checked = false;
            this.newallmonsters.Checked = false;
            this.newallmonsters.Enabled = false;
        }

        private void newmonsterbyplayer_Click(object sender, EventArgs e)
        {
            if (this.newmonsterbyplayer.Checked)
            {
                this.newallmonsters.Checked = false;
                this.newmonster.Checked = false;
                this.newmonsterbyplayername.Enabled = true;
            }
            else
                this.newmonsterbyplayername.Enabled = false;
            if (this.newalts.Checked || this.newmonster.Checked || (this.newallmonsters.Checked || this.newplayer.Checked) || this.newallgrouped.Checked)
                return;
            this.createnewmonster.Enabled = false;
        }

        private void newmonster_CheckedChanged(object sender, EventArgs e)
        {
            if (this.newmonster.Checked)
            {
                this.newallmonsters.Checked = false;
                this.newmonstername.Enabled = true;
                this.newmonsterbyplayer.Checked = false;
            }
            else
                this.newmonstername.Enabled = false;
            if (this.newalts.Checked || this.newmonster.Checked || (this.newallmonsters.Checked || this.newplayer.Checked) || this.newallgrouped.Checked)
                return;
            this.createnewmonster.Enabled = false;
        }

        private void newallmonsters_CheckedChanged(object sender, EventArgs e)
        {
            if (this.newallmonsters.Checked)
            {
                this.newmonster.Checked = false;
                this.createnewmonster.Enabled = true;
                this.newmonsterbyplayer.Checked = false;
            }
            else if (!this.newallmonsters.Checked && this.allMonsters == null)
                this.newmonster.Enabled = true;
            if (this.newalts.Checked || this.newmonster.Checked || (this.newallmonsters.Checked || this.newplayer.Checked) || this.newallgrouped.Checked)
                return;
            this.createnewmonster.Enabled = false;
        }

        private void getimage_CheckedChanged(object sender, EventArgs e)
        {
            this.getmonsterid2.Checked = this.getimage.Checked;
            this.vgetimage = this.getimage.Checked;
        }

        private void newmonsterbyplayername_TextChanged(object sender, EventArgs e)
        {
            if (this.newmonsterbyplayername.Text != "")
            {
                this.createnewmonster.Enabled = true;
            }
            else
            {
                if (!(this.newmonsterbyplayername.Text == ""))
                    return;
                this.createnewmonster.Enabled = false;
            }
        }

        private void newmonsterbyplayername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar != '\r')
                    return;
                e.Handled = true;
                this.CreateMonsterTabs();
            }
        }

        private void newmonstername_TextChanged(object sender, EventArgs e)
        {
            if (this.newmonstername.Text != "")
            {
                this.createnewmonster.Enabled = true;
            }
            else
            {
                if (!(this.newmonstername.Text == ""))
                    return;
                this.createnewmonster.Enabled = false;
            }
        }

        private void newmonstername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar != '\r')
                    return;
                e.Handled = true;
                this.CreateMonsterTabs();
            }
        }

        private void createnewmonster_Click(object sender, EventArgs e)
        {
            if (this.newallmonsters.Checked && this.allMonsters == null)
                this.Invoke((Delegate)new ClientTab.MakeAllMonster(this.MakeAllMonsters));
            else if (this.allMonsters != null)
                this.monsterexists.Visible = true;
            this.CreateMonsterTabs();
        }

        public void CreateMonsterTabs()
        {
            this.getimage.Checked = false;
            if (this.newmonster.Checked && this.newmonstername.Text != "")
            {
                if (this.Client.targetmonster.Count > 0)
                {
                    int matched = 0;
                    this.Client.targetmonster.ForEach((Action<TargetMonster>)(monster =>
                   {
                       if (!string.Equals(monster.Text, this.newmonstername.Text, StringComparison.CurrentCulture))
                           return;
                       ++matched;
                   }));
                    if (matched == 0)
                    {
                        this.Monsters = new TargetMonster(this.newmonstername.Text, this);
                        this.Client.targetmonster.Add(this.Monsters);
                        this.newmonster.Checked = false;
                        this.monsterexists.Visible = false;
                    }
                    else
                        this.monsterexists.Visible = true;
                }
                else
                {
                    this.Monsters = new TargetMonster(this.newmonstername.Text, this);
                    this.Client.targetmonster.Add(this.Monsters);
                    this.newmonster.Checked = false;
                    this.monsterexists.Visible = false;
                }
            }
            if (this.newmonsterbyplayer.Checked && this.newmonsterbyplayername.Text != "")
            {
                this.Client.targetmonster.ForEach((Action<TargetMonster>)(monster => this.spellMonsters.TabPages.Remove((TabPage)monster)));
                this.Client.targetmonster.Clear();
                this.MonstersByPlayer = new targetMonsterbyPlayer(this.newmonsterbyplayername.Text, this);
                this.spellMonsters.TabPages.Add((TabPage)this.MonstersByPlayer);
                this.spellMonsters.SelectedTab = (TabPage)this.MonstersByPlayer;
                this.monsterexists.Visible = false;
                this.newmonsterbyplayer.Checked = false;
                this.newmonsterbyplayername.Enabled = false;
                this.newmonster.Checked = false;
                this.newmonster.Enabled = false;
                this.newallmonsters.Checked = false;
                this.newallmonsters.Enabled = false;
                this.createnewmonster.Enabled = false;
            }
            this.newmonsterbyplayername.Text = "";
            this.newmonstername.Text = "";
        }

        public void TemplateSaveMessage_Opacity(object sender, EventArgs e)
        {
            this.templatesaved.Visible = false;
            this.currenttemplateupdated.Visible = false;
            this.newtemplate_error.Visible = false;
            this.template_loaded_message.Visible = false;
            this.templatedeleted.Visible = false;
            this.templateupdated2.Visible = false;
            this.TemplateSaveTimer.Stop();
        }

        private void updatecurrent_Click(object sender, EventArgs e)
        {
            this.SaveTemplate(this.loadedtemplate.Text, false);
            this.currenttemplateupdated.Visible = true;
            this.TemplateSaveTimer.Start();
        }

        private void newtemplate_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            e.Handled = true;
            this.newtemplate_save.PerformClick();
        }

        private void newtemplate_save_Click(object sender, EventArgs e)
        {
            string str = this.RemoveSpecialChars(this.newtemplate_name.Text);
            if (str.Equals("") || str.Length > 22)
            {
                this.newtemplate_error.Visible = true;
                this.templatesaved.Visible = false;
            }
            else
            {
                this.newtemplate_error.Visible = false;
                this.templatesaved.Visible = true;
                this.SaveTemplate("", false);
                this.newtemplate_name.Text = "";
                this.loadedtemplate.Text = str;
            }
            this.template_loaded_message.Visible = false;
            this.currenttemplateupdated.Visible = false;
            this.TemplateSaveTimer.Start();
        }

        private void loadtemplate_Click(object sender, EventArgs e)
        {
            if (this.template_lists.SelectedItem == null)
                return;
            this.LoadTemplate("", false);
            this.template_loaded_message.Text = this.template_lists.SelectedItem.ToString() + " template loaded.";
            this.template_loaded_message.Visible = true;
            this.currenttemplateupdated.Visible = false;
            this.templatesaved.Visible = false;
            this.TemplateSaveTimer.Start();
        }

        private void loaddefault_Click(object sender, EventArgs e)
        {
            this.LoadTemplate("default", false);
        }

        private void delete_template_Click(object sender, EventArgs e)
        {
            this.DeleteTemplate();
        }

        private void template_lists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.template_lists.SelectedItem != null)
            {
                this.loadtemplate.Enabled = true;
                this.delete_template.Enabled = true;
                this.loaddefault.Enabled = true;
            }
            else
            {
                this.loadtemplate.Enabled = false;
                this.delete_template.Enabled = false;
                this.loaddefault.Enabled = false;
            }
        }

        public static string CapitalizeWords(string value)
        {
            switch (value)
            {
                case "":
                    return value;
                case null:
                    throw new ArgumentNullException(nameof(value));
                default:
                    StringBuilder stringBuilder = new StringBuilder(value);
                    stringBuilder[0] = char.ToUpper(stringBuilder[0]);
                    for (int index = 1; index < stringBuilder.Length; ++index)
                        stringBuilder[index] = !char.IsWhiteSpace(stringBuilder[index - 1]) ? char.ToLower(stringBuilder[index]) : char.ToUpper(stringBuilder[index]);
                    return stringBuilder.ToString();
            }
        }

        public string RemoveSpecialChars(string str)
        {
            string[] strArray = new string[22]
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
        "(",
        ")",
        ":",
        "|",
        "[",
        "]"
            };
            for (int index = 0; index < strArray.Length; ++index)
            {
                if (str.Contains(strArray[index]))
                    str = str.Replace(strArray[index], "");
            }
            return str;
        }

        private void LoadTemplates(FileInfo gonefile)
        {
            if (!Directory.Exists(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\"))
                return;
            FileInfo[] files = new DirectoryInfo(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\").GetFiles("*.xml");
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            if (files.Length == 0)
            {
                this.loadtemplate.Enabled = false;
                this.delete_template.Enabled = false;
            }
            else
            {
                this.loadtemplate.Enabled = true;
                this.delete_template.Enabled = true;
            }
            foreach (FileInfo fileInfo in files)
            {
                string str = fileInfo.Name.Remove(fileInfo.Name.IndexOf(".xml"));
                if (!this.template_lists.Items.Contains((object)str) && fileInfo.Name != gonefile.Name && (str != "macro" && str != "skills") && (str != "default" && str != "timedstuff" && (str != "originalskills" && str != "customskills")) && str != this.Client.Name.ToLower() + "_dc" && str != this.Client.Name.ToLower() + "_default")
                    this.template_lists.Items.Add((object)str);
            }
            string str1 = gonefile.Name.Remove(gonefile.Name.IndexOf(".xml"));
            if (this.template_lists.Items.Contains((object)str1))
                this.template_lists.Items.Remove((object)str1);
        }

        public void LoadTemplates()
        {
            if (!Directory.Exists(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\"))
                return;
            FileInfo[] files = new DirectoryInfo(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\").GetFiles("*.xml");
            string empty = string.Empty;
            foreach (FileInfo fileInfo in files)
            {
                int startIndex = fileInfo.Name.IndexOf(".xml");
                string str = fileInfo.Name.Remove(startIndex);
                if (!this.template_lists.Items.Contains((object)str) && str != "macro" && (str != "skills" && str != "default") && (str != "timedstuff" && str != "originalskills" && (str != "customskills" && str != this.Client.Name.ToLower() + "_dc")) && str != this.Client.Name.ToLower() + "_default")
                    this.template_lists.Items.Add((object)str);
            }
        }

        private void DeleteTemplate()
        {
            FileInfo[] files = new DirectoryInfo(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\").GetFiles("*.xml");
            string empty = string.Empty;
            foreach (FileInfo gonefile in files)
            {
                int startIndex = gonefile.Name.IndexOf(".xml");
                string str = gonefile.Name.Remove(startIndex);
                if (this.template_lists.SelectedItem != null && this.template_lists.SelectedItem.ToString() == str)
                {
                    gonefile.Delete();
                    this.LoadTemplates(gonefile);
                    this.templatedeleted.Text = str + " was deleted.";
                    this.templatedeleted.Visible = true;
                    this.templateupdated2.Visible = false;
                    this.template_loaded_message.Visible = false;
                    this.TemplateSaveTimer.Start();
                    break;
                }
            }
        }

        public void SaveTemplate(string toSave = "", bool OnDC = false)
        {
            XDocument doc = new XDocument();
            doc.Add((object)new XElement((XName)"Settings"));
            if (OnDC)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"attirebool", (object)this.Client.claimbeachattire));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"PlayState", (object)this.Client.pause));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"AutoWalkState", (object)this.Client.autowalkon));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"AutoWalkDestA", this.autowalker_locales.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"AutoWalkDestB", this.walklocaleslist.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"GroupCount", (object)this.Client.GroupMembers.Count));
                int num = 0;
                foreach (string groupMember in this.Client.GroupMembers)
                {
                    doc.Element((XName)"Settings").Add((object)new XElement((XName)("GroupMember_" + (object)num), (object)groupMember));
                    ++num;
                }
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"mediumwalk", (object)this.mediumwalk.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"fastwalk", (object)this.fastwalk.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"WalkSpeed", (object)this.walksettings.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"Follow", (object)this.followplayer.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"Follow_target", (object)this.followtarget.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"Distance", (object)this.followdist.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"castwhilefollow", (object)this.castwhilefollow.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"IgnoreWalkAll", (object)this.ignorewalkall.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"walktowards", (object)this.walktowards.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"haltwalknonfriends", (object)this.haltwalknonfriends.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"walkclosebyonly", (object)this.walkclosebyonly.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"UseWaypoints", (object)this.wayregionson.Checked));
            int num1 = 0;
            foreach (KeyValuePair<int, MapNum> tempRegion in this.Client.TempRegions)
            {
                if (tempRegion.Value.Regions.Count > 0)
                    ++num1;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"NumberOfMaps", (object)num1));
            int num2 = 0;
            foreach (KeyValuePair<int, MapNum> tempRegion in this.Client.TempRegions)
            {
                if (tempRegion.Value.Regions.Count > 0)
                {
                    doc.Element((XName)"Settings").Add((object)new XElement((XName)("map" + (object)num2)));
                    XElement xelement1 = doc.Element((XName)"Settings").Element((XName)("map" + (object)num2));
                    XName name1 = (XName)"Count";
                    int num3 = tempRegion.Value.Regions.Count;
                    string str1 = num3.ToString();
                    XElement xelement2 = new XElement(name1, (object)str1);
                    xelement1.Add((object)xelement2);
                    XElement xelement3 = doc.Element((XName)"Settings").Element((XName)("map" + (object)num2));
                    XName name2 = (XName)"MapNum";
                    num3 = tempRegion.Key;
                    string str2 = num3.ToString();
                    XElement xelement4 = new XElement(name2, (object)str2);
                    xelement3.Add((object)xelement4);
                    int num4 = 0;
                    foreach (KeyValuePair<Location, string> region in tempRegion.Value.Regions)
                    {
                        if (region.Key != null)
                        {
                            XElement xelement5 = doc.Element((XName)"Settings").Element((XName)("map" + (object)num2));
                            XName name3 = (XName)("Location" + (object)num4);
                            num3 = region.Key.X;
                            string str3 = num3.ToString();
                            num3 = region.Key.Y;
                            string str4 = num3.ToString();
                            string str5 = str3 + "," + str4;
                            XElement xelement6 = new XElement(name3, (object)str5);
                            xelement5.Add((object)xelement6);
                            doc.Element((XName)"Settings").Element((XName)("map" + (object)num2)).Add((object)new XElement((XName)("Point" + (object)num4), (object)region.Value.ToString()));
                            ++num4;
                        }
                    }
                    ++num2;
                }
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"WaitOnPlayers", (object)this.Wayregion.waitonplayers.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"WaitOnPlayersCount", (object)this.Wayregion.waitonplayerslistbox.Items.Count));
            int num5 = 0;
            foreach (string str in this.Wayregion.waitonplayerslistbox.Items)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("WaitOnPlayer" + (object)num5), (object)str));
                ++num5;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"chattimestamp", (object)this.chattimestamp.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"all5classes", (object)this.all5classes.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"recorditemdata", (object)this.recorditemdata.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"friendspeak", (object)this.friendspeak.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"UseMonster", (object)this.usemonster.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"MonsterID", (object)this.usemonsterid.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"DisableSpells", (object)this.disableallspell.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"DisableBody", (object)this.disableallbody.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"disableitemsnstuff", (object)this.disableitemsnstuff.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"Slash_commands", (object)this.slash_commands.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"Auto_Kom", (object)this.autobuykoms.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"Auto_Hem", (object)this.autobuyhems.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"No_wall", (object)this.nowalls.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"disablesnow", (object)this.disablesnow.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"monitords", (object)this.monitords.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"TrackCurse", (object)this.monitorcurses.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"TrackAiteFas", (object)this.monitorspells.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"TrackDion", (object)this.monitordion.Checked));
            if (OnDC)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"dojo", (object)this.dojo.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"macrospell", (object)this.MacroOptions.macrospell.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"macroskill", (object)this.MacroOptions.macroskill.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"macroassail", (object)this.MacroOptions.macroassail.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"macrohemcrasher", (object)this.MacroOptions.macrohemcrasher.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"macropoisoncrasher", (object)this.MacroOptions.macropoisoncrasher.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"useskillbonus", (object)this.useskillbonus.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"altar", (object)this.altar.Checked));
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"labordays", (object)this.labordays.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo1length", (object)((IEnumerable<string>)this.ComboOptions.macro1).Count<string>()));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo2length", (object)((IEnumerable<string>)this.ComboOptions.macro2).Count<string>()));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo3length", (object)((IEnumerable<string>)this.ComboOptions.macro3).Count<string>()));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo4length", (object)((IEnumerable<string>)this.ComboOptions.macro4).Count<string>()));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo5length", (object)((IEnumerable<string>)this.ComboOptions.macro5).Count<string>()));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo6length", (object)((IEnumerable<string>)this.ComboOptions.macro6).Count<string>()));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo7length", (object)((IEnumerable<string>)this.ComboOptions.macro7).Count<string>()));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo8length", (object)((IEnumerable<string>)this.ComboOptions.macro8).Count<string>()));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo9length", (object)((IEnumerable<string>)this.ComboOptions.macro9).Count<string>()));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo10length", (object)((IEnumerable<string>)this.ComboOptions.macro10).Count<string>()));
            int num6 = 0;
            foreach (string str in this.ComboOptions.macro1)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("combo1box" + (object)num6), (object)str));
                ++num6;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usemacro1", (object)this.ComboOptions.usemacro1.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo1trigger", (object)this.ComboOptions.combo1trigger.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo1mod", (object)this.ComboOptions.combo1mod.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo1name", (object)this.ComboOptions.combo1name.Text));
            int num7 = 0;
            foreach (string str in this.ComboOptions.macro2)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("combo2box" + (object)num7), (object)str));
                ++num7;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usemacro2", (object)this.ComboOptions.usemacro2.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo2trigger", (object)this.ComboOptions.combo2trigger.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo2mod", (object)this.ComboOptions.combo2mod.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo2name", (object)this.ComboOptions.combo2name.Text));
            int num8 = 0;
            foreach (string str in this.ComboOptions.macro3)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("combo3box" + (object)num8), (object)str));
                ++num8;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usemacro3", (object)this.ComboOptions.usemacro3.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo3trigger", (object)this.ComboOptions.combo3trigger.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo3mod", (object)this.ComboOptions.combo3mod.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo3name", (object)this.ComboOptions.combo3name.Text));
            int num9 = 0;
            foreach (string str in this.ComboOptions.macro4)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("combo4box" + (object)num9), (object)str));
                ++num9;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usemacro4", (object)this.ComboOptions.usemacro4.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo4trigger", (object)this.ComboOptions.combo4trigger.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo4mod", (object)this.ComboOptions.combo4mod.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo4name", (object)this.ComboOptions.combo4name.Text));
            int num10 = 0;
            foreach (string str in this.ComboOptions.macro5)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("combo5box" + (object)num10), (object)str));
                ++num10;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usemacro5", (object)this.ComboOptions.usemacro5.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo5trigger", (object)this.ComboOptions.combo5trigger.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo5mod", (object)this.ComboOptions.combo5mod.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo5name", (object)this.ComboOptions.combo5name.Text));
            int num11 = 0;
            foreach (string str in this.ComboOptions.macro6)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("combo6box" + (object)num11), (object)str));
                ++num11;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usemacro6", (object)this.ComboOptions.usemacro6.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo6trigger", (object)this.ComboOptions.combo6trigger.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo6mod", (object)this.ComboOptions.combo6mod.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo6name", (object)this.ComboOptions.combo6name.Text));
            int num12 = 0;
            foreach (string str in this.ComboOptions.macro7)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("combo7box" + (object)num12), (object)str));
                ++num12;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usemacro7", (object)this.ComboOptions.usemacro7.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo7trigger", (object)this.ComboOptions.combo7trigger.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo7mod", (object)this.ComboOptions.combo7mod.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo7name", (object)this.ComboOptions.combo7name.Text));
            int num13 = 0;
            foreach (string str in this.ComboOptions.macro8)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("combo8box" + (object)num13), (object)str));
                ++num13;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usemacro8", (object)this.ComboOptions.usemacro8.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo8trigger", (object)this.ComboOptions.combo8trigger.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo8mod", (object)this.ComboOptions.combo8mod.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo8name", (object)this.ComboOptions.combo8name.Text));
            int num14 = 0;
            foreach (string str in this.ComboOptions.macro9)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("combo9box" + (object)num14), (object)str));
                ++num14;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usemacro9", (object)this.ComboOptions.usemacro9.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo9trigger", (object)this.ComboOptions.combo9trigger.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo9mod", (object)this.ComboOptions.combo9mod.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo9name", (object)this.ComboOptions.combo9name.Text));
            int num15 = 0;
            foreach (string str in this.ComboOptions.macro10)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("combo10box" + (object)num15), (object)str));
                ++num15;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usemacro10", (object)this.ComboOptions.usemacro10.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo10trigger", (object)this.ComboOptions.combo10trigger.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo10mod", (object)this.ComboOptions.combo10mod.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"combo10name", (object)this.ComboOptions.combo10name.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"UseMobbed", (object)this.actonlyinmobs.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"MobSize", (object)this.mobsize.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"MobRange", (object)this.mobdistance.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"NoLongerMobbed", (object)this.nolongermobbed.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"nolure", (object)this.nolure.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"WaitOnMonsters", (object)this.waitonmonsters.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"LureWithLamh", (object)this.lurewithlamh.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"LureWithSpells", (object)this.lurewithspells.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"LureSpell", this.lurespells.SelectedItem));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"LureWithSkills", (object)this.lurewithskills.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"onlylurewithmp", (object)this.onlylurewithmp.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"onlylurewithmpamount", (object)this.onlylurewithmpamount.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"openveltchest", (object)this.openveltchest.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"openveltchestgold", (object)this.openveltchestgold.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"openmedchest", (object)this.openmedchest.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"throwtotems", (object)this.throwtotems.Checked));
            if (toSave != "default")
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"reequiparmor", (object)this.reequiparmor.Checked));
            if (OnDC)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"useexpgem", (object)this.useexpgem.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"expgemmp", (object)this.expgemmp.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"UseEXPAPBonus", (object)this.expapbonus.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"ABRune", (object)this.abrune.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"XPShroom", (object)this.xpshroom.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"destroytonics", (object)this.destroytonics.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"uncheckloot", (object)this.uncheckloot.Checked));
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"respondflower", (object)this.respondflower.Checked));
            if (OnDC)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"reactdelay", (object)this.reactdelaya.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"reactdelayb", (object)this.reactdelayb.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"lootdelaya", (object)this.lootdelaya.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"lootdelayb", (object)this.lootdelayb.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"switchtargetdelaya", (object)this.switchtargetdelaya.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"switchtargetdelayb", (object)this.switchtargetdelayb.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"newtargetdelaya", (object)this.newtargetdelaya.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"newtargetdelayb", (object)this.newtargetdelayb.Value));
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"redaislings", (object)this.redaislings.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"walktored", (object)this.walktored.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"loot", (object)this.looton.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"walktoloot", (object)this.walktoloot.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"lootlocale", this.lootlocale.SelectedItem));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"potion", (object)this.potion.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"potioncond", (object)this.potioncond.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"mantidscent", (object)this.mantidscent.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"assassinscroll", (object)this.assassinscroll.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"elemusmount", (object)this.elemusmount.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"icebottle", (object)this.icebottle.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"fungusbeetle", (object)this.fungusbeetleextract.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dragonsfire", (object)this.dragonsfire.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dragonsscale", (object)this.dragonsscale.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"musclestimulant", (object)this.musclestimulant.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"nervestimulant", (object)this.nervestimulant.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"wakescroll", (object)this.wakescroll.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"vanishingelixer", (object)this.HideTrinketOptions.vanishingelixir.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"hideallgroup", (object)this.HideTrinketOptions.hideallgroup.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"vanishingelixercount", (object)this.HideTrinketOptions.namelist.Items.Count));
            int num16 = 0;
            foreach (string str in this.HideTrinketOptions.namelist.Items)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("vanishingelixerlistbox" + (object)num16), (object)str));
                ++num16;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"iditems", (object)this.iditems.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dropitems", (object)this.dropitemson.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dropitemlistlength", (object)this.dropitemslist.Items.Count));
            int num17 = 0;
            foreach (string str in this.dropitemslist.Items)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("dropitemslistbox" + (object)num17), (object)str));
                ++num17;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"autodeposit", (object)this.autodepositon.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"autodepositlistlength", (object)this.autodepositlistbox.Items.Count));
            int num18 = 0;
            foreach (string str in this.autodepositlistbox.Items)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)("autodepositlistbox" + (object)num18), (object)str));
                ++num18;
            }
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"aopuinseinpriority", (object)this.SpellPriority.aopuinsein.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"aocradhspriority", (object)this.SpellPriority.aocradhs.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"bcpriority", (object)this.SpellPriority.beagcradh.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"wakescrollpriority", (object)this.SpellPriority.wakescroll.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dispriority", (object)this.SpellPriority.disenchanter.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dfmonsters", (object)this.dfmonsters.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"asgallmonsters", (object)this.asgallmonsters.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfca", (object)this.selfca.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfregen", (object)this.selfregen.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfmist", (object)this.selfmist.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfcreagneart", (object)this.selfcreagneart.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selffasdeireas", (object)this.selffasdeireas.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfbean", (object)this.selfbean.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selffastype", this.selffastype.SelectedItem));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selffas", (object)this.selffas.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfaitetype", this.selfaitetype.SelectedItem));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfaite", (object)this.selfaite.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"staffswitch", (object)this.staffswitch.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"diontype", this.diontype.SelectedItem));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dion_aosith", (object)this.dion_aosith.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dion_enemiesnext", (object)this.dion_enemiesnext.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dion_enemiesonscreen", (object)this.dion_enemiesonscreen.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dion_lowhp", (object)this.dion_lowhp.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dion_enemiesnextcount", (object)this.dion_enemiesnextcount.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dion_enemiesonscreenvalue", (object)this.dion_enemiesonscreenvalue.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"dion_hpcond", (object)this.dion_hpcond.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"fs", (object)this.fs.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"fscond", (object)this.fscond.Text));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"iocselfcond", (object)this.iocselfcond.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"ioctype", this.ioctype.SelectedItem));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"iocself", (object)this.iocself.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"druidform", (object)this.druidform.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfhide", (object)this.selfhide.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"disenchanter", (object)this.disenchanter.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfarm", (object)this.selfarm.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfbc", (object)this.selfbc.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"aocurse", (object)this.aocurse.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfaopuinsein", (object)this.selfaopuinsein.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"selfaosuain", (object)this.selfaosuain.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"bubblenorajo", (object)this.bubblenorajo.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"halfcast", (object)this.halfcast.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"switchneck", (object)this.switchneck.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"equipweapon", (object)this.equipweapon.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"equipshield", (object)this.equipshield.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"attackinfinitemr", (object)this.attackinfinitemr.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"assail", (object)this.assail.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"insectassail", (object)this.insectassail.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"walktomonster", (object)this.walktomonster.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"skfasedonly", (object)this.fasedonly.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"skcursedonly", (object)this.cursedonly.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"skpramhedonly", (object)this.pramhedonly.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"useskills", (object)this.useskills.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"asrs", (object)this.asrs.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"castbries", (object)this.castbries.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"useambush", (object)this.useambush.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"usefrost", (object)this.usefrost.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"useskillshidden", (object)this.useskillshidden.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"comboscroll", (object)this.comboscroll.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"comboscrollnoshield", (object)this.comboscrollnoshield.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"pf", (object)this.pf.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"pfmonsters", (object)this.pfmonsters.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"pd", (object)this.pd.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"skillgrouprange", (object)this.skillgrouprange.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"skillgrouprangenum", (object)this.skillgrouprangenum.Value));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"attackleaderstarget", (object)this.attackleaderstarget.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"briescantattack", (object)this.briescantattack.Checked));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"brieshits", (object)this.brieshits.Value));
            if (this.allMonsters != null)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"allMonstersExists", (object)true));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"attackwithmp", (object)this.allMonsters.onlyattackwithmp.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"attackwithmpamount", (object)this.allMonsters.onlyattackwithmpamount.Text));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"pndbeforecurse", (object)this.allMonsters.pndbeforecurse.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"pndlowhp", (object)this.allMonsters.pndlowhp.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"pndiond", (object)this.allMonsters.pndiond.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"groupmembersinrange", (object)this.allMonsters.groupedmembers.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"groupmembersrange", (object)this.allMonsters.groupedmembersrange.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"spelllargestgroup", (object)this.allMonsters.spelllargestgroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"spelllargestgroupnumber", (object)this.allMonsters.spelllargestgroupnumber.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"ignoredistant", (object)this.allMonsters.ignoredistant.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"targettype", this.allMonsters.targettype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"fascursetargettype", this.allMonsters.fascursetargettype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"attack1type", this.allMonsters.attack1type.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"attack2type", this.allMonsters.attack2type.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"pramhtype", this.allMonsters.pramhtype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"fastype", this.allMonsters.fastype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"cradhtype", this.allMonsters.cradhtype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"ardedonly", (object)this.allMonsters.ardedonly.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"fasedonly", (object)this.allMonsters.fasedonly.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"ctd", (object)this.allMonsters.ctd.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"diondonly", (object)this.allMonsters.diondonly.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"pramhedonly", (object)this.allMonsters.pramhedonly.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"cradh", (object)this.allMonsters.cradh.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"fas", (object)this.allMonsters.fas.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"spamfascurse", (object)this.allMonsters.spamfascurse.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"fasaman", (object)this.allMonsters.fasamancrystals.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"spellsilenced", (object)this.allMonsters.spellsilenced.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"attack1", (object)this.allMonsters.attack1.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"attack2", (object)this.allMonsters.attack2.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"multi", (object)this.allMonsters.multi.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"pramh", (object)this.allMonsters.pramh.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"spampramh", (object)this.allMonsters.spampramh.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"attackafterpramh", (object)this.allMonsters.attackafterpramh.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"pramhbasherstarget", (object)this.allMonsters.pramhbasherstarget.Checked));
            }
            else
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"allMonstersExists", (object)false));
            if (this.MonstersByPlayer != null)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"MonsterByPlayerExists", (object)true));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"player_name", (object)this.MonstersByPlayer.myTarget));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"player_attack1type", this.MonstersByPlayer.attack1type.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"player_attack2type", this.MonstersByPlayer.attack2type.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"player_spellsilenced", (object)this.MonstersByPlayer.spellsilenced.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"player_attack1", (object)this.MonstersByPlayer.attack1.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"player_attack2", (object)this.MonstersByPlayer.attack2.Checked));
            }
            else
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"MonsterByPlayerExists", (object)false));
            if (this.Monsters != null)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"MonstersExists", (object)true));
                int count = 0;
                this.Client.targetmonster.ForEach((Action<TargetMonster>)(monster =>
               {
                   if (monster == null)
                       return;
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("monstersname" + count.ToString()), (object)monster.monstername.Text));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("targettype" + count.ToString()), monster.targettype.SelectedItem));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("fascursetargettype" + count.ToString()), monster.fascursetargettype.SelectedItem));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("attack1type" + count.ToString()), monster.attack1type.SelectedItem));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("attack2type" + count.ToString()), monster.attack2type.SelectedItem));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("pramhtype" + count.ToString()), monster.pramhtype.SelectedItem));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("fastype" + count.ToString()), monster.fastype.SelectedItem));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("cradhtype" + count.ToString()), monster.cradhtype.SelectedItem));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("ardedonly" + count.ToString()), (object)monster.ardedonly.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("fasedonly" + count.ToString()), (object)monster.fasedonly.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("pramhedonly" + count.ToString()), (object)monster.pramhedonly.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("ctd" + count.ToString()), (object)monster.ctd.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("diondonly" + count.ToString()), (object)monster.diondonly.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("cradh" + count.ToString()), (object)monster.cradh.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("fas" + count.ToString()), (object)monster.fas.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("spamfascurse" + count.ToString()), (object)monster.spamfascurse.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("fasaman" + count.ToString()), (object)monster.fasamancrystals.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("spellsilenced" + count.ToString()), (object)monster.spellsilenced.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("attack1" + count.ToString()), (object)monster.attack1.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("attack2" + count.ToString()), (object)monster.attack2.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("multi" + count.ToString()), (object)monster.multi.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("pramh" + count.ToString()), (object)monster.pramh.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("spampramh" + count.ToString()), (object)monster.spampramh.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("attackafterpramh" + count.ToString()), (object)monster.attackafterpramh.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("heal" + count.ToString()), (object)monster.heal.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("healvalue" + count.ToString()), (object)monster.healnum.Value));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("aite" + count.ToString()), (object)monster.aite.Checked));
                   ++count;
               }));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"MonsterCounter", (object)count.ToString()));
            }
            else
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"MonstersExists", (object)false));
            if (this.targetgroup != null)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"TargetGroupExists", (object)true));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_aitetype", this.targetgroup.aitetype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_fastype", this.targetgroup.fastype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_ioctype", this.targetgroup.ioctype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_ioccond", (object)this.targetgroup.iocgroupcond.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_micsleep", (object)this.targetgroup.micgroupdelay.Text));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_mdcspam", (object)this.targetgroup.mdcspam.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_mdcperfect", (object)this.targetgroup.mdcperfect.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_aitegroup", (object)this.targetgroup.aitegroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_fasplayer", (object)this.targetgroup.fasplayergroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_beanngroup", (object)this.targetgroup.beanngroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_fasdeireas", (object)this.targetgroup.fasdeireasgroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_arm", (object)this.targetgroup.armachdgroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_creag", (object)this.targetgroup.creagneartgroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_lifearrow", (object)this.targetgroup.lifearrowgroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_vineyard", (object)this.targetgroup.vineyard.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_vinebefore", (object)this.targetgroup.vinebeforespiorad.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_aodall", (object)this.targetgroup.aodallgroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_aosuain", (object)this.targetgroup.aosuaingroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_aopuinsein", (object)this.targetgroup.aopuinseingroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_aocurse", (object)this.targetgroup.aocursesgroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_ignorebardo", (object)this.targetgroup.ignorebardogroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_bc", (object)this.targetgroup.beagcradhgroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_healanim", (object)this.targetgroup.healanim.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_ioc", (object)this.targetgroup.iocgroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_mic", (object)this.targetgroup.micgroup.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_backupmic", (object)this.targetgroup.backupmic.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_backupmicname", (object)this.targetgroup.backupmicname.Text));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"group_reflection", (object)this.targetgroup.reflection.Checked));
            }
            else
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"TargetGroupExists", (object)false));
            if (this.allalts != null)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"AltsExists", (object)true));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_aitetype", this.allalts.aitetype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_fastype", this.allalts.fastype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_ioctype", this.allalts.ioctype.SelectedItem));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_ioccond", (object)this.allalts.iocaltscond.Value));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_mdcperfect", (object)this.allalts.dionalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_aitegroup", (object)this.allalts.aitealts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_fasplayer", (object)this.allalts.fasplayeralts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_beanngroup", (object)this.allalts.beannalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_fasdeireas", (object)this.allalts.fasdeireasalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_arm", (object)this.allalts.armachdalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_creag", (object)this.allalts.creagneartalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_aosuain", (object)this.allalts.aosuainalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_aopuinsein", (object)this.allalts.aopuinseinalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_aocurse", (object)this.allalts.aocursesalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_ignorebardo", (object)this.allalts.ignorebardoalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_bc", (object)this.allalts.beagcradhalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_regen", (object)this.allalts.regenalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_ca", (object)this.allalts.caalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_ioc", (object)this.allalts.iocalts.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_lyliac", (object)this.allalts.lyliacplayer.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_lyliaccond", (object)this.allalts.lyliacplayercond.Text));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_vineyard", (object)this.allalts.vineyard.Checked));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"alts_vineyardcond", (object)this.allalts.vineyardcond.Text));
            }
            else
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"AltsExists", (object)false));
            if (this.Client.targetplayer.Count > 0)
            {
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"PlayersExists", (object)true));
                int playerscount = 0;
                this.Client.targetplayer.ForEach((Action<targetPlayer>)(player =>
               {
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_aitetype" + playerscount.ToString()), player.aitetype.SelectedItem));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_fastype" + playerscount.ToString()), player.fastype.SelectedItem));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_ioctype" + playerscount.ToString()), player.ioctype.SelectedItem));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_ioccond" + playerscount.ToString()), (object)player.iocplayercond.Value));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_mdclowmp" + playerscount.ToString()), (object)player.mdclowmp.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_mdclowmpnum" + playerscount.ToString()), (object)player.mdclowmpNum.Text));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_mdcperfect" + playerscount.ToString()), (object)player.dionplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_aitegroup" + playerscount.ToString()), (object)player.aiteplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_fasplayer" + playerscount.ToString()), (object)player.fasplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_beanngroup" + playerscount.ToString()), (object)player.beannplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_fasdeireas" + playerscount.ToString()), (object)player.fasdeireasplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_arm" + playerscount.ToString()), (object)player.armachdplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_creag" + playerscount.ToString()), (object)player.creagneartplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_aosuain" + playerscount.ToString()), (object)player.aosuainplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_aopuinsein" + playerscount.ToString()), (object)player.aopuinseinplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_aocurse" + playerscount.ToString()), (object)player.aocursesplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_bc" + playerscount.ToString()), (object)player.beagcradhplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_regen" + playerscount.ToString()), (object)player.regenplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_ca" + playerscount.ToString()), (object)player.caplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_ioc" + playerscount.ToString()), (object)player.iocplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_lyliac" + playerscount.ToString()), (object)player.lyliacplayer.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_lyliaccond" + playerscount.ToString()), (object)player.lyliacplayercond.Text));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_vineyard" + playerscount.ToString()), (object)player.vineyard.Checked));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("players_vineyardcond" + playerscount.ToString()), (object)player.vineyardcond.Text));
                   doc.Element((XName)"Settings").Add((object)new XElement((XName)("PlayerName" + playerscount.ToString()), (object)player.playername.Text));
                   ++playerscount;
               }));
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"PlayersCount", (object)playerscount.ToString()));
            }
            else
                doc.Element((XName)"Settings").Add((object)new XElement((XName)"PlayersExists", (object)false));
            doc.Element((XName)"Settings").Add((object)new XElement((XName)"Player"));
            if (!OnDC)
            {
                string empty = string.Empty;
                string lower = (!(toSave == "") ? this.RemoveSpecialChars(toSave) : this.RemoveSpecialChars(this.newtemplate_name.Text)).ToLower();
                if (!lower.Equals(""))
                {
                    if (Directory.Exists(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower()))
                    {
                        if (File.Exists(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\" + lower + ".xml"))
                            this.Client.SendMessage("Template updated: " + lower, "grey", false);
                        else
                            this.Client.SendMessage("New template created: " + lower, "grey", false);
                        doc.Save(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\" + lower + ".xml");
                    }
                    else
                    {
                        this.Client.SendMessage("New template created: " + lower, "grey", false);
                        Directory.CreateDirectory(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower());
                        doc.Save(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\" + lower + ".xml");
                    }
                    this.loadedtemplate.Text = lower;
                }
                else
                    this.Client.SendMessage("The template name you input was invalid.", "red", false);
                this.LoadTemplates();
            }
            else if (Directory.Exists(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower()))
            {
                doc.Save(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\" + this.Client.Name.ToLower() + "_dc.xml");
            }
            else
            {
                Directory.CreateDirectory(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower());
                doc.Save(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\" + this.Client.Name.ToLower() + "_dc.xml");
            }
        }

        public void LoadTemplate(string toLoad = "", bool AfterRelog = false)
        {
            bool flag = false;
            string empty1 = string.Empty;
            string str1;
            if (!AfterRelog)
            {
                if (!this.Client.pause)
                    flag = true;
                this.Client.pause = true;
                this.btnPlay.Enabled = true;
                this.btnStop.Enabled = false;
                str1 = !(toLoad == "") ? toLoad : this.template_lists.SelectedItem.ToString().ToLower();
            }
            else
                str1 = this.Client.Name.ToLower() + "_dc";
            if (Directory.Exists(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower()))
            {
                if (File.Exists(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\" + str1 + ".xml"))
                {
                    XDocument xdocument = XDocument.Load(Program.StartupPath + "\\Settings\\" + this.Client.Name.ToLower() + "\\" + str1 + ".xml");
                    if (AfterRelog)
                    {
                        if (xdocument.Element((XName)"Settings").Element((XName)"attirebool") != null)
                            this.Client.claimbeachattire = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"attirebool").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"AutoWalkState") != null)
                            this.Client.autowalkon = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"AutoWalkState").Value);
                        if (this.Client.autowalkon)
                            this.autowalker_button.Text = "Stop";
                        else
                            this.autowalker_button.Text = "Start";
                        if (xdocument.Element((XName)"Settings").Element((XName)"AutoWalkDestA") != null)
                            this.autowalker_locales.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"AutoWalkDestA").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"AutoWalkDestB") != null)
                            this.walklocaleslist.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"AutoWalkDestB").Value;
                    }
                    this.Client.targetmonster.ForEach((Action<TargetMonster>)(monster =>
                   {
                       if (this.InvokeRequired)
                           this.Invoke((Action)(() => monster.Dispose()));
                       else
                           monster.Dispose();
                       monster = (TargetMonster)null;
                   }));
                    this.Client.targetmonster.Clear();
                    if (this.MonstersByPlayer != null)
                    {
                        if (this.InvokeRequired)
                            this.Invoke((Action)(() => this.MonstersByPlayer.Dispose()));
                        else
                            this.MonstersByPlayer.Dispose();
                        this.MonstersByPlayer = (targetMonsterbyPlayer)null;
                    }
                    if (this.allMonsters != null)
                    {
                        if (this.InvokeRequired)
                            this.Invoke((Action)(() => this.allMonsters.Dispose()));
                        else
                            this.allMonsters.Dispose();
                        this.allMonsters = (TargetAllMonster)null;
                    }
                    this.Client.targetplayer.ForEach((Action<targetPlayer>)(player =>
                   {
                       if (this.InvokeRequired)
                           this.Invoke((Action)(() => player.Dispose()));
                       else
                           player.Dispose();
                       player = (targetPlayer)null;
                   }));
                    this.Client.targetplayer.Clear();
                    this.Client.alts.Clear();
                    if (this.allalts != null)
                    {
                        if (this.InvokeRequired)
                            this.Invoke((Action)(() => this.allalts.Dispose()));
                        else
                            this.allalts.Dispose();
                        this.allalts = (targetAlts)null;
                    }
                    if (this.targetgroup != null)
                    {
                        if (this.InvokeRequired)
                            this.Invoke((Action)(() => this.targetgroup.Dispose()));
                        else
                            this.targetgroup.Dispose();
                        this.targetgroup = (targetGroup)null;
                    }
                    this.Monsters = (TargetMonster)null;
                    this.Players = (targetPlayer)null;
                    this.newalts.Enabled = true;
                    this.newallgrouped.Enabled = true;
                    this.newallmonsters.Enabled = true;
                    if (xdocument.Element((XName)"Settings").Element((XName)"Follow") != null)
                        this.followplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"Follow").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"Follow_target") != null)
                        this.followtarget.Text = xdocument.Element((XName)"Settings").Element((XName)"Follow_target").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"Distance") != null)
                        this.followdist.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"Distance").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"castwhilefollow") != null)
                        this.castwhilefollow.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"castwhilefollow").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"mediumwalk") != null)
                        this.mediumwalk.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"mediumwalk").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"fastwalk") != null)
                        this.fastwalk.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"fastwalk").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"WalkSpeed") != null)
                        this.walksettings.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"WalkSpeed").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"IgnoreWalkAll") != null)
                        this.ignorewalkall.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"IgnoreWalkAll").Value);
                    this.Client.TempRegions.Clear();
                    this.Client.Previous.Clear();
                    if (xdocument.Element((XName)"Settings").Element((XName)"NumberOfMaps") != null)
                    {
                        for (int index1 = 0; index1 < (int)Convert.ToUInt16(xdocument.Element((XName)"Settings").Element((XName)"NumberOfMaps").Value); ++index1)
                        {
                            MapNum mapNum = new MapNum();
                            mapNum.Number = (int)Convert.ToUInt16(xdocument.Element((XName)"Settings").Element((XName)("map" + (object)index1)).Element((XName)"MapNum").Value);
                            this.Client.TempRegions.Add(mapNum.Number, mapNum);
                            for (int index2 = 0; index2 < (int)Convert.ToUInt16(xdocument.Element((XName)"Settings").Element((XName)("map" + (object)index1)).Element((XName)"Count").Value); ++index2)
                            {
                                Npc npc = new Npc();
                                string[] strArray = xdocument.Element((XName)"Settings").Element((XName)("map" + (object)index1)).Element((XName)("Location" + (object)index2)).Value.Split(',');
                                Location key = new Location(int.Parse(strArray[0]), int.Parse(strArray[1]));
                                string str2 = xdocument.Element((XName)"Settings").Element((XName)("map" + (object)index1)).Element((XName)("Point" + (object)index2)).Value;
                                this.Client.TempRegions[mapNum.Number].Regions.Add(key, str2);
                            }
                        }
                    }
                    if (!this.Client.TempRegions.ContainsKey(this.Client.MapInfo.Number))
                    {
                        MapNum mapNum = new MapNum();
                        mapNum.Number = this.Client.MapInfo.Number;
                        this.Client.TempRegions.Add(mapNum.Number, mapNum);
                    }
                    this.Wayregion.waitonplayerslistbox.Items.Clear();
                    if (xdocument.Element((XName)"Settings").Element((XName)"WaitOnPlayers") != null)
                        this.Wayregion.waitonplayers.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"WaitOnPlayers").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"WaitOnPlayersCount") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"WaitOnPlayersCount").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("WaitOnPlayer" + (object)index)).Value != string.Empty && !this.Wayregion.waitonplayerslistbox.Items.Contains((object)xdocument.Element((XName)"Settings").Element((XName)("WaitOnPlayer" + (object)index)).Value))
                                this.Wayregion.waitonplayerslistbox.Items.Add((object)xdocument.Element((XName)"Settings").Element((XName)("WaitOnPlayer" + (object)index)).Value);
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"UseWaypoints") != null)
                        this.wayregionson.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"UseWaypoints").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"haltwalknonfriends") != null)
                        this.haltwalknonfriends.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"haltwalknonfriends").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"walkclosebyonly") != null)
                        this.walkclosebyonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"walkclosebyonly").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"walktowards") != null)
                        this.walktowards.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"walktowards").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"chattimestamp") != null)
                        this.chattimestamp.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"chattimestamp").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"all5classes") != null)
                        this.all5classes.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"all5classes").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"recorditemdata") != null)
                        this.recorditemdata.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"recorditemdata").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"friendspeak") != null)
                        this.friendspeak.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"friendspeak").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"MonsterID") != null)
                        this.usemonsterid.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"MonsterID").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"UseMonster") != null)
                        this.usemonster.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"UseMonster").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"DisableSpells") != null)
                        this.disableallspell.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"DisableSpells").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"DisableBody") != null)
                        this.disableallbody.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"DisableBody").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"disableitemsnstuff") != null)
                        this.disableitemsnstuff.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"disableitemsnstuff").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"Slash_commands") != null)
                        this.slash_commands.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"Slash_commands").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"Auto_Kom") != null)
                        this.autobuykoms.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"Auto_Kom").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"Auto_Hem") != null)
                        this.autobuyhems.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"Auto_Hem").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"No_wall") != null)
                        this.nowalls.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"No_wall").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"disablesnow") != null)
                        this.disablesnow.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"disablesnow").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"monitords") != null)
                        this.monitords.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"monitords").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"TrackCurse") != null)
                        this.monitorcurses.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"TrackCurse").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"TrackAiteFas") != null)
                        this.monitorspells.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"TrackAiteFas").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"TrackDion") != null)
                        this.monitordion.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"TrackDion").Value);
                    if (AfterRelog)
                    {
                        if (xdocument.Element((XName)"Settings").Element((XName)"dojo") != null)
                            this.dojo.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"dojo").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"macrospell") != null)
                            this.MacroOptions.macrospell.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"macrospell").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"macroskill") != null)
                            this.MacroOptions.macroskill.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"macroskill").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"macroassail") != null)
                            this.MacroOptions.macroassail.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"macroassail").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"macrohemcrasher") != null)
                            this.MacroOptions.macrohemcrasher.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"macrohemcrasher").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"macropoisoncrasher") != null)
                            this.MacroOptions.macropoisoncrasher.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"macropoisoncrasher").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"useskillbonus") != null)
                            this.useskillbonus.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"useskillbonus").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"altar") != null)
                            this.altar.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"altar").Value);
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"labordays") != null)
                        this.labordays.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"labordays").Value);
                    this.ComboOptions.combo1box.Text = string.Empty;
                    this.ComboOptions.combo2box.Text = string.Empty;
                    this.ComboOptions.combo3box.Text = string.Empty;
                    this.ComboOptions.combo4box.Text = string.Empty;
                    this.ComboOptions.combo5box.Text = string.Empty;
                    this.ComboOptions.combo6box.Text = string.Empty;
                    this.ComboOptions.combo7box.Text = string.Empty;
                    this.ComboOptions.combo8box.Text = string.Empty;
                    this.ComboOptions.combo9box.Text = string.Empty;
                    this.ComboOptions.combo10box.Text = string.Empty;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo1length") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"combo1length").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("combo1box" + (object)index)).Value != string.Empty)
                            {
                                TextBox combo1box = this.ComboOptions.combo1box;
                                combo1box.Text = combo1box.Text + ClientTab.CapitalizeWords(xdocument.Element((XName)"Settings").Element((XName)("combo1box" + (object)index)).Value) + Environment.NewLine;
                            }
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo2length") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"combo2length").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("combo2box" + (object)index)).Value != string.Empty)
                            {
                                TextBox combo2box = this.ComboOptions.combo2box;
                                combo2box.Text = combo2box.Text + ClientTab.CapitalizeWords(xdocument.Element((XName)"Settings").Element((XName)("combo2box" + (object)index)).Value) + Environment.NewLine;
                            }
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo3length") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"combo3length").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("combo3box" + (object)index)).Value != string.Empty)
                            {
                                TextBox combo3box = this.ComboOptions.combo3box;
                                combo3box.Text = combo3box.Text + ClientTab.CapitalizeWords(xdocument.Element((XName)"Settings").Element((XName)("combo3box" + (object)index)).Value) + Environment.NewLine;
                            }
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo4length") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"combo4length").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("combo4box" + (object)index)).Value != string.Empty)
                            {
                                TextBox combo4box = this.ComboOptions.combo4box;
                                combo4box.Text = combo4box.Text + ClientTab.CapitalizeWords(xdocument.Element((XName)"Settings").Element((XName)("combo4box" + (object)index)).Value) + Environment.NewLine;
                            }
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo5length") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"combo5length").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("combo5box" + (object)index)).Value != string.Empty)
                            {
                                TextBox combo5box = this.ComboOptions.combo5box;
                                combo5box.Text = combo5box.Text + ClientTab.CapitalizeWords(xdocument.Element((XName)"Settings").Element((XName)("combo5box" + (object)index)).Value) + Environment.NewLine;
                            }
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo6length") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"combo6length").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("combo6box" + (object)index)).Value != string.Empty)
                            {
                                TextBox combo6box = this.ComboOptions.combo6box;
                                combo6box.Text = combo6box.Text + ClientTab.CapitalizeWords(xdocument.Element((XName)"Settings").Element((XName)("combo6box" + (object)index)).Value) + Environment.NewLine;
                            }
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo7length") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"combo7length").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("combo7box" + (object)index)).Value != string.Empty)
                            {
                                TextBox combo7box = this.ComboOptions.combo7box;
                                combo7box.Text = combo7box.Text + ClientTab.CapitalizeWords(xdocument.Element((XName)"Settings").Element((XName)("combo7box" + (object)index)).Value) + Environment.NewLine;
                            }
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo8length") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"combo8length").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("combo8box" + (object)index)).Value != string.Empty)
                            {
                                TextBox combo8box = this.ComboOptions.combo8box;
                                combo8box.Text = combo8box.Text + ClientTab.CapitalizeWords(xdocument.Element((XName)"Settings").Element((XName)("combo8box" + (object)index)).Value) + Environment.NewLine;
                            }
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo9length") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"combo9length").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("combo9box" + (object)index)).Value != string.Empty)
                            {
                                TextBox combo9box = this.ComboOptions.combo9box;
                                combo9box.Text = combo9box.Text + ClientTab.CapitalizeWords(xdocument.Element((XName)"Settings").Element((XName)("combo9box" + (object)index)).Value) + Environment.NewLine;
                            }
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo10length") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"combo10length").Value); ++index)
                        {
                            if (xdocument.Element((XName)"Settings").Element((XName)("combo10box" + (object)index)).Value != string.Empty)
                            {
                                TextBox combo10box = this.ComboOptions.combo10box;
                                combo10box.Text = combo10box.Text + ClientTab.CapitalizeWords(xdocument.Element((XName)"Settings").Element((XName)("combo10box" + (object)index)).Value) + Environment.NewLine;
                            }
                        }
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"usemacro1") != null)
                        this.ComboOptions.usemacro1.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usemacro1").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"usemacro2") != null)
                        this.ComboOptions.usemacro2.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usemacro2").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"usemacro3") != null)
                        this.ComboOptions.usemacro3.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usemacro3").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"usemacro4") != null)
                        this.ComboOptions.usemacro4.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usemacro4").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"usemacro5") != null)
                        this.ComboOptions.usemacro5.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usemacro5").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"usemacro6") != null)
                        this.ComboOptions.usemacro6.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usemacro6").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"usemacro7") != null)
                        this.ComboOptions.usemacro7.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usemacro7").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"usemacro8") != null)
                        this.ComboOptions.usemacro8.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usemacro8").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"usemacro9") != null)
                        this.ComboOptions.usemacro9.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usemacro9").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"usemacro10") != null)
                        this.ComboOptions.usemacro10.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usemacro10").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo1trigger") != null)
                        this.ComboOptions.combo1trigger.Text = xdocument.Element((XName)"Settings").Element((XName)"combo1trigger").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo2trigger") != null)
                        this.ComboOptions.combo2trigger.Text = xdocument.Element((XName)"Settings").Element((XName)"combo2trigger").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo3trigger") != null)
                        this.ComboOptions.combo3trigger.Text = xdocument.Element((XName)"Settings").Element((XName)"combo3trigger").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo4trigger") != null)
                        this.ComboOptions.combo4trigger.Text = xdocument.Element((XName)"Settings").Element((XName)"combo4trigger").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo5trigger") != null)
                        this.ComboOptions.combo5trigger.Text = xdocument.Element((XName)"Settings").Element((XName)"combo5trigger").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo6trigger") != null)
                        this.ComboOptions.combo6trigger.Text = xdocument.Element((XName)"Settings").Element((XName)"combo6trigger").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo7trigger") != null)
                        this.ComboOptions.combo7trigger.Text = xdocument.Element((XName)"Settings").Element((XName)"combo7trigger").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo8trigger") != null)
                        this.ComboOptions.combo8trigger.Text = xdocument.Element((XName)"Settings").Element((XName)"combo8trigger").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo9trigger") != null)
                        this.ComboOptions.combo9trigger.Text = xdocument.Element((XName)"Settings").Element((XName)"combo9trigger").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo10trigger") != null)
                        this.ComboOptions.combo10trigger.Text = xdocument.Element((XName)"Settings").Element((XName)"combo10trigger").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo1mod") != null)
                        this.ComboOptions.combo1mod.Text = xdocument.Element((XName)"Settings").Element((XName)"combo1mod").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo2mod") != null)
                        this.ComboOptions.combo2mod.Text = xdocument.Element((XName)"Settings").Element((XName)"combo2mod").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo3mod") != null)
                        this.ComboOptions.combo3mod.Text = xdocument.Element((XName)"Settings").Element((XName)"combo3mod").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo4mod") != null)
                        this.ComboOptions.combo4mod.Text = xdocument.Element((XName)"Settings").Element((XName)"combo4mod").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo5mod") != null)
                        this.ComboOptions.combo5mod.Text = xdocument.Element((XName)"Settings").Element((XName)"combo5mod").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo6mod") != null)
                        this.ComboOptions.combo6mod.Text = xdocument.Element((XName)"Settings").Element((XName)"combo6mod").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo7mod") != null)
                        this.ComboOptions.combo7mod.Text = xdocument.Element((XName)"Settings").Element((XName)"combo7mod").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo8mod") != null)
                        this.ComboOptions.combo8mod.Text = xdocument.Element((XName)"Settings").Element((XName)"combo8mod").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo9mod") != null)
                        this.ComboOptions.combo9mod.Text = xdocument.Element((XName)"Settings").Element((XName)"combo9mod").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo10mod") != null)
                        this.ComboOptions.combo10mod.Text = xdocument.Element((XName)"Settings").Element((XName)"combo10mod").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo1name") != null)
                        this.ComboOptions.combo1name.Text = xdocument.Element((XName)"Settings").Element((XName)"combo1name").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo2name") != null)
                        this.ComboOptions.combo2name.Text = xdocument.Element((XName)"Settings").Element((XName)"combo2name").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo3name") != null)
                        this.ComboOptions.combo3name.Text = xdocument.Element((XName)"Settings").Element((XName)"combo3name").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo4name") != null)
                        this.ComboOptions.combo4name.Text = xdocument.Element((XName)"Settings").Element((XName)"combo4name").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo5name") != null)
                        this.ComboOptions.combo5name.Text = xdocument.Element((XName)"Settings").Element((XName)"combo5name").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo6name") != null)
                        this.ComboOptions.combo6name.Text = xdocument.Element((XName)"Settings").Element((XName)"combo6name").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo7name") != null)
                        this.ComboOptions.combo7name.Text = xdocument.Element((XName)"Settings").Element((XName)"combo7name").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo8name") != null)
                        this.ComboOptions.combo8name.Text = xdocument.Element((XName)"Settings").Element((XName)"combo8name").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo9name") != null)
                        this.ComboOptions.combo9name.Text = xdocument.Element((XName)"Settings").Element((XName)"combo9name").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"combo10name") != null)
                        this.ComboOptions.combo10name.Text = xdocument.Element((XName)"Settings").Element((XName)"combo10name").Value;
                    this.ComboOptions.LoadCombos();
                    if (xdocument.Element((XName)"Settings").Element((XName)"UseMobbed") != null)
                        this.actonlyinmobs.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"UseMobbed").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"MobSize") != null)
                        this.mobsize.Value = (Decimal)Convert.ToInt32(xdocument.Element((XName)"Settings").Element((XName)"MobSize").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"MobRange") != null)
                        this.mobdistance.Value = (Decimal)Convert.ToInt32(xdocument.Element((XName)"Settings").Element((XName)"MobRange").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"NoLongerMobbed") != null)
                        this.nolongermobbed.Value = (Decimal)Convert.ToInt32(xdocument.Element((XName)"Settings").Element((XName)"NoLongerMobbed").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"nolure") != null)
                        this.nolure.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"nolure").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"WaitOnMonsters") != null)
                        this.waitonmonsters.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"WaitOnMonsters").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"LureWithLamh") != null)
                        this.lurewithlamh.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"LureWithLamh").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"LureWithSpells") != null)
                        this.lurewithspells.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"LureWithSpells").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"LureSpell") != null)
                        this.lurespells.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"LureSpell").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"LureWithSkills") != null)
                        this.lurewithskills.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"LureWithSkills").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"onlylurewithmp") != null)
                        this.onlylurewithmp.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"onlylurewithmp").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"onlylurewithmpamount") != null)
                        this.onlylurewithmpamount.Text = xdocument.Element((XName)"Settings").Element((XName)"onlylurewithmpamount").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"openveltchest") != null)
                        this.openveltchest.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"openveltchest").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"openveltchestgold") != null)
                        this.openveltchestgold.Text = xdocument.Element((XName)"Settings").Element((XName)"openveltchestgold").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"reequiparmor") != null)
                        this.reequiparmor.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"reequiparmor").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"openmedchest") != null)
                        this.openmedchest.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"openmedchest").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"throwtotems") != null)
                        this.throwtotems.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"throwtotems").Value);
                    if (AfterRelog)
                    {
                        if (xdocument.Element((XName)"Settings").Element((XName)"useexpgem") != null)
                            this.useexpgem.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"useexpgem").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"expgemmp") != null)
                            this.expgemmp.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"expgemmp").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"UseEXPAPBonus") != null)
                            this.expapbonus.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"UseEXPAPBonus").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"ABRune") != null)
                            this.abrune.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"ABRune").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"XPShroom") != null)
                            this.xpshroom.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"XPShroom").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"destroytonics") != null)
                            this.destroytonics.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"destroytonics").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"uncheckloot") != null)
                            this.uncheckloot.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"uncheckloot").Value);
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"respondflower") != null)
                        this.respondflower.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"respondflower").Value);
                    if (AfterRelog)
                    {
                        if (xdocument.Element((XName)"Settings").Element((XName)"reactdelay") != null)
                            this.reactdelaya.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"reactdelay").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"reactdelayb") != null)
                            this.reactdelayb.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"reactdelayb").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"lootdelaya") != null)
                            this.lootdelaya.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"lootdelaya").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"lootdelayb") != null)
                            this.lootdelayb.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"lootdelayb").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"newtargetdelaya") != null)
                            this.newtargetdelaya.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"newtargetdelaya").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"newtargetdelayb") != null)
                            this.newtargetdelayb.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"newtargetdelayb").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"switchtargetdelaya") != null)
                            this.switchtargetdelaya.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"switchtargetdelaya").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"switchtargetdelayb") != null)
                            this.switchtargetdelayb.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"switchtargetdelayb").Value);
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"redaislings") != null)
                        this.redaislings.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"redaislings").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"walktored") != null)
                        this.walktored.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"walktored").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"loot") != null)
                        this.looton.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"loot").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"walktoloot") != null)
                        this.walktoloot.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"walktoloot").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"lootlocale") != null)
                        this.lootlocale.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"lootlocale").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"potion") != null)
                        this.potion.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"potion").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"potioncond") != null)
                        this.potioncond.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"potioncond").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"mantidscent") != null)
                        this.mantidscent.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"mantidscent").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"assassinscroll") != null)
                        this.assassinscroll.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"assassinscroll").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"icebottle") != null)
                        this.icebottle.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"icebottle").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"elemusmount") != null)
                        this.elemusmount.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"elemusmount").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"fungusbeetle") != null)
                        this.fungusbeetleextract.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"fungusbeetle").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"dragonsfire") != null)
                        this.dragonsfire.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"dragonsfire").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"dragonsscale") != null)
                        this.dragonsscale.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"dragonsscale").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"musclestimulant") != null)
                        this.musclestimulant.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"musclestimulant").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"nervestimulant") != null)
                        this.nervestimulant.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"nervestimulant").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"wakescroll") != null)
                        this.wakescroll.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"wakescroll").Value);
                    this.HideTrinketOptions.vanishingelixir.Checked = false;
                    if (xdocument.Element((XName)"Settings").Element((XName)"vanishingelixer") != null)
                        this.HideTrinketOptions.vanishingelixir.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"vanishingelixer").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"hideallgroup") != null)
                        this.HideTrinketOptions.hideallgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"hideallgroup").Value);
                    this.HideTrinketOptions.namelist.Items.Clear();
                    if (xdocument.Element((XName)"Settings").Element((XName)"vanishingelixercount") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"vanishingelixercount").Value); ++index)
                            this.HideTrinketOptions.namelist.Items.Add((object)xdocument.Element((XName)"Settings").Element((XName)("vanishingelixerlistbox" + (object)index)).Value);
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"iditems") != null)
                        this.iditems.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"iditems").Value);
                    this.dropitemson.Checked = false;
                    if (xdocument.Element((XName)"Settings").Element((XName)"dropitems") != null)
                        this.dropitemson.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"dropitems").Value);
                    this.dropitemslist.Items.Clear();
                    if (xdocument.Element((XName)"Settings").Element((XName)"dropitemlistlength") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"dropitemlistlength").Value); ++index)
                            this.dropitemslist.Items.Add((object)xdocument.Element((XName)"Settings").Element((XName)("dropitemslistbox" + (object)index)).Value);
                    }
                    this.autodepositon.Checked = false;
                    if (xdocument.Element((XName)"Settings").Element((XName)"autodeposit") != null)
                        this.autodepositon.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"autodeposit").Value);
                    this.autodepositlistbox.Items.Clear();
                    if (xdocument.Element((XName)"Settings").Element((XName)"autodepositlistlength") != null)
                    {
                        for (int index = 0; (long)index < (long)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"autodepositlistlength").Value); ++index)
                            this.autodepositlistbox.Items.Add((object)xdocument.Element((XName)"Settings").Element((XName)("autodepositlistbox" + (object)index)).Value);
                    }
                    if (xdocument.Element((XName)"Settings").Element((XName)"aopuinseinpriority") != null)
                        this.SpellPriority.aopuinsein.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"aopuinseinpriority").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"aocradhspriority") != null)
                        this.SpellPriority.aocradhs.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"aocradhspriority").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"bcpriority") != null)
                        this.SpellPriority.beagcradh.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"bcpriority").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"wakescrollpriority") != null)
                        this.SpellPriority.wakescroll.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"wakescrollpriority").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"dispriority") != null)
                        this.SpellPriority.disenchanter.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"dispriority").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"dfmonsters") != null)
                        this.dfmonsters.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"dfmonsters").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"asgallmonsters") != null)
                        this.asgallmonsters.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"asgallmonsters").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfca") != null)
                        this.selfca.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfca").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfregen") != null)
                        this.selfregen.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfregen").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfmist") != null)
                        this.selfmist.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfmist").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfcreagneart") != null)
                        this.selfcreagneart.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfcreagneart").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selffasdeireas") != null)
                        this.selffasdeireas.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selffasdeireas").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfbean") != null)
                        this.selfbean.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfbean").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selffastype") != null)
                        this.selffastype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"selffastype").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"selffas") != null)
                        this.selffas.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selffas").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfaitetype") != null)
                        this.selfaitetype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"selfaitetype").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfaite") != null)
                        this.selfaite.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfaite").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"staffswitch") != null)
                        this.staffswitch.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"staffswitch").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"diontype") != null)
                        this.diontype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"diontype").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"dion_aosith") != null)
                        this.dion_aosith.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"dion_aosith").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"dion_enemiesnext") != null)
                        this.dion_enemiesnext.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"dion_enemiesnext").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"dion_enemiesonscreen") != null)
                        this.dion_enemiesonscreen.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"dion_enemiesonscreen").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"dion_lowhp") != null)
                        this.dion_lowhp.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"dion_lowhp").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"dion_hpcond") != null)
                        this.dion_hpcond.Value = (Decimal)Convert.ToUInt16(xdocument.Element((XName)"Settings").Element((XName)"dion_hpcond").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"dion_enemiesnextcount") != null)
                        this.dion_enemiesnextcount.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"dion_enemiesnextcount").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"dion_enemiesonscreenvalue") != null)
                        this.dion_enemiesonscreenvalue.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"dion_enemiesonscreenvalue").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"fs") != null)
                        this.fs.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"fs").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"fscond") != null)
                        this.fscond.Text = xdocument.Element((XName)"Settings").Element((XName)"fscond").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"iocselfcond") != null)
                        this.iocselfcond.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"iocselfcond").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"ioctype") != null)
                        this.ioctype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"ioctype").Value;
                    if (xdocument.Element((XName)"Settings").Element((XName)"iocself") != null)
                        this.iocself.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"iocself").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"druidform") != null)
                        this.druidform.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"druidform").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfhide") != null)
                        this.selfhide.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfhide").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"disenchanter") != null)
                        this.disenchanter.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"disenchanter").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfarm") != null)
                        this.selfarm.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfarm").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfbc") != null)
                        this.selfbc.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfbc").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"aocurse") != null)
                        this.aocurse.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"aocurse").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfaopuinsein") != null)
                        this.selfaopuinsein.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfaopuinsein").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"selfaosuain") != null)
                        this.selfaosuain.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"selfaosuain").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"bubblenorajo") != null)
                        this.bubblenorajo.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"bubblenorajo").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"halfcast") != null)
                        this.halfcast.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"halfcast").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"switchneck") != null)
                        this.switchneck.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"switchneck").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"equipweapon") != null)
                        this.equipweapon.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"equipweapon").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"equipshield") != null)
                        this.equipshield.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"equipshield").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"attackinfinitemr") != null)
                        this.attackinfinitemr.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"attackinfinitemr").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"assail") != null)
                        this.assail.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"assail").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"insectassail") != null)
                        this.insectassail.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"insectassail").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"walktomonster") != null)
                        this.walktomonster.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"walktomonster").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"skfasedonly") != null)
                        this.fasedonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"skfasedonly").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"skcursedonly") != null)
                        this.cursedonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"skcursedonly").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"skpramhedonly") != null)
                        this.pramhedonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"skpramhedonly").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"useskills") != null)
                        this.useskills.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"useskills").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"useskillshidden") != null)
                        this.useskillshidden.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"useskillshidden").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"useambush") != null)
                        this.useambush.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"useambush").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"usefrost") != null)
                        this.usefrost.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"usefrost").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"asrs") != null)
                        this.asrs.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"asrs").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"castbries") != null)
                        this.castbries.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"castbries").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"comboscroll") != null)
                        this.comboscroll.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"comboscroll").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"comboscrollnoshield") != null)
                        this.comboscrollnoshield.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"comboscrollnoshield").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"pf") != null)
                        this.pf.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"pf").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"pfmonsters") != null)
                        this.pfmonsters.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"pfmonsters").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"pd") != null)
                        this.pd.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"pd").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"skillgrouprange") != null)
                        this.skillgrouprange.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"skillgrouprange").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"skillgrouprangenum") != null)
                        this.skillgrouprangenum.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"skillgrouprangenum").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"attackleaderstarget") != null)
                        this.attackleaderstarget.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"attackleaderstarget").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"brieshits") != null)
                        this.brieshits.Value = Convert.ToDecimal(xdocument.Element((XName)"Settings").Element((XName)"brieshits").Value);
                    if (xdocument.Element((XName)"Settings").Element((XName)"briescantattack") != null)
                        this.briescantattack.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"briescantattack").Value);
                    if (Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"allMonstersExists").Value))
                    {
                        this.Invoke((Delegate)new ClientTab.MakeAllMonster(this.MakeAllMonsters));
                        if (xdocument.Element((XName)"Settings").Element((XName)"attackwithmp") != null)
                            this.allMonsters.onlyattackwithmp.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"attackwithmp").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"attackwithmpamount") != null)
                            this.allMonsters.onlyattackwithmpamount.Text = xdocument.Element((XName)"Settings").Element((XName)"attackwithmpamount").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"pndbeforecurse") != null)
                            this.allMonsters.pndbeforecurse.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"pndbeforecurse").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"pndlowhp") != null)
                            this.allMonsters.pndlowhp.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"pndlowhp").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"pndiond") != null)
                            this.allMonsters.pndiond.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"pndiond").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"groupmembersinrange") != null)
                            this.allMonsters.groupedmembers.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"groupmembersinrange").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"groupmembersrange") != null)
                            this.allMonsters.groupedmembersrange.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"groupmembersrange").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"spelllargestgroup") != null)
                            this.allMonsters.spelllargestgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"spelllargestgroup").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"spelllargestgroupnumber") != null)
                            this.allMonsters.spelllargestgroupnumber.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"spelllargestgroupnumber").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"ignoredistant") != null)
                            this.allMonsters.ignoredistant.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"ignoredistant").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"targettype") != null)
                            this.allMonsters.targettype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"targettype").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"fascursetargettype") != null)
                            this.allMonsters.fascursetargettype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"fascursetargettype").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"attack1type") != null)
                            this.allMonsters.attack1type.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"attack1type").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"attack2type") != null)
                            this.allMonsters.attack2type.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"attack2type").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"pramhtype") != null)
                            this.allMonsters.pramhtype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"pramhtype").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"fastype") != null)
                            this.allMonsters.fastype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"fastype").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"cradhtype") != null)
                            this.allMonsters.cradhtype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"cradhtype").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"ardedonly") != null)
                            this.allMonsters.ardedonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"ardedonly").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"fasedonly") != null)
                            this.allMonsters.fasedonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"fasedonly").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"ctd") != null)
                            this.allMonsters.ctd.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"ctd").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"diondonly") != null)
                            this.allMonsters.diondonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"diondonly").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"pramhedonly") != null)
                            this.allMonsters.pramhedonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"pramhedonly").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"cradh") != null)
                            this.allMonsters.cradh.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"cradh").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"fas") != null)
                            this.allMonsters.fas.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"fas").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"spamfascurse") != null)
                            this.allMonsters.spamfascurse.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"spamfascurse").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"fasaman") != null)
                            this.allMonsters.fasamancrystals.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"fasaman").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"spellsilenced") != null)
                            this.allMonsters.spellsilenced.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"spellsilenced").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"attack1") != null)
                            this.allMonsters.attack1.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"attack1").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"attack2") != null)
                            this.allMonsters.attack2.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"attack2").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"multi") != null)
                            this.allMonsters.multi.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"multi").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"pramh") != null)
                            this.allMonsters.pramh.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"pramh").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"spampramh") != null)
                            this.allMonsters.spampramh.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"spampramh").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"attackafterpramh") != null)
                            this.allMonsters.attackafterpramh.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"attackafterpramh").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"pramhbasherstarget") != null)
                            this.allMonsters.pramhbasherstarget.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"pramhbasherstarget").Value);
                    }
                    if (Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"MonsterByPlayerExists").Value))
                    {
                        this.MonstersByPlayer = new targetMonsterbyPlayer(xdocument.Element((XName)"Settings").Element((XName)"player_name").Value, this);
                        this.spellMonsters.TabPages.Add((TabPage)this.MonstersByPlayer);
                        this.monsterexists.Visible = false;
                        this.newmonsterbyplayer.Checked = false;
                        this.newmonsterbyplayername.Text = "";
                        this.newmonsterbyplayername.Enabled = false;
                        this.newmonster.Checked = false;
                        this.newallmonsters.Checked = false;
                        this.createnewmonster.Enabled = false;
                        if (xdocument.Element((XName)"Settings").Element((XName)"player_attack1type") != null)
                            this.MonstersByPlayer.attack1type.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"player_attack1type").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"player_attack2type") != null)
                            this.MonstersByPlayer.attack2type.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"player_attack2type").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"player_name") != null)
                            this.MonstersByPlayer.myTarget = xdocument.Element((XName)"Settings").Element((XName)"player_name").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"player_spellsilenced") != null)
                            this.MonstersByPlayer.spellsilenced.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"player_spellsilenced").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"player_attack1") != null)
                            this.MonstersByPlayer.attack1.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"player_attack1").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"player_attack2") != null)
                            this.MonstersByPlayer.attack2.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"player_attack2").Value);
                    }
                    if (Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"MonstersExists").Value))
                    {
                        uint uint32 = Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"MonsterCounter").Value);
                        string themonstersname = string.Empty;
                        if (uint32 > 0U)
                        {
                            for (int index = 0; (long)index < (long)uint32; ++index)
                            {
                                themonstersname = xdocument.Element((XName)"Settings").Element((XName)("monstersname" + index.ToString())).Value;
                                this.Invoke((Action)(() => this.Monsters = new TargetMonster(themonstersname, this)));
                                this.Client.targetmonster.Add(this.Monsters);
                                this.newmonster.Checked = false;
                                this.newmonstername.Text = "";
                                this.monsterexists.Visible = false;
                                this.Monsters.monstername.Text = themonstersname;
                                if (xdocument.Element((XName)"Settings").Element((XName)("targettype" + index.ToString())) != null)
                                    this.Monsters.targettype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)("targettype" + index.ToString())).Value;
                                if (xdocument.Element((XName)"Settings").Element((XName)("fascursetargettype" + index.ToString())) != null)
                                    this.Monsters.fascursetargettype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)("fascursetargettype" + index.ToString())).Value;
                                if (xdocument.Element((XName)"Settings").Element((XName)("attack1type" + index.ToString())) != null)
                                    this.Monsters.attack1type.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)("attack1type" + index.ToString())).Value;
                                if (xdocument.Element((XName)"Settings").Element((XName)("attack2type" + index.ToString())) != null)
                                    this.Monsters.attack2type.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)("attack2type" + index.ToString())).Value;
                                if (xdocument.Element((XName)"Settings").Element((XName)("pramhtype" + index.ToString())) != null)
                                    this.Monsters.pramhtype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)("pramhtype" + index.ToString())).Value;
                                if (xdocument.Element((XName)"Settings").Element((XName)("fastype" + index.ToString())) != null)
                                    this.Monsters.fastype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)("fastype" + index.ToString())).Value;
                                if (xdocument.Element((XName)"Settings").Element((XName)("cradhtype" + index.ToString())) != null)
                                    this.Monsters.cradhtype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)("cradhtype" + index.ToString())).Value;
                                if (xdocument.Element((XName)"Settings").Element((XName)("ardedonly" + index.ToString())) != null)
                                    this.Monsters.ardedonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("ardedonly" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("fasedonly" + index.ToString())) != null)
                                    this.Monsters.fasedonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("fasedonly" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("pramhedonly" + index.ToString())) != null)
                                    this.Monsters.pramhedonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("pramhedonly" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("ctd" + index.ToString())) != null)
                                    this.Monsters.ctd.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("ctd" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("diondonly" + index.ToString())) != null)
                                    this.Monsters.diondonly.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("diondonly" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("cradh" + index.ToString())) != null)
                                    this.Monsters.cradh.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("cradh" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("fas" + index.ToString())) != null)
                                    this.Monsters.fas.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("fas" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("spamfascurse" + index.ToString())) != null)
                                    this.Monsters.spamfascurse.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("spamfascurse" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("fasaman" + index.ToString())) != null)
                                    this.Monsters.fasamancrystals.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("fasaman" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("spellsilenced" + index.ToString())) != null)
                                    this.Monsters.spellsilenced.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("spellsilenced" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("attack1" + index.ToString())) != null)
                                    this.Monsters.attack1.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("attack1" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("attack2" + index.ToString())) != null)
                                    this.Monsters.attack2.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("attack2" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("multi" + index.ToString())) != null)
                                    this.Monsters.multi.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("multi" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("pramh" + index.ToString())) != null)
                                    this.Monsters.pramh.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("pramh" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("spampramh" + index.ToString())) != null)
                                    this.Monsters.spampramh.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("spampramh" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("attackafterpramh" + index.ToString())) != null)
                                    this.Monsters.attackafterpramh.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("attackafterpramh" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("heal" + index.ToString())) != null)
                                    this.Monsters.heal.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("heal" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("healnum" + index.ToString())) != null)
                                    this.Monsters.healnum.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)("healnum" + index.ToString())).Value);
                                if (xdocument.Element((XName)"Settings").Element((XName)("aite" + index.ToString())) != null)
                                    this.Monsters.aite.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("aite" + index.ToString())).Value);
                            }
                        }
                    }
                    if (Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"TargetGroupExists").Value))
                    {
                        this.Invoke((Delegate)new ClientTab.MakeGroupTarget(this.CreateGroupTarget), (object)this);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_aitetype") != null)
                            this.targetgroup.aitetype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"group_aitetype").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_fastype") != null)
                            this.targetgroup.fastype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"group_fastype").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_ioctype") != null)
                            this.targetgroup.ioctype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"group_ioctype").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_ioccond") != null)
                            this.targetgroup.iocgroupcond.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"group_ioccond").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_micsleep") != null)
                            this.targetgroup.micgroupdelay.Text = xdocument.Element((XName)"Settings").Element((XName)"group_micsleep").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_mdcspam") != null)
                            this.targetgroup.mdcspam.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_mdcspam").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_mdcperfect") != null)
                            this.targetgroup.mdcperfect.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_mdcperfect").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_aitegroup") != null)
                            this.targetgroup.aitegroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_aitegroup").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_fasplayer") != null)
                            this.targetgroup.fasplayergroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_fasplayer").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_beanngroup") != null)
                            this.targetgroup.beanngroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_beanngroup").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_fasdeireas") != null)
                            this.targetgroup.fasdeireasgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_fasdeireas").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_arm") != null)
                            this.targetgroup.armachdgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_arm").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_creag") != null)
                            this.targetgroup.creagneartgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_creag").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_lifearrow") != null)
                            this.targetgroup.lifearrowgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_lifearrow").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_vineyard") != null)
                            this.targetgroup.vineyard.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_vineyard").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_vinebefore") != null)
                            this.targetgroup.vinebeforespiorad.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_vinebefore").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_aodall") != null)
                            this.targetgroup.aodallgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_aodall").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_aosuain") != null)
                            this.targetgroup.aosuaingroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_aosuain").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_aopuinsein") != null)
                            this.targetgroup.aopuinseingroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_aopuinsein").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_aocurse") != null)
                            this.targetgroup.aocursesgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_aocurse").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_ignorebardo") != null)
                            this.targetgroup.ignorebardogroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_ignorebardo").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_bc") != null)
                            this.targetgroup.beagcradhgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_bc").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_healanim") != null)
                            this.targetgroup.healanim.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_healanim").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_ioc") != null)
                            this.targetgroup.iocgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_ioc").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_mic") != null)
                            this.targetgroup.micgroup.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_mic").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_backupmic") != null)
                            this.targetgroup.backupmic.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_backupmic").Value);
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_backupmicname") != null)
                            this.targetgroup.backupmicname.Text = xdocument.Element((XName)"Settings").Element((XName)"group_backupmicname").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"group_reflection") != null)
                            this.targetgroup.reflection.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"group_reflection").Value);
                    }
                    if (Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"AltsExists").Value))
                    {
                        this.Invoke((Delegate)new ClientTab.MakeGroupTarget(this.MakeAlts), (object)this);
                        if (xdocument.Element((XName)"Settings").Element((XName)"alts_aitetype") != null)
                            this.allalts.aitetype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"alts_aitetype").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"alts_fastype") != null)
                            this.allalts.fastype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"alts_fastype").Value;
                        if (xdocument.Element((XName)"Settings").Element((XName)"alts_ioctype") != null)
                            this.allalts.ioctype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)"alts_ioctype").Value;
                        this.allalts.iocaltscond.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"alts_ioccond").Value);
                        this.allalts.dionalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_mdcperfect").Value);
                        this.allalts.aitealts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_aitegroup").Value);
                        this.allalts.fasplayeralts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_fasplayer").Value);
                        this.allalts.beannalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_beanngroup").Value);
                        this.allalts.fasdeireasalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_fasdeireas").Value);
                        this.allalts.armachdalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_arm").Value);
                        this.allalts.creagneartalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_creag").Value);
                        this.allalts.aosuainalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_aosuain").Value);
                        this.allalts.aopuinseinalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_aopuinsein").Value);
                        this.allalts.aocursesalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_aocurse").Value);
                        this.allalts.ignorebardoalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_ignorebardo").Value);
                        this.allalts.beagcradhalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_bc").Value);
                        this.allalts.regenalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_regen").Value);
                        this.allalts.caalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_ca").Value);
                        this.allalts.iocalts.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_ioc").Value);
                        this.allalts.lyliacplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_lyliac").Value);
                        this.allalts.lyliacplayercond.Text = Convert.ToString(xdocument.Element((XName)"Settings").Element((XName)"alts_lyliaccond").Value);
                        this.allalts.vineyard.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"alts_vineyard").Value);
                        this.allalts.vineyardcond.Text = Convert.ToString(xdocument.Element((XName)"Settings").Element((XName)"alts_vineyardcond").Value);
                    }
                    if (Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)"PlayersExists").Value))
                    {
                        uint uint32 = Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)"PlayersCount").Value);
                        string empty2 = string.Empty;
                        for (int index = 0; (long)index < (long)uint32; ++index)
                        {
                            this.Invoke((Delegate)new ClientTab.MakePlayers(this.MakeThePlayers), (object)xdocument.Element((XName)"Settings").Element((XName)("PlayerName" + (object)index)).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_aitetype" + index.ToString())) != null)
                                this.Players.aitetype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)("players_aitetype" + index.ToString())).Value;
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_fastype" + index.ToString())) != null)
                                this.Players.fastype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)("players_fastype" + index.ToString())).Value;
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_ioctype" + index.ToString())) != null)
                                this.Players.ioctype.SelectedItem = (object)xdocument.Element((XName)"Settings").Element((XName)("players_ioctype" + index.ToString())).Value;
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_ioccond" + index.ToString())) != null)
                                this.Players.iocplayercond.Value = (Decimal)Convert.ToUInt32(xdocument.Element((XName)"Settings").Element((XName)("players_ioccond" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_mdclowmp" + index.ToString())) != null)
                                this.Players.mdclowmp.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_mdclowmp" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_mdclowmpnum" + index.ToString())) != null)
                                this.Players.mdclowmpNum.Text = xdocument.Element((XName)"Settings").Element((XName)("players_mdclowmpnum" + index.ToString())).Value;
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_mdcperfect" + index.ToString())) != null)
                                this.Players.dionplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_mdcperfect" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_aitegroup" + index.ToString())) != null)
                                this.Players.aiteplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_aitegroup" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_fasplayer" + index.ToString())) != null)
                                this.Players.fasplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_fasplayer" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_beanngroup" + index.ToString())) != null)
                                this.Players.beannplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_beanngroup" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_fasdeireas" + index.ToString())) != null)
                                this.Players.fasdeireasplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_fasdeireas" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_arm" + index.ToString())) != null)
                                this.Players.armachdplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_arm" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_creag" + index.ToString())) != null)
                                this.Players.creagneartplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_creag" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_aosuain" + index.ToString())) != null)
                                this.Players.aosuainplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_aosuain" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_aopuinsein" + index.ToString())) != null)
                                this.Players.aopuinseinplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_aopuinsein" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_aocurse" + index.ToString())) != null)
                                this.Players.aocursesplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_aocurse" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_bc" + index.ToString())) != null)
                                this.Players.beagcradhplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_bc" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_regen" + index.ToString())) != null)
                                this.Players.regenplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_regen" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_ca" + index.ToString())) != null)
                                this.Players.caplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_ca" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_ioc" + index.ToString())) != null)
                                this.Players.iocplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_ioc" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_lyliac" + index.ToString())) != null)
                                this.Players.lyliacplayer.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_lyliac" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_lyliaccond" + index.ToString())) != null)
                                this.Players.lyliacplayercond.Text = xdocument.Element((XName)"Settings").Element((XName)("players_lyliaccond" + index.ToString())).Value;
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_vineyard" + index.ToString())) != null)
                                this.Players.vineyard.Checked = Convert.ToBoolean(xdocument.Element((XName)"Settings").Element((XName)("players_vineyard" + index.ToString())).Value);
                            if (xdocument.Element((XName)"Settings").Element((XName)("players_vineyardcond" + index.ToString())) != null)
                                this.Players.vineyardcond.Text = xdocument.Element((XName)"Settings").Element((XName)("players_vineyardcond" + index.ToString())).Value;
                            this.Invoke((Delegate)new ClientTab.MakePlayerTargets(this.MakePlayerTarget), (object)this.Players);
                        }
                    }
                    if (!AfterRelog)
                    {
                        this.Client.SendMessage("Template loaded: " + str1, "grey", false);
                        this.loadedtemplate.Text = str1;
                    }
                }
                else if (!str1.Equals("Default") && !AfterRelog)
                    this.Client.SendMessage("The template you requested, " + str1 + ", does not exist.", "red", false);
            }
            if (!flag)
                return;
            this.Client.pause = false;
            this.btnPlay.Enabled = false;
            this.btnStop.Enabled = true;
        }

        private void calc_exp_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.calc_exp.Checked && !this.calc_ap.Checked && !this.calc_gold.Checked)
            {
                this.ResetCalc();
                this.calc_toggle.Text = "Start";
                this.calc_toggle.Enabled = false;
            }
            else
                this.calc_toggle.Enabled = true;
        }

        private void calc_ap_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.calc_exp.Checked && !this.calc_ap.Checked && !this.calc_gold.Checked)
            {
                this.ResetCalc();
                this.calc_toggle.Text = "Start";
                this.calc_toggle.Enabled = false;
            }
            else
                this.calc_toggle.Enabled = true;
        }

        private void calc_gold_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.calc_exp.Checked && !this.calc_ap.Checked && !this.calc_gold.Checked)
            {
                this.ResetCalc();
                this.calc_toggle.Text = "Start";
                this.calc_toggle.Enabled = false;
            }
            else
                this.calc_toggle.Enabled = true;
        }

        private void calc_toggle_Click(object sender, EventArgs e)
        {
            if (this.calc_toggle.Text == "Start")
                this.StartCalc();
            else
                this.StopCalc();
        }

        private void calc_reset_Click(object sender, EventArgs e)
        {
            this.ResetCalc();
        }

        public void Update_Calculator(object sender, EventArgs e)
        {
            if (this.apcounter == 600.0)
            {
                if (this.calc_message.Checked)
                    this.Calculator_Message();
                this.apcounter = 0.0;
            }
            this.apcounter += 20.0;
            this.totaltime += 20.0;
        }

        public void Calculator_Message()
        {
            if (this == null || this.Client == null || this.Client.Name == null || this.totaltime <= 0.0)
                return;
            this.endap = (double)this.Client.Statistics.AbilityExp;
            this.endexp = (double)this.Client.Statistics.Experience;
            this.endgold = (double)this.Client.Statistics.Gold;
            double num1 = this.endap - this.startap;
            double num2 = this.totaltime / 3600.0;
            double num3 = this.endexp - this.startexp;
            double num4 = this.totaltime / 3600.0;
            double num5 = this.endgold - this.startgold;
            double num6 = this.totaltime / 3600.0;
            string empty1 = string.Empty;
            string str1;
            if (this.totaltime < 60.0)
                str1 = "less than a minute";
            else if (this.totaltime < 600.0)
                str1 = "less than 10 minutes";
            else if (this.totaltime < 3600.0)
            {
                str1 = Math.Round(this.totaltime / 60.0, 0).ToString() + " minutes";
            }
            else
            {
                double num7 = Math.Floor(this.totaltime / 3600.0);
                double num8 = Math.Round(this.totaltime / 60.0 - num7 * 60.0, 0);
                str1 = num7.ToString() + " hours and " + (object)num8 + " minutes";
            }
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            double num9 = num1 / num2;
            string str5;
            if (num1 > 0.0)
            {
                num1 = Math.Round(num1, 2);
                str5 = "none";
            }
            else
                str5 = "null";
            if (num9 > 0.0)
            {
                num9 = Math.Round(num9, 2);
                str2 = "none";
            }
            else if (num9 == 0.0)
                str2 = "null";
            double num10 = num3 / num4;
            string str6;
            if (num3 > 0.0)
            {
                num3 = Math.Round(num3, 2);
                str6 = "none";
            }
            else
                str6 = "null";
            if (num10 > 0.0)
            {
                num10 = Math.Round(num10, 2);
                str3 = "none";
            }
            else if (num10 == 0.0)
                str3 = "null";
            double num11 = num5 / num6;
            string str7;
            if (num5 > 0.0)
            {
                num5 = Math.Round(num5, 2);
                str7 = "none";
            }
            else
                str7 = "null";
            if (num11 > 0.0)
            {
                num11 = Math.Round(num11, 2);
                str4 = "none";
            }
            else if (num11 == 0.0)
                str4 = "null";
            if (this.calc_ap.Checked || this.calc_exp.Checked || this.calc_gold.Checked)
                this.Client.SendMessage("You have been hunting for " + str1 + ".", "orange", false);
            if (this.calc_exp.Checked)
            {
                if (str6.Equals("billions", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("You have gained " + (object)num3 + "bil Exp", "orange", false);
                else if (str6.Equals("millions", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("You have gained " + (object)num3 + "mil Exp", "orange", false);
                else if (str6.Equals("thousands", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("You have gained " + (object)num3 + "k Exp", "orange", false);
                else if (str6.Equals("none", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("You have gained " + (object)num3 + " Exp", "orange", false);
                else if (str6.Equals("null", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("You haven't gained any Exp.", "orange", false);
                if (str3.Equals("billions", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num10, 2) + "bil Exp/hr.", "orange", false);
                else if (str3.Equals("millions", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num10, 2) + "mil Exp/hr.", "orange", false);
                else if (str3.Equals("thousands", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num10, 2) + "k Exp/hr.", "orange", false);
                else if (str3.Equals("none", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num10, 2) + " Exp/hr.", "orange", false);
                else if (!str3.Equals("null", StringComparison.CurrentCultureIgnoreCase)) ;
            }
            string empty5 = string.Empty;
            string str8 = !this.calc_exp.Checked || str5.Equals("null", StringComparison.CurrentCultureIgnoreCase) ? (!this.calc_exp.Checked || !str6.Equals("null", StringComparison.CurrentCultureIgnoreCase) || !str5.Equals("null", StringComparison.CurrentCultureIgnoreCase) ? (!this.calc_exp.Checked || str6.Equals("null", StringComparison.CurrentCultureIgnoreCase) || !str5.Equals("null", StringComparison.CurrentCultureIgnoreCase) ? (this.calc_exp.Checked || !str5.Equals("null", StringComparison.CurrentCultureIgnoreCase) ? "You have " : "You haven't ") : "But you haven't ") : "And you haven't ") : "You've also ";
            if (this.calc_ap.Checked)
            {
                if (str5.Equals("billions", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage(str8 + "gained " + (object)num1 + "bil Ap", "orange", false);
                else if (str5.Equals("millions", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage(str8 + "gained " + (object)num1 + "mil Ap", "orange", false);
                else if (str5.Equals("thousands", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage(str8 + "gained " + (object)num1 + "k Ap", "orange", false);
                else if (str5.Equals("none", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage(str8 + "gained " + (object)num1 + " Ap", "orange", false);
                else if (str5.Equals("null", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage(str8 + "gained any Ap.", "orange", false);
                if (str2.Equals("billions", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num9, 2) + "bil Ap/hr.", "orange", false);
                else if (str2.Equals("millions", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num9, 2) + "mil Ap/hr.", "orange", false);
                else if (str2.Equals("thousands", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num9, 2) + "k Ap/hr.", "orange", false);
                else if (str2.Equals("none", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num9, 2) + " Ap/hr.", "orange", false);
                else if (!str2.Equals("null", StringComparison.CurrentCultureIgnoreCase))
                    ;
            }
            string empty6 = string.Empty;
            string str9 = !this.calc_exp.Checked && !this.calc_ap.Checked || str7.Equals("null", StringComparison.CurrentCultureIgnoreCase) ? (!this.calc_exp.Checked && !this.calc_ap.Checked || !str5.Equals("null", StringComparison.CurrentCultureIgnoreCase) || !str7.Equals("null", StringComparison.CurrentCultureIgnoreCase) ? (!this.calc_exp.Checked && !this.calc_ap.Checked || str5.Equals("null", StringComparison.CurrentCultureIgnoreCase) || !str7.Equals("null", StringComparison.CurrentCultureIgnoreCase) ? (this.calc_exp.Checked || this.calc_ap.Checked || !str7.Equals("null", StringComparison.CurrentCultureIgnoreCase) ? "You have " : "You haven't ") : "But you haven't ") : "And you haven't ") : "You've also ";
            if (this.calc_gold.Checked)
            {
                if (str7.Equals("millions", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage(str9 + "gained " + (object)num5 + "mil Gold", "orange", false);
                else if (str7.Equals("thousands", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage(str9 + "gained " + (object)num5 + "k Gold", "orange", false);
                else if (str7.Equals("none", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage(str9 + "gained " + (object)num5 + " Gold", "orange", false);
                else if (str7.Equals("null", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage(str9 + "gained any Gold.", "orange", false);
                if (str4.Equals("millions", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num11, 2) + "mil Gold/hr.", "orange", false);
                else if (str4.Equals("thousands", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num11, 2) + "k Gold/hr.", "orange", false);
                else if (str4.Equals("none", StringComparison.CurrentCultureIgnoreCase))
                    this.Client.SendMessage("at the rate of " + (object)Math.Round(num11, 2) + " Gold/hr.", "orange", false);
                else if (!str4.Equals("null", StringComparison.CurrentCultureIgnoreCase))
                    ;
            }
        }

        public void StartCalc()
        {
            this.Client.SendMessage("Calculator started. Please wait at least 20 seconds before requesting rates.", "orange", false);
            this.calc_toggle.Text = "Pause";
            this.calc_reset.Enabled = true;
            if (this.startap == -1.0)
                this.startap = (double)this.Client.Statistics.AbilityExp;
            if (this.startexp == -1.0)
                this.startexp = (double)this.Client.Statistics.Experience;
            if (this.startgold == -1.0)
                this.startgold = (double)this.Client.Statistics.Gold;
            this.calctimer.Start();
        }

        public void StopCalc()
        {
            this.Client.SendMessage("The calculator was paused.", "orange", false);
            this.calc_toggle.Text = "Start";
            this.calc_reset.Enabled = false;
            this.calctimer.Stop();
        }

        public void ResetCalc()
        {
            this.Client.SendMessage("The calculator was reset.", "orange", false);
            this.startap = (double)this.Client.Statistics.AbilityExp;
            this.startexp = (double)this.Client.Statistics.Experience;
            this.startgold = (double)this.Client.Statistics.Gold;
            this.totaltime = 0.0;
            this.apcounter = 0.0;
        }

        private void waitonmonsters_CheckedChanged(object sender, EventArgs e)
        {
            this.vwaitonmonsters = this.waitonmonsters.Checked;
        }

        private void actonlyinmobs_CheckedChanged(object sender, EventArgs e)
        {
            this.vactonlyinmobs = this.actonlyinmobs.Checked;
        }

        private void redaislings_CheckedChanged(object sender, EventArgs e)
        {
            if (this.redaislings.Checked)
                this.vredaislings = true;
            else
                this.vredaislings = false;
        }

        private void potion_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.potion.Checked)
            {
                this.vpotion = true;
                this.potioncond.Enabled = true;
            }
            else
            {
                this.vpotion = false;
                this.potioncond.Enabled = false;
            }
        }

        private void potioncond_ValueChanged(object sender, EventArgs e)
        {
            this.vpotioncond = (int)this.potioncond.Value;
        }

        private void mantidscent_CheckedChanged(object sender, EventArgs e)
        {
            this.vmantidscent = this.mantidscent.Checked;
        }

        private void insectcloak_CheckedChanged(object sender, EventArgs e)
        {
            this.vinsectcloak = this.insectcloak.Checked;
        }

        private void assassinscroll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.assassinscroll.Checked)
                this.vassassinscroll = true;
            else
                this.vassassinscroll = false;
        }

        private void fungusbeetleextract_CheckedChanged(object sender, EventArgs e)
        {
            if (this.fungusbeetleextract.Checked)
                this.vfungusbeetleextract = true;
            else
                this.vfungusbeetleextract = false;
        }

        private void dragonsfire_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dragonsfire.Checked)
                this.vdragonsfire = true;
            else
                this.vdragonsfire = false;
        }

        private void dragonsscale_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dragonsscale.Checked)
                this.vdragonsscale = true;
            else
                this.vdragonsscale = false;
        }

        private void musclestimulant_CheckedChanged(object sender, EventArgs e)
        {
            if (this.musclestimulant.Checked)
                this.vmusclestimulant = true;
            else
                this.vmusclestimulant = false;
        }

        private void nervestimulant_CheckedChanged(object sender, EventArgs e)
        {
            if (this.nervestimulant.Checked)
                this.vnervestimulant = true;
            else
                this.vnervestimulant = false;
        }

        private void wakescroll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.wakescroll.Checked)
                this.vwakescroll = true;
            else
                this.vwakescroll = false;
        }

        private void icebottle_CheckedChanged(object sender, EventArgs e)
        {
            if (this.icebottle.Checked)
                this.vicebottle = true;
            else
                this.vicebottle = false;
        }

        private void elemusmount_CheckedChanged(object sender, EventArgs e)
        {
            this.velemusmount = this.elemusmount.Checked;
        }

        private void looton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.looton.Checked)
                this.Client.loot = true;
            else
                this.Client.loot = false;
        }

        private void dropitemstext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            e.Handled = true;
            this.dropitemsadd.PerformClick();
        }

        private void dropitemsadd_Click(object sender, EventArgs e)
        {
            if (!(this.dropitemstext.Text != string.Empty) || this.dropitemslist.Items.Contains((object)this.dropitemstext.Text))
                return;
            this.dropitemslist.Items.Add((object)this.dropitemstext.Text);
            this.dropitemstext.Text = string.Empty;
        }

        private void dropitemsremove_Click(object sender, EventArgs e)
        {
            this.dropitemslist.Items.Remove(this.dropitemslist.SelectedItem);
        }

        private void dropitemson_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dropitemson.Checked)
                this.vdropitemson = true;
            else
                this.vdropitemson = false;
        }

        private void lootlocale_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.vlootlocale = this.lootlocale.Text;
        }

        private void walktoloot_CheckedChanged(object sender, EventArgs e)
        {
            this.vwalktoloot = this.walktoloot.Checked;
        }

        private void additem_Click(object sender, EventArgs e)
        {
            if (!(this.newitem.Text != string.Empty) || this.autodepositlistbox.Items.Contains((object)this.newitem.Text))
                return;
            this.autodepositlistbox.Items.Add((object)this.newitem.Text);
            this.newitem.Text = string.Empty;
        }

        private void removeitem_Click(object sender, EventArgs e)
        {
            this.autodepositlistbox.Items.Remove(this.autodepositlistbox.SelectedItem);
        }

        private void autodepositon_CheckedChanged(object sender, EventArgs e)
        {
            this.Client.autodeposit = this.autodepositon.Checked;
        }

        private void newitem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            e.Handled = true;
            this.additem.PerformClick();
        }

        private void rescueascendername_TextChanged(object sender, EventArgs e)
        {
            this.vrescueascendername = this.rescueascendername.Text;
        }

        private void rescueascender_CheckedChanged(object sender, EventArgs e)
        {
            this.vrescueascender = this.rescueascender.Checked;
            if (!this.rescueascender.Checked || this.Client.HasSkill("Rescue", false))
                return;
            this.rescueascender.Checked = false;
        }

        private void assistonthischar_CheckedChanged(object sender, EventArgs e)
        {
            this.vassistonthischar = this.assistonthischar.Checked;
        }

        private void impskillbutton_TextChanged(object sender, EventArgs e)
        {
            if (this.impskillbutton.Text.Equals("Start"))
                this.vimpskillbutton = false;
            else
                this.vimpskillbutton = true;
        }

        private void impskillbutton_Click(object sender, EventArgs e)
        {
            if (this.impskillbutton.Text.Equals("Start"))
            {
                this.impskillbutton.Text = "Stop";
            }
            else
            {
                this.impskillbutton.Text = "Start";
                this.Client.impingskill = false;
            }
        }

        private void laborbutton_TextChanged(object sender, EventArgs e)
        {
            if (this.laborbutton.Text.Equals("Start"))
                this.vlaborbutton = false;
            else
                this.vlaborbutton = true;
        }

        private void laborbutton_Click(object sender, EventArgs e)
        {
            if (this.laborbutton.Text.Equals("Start"))
                this.laborbutton.Text = "Stop";
            else
                this.laborbutton.Text = "Start";
        }

        private void praybutton_TextChanged(object sender, EventArgs e)
        {
            if (this.praybutton.Text.Equals("Start"))
                this.vpraybutton = false;
            else
                this.vpraybutton = true;
        }

        private void praybutton_Click(object sender, EventArgs e)
        {
            if (this.praybutton.Text.Equals("Start"))
                this.praybutton.Text = "Stop";
            else
                this.praybutton.Text = "Start";
        }

        private void praynecklace_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.praynecklace.Checked)
                return;
            this.prayhere.Enabled = true;
            this.prayxy.Enabled = true;
            this.prayxytext.Enabled = true;
        }

        private void praytemple_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.praytemple.Checked)
                return;
            this.prayhere.Enabled = false;
            this.prayxy.Enabled = false;
            this.prayxytext.Enabled = false;
        }

        private void prayernecklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Client.PrayerNeck = this.prayernecklist.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void testnum_ValueChanged(object sender, EventArgs e)
        {
        }

        public void PopulateLureList()
        {
            int num = 0;
            if (this.Client.YourAttacks1.Contains("Keeter"))
            {
                this.lurespells.Items.Add((object)"Keeter");
                ++num;
            }
            if (this.Client.YourAttacks1.Contains("Mermaid"))
            {
                this.lurespells.Items.Add((object)"Mermaid");
                ++num;
            }
            if (this.Client.YourAttacks1.Contains("Torch"))
            {
                this.lurespells.Items.Add((object)"Torch");
                ++num;
            }
            if (this.Client.YourAttacks1.Contains("Groo"))
            {
                this.lurespells.Items.Add((object)"Groo");
                ++num;
            }
            if (this.Client.YourAttacks1.Contains("mor pian na dion"))
            {
                this.lurespells.Items.Add((object)"mor pian na dion");
                ++num;
            }
            if (this.Client.YourAttacks1.Contains("pian na dion"))
            {
                this.lurespells.Items.Add((object)"pian na dion");
                ++num;
            }
            if (this.Client.YourAttacks1.Contains("ard deo searg"))
            {
                this.lurespells.Items.Add((object)"ard deo searg");
                ++num;
            }
            if (this.Client.YourAttacks1.Contains("deo searg"))
            {
                this.lurespells.Items.Add((object)"deo searg");
                ++num;
            }
            if (this.Client.YourAttacks1.Contains("Star Arrow"))
            {
                this.lurespells.Items.Add((object)"Star Arrow");
                ++num;
            }
            if (this.Client.YourAttacks1.Contains("Shock Arrow"))
            {
                this.lurespells.Items.Add((object)"Shock Arrow");
                ++num;
            }
            if (this.Client.YourAttacks1.Contains("Hail of Feathers"))
            {
                this.lurespells.Items.Add((object)"Hail of Feathers");
                ++num;
            }
            if (num > 0)
            {
                this.lurespells.SelectedIndex = 0;
            }
            else
            {
                this.lurewithspells.Checked = false;
                this.lurewithspells.Enabled = false;
                this.lurespells.Enabled = false;
            }
        }

        private void lurespells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lurewithspells.Checked)
            {
                this.onlylurewithmp.Enabled = true;
                this.onlylurewithmpamount.Enabled = true;
                if (this.lurespells.Text.Equals("Keeter"))
                {
                    foreach (Spell spell in this.Client.SpellBook)
                    {
                        if (spell != null && spell.Name.Contains("Keeter"))
                        {
                            this.lurespellwith = Server.SpellList[spell.Name];
                            break;
                        }
                    }
                }
                else if (this.lurespells.Text.Equals("Mermaid"))
                {
                    foreach (Spell spell in this.Client.SpellBook)
                    {
                        if (spell != null && spell.Name.Contains("Mermaid"))
                        {
                            this.lurespellwith = Server.SpellList[spell.Name];
                            break;
                        }
                    }
                }
                else if (this.lurespells.Text.Equals("Torch"))
                {
                    foreach (Spell spell in this.Client.SpellBook)
                    {
                        if (spell != null && spell.Name.Contains("Torch"))
                        {
                            this.lurespellwith = Server.SpellList[spell.Name];
                            break;
                        }
                    }
                }
                else if (this.lurespells.Text.Equals("Groo"))
                {
                    foreach (Spell spell in this.Client.SpellBook)
                    {
                        if (spell != null && spell.Name.Contains("Groo"))
                        {
                            this.lurespellwith = Server.SpellList[spell.Name];
                            break;
                        }
                    }
                }
                else if (this.lurespells.Text.Equals("Star Arrow"))
                {
                    foreach (Spell spell in this.Client.SpellBook)
                    {
                        if (spell != null && spell.Name.Contains("Star Arrow") && spell.Name != "Star Arrow 10")
                        {
                            this.lurespellwith = Server.SpellList[spell.Name];
                            break;
                        }
                    }
                }
                else if (this.lurespells.Text.Equals("Hail of Feathers"))
                {
                    foreach (Spell spell in this.Client.SpellBook)
                    {
                        if (spell != null && spell.Name.Contains("Hail of Feathers"))
                        {
                            this.lurespellwith = Server.SpellList[spell.Name];
                            break;
                        }
                    }
                }
                else
                    this.lurespellwith = Server.SpellList[this.lurespells.Text];
            }
            else
            {
                this.lurespellwith = (SpellData)null;
                this.onlylurewithmp.Enabled = false;
                this.onlylurewithmp.Checked = false;
                this.onlylurewithmpamount.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Enabled = false;
            new Thread(new ThreadStart(this.Client.DAFind)).Start();
        }

        private void spellaninum_ValueChanged(object sender, EventArgs e)
        {
            this.Client.FakeSpellAni(this.Client.ServerLocation.X, this.Client.ServerLocation.Y, (int)this.spellaninum.Value);
        }

        private void spellaninum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar != '\r')
                    return;
                this.Client.FakeSpellAni(this.Client.ServerLocation.X, this.Client.ServerLocation.Y, (int)this.spellaninum.Value);
            }
        }

        private void openmacroform_Click(object sender, EventArgs e)
        {
            this.openmacroform.Enabled = false;
            this.MacroOptions.Text = "Macro - " + this.Client.Name;
            this.MacroOptions.Show();
            if (this.macroonce == 0)
                return;
            this.MacroOptions.Location = new System.Drawing.Point(this.MacroOptions.parent.Location.X + 200, this.MacroOptions.parent.Location.Y + 80);
            this.macroonce = 0;
        }

        private void opencomboform_Click(object sender, EventArgs e)
        {
            this.opencomboform.Enabled = false;
            this.ComboOptions.Text = this.Client.Name + "'s Combo Editor";
            this.ComboOptions.Show();
            if (this.comboonce == 0)
                return;
            this.ComboOptions.Location = new System.Drawing.Point(this.ComboOptions.parent.Location.X + 200, this.ComboOptions.parent.Location.Y + 80);
            this.comboonce = 0;
        }

        private void openascendform_Click(object sender, EventArgs e)
        {
            this.openascendform.Enabled = false;
            this.AscendOptions.Text = "Ascend " + this.Client.Name;
            this.AscendOptions.Show();
            if (this.ascendonce == 0)
                return;
            this.AscendOptions.Location = new System.Drawing.Point(this.AscendOptions.parent.Location.X + 200, this.AscendOptions.parent.Location.Y + 80);
            this.ascendonce = 0;
        }

        private void vanishingelixir_Click(object sender, EventArgs e)
        {
            this.vanishingelixir.Enabled = false;
            this.HideTrinketOptions.Text = "Hide these bitches";
            this.HideTrinketOptions.Show();
            if (this.hideonce == 0)
                return;
            this.HideTrinketOptions.Location = new System.Drawing.Point(this.HideTrinketOptions.parent.Location.X + 200, this.HideTrinketOptions.parent.Location.Y + 80);
            this.hideonce = 0;
        }

        private void openmedchest_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void duarmor_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Client.Loaded)
                return;
            this.Client.UseMonsterForm();
        }

        private void openarenaform_Click(object sender, EventArgs e)
        {
            this.openarenaform.Enabled = false;
            this.ArenaCounter.Text = this.Client.Name + "'s Arena Counter";
            this.ArenaCounter.Show();
            if (this.arecoonce == 0)
                return;
            this.ArenaCounter.Location = new System.Drawing.Point(this.ArenaCounter.parent.Location.X + 200, this.ArenaCounter.parent.Location.Y + 80);
            this.arecoonce = 0;
        }

        private void recorditemdata_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.recorditemdata.Checked)
                return;
            Program.MainForm.BeginInvoke((Action)(() =>
           {
               Program.MainForm.openitemxmleditor.Enabled = false;
               Program.MainForm.ItemXMLEditor.Show();
           }));
        }

        private void openswapform_Click(object sender, EventArgs e)
        {
            this.openswapform.Enabled = false;
            this.SkillSwap.Text = this.Client.Name + "'s Skill Swapper";
            this.SkillSwap.Show();
            if (this.swaponce == 0)
                return;
            this.SkillSwap.Location = new System.Drawing.Point(this.SkillSwap.parent.Location.X + 200, this.SkillSwap.parent.Location.Y + 80);
            this.swaponce = 0;
        }

        private void btnPlay_CheckedChanged(object sender, EventArgs e)
        {
            if (!(this.Client.lastaction != DateTime.MinValue))
                return;
            this.Client.lastaction = DateTime.UtcNow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            if (!(this.scriptida.Value <= this.scriptidb.Value))
                return;
            for (ushort script = (ushort)this.scriptida.Value; (int)script <= (int)(ushort)this.scriptidb.Value; ++script)
            {
                this.Client.DialogueRespond((uint)this.npcid.Value, script);
                Thread.Sleep(1);
            }
            Client client = this.Client;
            Decimal num = this.scriptida.Value;
            string str1 = num.ToString();
            num = this.scriptidb.Value;
            string str2 = num.ToString();
            string text = "finished search from " + str1 + " to " + str2;
            client.SendMessage(text, (byte)0, false);
            this.button2.Enabled = true;
        }

        private void togglehaxloop_Click(object sender, EventArgs e)
        {
            if (this.togglehaxloop.Text == "start")
                this.togglehaxloop.Text = "stop";
            else
                this.togglehaxloop.Text = "start";
        }

        private void drophaxbtn_Click(object sender, EventArgs e)
        {
            if (!(this.drophaxnpcid.Value != new Decimal(0)) || !(this.drophaxtxt.Text != "") || !this.Client.HasItem(this.drophaxtxt.Text))
                return;
            foreach (Item obj in ((IEnumerable<Item>)this.Client.Inventory).ToArray<Item>())
            {
                if (obj != null && obj.Name.Equals(this.drophaxtxt.Text, StringComparison.CurrentCultureIgnoreCase))
                    this.Client.DropInMonster((uint)this.drophaxnpcid.Value, obj.InventorySlot, (int)obj.Amount);
            }
            this.drophaxtxt.Text = "";
        }

        private void getmonsterid2_CheckedChanged(object sender, EventArgs e)
        {
            this.getimage.Checked = this.getmonsterid2.Checked;
            this.vgetimage = this.getimage.Checked;
        }

        private void itemNum_ValueChanged(object sender, EventArgs e)
        {
            this.Client.CreateItem((byte)19, (int)(this.itemNum.Value + new Decimal(32768)), "test", (byte)this.itemColor.Value);
        }

        private void legendopen_Click(object sender, EventArgs e)
        {
            this.legendopen.Enabled = false;
            this.LegendMarks.Text = this.Client.Name + "'s Unobtained Legend Marks";
            this.LegendMarks.Show();
        }

        private delegate void MakeGroupTarget(ClientTab newText);

        private delegate void MakePlayerTargets(targetPlayer name);

        private delegate void MakePlayers(string name);

        private delegate void MakeAllMonster();
    }
}
