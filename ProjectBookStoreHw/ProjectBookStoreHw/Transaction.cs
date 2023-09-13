using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookStoreHw
{
    class Transaction
    {
        public string No { get; set; }
        public string ISBN { get; set; }
        public string Customer_Id { get; set; }
        public int Quatity { get; set; }
        public decimal Total_Price { get; set; }
    }
}
