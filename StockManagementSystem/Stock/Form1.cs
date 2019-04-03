using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;

namespace Stock
{
    public partial class Form1 : Form
    {
        private CategoryBL categories = new CategoryBL();

        public Form1()
        {
            InitializeComponent();
            

        }


        private void AddCompanyButton_Click(object sender, EventArgs e)
        {
            CompanyForm companyForm = new CompanyForm();
            companyForm.Show();
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.Show();
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm();
            itemForm.Show();
        }

        private void StockInButton_Click(object sender, EventArgs e)
        {
            StockInForm stockInForm = new StockInForm();
            stockInForm.Show();
        }

        private void StockOutButton_Click(object sender, EventArgs e)
        {
            StockOutForm stockOutForm = new StockOutForm();
            stockOutForm.Show();
        }

        private void SearchAndViewButton_Click(object sender, EventArgs e)
        {
            SearchAndViewForm searchAndViewForm = new SearchAndViewForm();
            searchAndViewForm.Show();
        }

    

    }
}
