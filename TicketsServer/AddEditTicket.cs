using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsServer
{
    public partial class AddEditTicket : Form
    {
        Ticket ticketToEdit;
        public AddEditTicket(int ticketId = 0)
        {
            InitializeComponent();
            if(ticketId != 0)
            {
                using (TicketRepository repository = new TicketRepository())
                {
                    ticketToEdit = repository.Get(ticketId);
                    textBox1.Text = ticketToEdit.TicketName;
                    textBox2.Text = ticketToEdit.DepartureLocation;
                    textBox3.Text = ticketToEdit.DestinationLocation;
                    textBox4.Text = ticketToEdit.Date.ToString();
                    textBox5.Text = Convert.ToInt32(ticketToEdit.Price).ToString();
                    textBox6.Text = Convert.ToInt32(ticketToEdit.Amount).ToString();
                    textBox7.Text = ticketToEdit.TransportType;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(TicketRepository repository = new TicketRepository())
            {
                if(ticketToEdit == null)
                {
                    ticketToEdit = new Ticket();
                }

                ticketToEdit.TicketName = textBox1.Text;
                ticketToEdit.DepartureLocation = textBox2.Text;
                ticketToEdit.DestinationLocation = textBox3.Text;
                ticketToEdit.Date = Convert.ToDateTime(textBox4.Text);
                ticketToEdit.Price = Convert.ToInt32(textBox5.Text);
                ticketToEdit.Amount  = Convert.ToInt32(textBox6.Text);
                ticketToEdit.TransportType = textBox7.Text;

                repository.CreateOrUpdate(ticketToEdit);
                repository.Save();
            }
            this.Close();
        }
    }
}
