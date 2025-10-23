using Presentation;
using OrderHub;

public class Program
{
	public static void Main()
	{
		var ui = new ConsoleUI();
		ui.StartApp();

		ILogger logger = new ConsoleLogger();

		var service = new OrderService(logger);

		Console.WriteLine($"inserisci email");
		string? email = Console.ReadLine();
		Console.WriteLine($"Inserisci un importo");
		decimal amount = Convert.ToDecimal(Console.ReadLine());


		service.OnOrderPaid += (orderId, total) => logger.Log($"Order {orderId} paid for {total}");
		service.OnOrderShipped += (orderId, total) => logger.Log($"Order {orderId} shipped to {email} for {total}");
		service.OnOrderCancelled += (orderId, total) => logger.Log($"Order {orderId} cancelled for {total}");
		service.EmailNotifier(email, amount);
	}
}