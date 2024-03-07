﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRock
{
    public class Product
    {
        public string? Name { get; set; }
        public string Price { get; set; }
        public string Rating { get; set; }

        public override string ToString()
        {
            return $"{Name} , {Price} , {Rating}";
        }

    }
}
