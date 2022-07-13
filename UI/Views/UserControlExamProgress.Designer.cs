namespace UI.Views
{
    partial class UserControlExamProgress
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxQuestionDisplay = new System.Windows.Forms.GroupBox();
            this.richTextBoxQuestionContent = new System.Windows.Forms.RichTextBox();
            this.textBoxQuestionResult = new System.Windows.Forms.TextBox();
            this.labelQuestionResult = new System.Windows.Forms.Label();
            this.buttonShowHint = new System.Windows.Forms.Button();
            this.buttonQuestionNext = new System.Windows.Forms.Button();
            this.groupBoxQuestionPicker = new System.Windows.Forms.GroupBox();
            this.progressBarExam = new MaterialSkin.Controls.MaterialProgressBar();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelQuestionKit = new System.Windows.Forms.Label();
            this.labelQuestionTotal = new System.Windows.Forms.Label();
            this.buttonExamEnd = new System.Windows.Forms.Button();
            this.labelTimeLeft = new System.Windows.Forms.Label();
            this.labelQuestionAnswered = new System.Windows.Forms.Label();
            this.textBoxQuestionKit = new System.Windows.Forms.TextBox();
            this.textBoxQuestionTotal = new System.Windows.Forms.TextBox();
            this.textBoxTimeLeft = new System.Windows.Forms.TextBox();
            this.textBoxQuestionAnswered = new System.Windows.Forms.TextBox();
            this.groupBoxQuestionDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxQuestionDisplay
            // 
            this.groupBoxQuestionDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxQuestionDisplay.Controls.Add(this.richTextBoxQuestionContent);
            this.groupBoxQuestionDisplay.Controls.Add(this.textBoxQuestionResult);
            this.groupBoxQuestionDisplay.Controls.Add(this.labelQuestionResult);
            this.groupBoxQuestionDisplay.Controls.Add(this.buttonShowHint);
            this.groupBoxQuestionDisplay.Controls.Add(this.buttonQuestionNext);
            this.groupBoxQuestionDisplay.Location = new System.Drawing.Point(0, 54);
            this.groupBoxQuestionDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxQuestionDisplay.Name = "groupBoxQuestionDisplay";
            this.groupBoxQuestionDisplay.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxQuestionDisplay.Size = new System.Drawing.Size(388, 255);
            this.groupBoxQuestionDisplay.TabIndex = 8;
            this.groupBoxQuestionDisplay.TabStop = false;
            this.groupBoxQuestionDisplay.Text = "Câu hỏi";
            // 
            // richTextBoxQuestionContent
            // 
            this.richTextBoxQuestionContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxQuestionContent.BackColor = System.Drawing.Color.White;
            this.richTextBoxQuestionContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxQuestionContent.Location = new System.Drawing.Point(9, 17);
            this.richTextBoxQuestionContent.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxQuestionContent.Name = "richTextBoxQuestionContent";
            this.richTextBoxQuestionContent.ReadOnly = true;
            this.richTextBoxQuestionContent.Size = new System.Drawing.Size(375, 68);
            this.richTextBoxQuestionContent.TabIndex = 0;
            this.richTextBoxQuestionContent.Text = "Nội dung câu hỏi ở đây, các câu trả lời phải tạo ra từ vòng lặp dựa theo số lượng" +
    " câu trả lời (Dùng CheckBox)";
            // 
            // textBoxQuestionResult
            // 
            this.textBoxQuestionResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuestionResult.BackColor = System.Drawing.Color.White;
            this.textBoxQuestionResult.Location = new System.Drawing.Point(322, 203);
            this.textBoxQuestionResult.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxQuestionResult.Name = "textBoxQuestionResult";
            this.textBoxQuestionResult.ReadOnly = true;
            this.textBoxQuestionResult.Size = new System.Drawing.Size(62, 20);
            this.textBoxQuestionResult.TabIndex = 8;
            // 
            // labelQuestionResult
            // 
            this.labelQuestionResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelQuestionResult.AutoSize = true;
            this.labelQuestionResult.Location = new System.Drawing.Point(271, 206);
            this.labelQuestionResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuestionResult.Name = "labelQuestionResult";
            this.labelQuestionResult.Size = new System.Drawing.Size(48, 13);
            this.labelQuestionResult.TabIndex = 7;
            this.labelQuestionResult.Text = "Đáp án: ";
            // 
            // buttonShowHint
            // 
            this.buttonShowHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowHint.FlatAppearance.BorderSize = 0;
            this.buttonShowHint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowHint.Location = new System.Drawing.Point(256, 226);
            this.buttonShowHint.Margin = new System.Windows.Forms.Padding(2);
            this.buttonShowHint.Name = "buttonShowHint";
            this.buttonShowHint.Size = new System.Drawing.Size(62, 24);
            this.buttonShowHint.TabIndex = 9;
            this.buttonShowHint.Text = "Gợi ý";
            this.buttonShowHint.UseVisualStyleBackColor = true;
            this.buttonShowHint.Click += new System.EventHandler(this.buttonShowHint_Click);
            // 
            // buttonQuestionNext
            // 
            this.buttonQuestionNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuestionNext.FlatAppearance.BorderSize = 0;
            this.buttonQuestionNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuestionNext.Location = new System.Drawing.Point(322, 226);
            this.buttonQuestionNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonQuestionNext.Name = "buttonQuestionNext";
            this.buttonQuestionNext.Size = new System.Drawing.Size(62, 24);
            this.buttonQuestionNext.TabIndex = 10;
            this.buttonQuestionNext.Text = "Tiếp theo";
            this.buttonQuestionNext.UseVisualStyleBackColor = true;
            this.buttonQuestionNext.Click += new System.EventHandler(this.buttonQuestionNext_Click);
            // 
            // groupBoxQuestionPicker
            // 
            this.groupBoxQuestionPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxQuestionPicker.Location = new System.Drawing.Point(392, 54);
            this.groupBoxQuestionPicker.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxQuestionPicker.Name = "groupBoxQuestionPicker";
            this.groupBoxQuestionPicker.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxQuestionPicker.Size = new System.Drawing.Size(262, 255);
            this.groupBoxQuestionPicker.TabIndex = 9;
            this.groupBoxQuestionPicker.TabStop = false;
            this.groupBoxQuestionPicker.Text = "Danh sách câu hỏi";
            // 
            // progressBarExam
            // 
            this.progressBarExam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarExam.Depth = 0;
            this.progressBarExam.Location = new System.Drawing.Point(0, 318);
            this.progressBarExam.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarExam.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressBarExam.Name = "progressBarExam";
            this.progressBarExam.Size = new System.Drawing.Size(655, 5);
            this.progressBarExam.TabIndex = 8;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubmit.FlatAppearance.BorderSize = 0;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Location = new System.Drawing.Point(514, 0);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(70, 49);
            this.buttonSubmit.TabIndex = 10;
            this.buttonSubmit.Text = "Nộp bài";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // labelQuestionKit
            // 
            this.labelQuestionKit.AutoSize = true;
            this.labelQuestionKit.Location = new System.Drawing.Point(2, 3);
            this.labelQuestionKit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuestionKit.Name = "labelQuestionKit";
            this.labelQuestionKit.Size = new System.Drawing.Size(84, 13);
            this.labelQuestionKit.TabIndex = 0;
            this.labelQuestionKit.Text = "Bộ đề của bạn: ";
            // 
            // labelQuestionTotal
            // 
            this.labelQuestionTotal.AutoSize = true;
            this.labelQuestionTotal.Location = new System.Drawing.Point(2, 22);
            this.labelQuestionTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuestionTotal.Name = "labelQuestionTotal";
            this.labelQuestionTotal.Size = new System.Drawing.Size(64, 13);
            this.labelQuestionTotal.TabIndex = 2;
            this.labelQuestionTotal.Text = "Số câu hỏi: ";
            // 
            // buttonExamEnd
            // 
            this.buttonExamEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExamEnd.FlatAppearance.BorderSize = 0;
            this.buttonExamEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExamEnd.Location = new System.Drawing.Point(584, 0);
            this.buttonExamEnd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExamEnd.Name = "buttonExamEnd";
            this.buttonExamEnd.Size = new System.Drawing.Size(70, 49);
            this.buttonExamEnd.TabIndex = 11;
            this.buttonExamEnd.Text = "Kết thúc";
            this.buttonExamEnd.UseVisualStyleBackColor = true;
            this.buttonExamEnd.Click += new System.EventHandler(this.buttonExamEnd_Click);
            // 
            // labelTimeLeft
            // 
            this.labelTimeLeft.AutoSize = true;
            this.labelTimeLeft.Location = new System.Drawing.Point(218, 3);
            this.labelTimeLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimeLeft.Name = "labelTimeLeft";
            this.labelTimeLeft.Size = new System.Drawing.Size(91, 13);
            this.labelTimeLeft.TabIndex = 4;
            this.labelTimeLeft.Text = "Thời gian còn lại: ";
            // 
            // labelQuestionAnswered
            // 
            this.labelQuestionAnswered.AutoSize = true;
            this.labelQuestionAnswered.Location = new System.Drawing.Point(218, 22);
            this.labelQuestionAnswered.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuestionAnswered.Name = "labelQuestionAnswered";
            this.labelQuestionAnswered.Size = new System.Drawing.Size(91, 13);
            this.labelQuestionAnswered.TabIndex = 6;
            this.labelQuestionAnswered.Text = "Số câu đã trả lời: ";
            // 
            // textBoxQuestionKit
            // 
            this.textBoxQuestionKit.BackColor = System.Drawing.Color.White;
            this.textBoxQuestionKit.Location = new System.Drawing.Point(88, 1);
            this.textBoxQuestionKit.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxQuestionKit.Name = "textBoxQuestionKit";
            this.textBoxQuestionKit.ReadOnly = true;
            this.textBoxQuestionKit.Size = new System.Drawing.Size(76, 20);
            this.textBoxQuestionKit.TabIndex = 1;
            // 
            // textBoxQuestionTotal
            // 
            this.textBoxQuestionTotal.BackColor = System.Drawing.Color.White;
            this.textBoxQuestionTotal.Location = new System.Drawing.Point(88, 19);
            this.textBoxQuestionTotal.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxQuestionTotal.Name = "textBoxQuestionTotal";
            this.textBoxQuestionTotal.ReadOnly = true;
            this.textBoxQuestionTotal.Size = new System.Drawing.Size(76, 20);
            this.textBoxQuestionTotal.TabIndex = 3;
            // 
            // textBoxTimeLeft
            // 
            this.textBoxTimeLeft.BackColor = System.Drawing.Color.White;
            this.textBoxTimeLeft.Location = new System.Drawing.Point(312, 1);
            this.textBoxTimeLeft.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTimeLeft.Name = "textBoxTimeLeft";
            this.textBoxTimeLeft.ReadOnly = true;
            this.textBoxTimeLeft.Size = new System.Drawing.Size(76, 20);
            this.textBoxTimeLeft.TabIndex = 5;
            // 
            // textBoxQuestionAnswered
            // 
            this.textBoxQuestionAnswered.BackColor = System.Drawing.Color.White;
            this.textBoxQuestionAnswered.Location = new System.Drawing.Point(311, 20);
            this.textBoxQuestionAnswered.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxQuestionAnswered.Name = "textBoxQuestionAnswered";
            this.textBoxQuestionAnswered.ReadOnly = true;
            this.textBoxQuestionAnswered.Size = new System.Drawing.Size(76, 20);
            this.textBoxQuestionAnswered.TabIndex = 7;
            // 
            // UserControlExamProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textBoxQuestionAnswered);
            this.Controls.Add(this.textBoxTimeLeft);
            this.Controls.Add(this.textBoxQuestionTotal);
            this.Controls.Add(this.textBoxQuestionKit);
            this.Controls.Add(this.labelQuestionAnswered);
            this.Controls.Add(this.labelQuestionTotal);
            this.Controls.Add(this.labelTimeLeft);
            this.Controls.Add(this.labelQuestionKit);
            this.Controls.Add(this.buttonExamEnd);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.progressBarExam);
            this.Controls.Add(this.groupBoxQuestionPicker);
            this.Controls.Add(this.groupBoxQuestionDisplay);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserControlExamProgress";
            this.Size = new System.Drawing.Size(655, 322);
           
            this.groupBoxQuestionDisplay.ResumeLayout(false);
            this.groupBoxQuestionDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxQuestionDisplay;
        private System.Windows.Forms.GroupBox groupBoxQuestionPicker;
        private MaterialSkin.Controls.MaterialProgressBar progressBarExam;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelQuestionKit;
        private System.Windows.Forms.Label labelQuestionTotal;
        private System.Windows.Forms.Button buttonExamEnd;
        private System.Windows.Forms.Label labelTimeLeft;
        private System.Windows.Forms.Label labelQuestionAnswered;
        private System.Windows.Forms.TextBox textBoxQuestionKit;
        private System.Windows.Forms.TextBox textBoxQuestionTotal;
        private System.Windows.Forms.TextBox textBoxTimeLeft;
        private System.Windows.Forms.TextBox textBoxQuestionAnswered;
        private System.Windows.Forms.Button buttonQuestionNext;
        private System.Windows.Forms.TextBox textBoxQuestionResult;
        private System.Windows.Forms.Label labelQuestionResult;
        private System.Windows.Forms.Button buttonShowHint;
        private System.Windows.Forms.RichTextBox richTextBoxQuestionContent;
    }
}
