using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class CategoryBL
    {
        CategoryDAL categoriesDal = new CategoryDAL();

        public bool AddCategory(Category category)
        {
            List<Category> categories = GetCategories();
            foreach (var item in categories)
            {
                if (item.Name == category.Name)
                {
                    return false;
                }
            }
            return categoriesDal.AddCategory(category);
        }

        public List<Category> GetCategories()
        {
            return categoriesDal.GetCategories();
        }

        public bool UpdateCategory(Category category)
        {
            return categoriesDal.UpdateCategory(category);
        }

        public Category GetCategoryByName(string name)
        {
            return categoriesDal.GetCategoryByName(name);
        }
    }
}
