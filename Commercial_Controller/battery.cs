using System;
using System.Collections.Generic;

namespace Commercial_Controller
{

//Declares each Battery
    public class Battery
    {
        public char columnID = 'A';
        public int floorRequestButtonID = 1;
        public int ID;
        public string status;
        public List<Column> columnsList;
        public List<FloorRequestButton> floorRequestButtonsList;

        //Function used to create new Batteries with the desired properties
        public Battery(int _ID, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            this.ID = _ID;
            this.status = "online";
            this.columnsList = new List<Column>();
            this.floorRequestButtonsList = new List<FloorRequestButton>();

            if (_amountOfBasements > 0)
            {
                createBasementColumn(_amountOfBasements, _amountOfElevatorPerColumn);
                createBasementFloorRequestButtons(_amountOfBasements);
                _amountOfColumns--;
            }

            createFloorRequestButtons(_amountOfFloors);
            createColumns(_amountOfColumns, _amountOfFloors, _amountOfElevatorPerColumn);
        }

        //Method used by the Battery to create a basement Column
        public void createBasementColumn(int _amountOfBasement, int _amountOfElevatorPerColumn)
        {
            List<int> servedFloors = new List<int>();
            int floor = -1;
            for (int i = 0; i < _amountOfBasement; i++)
            {
                servedFloors.Add(floor);
                floor--;
            }

            Column basementColumn = new Column(columnID, _amountOfElevatorPerColumn, servedFloors, true);
            columnsList.Add(basementColumn);
            columnID++;
        }

        //Method used to create Columns
        public void createColumns(double _amountOfColumns, double _amountOfFloors, int _amountOfElevatorPerColumn)
        {
            double amountOfFloorsPerColumn = Math.Ceiling(_amountOfFloors / _amountOfColumns);
            int floor = 1;

            for (int i = 0; i < _amountOfColumns; i++)
            {
                List<int> servedFloors = new List<int>();

                for (int j = 0; j < amountOfFloorsPerColumn; j++)
                {
                    if (floor <= _amountOfFloors)
                    {
                        servedFloors.Add(floor);
                        floor++;
                    }
                }
                Column column = new Column(columnID, _amountOfElevatorPerColumn, servedFloors, false);
                columnsList.Add(column);
                columnID++;
            }
        }

        //Method used to create FloorRequestButtons
        public void createFloorRequestButtons(double _amountOfFloors)
        {
            int buttonFloor = 1;
            for (int i = 0; i < _amountOfFloors; i++)
            {
                FloorRequestButton floorRequestButton = new FloorRequestButton(floorRequestButtonID, buttonFloor, "up");
                floorRequestButtonsList.Add(floorRequestButton);
                buttonFloor++;
                floorRequestButtonID++;
            }
        }

        //Method used to create basement FloorRequestButtons
        public void createBasementFloorRequestButtons(int _amountOfBasements)
        {
            int buttonFloor = -1;
            for (int i = 0; i < _amountOfBasements; i++)
            {
                FloorRequestButton floorRequestButton = new FloorRequestButton(floorRequestButtonID, buttonFloor, "down");
                floorRequestButtonsList.Add(floorRequestButton);
                buttonFloor--;
                floorRequestButtonID++;
            }
        }

        //Method used to assign the best Elevator according to the best Column from the user's inputs
        public (Column, Elevator) assignElevator(int _requestedFloor, string _direction)
        {
            Console.WriteLine("An elevator has been requested from the lobby to the floor #{0}\n", _requestedFloor);

            Column bestColumn = findBestColumn(_requestedFloor);
            Elevator bestElevator = bestColumn.findElevator(1, _direction);
            Console.WriteLine("Elevator {0} on the floor #{1} has been selected as the best elevator\n", bestElevator.ID, bestElevator.currentFloor);
            bestElevator.addNewRequest(1);
            bestElevator.move();

            bestElevator.addNewRequest(_requestedFloor);
            bestElevator.move();
            return (bestColumn, bestElevator);
        }

        //Simulate when a user press a button at the lobby
        public Column findBestColumn(int _requestedFloor)
        {
            var returnedObject = default(Column);
            foreach (Column column in columnsList)
            {
                if (column.servedFloors.Contains(_requestedFloor))
                {
                    returnedObject = column;
                }
            }
            return returnedObject;

        }
    }
}

