// Decompiled with JetBrains decompiler
// Type: ProxyBase.Point
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;

namespace ProxyBase
{
  public class Point
  {
    public bool prayermessagesent = false;
    public DateTime AnimationTimer = DateTime.MinValue;
    public DateTime PrayerTimer = DateTime.MinValue;
    public DateTime GemPolishTimer = DateTime.MinValue;

    public int X { get; set; }

    public int Y { get; set; }

    public bool IsWall { get; set; }

    public bool HasEntity { get; set; }

    public Point(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    public int StepCount { get; set; }

    public bool HasBlock { get; set; }

    public bool PlayAnimation
    {
      get
      {
        return DateTime.UtcNow.Subtract(this.AnimationTimer).TotalSeconds > 3.0;
      }
    }

    public bool HasPrayerSpell
    {
      get
      {
        return !(this.PrayerTimer == DateTime.MinValue) && DateTime.UtcNow.Subtract(this.PrayerTimer).TotalSeconds < 121.0;
      }
    }

    public bool SafeToDropNecklace
    {
      get
      {
        return !(this.PrayerTimer == DateTime.MinValue) && DateTime.UtcNow.Subtract(this.PrayerTimer).TotalSeconds < 110.0;
      }
    }

    public bool HasGemPolish
    {
      get
      {
        return !(this.GemPolishTimer == DateTime.MinValue) && DateTime.UtcNow.Subtract(this.GemPolishTimer).TotalSeconds < 50.0;
      }
    }

    public bool IsInMaxView(Location loc, int dist)
    {
      return (dist <= 8 || (dist < 11 || (this.X > loc.X || this.Y < loc.Y || this.DistanceFrom(loc) <= 11)) && (dist != 12 || (this.X < loc.X || this.Y >= loc.Y || this.DistanceFrom(loc) <= 11))) && this.DistanceFrom(loc) <= dist;
    }

    public int DistanceFrom(Location loc)
    {
      return this.X > loc.X && this.X <= loc.X + 5 ? Math.Abs(this.X - loc.X) + Math.Abs(this.Y - loc.Y) : Math.Abs(this.X - loc.X) + Math.Abs(this.Y - loc.Y);
    }

    public bool WithinSquare(Location loc, int num)
    {
      return Math.Abs(this.X - loc.X) <= num && Math.Abs(this.Y - loc.Y) <= num;
    }

    public bool IsBehind(Location loc)
    {
      if (loc.Direction == Direction.North)
      {
        if (this.Y > loc.Y)
          return true;
      }
      else if (loc.Direction == Direction.South)
      {
        if (this.Y < loc.Y)
          return true;
      }
      else if (loc.Direction == Direction.East)
      {
        if (this.X < loc.X)
          return true;
      }
      else if (loc.Direction == Direction.West && this.X > loc.X)
        return true;
      return false;
    }

    public bool IsInFront(Location loc)
    {
      if (loc.Direction == Direction.South)
      {
        if (this.Y >= loc.Y + 1 && this.X == loc.X && this.DistanceFrom(loc) == 1)
          return true;
      }
      else if (loc.Direction == Direction.North)
      {
        if (this.Y <= loc.Y - 1 && this.X == loc.X && this.DistanceFrom(loc) == 1)
          return true;
      }
      else if (loc.Direction == Direction.West)
      {
        if (this.X <= loc.X - 1 && this.Y == loc.Y && this.DistanceFrom(loc) == 1)
          return true;
      }
      else if (loc.Direction == Direction.East && (this.X >= loc.X + 1 && this.Y == loc.Y && this.DistanceFrom(loc) == 1))
        return true;
      return false;
    }

    public bool IsInRSRange(Location loc, int dist)
    {
      if (loc.Direction == Direction.North)
      {
        if (this.X == loc.X && Math.Abs(this.Y - loc.Y) < dist && this.Y <= loc.Y)
          return true;
      }
      else if (loc.Direction == Direction.South)
      {
        if (this.X == loc.X && Math.Abs(this.Y - loc.Y) < dist && this.Y >= loc.Y)
          return true;
      }
      else if (loc.Direction == Direction.East)
      {
        if (this.Y == loc.Y && Math.Abs(this.X - loc.X) < dist && this.X >= loc.X)
          return true;
      }
      else if (loc.Direction == Direction.West && (this.Y == loc.Y && Math.Abs(this.X - loc.X) < dist && this.X <= loc.X))
        return true;
      return false;
    }

    public bool Passable
    {
      get
      {
        return !this.IsWall && !this.HasBlock;
      }
    }
  }
}
