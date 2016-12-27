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
using System.Globalization;

namespace BillingWinForms
{
    public partial class UserListDialog : Form
    {
        public UserListDialog()
        {
            InitializeComponent();
        }
        
        public User User
        {
            get;
            set;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (User == null)
            {
                
                User = new User();

                User.Name = tbName.Text;
                User.Cnp = Double.Parse(tbCnp.Text);
                User.Age = Int32.Parse(tbAge.Text);
                User.Sex = cbSex.Text;
                User.Height = Int32.Parse(tbHeight.Text);
                User.Weight = Int32.Parse(tbWeigth.Text);
                User.Pregnant = cbPregnant.Text;
                if (tbTimeExp.Text.IndexOf(",") == -1) //ha van vesszo
                {
                    User.TimeExp = float.Parse(tbTimeExp.Text, CultureInfo.InvariantCulture.NumberFormat);
                }
                else
                {
                    string s = tbTimeExp.Text;
                    char[] array = s.ToCharArray();
                    array[tbTimeExp.Text.IndexOf(",")] = '.';
                    s = new string(array);
                    User.TimeExp = float.Parse(s, CultureInfo.InvariantCulture.NumberFormat);
                }
                User.DateExp = dtDate.Value.ToString("dd-MM-yyyy"); 

                var db = BusinessLogic.DB;
                db.InsertUser(User);
            }
            else
            {
                User.Name = tbName.Text;
                User.Cnp = Double.Parse(tbCnp.Text);
                User.Age = Int32.Parse(tbAge.Text);
                User.Sex = cbSex.Text;
                User.Height = Int32.Parse(tbHeight.Text);
                User.Weight = Int32.Parse(tbWeigth.Text);
                User.Pregnant = cbPregnant.Text;
                if (tbTimeExp.Text.IndexOf(",") == -1)
                {
                    User.TimeExp = float.Parse(tbTimeExp.Text, CultureInfo.InvariantCulture.NumberFormat);
                }
                else
                {
                    string s = tbTimeExp.Text;
                    char[] array = s.ToCharArray();
                    array[tbTimeExp.Text.IndexOf(",")] = '.';
                    s = new string(array);
                    User.TimeExp = float.Parse(s, CultureInfo.InvariantCulture.NumberFormat);

                }
                User.DateExp = dtDate.Value.ToString("dd-MM-yyyy"); 
            }
            this.DialogResult = DialogResult.OK;
        }

        private void UserListDialog_Load(object sender, EventArgs e)
        {
            //BusinessLogic.DB.calculateAge();
            btnOK.Enabled = false;
            if (User != null)
            {
                tbName.Text = User.Name ?? "";
                tbCnp.Text = User.Cnp.ToString() ?? "";
                tbAge.Text = User.Age.ToString() ?? "";
                cbSex.Text = User.Sex ?? "";
                tbHeight.Text = User.Height.ToString() ?? "";
                tbWeigth.Text = User.Weight.ToString() ?? "";
                cbPregnant.Text = User.Pregnant ?? "";
                tbTimeExp.Text = User.TimeExp.ToString() ?? "";
                dtDate.Value = DateTime.ParseExact(User.DateExp, "dd'-'MM'-'yyyy", CultureInfo.InvariantCulture);
            }
        }

        //TEXTBOX VALIDATIONS

