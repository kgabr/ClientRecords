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
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            customerListView.Items.Clear();
            BusinessLogic db = BusinessLogic.DB;

            Customer[] list = db.GetCustomers();

            foreach(Customer cust in list)
            {
                ListViewItem item = customerListView.Items.Add(cust.CustomerID.ToString());
                item.SubItems.Add(cust.Name);
                item.SubItems.Add(cust.Address);
            }

       }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            RefreshList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CustomerDialog dlg = new CustomerDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                RefreshList();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (customerListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item selected.");
                return;
            }
            int id = Int32.Parse(customerListView.SelectedItems[0].Text);
            Customer c = BusinessLogic.DB.GetCustomer(id);
            CustomerDialog dlg = new CustomerDialog();
            dlg.Customer = c;
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                RefreshList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (customerListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select an item first.");
                return;
            }
            int id = Int32.Parse(customerListView.SelectedItems[0].Text);
            if (MessageBox.Show("Delete selected customer?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            BusinessLogic.DB.DeleteCustomer(id);
            RefreshList();
        }


    }
}
