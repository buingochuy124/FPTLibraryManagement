using DataAccess.DTO;
using System.Collections.Generic;

namespace DataAccess.DAO
{
    public interface IBookDAO
    {
        List<BookDTO> Books_GetList();

        int Book_Create(long BookISBN, string BookName, string Author, double Cost, int Pages, int CategoryID, string Description, string BookImageURL);

        BookDTO Book_GetDetail(long BookISBN);

        List<BookDTO> Books_GetListByPage(int? PageNumber, int? NumberPerPage);
    }
}
