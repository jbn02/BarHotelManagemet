using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarHotelManagemet.Models
{
    public class TableOrder
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OrderNo { get; set; }
        public string KOT { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}