using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsServer
{
    public partial class ServerInterface : Form
    {
        public ServerInterface()
        {
            InitializeComponent();
            new Server().Start(listBox1);
        }

        private void LoadTickets()
        {
            using (TicketRepository repository = new TicketRepository())
            {
                dataGridView1.DataSource = repository.GetAll().Select(x => new
                {
                    x.TicketId,
                    x.TicketName,
                    x.DepartureLocation,
                    x.DestinationLocation,
                    x.Date,
                    x.Price,
                    x.Amount,
                    x.TransportType
                }).ToList();
            }
        }

        private void LoadUsers()
        {
            using (UserRepository repository = new UserRepository())
            {
                dataGridView2.DataSource = repository.GetAll().Select(x => new
                {
                    x.UserId,
                    x.UserName,
                    x.UserLastname,
                    x.UserLogin,
                    x.UserPassword
                }).ToList();
            }
        }

        private void ServerInterface_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                LoadTickets();
                LoadUsers();
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditTicket form = new AddEditTicket();
            form.ShowDialog();
            LoadTickets();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedRowTicketId = (int)dataGridView1.SelectedRows[0].Cells["TicketId"].Value;
            AddEditTicket form = new AddEditTicket(selectedRowTicketId);
            form.ShowDialog();
            LoadTickets();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRowTicketId = (int)dataGridView1.SelectedRows[0].Cells["TicketId"].Value;
            using (TicketRepository repository = new TicketRepository())
            {
                Ticket ticketToDelete = repository.Get(selectedRowTicketId);
                try
                {
                    repository.Delete(ticketToDelete);
                    repository.Save();
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show($"Cannot delete this ticket. There is still users that use have this ticket.");
                }
                LoadTickets();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddEditUser form = new AddEditUser();
            form.ShowDialog();
            LoadTickets();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int selectedRowUserId = (int)dataGridView2.SelectedRows[0].Cells["UserId"].Value;
            AddEditTicket form = new AddEditTicket(selectedRowUserId);
            form.ShowDialog();
            LoadTickets();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedRowUserId = (int)dataGridView2.SelectedRows[0].Cells["UserId"].Value;
            using (UserRepository repository = new UserRepository())
            {
                User userToDelete = repository.Get(selectedRowUserId);
                repository.Delete(userToDelete);
                repository.Save();
                LoadTickets();
            }
        }
    }
}
