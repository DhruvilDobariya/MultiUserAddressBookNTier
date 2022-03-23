using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBALBase
/// </summary>

namespace AddressBook.BAL
{
    public abstract class UserBALBase
    {
        protected string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        #region Validate User
        public UserENT ValidateUser(SqlString UserName, SqlString Password)
        {
            UserDAL userDAL = new UserDAL();
            UserENT entUser = userDAL.ValidateUser(UserName, Password);
            if (entUser != null)
            {
                return entUser;
            }
            else
            {
                _Message = userDAL.Message;
                return null;
            }
        }
        #endregion Validate User

        #region Select By PK
        public UserENT SelectByPK(SqlInt32 UserId)
        {
            UserDAL userDAL = new UserDAL();
            UserENT entUser = userDAL.SelectByPK(UserId);
            if(entUser != null)
            {
                return entUser;
            }
            else
            {
                _Message = userDAL.Message;
                return null;
            }
        }
        #endregion Select By PK

        #region Insert
        public bool Insert(UserENT entUser)
        {
            UserDAL userDAL = new UserDAL();
            if (userDAL.Insert(entUser))
            {
                return true;
            }
            else
            {
                _Message = userDAL.Message;
                return false;
            }
        }
        #endregion Insert

        #region Update
        public bool Update(UserENT entUser)
        {
            UserDAL userDAL = new UserDAL();
            if (userDAL.Update(entUser))
            {
                return true;
            }
            else
            {
                _Message = userDAL.Message;
                return false;
            }
        }
        #endregion Update

        #region Delete
        public bool Delete(SqlInt32 UserId)
        {
            UserDAL userDAL = new UserDAL();
            if (userDAL.Delete(UserId))
            {
                return true;
            }
            else
            {
                _Message = userDAL.Message;
                return false;
            }
        }
        #endregion Delete
    }
}
