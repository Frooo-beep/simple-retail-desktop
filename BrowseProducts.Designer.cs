namespace SimplerRetail
{
    partial class BrowseProducts
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
            this.buttonSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewBrowseProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBrowseProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(676, 410);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(112, 34);
            this.buttonSelect.TabIndex = 5;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "BROWSE PRODUCTS";
            // 
            // dataGridViewBrowseProducts
            // 
            this.dataGridViewBrowseProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBrowseProducts.Location = new System.Drawing.Point(12, 64);
            this.dataGridViewBrowseProducts.Name = "dataGridViewBrowseProducts";
            this.dataGridViewBrowseProducts.RowHeadersWidth = 62;
            this.dataGridViewBrowseProducts.RowTemplate.Height = 33;
            this.dataGridViewBrowseProducts.Size = new System.Drawing.Size(776, 322);
            this.dataGridViewBrowseProducts.TabIndex = 3;
            // 
            // BrowseProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewBrowseProducts);
            this.Name = "BrowseProducts";
            this.Text = "BrowseProducts";
            this.Load += new System.EventHandler(this.BrowseProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBrowseProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonSelect;
        private Label label1;
        private DataGridView dataGridViewBrowseProducts;
    }
}