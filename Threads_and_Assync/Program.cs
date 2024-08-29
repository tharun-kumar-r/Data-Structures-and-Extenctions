using Banking_System;
using System;
using static Banking_System.Account;

namespace SimpleBankSystem
{
 
    class Program
    {
            static void Main(string[] args)
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
                            Thread depositThread1 = new Thread(() => account1.Deposit(depositAmount1));
                            depositThread1.Start();
                            depositThread1.Join();
                            break;

                        case "2":
                            Console.Write("Enter amount to withdraw from Account 1: ");
                            decimal withdrawAmount1 = decimal.Parse(Console.ReadLine());
                            Thread withdrawThread1 = new Thread(() => account1.Withdraw(withdrawAmount1));
                            withdrawThread1.Start();
                            withdrawThread1.Join();
                            break;

                        case "3":
                            Console.Write("Enter amount to deposit into Account 2: ");
                            decimal depositAmount2 = decimal.Parse(Console.ReadLine());
                            Thread depositThread2 = new Thread(() => account2.Deposit(depositAmount2));
                            depositThread2.Start();
                            depositThread2.Join();
                            break;

                        case "4":
                            Console.Write("Enter amount to withdraw from Account 2: ");
                            decimal withdrawAmount2 = decimal.Parse(Console.ReadLine());
                            Thread withdrawThread2 = new Thread(() => account2.Withdraw(withdrawAmount2));
                            withdrawThread2.Start();
                            withdrawThread2.Join();
                            break;

                        case "5":
                            Console.Write("Enter amount to transfer from Account 1 to Account 2: ");
                            decimal transferAmount = decimal.Parse(Console.ReadLine());
                            Thread transferThread = new Thread(() => accountManager.Transfer(account1, account2, transferAmount));
                            transferThread.Start();
                            transferThread.Join();
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
