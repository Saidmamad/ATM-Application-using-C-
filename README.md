// ATM-Application-using-C- #
// ATM operations 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMApplication
{
    class ATM
    {
        public static double balance = 0;
        public static int withdrawAmount;
        public static int depositAmount;

        static void CheckBalance() {
            Console.WriteLine("Your balance: " + balance);
        }

        static double WithdrawMoney(int withdrawAmount) {
            if (withdrawAmount > balance)
            {
                Console.WriteLine("Unsufficient balance!");
                return 0; 
            }
            else {
                balance -= withdrawAmount;
                Console.WriteLine("Take your cash");
                return balance;
            }
        
        }

        static void Deposit(int DepositAmount) {
            //Console.WriteLine("Please enter the amount to deposit:");
            //depositAmount = int.Parse(Console.ReadLine());
            balance += DepositAmount;
            Console.WriteLine("Your money has been deposited to your account. \nYour current balance is Rs. {0} .", balance);
        }


        static void Main(string[] args)
        {
            int PIN;
            int choice;
            int pinTryNumber = 1;
            Console.WriteLine("Welcome to State Bank of India! ");
            Console.WriteLine("Please insert your card!\n");
            Console.WriteLine("Please enter your PIN: ");
            PIN = int.Parse(Console.ReadLine());

            ValidPIN:
            if (PIN == 1234)
            {
            
                while (true)
                {
                    Console.WriteLine("PLease enter your choice of operation: ");
                    Console.WriteLine(" 1 - To check your balance \n 2 - To withdraw money \n 3 - To deposit money \n 4 - To exit ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            CheckBalance();
                            break;

                        case 2:
                            Console.WriteLine("Please enter the amount of money to withdraw: ");
                            withdrawAmount = int.Parse(Console.ReadLine());
                            WithdrawMoney(withdrawAmount);
                            break;

                        case 3:
                            Console.WriteLine("Please enter the amount to deposit: ");
                            depositAmount = int.Parse(Console.ReadLine());
                            Deposit(depositAmount);
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
            }
            else
            {
                while (pinTryNumber < 3)
                {
                    pinTryNumber++;
                    Console.WriteLine("You PIN is not correct. Please enter the correct PIN:");
                    PIN = int.Parse(Console.ReadLine());
                    if (PIN == 1234)
                        goto ValidPIN;
                }
                Console.WriteLine("\n\nYou exceeded the number of tries! Your card has been locked! \nContact your branch office for further information!");
                
            }
            
            Console.ReadKey();
        }
    }
}

