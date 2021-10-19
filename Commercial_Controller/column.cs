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
        public List<Elevator> elevatorsList;
        public List<CallButton> callButtonsList;
        public Column(string _ID, int _amountOfElevators, List<int> _servedFloors, bool _isBasement)
        {
            this.ID = _ID;
            this.status = "online";
            this.servedFloors = _servedFloors;
            this.isBasement = _isBasement;
            this.elevatorsList = new List<Elevator>();
            this.callButtonsList = new List<CallButton>();

            createElevators(servedFloors.Count, elevatorsList.Count);
            createCallButtons(servedFloors.Count, isBasement);
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
                elevatorsList.Add(elevator);
                Program.elevatorID++;
            }
        }

        //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int _userPosition, string _direction)
        {
            Elevator bestElevator = findElevator(_userPosition, _direction);
            bestElevator.addNewRequest(_userPosition);
            bestElevator.move();

            bestElevator.addNewRequest(1);
            bestElevator.move();

            return bestElevator;
        }

        public Elevator findElevator(int _requestedFloor, string _requestedDirection)
        {
            Elevator bestElevator = elevatorsList[0];
            int bestScore = 6;
            int referenceGap = servedFloors.Count * 2;

            if (_requestedFloor == 1)
            {
                foreach (Elevator elevator in elevatorsList)
                {
                    if (elevator.currentFloor == 1 && elevator.status == "stopped")
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(1, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                    else if (elevator.currentFloor == 1 && elevator.status == "idle")
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(2, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                    else if (elevator.currentFloor < 1 && elevator.direction == "up")
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(3, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                    else if (elevator.currentFloor < 1 && elevator.direction == "down")
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(3, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                    else if (elevator.status == "idle")
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(4, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                    else
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(5, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                }
            }
            else
            {
                foreach (Elevator elevator in elevatorsList)
                {
                    if (elevator.currentFloor == _requestedFloor && elevator.status == "stopped" && elevator.direction == _requestedDirection)
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(1, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                    else if (elevator.currentFloor < _requestedFloor && elevator.direction == "up" && _requestedDirection == "up")
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(2, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                    else if (elevator.currentFloor < _requestedFloor && elevator.direction == "down" && _requestedDirection == "down")
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(2, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                    else if (elevator.status == "idle")
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(3, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                    else
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(4, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
                    }
                }
            }
            return bestElevator;
        }
        
        public (Elevator, int, int) checkIfElevatorIsBetter(int _scoreToCheck, Elevator _newElevator, int _bestScore, int _referenceGap, Elevator _bestElevator, int _floor)
        {
            if (_scoreToCheck < _bestScore)
            {
                _bestScore = _scoreToCheck;
                _bestElevator = _newElevator;
                _referenceGap = Math.Abs(_newElevator.currentFloor - _floor);
            }
            else if (_bestScore == _scoreToCheck)
            {
                int gap = Math.Abs(_newElevator.currentFloor - _floor);
                if (_referenceGap > gap)
                    _bestElevator = _newElevator;
                    _referenceGap = gap;
                {
                    
                }
            }
            return (_bestElevator, _bestScore, _referenceGap);
        }
    }
}