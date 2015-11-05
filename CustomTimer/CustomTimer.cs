using System;
using System.Timers;

namespace CustomTimer
{
    public class CustomTimer
    {
        private bool _alreadyStarted = false;
        private readonly object _locker=new object();
        private readonly Timer _timer;

        public delegate void TimeIsUpEventHandler(object sender, EventArgs e);

        public event TimeIsUpEventHandler TimeIsUp;

        public CustomTimer()
        {
            _timer=new Timer();
            _timer.Elapsed += OnTimeIsUp;
            _timer.AutoReset = false;
        }

        public virtual void OnTimeIsUp(object sender, EventArgs e)
        {
            if(TimeIsUp!=null)
                TimeIsUp(sender, e);
            lock(_locker)
            {
                _alreadyStarted = false;
            }
        }

        public void StartTimer(int seconds)
        {
            if (!_alreadyStarted)
            {
                lock (_locker)
                {
                    if (!_alreadyStarted)
                    {
                        _timer.Interval = 1000*seconds;
                        _timer.Enabled=true;
                        _alreadyStarted = true;
                    }
                }
            }
        }
    }
}
