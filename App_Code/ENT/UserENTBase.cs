using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserENTBase
/// </summary>

namespace AddressBook.ENT
{
    public abstract class UserENTBase
    {
        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        protected SqlString _UserName;
        public SqlString UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        protected SqlString _Password;
        public SqlString Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        protected SqlString _DisplayName;
        public SqlString DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        protected SqlString _Address;
        public SqlString Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        protected SqlString _MobileNo;
        public SqlString MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }

        protected SqlString _Email;
        public SqlString Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        protected SqlDateTime _CreationDate;
        public SqlDateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }
    }
}
