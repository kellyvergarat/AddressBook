using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB.Model
{
    public class ModelMapping
    {
        public DataUser LoadUser(AddressBookDB.User user)
        {
            return new DataUser
            {
                id = user.id,
                firstName = user.firstName,
                lastName = user.lastName,
                fullName = user.firstName.Trim()+" "+user.lastName.Trim(),
                email = user.email,
                category = user.category,
                photo = user.photo
            };
        }

        public DataUser GetUser(AddressBookDB.User user)
        {
            return new DataUser
            {
                id = user.id,
                fullName = user.firstName.Trim() + " " + user.lastName.Trim(),
                email = user.email,
                category = user.category,
                photo = user.photo
            };
        }
    }
}
