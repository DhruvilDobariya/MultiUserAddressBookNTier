using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactCategory
/// </summary>

namespace AddressBook.ENT
{
    public class ContactWiseContactCategoryENT : ContactWiseContactCategoryENTBase
    {
        protected ContactCategoryENT _ContactCategory;
        public ContactCategoryENT ContactCategory
        {
            get { return _ContactCategory; }
            set { _ContactCategory = value; }
        }
    }
}
