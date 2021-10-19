using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        public string ID;
        public string status;
        public int currentFloor;
        public string direction;
        public Door door;
        public List<int> floorRequestsList;
        public List<int> completedRequestsList;

        public Elevator(string _elevatorID)
        {
            this.ID = _elevatorID;
            this.status = "idle";
            this.currentFloor = 1;
            this.direction = "null";
            this.door = new Door(1, "off");
            this.floorRequestsList = new List<int>();
            this.completedRequestsList = new List<int>();
            
        }
        public void move()
        {

            while (floorRequestsList.Count != 0)
            {
                int destination = floorRequestsList[0];
                status = "moving";
                if (currentFloor < destination)
                {
                    direction = "up";
                    sortFloorList();
                    while (currentFloor < destination)
                    {
                         currentFloor++;
                    }
                }
                else if (currentFloor > destination)
                {
                    direction = "down";
                    sortFloorList();
                    while (currentFloor > destination)
                    {
                        currentFloor--;
                    }
                }
                status = "stopped";
                operateDoors();
                floorRequestsList.RemoveAt(0);
            }
            status = "idle";
        }

        public void sortFloorList()
        {
            floorRequestsList.Sort();
            if (direction == "down")
            {
                floorRequestsList.Reverse();
            }
        }

        public void operateDoors()
        {
            door.status = "opened";
            //Wait 5 secondes
            door.status = "closed";
        }

        public void addNewRequest(int requestedFloor)
        {
            completedRequestsList.Add(requestedFloor);
            if (floorRequestsList.Contains(requestedFloor) == false)
            {
                floorRequestsList.Add(requestedFloor);
            }

            if (currentFloor < requestedFloor)
            {
                direction = "up";
            }
            else if (currentFloor > requestedFloor)
            {
                direction = "down";
            }   
        }        
    }
}