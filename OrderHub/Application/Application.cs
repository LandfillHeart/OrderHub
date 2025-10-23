using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    #region SINGLETON
    sealed class ConfigurationProvider
    {
        // Lazy + thread-safe
        private static readonly Lazy<ConfigurationProvider> _lazy =
            new Lazy<ConfigurationProvider>(() => new ConfigurationProvider());
        public static ConfigurationProvider Instance => _lazy.Value;
        public double TaxRate { get; private set; }
        public string Currency { get; private set; }
        public string Environment { get; private set; }
        public string ApiBaseUrl { get; private set; }
        public string CompanyName { get; private set; }
        public DateTime LoadedAt { get; private set; }
        public bool IsProduction { get; private set; }

        private ConfigurationProvider()
        {
            Currency = "EUR";
            TaxRate = Currency == "EUR" ? 0.22 : 0.10;
            Environment = "Demo";
            ApiBaseUrl = "https://api.orderhub.local";
            CompanyName = "OrderHub S.r.l.";
            LoadedAt = DateTime.UtcNow; //UtcNow sono le coordinate attuali configurate nel pc
            IsProduction = Environment == "Demo" ? false : true;
        }
    }
    #endregion

    #region FACTORY
    public static class PaymentFactory
    {
        public static IPayment Payment(PaymentType paymentType)
        {
            return paymentType switch
            {
                PaymentType.Card => new CardPayment(),
                PaymentType.PayPal => new PayPalPayment(),
                PaymentType.BankTransfer => new BankTrasferPayment(),
                _ => throw new ArgumentException("Tipo non esistente!")
            };
        }
    }
    #endregion

    #region ENTITA'
    public class CardPayment : IPayment
    {
        private readonly OrderStatus _status;
        public void ProcessPayment(decimal amount)
        {
            if (_status == OrderStatus.New) { Console.WriteLine($"Pagamento effettuato con Carta\timporto: {amount}"); }
            throw new ArgumentException($"Non puoi effettuare il pagamento!\tStato attuale: {_status}");
        }
        public string GetName() { return "Carta"; }

    }
    public class PayPalPayment : IPayment
    {
        private readonly OrderStatus _status;
        public void ProcessPayment(decimal amount)
        {
            if (_status == OrderStatus.New) { Console.WriteLine($"Pagamento effettuato con PayPal\timporto: {amount}"); }
            throw new ArgumentException($"Non puoi effettuare il pagamento!\tStato attuale: {_status}");
        }
        public string GetName(){ return "PayPal"; }
    }
    public class BankTrasferPayment : IPayment
    {
        private readonly OrderStatus _status;
        public void ProcessPayment(decimal amount)
        {
            if (_status == OrderStatus.New) { Console.WriteLine($"Pagamento effettuato con Bonifico\timporto: {amount}"); }
            throw new ArgumentException($"Non puoi effettuare il pagamento!\tStato attuale: {_status}");
        }
        public string GetName() { return ""; }
    }
    #endregion
}