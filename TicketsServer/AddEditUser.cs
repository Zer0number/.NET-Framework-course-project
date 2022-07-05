using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsServer
{
    public partial class AddEditUser : Form
    {
        User userToEdit;
        public AddEditUser(int userId = 0)
        {
            InitializeComponent();
            if(userId != 0)
            {
                using(UserRepository repository = new UserRepository())
                {
                    userToEdit = repository.Get(userId);
                    textBox1.Text = userToEdit.UserName;
                    textBox2.Text = userToEdit.UserLastname;
                    textBox3.Text = userToEdit.UserEmail;
                    textBox4.Text = userToEdit.UserLogin;
                    textBox5.Text = userToEdit.UserPassword;
                    textBox5.Text = userToEdit.Birthday.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(UserRepository repository = new UserRepository())
            {
                if(userToEdit == null)
                {
                    userToEdit = new User();
                }

                userToEdit.UserName = textBox1.Text;
                userToEdit.UserLastname = textBox2.Text;
                userToEdit.UserEmail = textBox3.Text;
                userToEdit.UserLogin = textBox4.Text;
                userToEdit.UserPassword = textBox5.Text;
                userToEdit.Birthday = Convert.ToDateTime(textBox6.Text);

                repository.CreateOrUpdate(userToEdit);
                repository.Save();
            }
            this.Close();
        }
    }
}
