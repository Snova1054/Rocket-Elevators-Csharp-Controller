using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        public int ID;
        public string status;
        public Column[] columnsList;
        public FloorRequestButton[] floorRequestButtonsList;

        public Battery(int _ID, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            this.ID = _ID;
            this.status = "online";
            this.columnsList = new Column[_amountOfColumns];
            this.floorRequestButtonsList = new FloorRequestButton[_amountOfFloors + _amountOfBasements];
        }

        // public Column findBestColumn(int _requestedFloor)
        // {
        //     for (int i = 0; i < columnsList.Length; i++)
        //     {
                
        //     }
        // }
        // //Simulate when a user press a button at the lobby
        // public (Column, Elevator) assignElevator(int _requestedFloor, string _direction)
        // {
            
        // }
    }
}

