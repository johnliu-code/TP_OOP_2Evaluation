using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCounter
{
    class Client : User
    {
        public Client() { usertype = 1; }
        public Client(string _firstname, string _lastname, string _username) : base(_firstname, _lastname, _username)
        {
            usertype = 1;
        }
    }
}

