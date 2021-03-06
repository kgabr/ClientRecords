﻿namespace BillingWinForms
{
    partial class UserListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserListForm));
            this.userListFormListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNew = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dtShowFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewWithLastUser = new System.Windows.Forms.Button();
            this.dtShowUntil = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // userListFormListView
            // 
            this.userListFormListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.userListFormListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.userListFormListView.FullRowSelect = true;
            this.userListFormListView.GridLines = true;
            this.userListFormListView.Location = new System.Drawing.Point(12, 69);
            this.userListFormListView.MaximumSize = new System.Drawing.Size(1887, 1500);
            this.userListFormListView.Name = "userListFormListView";
            this.userListFormListView.Size = new System.Drawing.Size(891, 473);
            this.userListFormListView.TabIndex = 0;
            this.userListFormListView.UseCompatibleStateImageBehavior = false;
            this.userListFormListView.View = System.Windows.Forms.View.Details;
            this.userListFormListView.DoubleClick += new System.EventHandler(this.btnModify_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "id";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nr. Crt";
            this.columnHeader2.Width = 49;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nume si Prenume";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CNP";
            this.columnHeader4.Width = 101;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Varsta";
            this.columnHeader5.Width = 44;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Sex (M/F)";
            this.columnHeader6.Width = 63;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Inaltime (cm)";
            this.columnHeader7.Width = 75;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Greutate (kg)";
            this.columnHeader8.Width = 76;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Insarcinata (luna/NU)";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Timpul expunerii (sec)";
            this.columnHeader10.Width = 95;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Data expunerii";
            this.columnHeader11.Width = 97;
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(109, 47);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "Adauga";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnModify
            // 
            this.btnModify.Image = ((System.Drawing.Image)(resources.GetObject("btnModify.Image")));
            this.btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModify.Location = new System.Drawing.Point(174, 12);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(88, 47);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "Modifica";
            this.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(268, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 47);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Sterge";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(779, 12);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(124, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generare Raport";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dtShowFrom
            // 
            this.dtShowFrom.Location = new System.Drawing.Point(569, 13);
            this.dtShowFrom.Name = "dtShowFrom";
            this.dtShowFrom.Size = new System.Drawing.Size(200, 20);
            this.dtShowFrom.TabIndex = 5;
            this.dtShowFrom.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dtShowFrom.ValueChanged += new System.EventHandler(this.dtShowFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Afiseaza intre:";
            // 
            // btnNewWithLastUser
            // 
            this.btnNewWithLastUser.Location = new System.Drawing.Point(117, 12);
            this.btnNewWithLastUser.Name = "btnNewWithLastUser";
            this.btnNewWithLastUser.Size = new System.Drawing.Size(51, 47);
            this.btnNewWithLastUser.TabIndex = 7;
            this.btnNewWithLastUser.Text = "Din Nou";
            this.btnNewWithLastUser.UseVisualStyleBackColor = true;
            this.btnNewWithLastUser.Click += new System.EventHandler(this.btnNewWithLastUser_Click);
            // 
            // dtShowUntil
            // 
            this.dtShowUntil.Location = new System.Drawing.Point(569, 39);
            this.dtShowUntil.Name = "dtShowUntil";
            this.dtShowUntil.Size = new System.Drawing.Size(200, 20);
            this.dtShowUntil.TabIndex = 5;
            this.dtShowUntil.Value = new System.DateTime(2017, 4, 4, 0, 0, 0, 0);
            this.dtShowUntil.ValueChanged += new System.EventHandler(this.dtShowUntil_ValueChanged);
            // 
            // UserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 554);
            this.Controls.Add(this.btnNewWithLastUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtShowUntil);
            this.Controls.Add(this.dtShowFrom);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.userListFormListView);
            this.KeyPreview = true;
            this.Name = "UserListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserListForm";
            this.Load += new System.EventHandler(this.UserListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserListForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView userListFormListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DateTimePicker dtShowFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewWithLastUser;
        private System.Windows.Forms.DateTimePicker dtShowUntil;
    }
}