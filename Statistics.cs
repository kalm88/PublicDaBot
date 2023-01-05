﻿// Decompiled with JetBrains decompiler
// Type: ProxyBase.Statistics
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

namespace ProxyBase
{
  public class Statistics
  {
    public int Level { get; set; }

    public int Ability { get; set; }

    public uint MaximumHP { get; set; }

    public uint MaximumMP { get; set; }

    public int Str { get; set; }

    public int Int { get; set; }

    public int Wis { get; set; }

    public int Con { get; set; }

    public int Dex { get; set; }

    public int AvailablePoints { get; set; }

    public int MaximumWeight { get; set; }

    public int CurrentWeight { get; set; }

    public uint CurrentHP { get; set; }

    public uint CurrentMP { get; set; }

    public uint Experience { get; set; }

    public uint ToNextLevel { get; set; }

    public uint AbilityExp { get; set; }

    public uint ToNextAbility { get; set; }

    public uint GamePoints { get; set; }

    public uint Gold { get; set; }

    public byte MailAndParcel { get; set; }

    public Statistics.Elements AttackElement { get; set; }

    public Statistics.Elements DefenseElement { get; set; }

    public int AttackElement2 { get; set; }

    public int DefenseElement2 { get; set; }

    public int MagicResistance { get; set; }

    public int ArmorClass { get; set; }

    public int Damage { get; set; }

    public int Hit { get; set; }

    public int BitMask { get; set; }

    public enum Elements
    {
      None,
      Fire,
      Sea,
      Wind,
      Earth,
      Light,
      Dark,
      Wood,
      Metal,
      Undead,
    }
  }
}
