using Spartdungeon.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spartdungeon.DTOs
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public Job job { get; set; }
        public float Health { get; set; }
        public float Attack { get; set; }
        public float Defense { get; set; }
        public float CurrHealth { get; set; }
        public int Money {  get; set; }
    }
}
