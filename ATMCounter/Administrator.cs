using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCounter
{
    class Administrator : User
    {
        public Administrator() { usertype = 0; }
        public Administrator(string _firstname, string _lastname, string _username) : base(_firstname, _lastname, _username)
        {
            usertype = 0;
        }
    }
}

