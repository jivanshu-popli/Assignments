using System;

namespace I{
    class Employee:IEmployee{
        public int Empid{get; set;}
        public string Empname{get; set;}
        public float Salary{get; set;}
        public DateTime Doj{get; set;}

        public virtual void AcceptDetails(){
            Console.WriteLine("Enter EMPID");
            Empid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EMPNAME");
            Empname = Console.ReadLine();
            Console.WriteLine("Enter DOJ");
            Doj = Convert.ToDateTime(Console.ReadLine());
        }

        public virtual void DisplayDetails(){
            Console.WriteLine("EMPID is: "+Empid);
            Console.WriteLine("Empname is: "+Empname);
            Console.WriteLine("Salary is: "+Salary);
            Console.WriteLine("Doj is: {0}", Doj.ToShortDateString());
        }
        public virtual void CalculateSalary(){
            Salary = 15000F;
        }
    }

    class Permenant:Employee{
        public float Basicpay{get; set;}
        public float Hra{get; set;}
        public float Da{get; set;}
        public float Pf{get; set;}

        public override void AcceptDetails(){
            base.AcceptDetails();
            Console.WriteLine("Enter Basic Pay");
            Basicpay = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter HRA");
            Hra = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter DA");
            Da = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter PF");
            Pf = float.Parse(Console.ReadLine());
        }
        
        public override void CalculateSalary(){
            Salary = Basicpay + Hra + Da - Pf;
        }

        public override void DisplayDetails(){
            base.DisplayDetails();
            Console.WriteLine("Basic Pay is: "+Basicpay);
            Console.WriteLine("HRA is: "+Hra);
            Console.WriteLine("DA is: "+Da);
            Console.WriteLine("PF is: "+Pf);
            Console.WriteLine("Salary is: "+Salary);
        }

    }

    class Trainee:Employee{
        public float Basicpay{get; set;}
        public float Bonus{get; set;}
        public string Projectname{get; set;}

        public override void AcceptDetails(){
            base.AcceptDetails();
            Console.WriteLine("Enter Basic Pay");
            Basicpay = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Project Name");
            Projectname = Console.ReadLine();
        }
       
        public override void CalculateSalary(){
            if(Projectname == "Banking"){
                Bonus = 0.05F * Basicpay;   
                Salary = Basicpay + Bonus;
            }
            else if(Projectname == "Insurance"){
                Bonus = 0.1F * Basicpay;
                Salary = Basicpay + Bonus;
            }
        }
        public override void DisplayDetails(){
            base.DisplayDetails();
            Console.WriteLine("Basic Pay is: "+Basicpay);
            Console.WriteLine("Bonus is: "+Bonus);
            Console.WriteLine("Project name is: "+Projectname);
            Console.WriteLine("Salary is: "+Salary);
        }
        
    }



}