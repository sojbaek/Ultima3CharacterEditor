using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Ultima3CharacterEditor
{
    class U3EditorUtil
    {
        static public Byte OneByteHex2Dec(Byte v)
        {
            return (byte)((v >> 4) * 10 + v % 16);
        }

        static public UInt16 TwoByteHex2Dec(UInt16 v)
        {
            Byte low = (Byte)(v / 256);
            Byte high = (Byte)(v % 256);
            return (UInt16)(OneByteHex2Dec(low) * 100 + OneByteHex2Dec(high));
        }

        static public Byte read1Dec(BinaryReader reader)
        {
            return OneByteHex2Dec(reader.ReadByte());
        }

        static public UInt16 read2Dec(BinaryReader reader)
        {
            return TwoByteHex2Dec(reader.ReadUInt16());
        }

        static public UInt32 read4Dec(BinaryReader reader)
        {
            UInt16 lower = TwoByteHex2Dec(reader.ReadUInt16());
            UInt16 upper = TwoByteHex2Dec(reader.ReadUInt16());
            return (UInt32)lower + upper * 1000U;
        }


        static public void write1Dec(BinaryWriter writer, uint value)
        {
            byte v1 = (byte) (value % 100);
            byte v2 = (byte) ((v1 / 10) * 16 + (v1 % 10));
            writer.Write(v2);
        }

        static public void write2Dec(BinaryWriter writer, uint value)
        {
            uint v1 = (byte)(value / 100);
            uint v2 = (byte)(value % 100);
            write1Dec(writer, v2);
            write1Dec(writer, v1);
        }

        static public void write4Dec(BinaryWriter writer, uint value)
        {
            uint v1 = (byte)(value / 10000);
            uint v2 = (byte)(value % 10000);
            write2Dec(writer, v2);
            write2Dec(writer, v1);
        }
    }
}
