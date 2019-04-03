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
    public partial class SearchAndViewForm : Form
    {
        private List<Category> categories = new List<Category>();
        private List<Company> companies = new List<Company>();
        private List<Item> items = new List<Item>();
        private List<SearchResult> searchResults = new List<SearchResult>();

        private CategoryBL categoryBll = new CategoryBL();
        private CompanyBLL companyBll = new CompanyBLL();
        private ItemBLL itemBll = new ItemBLL();


        private int selectedCompanyId = 0;
        private int selectedCategoryId = 0;

        public SearchAndViewForm()
        {
            InitializeComponent();
            categories = categoryBll.GetCategories();
            companies = companyBll.GetCompanies();
            searchResultDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var category in categories)
            {
                categoryComboBox.Items.Add(category.Name);
            }

            foreach (var company in companies)
            {
                companyComboBox.Items.Add(company.Name);
            }

        }

        private int GetCategoryId(string name)
        {
            foreach (var category in categories)
            {
                if (category.Name == name)
                {
                    return category.Id;
                }
            }

            return 0;
        }

        private int GetCompanyId(string name)
        {
            foreach (var company in companies)
            {
                if (company.Name == name)
                {
                    return company.Id;
                }
            }

            return 0;
        }

        private string GetCompanyName(int id)
        {
            foreach (var company in companies)
            {
                if (company.Id == id)
                {
                    return company.Name;
                }
            }

            return null;
        }

        private string GetCategoryName(int id)
        {
            foreach (var category in categories)
            {
                if (category.Id == id)
                {
                    return category.Name;
                }
            }

            return null;
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCompanyId = GetCompanyId(companyComboBox.SelectedItem.ToString());

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCategoryId = GetCategoryId(categoryComboBox.SelectedItem.ToString());
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
//            MessageBox.Show(selectedCategoryId.ToString() + " - " + selectedCompanyId.ToString());
            items = itemBll.GetItemsByCompanyAndCategory(selectedCompanyId, selectedCategoryId);
            searchResultDataGridView.DataSource = null;
            foreach (var item in items)
            {
                SearchResult result = new SearchResult();
                result.ItemName = item.Name;
                result.Company = GetCompanyName(item.CompanyId);
                result.Category = GetCategoryName(item.CategoryId);
                result.AvailableQuantity = item.Quantity.ToString();
                result.ReorderLavel = item.ReorderLebel.ToString();
                searchResults.Add(result);
            }

            searchResultDataGridView.DataSource = searchResults;
        }
    }
}
