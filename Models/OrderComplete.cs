using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Models
{
    public class OrderComplete
    {
        public string order_id { get; set; }
        public string payment_id { get; set; }
        public string signature { get; set; }
    }
}
