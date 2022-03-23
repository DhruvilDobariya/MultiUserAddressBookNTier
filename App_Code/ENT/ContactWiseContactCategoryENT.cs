using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactCategory
/// </summary>

namespace AddressBook.ENT
{
    public class ContactWiseContactCategoryENT : ContactWiseContactCategoryENTBase
    {
        protected UserENT _User;
        public UserENT User
        {
            get { return _User; }
            set { _User = value; }
        }

        protected ContactENT _Contact;
        public ContactENT Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }

        protected ContactCategoryENT _ContactCategory;
        public ContactCategoryENT ContactCategory
        {
            get { return _ContactCategory; }
            set { _ContactCategory = value; }
        }

        protected SqlString _SelecteOrNot;
        public SqlString SelecteOrNot
        {
            get { return _SelecteOrNot; }
            set { _SelecteOrNot = value; }
        }
    }
}
