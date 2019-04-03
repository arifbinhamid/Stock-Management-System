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
    public partial class CompanyForm : Form
    {
        private int selectedCompanyId = -1;
        private string selectedCompanyName = null;
        private CompanyBLL companyBll = new CompanyBLL();
        public CompanyForm()
        {
            InitializeComponent();
            CancelButton.Visible = false;
            companiesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            companiesDataGridView.DataSource = companyBll.GetCompanies();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (selectedCompanyId >= 0 &&
                !String.IsNullOrEmpty(selectedCompanyName) &&
                !String.IsNullOrEmpty(NameTextBox.Text))
            {
                //Update Company
                Company company = new Company();
                company.Id = selectedCompanyId;
                company.Name = NameTextBox.Text;
                if (companyBll.UpdateCompany(company))
                {
                    MessageBox.Show("Company updated successfully...");
                    CancelButton.Visible = false;
                    NameTextBox.Clear();
                    selectedCompanyId = -1;
                    selectedCompanyName = null;
                    SaveButton.Text = "Save";
                }
            }else if(String.IsNullOrEmpty(NameTextBox.Text))

            {
                MessageBox.Show("Please enter a company name");
            }
            else
            {
                // add Company
                Company company = new Company();
                company.Name = NameTextBox.Text;
                if (companyBll.AddCompany(company))
                {
                    MessageBox.Show("Company added successfully...");
                    NameTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Company creation failed...");
                }
            }

            companiesDataGridView.DataSource = companyBll.GetCompanies();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancelButton.Visible = false;
            NameTextBox.Clear();
            selectedCompanyId = -1;
            selectedCompanyName = null;
            SaveButton.Text = "Save";
        }

        private void companiesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = companiesDataGridView.CurrentRow.Index;
                NameTextBox.Text = companiesDataGridView.Rows[row].Cells[1].Value.ToString();
                selectedCompanyName = companiesDataGridView.Rows[row].Cells[1].Value.ToString();
                selectedCompanyId = (int)companiesDataGridView.Rows[row].Cells[0].Value;
                SaveButton.Text = "Update";
                CancelButton.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("No Company selected...");
            }
        }

      
    }
}
