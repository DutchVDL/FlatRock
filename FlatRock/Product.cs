using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRock
{
    public class Product
    {
        public string? productName { get; set; }
        public string? price { get; set; }
        public string? rating { get; set; }

        public override string ToString()
        {
            return $"{productName} , {price} , {rating}";
        }

    }
}
