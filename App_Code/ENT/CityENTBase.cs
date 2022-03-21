using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityENTBase
/// </summary>

namespace AddressBook.ENT
{
    public class CityENTBase
    {
        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }

        protected SqlString _CityName;
        public SqlString CityName 
        { 
            get { return _CityName; }
            set { _CityName = value; }
        }

        protected SqlString _PinCode;
        public SqlString PinCode
        {
            get { return _PinCode; }
            set { _PinCode = value; }
        }

        protected SqlString _STDCode;
        public SqlString STDCode
        {
            get { return _STDCode; }
            set { _STDCode = value; }
        }

        protected SqlInt32 _StateID;
        public SqlInt32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
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