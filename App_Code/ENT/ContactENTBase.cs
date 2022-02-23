using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactENTBase
/// </summary>

namespace AddressBook.ENT
{
    public class ContactENTBase
    {
        protected SqlInt32 _ContactID;
        public SqlInt32 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        protected SqlString _ContactName;
        public SqlString ContactName
        {
            get { return _ContactName; }
            set { _ContactName = value; }
        }

        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }

        protected SqlInt32 _StateID;
        public SqlInt32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        protected SqlInt32 _CountryID;
        public SqlInt32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        protected SqlString _ContactNo;
        public SqlString ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }

        protected SqlString _WhatsappNo;
        public SqlString WhatsappNo
        {
            get { return _WhatsappNo; }
            set { _WhatsappNo = value; }
        }

        protected SqlDateTime _BirthDate;
        public SqlDateTime BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }

        protected SqlString _Email;
        public SqlString Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        protected SqlInt32 _Age;
        public SqlInt32 Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        protected SqlString _BloodGroup;
        public SqlString BloodGroup
        {
            get { return _BloodGroup; }
            set { _BloodGroup = value; }
        }

        protected SqlString _FacebookID;
        public SqlString FacebookID
        {
            get { return _FacebookID; }
            set { _FacebookID = value; }
        }

        protected SqlString _LinkedinID;
        public SqlString LinkedinID
        {
            get { return _LinkedinID; }
            set { _LinkedinID = value; }
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

        protected SqlString _FilePath;
        public SqlString FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }

        protected SqlString _FileSize;
        public SqlString FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }

        protected SqlString _FileType;
        public SqlString FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }
    }
}