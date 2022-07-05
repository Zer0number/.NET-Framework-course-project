using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TicketRepository : IDisposable
    {
        TicketsContext context = new TicketsContext();

        public List<Ticket> GetAll()
        {
            return context.Tickets.ToList();
        }

        public Ticket Get(int id)
        {
            return context.Tickets.Find(id);
        }

        public void CreateOrUpdate(Ticket ticket)
        {
            context.Tickets.AddOrUpdate(ticket);
        }

        public void Delete(Ticket ticket)
        {
            context.Tickets.Remove(ticket);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        ~TicketRepository()
        {
            context.Dispose();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
