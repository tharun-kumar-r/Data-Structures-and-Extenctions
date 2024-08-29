using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public class Account
    {
        public int AccountId { get; private set; }
        public decimal AccountBalance { get; private set; }
        private readonly object balanceLock = new object(); 

        
        public Account(int accountId, decimal initialBalance)
        {
            AccountId = accountId;
            AccountBalance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            lock (balanceLock)
            {
                if (amount > 0)
                {
                    AccountBalance += amount;
                    Console.WriteLine($"Deposited {amount} into Account {AccountId}. New Balance: {AccountBalance}");
                }
                else
                {
                    Console.WriteLine("Deposit amount must be positive.");
                }
            }
        }



        public bool Withdraw(decimal amount)
        {
            lock (balanceLock)
            {
                if (amount > 0 && AccountBalance >= amount)
                {
                    AccountBalance -= amount;
                    Console.WriteLine($"Withdrew {amount} from Account {AccountId}. New Balance: {AccountBalance}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Insufficient balance or invalid amount in Account {AccountId}.");
                    return false;
                }
            }
        }


        public class AccountManager
        {
            public void Transfer(Account fromAccount, Account toAccount, decimal amount)
            {
                
                lock (fromAccount)
                {
                    if (fromAccount.Withdraw(amount))
                    {
                        lock (toAccount)
                        {
                            toAccount.Deposit(amount);
                            Console.WriteLine($"Transferred {amount} from Account {fromAccount.AccountId} to Account {toAccount.AccountId}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Transfer failed due to insufficient funds.");
                    }
                }
            }
        }

    }
}
