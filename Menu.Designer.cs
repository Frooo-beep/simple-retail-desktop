namespace SimplerRetail
{
    partial class Menu
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
            this.mmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.mExportData = new System.Windows.Forms.ToolStripMenuItem();
            this.mLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mmReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.mMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.mmData = new System.Windows.Forms.ToolStripMenuItem();
            this.mProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mmTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.mNewTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.mHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mmFile
            // 
            this.mmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mProfile,
            this.mExportData,
            this.mLogout,
            this.mExit});
            this.mmFile.Name = "mmFile";
            this.mmFile.Size = new System.Drawing.Size(59, 29);
            this.mmFile.Text = "FILE";
            // 
            // mProfile
            // 
            this.mProfile.Name = "mProfile";
            this.mProfile.Size = new System.Drawing.Size(270, 34);
            this.mProfile.Text = "Profile";
            // 
            // mExportData
            // 
            this.mExportData.Name = "mExportData";
            this.mExportData.Size = new System.Drawing.Size(270, 34);
            this.mExportData.Text = "Export Data";
            this.mExportData.Click += new System.EventHandler(this.mExportData_Click);
            // 
            // mLogout
            // 
            this.mLogout.Name = "mLogout";
            this.mLogout.Size = new System.Drawing.Size(270, 34);
            this.mLogout.Text = "Logout";
            this.mLogout.Click += new System.EventHandler(this.mLogout_Click);
            // 
            // mExit
            // 
            this.mExit.Name = "mExit";
            this.mExit.Size = new System.Drawing.Size(270, 34);
            this.mExit.Text = "Exit";
            this.mExit.Click += new System.EventHandler(this.mExit_Click);
            // 
            // mmReport
            // 
            this.mmReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDaily,
            this.mMonth});
            this.mmReport.Name = "mmReport";
            this.mmReport.Size = new System.Drawing.Size(91, 29);
            this.mmReport.Text = "REPORT";
            // 
            // mDaily
            // 
            this.mDaily.Name = "mDaily";
            this.mDaily.Size = new System.Drawing.Size(270, 34);
            this.mDaily.Text = "Daily";
            this.mDaily.Click += new System.EventHandler(this.mDaily_Click);
            // 
            // mMonth
            // 
            this.mMonth.Name = "mMonth";
            this.mMonth.Size = new System.Drawing.Size(270, 34);
            this.mMonth.Text = "Month";
            // 
            // mmData
            // 
            this.mmData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mProduct,
            this.mEmployee,
            this.mSupplier});
            this.mmData.Name = "mmData";
            this.mmData.Size = new System.Drawing.Size(72, 29);
            this.mmData.Text = "DATA";
            // 
            // mProduct
            // 
            this.mProduct.Name = "mProduct";
            this.mProduct.Size = new System.Drawing.Size(192, 34);
            this.mProduct.Text = "Product";
            this.mProduct.Click += new System.EventHandler(this.mProduct_Click);
            // 
            // mEmployee
            // 
            this.mEmployee.Name = "mEmployee";
            this.mEmployee.Size = new System.Drawing.Size(192, 34);
            this.mEmployee.Text = "Employee";
            this.mEmployee.Click += new System.EventHandler(this.mEmployee_Click);
            // 
            // mSupplier
            // 
            this.mSupplier.Name = "mSupplier";
            this.mSupplier.Size = new System.Drawing.Size(192, 34);
            this.mSupplier.Text = "Supplier";
            this.mSupplier.Click += new System.EventHandler(this.mSupplier_Click);
            // 
            // mmTransaction
            // 
            this.mmTransaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mNewTransaction,
            this.mHistory});
            this.mmTransaction.Name = "mmTransaction";
            this.mmTransaction.Size = new System.Drawing.Size(147, 29);
            this.mmTransaction.Text = "TRANSACTION";
            // 
            // mNewTransaction
            // 
            this.mNewTransaction.Name = "mNewTransaction";
            this.mNewTransaction.Size = new System.Drawing.Size(242, 34);
            this.mNewTransaction.Text = "New Transaction";
            this.mNewTransaction.Click += new System.EventHandler(this.mNewTransaction_Click);
            // 
            // mHistory
            // 
            this.mHistory.Name = "mHistory";
            this.mHistory.Size = new System.Drawing.Size(242, 34);
            this.mHistory.Text = "History";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmFile,
            this.mmData,
            this.mmTransaction,
            this.mmReport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStripMenuItem mmFile;
        private ToolStripMenuItem mProfile;
        private ToolStripMenuItem mExportData;
        private ToolStripMenuItem mLogout;
        private ToolStripMenuItem mExit;
        private ToolStripMenuItem mmReport;
        private ToolStripMenuItem mDaily;
        private ToolStripMenuItem mMonth;
        private ToolStripMenuItem mmData;
        private ToolStripMenuItem mProduct;
        private ToolStripMenuItem mEmployee;
        private ToolStripMenuItem mSupplier;
        private ToolStripMenuItem mmTransaction;
        private ToolStripMenuItem mNewTransaction;
        private ToolStripMenuItem mHistory;
        private MenuStrip menuStrip1;
    }
}