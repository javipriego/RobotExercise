using System;
using System.Collections.Generic;

namespace Robot.Factory.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            var robots = new List<IRobot>();
            var robotFactory = new RobotFactory();
            var robot1 = robotFactory.Create(RobotAction.Dance);
            var robot2 = robotFactory.Create(RobotAction.Fight);
            robots.Add(robot1);
            robots.Add(robot2);

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

    public class RobotFight
        : IRobot
    {
        public void DoStuff()
        {
            Console.WriteLine("Robot init");
            Console.WriteLine("Fight");
        }
    }

    public class RobotDance
        : IRobot
    {
        public void DoStuff()
        {
            Console.WriteLine("Robot init");
            Console.WriteLine("Dance");
        }
    }

    public class RobotInit
        : IRobot
    {
        public void DoStuff()
        {
            Console.WriteLine("Robot init");
        }
    }

    public class RobotFactory
        : IRobotFactory
    {
        public IRobot Create(RobotAction robotActions)
        {
            return robotActions switch
            {
                RobotAction.Dance => new RobotDance(),
                RobotAction.Fight => new RobotFight(),
                _ => new RobotInit(),
            };
        }
    }

    public interface IRobotFactory
    {
        IRobot Create(RobotAction robotActions);
    }

    public interface IRobot
    {
        void DoStuff();
    }

    public enum RobotAction
    {
        Dance,
        Fight
    }
}
