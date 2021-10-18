using System;
using System.Collections.Generic;

namespace Commercial_Controller
{   
    public class Column
    {
        public string ID;
        public string status;
        public List<int> servedFloors;
        public bool isBasement;
        public Elevator[] elevatorsList;
        public CallButton[] callButtonsList;
        public Column(string _ID, int _amountOfElevators, List<int> _servedFloors, bool _isBasement)
        {
            this.ID = _ID;
            this.status = "online";
            this.servedFloors = _servedFloors;
            this.isBasement = _isBasement;
            this.elevatorsList = new Elevator[_amountOfElevators];
            this.callButtonsList = new CallButton[_servedFloors.Count];
        }

        //Simulate when a user press a button on a floor to go back to the first floor
        // public Elevator requestElevator(int userPosition, string direction)
        // {
        //     Elevator yes = new Elevator;
        // }

    }
}