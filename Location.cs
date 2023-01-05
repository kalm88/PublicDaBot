// Decompiled with JetBrains decompiler
// Type: ProxyBase.Location
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;

namespace ProxyBase
{
  public class Location
  {
    public Direction Direction = Direction.None;

    public int X { get; set; }

    public int Y { get; set; }

    public Location(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    public int DistanceFrom(Location loc)
    {
      return Math.Abs(this.X - loc.X) + Math.Abs(this.Y - loc.Y);
    }

    public int DistanceFrom(int x, int y)
    {
      return Math.Abs(this.X - x) + Math.Abs(this.Y - y);
    }

    public bool WithinSquare(Location loc, int num)
    {
      return Math.Abs(this.X - loc.X) <= num && Math.Abs(this.Y - loc.Y) <= num;
    }

    public static Location operator +(Location a, Direction b)
    {
      Location location = new Location(a.X, a.Y);
      switch (b)
      {
        case Direction.North:
          --location.Y;
          break;
        case Direction.East:
          ++location.X;
          break;
        case Direction.South:
          ++location.Y;
          break;
        case Direction.West:
          --location.X;
          break;
      }
      return location;
    }

    public static Direction operator -(Location a, Location b)
    {
      if (a.X == b.X && a.Y == b.Y + 1)
        return Direction.North;
      if (a.X == b.X && a.Y == b.Y - 1)
        return Direction.South;
      if (a.X == b.X + 1 && a.Y == b.Y)
        return Direction.West;
      return a.X == b.X - 1 && a.Y == b.Y ? Direction.East : Direction.None;
    }
  }
}
