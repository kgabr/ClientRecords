using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Billing;

namespace BillingWinForms
{
    public partial class CustomerDialog : Form
    {
        public CustomerDialog()
        {
            InitializeComponent();
        }

        public Customer Customer
        {
            get; set;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Customer == null)
            {
                Customer = new Customer() { Name = tbName.Text, Address = tbAddress.Text };
                var db = BusinessLogic.DB;
                db.InsertCustomer(Customer);
            }
            else
            {
                Customer.Name = tbName.Text;
                Customer.Address = tbAddress.Text;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                tbName.Text = Customer.Name ?? "";
                tbAddress.Text = Customer.Address ?? "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
