using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystems.Rooms
{
    public class RoomDto
    {
        public int Id { get; set; }
        public byte Number { get; set; }
        public byte Floor { get; set; }
        public string Name
        {
            get
            {
                return string.Concat(Floor, Number.ToString().PadLeft(2, '0'));
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

        public string Maintanance
        {
            get
            {
                if(InMaintanance==true)
                {
                    return ("Müsait Değil");
                }
                else
                {
                    return ("Müsait");
                }
            }
        }
    }
}
