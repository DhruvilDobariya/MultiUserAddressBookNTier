using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryENTBase
/// </summary>

namespace AddressBook.ENT
{
    public abstract class CountryENTBase
    {
        protected SqlInt32 _CountryID;
        public SqlInt32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        protected SqlString _CountryName;
        public SqlString CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }

        protected SqlString _CountryCode;
        public SqlString CountryCode
        {
            get { return _CountryCode; }
            set { _CountryCode = value; }
        }

        protected SqlDateTime _CreationDate;
        public SqlDateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }

        protected SqlInt32 _UserID;
        public SqlInt32 USerID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
    }
}