using System;
using System.Collections.Generic;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    [ZDataDictionaryAttribute(
        associations: new string[] { },
        collections: new string[] { "CustomerCustomerDemos", "Orders" },
        isIdentity: false,
        keys: new string[] { "CustomerId" },
        linqOrderBy: "CompanyName",
        linqWhere: "CustomerId == @0",
        lookup: "CompanyName"
    )]    
    public partial class Customer : ZDataBase
    {        
        #region Properties
        
        public virtual string CustomerId { get; set; }
        
        public virtual string CompanyName { get; set; }
        
        public virtual string ContactName { get; set; }
        
        public virtual string ContactTitle { get; set; }
        
        public virtual string Address { get; set; }
        
        public virtual string City { get; set; }
        
        public virtual string Region { get; set; }
        
        public virtual string PostalCode { get; set; }
        
        public virtual string Country { get; set; }
        
        public virtual string Phone { get; set; }
        
        public virtual string Fax { get; set; }

        #endregion Properties

        #region Properties ZDataBase

        public override string LookupText
        {
            get { return base.LookupText; }
            set { }
        }

        #endregion Properties ZDataBase

        #region Collections (PK)

        public virtual IList<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }

        public virtual IList<Order> Orders { get; set; }

        #endregion Collections (PK)

        #region Methods
        
        public Customer()
        {            
            CustomerId = LibraryDefaults.Default_String;
            CompanyName = LibraryDefaults.Default_String;
            ContactName = null;
            ContactTitle = null;
            Address = null;
            City = null;
            Region = null;
            PostalCode = null;
            Country = null;
            Phone = null;
            Fax = null;

            CustomerCustomerDemos = new List<CustomerCustomerDemo>();
            Orders = new List<Order>();
        }

        public Customer(string customerId)
            : this()
        {            
            CustomerId = customerId;
        }

        public Customer(
            string customerId,
            string companyName,
            string contactName = null,
            string contactTitle = null,
            string address = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string country = null,
            string phone = null,
            string fax = null
        )
            : this()
        {
            CustomerId = customerId;
            CompanyName = companyName;
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Fax = fax;
        }

        public override object[] GetId()
        {
            return new object[] { CustomerId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                CustomerId = DataHelper.IdToString(ids[0]);
            }
        }

        #endregion Methods
    }
}
