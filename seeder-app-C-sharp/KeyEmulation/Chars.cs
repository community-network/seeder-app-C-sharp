using System;

namespace seeder_app_C_sharp
{

    internal class Chars
    {
        public static ushort[] CHAR_MAPPING = new ushort[47] {
            0x33, //,
            0x0C, //-
            0x34, //.
            0x35, //\/
            0x0B, //0
            0x02, //1
            0x03, //2
            0x04, //3
            0x05, //4
            0x06, //5
            0x07, //6
            0x08, //7
            0x09, //8
            0x0A, //9
            0x0,
            0x27, //;
            0x0,
            0x0D, //=
            0x0,
            0x0,
            0x0,
            0x1E, //A
            0x30, //B
            0x2E, //C
            0x20, //D
            0x12, //E
            0x21, //F
            0x22, //G
            0x23, //H
            0x17, //I
            0x24, //J
            0x25, //K
            0x26, //L
            0x32, //M
            0x31, //N
            0x18, //O
            0x19, //P
            0x10, //Q
            0x13, //R
            0x1F, //S
            0x14, //T
            0x16, //U
            0x2F, //V
            0x11, //W
            0x2D, //X
            0x15, //Y
            0x2C  //Z
        };

        public enum DXCode
        {
            Symbol,
            Shifted
        }
        public static Tuple<DXCode, ushort> CharToDXCODES(char c)
        {
            byte c_u8 = Convert.ToByte(c);

            if (Char.IsLower(c))
            {
                c_u8 &= 0xdf;
            }

            if (Char.IsWhiteSpace(c))
            {
                return Tuple.Create(DXCode.Symbol, (ushort)0x39);
            }

            if (c_u8 < 0x5B && c_u8 > 0x2B) {
                byte index = (byte)(c_u8 - 0x2C);
                ushort code = CHAR_MAPPING[index];
                // println!("{} {}", index, code);
                if (code == 0x0) {
                    return null;
                }
                else if (Char.IsUpper(c)) {
                    // Press SHIFT
                    return Tuple.Create(DXCode.Shifted, code);
                }
                else
                {
                    return Tuple.Create(DXCode.Symbol, code);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
