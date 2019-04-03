using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class ItemDAL
    {
        static string connectionString = @"Server=SAZID-PC\SQLEXPRESS; Database=StockManagement; Integrated Security = true ";
        SqlConnection conn = new SqlConnection(connectionString);

        // Getting Item list
        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            string query = "SELECT * FROM items";
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Item item = new Item();
                item.Id = (int)reader["id"];
                item.Name = reader["name"].ToString();
                item.CategoryId = (int)reader["category_id"];
                item.CompanyId = (int)reader["company_id"];
                item.Quantity = (int)reader["quantity"];
                item.ReorderLebel = (int)reader["reorder_label"];
                items.Add(item);
            }
            reader.Close();
            conn.Close();
            return items;
        }

        public List<Item> GetItems(int companyId)
        {
            List<Item> items = new List<Item>();
            string query = "SELECT * FROM items WHERE company_id =" + companyId;
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Item item = new Item();
                item.Id = (int)reader["id"];
                item.Name = reader["name"].ToString();
                item.CategoryId = (int)reader["category_id"];
                item.CompanyId = (int)reader["company_id"];
                string d = reader["quantity"].ToString();
                if ( d != "")
                {
                    item.Quantity = Convert.ToInt32(d);
                }
                item.ReorderLebel = (int)reader["reorder_label"];
                items.Add(item);
            }
            reader.Close();
            conn.Close();
            return items;
        }
        
        public List<Item> GetItemsByCtegory(int categoryId)
        {
            List<Item> items = new List<Item>();
            string query = "SELECT * FROM items WHERE category_id =" + categoryId;
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Item item = new Item();
                item.Id = (int)reader["id"];
                item.Name = reader["name"].ToString();
                item.CategoryId = (int)reader["category_id"];
                item.CompanyId = (int)reader["company_id"];
                string d = reader["quantity"].ToString();
                if (d != "")
                {
                    item.Quantity = Convert.ToInt32(d);
                }
                item.ReorderLebel = (int)reader["reorder_label"];
                items.Add(item);
            }
            reader.Close();
            conn.Close();
            return items;
        }

        public List<Item> GetItemsByCompanyAndCategory(int companyId, int categoryId)
        {
            if (companyId == 0 && categoryId == 0)
            {
                return GetItems();
            }

            if (companyId != 0 && categoryId == 0)
            {
                return GetItems(companyId);
            }

            if (companyId == 0 && categoryId != 0)
            {
                return GetItemsByCtegory(categoryId);
            }

            List<Item> items = new List<Item>();
            string query = "SELECT * FROM items WHERE company_id = " + companyId +
                           " AND category_id = " + categoryId;
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Item item = new Item();
                item.Id = (int)reader["id"];
                item.Name = reader["name"].ToString();
                item.CategoryId = (int)reader["category_id"];
                item.CompanyId = (int)reader["company_id"];
                string d = reader["quantity"].ToString();
                if (d != "")
                {
                    item.Quantity = Convert.ToInt32(d);
                }
                item.ReorderLebel = (int)reader["reorder_label"];
                items.Add(item);
            }
            reader.Close();
            conn.Close();
            return items;
        }

        // Getting single item
        public Item GetItem(int id)
        {
            Item item = new Item();
            string query = "SELECT * FROM items WHERE id = " + id;
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                item.Id = (int)reader["id"];
                item.Name = reader["name"].ToString();
                item.CategoryId = (int)reader["category_id"];
                item.CompanyId = (int)reader["company_id"];
                item.Quantity = (int)reader["quantity"];
                item.ReorderLebel = (int)reader["reorder_label"];
                break;
            }

            reader.Close();
            conn.Close();
            return item;

        }

        // Checking for an item
        public bool GetItem(string name, int categoryId, int companyId)
        {
            string query = "SELECT * FROM items WHERE name = '" + name
                            + "' AND category_id = " + categoryId +
                            " AND company_id = " + companyId;
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            int result = 0;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result++;
            }
            conn.Close();
            if (result>0)
            {
                return false;
            }

            return true;
        }

        // Adding single item
        public bool AddItem(Item item)
        {
            bool status = false;
            string query = "INSERT INTO items (name, category_id, company_id, reorder_label)" +
                           "Values('" + item.Name + "', " + item.CategoryId + ", " +
                           item.CompanyId + ", " + item.ReorderLebel + ")";
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                status = true;
            }

            return status;
        }

        // Updating item
        public bool UpdateItem(Item item)
        {
            bool status = false;
            string query = "UPDATE items SET name = '"+item.Name+"', " +
                           "reorder_label = "+ item.ReorderLebel +
                           " WHERE id = " + item.Id;
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                status = true;
            }

            return status;
        }

        public bool IncreaseItemQuantity(int itemId, int quantityToIncrease)
        {
            bool status = false;
            int previousQuantity = GetItem(itemId).Quantity;
            quantityToIncrease += previousQuantity;
            string query = "UPDATE items SET quantity =" + quantityToIncrease +
                "WHERE id = " + itemId;
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                status = true;
            }

            return status;
        }

        public bool DecreaseItemQuantity(int itemId, int quantityToDecrese, string type)
        {
            bool status = false;
            int previousQuantity = GetItem(itemId).Quantity;
            int updatedQuantity = previousQuantity - quantityToDecrese;
            string query = "UPDATE items SET quantity =" + updatedQuantity +
                           "WHERE id = " + itemId;
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                status = true;
            }

            return status;
        }

        // Deleting item
        public bool DeleteItem(int id)
        {
            bool status = false;
            string query = "DELETE FROM items WHERE id = " + id;
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                status = true;
            }

            return status;
        }


        
    }

}
