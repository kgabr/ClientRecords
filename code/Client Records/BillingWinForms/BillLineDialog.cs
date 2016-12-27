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
    public partial class BillLineDialog : Form
    {
        public BillLine BillLine
        {
            get;
            set;
        }

        public BillLineDialog()
        {
            InitializeComponent();
        }

        public List<BillLine> Lines { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int articleID = (int)cmbArticle.SelectedValue;
            decimal quantity;
            if (!decimal.TryParse(tbQuantity.Text, out quantity))
            {
                MessageBox.Show("Enter a number!");
                tbQuantity.Focus();
                return;
                // TODO: MessageBox, Focus
                
            }

            DateTime expireDate = dtExpireDate.Value.Date;
            decimal discountValue;
            if (!decimal.TryParse(tbDiscountValue.Text, out discountValue))
            {
                MessageBox.Show("Enter a number!");
                tbDiscountValue.Focus();
                // TODO: MessageBox, Focus
                return;
            }




            if(BillLine == null)
            {
                
                BillLine = new BillLine() { ArticleID = articleID, Quantity = quantity, ExpireDate = expireDate, DiscountValue = discountValue };
                Lines.Add(BillLine);
            }
            else
            {
                BillLine.ArticleID = articleID;
                BillLine.Quantity = quantity;
                BillLine.ExpireDate = expireDate;
                BillLine.DiscountValue = discountValue;
            }
            this.DialogResult = DialogResult.OK;

        }

        private void BillLineDialog_Load(object sender, EventArgs e)
        {
            
            cmbArticle.DisplayMember = "Name";
            cmbArticle.ValueMember = "ArticleID";
            cmbArticle.DataSource = BusinessLogic.DB.GetArticles();
            tbDiscountValue.Text = "0";
            if (BillLine != null)
            {
                cmbArticle.SelectedValue = BillLine.ArticleID;
                tbQuantity.Text = BillLine.Quantity.ToString();
                tbDiscountValue.Text = BillLine.DiscountValue.ToString();
                dtExpireDate.Value = BillLine.ExpireDate;
            }

        }


    }
}
