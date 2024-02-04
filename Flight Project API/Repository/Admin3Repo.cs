using flightapi.Models;
namespace flightapi.Repository{
    public class Admin3Repo : IAdmin3<CustomersJivanshu>
    {

        private readonly Ace52024Context db;
        public Admin3Repo(){}
        public Admin3Repo(Ace52024Context _db){
            db = _db;
        }
        public void AddCustomer(CustomersJivanshu c)
        {
            db.CustomersJivanshus.Add(c);
            db.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            CustomersJivanshu d = db.CustomersJivanshus.Find(id);
            db.CustomersJivanshus.Remove(d);
            db.SaveChanges();
        }

        public List<CustomersJivanshu> GetAllCustomers()
        {
            List<CustomersJivanshu> c = db.CustomersJivanshus.ToList();
            return c;
        }

        public CustomersJivanshu GetCustomerById(int id)
        {
            return db.CustomersJivanshus.Find(id);
        }

        public void UpdateCustomer(int id, CustomersJivanshu c)
        {
           db.CustomersJivanshus.Update(c);
           db.SaveChanges(); 
        }
    }
}