namespace SimplerRetail
{
    partial class DailyReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelToProductSold = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelToTrans = new System.Windows.Forms.Label();
            this.labelDateValue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelIncome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // labelToProductSold
            // 
            this.labelToProductSold.AutoSize = true;
            this.labelToProductSold.Location = new System.Drawing.Point(246, 167);
            this.labelToProductSold.Name = "labelToProductSold";
            this.labelToProductSold.Size = new System.Drawing.Size(36, 25);
            this.labelToProductSold.TabIndex = 1;
            this.labelToProductSold.Text = "xxx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gross Income";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Product Sold";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Transaction";
            // 
            // labelToTrans
            // 
            this.labelToTrans.AutoSize = true;
            this.labelToTrans.Location = new System.Drawing.Point(246, 112);
            this.labelToTrans.Name = "labelToTrans";
            this.labelToTrans.Size = new System.Drawing.Size(28, 25);
            this.labelToTrans.TabIndex = 5;
            this.labelToTrans.Text = "xx";
            // 
            // labelDateValue
            // 
            this.labelDateValue.AutoSize = true;
            this.labelDateValue.Location = new System.Drawing.Point(246, 57);
            this.labelDateValue.Name = "labelDateValue";
            this.labelDateValue.Size = new System.Drawing.Size(82, 25);
            this.labelDateValue.TabIndex = 6;
            this.labelDateValue.Text = "xx-xx-xxx";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(246, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Rp.";
            // 
            // labelIncome
            // 
            this.labelIncome.AutoSize = true;
            this.labelIncome.Location = new System.Drawing.Point(279, 231);
            this.labelIncome.Name = "labelIncome";
            this.labelIncome.Size = new System.Drawing.Size(36, 25);
            this.labelIncome.TabIndex = 8;
            this.labelIncome.Text = "xxx";
            // 
            // DailyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 360);
            this.Controls.Add(this.labelIncome);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelDateValue);
            this.Controls.Add(this.labelToTrans);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelToProductSold);
            this.Controls.Add(this.label1);
            this.Name = "DailyReport";
            this.Text = "DailyReport";
            this.Load += new System.EventHandler(this.DailyReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label labelToProductSold;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label labelToTrans;
        private Label labelDateValue;
        private Label label8;
        private Label labelIncome;
    }
}