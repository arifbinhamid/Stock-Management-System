namespace Stock
{
    partial class StockInForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.companyCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ReorderLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StockQuantityLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.stockInQunatityTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Company";
            // 
            // companyCombobox
            // 
            this.companyCombobox.FormattingEnabled = true;
            this.companyCombobox.Location = new System.Drawing.Point(121, 20);
            this.companyCombobox.Name = "companyCombobox";
            this.companyCombobox.Size = new System.Drawing.Size(217, 21);
            this.companyCombobox.TabIndex = 2;
            this.companyCombobox.SelectedIndexChanged += new System.EventHandler(this.companyCombobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item";
            // 
            // ItemComboBox
            // 
            this.ItemComboBox.FormattingEnabled = true;
            this.ItemComboBox.Location = new System.Drawing.Point(121, 60);
            this.ItemComboBox.Name = "ItemComboBox";
            this.ItemComboBox.Size = new System.Drawing.Size(217, 21);
            this.ItemComboBox.TabIndex = 2;
            this.ItemComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Reorder Lavel";
            // 
            // ReorderLabel
            // 
            this.ReorderLabel.AutoSize = true;
            this.ReorderLabel.Location = new System.Drawing.Point(118, 113);
            this.ReorderLabel.Name = "ReorderLabel";
            this.ReorderLabel.Size = new System.Drawing.Size(0, 13);
            this.ReorderLabel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Available Quantity";
            // 
            // StockQuantityLabel
            // 
            this.StockQuantityLabel.AutoSize = true;
            this.StockQuantityLabel.Location = new System.Drawing.Point(118, 152);
            this.StockQuantityLabel.Name = "StockQuantityLabel";
            this.StockQuantityLabel.Size = new System.Drawing.Size(0, 13);
            this.StockQuantityLabel.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Stock-in-Quantity";
            // 
            // stockInQunatityTextBox
            // 
            this.stockInQunatityTextBox.Location = new System.Drawing.Point(121, 189);
            this.stockInQunatityTextBox.Name = "stockInQunatityTextBox";
            this.stockInQunatityTextBox.Size = new System.Drawing.Size(217, 20);
            this.stockInQunatityTextBox.TabIndex = 3;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(263, 227);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // StockInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 276);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.stockInQunatityTextBox);
            this.Controls.Add(this.ItemComboBox);
            this.Controls.Add(this.companyCombobox);
            this.Controls.Add(this.StockQuantityLabel);
            this.Controls.Add(this.ReorderLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "StockInForm";
            this.Text = "StockInForm";
            this.Load += new System.EventHandler(this.StockInForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox companyCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ItemComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ReorderLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label StockQuantityLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox stockInQunatityTextBox;
        private System.Windows.Forms.Button SaveButton;
    }
}