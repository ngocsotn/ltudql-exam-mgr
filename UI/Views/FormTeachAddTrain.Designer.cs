namespace UI.Views
{
    partial class FormTeachAddTrain
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
            this.comboBoxExamType = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelExamType = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelExamDate = new System.Windows.Forms.Label();
            this.maskedTextBoxExamDate = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(248, 129);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(210, 69);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Đóng";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(9, 129);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(210, 69);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Thêm";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxExamType
            // 
            this.comboBoxExamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExamType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExamType.FormattingEnabled = true;
            this.comboBoxExamType.Location = new System.Drawing.Point(46, 56);
            this.comboBoxExamType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxExamType.Name = "comboBoxExamType";
            this.comboBoxExamType.Size = new System.Drawing.Size(186, 25);
            this.comboBoxExamType.TabIndex = 1;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(235, 56);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(100, 25);
            this.comboBoxStatus.TabIndex = 3;
            // 
            // labelExamType
            // 
            this.labelExamType.AutoSize = true;
            this.labelExamType.BackColor = System.Drawing.Color.Transparent;
            this.labelExamType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExamType.Location = new System.Drawing.Point(52, 41);
            this.labelExamType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExamType.Name = "labelExamType";
            this.labelExamType.Size = new System.Drawing.Size(82, 13);
            this.labelExamType.TabIndex = 0;
            this.labelExamType.Text = "Học sinh ôn tập";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(242, 41);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(69, 13);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Bộ đề ôn tập";
            // 
            // labelExamDate
            // 
            this.labelExamDate.AutoSize = true;
            this.labelExamDate.BackColor = System.Drawing.Color.Transparent;
            this.labelExamDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExamDate.Location = new System.Drawing.Point(345, 41);
            this.labelExamDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExamDate.Name = "labelExamDate";
            this.labelExamDate.Size = new System.Drawing.Size(51, 13);
            this.labelExamDate.TabIndex = 4;
            this.labelExamDate.Text = "Hạn chót";
            // 
            // maskedTextBoxExamDate
            // 
            this.maskedTextBoxExamDate.Culture = new System.Globalization.CultureInfo("vi-VN");
            this.maskedTextBoxExamDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxExamDate.Location = new System.Drawing.Point(338, 56);
            this.maskedTextBoxExamDate.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBoxExamDate.Mask = "00/00/0000";
            this.maskedTextBoxExamDate.Name = "maskedTextBoxExamDate";
            this.maskedTextBoxExamDate.Size = new System.Drawing.Size(84, 23);
            this.maskedTextBoxExamDate.TabIndex = 5;
            this.maskedTextBoxExamDate.Text = "01012001";
            this.maskedTextBoxExamDate.ValidatingType = typeof(System.DateTime);
            // 
            // FormTeachAddTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 207);
            this.Controls.Add(this.maskedTextBoxExamDate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxExamType);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.labelExamDate);
            this.Controls.Add(this.labelExamType);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormTeachAddTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM KÌ ÔN TẬP";
            this.Load += new System.EventHandler(this.FormTeachAddTrain_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxExamType;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelExamType;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelExamDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxExamDate;
    }
}