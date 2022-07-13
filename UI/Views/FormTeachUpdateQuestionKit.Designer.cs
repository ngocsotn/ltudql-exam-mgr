namespace UI.Views
{
    partial class FormTeachUpdateQuestionKit
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
            this.comboBoxGrade = new System.Windows.Forms.ComboBox();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelGrade = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.groupBoxManageQuestion = new System.Windows.Forms.GroupBox();
            this.textBoxAddedQuestionNote = new System.Windows.Forms.TextBox();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.richTextBoxAddedQuestionContent = new System.Windows.Forms.RichTextBox();
            this.richTextBoxQuestionContent = new System.Windows.Forms.RichTextBox();
            this.listBoxAddedQuestions = new System.Windows.Forms.ListBox();
            this.listBoxQuestions = new System.Windows.Forms.ListBox();
            this.buttonRemoveQuestions = new System.Windows.Forms.Button();
            this.buttonAddQuestions = new System.Windows.Forms.Button();
            this.labelAddedQuestions = new System.Windows.Forms.Label();
            this.labelQuestionNote = new System.Windows.Forms.Label();
            this.labelQuestions = new System.Windows.Forms.Label();
            this.groupBoxManageQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(356, 404);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(341, 69);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Huỷ";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.FlatAppearance.BorderSize = 0;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(9, 404);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(341, 69);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "Cập nhật";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // comboBoxGrade
            // 
            this.comboBoxGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGrade.FormattingEnabled = true;
            this.comboBoxGrade.Location = new System.Drawing.Point(389, 56);
            this.comboBoxGrade.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxGrade.Name = "comboBoxGrade";
            this.comboBoxGrade.Size = new System.Drawing.Size(147, 25);
            this.comboBoxGrade.TabIndex = 3;
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new System.Drawing.Point(46, 56);
            this.comboBoxSubject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(340, 25);
            this.comboBoxSubject.TabIndex = 1;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.Transparent;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(547, 41);
            this.labelTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(81, 13);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "Thời gian (phút)";
            // 
            // labelGrade
            // 
            this.labelGrade.AutoSize = true;
            this.labelGrade.BackColor = System.Drawing.Color.Transparent;
            this.labelGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrade.Location = new System.Drawing.Point(396, 41);
            this.labelGrade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGrade.Name = "labelGrade";
            this.labelGrade.Size = new System.Drawing.Size(28, 13);
            this.labelGrade.TabIndex = 2;
            this.labelGrade.Text = "Khối";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.BackColor = System.Drawing.Color.Transparent;
            this.labelSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubject.Location = new System.Drawing.Point(53, 41);
            this.labelSubject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(49, 13);
            this.labelSubject.TabIndex = 0;
            this.labelSubject.Text = "Môn học";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTime.Location = new System.Drawing.Point(540, 56);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(122, 23);
            this.textBoxTime.TabIndex = 5;
            // 
            // groupBoxManageQuestion
            // 
            this.groupBoxManageQuestion.Controls.Add(this.textBoxAddedQuestionNote);
            this.groupBoxManageQuestion.Controls.Add(this.textBoxNote);
            this.groupBoxManageQuestion.Controls.Add(this.richTextBoxAddedQuestionContent);
            this.groupBoxManageQuestion.Controls.Add(this.richTextBoxQuestionContent);
            this.groupBoxManageQuestion.Controls.Add(this.listBoxAddedQuestions);
            this.groupBoxManageQuestion.Controls.Add(this.listBoxQuestions);
            this.groupBoxManageQuestion.Controls.Add(this.buttonRemoveQuestions);
            this.groupBoxManageQuestion.Controls.Add(this.buttonAddQuestions);
            this.groupBoxManageQuestion.Controls.Add(this.labelAddedQuestions);
            this.groupBoxManageQuestion.Controls.Add(this.labelQuestionNote);
            this.groupBoxManageQuestion.Controls.Add(this.labelQuestions);
            this.groupBoxManageQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxManageQuestion.Location = new System.Drawing.Point(46, 93);
            this.groupBoxManageQuestion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxManageQuestion.Name = "groupBoxManageQuestion";
            this.groupBoxManageQuestion.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxManageQuestion.Size = new System.Drawing.Size(615, 307);
            this.groupBoxManageQuestion.TabIndex = 6;
            this.groupBoxManageQuestion.TabStop = false;
            this.groupBoxManageQuestion.Text = "Quản lý câu hỏi";
            // 
            // textBoxAddedQuestionNote
            // 
            this.textBoxAddedQuestionNote.Location = new System.Drawing.Point(333, 281);
            this.textBoxAddedQuestionNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxAddedQuestionNote.Name = "textBoxAddedQuestionNote";
            this.textBoxAddedQuestionNote.Size = new System.Drawing.Size(278, 19);
            this.textBoxAddedQuestionNote.TabIndex = 9;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(4, 281);
            this.textBoxNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(278, 19);
            this.textBoxNote.TabIndex = 4;
            // 
            // richTextBoxAddedQuestionContent
            // 
            this.richTextBoxAddedQuestionContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxAddedQuestionContent.Location = new System.Drawing.Point(333, 48);
            this.richTextBoxAddedQuestionContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxAddedQuestionContent.Name = "richTextBoxAddedQuestionContent";
            this.richTextBoxAddedQuestionContent.ReadOnly = true;
            this.richTextBoxAddedQuestionContent.Size = new System.Drawing.Size(188, 212);
            this.richTextBoxAddedQuestionContent.TabIndex = 8;
            this.richTextBoxAddedQuestionContent.Text = "";
            // 
            // richTextBoxQuestionContent
            // 
            this.richTextBoxQuestionContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxQuestionContent.Location = new System.Drawing.Point(95, 48);
            this.richTextBoxQuestionContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxQuestionContent.Name = "richTextBoxQuestionContent";
            this.richTextBoxQuestionContent.ReadOnly = true;
            this.richTextBoxQuestionContent.Size = new System.Drawing.Size(188, 212);
            this.richTextBoxQuestionContent.TabIndex = 2;
            this.richTextBoxQuestionContent.Text = "";
            // 
            // listBoxAddedQuestions
            // 
            this.listBoxAddedQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAddedQuestions.FormattingEnabled = true;
            this.listBoxAddedQuestions.Location = new System.Drawing.Point(524, 48);
            this.listBoxAddedQuestions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxAddedQuestions.Name = "listBoxAddedQuestions";
            this.listBoxAddedQuestions.Size = new System.Drawing.Size(87, 212);
            this.listBoxAddedQuestions.TabIndex = 7;
            this.listBoxAddedQuestions.SelectedIndexChanged += new System.EventHandler(this.listBoxAddedQuestions_SelectedIndexChanged);
            // 
            // listBoxQuestions
            // 
            this.listBoxQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxQuestions.FormattingEnabled = true;
            this.listBoxQuestions.Location = new System.Drawing.Point(4, 48);
            this.listBoxQuestions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxQuestions.Name = "listBoxQuestions";
            this.listBoxQuestions.Size = new System.Drawing.Size(87, 212);
            this.listBoxQuestions.TabIndex = 1;
            this.listBoxQuestions.SelectedIndexChanged += new System.EventHandler(this.listBoxQuestions_SelectedIndexChanged);
            // 
            // buttonRemoveQuestions
            // 
            this.buttonRemoveQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveQuestions.Location = new System.Drawing.Point(286, 140);
            this.buttonRemoveQuestions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRemoveQuestions.Name = "buttonRemoveQuestions";
            this.buttonRemoveQuestions.Size = new System.Drawing.Size(42, 31);
            this.buttonRemoveQuestions.TabIndex = 10;
            this.buttonRemoveQuestions.Text = "<<";
            this.buttonRemoveQuestions.UseVisualStyleBackColor = true;
            this.buttonRemoveQuestions.Click += new System.EventHandler(this.buttonRemoveQuestions_Click);
            // 
            // buttonAddQuestions
            // 
            this.buttonAddQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddQuestions.Location = new System.Drawing.Point(286, 104);
            this.buttonAddQuestions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddQuestions.Name = "buttonAddQuestions";
            this.buttonAddQuestions.Size = new System.Drawing.Size(42, 31);
            this.buttonAddQuestions.TabIndex = 5;
            this.buttonAddQuestions.Text = ">>";
            this.buttonAddQuestions.UseVisualStyleBackColor = true;
            this.buttonAddQuestions.Click += new System.EventHandler(this.buttonAddQuestions_Click);
            // 
            // labelAddedQuestions
            // 
            this.labelAddedQuestions.AutoSize = true;
            this.labelAddedQuestions.Location = new System.Drawing.Point(332, 32);
            this.labelAddedQuestions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddedQuestions.Name = "labelAddedQuestions";
            this.labelAddedQuestions.Size = new System.Drawing.Size(186, 13);
            this.labelAddedQuestions.TabIndex = 6;
            this.labelAddedQuestions.Text = "Các câu hỏi đã được thêm vào bộ đề";
            // 
            // labelQuestionNote
            // 
            this.labelQuestionNote.AutoSize = true;
            this.labelQuestionNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestionNote.Location = new System.Drawing.Point(11, 265);
            this.labelQuestionNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuestionNote.Name = "labelQuestionNote";
            this.labelQuestionNote.Size = new System.Drawing.Size(94, 13);
            this.labelQuestionNote.TabIndex = 3;
            this.labelQuestionNote.Text = "Ghi chú (tuỳ chọn)";
            // 
            // labelQuestions
            // 
            this.labelQuestions.AutoSize = true;
            this.labelQuestions.Location = new System.Drawing.Point(11, 32);
            this.labelQuestions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuestions.Name = "labelQuestions";
            this.labelQuestions.Size = new System.Drawing.Size(248, 13);
            this.labelQuestions.TabIndex = 0;
            this.labelQuestions.Text = "Các câu hỏi có sẵn theo môn học và khối đã chọn";
            // 
            // FormTeachUpdateQuestionKit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 482);
            this.Controls.Add(this.groupBoxManageQuestion);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.comboBoxGrade);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelGrade);
            this.Controls.Add(this.labelSubject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormTeachUpdateQuestionKit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẬP NHẬT BỘ ĐỀ";
            this.groupBoxManageQuestion.ResumeLayout(false);
            this.groupBoxManageQuestion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ComboBox comboBoxGrade;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelGrade;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.GroupBox groupBoxManageQuestion;
        private System.Windows.Forms.Label labelAddedQuestions;
        private System.Windows.Forms.Label labelQuestions;
        private System.Windows.Forms.Button buttonRemoveQuestions;
        private System.Windows.Forms.Button buttonAddQuestions;
        private System.Windows.Forms.RichTextBox richTextBoxQuestionContent;
        private System.Windows.Forms.ListBox listBoxQuestions;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label labelQuestionNote;
        private System.Windows.Forms.TextBox textBoxAddedQuestionNote;
        private System.Windows.Forms.RichTextBox richTextBoxAddedQuestionContent;
        private System.Windows.Forms.ListBox listBoxAddedQuestions;
    }
}