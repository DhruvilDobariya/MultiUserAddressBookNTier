using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateBALBase
/// </summary>

namespace AddressBook.BAL
{
    public abstract class StateBALBase
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

        public bool Insert(StateENT entState)
        {
            StateDAL StateDAL = new StateDAL();
            if (StateDAL.InsertState(entState))
            {
                return true;
            }
            else
            {
                this.Message = StateDAL.Message;
                return false;
            }
        }
        #endregion Insert

        #region Select All
        public DataTable SelectAll(SqlInt32 UserId)
        {
            StateDAL StateDAL = new StateDAL();
            return StateDAL.GetStateList(UserId);
        }
        #endregion Select All

        #region Select By PK
        public StateENT SelectByPK(SqlInt32 StateId, SqlInt32 UserId)
        {
            StateDAL StateDAL = new StateDAL();
            return StateDAL.GetStateById(StateId, UserId);
        }
        #endregion Select By PK

        #region Update
        public bool Update(StateENT entState)
        {
            StateDAL StateDAL = new StateDAL();
            if (StateDAL.UpdateState(entState))
            {
                return true;
            }
            else
            {
                this.Message = StateDAL.Message;
                return false;
            }
        }
        #endregion Update

        #region Delete
        public bool Delete(SqlInt32 StateId, SqlInt32 UserId)
        {
            StateDAL StateDAL = new StateDAL();
            if (StateDAL.DeleteState(StateId, UserId))
            {
                return true;
            }
            else
            {
                this.Message = StateDAL.Message;
                return false;
            }
        }
        #endregion Delete

        #region Select for dropdown
        public DataTable SelectForDropDown(SqlInt32 UserId)
        {
            StateDAL stateDAL = new StateDAL();
            return stateDAL.GetStateDropDown(UserId, SqlInt32.Null);
        }
        #endregion Select for dropdown

        #region Select for dropdown
        public DataTable SelectForDropDownByCountryID(SqlInt32 UserId, SqlInt32 CountryId)
        {
            StateDAL stateDAL = new StateDAL();
            return stateDAL.GetStateDropDown(UserId, CountryId);
        }
        #endregion Select for dropdown
    }
}
