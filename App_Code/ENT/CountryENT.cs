using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryENT
/// </summary>

namespace AddressBook.ENT
{
    public class CountryENT : CountryENTBase
    {
        protected UserENT _User;
        public UserENT User
        {
            get { return _User; }
            set { _User = value; }
        }

        protected ICollection<StateENT> _States;
        public ICollection<StateENT> State
        {
            get { return _States; }
            set { _States = value; }
        }

        protected ICollection<ContactENT> _Contacts;
        public ICollection<ContactENT> Contacts
        {
            get { return _Contacts; }
            set { _Contacts = value; }
        }
    }
}