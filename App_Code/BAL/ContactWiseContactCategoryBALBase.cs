using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactCategoryBALBase
/// </summary>

namespace AddressBook.BAL
{
    public abstract class ContactWiseContactCategoryBALBase
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

        public bool Insert(ContactWiseContactCategoryENT entContactWiseContactCategory)
        {
            ContactWiseContactCategoryDAL ContactWiseContactCategoryDAL = new ContactWiseContactCategoryDAL();
            if (ContactWiseContactCategoryDAL.InsertContactWiseContactCategory(entContactWiseContactCategory))
            {
                return true;
            }
            else
            {
                this.Message = ContactWiseContactCategoryDAL.Message;
                return false;
            }
        }
        #endregion Insert

        #region Select By PK
        public DataTable SelectByPK(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactWiseContactCategoryDAL ContactWiseContactCategoryDAL = new ContactWiseContactCategoryDAL();
            return ContactWiseContactCategoryDAL.GetContactWiseContactCategoryById(ContactId, UserId);
        }
        #endregion Select By PK

        #region Delete
        public bool Delete(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactWiseContactCategoryDAL ContactWiseContactCategoryDAL = new ContactWiseContactCategoryDAL();
            if (ContactWiseContactCategoryDAL.DeleteContactWiseContactCategory(ContactId, UserId))
            {
                return true;
            }
            else
            {
                this.Message = ContactWiseContactCategoryDAL.Message;
                return true;
            }
        }
        #endregion Delete
    }
}
