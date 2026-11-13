using System;

enum AccountType
{
    Current,
    Savings,
    Credit,
    Deposit
}

class BankAccount
{
    private static int nextNumber = 1000;

    private int accountNumber;
    private decimal balance;
    private AccountType accountType;

    private static int GenerateNumber()
    {
        return ++nextNumber;
    }

    public BankAccount()
    {
        accountNumber = GenerateNumber();
    }

    public void SetBalance(decimal value)
    {
        balance = value;
    }

    public void SetAccountType(AccountType type)
    {
        accountType = type;
    }

    public int GetAccountNumber()
    {
        return accountNumber;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public AccountType GetAccountType()
    {
        return accountType;
    }

    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }
        balance += amount;
        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > balance)
        {
            return false;
        }
        balance -= amount;
        return true;
    }

    public bool Transfer(BankAccount source, decimal amount)
    {
        
        if (source == null)
        {
            return false;
        }

        if (source == this)
        {
            return false;
        }

        
        if (!source.Withdraw(amount))
        {
            return false;
        }

        Deposit(amount);
        return true;
    }
}


struct Money
{
    public decimal Amount;
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        BankAccount acc1 = new BankAccount();
        acc1.SetBalance(1000m);
        BankAccount acc2 = new BankAccount();
        acc2.SetBalance(500m);

        bool ok = acc2.Transfer(acc1, 300m);
        Console.WriteLine($"Перевод 300: {ok}");
        Console.WriteLine($"acc1: {acc1.GetBalance():F2}, acc2: {acc2.GetBalance():F2}");

        
        BankAccount nothing = null;
        Console.WriteLine($"Перевод с null: {acc2.Transfer(nothing, 100m)}");

        Console.WriteLine($"Перевод самому себе: {acc1.Transfer(acc1, 100m)}");

        BankAccount link = acc1;
        link.Deposit(100m);
        Console.WriteLine($"После link.Deposit(100): acc1 = {acc1.GetBalance():F2}");

        
        Money m1 = new Money();
        m1.Amount = 50m;
        Money m2 = m1;                
        m2.Amount = 999m;
        Console.WriteLine($"m1.Amount = {m1.Amount}, m2.Amount = {m2.Amount}");
    }
}
