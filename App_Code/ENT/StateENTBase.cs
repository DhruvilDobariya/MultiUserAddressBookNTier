using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateENTBase
/// </summary>

namespace AddressBook.ENT
{
    public abstract class StateENTBase
    {
        protected SqlInt32 _StateID;
        public SqlInt32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        protected SqlString _StateName;
        public SqlString StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }

        protected SqlString _StateCode;
        public SqlString StateCode
        {
            get { return _StateCode; }
            set { _StateCode = value; }
        }

        protected SqlInt32 _CountryID;
        public SqlInt32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
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