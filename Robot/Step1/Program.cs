using System;
using System.Collections.Generic;

namespace Robot.Step1
{
    class Program
    {
        static void Main(string[] args)
        {
            var robots = new List<IRobot>();
            var robot1 = new Robot();
            robots.Add(robot1);

            foreach (IRobot robot in robots)
            {
                robot.DoStuff();
            }
        }
    }

    public class Robot
        : IRobot
    {
        public void DoStuff()
        {
            Console.WriteLine("Robot init");
            Console.WriteLine("Dance");
        }
    }

    public interface IRobot
    {
        void DoStuff();
    }
}
