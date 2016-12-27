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
    public partial class BillsForm : Form
    {
        public BillsForm()
        {
            InitializeComponent();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        public void RefreshList()
        {
            billListView.Items.Clear();
            BusinessLogic db = BusinessLogic.DB;

            Bill[] list = db.GetBills();

            foreach(Bill bill in list)
            {
                ListViewItem item = billListView.Items.Add(bill.BillID.ToString());
                item.SubItems.Add(db.GetCustomerName(bill.CustomerID));
                item.SubItems.Add(bill.Number.ToString());
                item.SubItems.Add(bill.Date.ToShortDateString());
                item.SubItems.Add(db.GetBillTotal(bill.BillID).ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            BillDialog dlg = new BillDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                RefreshList();    
            }
            
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (billListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item selected.");
                return;
            }
            int id = Int32.Parse(billListView.SelectedItems[0].Text);
            Bill b = BusinessLogic.DB.GetBill(id);
            BillDialog dlg = new BillDialog();
            dlg.Bill = b;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                RefreshList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (billListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item selected.");
                return;
            }
            int id = Int32.Parse(billListView.SelectedItems[0].Text);

            if (MessageBox.Show("Delete selected item?","Question", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            BusinessLogic.DB.DeleteBill(id);
            RefreshList();

        }
    }
}
