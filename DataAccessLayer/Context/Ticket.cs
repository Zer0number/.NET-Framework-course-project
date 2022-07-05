using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public string DepartureLocation { get; set; }
        public string DestinationLocation { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string TransportType { get; set; }
    }
}
