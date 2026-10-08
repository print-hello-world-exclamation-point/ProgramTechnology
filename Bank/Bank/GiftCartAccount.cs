namespace Bank;

internal class GiftCartAccount: BankAccount
{
    private readonly decimal _monthlyDeposit = 0m;

    public GiftCartAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0)
        : base(name, initialBalance) => _monthlyDeposit = monthlyDeposit;
     
    public override void PerformMonthEndTransactions()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
        }
    }
    public override string ToString()
       => base.ToString() + $"monthly deposit: {_monthlyDeposit}";

}
