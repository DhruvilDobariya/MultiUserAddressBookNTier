using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountactCategoryENT
/// </summary>

namespace AddressBook.ENT
{
    public class ContactCategoryENT : ContactCategoryENTBase
    {
        protected UserENT _User;
        public UserENT User
        {
            get { return _User; }
            set { _User = value; }
        }

        protected ICollection<ContactENT> _Contacts;
        public ICollection<ContactENT> Contacts
        {
            get { return _Contacts; }
            set { _Contacts = value; }
        }

        protected ICollection<ContactWiseContactCategoryENT> _ContactWiseContactCategories;
        public ICollection<ContactWiseContactCategoryENT> ContactWiseContactCategories
        {
            get { return _ContactWiseContactCategories; }
            set { _ContactWiseContactCategories = value; }
        }
    }
}