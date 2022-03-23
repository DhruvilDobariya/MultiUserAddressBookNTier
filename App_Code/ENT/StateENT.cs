using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateENT
/// </summary>

namespace AddressBook.ENT
{
    public class StateENT : StateENTBase
    {
        protected UserENT _User;
        public UserENT User
        {
            get { return _User; }
            set { _User = value; }
        }

        protected CountryENT _Country;
        public CountryENT Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        protected ICollection<CityENT> _Cities;
        public ICollection<CityENT> Cities
        {
            get { return _Cities; }
            set { _Cities = value; }
        }

        protected ICollection<ContactENT> _Contacts;
        public ICollection<ContactENT> Contacts
        {
            get { return _Contacts; }
            set { _Contacts = value; }
        }
    }
}