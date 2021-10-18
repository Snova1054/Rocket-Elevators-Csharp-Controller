using System;

namespace Commercial_Controller
{
    public class Door
    {
        public int ID = 1;
        public string status;

        public Door(int ID, string status)
        {
            this.ID = ID;
            this.status = status;
        }
    }
}