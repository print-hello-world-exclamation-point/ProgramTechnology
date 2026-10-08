namespace Bank;

public class Program
{
    static void Main(string[] args)
    {
        BankAccount account1 = new BankAccount("Zocya", 10000000000);
        BankAccount account2 = new BankAccount("Egor", 100);

        Console.WriteLine($"Account: {account1.Owner} {account1.Balance}$ {account1.Number}");
        Console.WriteLine($"account: {account2.Owner} {account2.Balance}$ {account2.Number}");
        account1.MakeDeposit(1000000, DateTime.UtcNow, ":)");
        Console.WriteLine(account1.Balance);
        account1.MakeWithdrawal(1000, DateTime.UtcNow, ";)");

        Console.WriteLine(account1.GetAccountHistory());


        try
        {
            account2.MakeWithdrawal(1000, DateTime.UtcNow, "&&&");
            Console.WriteLine(account2.Balance);
        }
        catch(InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }

        InterestEarningAccount interestEarning = new("Yana", 1000m);
        interestEarning.MakeDeposit(1000m, DateTime.UtcNow, "fff");
        interestEarning.MakeWithdrawal(10m, DateTime.UtcNow, "fff");
        interestEarning.PerformMonthEndTransactions();

        Console.WriteLine(interestEarning);
        Console.WriteLine(interestEarning.GetAccountHistory());

        InterestEarningAccount interest = new InterestEarningAccount("Yana", 1000);
        interest.PerformMonthEndTransactions();

        Console.WriteLine(interest.GetAccountHistory());

        LineOfCreditAccount lineOfCredit = new LineOfCreditAccount("Yana", 0, 1000m);
        lineOfCredit.MakeWithdrawal(500m, DateTime.UtcNow, "credit");

        GiftCartAccount giftcart = new GiftCartAccount("Yana", 1000m, 5000m);

        List<BankAccount> accounts = new List<BankAccount>();
        accounts.Add(account1);
        accounts.Add(interest);
        accounts.Add(lineOfCredit);
        accounts.Add(giftcart);

        foreach (BankAccount account in accounts)
        {
            Console.WriteLine(account);
            account.PerformMonthEndTransactions();
            Console.WriteLine(account.GetAccountHistory);

        }

    }
}
