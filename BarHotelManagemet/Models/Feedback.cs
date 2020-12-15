using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarHotelManagemet.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string FeedbackDescription { get; set; }
    }
}