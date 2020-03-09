using System;
using System.Collections.Generic;
using System.Text;

namespace Ex08
{

    class Bill
    {
        public int surcharge = 15;
        public int surchargeThreshold = 400;

        public double GetRate(double consumption)
        {

            if (consumption <= 199)
            {
                return 1.20;
            }

            if (consumption > 199 && consumption < 400)
            {
                return 1.50;
            }

            if (consumption >= 400 && consumption < 600)
            {
                return 1.80;
            }

            return 2.00;
        }

        public double GetSurcharge(double amount)
        {

            if (amount > this.surchargeThreshold)
            {
                return (amount * this.surcharge) / 100;
            }

            return 0;
        }
    }
}
