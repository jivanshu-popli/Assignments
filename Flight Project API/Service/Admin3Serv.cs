using System.Runtime.InteropServices;
using flightapi.Models;
using flightapi.Repository;

namespace flightapi.Service{
    public class Admin3Serv : IAdmin3Serv<CustomersJivanshu>
    {
        private readonly IAdmin3<CustomersJivanshu> arepo;
        public Admin3Serv(){}
        public Admin3Serv(IAdmin3<CustomersJivanshu> _arepo){
            arepo = _arepo;
        }
        public void AddCustomer(CustomersJivanshu c)
        {
            arepo.AddCustomer(c);
        }

        public void DeleteCustomer(int id)
        {
            arepo.DeleteCustomer(id);
        }

        public List<CustomersJivanshu> GetAllCustomers()
        {
            return arepo.GetAllCustomers();
        }

        public CustomersJivanshu GetCustomerById(int id)
        {
            return arepo.GetCustomerById(id);
        }

        public void UpdateCustomer(int id, CustomersJivanshu c)
        {
            arepo.UpdateCustomer(id, c);
        }
    }
}