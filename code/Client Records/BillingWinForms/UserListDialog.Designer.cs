namespace BillingWinForms
{
    partial class UserListDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbCnp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbWeigth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTimeExp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lbName = new System.Windows.Forms.Label();
            this.lbCnp = new System.Windows.Forms.Label();
            this.lbAge = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbWeight = new System.Windows.Forms.Label();
            this.cbPregnant = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume si prenume";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(183, 71);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 1;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            this.tbName.Validating += new System.ComponentModel.CancelEventHandler(this.tbName_Validating);
            // 
            // tbCnp
            // 
            this.tbCnp.Location = new System.Drawing.Point(183, 45);
            this.tbCnp.Name = "tbCnp";
            this.tbCnp.Size = new System.Drawing.Size(100, 20);
            this.tbCnp.TabIndex = 0;
            this.tbCnp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCnp_KeyDown);
            this.tbCnp.Validating += new System.ComponentModel.CancelEventHandler(this.tbCnp_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CNP";
            // 
            // tbAge
            // 
            this.tbAge.Enabled = false;
            this.tbAge.Location = new System.Drawing.Point(183, 99);
            this.tbAge.Name = "tbAge";
            this.tbAge.Size = new System.Drawing.Size(100, 20);
            this.tbAge.TabIndex = 2;
            this.tbAge.Text = "0";
            this.tbAge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAge_KeyDown);
            this.tbAge.Validating += new System.ComponentModel.CancelEventHandler(this.tbAge_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Varsta";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(183, 149);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(100, 20);
            this.tbHeight.TabIndex = 4;
            this.tbHeight.Text = "0";
            this.tbHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHeight_KeyPress);
            this.tbHeight.Leave += new System.EventHandler(this.tbHeight_Leave);
            this.tbHeight.Validating += new System.ComponentModel.CancelEventHandler(this.tbHeight_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Inaltime (cm)";
            // 
            // tbWeigth
            // 
            this.tbWeigth.Location = new System.Drawing.Point(183, 175);
            this.tbWeigth.Name = "tbWeigth";
            this.tbWeigth.Size = new System.Drawing.Size(100, 20);
            this.tbWeigth.TabIndex = 5;
            this.tbWeigth.Text = "0";
            this.tbWeigth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWeigth_KeyPress);
            this.tbWeigth.Leave += new System.EventHandler(this.tbWeigth_Leave);
            this.tbWeigth.Validating += new System.ComponentModel.CancelEventHandler(this.tbWeigth_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Greutate (kg)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Insarcinata (Luna/Nu)";
            // 
            // tbTimeExp
            // 
            this.tbTimeExp.Location = new System.Drawing.Point(183, 231);
            this.tbTimeExp.Name = "tbTimeExp";
            this.tbTimeExp.Size = new System.Drawing.Size(100, 20);
            this.tbTimeExp.TabIndex = 7;
            this.tbTimeExp.Text = "0";
            this.tbTimeExp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTimeExp_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Timpul expunerii (sec)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Data expunerii";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(111, 315);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(196, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbSex
            // 
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cbSex.Location = new System.Drawing.Point(183, 125);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(100, 21);
            this.cbSex.TabIndex = 3;
            this.cbSex.Text = "M";
            this.cbSex.Enter += new System.EventHandler(this.cbSex_Enter);
            this.cbSex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSex_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(129, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Sex M/F";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(143, 260);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(140, 20);
            this.dtDate.TabIndex = 8;
            this.dtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtDate_KeyDown);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(301, 74);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(0, 13);
            this.lbName.TabIndex = 20;
            // 
            // lbCnp
            // 
            this.lbCnp.AutoSize = true;
            this.lbCnp.Location = new System.Drawing.Point(301, 48);
            this.lbCnp.Name = "lbCnp";
            this.lbCnp.Size = new System.Drawing.Size(0, 13);
            this.lbCnp.TabIndex = 21;
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Location = new System.Drawing.Point(301, 99);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(0, 13);
            this.lbAge.TabIndex = 22;
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(304, 153);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(0, 13);
            this.lbHeight.TabIndex = 23;
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.Location = new System.Drawing.Point(304, 175);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(0, 13);
            this.lbWeight.TabIndex = 24;
            // 
            // cbPregnant
            // 
            this.cbPregnant.FormattingEnabled = true;
            this.cbPregnant.Items.AddRange(new object[] {
            "NU",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbPregnant.Location = new System.Drawing.Point(183, 204);
            this.cbPregnant.Name = "cbPregnant";
            this.cbPregnant.Size = new System.Drawing.Size(100, 21);
            this.cbPregnant.TabIndex = 6;
            this.cbPregnant.Text = "NU";
            this.cbPregnant.Enter += new System.EventHandler(this.cbPregnant_Enter);
            this.cbPregnant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPregnant_KeyDown);
            // 
            // UserListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 401);
            this.Controls.Add(this.cbPregnant);
            this.Controls.Add(this.lbWeight);
            this.Controls.Add(this.lbHeight);
            this.Controls.Add(this.lbAge);
            this.Controls.Add(this.lbCnp);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbTimeExp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbWeigth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbAge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCnp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "UserListDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adaugarea unei noi inregistrari";
            this.Load += new System.EventHandler(this.UserListDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbCnp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbWeigth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTimeExp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbCnp;
        private System.Windows.Forms.Label lbAge;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.ComboBox cbPregnant;
    }
}