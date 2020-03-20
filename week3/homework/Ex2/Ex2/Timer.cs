using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2
{
    class Timer
    {
        private int threshold;
        private int total;
        public event EventHandler AlarmEvent;

        public Timer(int Threshold)
        {
            this.threshold = Threshold;
        }

        public void Add(int x)
        {
            this.total += x;

            if (this.total >= this.threshold)
            {
                OnThresholdReached(EventArgs.Empty);
            }
        }

        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = AlarmEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}

