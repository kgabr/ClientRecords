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
    public partial class ArticlesForm : Form
    {
        public ArticlesForm()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            articleListView.Items.Clear();

            Article[] list = BusinessLogic.DB.GetArticles();

            foreach(Article art in list)
            {
                ListViewItem item = articleListView.Items.Add(art.ArticleID.ToString());
                item.SubItems.Add(art.Name);
                item.SubItems.Add(art.Price.ToString());
                item.SubItems.Add(art.Quantity.ToString());
            }
        }

        private void ArticlesForm_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            RefreshList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ArticleDialog form = new ArticleDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshList();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (articleListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item selected.");
                return;
            }
            int id = Int32.Parse(articleListView.SelectedItems[0].Text);
            Article a = BusinessLogic.DB.GetArticle(id);
            ArticleDialog dlg = new ArticleDialog();
            dlg.Article = a;
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                RefreshList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (articleListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select an item first.");
                return;
            }
            int id = Int32.Parse(articleListView.SelectedItems[0].Text);
            if (MessageBox.Show("Delete selected article?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            BusinessLogic.DB.DeleteArticle(id);
            RefreshList();
        }


        
    }
}
