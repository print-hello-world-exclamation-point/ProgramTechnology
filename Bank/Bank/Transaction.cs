namespace Bank;
// Мы создали неизменяемый тип данных благодаря record
internal record Transaction(decimal Amount, DateTime date, string Note);


