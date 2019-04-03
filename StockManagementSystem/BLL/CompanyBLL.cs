using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class CompanyBLL
    {
        CompanyDAL companyDal = new CompanyDAL();

        public bool AddCompany(Company company)
        {
            List<Company> companies = GetCompanies();
            foreach (var item in companies)
            {
                if (item.Name == company.Name)
                {
                    return false;
                }
            }
            return companyDal.AddCompany(company);
        }

        public List<Company> GetCompanies()
        {
            return companyDal.GetCompanies();
        }

        public bool UpdateCompany(Company company)
        {
            return companyDal.UpdateCompany(company);
        }

        public Company GetCompanyByName(string name)
        {
            return companyDal.GetCompanyByName(name);
        }
    }
}
