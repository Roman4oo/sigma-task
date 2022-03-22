using System;
using MarsRover.Core.CommandCenter;
using MarsRover.Core.Mars;
using MarsRover.Core.Rovers;

namespace MarsRover.ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            var plateau = new Plateau();

            var commandCenter = new CommandCenter();

            var roverSquadManager = new RoverSquadManager(plateau);

            Console.WriteLine("Please enter coordinates of pletau:");
            var pletauCords = Console.ReadLine();

            var createPlateauCommand = new CreatePlateauCommand(plateau, pletauCords);
            commandCenter.SendCommand(createPlateauCommand);

            Console.WriteLine("Enter coordinates for rover to deploy:");
            var roverCords = Console.ReadLine();

            var createRoverCommand = new CreateRoverCommand(roverSquadManager, roverCords);
            commandCenter.SendCommand(createRoverCommand);

            Console.WriteLine("Enter rover movent:");
            var roverMovement = Console.ReadLine();

            var moveRoverCommand = new MoveRoverCommand(roverSquadManager, roverMovement);
            commandCenter.SendCommand(moveRoverCommand);

            Console.WriteLine("Deploy second rover:");
            roverCords = Console.ReadLine();

            createRoverCommand = new CreateRoverCommand(roverSquadManager, roverCords);
            commandCenter.SendCommand(createRoverCommand);

            Console.WriteLine("Enter rover movent:");
            roverMovement = Console.ReadLine();

            moveRoverCommand = new MoveRoverCommand(roverSquadManager, roverMovement);
            commandCenter.SendCommand(moveRoverCommand);

            foreach (var rover in roverSquadManager.ListRovers())
            {
                Console.WriteLine(rover.Location());
            }

            Console.ReadLine();
        }
    }
}
