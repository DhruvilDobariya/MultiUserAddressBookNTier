using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactENT
/// </summary>

namespace AddressBook.ENT
{
    public class ContactENT : ContactENTBase
    {
        protected UserENT _User; 
        public UserENT User
        {
            get{ return _User; }
            set{ _User = value; }
        }

        protected CountryENT _Country;
        public CountryENT Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        protected StateENT _State; 
        public StateENT State
        {
            get { return _State; }
            set { _State = value; }
        }

        protected CityENT _City;
        public CityENT City
        {
            get { return _City; }
            set { _City = value; }
        }

        protected ICollection<ContactWiseContactCategoryENT> _ContactWiseContactCategories;
        public ICollection<ContactWiseContactCategoryENT> ContactWiseContactCategories
        {
            get { return _ContactWiseContactCategories; }
            set { _ContactWiseContactCategories = value; }
        }
    }
}