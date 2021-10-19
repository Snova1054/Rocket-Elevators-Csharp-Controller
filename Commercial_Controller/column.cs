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
        public List<CallButton> callButtonsList;
        public Column(string _ID, int _amountOfElevators, List<int> _servedFloors, bool _isBasement)
        {
            this.ID = _ID;
            this.status = "online";
            this.servedFloors = _servedFloors;
            this.isBasement = _isBasement;
            this.elevatorsList = new Elevator[_amountOfElevators];
            this.callButtonsList = new List<CallButton>();
        }

        public void createCallButtons(int _amountOfFloors, bool _isBasement)
        {
            if (_isBasement)
            {
                int buttonFloor = -1;
                for (int i = 0; i < _amountOfFloors; i++)
                {
                    CallButton callButton = new CallButton(1, buttonFloor, "up");
                    callButtonsList.Add(callButton);
                    buttonFloor--;
                    Program.callButtonID++;
                }
            }
            else
            {
                int buttonFloor = 1;
                for (int i = 0; i < _amountOfFloors; i++)
                {
                    CallButton callButton = new CallButton(1, buttonFloor, "down");
                    callButtonsList.Add(callButton);
                    buttonFloor++;
                    Program.callButtonID++;
                }
            }
        }

        public void createElevators(int _amountOfFloors, int _amountOfElevators)
        {
            for (int i = 0; i < _amountOfElevators; i++)
            {
                Elevator elevator = new Elevator(Program.elevatorID.ToString());
                elevatorsList[i] = elevator;
                Program.elevatorID++;
            }
        }

        //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int userPosition, string direction)
        {
            Elevator yes = new Elevator("1");
            return yes;
        }

    }
}