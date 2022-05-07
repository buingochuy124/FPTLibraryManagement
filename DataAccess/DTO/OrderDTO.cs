using System;
using System.Collections.Generic;

namespace DataAccess.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }

        List<OrderDetailDTO> ListOrderDetail { get; set; }
    }
}
