namespace RefactoringLab;

public interface IOrderRepository
{
    void Save(int orderId, DateTime processedAt);
}

public interface IEmailSender
{
    void Send(string to, string body);
}

public class SqlOrderRepository : IOrderRepository
{
    public void Save(int orderId, DateTime processedAt) =>
        Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
}

public class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string body) =>
        Console.WriteLine($"[SMTP] to={to} body={body}");
}

public class OrderProcessor
{
    private readonly IOrderRepository _repo;
    private readonly IEmailSender _email;

    public OrderProcessor(IOrderRepository repo, IEmailSender email)
    {
        _repo = repo;
        _email = email;
    }

    public void Process(int orderId, string customerEmail)
    {
        var now = DateTime.Now;
        _repo.Save(orderId, now);
        _email.Send(customerEmail, $"Order {orderId} confirmed at {now}");
    }
}