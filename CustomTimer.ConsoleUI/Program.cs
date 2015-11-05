using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomTimer.ConsoleUI
{
    class MicrowaveAlarm
    {
        public MicrowaveAlarm(CustomTimer timer)
        {
            if (timer == null)
                throw new ArgumentNullException();
            Console.WriteLine("MicrowaveAlarm is now registered");
            timer.TimeIsUp += MicrowaveAlarmMsg;
        }

        public void Register(CustomTimer timer)
        {
            if (timer == null)
                throw new ArgumentNullException();
            Console.WriteLine("MicrowaveAlarm is now registered");
            timer.TimeIsUp += MicrowaveAlarmMsg;
        }

        public void Unregister(CustomTimer timer)
        {
            if (timer == null)
                throw new ArgumentNullException();
            Console.WriteLine("Microwave is now unregistered");
            timer.TimeIsUp -= MicrowaveAlarmMsg;
        }

        public void MicrowaveAlarmMsg(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Food is ready");
        }
    }

    class HandWatchAlarm
    {
        public HandWatchAlarm(CustomTimer timer)
        {
            if (timer==null)
                throw new ArgumentNullException();
            Console.WriteLine("HandWatchAlarm is now registered");
            timer.TimeIsUp += AlarmMsg;
        }

        public void Register(CustomTimer timer)
        {
            if (timer == null)
                throw new ArgumentNullException();
            Console.WriteLine("HandWatchAlarm is now registered");
            timer.TimeIsUp += AlarmMsg;
        }

        public void Unregister(CustomTimer timer)
        {
            if (timer==null)
                throw new ArgumentNullException();
            Console.WriteLine("HandWatchAlarm is now unregistered");
            timer.TimeIsUp -= AlarmMsg;
        }

        public void AlarmMsg(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("HandWatch alarm is ringing");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CustomTimer customTimer=new CustomTimer();
            MicrowaveAlarm microwaveAlarm=new MicrowaveAlarm(customTimer);
            HandWatchAlarm handWatchAlarm=new HandWatchAlarm(customTimer);
            customTimer.StartTimer(5);
            Thread.Sleep(5500);
            microwaveAlarm.Unregister(customTimer);
            customTimer.StartTimer(3);
            Thread.Sleep(3500);
            handWatchAlarm.Unregister(customTimer);
            Console.ReadKey();
        }
    }
}
