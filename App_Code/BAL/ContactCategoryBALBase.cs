using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for ContactCategoryBALBase
/// </summary>

namespace AddressBook.BAL
{
    public abstract class ContactCategoryBALBase
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

        public bool Insert(ContactCategoryENT entContactCategory)
        {
            ContactCategoryDAL ContactCategoryDAL = new ContactCategoryDAL();
            if (ContactCategoryDAL.InsertContactCategory(entContactCategory))
            {
                return true;
            }
            else
            {
                this.Message = ContactCategoryDAL.Message;
                return false;
            }
        }
        #endregion Insert

        #region Select All
        public DataTable SelectAll(SqlInt32 UserId)
        {
            ContactCategoryDAL ContactCategoryDAL = new ContactCategoryDAL();
            return ContactCategoryDAL.GetContactCategoryList(UserId);
        }
        #endregion Select All

        #region Select By PK
        public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryId, SqlInt32 UserId)
        {
            ContactCategoryDAL ContactCategoryDAL = new ContactCategoryDAL();
            return ContactCategoryDAL.GetContactCategoryById(ContactCategoryId, UserId);
        }
        #endregion Select By PK

        #region Update
        public bool Update(ContactCategoryENT entContactCategory)
        {
            ContactCategoryDAL ContactCategoryDAL = new ContactCategoryDAL();
            if (ContactCategoryDAL.UpdateContactCategory(entContactCategory))
            {
                return true;
            }
            else
            {
                this.Message = ContactCategoryDAL.Message;
                return false;
            }
        }
        #endregion Update

        #region Delete
        public bool Delete(SqlInt32 ContactCategoryId, SqlInt32 UserId)
        {
            ContactCategoryDAL ContactCategoryDAL = new ContactCategoryDAL();
            if (ContactCategoryDAL.DeleteContactCategory(ContactCategoryId, UserId))
            {
                return true;
            }
            else
            {
                this.Message = ContactCategoryDAL.Message;
                return false;
            }
        }
        #endregion Delete

        #region Select For DropDown
        public DataTable SelectForDropDown(SqlInt32 UserId)
        {
            ContactCategoryDAL ContactCategoryDAL = new ContactCategoryDAL();
            return ContactCategoryDAL.GetContactCategoryDropDown(UserId);
        }
        #endregion Select For DropDown
    }
}
