using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seeder_app_C_sharp.Structs
{
    internal class PlayerList
    {
        public int Index { get; set; }
        public int TeamID { get; set; }
        public byte Mark { get; set; }

        public int Rank { get; set; }
        public string Name { get; set; }
        public long PersionID { get; set; }
        public int Kill { get; set; }
        public int Dead { get; set; }
        public int Score { get; set; }
        public float KD { get; set; }
        public float KPM { get; set; }
    }
}
