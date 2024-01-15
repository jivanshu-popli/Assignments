namespace oopseg{
    class EmployeeClient{

        public static void Main(){
            Employee e1 = new Permenant();
            Employee e2 = new Trainee();
            Console.WriteLine("Enter details of Permenant Employee: ");
            e1.AcceptDetails();
            e1.CalculateSalary();
            Console.WriteLine("Permenant Employee details: ");
            e1.DisplayDetails();
            Console.WriteLine("Enter details of Trainee: ");
            e2.AcceptDetails();
            e2.CalculateSalary();
            Console.WriteLine("Trainee details: ");
            e2.DisplayDetails();
        }

    }
}