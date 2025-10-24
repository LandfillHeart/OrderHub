using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Domain;
using Infrastructure;
using System.Runtime.Intrinsics.Arm;
using System.Drawing;
using OrderHub.Application;

namespace Presentation
{
    public class ConsoleUI
    {
        private bool _running = true;

        public void StartApp()
        {
            do
            {
                ShowMenu();
                Console.WriteLine($"Benvenuto nella nostra OrderHubApp, seleziona l'operazione che ti interessa:");
                Console.WriteLine($"Scelta: ");
                string sceltaOperazione = Console.ReadLine();

                switch (sceltaOperazione)
                {
                    case "1":
                        AddProductUI();
                        break;

                    case "2":
                        ListProductUI();
                        break;

                    case "3":
                        CreateOrderUI();
                        break;

                    case "4":
                        AddItemToOrderUI();
                        break;

                    case "5":
                        CheckoutUI();
                        break;

                    case "6":
                        ShipOrderUI();
                        break;

                    case "7":
                        CancelOrderUI();
                        break;

                    case "8":
                        ListOrderUI();
                        break;

                    case "0":
                        Console.WriteLine($"Esco dal programma...");
                        _running = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"[ERRORE] Operazione non valida!");
                        Console.ResetColor();
                        break;
                }


            } while (_running);
        }

        private void ShowMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"==============================");
            Console.WriteLine($"==     ORDER HUB MENU       ==");
            Console.WriteLine($"==============================");
            Console.ResetColor();
            Console.WriteLine($"[1] Aggiungi un Prodotto al catalogo");
            Console.WriteLine($"[2] Vedi il catalogo dei prodotti");
            Console.WriteLine($"[3] Crea un ordine");
            Console.WriteLine($"[4] Aggiungi degli oggetti ad un ordine");
            Console.WriteLine($"[5] Esegui il checkout");
            Console.WriteLine($"[6] Spedisci un ordine");
            Console.WriteLine($"[7] Cancella un ordine");
            Console.WriteLine($"[8] Vedi l'elenco degli ordini");
            Console.WriteLine($"[0] Esci");
            Console.WriteLine();
        }

        // 1 Aggiungi un Prodotto al catalogo
        private void AddProductUI()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"===== AGGIUNGI PRODOTTO =====");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine($"Inserisci il nome del prodotto:");
            string name = Console.ReadLine();

            Console.WriteLine($"Inserisci il prezzo del prodotto");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine($"Inserisci la quantita di prodotto nel magazzino");
            int stock = int.Parse(Console.ReadLine());

			// TODO: aggiungere le chiamate il service per rendere vere le operazioni
			// niente stock :(
			ApplicationLayer.Instance.CreateProduct(name, price);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[OK] Prodotto '{name}' creato con successo!");
            Console.ResetColor();
            Console.WriteLine($"[CONTABILITÀ] il prodotto creato ha prezzo {price} EUR");
            Console.WriteLine($"[MAGAZZINO] {stock} del prodotto presenti nel magazzino");
        }

        // 2 Vedi il catalogo dei prodotti
        private void ListProductUI()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"===== CATALOGO PRODOTTI =====");
            Console.ResetColor();
            Console.WriteLine();

			// TODO: recupero del repository dei prodotti
			if(!ApplicationLayer.Instance.GetAllProducts(out List<Product> serializedProds))
			{
				Console.Write("Non sei collegato al database, impossibile visualizzare ordini!!");
			}
			foreach (Product prod in serializedProds)
			{
				Console.WriteLine($"[PRODOTTO] {prod.Id} | {prod.Name} | {prod.Price} | QUANTITÀ (da implementare) ");
			}
            
        }

        // 3 Crea un ordine
        private void CreateOrderUI()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"===== CREA UN ORDINE =====");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine($"Inserire nome del cliente che crea l'ordine: ");
            string? customerName = Console.ReadLine();
            ApplicationLayer.Instance.CreateOrder(customerName);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[OK] ORDINE CREATO");
            Console.ResetColor();
            Console.WriteLine($"Ordine creato a nome di {customerName}");
        }

        // 4 Aggiungi degli oggetti ad un ordine 
        private void AddItemToOrderUI()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"===== CREA UN ORDINE =====");
            Console.ResetColor();
            Console.WriteLine();
        }

        // 5 Esegui il checkout
        private void CheckoutUI()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"===== ESEGUI IL CHECKOUT=====");
            Console.ResetColor();
            Console.WriteLine();
        }

        // 6 Spedisci un ordine
        private void ShipOrderUI()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"===== SPEDISCI UN ORDINE =====");
            Console.ResetColor();
            Console.WriteLine();
        }

        // 7 Cancella un ordine
        private void CancelOrderUI()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"===== CANCELLA UN ORDINE =====");
            Console.ResetColor();
            Console.WriteLine();
        }

        // 8 Vedi l'elenco degli ordini
        private void ListOrderUI()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"===== LISTA DEGLI ORDINI =====");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}