using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityBALBase
/// </summary>

namespace AddressBook.BAL
{
    public abstract class CityBALBase
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

        public bool Insert(CityENT entCity)
        {
            CityDAL CityDAL = new CityDAL();
            if (CityDAL.InsertCity(entCity))
            {
                return true;
            }
            else
            {
                this.Message = CityDAL.Message;
                return false;
            }
        }
        #endregion Insert

        #region Select All
        public DataTable SelectAll(SqlInt32 UserId)
        {
            CityDAL CityDAL = new CityDAL();
            return CityDAL.GetCityList(UserId);
        }
        #endregion Select All

        #region Select By PK
        public CityENT SelectByPK(SqlInt32 CityId, SqlInt32 UserId)
        {
            CityDAL CityDAL = new CityDAL();
            return CityDAL.GetCityById(CityId, UserId);
        }
        #endregion Select By PK

        #region Update
        public bool Update(CityENT entCity)
        {
            CityDAL CityDAL = new CityDAL();
            if (CityDAL.UpdateCity(entCity))
            {
                return true;
            }
            else
            {
                this.Message = CityDAL.Message;
                return false;
            }
        }
        #endregion Update

        #region Delete
        public bool Delete(SqlInt32 CityId, SqlInt32 UserId)
        {
            CityDAL CityDAL = new CityDAL();
            if (CityDAL.DeleteCity(CityId, UserId))
            {
                return true;
            }
            else
            {
                this.Message = CityDAL.Message;
                return false;
            }
        }
        #endregion Delete

        #region Select for dropdown
        public DataTable SelectForDropDown(SqlInt32 UserId)
        {
            CityDAL CityDAL = new CityDAL();
            return CityDAL.GetCityDropDown(UserId, SqlInt32.Null);
        }
        #endregion Select for dropdown

        #region Select for dropdown
        public DataTable SelectForDropDownByStateID(SqlInt32 UserId, SqlInt32 StateId)
        {
            CityDAL CityDAL = new CityDAL();
            return CityDAL.GetCityDropDown(UserId, StateId);
        }
        #endregion Select for dropdown
    }
}
