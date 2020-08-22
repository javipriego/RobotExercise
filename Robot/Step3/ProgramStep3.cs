using System;
using System.Collections.Generic;

namespace Robot.Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            var robots = new List<IRobot>();
            var robot1 = new Robot();
            var robot2 = new Robot();
            var robot3 = new Robot();
            robots.Add(new DancerRobotDecorator(robot1));
            robots.Add(new FighterRobotDecorator(robot2));
            robots.Add(new DancerRobotDecorator(new FighterRobotDecorator(robot3)));

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
        }
    }

    public class DancerRobotDecorator
        : IRobot
    {
        IRobot _robot;

        public DancerRobotDecorator(IRobot robot)
        {
            this._robot = robot;
        }

        public void DoStuff()
        {
            _robot.DoStuff();
            Console.WriteLine("Dance");            
        }
    }

    public class FighterRobotDecorator
        : IRobot
    {
        IRobot _robot;

        public FighterRobotDecorator(IRobot robot)
        {
            this._robot = robot;
        }

        public void DoStuff()
        {
            _robot.DoStuff();
            Console.WriteLine("Fight");
        }
    }

    public interface IRobot
    {
        void DoStuff();
    }
}
