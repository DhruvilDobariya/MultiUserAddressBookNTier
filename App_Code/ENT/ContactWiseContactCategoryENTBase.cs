using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactCategoryENTBase
/// </summary>

namespace AddressBook.ENT
{
    public class ContactWiseContactCategoryENTBase
    {
        protected SqlInt32 _ContactWiseContactCategoryID;
        public SqlInt32 ContactWiseContactCategoryID
        {
            get { return _ContactWiseContactCategoryID; }
            set { _ContactWiseContactCategoryID = value; }
        }

        protected SqlInt32 _ContactID;
        public SqlInt32 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        protected SqlInt32 _ContactCategoryID;
        public SqlInt32 ContactCategoryID
        {
            get { return _ContactCategoryID; }
            set { _ContactCategoryID = value; }
        }

        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
    }
}
