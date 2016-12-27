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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            userListForm.WindowState = FormWindowState.Maximized;
            userListForm.MdiParent = this;
            userListForm.Show();
            customersToolStripMenuItem.Visible = false;
        }
        UserListForm userListForm = new UserListForm();
        CustomersForm customersForm = new CustomersForm();
        BillsForm billsForm = new BillsForm();
        ArticlesForm articlesForm = new ArticlesForm();

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOrHideForm(customersForm);
        }

        private void showOrHideForm(Form form)
        {
            if (!form.Visible)
            {
                form.WindowState = FormWindowState.Normal;
                form.MdiParent = this;
                form.Show();
                form.WindowState = FormWindowState.Maximized;
            }
            else if (form == ActiveMdiChild)
            {
                form.Hide();
            } 
            else
            {
                form.Activate();
            }

        }

        private void showUserListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOrHideForm(userListForm);
        }
        private void billsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOrHideForm(billsForm);
        }

        private void articlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOrHideForm(articlesForm);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BusinessLogic.DB.Write();
            BusinessLogic.DB.CreateBackup();
            BusinessLogic.DB.WriteStatus();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitForm exitForm = new ExitForm();
            if (exitForm.ShowDialog() != DialogResult.Yes)
            {
                e.Cancel = true;
            }

        }


       
        
    }
}
