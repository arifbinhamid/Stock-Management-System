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
    public partial class StockOutForm : Form
    {
        ItemBLL itemBll = new ItemBLL();
        List<Item> items = new List<Item>();
        List<Item> allItems = new List<Item>();

        CompanyBLL companyBll = new CompanyBLL();
        List<Company> companies = new List<Company>();

        private int selectedItemId = -1;

        List<CartItem> itemsCart = new List<CartItem>(); 

        public StockOutForm()
        {
            InitializeComponent();
            companies = companyBll.GetCompanies();
            allItems = itemBll.GetItems();

            ItemComboBox.Enabled = false;
            quantityTextBox.Enabled = false;
            AddButton.Enabled = false;

            foreach (var company in companies)
            {
                companyNameComboBox.Items.Add(company.Name);
            }

            itemGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemComboBox.Items.Clear();
            ItemComboBox.Text = "";
            availableQuantityLabel.Text = "";
            reorderQuantityLabel.Text = "";
            string selectedCompany = companyNameComboBox.SelectedItem.ToString();
            int companyId = GetCompanyId(selectedCompany);

            //            MessageBox.Show(selectedCompany);
            items = getItemsByCompanyId(companyId);
            if (items != null)
            {
                foreach (var item in items)
                {
                    string companyName = "";
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
            quantityTextBox.Clear();
        }

        private void ItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = ItemComboBox.SelectedIndex;
            
            selectedItemId = items[selectedItem].Id;
            //            MessageBox.Show(selectedItemId.ToString());
            availableQuantityLabel.Text = items[selectedItem].Quantity.ToString();
            reorderQuantityLabel.Text = items[selectedItem].ReorderLebel.ToString();
            quantityTextBox.Enabled = true;
            quantityTextBox.Clear();
        }



        private void AddButton_Click(object sender, EventArgs e)
        {
            foreach (var item in items)
            {
                if (item.Id == selectedItemId)
                {
                    CartItem singleCartItem = new CartItem();
                    singleCartItem.Id = item.Id;
                    singleCartItem.Company = getCompanyName(item.CompanyId);
                    singleCartItem.Name = item.Name;
                    singleCartItem.Quantity = Convert.ToInt32(quantityTextBox.Text);
                    itemsCart.Add(singleCartItem);
                    foreach (var mainItem in allItems)
                    {
                        if (mainItem.Id == item.Id)
                        {
                            mainItem.Quantity -= Convert.ToInt32(quantityTextBox.Text);
                        }
                    }
//                    item.Quantity -= Convert.ToInt32(quantityTextBox.Text);
                    availableQuantityLabel.Text = item.Quantity.ToString();
                    break;
                }
            }

            itemGridView.DataSource = null;
            itemGridView.DataSource = itemsCart;
            itemGridView.Columns["Id"].Visible = false;
            quantityTextBox.Clear();
            AddButton.Enabled = false;


        }

        private void quantityTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (quantityTextBox.Text != "")
            {
                int stockQuantityAfterOrder = Convert.ToInt32(availableQuantityLabel.Text) -
                                              Convert.ToInt32(quantityTextBox.Text);
                if (stockQuantityAfterOrder < 0)
                {
                    MessageBox.Show("Item not available please reduce quantity...");
                }
                else
                {
                    if (Convert.ToInt32(quantityTextBox.Text) > 0)
                    {
                        AddButton.Enabled = true;
                    }
                }
            }
        }

        private string getCompanyName(int companyId)
        {
            string name = "Unknown";
            foreach (var company in companies)
            {
                if (company.Id == companyId)
                {
                    name = company.Name;
                }
            }

            return name;
        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            bool status = true;
            foreach (var cartItem in itemsCart)
            {
                if (!itemBll.DecreaseItemQuantity(cartItem.Id, cartItem.Quantity, "sold"))
                {
                    MessageBox.Show("Operation failed");
                    status = false;
                    break;
                }
            }

            itemsCart = null;
            itemGridView.DataSource = itemsCart;
            if (status)
            {
                MessageBox.Show("Operation successfull...");
            }
        }

        private void DamageButton_Click(object sender, EventArgs e)
        {
            bool status = true;
            foreach (var cartItem in itemsCart)
            {
                if (!itemBll.DecreaseItemQuantity(cartItem.Id, cartItem.Quantity, "damaged"))
                {
                    MessageBox.Show("Operation failed");
                    status = false;
                    break;
                }
            }

            itemsCart = null;
            itemGridView.DataSource = itemsCart;
            if (status)
            {
                MessageBox.Show("Operation successfull...");
            }
        }

        private void LostButton_Click(object sender, EventArgs e)
        {
            bool status = true;
            foreach (var cartItem in itemsCart)
            {
                if (!itemBll.DecreaseItemQuantity(cartItem.Id, cartItem.Quantity, "lost"))
                {
                    MessageBox.Show("Operation failed");
                    status = false;
                    break;
                }
            }

            itemsCart = null;
            itemGridView.DataSource = itemsCart;
            if (status)
            {
                MessageBox.Show("Operation successfull...");
            }
        }

        private List<Item> getItemsByCompanyId(int id)
        {
            List<Item> items = new List<Item>();
            foreach (var item in allItems)
            {
                if (id == item.CompanyId)
                {
                    items.Add(item);
                }
            }

            return items;
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


       
    }
}
