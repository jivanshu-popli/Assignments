namespace flightapi.Service{
    public interface IAdmin3Serv<CustomersJivanshu>{
        void AddCustomer(CustomersJivanshu c);
        void DeleteCustomer(int id);
        List<CustomersJivanshu> GetAllCustomers();
        CustomersJivanshu GetCustomerById(int id);
        void UpdateCustomer(int id, CustomersJivanshu c);
    }
}