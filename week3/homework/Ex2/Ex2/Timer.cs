using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ex2
{
    class Timer
    {
        private int threshold;
        public event EventHandler AlarmEvent;

        public Timer(int Threshold)
        {
            this.threshold = Threshold;
        }

        public void Elapse()
        {
            while (true)
            {
                Thread.Sleep(this.threshold);
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

