// Decompiled with JetBrains decompiler
// Type: ProxyBase.ClientPacket
// Assembly: ProxyBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 077B98B9-686A-434C-992F-701D553EA96A
// Assembly location: C:\Users\snowi\Documents\projects\ProxyBase3-30-17\ProxyBase.exe

using System;
using System.Security.Cryptography;

namespace ProxyBase
{
  public class ClientPacket : Packet
  {
    public ClientPacket(byte opcode)
    {
      this.signature = (byte) 170;
      this.bodyData = new byte[0];
      this.opcode = opcode;
    }

    public ClientPacket(byte[] rawData)
    {
      this.signature = rawData[0];
      this.length = (ushort) ((uint) rawData[1] * 256U + (uint) rawData[2]);
      this.opcode = rawData[3];
      if (this.ShouldEncrypt)
      {
        this.ordinal = rawData[4];
        this.bodyData = new byte[rawData.Length - 5];
        Array.Copy((Array) rawData, 5, (Array) this.bodyData, 0, this.bodyData.Length);
      }
      else
      {
        this.bodyData = new byte[rawData.Length - 4];
        Array.Copy((Array) rawData, 4, (Array) this.bodyData, 0, this.bodyData.Length);
      }
    }

    public override bool ShouldEncrypt
    {
      get
      {
        return this.Opcode != (byte) 0 && this.Opcode != (byte) 16 && this.Opcode != (byte) 87 && this.Opcode != (byte) 98;
      }
    }

    public override bool UseDefaultKey
    {
      get
      {
        return this.Opcode == (byte) 2 || this.Opcode == (byte) 3 || (this.Opcode == (byte) 4 || this.Opcode == (byte) 11) || (this.Opcode == (byte) 38 || this.Opcode == (byte) 45 || (this.Opcode == (byte) 58 || this.Opcode == (byte) 66)) || (this.Opcode == (byte) 67 || this.Opcode == (byte) 75 || (this.Opcode == (byte) 87 || this.Opcode == (byte) 98) || (this.Opcode == (byte) 104 || this.Opcode == (byte) 113 || this.Opcode == (byte) 115)) || this.Opcode == (byte) 123;
      }
    }

    public override void Encrypt(Client client)
    {
      int count = this.bodyData.Length - 7;
      Random random = new Random();
      ushort bRand = (ushort) (random.Next(65277) + 256);
      byte sRand = (byte) (random.Next(155) + 100);
      byte[] numArray = this.UseDefaultKey ? client.Key : client.GenerateKey(bRand, sRand);
      for (int index = 0; index < count; ++index)
      {
        this.bodyData[index] ^= numArray[index % numArray.Length];
        this.bodyData[index] ^= Packet.saltTable[(int) client.Seed][index / numArray.Length % Packet.saltTable[(int) client.Seed].Length];
        if (index / numArray.Length % Packet.saltTable[(int) client.Seed].Length != (int) this.ordinal)
          this.bodyData[index] ^= Packet.saltTable[(int) client.Seed][(int) this.ordinal];
      }
      byte[] buffer = new byte[count + 2];
      buffer[0] = this.opcode;
      buffer[1] = this.ordinal;
      Buffer.BlockCopy((Array) this.bodyData, 0, (Array) buffer, 2, count);
      byte[] hash = MD5.Create().ComputeHash(buffer);
      this.bodyData[count] = hash[13];
      this.bodyData[count + 1] = hash[3];
      this.bodyData[count + 2] = hash[11];
      this.bodyData[count + 3] = hash[7];
      this.bodyData[count + 4] = (byte) ((int) bRand % 256 ^ 112);
      this.bodyData[count + 5] = (byte) ((uint) sRand ^ 35U);
      this.bodyData[count + 6] = (byte) (((int) bRand >> 8) % 256 ^ 116);
    }

    public override void Decrypt(Client client)
    {
      int num = this.bodyData.Length - 7;
      ushort bRand = (ushort) (((int) this.bodyData[num + 6] << 8 | (int) this.bodyData[num + 4]) ^ 29808);
      byte sRand = (byte) ((uint) this.bodyData[num + 5] ^ 35U);
      byte[] numArray = this.UseDefaultKey ? client.Key : client.GenerateKey(bRand, sRand);
      for (int index = 0; index < num; ++index)
      {
        this.bodyData[index] ^= numArray[index % numArray.Length];
        this.bodyData[index] ^= Packet.saltTable[(int) client.Seed][index / numArray.Length % Packet.saltTable[(int) client.Seed].Length];
        if (index / numArray.Length % Packet.saltTable[(int) client.Seed].Length != (int) this.ordinal)
          this.bodyData[index] ^= Packet.saltTable[(int) client.Seed][(int) this.ordinal];
      }
    }

    public void GenerateDialogHeader()
    {
      ushort num = 0;
      for (int index = 0; index < this.bodyData.Length - 6; ++index)
        num = (ushort) ((uint) this.bodyData[6 + index] ^ ((uint) (ushort) ((uint) num << 8) ^ (uint) Packet.dialogCrcTable[(int) num >> 8]));
      Random random = new Random();
      this.bodyData[0] = (byte) random.Next();
      this.bodyData[1] = (byte) random.Next();
      this.bodyData[2] = (byte) ((this.bodyData.Length - 4) / 256);
      this.bodyData[3] = (byte) ((this.bodyData.Length - 4) % 256);
      this.bodyData[4] = (byte) ((uint) num / 256U);
      this.bodyData[5] = (byte) ((uint) num % 256U);
    }

    public void EncryptDialog()
    {
      int num1 = (int) this.bodyData[2] << 8 | (int) this.bodyData[3];
      byte num2 = (byte) ((uint) this.bodyData[1] ^ (uint) (byte) ((uint) this.bodyData[0] - 45U));
      byte num3 = (byte) ((uint) num2 + 114U);
      byte num4 = (byte) ((uint) num2 + 40U);
      this.bodyData[2] ^= num3;
      this.bodyData[3] ^= (byte) (((int) num3 + 1) % 256);
      for (int index = 0; index < num1; ++index)
        this.bodyData[4 + index] ^= (byte) (((int) num4 + index) % 256);
    }

    public void DecryptDialog()
    {
      byte num1 = (byte) ((uint) this.bodyData[1] ^ (uint) (byte) ((uint) this.bodyData[0] - 45U));
      byte num2 = (byte) ((uint) num1 + 114U);
      byte num3 = (byte) ((uint) num1 + 40U);
      this.bodyData[2] ^= num2;
      this.bodyData[3] ^= (byte) (((int) num2 + 1) % 256);
      int num4 = (int) this.bodyData[2] << 8 | (int) this.bodyData[3];
      for (int index = 0; index < num4; ++index)
        this.bodyData[4 + index] ^= (byte) (((int) num3 + index) % 256);
    }
  }
}
