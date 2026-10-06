namespace RefactoringLab;

public interface INotificationChannel
{
    void Send(string to, string formattedMessage);
}

public class EmailChannel : INotificationChannel
{
    public void Send(string to, string formattedMessage) =>
        Console.WriteLine($"[email] {to}: {formattedMessage}");
}

public class SmsChannel : INotificationChannel
{
    public void Send(string to, string formattedMessage) =>
        Console.WriteLine($"[sms] {to}: {formattedMessage}");
}

public class NotificationService
{
    private readonly INotificationChannel _channel;

    public NotificationService(INotificationChannel channel)
    {
        _channel = channel;
    }

    public void Send(string to, string message, bool isUrgent = false, DateTime? sendAt = null)
    {
        string finalMessage = message;

        if (isUrgent)
        {
            finalMessage = $"[URGENT] {finalMessage}";
        }

        if (sendAt.HasValue)
        {
            string channelPrefix = _channel is EmailChannel ? "email scheduled" : "sms scheduled";
            Console.WriteLine($"[{channelPrefix} {sendAt.Value:g}] {to}: {finalMessage}");
        }
        else
        {
            _channel.Send(to, finalMessage);
        }
    }
}