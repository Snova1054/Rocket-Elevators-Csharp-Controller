using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Program
    {
        public static char columnID = 'A';
        public static char elevatorID = 'A';
        public static int floorRequestButtonID = 1;
        public static int callButtonID = 1;
        // int floor;
        static void Main(string[] args)
        {
            //int scenarioNumber = Int32.Parse(args[0]);
            //Scenarios scenarios = new Scenarios();
            //scenarios.run(scenarioNumber);

            char x = 'A';
            for (int i = 0; i < 10; i++)
            {
                x++;
                Console.Write(x);
            }
        }
    }
}
