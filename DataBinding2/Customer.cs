using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBinding2
{
    class Customer
    {
        private String firstName, lastName, address;

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

    }
}
