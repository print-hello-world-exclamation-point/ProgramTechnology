namespace Bank;

/// <summary>
/// Представляет кредитный счёт, позволяющий балансу уходить в минус до достижения установленного лимита кредитования.
/// </summary>
public class LineOfCreditAccount : BankAccount
{
    /// <summary>
    /// Инициализирует новый экземпляр кредитного счёта с указанием имени владельца, начального баланса и кредитного лимита.
    /// </summary>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit)
        : base(name, initialBalance, -creditLimit)
    {

    }
}