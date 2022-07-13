namespace UI.Views
{
    partial class FormTeachStatistic
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
            this.comboBoxExam = new System.Windows.Forms.ComboBox();
            this.comboBoxQuestion = new System.Windows.Forms.ComboBox();
            this.labelExam = new System.Windows.Forms.Label();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.buttonExamStatistic = new System.Windows.Forms.Button();
            this.buttonQuestionStatistic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(688, 464);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 43);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Đóng";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxExam
            // 
            this.comboBoxExam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExam.FormattingEnabled = true;
            this.comboBoxExam.Location = new System.Drawing.Point(46, 56);
            this.comboBoxExam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxExam.Name = "comboBoxExam";
            this.comboBoxExam.Size = new System.Drawing.Size(186, 25);
            this.comboBoxExam.TabIndex = 1;
            // 
            // comboBoxQuestion
            // 
            this.comboBoxQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxQuestion.FormattingEnabled = true;
            this.comboBoxQuestion.Location = new System.Drawing.Point(360, 56);
            this.comboBoxQuestion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxQuestion.Name = "comboBoxQuestion";
            this.comboBoxQuestion.Size = new System.Drawing.Size(306, 25);
            this.comboBoxQuestion.TabIndex = 4;
            // 
            // labelExam
            // 
            this.labelExam.AutoSize = true;
            this.labelExam.BackColor = System.Drawing.Color.Transparent;
            this.labelExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExam.Location = new System.Drawing.Point(52, 41);
            this.labelExam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExam.Name = "labelExam";
            this.labelExam.Size = new System.Drawing.Size(30, 13);
            this.labelExam.TabIndex = 0;
            this.labelExam.Text = "Kì thi";
            // 
            // labelQuestion
            // 
            this.labelQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.BackColor = System.Drawing.Color.Transparent;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.Location = new System.Drawing.Point(367, 41);
            this.labelQuestion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(43, 13);
            this.labelQuestion.TabIndex = 3;
            this.labelQuestion.Text = "Câu hỏi";
            // 
            // buttonExamStatistic
            // 
            this.buttonExamStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExamStatistic.Location = new System.Drawing.Point(235, 56);
            this.buttonExamStatistic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExamStatistic.Name = "buttonExamStatistic";
            this.buttonExamStatistic.Size = new System.Drawing.Size(80, 23);
            this.buttonExamStatistic.TabIndex = 2;
            this.buttonExamStatistic.Text = "Thống kê";
            this.buttonExamStatistic.UseVisualStyleBackColor = true;
            // 
            // buttonQuestionStatistic
            // 
            this.buttonQuestionStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuestionStatistic.Location = new System.Drawing.Point(669, 56);
            this.buttonQuestionStatistic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonQuestionStatistic.Name = "buttonQuestionStatistic";
            this.buttonQuestionStatistic.Size = new System.Drawing.Size(80, 23);
            this.buttonQuestionStatistic.TabIndex = 5;
            this.buttonQuestionStatistic.Text = "Thống kê";
            this.buttonQuestionStatistic.UseVisualStyleBackColor = true;
            // 
            // FormTeachStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(794, 516);
            this.Controls.Add(this.buttonQuestionStatistic);
            this.Controls.Add(this.buttonExamStatistic);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxExam);
            this.Controls.Add(this.comboBoxQuestion);
            this.Controls.Add(this.labelExam);
            this.Controls.Add(this.labelQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormTeachStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxExam;
        private System.Windows.Forms.ComboBox comboBoxQuestion;
        private System.Windows.Forms.Label labelExam;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button buttonExamStatistic;
        private System.Windows.Forms.Button buttonQuestionStatistic;
    }
}