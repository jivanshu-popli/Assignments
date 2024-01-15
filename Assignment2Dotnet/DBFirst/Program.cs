using System.Timers;
using dbfirstbank.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Bank{
    class Bank{
        private static Ace52024Context bank = new Ace52024Context();
        public static int Tid = 0;
        public static void Main(){
            Console.WriteLine("Enter how many accounts you want to add: ");
            int x = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<x;i++){
                AddAccount();
            }
            DepositAmount(1, 2000);
            DepositAmount(2, 3000);
            WithdrawAmount(3, 4000);
            DepositAmount(1, 6000);
            WithdrawAmount(1, 5000);
            GetAccountDetails(2);
            GetAllAccounts();
            GetTransactions(1);
        }

        public static void AddAccount(){
            SbaccountJivanshu j = new SbaccountJivanshu();
            Console.WriteLine("Enter Account Number, Customer Name, Customer Address, Current Balance: ");
            j.Accountnumber = Convert.ToInt32(Console.ReadLine());
            j.Customername = Console.ReadLine();
            j.Customeraddress = Console.ReadLine();
            j.Currentbalance = decimal.Parse(Console.ReadLine());
            bank.SbaccountJivanshus.Add(j);
            bank.SaveChanges();
            Console.WriteLine("Account Added");
        }

        public static void DepositAmount(int accno, decimal amt){
            SbaccountJivanshu j = new SbaccountJivanshu();
            foreach(var i in bank.SbaccountJivanshus){
                if(i.Accountnumber == accno){
                    j = i;
                    i.Currentbalance += amt;
                }
            }
            Tid++;
            SbtransactionsJivanshu t = new SbtransactionsJivanshu();
            t.Transactionsid = Tid;
            t.Transactiondate = DateTime.Now;
            t.Accountnumber = accno;
            t.Amount = amt;
            t.Transactiontype = "Deposit";
            bank.SbtransactionsJivanshus.Add(t);
            bank.SaveChanges();
        }
        public static void WithdrawAmount(int accno, decimal amt){
            SbaccountJivanshu j = new SbaccountJivanshu();
            foreach(var i in bank.SbaccountJivanshus){
                if(i.Accountnumber == accno){  
                    i.Currentbalance -= amt;
                    j = i;
                }
            }
            Tid++;
            SbtransactionsJivanshu t = new SbtransactionsJivanshu();
            t.Transactionsid = Tid;
            t.Transactiondate = DateTime.Now;
            t.Accountnumber = accno;
            t.Amount = amt;
            t.Transactiontype = "Deposit";
            bank.SbtransactionsJivanshus.Add(t);
            bank.SaveChanges();
        }
        public static void GetAccountDetails(int accno){
            SbaccountJivanshu j = new SbaccountJivanshu();
            foreach(var i in bank.SbaccountJivanshus){
                if(i.Accountnumber == accno){  
                    j = i;
                }
            }
            Console.WriteLine($"Account details with {accno} Account Number: ");
            Console.WriteLine(j.Accountnumber + " " + j.Customername + " " + j.Customeraddress + " " + j.Currentbalance);
        }
        public static void GetAllAccounts(){
            Console.WriteLine("All Accounts: ");
            foreach(var j in bank.SbaccountJivanshus){
                Console.WriteLine(j.Accountnumber + " " + j.Customername + " " + j.Customeraddress + " " + j.Currentbalance);
            }
        }
        public static void GetTransactions(int accno){
            Console.WriteLine($"All transactions of {accno}: ");
            foreach(var j in bank.SbtransactionsJivanshus){
                if(j.Accountnumber == accno)
                    Console.WriteLine(j.Transactionsid + " " + j.Transactiondate + " " + j.Accountnumber + " " + j.Amount + " " + j.Transactiontype);
            }
        }

    }
}
