namespace UI.Views
{
    partial class FormUserTrainResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTrainAvailablePicker = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrainAvailablePicker)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTrainAvailablePicker
            // 
            this.dataGridViewTrainAvailablePicker.AllowUserToAddRows = false;
            this.dataGridViewTrainAvailablePicker.AllowUserToDeleteRows = false;
            this.dataGridViewTrainAvailablePicker.AllowUserToOrderColumns = true;
            this.dataGridViewTrainAvailablePicker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTrainAvailablePicker.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTrainAvailablePicker.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTrainAvailablePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTrainAvailablePicker.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTrainAvailablePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewTrainAvailablePicker.MultiSelect = false;
            this.dataGridViewTrainAvailablePicker.Name = "dataGridViewTrainAvailablePicker";
            this.dataGridViewTrainAvailablePicker.ReadOnly = true;
            this.dataGridViewTrainAvailablePicker.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridViewTrainAvailablePicker.RowHeadersVisible = false;
            this.dataGridViewTrainAvailablePicker.RowTemplate.Height = 24;
            this.dataGridViewTrainAvailablePicker.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTrainAvailablePicker.Size = new System.Drawing.Size(697, 394);
            this.dataGridViewTrainAvailablePicker.TabIndex = 0;
            // 
            // FormUserTrainResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 394);
            this.Controls.Add(this.dataGridViewTrainAvailablePicker);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormUserTrainResult";
            this.Text = "Xem đáp án câu hỏi dựa trên bộ đề đã chọn";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrainAvailablePicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTrainAvailablePicker;
    }
}