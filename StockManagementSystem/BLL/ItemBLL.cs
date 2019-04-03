using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class ItemBLL
    {
        ItemDAL itemDal = new ItemDAL();
        CompanyDAL companyDal = new CompanyDAL();
        public bool AddItem(Item item)
        {
            if (!itemDal.GetItem(item.Name, item.CategoryId, item.CompanyId))
            {
                return false;
            }

            return itemDal.AddItem(item);
        }

        public List<Item> GetItems()
        {
            return itemDal.GetItems();
        }

        public List<Item> GetItems(string companyName)
        {
            int companyId = companyDal.GetCompanyByName(companyName).Id;
            return itemDal.GetItems(companyId);
        }
        public bool UpdateItem(Item item)
        {
            return itemDal.UpdateItem(item);
        }

        public bool DeleteItem(int id)
        {
            return itemDal.DeleteItem(id);
        }

        public bool IncreaseItemQuantity(int itemId, int quantityToIncrease)
        {
            return itemDal.IncreaseItemQuantity(itemId, quantityToIncrease);
        }


        public bool DecreaseItemQuantity(int itemId, int quantityToDecrease, string type)
        {
            return itemDal.DecreaseItemQuantity(itemId, quantityToDecrease, type);
        }

        public List<Item> GetItemsByCompanyAndCategory(int companyId, int categoryId)
        {
            return itemDal.GetItemsByCompanyAndCategory(companyId, categoryId);
        }
    }
}
