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
    public partial class CategoryForm : Form
    {
        private int selectedCategoryId = -1;
        private string selectedCategoryName = null;
        private CategoryBL categoriesBl = new CategoryBL();
        public CategoryForm()
        {
            InitializeComponent();
            CancelButton.Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            List<Category> categoriesData = categoriesBl.GetCategories();
            dataGridView1.DataSource = categoriesData;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId >= 0 
                && selectedCategoryName != null 
                && !String.IsNullOrEmpty(nameTextBox.Text))
            {
                Category category = new Category();
                category.Id = selectedCategoryId;
                category.Name = nameTextBox.Text;
                if (categoriesBl.UpdateCategory(category))
                {
                    MessageBox.Show("Category Updated successfully...");
                    nameTextBox.Clear();
                    selectedCategoryId = -1;
                    selectedCategoryName = null;
                    CancelButton.Visible = false;
                    SaveButton.Text = "Save";
                }
                else
                {
                    MessageBox.Show("Category update failed");
                }
            }
            else if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please Enter a Category name");
            }
            else
            {
                Category category = new Category();
                category.Name = nameTextBox.Text;
                if (categoriesBl.AddCategory(category))
                {
                    MessageBox.Show("Category Added Successfully...");
                }
                else
                {
                    MessageBox.Show("Category Creation Failed...");
                }
            }

            dataGridView1.DataSource = categoriesBl.GetCategories();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = dataGridView1.CurrentRow.Index;
                nameTextBox.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                selectedCategoryName = dataGridView1.Rows[row].Cells[1].Value.ToString();
                selectedCategoryId = (int)dataGridView1.Rows[row].Cells[0].Value;
                SaveButton.Text = "Update";
                CancelButton.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("No Category selected");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Clear();
            selectedCategoryId = -1;
            selectedCategoryName = null;
            CancelButton.Visible = false;
            SaveButton.Text = "Save";
        }
    }
}
