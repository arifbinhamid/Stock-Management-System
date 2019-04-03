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
    public partial class ItemForm : Form
    {
        CategoryBL categoryBll= new CategoryBL();
        List<Category> categories = new List<Category>();

        CompanyBLL companyBll = new CompanyBLL();
        List<Company> companies = new List<Company>();

        ItemBLL itemBll = new ItemBLL();
        public ItemForm()
        {
            InitializeComponent();

            // Adding items to Category combo
            categories = categoryBll.GetCategories();
            foreach (var category in categories)
            {
                CategoryComboBox.Items.Add(category.Name);
                
            }

            //Adding items to Company combo
            companies = companyBll.GetCompanies();
            foreach (var company in companies)
            {
                CompanyComboBox.Items.Add(company.Name);
            }

            reorderLablelTextBox.Text = "0";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            string cat = CategoryComboBox.SelectedItem.ToString();
            string com = CompanyComboBox.SelectedItem.ToString();
            if (!String.IsNullOrEmpty(nameTextBox.Text)
                && !String.IsNullOrEmpty(cat)
                && !String.IsNullOrEmpty(com))
            {
                item.CategoryId = categoryBll.GetCategoryByName(cat).Id;
                item.CompanyId = companyBll.GetCompanyByName(com).Id;
                item.Name = nameTextBox.Text;
                item.ReorderLebel = Convert.ToInt32(reorderLablelTextBox.Text);

                if (itemBll.AddItem(item))
                {
                    MessageBox.Show("Item created successfully...");
                }
                else
                {
                    MessageBox.Show("Item Creation failed...");
                }

            }
            else
            {
                MessageBox.Show("Please fill the fields properly...");
            }
        }





    }
}
