using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityENT
/// </summary>

namespace AddressBook.ENT
{
    public class CityENT : CityENTBase
    {
        protected UserENT _User;
        public UserENT User
        {
            get { return _User; }
            set { _User = value; }
        }

        protected StateENT _State;
        public StateENT State
        {
            get { return _State; }
            set { _State = value; }
        }

        protected ICollection<ContactENT> _Contacts;
        public ICollection<ContactENT> Contacts
        {
            get { return _Contacts; }
            set { _Contacts = value; }
        }
    }
}