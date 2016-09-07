using System;
using System.Collections.Generic;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    [ZDataDictionaryAttribute(
        associations: new string[] { },
        collections: new string[] { "CustomerCustomerDemos" },
        isIdentity: false,
        keys: new string[] { "CustomerTypeId" },
        linqOrderBy: "CustomerDesc",
        linqWhere: "CustomerTypeId == @0",
        lookup: "CustomerDesc"
    )]    
    public partial class CustomerDemographic : ZDataBase
    {        
        #region Properties
        
        public virtual string CustomerTypeId { get; set; }
        
        public virtual string CustomerDesc { get; set; }

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

        #endregion Collections (PK)

        #region Methods
        
        public CustomerDemographic()
        {            
            CustomerTypeId = LibraryDefaults.Default_String;
            CustomerDesc = null;

            CustomerCustomerDemos = new List<CustomerCustomerDemo>();
        }

        public CustomerDemographic(string customerTypeId)
            : this()
        {            
            CustomerTypeId = customerTypeId;
        }

        public CustomerDemographic(
            string customerTypeId,
            string customerDesc = null
        )
            : this()
        {
            CustomerTypeId = customerTypeId;
            CustomerDesc = customerDesc;
        }

        public override object[] GetId()
        {
            return new object[] { CustomerTypeId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                CustomerTypeId = DataHelper.IdToString(ids[0]);
            }
        }

        #endregion Methods
    }
}
