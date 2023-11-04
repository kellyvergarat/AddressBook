using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB
{
    public class UserContext
    {
        AddressBookEntities _Ctx;
        
        public UserContext()
        {
            _Ctx = new AddressBookEntities();
        }

        public AddressBookEntities Context
        {
            get
            {
                return this._Ctx;
            }
        }

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }
    }
}
