using System;
using System.Collections.Generic;

namespace Robot.Factory.Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            var robots = new List<IRobot>();
            var robotFactory = new RobotFactory();
            var robot1 = robotFactory.Create(new List<RobotAction> { RobotAction.Dance });
            var robot2 = robotFactory.Create(new List<RobotAction> { RobotAction.Fight });
            var robot3 = robotFactory.Create(new List<RobotAction> { RobotAction.Fight, RobotAction.Dance });
            robots.Add(robot1);
            robots.Add(robot2);
            robots.Add(robot3);

            foreach (IRobot robot in robots)
            {
                robot.DoStuff();
            }
        }
    }

    public class Robot
        : IRobot
    {
        private IList<RobotAction> _robotActions;

        public Robot(IList<RobotAction> robotActions)
        {
            _robotActions = robotActions;
        }

        public void DoStuff()
        {
            Console.WriteLine("Robot init");

            foreach (var action in _robotActions)
            {
                Console.WriteLine(action);
            }
        }
    }

    public class RobotFactory
        : IRobotFactory
    {
        public IRobot Create(IList<RobotAction> robotActions)
        {
            return new Robot(robotActions);
        }
    }

    public interface IRobotFactory
    {
        IRobot Create(IList<RobotAction> robotActions);
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
