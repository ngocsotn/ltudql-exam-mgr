namespace UI.Views
{
    partial class FormSystemAddUser
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.checkBoxSpecializedClass = new System.Windows.Forms.CheckBox();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.comboBoxPermission = new System.Windows.Forms.ComboBox();
            this.textBoxPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPasswordConfirmation = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxFullname = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelFullname = new System.Windows.Forms.Label();
            this.labelDateofBirth = new System.Windows.Forms.Label();
            this.maskedTextBoxDateofBirth = new System.Windows.Forms.MaskedTextBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelPermission = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(192, 494);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(155, 69);
            this.buttonCancel.TabIndex = 22;
            this.buttonCancel.Text = "Đóng";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(9, 494);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(154, 69);
            this.buttonAdd.TabIndex = 21;
            this.buttonAdd.Text = "Thêm";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpecializedClass
            // 
            this.checkBoxSpecializedClass.AutoSize = true;
            this.checkBoxSpecializedClass.Location = new System.Drawing.Point(56, 453);
            this.checkBoxSpecializedClass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxSpecializedClass.Name = "checkBoxSpecializedClass";
            this.checkBoxSpecializedClass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxSpecializedClass.Size = new System.Drawing.Size(82, 17);
            this.checkBoxSpecializedClass.TabIndex = 20;
            this.checkBoxSpecializedClass.Text = "Lớp chuyên";
            this.checkBoxSpecializedClass.UseVisualStyleBackColor = true;
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(46, 426);
            this.comboBoxGender.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(264, 25);
            this.comboBoxGender.TabIndex = 19;
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new System.Drawing.Point(46, 384);
            this.comboBoxSubject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(264, 25);
            this.comboBoxSubject.TabIndex = 17;
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Location = new System.Drawing.Point(46, 343);
            this.comboBoxClass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(264, 25);
            this.comboBoxClass.TabIndex = 15;
            // 
            // comboBoxPermission
            // 
            this.comboBoxPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPermission.FormattingEnabled = true;
            this.comboBoxPermission.Location = new System.Drawing.Point(46, 301);
            this.comboBoxPermission.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxPermission.Name = "comboBoxPermission";
            this.comboBoxPermission.Size = new System.Drawing.Size(264, 25);
            this.comboBoxPermission.TabIndex = 13;
            this.comboBoxPermission.SelectedIndexChanged += new System.EventHandler(this.comboBoxPermission_SelectedIndexChanged);
            // 
            // textBoxPasswordConfirmation
            // 
            this.textBoxPasswordConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswordConfirmation.Location = new System.Drawing.Point(46, 261);
            this.textBoxPasswordConfirmation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPasswordConfirmation.Name = "textBoxPasswordConfirmation";
            this.textBoxPasswordConfirmation.Size = new System.Drawing.Size(264, 23);
            this.textBoxPasswordConfirmation.TabIndex = 11;
            this.textBoxPasswordConfirmation.UseSystemPasswordChar = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(46, 220);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(264, 23);
            this.textBoxPassword.TabIndex = 9;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPasswordConfirmation
            // 
            this.labelPasswordConfirmation.AutoSize = true;
            this.labelPasswordConfirmation.BackColor = System.Drawing.Color.Transparent;
            this.labelPasswordConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordConfirmation.Location = new System.Drawing.Point(53, 245);
            this.labelPasswordConfirmation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPasswordConfirmation.Name = "labelPasswordConfirmation";
            this.labelPasswordConfirmation.Size = new System.Drawing.Size(100, 13);
            this.labelPasswordConfirmation.TabIndex = 10;
            this.labelPasswordConfirmation.Text = "Xác nhận mật khẩu";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(46, 180);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(264, 23);
            this.textBoxEmail.TabIndex = 7;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(53, 204);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(52, 13);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Mật khẩu";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(46, 139);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(264, 23);
            this.textBoxAddress.TabIndex = 5;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(53, 163);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "Email";
            // 
            // textBoxFullname
            // 
            this.textBoxFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFullname.Location = new System.Drawing.Point(46, 58);
            this.textBoxFullname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFullname.Name = "textBoxFullname";
            this.textBoxFullname.Size = new System.Drawing.Size(264, 23);
            this.textBoxFullname.TabIndex = 1;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.BackColor = System.Drawing.Color.Transparent;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.Location = new System.Drawing.Point(53, 123);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(40, 13);
            this.labelAddress.TabIndex = 4;
            this.labelAddress.Text = "Địa chỉ";
            // 
            // labelFullname
            // 
            this.labelFullname.AutoSize = true;
            this.labelFullname.BackColor = System.Drawing.Color.Transparent;
            this.labelFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullname.Location = new System.Drawing.Point(53, 41);
            this.labelFullname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFullname.Name = "labelFullname";
            this.labelFullname.Size = new System.Drawing.Size(39, 13);
            this.labelFullname.TabIndex = 0;
            this.labelFullname.Text = "Họ tên";
            // 
            // labelDateofBirth
            // 
            this.labelDateofBirth.AutoSize = true;
            this.labelDateofBirth.BackColor = System.Drawing.Color.Transparent;
            this.labelDateofBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateofBirth.Location = new System.Drawing.Point(53, 82);
            this.labelDateofBirth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDateofBirth.Name = "labelDateofBirth";
            this.labelDateofBirth.Size = new System.Drawing.Size(54, 13);
            this.labelDateofBirth.TabIndex = 2;
            this.labelDateofBirth.Text = "Ngày sinh";
            // 
            // maskedTextBoxDateofBirth
            // 
            this.maskedTextBoxDateofBirth.BackColor = System.Drawing.SystemColors.Window;
            this.maskedTextBoxDateofBirth.Culture = new System.Globalization.CultureInfo("vi-VN");
            this.maskedTextBoxDateofBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxDateofBirth.Location = new System.Drawing.Point(46, 98);
            this.maskedTextBoxDateofBirth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.maskedTextBoxDateofBirth.Mask = "00/00/0000";
            this.maskedTextBoxDateofBirth.Name = "maskedTextBoxDateofBirth";
            this.maskedTextBoxDateofBirth.Size = new System.Drawing.Size(264, 23);
            this.maskedTextBoxDateofBirth.TabIndex = 3;
            this.maskedTextBoxDateofBirth.ValidatingType = typeof(System.DateTime);
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.BackColor = System.Drawing.Color.Transparent;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.Location = new System.Drawing.Point(53, 410);
            this.labelGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(47, 13);
            this.labelGender.TabIndex = 18;
            this.labelGender.Text = "Giới tính";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.BackColor = System.Drawing.Color.Transparent;
            this.labelSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubject.Location = new System.Drawing.Point(53, 368);
            this.labelSubject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(43, 13);
            this.labelSubject.TabIndex = 16;
            this.labelSubject.Text = "Bộ môn";
            // 
            // labelPermission
            // 
            this.labelPermission.AutoSize = true;
            this.labelPermission.BackColor = System.Drawing.Color.Transparent;
            this.labelPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPermission.Location = new System.Drawing.Point(53, 285);
            this.labelPermission.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPermission.Name = "labelPermission";
            this.labelPermission.Size = new System.Drawing.Size(79, 13);
            this.labelPermission.TabIndex = 12;
            this.labelPermission.Text = "Quyền truy cập";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.BackColor = System.Drawing.Color.Transparent;
            this.labelClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClass.Location = new System.Drawing.Point(53, 327);
            this.labelClass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(25, 13);
            this.labelClass.TabIndex = 14;
            this.labelClass.Text = "Lớp";
            // 
            // FormSystemAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 572);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.checkBoxSpecializedClass);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.comboBoxClass);
            this.Controls.Add(this.comboBoxPermission);
            this.Controls.Add(this.textBoxPasswordConfirmation);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPasswordConfirmation);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxFullname);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelFullname);
            this.Controls.Add(this.labelDateofBirth);
            this.Controls.Add(this.maskedTextBoxDateofBirth);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelPermission);
            this.Controls.Add(this.labelClass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormSystemAddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM NGƯỜI DÙNG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.CheckBox checkBoxSpecializedClass;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.ComboBox comboBoxClass;
        private System.Windows.Forms.ComboBox comboBoxPermission;
        private System.Windows.Forms.TextBox textBoxPasswordConfirmation;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPasswordConfirmation;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxFullname;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelFullname;
        private System.Windows.Forms.Label labelDateofBirth;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDateofBirth;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelPermission;
        private System.Windows.Forms.Label labelClass;
    }
}