        private bool ValidateInputs()
        {

            bool everythingValid = true;
            //NAME
            string s = tbName.Text;
            bool HasNumber = (from a in s.ToCharArray() where a >= '0' && a <= '9' select a).Any();
            if ((HasNumber) || (tbName.Text.Length == 0))
            {
                lbName.Text = "X";
                lbName.ForeColor = Color.Red;
                everythingValid = false;
            }
            else
            {
                lbName.Text = "✓";
                lbName.ForeColor = Color.Green;
            }

            //CNP
            if (BusinessLogic.DB.doesUserExist(tbCnp.Text))
            {
                User temp = BusinessLogic.DB.getExistingUserData(tbCnp.Text);
                tbName.Text = temp.Name;
                cbSex.Text = temp.Sex;
                tbAge.Text = BusinessLogic.DB.calculateAge(tbCnp.Text).ToString();

            }
            else
            {
                if (!BusinessLogic.DB.VerifyCnp(tbCnp.Text))
                {
                    lbCnp.Text = "X";
                    lbCnp.ForeColor = Color.Red;
                    everythingValid = false;
                }
                else
                {
                    lbCnp.Text = "✓";
                    lbCnp.ForeColor = Color.Green;
                    
                    tbAge.Text = BusinessLogic.DB.calculateAge(tbCnp.Text).ToString();
                    cbSex.Text = BusinessLogic.DB.determineSex(tbCnp.Text).ToString();
                }
            }

            //AGE
            if ((Int32.Parse(tbAge.Text) <= 0) || (Int32.Parse(tbAge.Text) > 130) || (tbAge.Text.Length == 0) || (tbAge.Text.Length == 0))
            {
                lbAge.Text = "";
                lbAge.ForeColor = Color.Red;
                everythingValid = false;
            }
            else
            {
                lbAge.Text = "✓";
                lbAge.ForeColor = Color.Green;
            }

            //HEIGHT
            if ((Int32.Parse(tbHeight.Text) <= 0) || (Int32.Parse(tbHeight.Text) > 250) || (tbHeight.Text.Length == 0))
            {
                lbHeight.Text = "X";
                lbHeight.ForeColor = Color.Red;
                everythingValid = false;
            }
            else
            {
                lbHeight.Text = "✓";
                lbHeight.ForeColor = Color.Green;
            }

            //WEIGHT
            if ((Int32.Parse(tbWeigth.Text) <= 0) || (Int32.Parse(tbWeigth.Text) > 250) || (tbWeigth.Text.Length == 0))
            {
                lbWeight.Text = "X";
                lbWeight.ForeColor = Color.Red;
                everythingValid = false;
            }
            else
            {
                lbWeight.Text = "✓";
                lbWeight.ForeColor = Color.Green;
            }

            btnOK.Enabled = everythingValid;
            return everythingValid;
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            ValidateInputs();
        }

        //CNP
        private void tbCnp_Validating(object sender, CancelEventArgs e)
        {
            ValidateInputs();
        }

        //AGE
        private void tbAge_Validating(object sender, CancelEventArgs e)
        {
            ValidateInputs();
        }

        //SEX
        private void cbSex_Enter(object sender, EventArgs e)
        {
            this.cbSex.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //HEIGHT
        private void tbHeight_Validating(object sender, CancelEventArgs e)
        {
            ValidateInputs();
        }
        
        //PREGNANCY
        private void cbPregnant_Enter(object sender, EventArgs e)
        {
            this.cbPregnant.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //TIME


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tbWeigth_Validating(object sender, CancelEventArgs e)
        {
            ValidateInputs();
        }

        //PASS FOCUS ALONG CORRECTLY
        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbSex.Focus();   
            }
        }

        private void tbCnp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbName.Focus();
            }
        }

        private void tbAge_KeyDown(object sender, KeyEventArgs e)
        {
        
            if (e.KeyCode == Keys.Enter)
            {
                cbSex.Focus();
            }
        }

        private void cbSex_KeyDown(object sender, KeyEventArgs e)
        {   
            
            if (e.KeyCode == Keys.Enter)
            {
                tbHeight.Focus();
            }
        }

        private void tbHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbHeight.Text=="")
            {
                tbHeight.Text = "0";
            }
            if (Convert.ToInt32(tbHeight.Text) < 5000)
            {
                if (Char.IsDigit(e.KeyChar)||(e.KeyChar == '\b'))
                {
                    // digits or backspace are OK 
                }
                else if (e.KeyChar.ToString() == Keys.Enter.ToString())
                {
                    tbWeigth.Focus();
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
        private void tbHeight_Leave(object sender, EventArgs e)
        {
            if (tbHeight.Text == "")
            {
                tbHeight.Text = "0";
            }
        }

        private void tbWeigth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbWeigth.Text=="")
            {
                tbWeigth.Text = "0";
            }
            if(Convert.ToInt32(tbWeigth.Text)<5000)
            {
                if (Char.IsDigit(e.KeyChar) || (e.KeyChar == '\b'))
                {
                    // digits or backspace are OK 
                }
                else if (e.KeyChar.ToString() == Keys.Enter.ToString())
                {
                    cbPregnant.Focus();
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
        private void tbWeigth_Leave(object sender, EventArgs e)
        {
            if (tbWeigth.Text == "")
            {
                tbWeigth.Text = "0";
            }

        }

        private void cbPregnant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbTimeExp.Focus();
            }
        }

        private void tbTimeExp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtDate.Focus();
            }
        }

        private void dtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.Focus();
            }
        }

        private void UserListDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }




        



       


        

        

        

        

        

        

        

    

        

     

    }
}
