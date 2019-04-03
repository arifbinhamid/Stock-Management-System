using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class CategoryDAL
    {
        static string connectionString = @"Server=SAZID-PC\SQLEXPRESS; Database=StockManagement; Integrated Security = true ";
        SqlConnection conn = new SqlConnection(connectionString);
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            string query = "SELECT * FROM categories";
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Category category = new Category();
                category.Id = (int)reader["id"];
                category.Name = reader["name"].ToString();
                categories.Add(category);
            }
            reader.Close();
            conn.Close();
            return categories;
        }

        public Category GetCategory(int id)
        {

            Category category = new Category();
            string query = "SELECT * FROM categories WHERE id=" + id;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                category.Id = (int)reader["id"];
                category.Name = reader["name"].ToString();
                break;
            }
            reader.Close();
            conn.Close();
            return category;
        }

        public Category GetCategoryByName(string name)
        {
            Category category = new Category();
            string query = "SELECT * FROM categories WHERE name ='" + name + "'";
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                category.Id = (int)reader["id"];
                category.Name = reader["name"].ToString();
                break;
            }
            reader.Close();
            conn.Close();
            return category;
        }

        public bool AddCategory(Category category)
        {
            bool status = false;
            string query = "INSERT INTO categories (name) VALUES('" + category.Name + "')";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            int result = command.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                status = true;
            }

            return status;
        }

        public bool UpdateCategory(Category category)
        {
            bool status = false;
            string query = "UPDATE categories SET name = '" + category.Name +
                           "' WHERE id = " + category.Id;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            int result = command.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool DeleteCategory(int id)
        {
            bool status = false;
            string query = "DELETE FROM categories WHERE id = " + id;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
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
