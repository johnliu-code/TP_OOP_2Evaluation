using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCounter
{
    class User
    {
        protected string firstname;
        protected string lastname;
        protected int usertype;
        protected string username;
        protected int pinnumber;

        Random randomNumber = new Random();

        public User() { }
        public User(string _firstname, string _lastname, string _username)
        {
            firstname = _firstname;
            lastname = _lastname;
            username = _username;
            pinnumber = randomNumber.Next(100000, 999999);
        }

        public string GetFirstname() { return firstname; }
        public string GetLastname() { return lastname; }
        public string GetUserName() { return username; }
        public int GetUserType() { return usertype; }
        public int GetPinNumber() { return pinnumber; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int UserType { get; }
        public int PINNumber { get; }

    }
}

