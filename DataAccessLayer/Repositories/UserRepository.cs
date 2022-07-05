using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IDisposable
    {
        TicketsContext context = new TicketsContext();

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public void CreateOrUpdate(User user)
        {
            context.Users.AddOrUpdate(user);
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        ~UserRepository()
        {
            context.Dispose();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
