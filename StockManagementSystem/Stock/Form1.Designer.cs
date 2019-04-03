namespace Stock
{
    partial class Form1
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
            this.AddCategoryButton = new System.Windows.Forms.Button();
            this.ManageCompanyButton = new System.Windows.Forms.Button();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.StockInButton = new System.Windows.Forms.Button();
            this.StockOutButton = new System.Windows.Forms.Button();
            this.SearchAndViewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddCategoryButton
            // 
            this.AddCategoryButton.Location = new System.Drawing.Point(12, 12);
            this.AddCategoryButton.Name = "AddCategoryButton";
            this.AddCategoryButton.Size = new System.Drawing.Size(385, 33);
            this.AddCategoryButton.TabIndex = 2;
            this.AddCategoryButton.Text = "Add Category";
            this.AddCategoryButton.UseVisualStyleBackColor = true;
            this.AddCategoryButton.Click += new System.EventHandler(this.AddCategoryButton_Click);
            // 
            // ManageCompanyButton
            // 
            this.ManageCompanyButton.Location = new System.Drawing.Point(14, 61);
            this.ManageCompanyButton.Name = "ManageCompanyButton";
            this.ManageCompanyButton.Size = new System.Drawing.Size(385, 33);
            this.ManageCompanyButton.TabIndex = 2;
            this.ManageCompanyButton.Text = "Manage Company";
            this.ManageCompanyButton.UseVisualStyleBackColor = true;
            this.ManageCompanyButton.Click += new System.EventHandler(this.AddCompanyButton_Click);
            // 
            // AddItemButton
            // 
            this.AddItemButton.Location = new System.Drawing.Point(14, 115);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(385, 33);
            this.AddItemButton.TabIndex = 2;
            this.AddItemButton.Text = "Add Item";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // StockInButton
            // 
            this.StockInButton.Location = new System.Drawing.Point(14, 169);
            this.StockInButton.Name = "StockInButton";
            this.StockInButton.Size = new System.Drawing.Size(385, 33);
            this.StockInButton.TabIndex = 2;
            this.StockInButton.Text = "Stock In";
            this.StockInButton.UseVisualStyleBackColor = true;
            this.StockInButton.Click += new System.EventHandler(this.StockInButton_Click);
            // 
            // StockOutButton
            // 
            this.StockOutButton.Location = new System.Drawing.Point(14, 225);
            this.StockOutButton.Name = "StockOutButton";
            this.StockOutButton.Size = new System.Drawing.Size(385, 33);
            this.StockOutButton.TabIndex = 2;
            this.StockOutButton.Text = "Stock Out";
            this.StockOutButton.UseVisualStyleBackColor = true;
            this.StockOutButton.Click += new System.EventHandler(this.StockOutButton_Click);
            // 
            // SearchAndViewButton
            // 
            this.SearchAndViewButton.Location = new System.Drawing.Point(14, 281);
            this.SearchAndViewButton.Name = "SearchAndViewButton";
            this.SearchAndViewButton.Size = new System.Drawing.Size(385, 33);
            this.SearchAndViewButton.TabIndex = 2;
            this.SearchAndViewButton.Text = "Search and View Items";
            this.SearchAndViewButton.UseVisualStyleBackColor = true;
            this.SearchAndViewButton.Click += new System.EventHandler(this.SearchAndViewButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 335);
            this.Controls.Add(this.SearchAndViewButton);
            this.Controls.Add(this.StockOutButton);
            this.Controls.Add(this.StockInButton);
            this.Controls.Add(this.AddItemButton);
            this.Controls.Add(this.ManageCompanyButton);
            this.Controls.Add(this.AddCategoryButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddCategoryButton;
        private System.Windows.Forms.Button ManageCompanyButton;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.Button StockInButton;
        private System.Windows.Forms.Button StockOutButton;
        private System.Windows.Forms.Button SearchAndViewButton;

    }
}

