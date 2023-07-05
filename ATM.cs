using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your current balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw?");
            double withdrawal = double.Parse(Console.ReadLine());
            // Checking for sufficient balance
            if (currentUser.getBalance() >= withdrawal)
            {
                currentUser.setBalance(currentUser.getBalance() + deposit );
                Console.WriteLine("Withdrawal successful. Thank you!");
            }
            else
            {
                Console.WriteLine("Insufficient balance for withdrawal.");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532774848898", 1234, "Jason", "Todd", 150.43));
        cardHolders.Add(new cardHolder("4532775684834", 2468, "Dick", "Grayson", 140.13));
        cardHolders.Add(new cardHolder("4657823456483", 4321, "Bruce", "Wayne", 120.33));
        cardHolders.Add(new cardHolder("8957498578493", 2341, "Matthew", "Murdock", 110.53));
        cardHolders.Add(new cardHolder("5437856357876", 4213, "Barry", "Allen", 130.93));

        // Prompt
        Console.WriteLine("Welcome to simpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our database
                currentUser = cardHolders.FirstOrDefault(a => a.getNum() == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again.");
            }
        }

        Console.WriteLine("Please enter your PIN: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // Check against our database
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect PIN. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect PIN. Please try again.");
            }
        }

        Console.WriteLine("Welcome, " + currentUser.getFirstName() + "!");

        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }
        } while (option != 4);

        Console.WriteLine("Thank you! Have a nice day!");
    }
}
