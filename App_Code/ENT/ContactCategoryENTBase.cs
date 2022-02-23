using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ContactCategoryENTBase
/// </summary>

namespace AddressBook.ENT
{
    public class ContactCategoryENTBase
    {
        protected SqlInt32 _ContactCategoryID;
        public SqlInt32 ContactCategoryID
        {
            get { return _ContactCategoryID; }
            set { _ContactCategoryID = value; }
        }

        protected SqlString _ContactCategoryName;
        public SqlString ContactCategoryName
        {
            get { return _ContactCategoryName; }
            set { _ContactCategoryName = value; }
        }

        protected SqlDateTime _CreationDate;
        public SqlDateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }

        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
    }
}