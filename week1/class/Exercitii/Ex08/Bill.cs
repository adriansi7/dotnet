using System;
using System.Collections.Generic;
using System.Text;

namespace Ex08
{
    class Bill
    {
        public int surcharge = 15;
        public int surchargeThreshold = 400;

        public double GetRate(int consumption) {
            if (consumption <= 199) {
                return 1.20;
            }
        }
    }
}
