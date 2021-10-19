using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        public char columnID = 'A';
        public int floorRequestButtonID = 1;
        public int ID;
        public string status;
        public List<Column> columnsList;
        public List<FloorRequestButton> floorRequestButtonsList;

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

        public void createBasementColumn(int _amountOfBasement, int _amountOfElevatorPerColumn)
        {
            List<int> servedFloors = new List<int>();
            int floor = -1;
            for (int i = 0; i < _amountOfBasement; i++)
            {
                servedFloors.Add(floor);
                floor--;
            }

            Console.WriteLine("Here's Basement Column {0}", columnID);
            Column basementColumn = new Column(columnID, _amountOfElevatorPerColumn, servedFloors, true);
            columnsList.Add(basementColumn);
            columnID++;
        }


        public void createColumns(double _amountOfColumns, double _amountOfFloors, int _amountOfElevatorPerColumn)
        {
            double amountOfFloorsPerColumn = Math.Ceiling(_amountOfFloors/_amountOfColumns);
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
                Console.WriteLine("=========Here's Column {0}", columnID);
                Column column = new Column(columnID,_amountOfElevatorPerColumn, servedFloors, false);
                columnsList.Add(column);
                columnID++;
            }
        }

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

        public (Column, Elevator) assignElevator(int _requestedFloor, string _direction)
        {
            Column bestColumn = findBestColumn(_requestedFloor);
            Elevator bestElevator = bestColumn.findElevator(1, _direction);
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

