using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarHotelManagemet.Models
{
    public class FoodRateList
    {
        public int ID { get; set; }
        public int FoodItemID { get; set; }
        public decimal Rate { get; set; }
        public string PlatType { get; set; }

        public FoodItem FoodItems { get; set; }


    }
}