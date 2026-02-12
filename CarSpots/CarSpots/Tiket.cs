using System;
using System.Collections.Generic;
using System.Text;

namespace CarSpots
{
    public class Tiket
    {
        public Guid TicketId { get; set; } = Guid.NewGuid();
        public bool Valid { get; set; }
        public string LicensePlate { get; set; }
    }
}
