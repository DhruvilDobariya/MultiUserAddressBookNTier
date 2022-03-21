using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryBALBase
/// </summary>

namespace AddressBook.BAL
{
    public abstract class CountryBALBase
    {
        #region Local Variable
        protected string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variable

        #region Insert

        public bool Insert(CountryENT entCountry)
        {
            CountryDAL countryDAL = new CountryDAL();
            if (countryDAL.InsertCountry(entCountry))
            {
                return true;
            }
            else
            {
                this.Message = countryDAL.Message;
                return false;
            }
        }
        #endregion Insert

        #region Select All
        public DataTable SelectAll(SqlInt32 UserId)
        {
            CountryDAL countryDAL = new CountryDAL();
            return countryDAL.GetCountryList(UserId);
        }
        #endregion Select All

        #region Select By PK
        public CountryENT SelectByPK(SqlInt32 CountryId, SqlInt32 UserId)
        {
            CountryDAL countryDAL = new CountryDAL();
            return countryDAL.GetCountryById(CountryId, UserId);
        }
        #endregion Select By PK

        #region Update
        public bool Update(CountryENT entCountry)
        {
            CountryDAL countryDAL = new CountryDAL();
            if (countryDAL.UpdateCountry(entCountry))
            {
                return true;
            }
            else
            {
                this.Message = countryDAL.Message;
                return false;
            }
        }
        #endregion Update

        #region Delete
        public bool Delete(SqlInt32 CountryId, SqlInt32 UserId)
        {
            CountryDAL countryDAL = new CountryDAL();
            if (countryDAL.DeleteCountry(CountryId, UserId))
            {
                return true;
            }
            else
            {
                this.Message = countryDAL.Message;
                return false;
            }
        }
        #endregion Delete

        #region Select For DropDown
        public DataTable SelectForDropDown(SqlInt32 UserId)
        {
            CountryDAL countryDAL = new CountryDAL();
            return countryDAL.GetCountryDropDown(UserId);
        }
        #endregion Select For DropDown
    }
}
