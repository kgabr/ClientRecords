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
    public partial class UserListForm : Form
    {
        public int nrCrt = 1;

        public UserListForm()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            userListFormListView.Items.Clear();
            BusinessLogic db = BusinessLogic.DB;

            User[] list = db.GetUsers();
            List<User> showList = new List<User>();
            foreach (User user in list) 
            {
                if ((DateTime.Compare(BusinessLogic.DB.convertStringToDateTime(user.DateExp), dtShowFrom.Value) >= 0) && 
                    (DateTime.Compare(BusinessLogic.DB.convertStringToDateTime(user.DateExp), dtShowUntil.Value) <= 0))
                {
                    showList.Add(user);
                }
            }
            nrCrt = 1;
            foreach(User usr in showList)
            {
                ListViewItem item = userListFormListView.Items.Add(usr.UserID.ToString()); 
                item.SubItems.Add(nrCrt.ToString());
                item.SubItems.Add(usr.Name);
                item.SubItems.Add((usr.Cnp).ToString());
                item.SubItems.Add(usr.Age.ToString());
                item.SubItems.Add(usr.Sex);
                item.SubItems.Add(usr.Height.ToString());
                item.SubItems.Add(usr.Weight.ToString());
                item.SubItems.Add(usr.Pregnant.ToString());
                item.SubItems.Add(usr.TimeExp.ToString());
                item.SubItems.Add(usr.DateExp.ToString());
                item.SubItems.Add(usr.UserID.ToString());
                nrCrt++;
                BusinessLogic.DB.Write();
            }
        }

        private void UserListForm_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            RefreshList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            UserListDialog dlg = new UserListDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                
                RefreshList();
                
            }
        }

        private void btnNewWithLastUser_Click(object sender, EventArgs e)
        {
            User u = BusinessLogic.DB.GetLastRecordDatas();
            u.UserID++;
            UserListDialog dlg = new UserListDialog();
            dlg.isNewEntyWithLastData = true;
            dlg.User = u;
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                RefreshList();

            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (userListFormListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selectati o inregistrare!");
                return;
            }

            int id = Int32.Parse(userListFormListView.SelectedItems[0].Text);
            User u = BusinessLogic.DB.GetUser(id);
            UserListDialog dlg = new UserListDialog();
            dlg.User = u;
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                RefreshList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (userListFormListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selectati o inregistrare!");
                return;
            }
            int id = Int32.Parse(userListFormListView.SelectedItems[0].Text);
            if (MessageBox.Show("Stergeti inregistrarea selectata?", "Atentie!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            BusinessLogic.DB.DeleteUser(id);
            
            RefreshList();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            UserListGenerateDialog dlg = new UserListGenerateDialog();
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void UserListForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Control nextControl;
            if (e.KeyCode == Keys.F5)
            {
                UserListDialog dlg = new UserListDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void dtShowFrom_ValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void dtShowUntil_ValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
