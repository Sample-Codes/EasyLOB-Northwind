using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindCustomerCustomerDemoRepositoryRedis : NorthwindGenericRepositoryRedis<CustomerCustomerDemo>
    {
        #region Methods

        public NorthwindCustomerCustomerDemoRepositoryRedis(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(CustomerCustomerDemo customerCustomerDemo)
        {
            if (customerCustomerDemo != null)
            {
                customerCustomerDemo.CustomerDemographic = UnitOfWork.GetRepository<CustomerDemographic>().GetById(customerCustomerDemo.CustomerTypeId);
                customerCustomerDemo.Customer = UnitOfWork.GetRepository<Customer>().GetById(customerCustomerDemo.CustomerId);
            }
        }

        #endregion Methods
    }
}
