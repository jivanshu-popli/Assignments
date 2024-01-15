using System.Collections;
namespace Bank{

    public class BankClient{
        public static void Main(){
            
            IBankRepository bank = new BankRepository();
            
            SBAccount aa = new SBAccount(1, "a", "delhi", 25000m);
            SBAccount bb = new SBAccount(2, "b", "mumbai", 20000m);
            SBAccount cc = new SBAccount(3, "c", "jammu", 15000m);

            bank.NewAccount(aa);
            bank.NewAccount(bb);
            bank.NewAccount(cc);

            bank.DepositAmount(1, 1000m);
            Console.WriteLine("Enter account number to withdraw money from: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter amount to withdraw: "); 
            decimal y = decimal.Parse(Console.ReadLine());
            try{
                bank.WithdrawAmount(x, y);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            bank.DepositAmount(1, 9000m);
            bank.DepositAmount(1, 3000m);
            Console.WriteLine("Enter account number to withdraw money from: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter amount to withdraw: "); 
            y = decimal.Parse(Console.ReadLine());
            try{
                bank.WithdrawAmount(x, y);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Type the account number you want the details for: ");
            int acc = Convert.ToInt32(Console.ReadLine());
            SBAccount account = null;
            try{
                account = bank.GetAccountDetails(acc);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                if(account != null)
                    Console.WriteLine(account.Customername + " " + account.Customeraddress + " " + account.Currentbalance);
            }
            
            Console.WriteLine();

            List<SBAccount> accounts = bank.GetAllAccounts();
            Console.WriteLine("All accounts details: ");
            foreach(SBAccount i in accounts){
                Console.WriteLine(i.Accountnumber + " " + i.Currentbalance + " " + i.Customeraddress + " " + i.Currentbalance);
            }

            Console.WriteLine();

            Console.WriteLine("Enter account number for which you want all the transaction details: ");
            x = Convert.ToInt32(Console.ReadLine());
            List<SBTransaction> transactions = null;
            try{
                transactions = bank.GetTransactions(x);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                if(transactions != null){
                    Console.WriteLine($"All transaction details of AccountNumber {x}: ");
                    foreach(SBTransaction i in transactions){
                        Console.WriteLine(i.Transactionid + " " + i.Transactiondate + " " + i.Accountnumber + " " + i.Amount + " " + i.Transactiontype);
                    }
                }
            }

        }
    } 
    
}