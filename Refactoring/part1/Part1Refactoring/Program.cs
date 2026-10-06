using RefactoringLab;

var shipping = new ShippingCostCalculator();
Console.WriteLine($"Aramex 2kg → {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate("FedEx", 2)}");
Console.WriteLine();

var processor = new OrderProcessor(new SqlOrderRepository(), new SmtpEmailSender());
processor.Process(1001, "moahmed@emial.com");
Console.WriteLine();


var urgentEmail = new NotificationService(new EmailChannel());
urgentEmail.Send("moahmed@emial.com", "Your order ships tomorrow", isUrgent: true, sendAt: DateTime.Today.AddHours(18));

var urgentSms = new NotificationService(new SmsChannel());
urgentSms.Send("+201060133021", "OTP 4821", isUrgent: true);