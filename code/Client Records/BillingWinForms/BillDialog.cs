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
    public partial class BillDialog : Form
    {
        public BillDialog()
        {
            InitializeComponent();
        }

        public Bill Bill { get; set; }

        List<BillLine> lines = new List<BillLine>();
        List<int> deletedLineIDs = new List<int>();
        


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lines.Count == 0)
            {
                MessageBox.Show("Must add at least one article!");
                return;
            }

            int customerId = (int)cmbCustomer.SelectedValue;
            DateTime date = dtDate.Value.Date;

            long number = 0;
            if (!long.TryParse(tbNumber.Text, out number))
            {
                MessageBox.Show("Enter a number!"); 
                tbNumber.Focus();
                return;
            }

            if (Bill == null)
            {
                Bill = new Bill() { CustomerID = customerId, Number = number, Date = date };
                BusinessLogic.DB.InsertBill(Bill);
            }
            else
            {
                Bill.CustomerID = customerId;
                Bill.Number = number;
                Bill.Date = date;
            }

            foreach (BillLine line in lines)
            {
                if (line.BillLineID == 0)
                {
                    line.BillID = Bill.BillID;
                    BusinessLogic.DB.InsertBillLine(line);
                }
                else
                {
                    BusinessLogic.DB.UpdateBillLine(line);
                }
            }

            foreach (int billLineId in deletedLineIDs)
            {
                BusinessLogic.DB.DeleteBillLine(billLineId);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void BillDialog_Load(object sender, EventArgs e)
        {
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.DataSource = BusinessLogic.DB.GetCustomers();

            if (Bill != null)
            {
                cmbCustomer.SelectedValue = Bill.CustomerID;

                tbNumber.Text = Bill.Number.ToString();

                dtDate.Value = Bill.Date;

                foreach (BillLine line in BusinessLogic.DB.GetBillLines(Bill.BillID))
                {
                    lines.Add(line.Copy());
                }
            }
            else
            {
                dtDate.Value = DateTime.Now.Date;
                tbNumber.Text = BusinessLogic.DB.NextBillNumber.ToString();
            }

            RefreshList();

        }

        public void RefreshList()
        {
            billLinesListView.Items.Clear();

            int i = 0;
            foreach (BillLine line in lines)
            {
                ListViewItem item = billLinesListView.Items.Add(BusinessLogic.DB.GetArticleName(line.ArticleID));
                item.SubItems.Add(line.Quantity.ToString());
                item.SubItems.Add(line.ExpireDate.ToShortDateString());
                item.SubItems.Add(line.DiscountValue.ToString());
                item.Tag = i;
                i++;
            }

            tbTotal.Text = BusinessLogic.DB.GetBillTotal(lines.ToArray()).ToString();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            BillLineDialog bLineDlg = new BillLineDialog();
            bLineDlg.Lines = this.lines;

            if (bLineDlg.ShowDialog() == DialogResult.OK)
            {
                RefreshList();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (billLinesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item selected.");
                return;
            }

            int index = (int) billLinesListView.SelectedItems[0].Tag;
            BillLineDialog bLineDlg = new BillLineDialog();
            bLineDlg.BillLine = lines[index];

            if (bLineDlg.ShowDialog() == DialogResult.OK)
            {
                RefreshList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (billLinesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item selected.");
                return;
            }

            int index = (int)billLinesListView.SelectedItems[0].Tag;

            int lineId = lines[index].BillLineID;

            lines.RemoveAt(index);

            if (lineId != 0)
            {
                deletedLineIDs.Add(lineId);
            }
            RefreshList();

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  

    }
}
