using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUserApp
{
    class User
    {
        public int ID { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }



        public User() { }

        public User(string login, string password, string email)
        {
            this.login = login;
            this.password = password;
            this.email = email;
        }

        /*public override string ToString()
        {
            return "User: " + login + ". Password: " + password + ". Email: " + email + ".";
        }*/
    }
}
