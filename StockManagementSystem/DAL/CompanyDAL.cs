using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class CompanyDAL
    {
        static string connectionString = @"Server=SAZID-PC\SQLEXPRESS; Database=StockManagement; Integrated Security = true ";
        SqlConnection conn = new SqlConnection(connectionString);
        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            string query = "SELECT * FROM companies";
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Company company = new Company();
                company.Id = (int)reader["id"];
                company.Name = reader["name"].ToString();
                companies.Add(company);
            }
            reader.Close();
            conn.Close();
            return companies;
        }

        public Company GetCompany(int id)
        {

            Company company = new Company();
            string query = "SELECT * FROM companies WHERE id=" + id;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                company.Id = (int)reader["id"];
                company.Name = reader["name"].ToString();
                break;
            }
            reader.Close();
            conn.Close();
            return company;
        }

        public Company GetCompanyByName(string name)
        {

            Company company = new Company();
            string query = "SELECT * FROM companies WHERE name= '" + name + "'";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                company.Id = (int) reader["id"];
                company.Name = reader["name"].ToString();
                break;
            }
            reader.Close();
            conn.Close();
            return company;
        }

        public bool AddCompany(Company company)
        {
            bool status = false;
            string query = "INSERT INTO companies (name) VALUES('" + company.Name + "')";
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

        public bool UpdateCompany(Company company)
        {
            bool status = false;
            string query = "UPDATE companies SET name = '" + company.Name +
                           "' WHERE id = " + company.Id;
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

        public bool DeleteCompany(int id)
        {
            bool status = false;
            string query = "DELETE FROM companies WHERE id = " + id;
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
