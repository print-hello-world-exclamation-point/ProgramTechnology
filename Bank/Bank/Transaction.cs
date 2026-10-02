namespace Bank;
// Мы создали неизменяемый тип данных благодаря record
public record Transaction(decimal Amount, DateTime date, string Note);


