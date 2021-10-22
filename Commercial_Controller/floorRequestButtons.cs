namespace Commercial_Controller
{
    //Button on a floor or basement to go back to lobby
    public class FloorRequestButton
    {
        public int ID;
        public string status;
        public int floor;
        public string direction;


        //Function used to create new NewFloorRequestButtons with the desired properties
       public FloorRequestButton(int _ID, int _floor, string _direction)
        {
            this.ID = _ID;
            this.status = "off";
            this.floor = _floor;
            this.direction = _direction;
        }
    }
}