using System;
using System.Collections.Generic;

namespace Robot.Step4
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
        static int _robotCounts = 0;
        int _robotNumber = 0;

        public Robot()
        {
            _robotNumber = _robotCounts;
            _robotCounts++;
        }

        public void DoStuff()
        {
            Console.WriteLine("Robot init" + _robotNumber.ToString());
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
