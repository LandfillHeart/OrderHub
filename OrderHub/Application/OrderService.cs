public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IConfigurationProvider _config;

        public event OrderEventHandler OnOrderPaid;
        public event OrderEventHandler OnOrderShipped;

        public OrderService(
            IOrderRepository orderRepository, 
            IProductRepository productRepository,
            IConfigurationProvider config)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _config = config;
        }

        public Order CreateOrder(string customerName)
        {
            var order = new Order(customerName);
            _orderRepository.Add(order);
            Console.WriteLine($"Ordine {order.Id} creato da ");
            return order;
        }
    }
