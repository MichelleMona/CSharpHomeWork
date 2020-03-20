using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clock
{
    public delegate void Tick_Alarm(Clock sender, Time time);

    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public Time()
        {
            this.Hour = 0;
            this.Minute = 0;
            this.Second = 0;
        }

        public Time(int x, int y, int z)
        {

            this.Hour = x;
            this.Minute = y;
            this.Second = z;
        }

    }
    public class Clock

    {
        public Time time = new Time();
        public event Tick_Alarm Tick;
        public event Tick_Alarm Alarm;
        public String setTime = DateTime.Now.ToShortTimeString().ToString();
        public int setSecond = 10;
        public int setMinute = 0;
        public int setHour = 0;

        public void Run()//闹钟运行的函数；
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                this.time.Second += 1;
                
                if (this.time.Second == 60)
                {
                    this.time.Second = 0;
                    this.time.Minute += 1;
                    if (this.time.Minute == 60)
                    {
                        this.time.Minute = 0;
                        this.time.Hour += 1;
                        if (this.time.Hour == 24)
                        {
                            this.time.Hour = 0;
                        }
                    }
                }
                Tick(this, this.time);//tick事件
                Alarm(this, this.time);//alarm事件
            }
        }
    }
    public class Person
    {
        public Clock clock = new Clock();
        public Person()
        {
            clock.Alarm += alarm;
            clock.Tick += tick;
        }

        public void tick(Clock sender, Time time)
        {
            Console.WriteLine($"[{sender.time.Hour}:{sender.time.Minute}:{sender.time.Second}]:Tick");
        }
        public void alarm(Clock sender, Time time)
        {
            if (sender.time.Hour==sender.setHour && sender.time.Minute == sender.setMinute && sender.time.Second == sender.setSecond)
            {
                Console.WriteLine("Ring");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.clock.Run();
        }
    }
}