namespace UI.Views
{
    partial class FormTeachUpdateExam
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
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.comboBoxExamType = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelSemester = new System.Windows.Forms.Label();
            this.labelExamType = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxSemester = new System.Windows.Forms.TextBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.groupBoxManageExam = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxAddedQuestionNote = new System.Windows.Forms.TextBox();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.listBoxAddedStudents = new System.Windows.Forms.ListBox();
            this.listBoxQuestionKits = new System.Windows.Forms.ListBox();
            this.listBoxStudents = new System.Windows.Forms.ListBox();
            this.buttonRemoveQuestions = new System.Windows.Forms.Button();
            this.buttonAddQuestions = new System.Windows.Forms.Button();
            this.labelAddedQuestionKit = new System.Windows.Forms.Label();
            this.labelAddedQuestions = new System.Windows.Forms.Label();
            this.labelQuestionNote = new System.Windows.Forms.Label();
            this.labelQuestionKits = new System.Windows.Forms.Label();
            this.labelStudents = new System.Windows.Forms.Label();
            this.labelExamDate = new System.Windows.Forms.Label();
            this.maskedTextBoxExamDate = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxManageExam.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(356, 404);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(341, 69);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Đóng";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.FlatAppearance.BorderSize = 0;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(9, 404);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(341, 69);
            this.buttonUpdate.TabIndex = 11;
            this.buttonUpdate.Text = "Cập nhật";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // comboBoxExamType
            // 
            this.comboBoxExamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExamType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExamType.FormattingEnabled = true;
            this.comboBoxExamType.Location = new System.Drawing.Point(379, 56);
            this.comboBoxExamType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxExamType.Name = "comboBoxExamType";
            this.comboBoxExamType.Size = new System.Drawing.Size(147, 25);
            this.comboBoxExamType.TabIndex = 7;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(530, 56);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(132, 25);
            this.comboBoxStatus.TabIndex = 9;
            // 
            // labelSemester
            // 
            this.labelSemester.AutoSize = true;
            this.labelSemester.BackColor = System.Drawing.Color.Transparent;
            this.labelSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSemester.Location = new System.Drawing.Point(52, 41);
            this.labelSemester.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSemester.Name = "labelSemester";
            this.labelSemester.Size = new System.Drawing.Size(38, 13);
            this.labelSemester.TabIndex = 0;
            this.labelSemester.Text = "Học kì";
            // 
            // labelExamType
            // 
            this.labelExamType.AutoSize = true;
            this.labelExamType.BackColor = System.Drawing.Color.Transparent;
            this.labelExamType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExamType.Location = new System.Drawing.Point(386, 41);
            this.labelExamType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExamType.Name = "labelExamType";
            this.labelExamType.Size = new System.Drawing.Size(67, 13);
            this.labelExamType.TabIndex = 6;
            this.labelExamType.Text = "Hình thức thi";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(537, 41);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(55, 13);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Tình trạng";
            // 
            // textBoxSemester
            // 
            this.textBoxSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSemester.Location = new System.Drawing.Point(46, 56);
            this.textBoxSemester.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSemester.Name = "textBoxSemester";
            this.textBoxSemester.Size = new System.Drawing.Size(109, 23);
            this.textBoxSemester.TabIndex = 1;
            // 
            // labelYear
            // 
            this.labelYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelYear.AutoSize = true;
            this.labelYear.BackColor = System.Drawing.Color.Transparent;
            this.labelYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYear.Location = new System.Drawing.Point(165, 41);
            this.labelYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(50, 13);
            this.labelYear.TabIndex = 2;
            this.labelYear.Text = "Năm học";
            // 
            // textBoxYear
            // 
            this.textBoxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxYear.Location = new System.Drawing.Point(158, 56);
            this.textBoxYear.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(98, 23);
            this.textBoxYear.TabIndex = 3;
            // 
            // groupBoxManageExam
            // 
            this.groupBoxManageExam.Controls.Add(this.textBox1);
            this.groupBoxManageExam.Controls.Add(this.textBoxAddedQuestionNote);
            this.groupBoxManageExam.Controls.Add(this.textBoxNote);
            this.groupBoxManageExam.Controls.Add(this.listBoxAddedStudents);
            this.groupBoxManageExam.Controls.Add(this.listBoxQuestionKits);
            this.groupBoxManageExam.Controls.Add(this.listBoxStudents);
            this.groupBoxManageExam.Controls.Add(this.buttonRemoveQuestions);
            this.groupBoxManageExam.Controls.Add(this.buttonAddQuestions);
            this.groupBoxManageExam.Controls.Add(this.labelAddedQuestionKit);
            this.groupBoxManageExam.Controls.Add(this.labelAddedQuestions);
            this.groupBoxManageExam.Controls.Add(this.labelQuestionNote);
            this.groupBoxManageExam.Controls.Add(this.labelQuestionKits);
            this.groupBoxManageExam.Controls.Add(this.labelStudents);
            this.groupBoxManageExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxManageExam.Location = new System.Drawing.Point(46, 93);
            this.groupBoxManageExam.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxManageExam.Name = "groupBoxManageExam";
            this.groupBoxManageExam.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxManageExam.Size = new System.Drawing.Size(615, 307);
            this.groupBoxManageExam.TabIndex = 10;
            this.groupBoxManageExam.TabStop = false;
            this.groupBoxManageExam.Text = "Quản lý câu hỏi";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(333, 48);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(145, 19);
            this.textBox1.TabIndex = 10;
            // 
            // textBoxAddedQuestionNote
            // 
            this.textBoxAddedQuestionNote.Location = new System.Drawing.Point(333, 281);
            this.textBoxAddedQuestionNote.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAddedQuestionNote.Name = "textBoxAddedQuestionNote";
            this.textBoxAddedQuestionNote.ReadOnly = true;
            this.textBoxAddedQuestionNote.Size = new System.Drawing.Size(278, 19);
            this.textBoxAddedQuestionNote.TabIndex = 11;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(4, 281);
            this.textBoxNote.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.ReadOnly = true;
            this.textBoxNote.Size = new System.Drawing.Size(278, 19);
            this.textBoxNote.TabIndex = 5;
            // 
            // listBoxAddedStudents
            // 
            this.listBoxAddedStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAddedStudents.FormattingEnabled = true;
            this.listBoxAddedStudents.Location = new System.Drawing.Point(482, 48);
            this.listBoxAddedStudents.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxAddedStudents.Name = "listBoxAddedStudents";
            this.listBoxAddedStudents.Size = new System.Drawing.Size(130, 212);
            this.listBoxAddedStudents.TabIndex = 8;
            this.listBoxAddedStudents.SelectedIndexChanged += new System.EventHandler(this.listBoxAddedStudents_SelectedIndexChanged);
            // 
            // listBoxQuestionKits
            // 
            this.listBoxQuestionKits.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxQuestionKits.FormattingEnabled = true;
            this.listBoxQuestionKits.Location = new System.Drawing.Point(138, 48);
            this.listBoxQuestionKits.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxQuestionKits.Name = "listBoxQuestionKits";
            this.listBoxQuestionKits.Size = new System.Drawing.Size(145, 212);
            this.listBoxQuestionKits.TabIndex = 3;
            this.listBoxQuestionKits.SelectedIndexChanged += new System.EventHandler(this.listBoxQuestionKits_SelectedIndexChanged);
            // 
            // listBoxStudents
            // 
            this.listBoxStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxStudents.FormattingEnabled = true;
            this.listBoxStudents.Location = new System.Drawing.Point(4, 48);
            this.listBoxStudents.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxStudents.Name = "listBoxStudents";
            this.listBoxStudents.Size = new System.Drawing.Size(130, 212);
            this.listBoxStudents.TabIndex = 1;
            this.listBoxStudents.SelectedIndexChanged += new System.EventHandler(this.listBoxStudents_SelectedIndexChanged);
            // 
            // buttonRemoveQuestions
            // 
            this.buttonRemoveQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveQuestions.Location = new System.Drawing.Point(286, 140);
            this.buttonRemoveQuestions.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveQuestions.Name = "buttonRemoveQuestions";
            this.buttonRemoveQuestions.Size = new System.Drawing.Size(42, 31);
            this.buttonRemoveQuestions.TabIndex = 12;
            this.buttonRemoveQuestions.Text = "<<";
            this.buttonRemoveQuestions.UseVisualStyleBackColor = true;
            this.buttonRemoveQuestions.Click += new System.EventHandler(this.buttonRemoveQuestions_Click);
            // 
            // buttonAddQuestions
            // 
            this.buttonAddQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddQuestions.Location = new System.Drawing.Point(286, 104);
            this.buttonAddQuestions.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddQuestions.Name = "buttonAddQuestions";
            this.buttonAddQuestions.Size = new System.Drawing.Size(42, 31);
            this.buttonAddQuestions.TabIndex = 6;
            this.buttonAddQuestions.Text = ">>";
            this.buttonAddQuestions.UseVisualStyleBackColor = true;
            this.buttonAddQuestions.Click += new System.EventHandler(this.buttonAddQuestions_Click);
            // 
            // labelAddedQuestionKit
            // 
            this.labelAddedQuestionKit.AutoSize = true;
            this.labelAddedQuestionKit.Location = new System.Drawing.Point(340, 32);
            this.labelAddedQuestionKit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddedQuestionKit.Name = "labelAddedQuestionKit";
            this.labelAddedQuestionKit.Size = new System.Drawing.Size(79, 13);
            this.labelAddedQuestionKit.TabIndex = 9;
            this.labelAddedQuestionKit.Text = "Bộ đề đã chọn";
            // 
            // labelAddedQuestions
            // 
            this.labelAddedQuestions.AutoSize = true;
            this.labelAddedQuestions.Location = new System.Drawing.Point(488, 32);
            this.labelAddedQuestions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddedQuestions.Name = "labelAddedQuestions";
            this.labelAddedQuestions.Size = new System.Drawing.Size(116, 13);
            this.labelAddedQuestions.TabIndex = 7;
            this.labelAddedQuestions.Text = "Danh sách học sinh thi";
            // 
            // labelQuestionNote
            // 
            this.labelQuestionNote.AutoSize = true;
            this.labelQuestionNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestionNote.Location = new System.Drawing.Point(11, 265);
            this.labelQuestionNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuestionNote.Name = "labelQuestionNote";
            this.labelQuestionNote.Size = new System.Drawing.Size(497, 13);
            this.labelQuestionNote.TabIndex = 4;
            this.labelQuestionNote.Text = "Tên học sinh đã chọn (dự phòng trong trường hợp cái listBoxStudents ở trên chỉ hi" +
    "ện được mã học sinh)";
            // 
            // labelQuestionKits
            // 
            this.labelQuestionKits.AutoSize = true;
            this.labelQuestionKits.Location = new System.Drawing.Point(144, 32);
            this.labelQuestionKits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuestionKits.Name = "labelQuestionKits";
            this.labelQuestionKits.Size = new System.Drawing.Size(83, 13);
            this.labelQuestionKits.TabIndex = 2;
            this.labelQuestionKits.Text = "Lựa chọn bộ đề";
            // 
            // labelStudents
            // 
            this.labelStudents.AutoSize = true;
            this.labelStudents.Location = new System.Drawing.Point(11, 32);
            this.labelStudents.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStudents.Name = "labelStudents";
            this.labelStudents.Size = new System.Drawing.Size(102, 13);
            this.labelStudents.TabIndex = 0;
            this.labelStudents.Text = "Danh sách học sinh";
            // 
            // labelExamDate
            // 
            this.labelExamDate.AutoSize = true;
            this.labelExamDate.BackColor = System.Drawing.Color.Transparent;
            this.labelExamDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExamDate.Location = new System.Drawing.Point(266, 41);
            this.labelExamDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExamDate.Name = "labelExamDate";
            this.labelExamDate.Size = new System.Drawing.Size(46, 13);
            this.labelExamDate.TabIndex = 4;
            this.labelExamDate.Text = "Ngày thi";
            // 
            // maskedTextBoxExamDate
            // 
            this.maskedTextBoxExamDate.Culture = new System.Globalization.CultureInfo("vi-VN");
            this.maskedTextBoxExamDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxExamDate.Location = new System.Drawing.Point(260, 56);
            this.maskedTextBoxExamDate.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBoxExamDate.Mask = "00/00/0000";
            this.maskedTextBoxExamDate.Name = "maskedTextBoxExamDate";
            this.maskedTextBoxExamDate.Size = new System.Drawing.Size(116, 23);
            this.maskedTextBoxExamDate.TabIndex = 5;
            this.maskedTextBoxExamDate.ValidatingType = typeof(System.DateTime);
            // 
            // FormTeachUpdateExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 482);
            this.Controls.Add(this.maskedTextBoxExamDate);
            this.Controls.Add(this.groupBoxManageExam);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.comboBoxExamType);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.labelExamDate);
            this.Controls.Add(this.textBoxSemester);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelSemester);
            this.Controls.Add(this.labelExamType);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormTeachUpdateExam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẬP NHẬT KÌ THI";
            this.groupBoxManageExam.ResumeLayout(false);
            this.groupBoxManageExam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ComboBox comboBoxExamType;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelSemester;
        private System.Windows.Forms.Label labelExamType;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxSemester;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.GroupBox groupBoxManageExam;
        private System.Windows.Forms.TextBox textBoxAddedQuestionNote;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.ListBox listBoxAddedStudents;
        private System.Windows.Forms.ListBox listBoxStudents;
        private System.Windows.Forms.Button buttonRemoveQuestions;
        private System.Windows.Forms.Button buttonAddQuestions;
        private System.Windows.Forms.Label labelAddedQuestions;
        private System.Windows.Forms.Label labelQuestionNote;
        private System.Windows.Forms.Label labelStudents;
        private System.Windows.Forms.ListBox listBoxQuestionKits;
        private System.Windows.Forms.Label labelQuestionKits;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelAddedQuestionKit;
        private System.Windows.Forms.Label labelExamDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxExamDate;
    }
}