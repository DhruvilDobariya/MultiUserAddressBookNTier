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

        public DataTable SelectAll(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactWiseContactCategoryDAL ContactWiseContactCategoryDAL = new ContactWiseContactCategoryDAL();
            DataTable dt = ContactWiseContactCategoryDAL.GetContactWiseContactCategories(ContactId, UserId);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                this.Message = ContactWiseContactCategoryDAL.Message;
                return null;
            }
        }
        #endregion Insert

        #region Insert

        public bool Insert(List<ContactWiseContactCategoryENT> contactWiseContactCategories)
        {
            ContactWiseContactCategoryDAL ContactWiseContactCategoryDAL = new ContactWiseContactCategoryDAL();
            if (ContactWiseContactCategoryDAL.InsertContactWiseContactCategory(contactWiseContactCategories))
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
        public ContactWiseContactCategoryENT SelectByPK(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactWiseContactCategoryDAL ContactWiseContactCategoryDAL = new ContactWiseContactCategoryDAL();
            return ContactWiseContactCategoryDAL.GetContactWiseContactCategoryById(ContactId, UserId);
        }
        #endregion Select By PK

        #region Delete By ContactId
        public bool DeleteByCountryID(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactWiseContactCategoryDAL ContactWiseContactCategoryDAL = new ContactWiseContactCategoryDAL();
            if (ContactWiseContactCategoryDAL.DeleteContactWiseContactCategory(ContactId, UserId))
            {
                return true;
            }
            else
            {
                this.Message = ContactWiseContactCategoryDAL.Message;
                return false;
            }
        }
        #endregion Delete By ContactId

        #region Delete By PK
        public bool DeleteByPK(SqlInt32 ContactWiseContactCategoryID, SqlInt32 UserId)
        {
            ContactWiseContactCategoryDAL ContactWiseContactCategoryDAL = new ContactWiseContactCategoryDAL();
            if (ContactWiseContactCategoryDAL.DeleteContactWiseContactCategory(ContactWiseContactCategoryID, UserId))
            {
                return true;
            }
            else
            {
                this.Message = ContactWiseContactCategoryDAL.Message;
                return false;
            }
        }
        #endregion Delete By PK

        #region SelectOrNot
        public List<ContactWiseContactCategoryENT> SelectOrNot(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactWiseContactCategoryDAL contactWiseContactCategoryDAL= new ContactWiseContactCategoryDAL();
            List<ContactWiseContactCategoryENT> contactWiseContactCategories = contactWiseContactCategoryDAL.SelectOrNot(ContactId, UserId);

            if(contactWiseContactCategories != null)
            {
                return contactWiseContactCategories;
            }
            else
            {
                _Message = Message;
                return null;
            }
        }
        #endregion SelectOrNot
    }
}
