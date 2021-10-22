using System;

namespace Commercial_Controller
{
    //Declares each Door
    public class Door
    {
        public int ID = 1;
        public string status;

        //Function used to create new Doors with the desired properties
        public Door(int _ID, string _status)
        {
            this.ID = _ID;
            this.status = _status;
        }
    }
}