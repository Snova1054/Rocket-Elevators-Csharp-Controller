using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    
    //Declares each Column
    public class Column
    {
        public int callButtonID = 1;

        public char elevatorID = 'A';

        public string ID;
        public string status;
        public List<int> servedFloors;
        public bool isBasement;
        public List<Elevator> elevatorsList;
        public List<CallButton> callButtonsList;

        //Function used to create new Columns with the desired properties
        public Column(char _ID, int _amountOfElevators, List<int> _servedFloors, bool _isBasement)
        {
            this.ID = _ID.ToString();
            this.status = "online";
            this.servedFloors = _servedFloors;
            this.isBasement = _isBasement;
            this.elevatorsList = new List<Elevator>();
            this.callButtonsList = new List<CallButton>();

            createElevators(servedFloors.Count, _amountOfElevators);
            createCallButtons(servedFloors.Count, isBasement);
        }

        //Method used by the Column to create Call Buttons
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
                    callButtonID++;
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
                    callButtonID++;
                }
            }
        }

        //Method used to create Elevators
        public void createElevators(int _amountOfFloors, int _amountOfElevators)
        {
            for (int i = 0; i < _amountOfElevators; i++)
            {
                Elevator elevator = new Elevator(elevatorID);
                elevatorsList.Add(elevator);
                elevatorID++;
            }
        }

        //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int _userPosition, string _direction)
        {
            Console.WriteLine("An elevator has been requested for the floor #{0} to go {1}\n", _userPosition, _direction);
            Elevator bestElevator = findElevator(_userPosition, _direction);
            Console.WriteLine("Elevator {0} on the floor #{1} has been selected as the best elevator\n", bestElevator.ID, bestElevator.currentFloor);
            bestElevator.addNewRequest(_userPosition);
            bestElevator.move();

            bestElevator.addNewRequest(1);
            bestElevator.move();

            return bestElevator;
        }

        //Method used to find the best Elevator possible
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
                    else if (elevator.currentFloor > 1 && elevator.direction == "down")
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
                    else if (elevator.currentFloor > _requestedFloor && elevator.direction == "down" && _requestedDirection == "down")
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(2, elevator, bestScore, referenceGap, bestElevator, _requestedFloor);
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
            return bestElevator;
        }

        //Method used to compared a new Elevator's information with the bestElevator's
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