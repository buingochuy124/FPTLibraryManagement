using DataAccess.DAO;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOImpl
{
    public class CategoryDAOImpl : ICategoryDAO
    {
        public List<CategoryDTO> Categories_GetList()
        {
            throw new NotImplementedException();
        }

        public int Category_Create(string CategoryName)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Category_GetDetailByID(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Category_GetDetailByName(string CategoryName)
        {
            throw new NotImplementedException();
        }
    }
}
