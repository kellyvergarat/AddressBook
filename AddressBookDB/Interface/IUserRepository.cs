using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB.Interface
{
    public interface IUserRepository: IDisposable
    {
        IQueryable<User> GetUser();
        //void AddUser(User user);
        
    }
}
