using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastname { get; set; }
        public string UserEmail { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public DateTime Birthday { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
