using DataAccess.DAO;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.DAOImpl
{
    public class BookDAOImpl : IBookDAO
    {
        public List<BookDTO> Books_GetList()
        {
            var result = new List<BookDTO>();
            try
            {
                var sqlconn = ConnectDB.GetSqlConnection();

                SqlCommand cmd = new SqlCommand("SP_GetListBook", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    result.Add(new BookDTO
                    {

                        BookISBN = long.Parse(read["BookISBN"].ToString()),
                        BookName = read["BookName"].ToString(),
                        Cost = double.Parse(read["Cost"].ToString()),
                        Pages = int.Parse(read["Pages"].ToString()),
                        CategoryID = int.Parse(read["CategoryID"].ToString()),
                        BookImageURL = read["BookURL"].ToString(),
                        Author = read["Author"].ToString(),
                        BookDescription = read["BookDescription"].ToString(),
                        StoreID = int.Parse(read["StoreID"].ToString()),


                    });
                }

                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<BookDTO> Books_GetListByPage(int? PageNumber, int? NumberPerPage)
        {
            var result = new List<BookDTO>();
            try
            {
                var sqlconn = ConnectDB.GetSqlConnection();

                SqlCommand cmd = new SqlCommand("SP_GetBookPagination", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@_NumberPerPage", NumberPerPage);


                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    result.Add(new BookDTO
                    {
                        BookISBN = long.Parse(read["BookISBN"].ToString()),
                        BookName = read["BookName"].ToString(),
                        Cost = double.Parse(read["Cost"].ToString()),
                        Pages = int.Parse(read["Pages"].ToString()),
                        CategoryID = int.Parse(read["CategoryID"].ToString()),
                        BookImageURL = read["BookURL"].ToString(),
                        Author = read["Author"].ToString(),
                        BookDescription = read["BookDescription"].ToString(),
                        StoreID = int.Parse(read["StoreID"].ToString()),


                    });
                }

                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Book_Create(long BookISBN, string BookName, string Author, double Cost, int Pages, int CategoryID, string Description, string BookImageURL)
        {
            throw new NotImplementedException();
        }

        public BookDTO Book_GetDetail(long BookISBN)
        {
            var result = new BookDTO();
            try
            {
                var sqlconn = ConnectDB.GetSqlConnection();

                SqlCommand cmd = new SqlCommand("SP_GetBookDetail", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@_BookISBN", BookISBN);


                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    result = new BookDTO
                    {
                        BookISBN = long.Parse(read["BookISBN"].ToString()),
                        BookName = read["BookName"].ToString(),
                        Cost = double.Parse(read["Cost"].ToString()),
                        Pages = int.Parse(read["Pages"].ToString()),
                        CategoryID = int.Parse(read["CategoryID"].ToString()),
                        BookImageURL = read["BookURL"].ToString(),
                        Author = read["Author"].ToString(),
                        BookDescription = read["BookDescription"].ToString(),
                        StoreID = int.Parse(read["StoreID"].ToString()),


                    };
                }

                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
