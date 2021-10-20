using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Program
    {
        static void Main(string[] args)
        {
            int scenarioNumber = Int32.Parse(args[0]);
            Scenarios scenarios = new Scenarios();
            scenarios.run(scenarioNumber);

            //#############################################

            // Battery battery = new Battery(1, 4, 60, 6, 5);
            // Column column = battery.columnsList[1];

            // column.elevatorsList[0].currentFloor = 20;
            // column.elevatorsList[0].direction = "down";
            // column.elevatorsList[0].status = "moving";
            // column.elevatorsList[0].floorRequestsList.Add(5);

            // column.elevatorsList[1].currentFloor = 3;
            // column.elevatorsList[1].direction = "up";
            // column.elevatorsList[1].status = "moving";
            // column.elevatorsList[1].floorRequestsList.Add(15);

            // column.elevatorsList[2].currentFloor = 13;
            // column.elevatorsList[2].direction = "down";
            // column.elevatorsList[2].status = "moving";
            // column.elevatorsList[2].floorRequestsList.Add(1);

            // column.elevatorsList[3].currentFloor = 15;
            // column.elevatorsList[3].direction = "down";
            // column.elevatorsList[3].status = "moving";
            // column.elevatorsList[3].floorRequestsList.Add(2);

            // column.elevatorsList[4].currentFloor = 6;
            // column.elevatorsList[4].direction = "down";
            // column.elevatorsList[4].status = "moving";
            // column.elevatorsList[4].floorRequestsList.Add(2);

            // (Column chosenColumn, Elevator chosenElevator) = battery.assignElevator(20, "up");
            // chosenColumn = moveAllElevators(chosenColumn);

            // Console.Write(chosenColumn.ID, chosenElevator.ID);
        
        }

        // static Column moveAllElevators(Column column) {
        //     for (int i = 0; i < column.elevatorsList.Count; i++)
        //     {
        //         while (column.elevatorsList[i].floorRequestsList.Count != 0)
        //         {
        //             column.elevatorsList[i].move();
        //         }
        //     }
        //     return column;
        // }

    }
}
