namespace Bank;

// record - Состояние объектов этого класса нельзя изменить
/// <summary>
/// Представляет неизменяемую запись о банковской операции, хранящую сумму, дату проведения и комментарий.
/// </summary>
public record Transaction(decimal Amount, DateTime Date, string Note);

//internal record Transaction
//{
//    public decimal Amount { get; }
//    public DateTime Date { get; }
//    public string Note { get; }
//    public Transaction(decimal Amount, DateTime Date, string Note)
//    { 
//        this.Amount = Amount;
//        this.Note = Note;
//        this.Date = Date;
//    }
//}