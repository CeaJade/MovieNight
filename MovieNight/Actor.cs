using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    class Actor
    {
        private int id;
        private string firstName;
        private string lastName;

        public int ID 
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName 
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName 
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public Actor(string firstname, string lastname) 
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public Actor(int id, string firstname, string lastname)
        : this(firstname, lastname)
        {
            this.id = id;
        }

    }
}
