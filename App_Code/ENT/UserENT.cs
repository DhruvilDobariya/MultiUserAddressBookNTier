using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserENT
/// </summary>
namespace AddressBook.ENT
{
    public class UserENT : UserENTBase
    {
        protected ICollection<CountryENT> _Countries;
        public ICollection<CountryENT> Countries
        {
            get { return _Countries; }
            set { _Countries = value; }
        }

        protected ICollection<StateENT> _States;
        public ICollection<StateENT> States
        {
            get { return _States; }
            set { _States = value; }
        }

        protected ICollection<CityENT> _Cities;
        public ICollection<CityENT> Cities
        {
            get { return _Cities; }
            set { _Cities = value; }
        }

        protected ICollection<ContactCategoryENT> _ContactCategories;
        public ICollection<ContactCategoryENT> ContactCategories
        {
            get { return _ContactCategories; }
            set { _ContactCategories = value; }
        }

        protected ICollection<ContactWiseContactCategoryENT> _ContactWiseContactCategories;
        public ICollection<ContactWiseContactCategoryENT> ContactWiseContactCategories
        {
            get { return _ContactWiseContactCategories; }
            set { _ContactWiseContactCategories = value; }
        }

        protected ICollection<ContactENT> _Contact;
        public ICollection<ContactENT> Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }
    }
}
