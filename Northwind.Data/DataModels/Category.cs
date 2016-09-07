using System;
using System.Collections.Generic;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    [ZDataDictionaryAttribute(
        associations: new string[] { },
        collections: new string[] { "Products" },
        isIdentity: true,
        keys: new string[] { "CategoryId" },
        linqOrderBy: "CategoryName",
        linqWhere: "CategoryId == @0",
        lookup: "CategoryName"
    )]    
    public partial class Category : ZDataBase
    {        
        #region Properties
        
        public virtual int CategoryId { get; set; }
        
        public virtual string CategoryName { get; set; }
        
        public virtual string Description { get; set; }
        
        public virtual byte[] Picture { get; set; }

        #endregion Properties

        #region Properties ZDataBase

        public override string LookupText
        {
            get { return base.LookupText; }
            set { }
        }

        #endregion Properties ZDataBase

        #region Collections (PK)

        public virtual IList<Product> Products { get; set; }

        #endregion Collections (PK)

        #region Methods
        
        public Category()
        {            
            CategoryId = LibraryDefaults.Default_Int32;
            CategoryName = LibraryDefaults.Default_String;
            Description = null;
            Picture = null;

            Products = new List<Product>();
        }

        public Category(int categoryId)
            : this()
        {            
            CategoryId = categoryId;
        }

        public Category(
            int categoryId,
            string categoryName,
            string description = null,
            byte[] picture = null
        )
            : this()
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
            Picture = picture;
        }

        public override object[] GetId()
        {
            return new object[] { CategoryId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                CategoryId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
