using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHub
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }
    public delegate void OrderEventHandler(Guid orderId, decimal total);

    public class OrderService
    {
        private readonly ILogger _logger;
        public event OrderEventHandler OnOrderPaid;
        public event OrderEventHandler OnOrderShipped;
        public event OrderEventHandler OnOrderCancelled;

        public OrderService(ILogger logger)
        {
            _logger = logger;
        }

        public void EmailNotifier(string email, decimal amount)
        {
            _logger.Log($"Sending email to {email}");
            OnOrderPaid?.Invoke(Guid.NewGuid(), amount);
            OnOrderShipped?.Invoke(Guid.NewGuid(), amount);
            OnOrderCancelled?.Invoke(Guid.NewGuid(), amount);
        }
        
        public void CRMSync()
        {
            _logger.Log("Syncing with CRM");
        }
    }
    }