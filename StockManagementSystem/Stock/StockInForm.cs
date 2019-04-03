using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;

namespace Stock
{
    public partial class StockInForm : Form
    {
        ItemBLL itemBll = new ItemBLL();
        List<Item> items = new List<Item>();

        CompanyBLL companyBll = new CompanyBLL();
        List<Company> companies = new List<Company>();

        private int selectedItemId = -1;
        private int quantityToAdd = 0;
        public StockInForm()
        {
            InitializeComponent();
            companies = companyBll.GetCompanies();
            ItemComboBox.Enabled = false;
            stockInQunatityTextBox.Enabled = false;
            foreach (var company in companies)
            {
                companyCombobox.Items.Add(company.Name);
            }
        }

        private void companyCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCompany = companyCombobox.SelectedItem.ToString();
//            MessageBox.Show(selectedCompany);
            items = itemBll.GetItems(selectedCompany);
            if (items != null)
            {
                foreach (var item in items)
                {
                    string companyName ="";
                    foreach (var company in companies)
                    {
                        if (item.CompanyId == company.Id)
                        {
                            companyName = company.Name;
                        }
                    }
                    ItemComboBox.Items.Add(item.Name + " - " + companyName);
                }
            }

            ItemComboBox.Enabled = true;
        }

        private void ItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = ItemComboBox.SelectedIndex;
            selectedItemId = items[selectedItem].Id;
//            MessageBox.Show(selectedItemId.ToString());
            StockQuantityLabel.Text = items[selectedItem].Quantity.ToString();
            ReorderLabel.Text = items[selectedItem].ReorderLebel.ToString();
            stockInQunatityTextBox.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(stockInQunatityTextBox.Text))
            {
                quantityToAdd = Convert.ToInt32(stockInQunatityTextBox.Text);
//                MessageBox.Show(quantityToAdd.ToString() + " - " + selectedItemId);

                if (itemBll.IncreaseItemQuantity(selectedItemId, quantityToAdd))
                {
                    MessageBox.Show("Items added successfully...");
                }
                else
                {
                    MessageBox.Show("Items not added successfully...");
                }
            }
            else
            {
                MessageBox.Show("Please enter quantity...");
            }
            
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {

        }
    }
}
