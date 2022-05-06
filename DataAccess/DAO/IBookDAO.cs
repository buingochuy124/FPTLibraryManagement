using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public interface IBookDAO
    {
        List<BookDTO> Books_GetList();

        int Book_Create(string BookISBN, string BookName, string Author, double Cost, int Pages, int CategoryID, string Description, string BookImageURL);

        BookDTO Book_GetDetail(int BookID);

        List<BookDTO> Books_GetListByPage(int? PageNumber, int? NumberPerPage);
    }
}
