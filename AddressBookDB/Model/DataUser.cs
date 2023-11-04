using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB.Model
{
    public class DataUser
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string fullName { get; set; }

        public string email { get; set; }
        public string category { get; set; }
        public string photo { get; set; }
    }
}
