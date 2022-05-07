using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public interface IOrderDetail
    {
        int OrderDetail_Create(long BookISBN, int Quantity,int OderID); 
    }
}
