using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookDB.Interface;
using AddressBookDB.Model;

namespace AddressBookDB
{
    public class UserRepository: IUserRepository
    {
        UserContext _Ctx;

        public UserRepository(UserContext Context)
        {
            _Ctx = Context;
            _Ctx.Context.Configuration.LazyLoadingEnabled = false;
            _Ctx.Context.Configuration.ProxyCreationEnabled = false;
        }

        /*
        public void AddUser(User user)
        {
            _Ctx.Context.Users.Add(user);
            _Ctx.Context.SaveChanges();
        }*/

        //Method development

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }

        public IQueryable<User> GetUser()
        {
            return _Ctx.Context.Users;
        }
    }
}
