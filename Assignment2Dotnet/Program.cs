using System.Collections;
namespace Bank{
    public class SBAccount{
        public int Accountnumber{get; set;}
        public string Customername{get; set;}
        public string Customeraddress{get; set;}
        public decimal Currentbalance{get; set;}

        public SBAccount(int accountNumber, string customerName, string customerAddress, decimal currentBalance){
            Accountnumber = accountNumber;
            Customername = customerName;
            Customeraddress = customerAddress;
            Currentbalance = currentBalance;
        }

    }

    public class SBTransaction{
        public int Transactionid{get; set;}
        public DateTime Transactiondate{get; set;}
        public int Accountnumber{get; set;}
        public decimal Amount{get; set;}
        public string Transactiontype{get; set;}

        public SBTransaction(int transactionId, DateTime transactionDate, int accountNumber, decimal amount, string transactionType){
            Transactionid = transactionId;
            Transactiondate = transactionDate;
            Accountnumber = accountNumber;
            Amount = amount;
            Transactiontype = transactionType;
        }

    }


}