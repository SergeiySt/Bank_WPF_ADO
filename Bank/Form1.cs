using Bank.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bank
{
    public partial class Form1 : Form
    {
        private MCCodeFitrs _context;
        public Form1()
        {
            InitializeComponent();
            _context = new MCCodeFitrs();

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            var data = (from p in _context.Persons
                        join r in _context.Roles on p.RoleId equals r.Id
                        join a in _context.Accounts on p.AccountId equals a.Id
                        select new
                        {
                            p.Id,
                            Role = r.Name,
                            Account = a.Number,
                            Amount = a.Amount,
                            p.Name
                        }).ToList();

            dataGridView.DataSource = data;
            dataGridView.Columns["Id"].Visible = false;
        }

        private void AddRecord_Click(object sender, EventArgs e)
        {
            var person = new Person
            {
                Name = txtName.Text,
                RoleId = int.Parse(txtRole.Text),
                AccountId = int.Parse(txtAccount.Text)
            };

            _context.Persons.Add(person);
            _context.SaveChanges();

            txtName.Text = "";
            txtRole.Text = "";
            txtAccount.Text = "";

            LoadData();
        }
    }
    }
}
