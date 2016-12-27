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
    public partial class ArticleDialog : Form
    {
        public ArticleDialog()
        {
            InitializeComponent();
        }


        public Article Article
        {
            get; set;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            decimal price;
            int quantity;
            bool validPrice, validQuantity;

            validPrice = decimal.TryParse(tbPrice.Text,out price);
            validQuantity = int.TryParse(tbQuantity.Text, out quantity);
            if (!validPrice||!validQuantity)
            {
                MessageBox.Show("Invalid entries!");
                return;
            }
            if (Article == null)
            {
                Article = new Article() { Name = tbName.Text, Price = decimal.Parse(tbPrice.Text), Quantity = int.Parse(tbQuantity.Text) };
                BusinessLogic.DB.InsertArticle(Article);
            }
            else
            {
                Article.Name = tbName.Text;
                Article.Price = decimal.Parse(tbPrice.Text);
                Article.Quantity = int.Parse(tbQuantity.Text);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void ArticleDialog_Load(object sender, EventArgs e)
        {
            if (Article != null)
            {
                tbName.Text = Article.Name ?? "";
                tbPrice.Text = Article.Price.ToString() ?? "";
                tbQuantity.Text = Article.Quantity.ToString() ?? "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        
        
    }
}
