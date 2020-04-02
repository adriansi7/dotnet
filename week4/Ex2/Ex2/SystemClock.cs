using System;

namespace Ex2
{
    class SystemClock : IClock
    {
        public DateTime Now
        {
            get { return DateTime.Now.Date; }
        }

        public DateTime UtcNow
        {
            get { return DateTime.UtcNow.Date; }
        }

        public BusinessDate Today { get; set; }

        public SystemClock(BusinessDate date) 
        {
            Today = date;
        }
    }
}
