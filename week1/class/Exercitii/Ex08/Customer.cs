﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex08
{
    class Customer
    {
        public int id;
        public string name;
        public double consumption;

        public Customer(int id, string name, double consumption)
        {
            this.id = id;
            this.name = name;
            this.consumption = consumption;
        }
    }
}
