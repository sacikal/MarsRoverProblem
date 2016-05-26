using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Domain;

namespace MarsRoverProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Area:");
            var area = Console.ReadLine();

            Console.WriteLine("Enter Location:");
            var location = Console.ReadLine();

            Console.WriteLine("Enter Command:");
            var command = Console.ReadLine();

            var rover = Rover.Create(area, location);
            rover.Process(command);

            Console.WriteLine(rover);
        }
    }
}
