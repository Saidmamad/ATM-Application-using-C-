/*    ############################################################
 *    #  Last updated: 26/08/2017                                #
 *    #  New features: Min amount to withdraw, withdraw options  #
 *    #                Conversions to the bigger/smaller notes   #
 *    #  Version: 1.1                                            #
 *    #  Author: Saidmamad Gulomshoev                            #
 *    #  License: MIT License                                    #
 *    ############################################################
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMApplication
{
    class ATM
    {
        public static Decimal balance = 0;
        public static Decimal withdrawAmount=0;
        public static Decimal depositAmount;
   
        static void CheckBalance() {
            Console.WriteLine("\nYour balance: Rs " + convertToBiggestNote(balance));
        }

        
        static Decimal withdrawIfAvailable(Decimal balance, Decimal withdrawAmount) {
            

            //balance = convertToBiggestNote(balance);
            //Console.WriteLine("Balance: {0} Withdraw amount: {0}", balance, withdrawAmount);
            if (withdrawAmount > balance)
            {
                Console.WriteLine("\n Sorry! Unsuficient balance! \n");
            }
            
            else if(withdrawAmount < 1000) {
                Console.WriteLine("Minimum amount possible to be withdrawn is Rs 10. \n");
            }
            
            else {
                balance -= withdrawAmount;
                Console.WriteLine("Please collect your cash! ");
            }
            return balance;
         }

        
        static Decimal WithdrawMoney()
        {
            int options;
            Console.WriteLine("Select an option: ");
            Console.WriteLine(" 1 - 50 \n 2 - 100 \n 3 - 500 \n 4 - Enter manually \n 0 - Back to main options ");
            Console.Write("Option: ");
            options = int.Parse(Console.ReadLine());
         

            switch (options) { 
                case 1:
                    withdrawAmount = 5000;
                    balance = withdrawIfAvailable(balance, withdrawAmount);
                    return balance;
                    
                case 2:
                    withdrawAmount = 10000;
                    balance = withdrawIfAvailable(balance, withdrawAmount);
                    return balance;

                case 3:
                    withdrawAmount = 50000; 
                    balance = withdrawIfAvailable(balance, withdrawAmount);
                    return balance;
                case 4:
                    Console.Write("\nPlease enter the amount you want to withdraw: ");
                    withdrawAmount = Decimal.Parse(Console.ReadLine());
                    withdrawAmount = convertToSmallestNote(withdrawAmount);
                    balance = withdrawIfAvailable(balance, withdrawAmount);
                    return balance;

                case 0:
                    return 0;

                default:
                    Console.WriteLine("\nInvalid choice! \n");
                    return 0;
            }

        }


        static Decimal convertToSmallestNote(Decimal bigNote) {
            Decimal smallNote = bigNote * 100;
            return smallNote;

        }


        static Decimal convertToBiggestNote(Decimal smallNote)
        {
            Decimal bigNote = smallNote / 100;
            return bigNote;

        }




        static void Deposit() {
            Console.Write("\nPlease enter the amount to deposit: ");
           
            depositAmount = Decimal.Parse(Console.ReadLine());
            depositAmount = convertToSmallestNote(depositAmount);
            Console.WriteLine("Converted to the smallest note: " + depositAmount);
            balance += depositAmount;
            Console.WriteLine("\nYour money has been deposited to your account. \nYour current balance is Rs. {0}.\n", convertToBiggestNote(balance));
        }


        static void Main(string[] argg)
        {
            int PIN;
            int choice;
            int pinTryNumber = 1;
            Console.WriteLine("Welcome to State Bank of India! ");
            Console.WriteLine("Please insert your card!\n");
            Console.Write("Please enter your PIN: ");
            PIN = int.Parse(Console.ReadLine());

            ValidPIN:
            if (PIN == 1234)
            {
            
                while (true)
                {
                    Console.WriteLine("\nPlease enter the operation mode: ");
                    Console.WriteLine(" 1 - To check your balance \n 2 - To withdraw money \n 3 - To deposit money \n 0 - To exit ");
                    Console.Write("Operation mode: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            CheckBalance();
                            break;

                        case 2:
                            WithdrawMoney();
                            break;

                        case 3:
                            Deposit();
                            break;

                        case 0:
                            //Close the program
                            return;

                        default:
                            Console.WriteLine("\nInvalid choice!");
                            break;
                    }
                }
            }
            else
            {
                while (pinTryNumber < 3)
                {
                    pinTryNumber++;
                    Console.Write("\nYou PIN is not correct. Please enter your correct PIN: ");
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
