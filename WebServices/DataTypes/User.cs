using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.DataTypes
{
    
    public class User
    {
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public int userID { get; private set; }
        public bool isAdmin { get; private set; }

        private User() { }
        public User(string firstName, string lastName, int userID, bool isAdmin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userID = userID;
            this.isAdmin = isAdmin;
        }
    }
}