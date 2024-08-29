using System;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Account
    {
        public int AccountId { get; private set; }
        public decimal AccountBalance { get; private set; }
        private readonly object _lock = new object();

        public Account(int accountId, decimal initialBalance)
        {
            AccountId = accountId;
            AccountBalance = initialBalance;
        }

        public Task DepositAsync(decimal amount)
        {
            return Task.Run(() =>
            {
                if (amount > 0)
                {
                    lock (_lock)
                    {
                        AccountBalance += amount;
                        Console.WriteLine($"Deposited {amount} into Account {AccountId}. New Balance: {AccountBalance}");
                    }
                }
                else
                {
                    Console.WriteLine("Deposit amount must be positive.");
                }
            });
        }

        public Task<bool> WithdrawAsync(decimal amount)
        {
            return Task.Run(() =>
            {
                lock (_lock)
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
            });
        }
    }

    public class AccountManager
    {
        public async Task TransferAsync(Account fromAccount, Account toAccount, decimal amount)
        {
            if (await fromAccount.WithdrawAsync(amount))
            {
                await toAccount.DepositAsync(amount);
                Console.WriteLine($"Transferred {amount} from Account {fromAccount.AccountId} to Account {toAccount.AccountId}");
            }
            else
            {
                Console.WriteLine("Transfer failed due to insufficient funds.");
            }
        }
    }

    class AssyncClass
    {
        static async Task Main(string[] args)
        {
            Account account1 = new Account(1, 1000m);
            Account account2 = new Account(2, 500m);
            AccountManager accountManager = new AccountManager();

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Deposit into Account 1");
                Console.WriteLine("2. Withdraw from Account 1");
                Console.WriteLine("3. Deposit into Account 2");
                Console.WriteLine("4. Withdraw from Account 2");
                Console.WriteLine("5. Transfer from Account 1 to Account 2");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter amount to deposit into Account 1: ");
                        decimal depositAmount1 = decimal.Parse(Console.ReadLine());
                        await account1.DepositAsync(depositAmount1);
                        break;

                    case "2":
                        Console.Write("Enter amount to withdraw from Account 1: ");
                        decimal withdrawAmount1 = decimal.Parse(Console.ReadLine());
                        await account1.WithdrawAsync(withdrawAmount1);
                        break;

                    case "3":
                        Console.Write("Enter amount to deposit into Account 2: ");
                        decimal depositAmount2 = decimal.Parse(Console.ReadLine());
                        await account2.DepositAsync(depositAmount2);
                        break;

                    case "4":
                        Console.Write("Enter amount to withdraw from Account 2: ");
                        decimal withdrawAmount2 = decimal.Parse(Console.ReadLine());
                        await account2.WithdrawAsync(withdrawAmount2);
                        break;

                    case "5":
                        Console.Write("Enter amount to transfer from Account 1 to Account 2: ");
                        decimal transferAmount = decimal.Parse(Console.ReadLine());
                        await accountManager.TransferAsync(account1, account2, transferAmount);
                        break;

                    case "6":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
