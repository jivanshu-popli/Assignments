using flightapi.Models;
namespace flightapi.Repository{
    public interface IAdmin3<CustomersJivanshu>{
        void AddCustomer(CustomersJivanshu c);
        void DeleteCustomer(int id);
        List<CustomersJivanshu> GetAllCustomers();
        CustomersJivanshu GetCustomerById(int id);
        void UpdateCustomer(int id, CustomersJivanshu c);
    }
}