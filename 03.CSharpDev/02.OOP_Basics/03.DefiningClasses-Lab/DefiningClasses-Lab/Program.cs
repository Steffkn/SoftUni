using System;
using System.Collections.Generic;
using System.Dynamic;

class Program
{
    static void Main()
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var tockens = input.Split();
            var command = tockens[0];
            switch (command)
            {
                case "Create":
                    Create(tockens, accounts);
                    break;
                case "Deposit":
                    Deposit(tockens, accounts);
                    break;
                case "Withdraw":
                    Withdraw(tockens, accounts);
                    break;
                case "Print":
                    Print(tockens, accounts);
                    break;
                default:
                    break;
            }
        }
    }

    private static void Print(string[] tockens, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(tockens[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine($"Account ID{id}, balance {accounts[id].Balance:f2}");
        }

    }

    private static void Withdraw(string[] tockens, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(tockens[1]);
        decimal amount = decimal.Parse(tockens[2]);
        if (accounts.ContainsKey(id))
        {
            if (accounts[id].Balance >= amount)
            {
                accounts[id].Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Deposit(string[] tockens, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(tockens[1]);
        decimal amount = decimal.Parse(tockens[2]);
        if (accounts.ContainsKey(id))
        {
            accounts[id].Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Create(string[] tockens, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(tockens[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            accounts.Add(id, new BankAccount { Id = id });
        }
    }
}
