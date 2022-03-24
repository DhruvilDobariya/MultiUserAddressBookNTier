using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactBALBase
/// </summary>

namespace AddressBook.BAL
{
    public abstract class ContactBALBase
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

        public SqlInt32 Insert(ContactENT entContact)
        {
            ContactDAL ContactDAL = new ContactDAL();
            SqlInt32 ContactId = ContactDAL.InsertContact(entContact);
            if (ContactId > 0)
            {
                return ContactId;
            }
            else
            {
                this.Message = ContactDAL.Message;
                return 0;
            }
        }
        #endregion Insert

        #region Select All
        public DataTable SelectAll(SqlInt32 UserId)
        {
            ContactDAL ContactDAL = new ContactDAL();
            return ContactDAL.GetContactList(UserId);
        }
        #endregion Select All

        #region Select By PK
        public ContactENT SelectByPK(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactDAL ContactDAL = new ContactDAL();
            return ContactDAL.GetContactById(ContactId, UserId);
        }
        #endregion Select By PK

        #region Update
        public bool Update(ContactENT entContact)
        {
            ContactDAL ContactDAL = new ContactDAL();
            if (ContactDAL.UpdateContact(entContact))
            {
                return true;
            }
            else
            {
                this.Message = ContactDAL.Message;
                return false;
            }
        }
        #endregion Update

        #region Delete
        public bool Delete(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactDAL ContactDAL = new ContactDAL();
            if (ContactDAL.DeleteContact(ContactId, UserId))
            {
                return true;
            }
            else
            {
                this.Message = ContactDAL.Message;
                return false;
            }
        }
        #endregion Delete

        #region Upload Image
        public bool UploadImage(SqlInt32 ContactId, SqlInt32 UserId, SqlString FilePath, SqlString FileType, SqlString FileSize)
        {
            ContactDAL contactDAL = new ContactDAL();
            if(contactDAL.UploadImage(ContactId, UserId, FilePath, FileType, FileSize))
            {
                return true;
            }
            else
            {
                this.Message = contactDAL.Message;
                return false;
            }
        }
        #endregion Upload Image

        #region Delete Image
        public bool DeleteImage(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactDAL contactDAL = new ContactDAL();
            if(contactDAL.DeleteContact(ContactId, UserId))
            {
                return true;
            }
            else
            {
                this.Message = contactDAL.Message;
                return false;
            }
        }
        #endregion Delete Image
    }
}
