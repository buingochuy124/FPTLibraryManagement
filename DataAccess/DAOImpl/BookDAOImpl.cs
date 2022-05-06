using DataAccess.DAO;
using DataAccess.DTO;
using System;
using System.Collections.Generic;

namespace DataAccess.DAOImpl
{
    public class BookDAOImpl : IBookDAO
    {
        public List<BookDTO> Books_GetList()
        {
            throw new NotImplementedException();
        }

        public List<BookDTO> Books_GetListByPage(int? PageNumber, int? NumberPerPage)
        {
            throw new NotImplementedException();
        }

        public int Book_Create(string BookISBN, string BookName, string Author, double Cost, int Pages, int CategoryID, string Description, string BookImageURL)
        {
            throw new NotImplementedException();
        }

        public BookDTO Book_GetDetail(int BookID)
        {
            throw new NotImplementedException();
        }
    }
}
