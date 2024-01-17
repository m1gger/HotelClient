using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hotel
{
    public class Room
    {
        public int id;
        public string type;
        public int capacity;
        public float cost;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public float Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public Room(int id, string type, int capacity, float cost)
        {
            this.id = id;
            this.type = type;
            this.capacity = capacity;
            this.cost = cost;
        }
    }
}
