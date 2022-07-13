namespace UI.Views
{
    partial class FormUserRegister
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
            this.labelRegister = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelFullname = new System.Windows.Forms.Label();
            this.textBoxFullname = new System.Windows.Forms.TextBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelDateofBirth = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.maskedTextBoxDOB = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelRegister
            // 
            this.labelRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegister.Location = new System.Drawing.Point(12, 9);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(516, 62);
            this.labelRegister.TabIndex = 0;
            this.labelRegister.Text = "ĐĂNG KÝ";
            this.labelRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRegister.FlatAppearance.BorderSize = 0;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.Location = new System.Drawing.Point(12, 409);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(516, 57);
            this.buttonRegister.TabIndex = 14;
            this.buttonRegister.Text = "Đăng ký";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(88, 169);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(51, 20);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(205, 166);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(241, 27);
            this.textBoxEmail.TabIndex = 5;
            // 
            // labelFullname
            // 
            this.labelFullname.AutoSize = true;
            this.labelFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullname.Location = new System.Drawing.Point(88, 126);
            this.labelFullname.Name = "labelFullname";
            this.labelFullname.Size = new System.Drawing.Size(59, 20);
            this.labelFullname.TabIndex = 2;
            this.labelFullname.Text = "Họ tên";
            // 
            // textBoxFullname
            // 
            this.textBoxFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFullname.Location = new System.Drawing.Point(205, 122);
            this.textBoxFullname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFullname.Name = "textBoxFullname";
            this.textBoxFullname.Size = new System.Drawing.Size(241, 27);
            this.textBoxFullname.TabIndex = 3;
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.Location = new System.Drawing.Point(88, 213);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(71, 20);
            this.labelGender.TabIndex = 6;
            this.labelGender.Text = "Giới tính";
            // 
            // labelDateofBirth
            // 
            this.labelDateofBirth.AutoSize = true;
            this.labelDateofBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateofBirth.Location = new System.Drawing.Point(88, 257);
            this.labelDateofBirth.Name = "labelDateofBirth";
            this.labelDateofBirth.Size = new System.Drawing.Size(83, 20);
            this.labelDateofBirth.TabIndex = 8;
            this.labelDateofBirth.Text = "Ngày sinh";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.Location = new System.Drawing.Point(88, 302);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(61, 20);
            this.labelAddress.TabIndex = 10;
            this.labelAddress.Text = "Địa chỉ";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(88, 345);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(77, 20);
            this.labelPassword.TabIndex = 12;
            this.labelPassword.Text = "Mật khẩu";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(205, 298);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(241, 27);
            this.textBoxAddress.TabIndex = 11;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(205, 342);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(241, 27);
            this.textBoxPassword.TabIndex = 13;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.Location = new System.Drawing.Point(92, 70);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(356, 17);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "Quyền hạn mặc định sẽ là học sinh sau khi đăng ký";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maskedTextBoxDOB
            // 
            this.maskedTextBoxDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxDOB.Location = new System.Drawing.Point(205, 254);
            this.maskedTextBoxDOB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.maskedTextBoxDOB.Mask = "00/00/0000";
            this.maskedTextBoxDOB.Name = "maskedTextBoxDOB";
            this.maskedTextBoxDOB.Size = new System.Drawing.Size(241, 27);
            this.maskedTextBoxDOB.TabIndex = 9;
            this.maskedTextBoxDOB.ValidatingType = typeof(System.DateTime);
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(205, 210);
            this.comboBoxGender.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(241, 28);
            this.comboBoxGender.TabIndex = 7;
            // 
            // FormUserRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 478);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.maskedTextBoxDOB);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelRegister);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelDateofBirth);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelFullname);
            this.Controls.Add(this.textBoxFullname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormUserRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRegister;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelFullname;
        private System.Windows.Forms.TextBox textBoxFullname;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelDateofBirth;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDOB;
        private System.Windows.Forms.ComboBox comboBoxGender;
    }
}