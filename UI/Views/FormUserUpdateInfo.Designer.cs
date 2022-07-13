namespace UI.Views
{
    partial class FormUserUpdateInfo
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
            this.labelUserUpdateInfo = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelFullname = new System.Windows.Forms.Label();
            this.textBoxFullname = new System.Windows.Forms.TextBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelDateofBirth = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPasswordOld = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPasswordOld = new System.Windows.Forms.TextBox();
            this.maskedTextBoxDOB = new System.Windows.Forms.MaskedTextBox();
            this.labelPasswordNew = new System.Windows.Forms.Label();
            this.textBoxPasswordNew = new System.Windows.Forms.TextBox();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelUserUpdateInfo
            // 
            this.labelUserUpdateInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserUpdateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserUpdateInfo.Location = new System.Drawing.Point(9, 7);
            this.labelUserUpdateInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserUpdateInfo.Name = "labelUserUpdateInfo";
            this.labelUserUpdateInfo.Size = new System.Drawing.Size(387, 50);
            this.labelUserUpdateInfo.TabIndex = 0;
            this.labelUserUpdateInfo.Text = "THAY ĐỔI THÔNG TIN";
            this.labelUserUpdateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.FlatAppearance.BorderSize = 0;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(9, 373);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(387, 46);
            this.buttonUpdate.TabIndex = 15;
            this.buttonUpdate.Text = "Thay đổi";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(66, 137);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(42, 17);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(154, 135);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(182, 23);
            this.textBoxEmail.TabIndex = 4;
            // 
            // labelFullname
            // 
            this.labelFullname.AutoSize = true;
            this.labelFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullname.Location = new System.Drawing.Point(66, 102);
            this.labelFullname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFullname.Name = "labelFullname";
            this.labelFullname.Size = new System.Drawing.Size(50, 17);
            this.labelFullname.TabIndex = 1;
            this.labelFullname.Text = "Họ tên";
            // 
            // textBoxFullname
            // 
            this.textBoxFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFullname.Location = new System.Drawing.Point(154, 99);
            this.textBoxFullname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFullname.Name = "textBoxFullname";
            this.textBoxFullname.Size = new System.Drawing.Size(182, 23);
            this.textBoxFullname.TabIndex = 2;
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.Location = new System.Drawing.Point(66, 173);
            this.labelGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(60, 17);
            this.labelGender.TabIndex = 5;
            this.labelGender.Text = "Giới tính";
            // 
            // labelDateofBirth
            // 
            this.labelDateofBirth.AutoSize = true;
            this.labelDateofBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateofBirth.Location = new System.Drawing.Point(66, 209);
            this.labelDateofBirth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDateofBirth.Name = "labelDateofBirth";
            this.labelDateofBirth.Size = new System.Drawing.Size(71, 17);
            this.labelDateofBirth.TabIndex = 7;
            this.labelDateofBirth.Text = "Ngày sinh";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.Location = new System.Drawing.Point(66, 245);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(51, 17);
            this.labelAddress.TabIndex = 9;
            this.labelAddress.Text = "Địa chỉ";
            // 
            // labelPasswordOld
            // 
            this.labelPasswordOld.AutoSize = true;
            this.labelPasswordOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordOld.Location = new System.Drawing.Point(66, 280);
            this.labelPasswordOld.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPasswordOld.Name = "labelPasswordOld";
            this.labelPasswordOld.Size = new System.Drawing.Size(85, 17);
            this.labelPasswordOld.TabIndex = 11;
            this.labelPasswordOld.Text = "Mật khẩu cũ";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(154, 242);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(182, 23);
            this.textBoxAddress.TabIndex = 10;
            // 
            // textBoxPasswordOld
            // 
            this.textBoxPasswordOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswordOld.Location = new System.Drawing.Point(154, 278);
            this.textBoxPasswordOld.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPasswordOld.Name = "textBoxPasswordOld";
            this.textBoxPasswordOld.Size = new System.Drawing.Size(182, 23);
            this.textBoxPasswordOld.TabIndex = 12;
            this.textBoxPasswordOld.UseSystemPasswordChar = true;
            // 
            // maskedTextBoxDOB
            // 
            this.maskedTextBoxDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxDOB.Location = new System.Drawing.Point(154, 206);
            this.maskedTextBoxDOB.Mask = "00/00/0000";
            this.maskedTextBoxDOB.Name = "maskedTextBoxDOB";
            this.maskedTextBoxDOB.Size = new System.Drawing.Size(182, 23);
            this.maskedTextBoxDOB.TabIndex = 8;
            this.maskedTextBoxDOB.ValidatingType = typeof(System.DateTime);
            // 
            // labelPasswordNew
            // 
            this.labelPasswordNew.AutoSize = true;
            this.labelPasswordNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordNew.Location = new System.Drawing.Point(66, 316);
            this.labelPasswordNew.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPasswordNew.Name = "labelPasswordNew";
            this.labelPasswordNew.Size = new System.Drawing.Size(92, 17);
            this.labelPasswordNew.TabIndex = 13;
            this.labelPasswordNew.Text = "Mật khẩu mới";
            // 
            // textBoxPasswordNew
            // 
            this.textBoxPasswordNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswordNew.Location = new System.Drawing.Point(154, 314);
            this.textBoxPasswordNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPasswordNew.Name = "textBoxPasswordNew";
            this.textBoxPasswordNew.Size = new System.Drawing.Size(182, 23);
            this.textBoxPasswordNew.TabIndex = 14;
            this.textBoxPasswordNew.UseSystemPasswordChar = true;
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(154, 171);
            this.comboBoxGender.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(182, 25);
            this.comboBoxGender.TabIndex = 6;
            // 
            // FormUserUpdateInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(405, 428);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.maskedTextBoxDOB);
            this.Controls.Add(this.labelUserUpdateInfo);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.labelPasswordNew);
            this.Controls.Add(this.labelPasswordOld);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelDateofBirth);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxPasswordNew);
            this.Controls.Add(this.textBoxPasswordOld);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelFullname);
            this.Controls.Add(this.textBoxFullname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormUserUpdateInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserUpdateInfo;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelFullname;
        private System.Windows.Forms.TextBox textBoxFullname;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelDateofBirth;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelPasswordOld;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxPasswordOld;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDOB;
        private System.Windows.Forms.Label labelPasswordNew;
        private System.Windows.Forms.TextBox textBoxPasswordNew;
        private System.Windows.Forms.ComboBox comboBoxGender;
    }
}