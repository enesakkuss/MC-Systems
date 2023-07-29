using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystems.DataAccess.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public byte Number { get; set; }
        public byte Floor { get; set; }
        public string Name 
        { 
            get
            {
                return string.Concat(Floor, Number.ToString().PadLeft(3,'0'));
            }
        }
        public string Description 
        { 
            get
            {
                return string.Empty;
            }
        }
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public bool InMaintanance { get; set; }
        
    }
}
