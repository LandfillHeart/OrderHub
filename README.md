# 🧾 OrderHub — Mini Sistema Ordini (C# .NET Console) 🧾

**OrderHub** è una mini applicazione console per la gestione di prodotti e ordini, sviluppata in C# seguendo i principali design pattern e un architettura N-tier orientata alla l:

**Dependency Injection**, **Factory**, **Singleton**, **Delegate/Event**, e **Repository**.

Il progetto mostra un’architettura pulita e modulare, separando Domain, Infrastructure e Presentation.

## 📁 Struttura del Progetto 📁

OrderHub/
|--**Domain**/
│ |--Entities/
│ │ |--Product.cs
│ │ |-- Order.cs
│ │ |-- OrderItem.cs
|
│ |--Enums/
│ │ |--OrderStatus.cs
|  
│ |--Interfaces/
│ │ |--IProductRepository.cs
│ │ |-- IOrderRepository.cs
|
│ |--Services/
│ | |--OrderService.cs
│
|--**Infrastructure**/
│ |-- Repositories/
│ │ |-- InMemoryProductRepository.cs
│ │ |-- InMemoryOrderRepository.cs
|
│ |--Factories/
│ │ |-- PaymentFactory.cs
|
│ |-- Config/
│ | |-- ConfigurationProvider.cs
│
|--**Presentation**/
│ |--ConsoleUI.cs
|
│--Program.cs
│
└── README.md

## ⚙️ Funzionalità ⚙️

### 👕 Prodotti 👕

- [x] Creazione di un nuovo prodotto
- [x] Lista prodotti disponibili

### 📦 Ordini 📦

- [x] Creazione di un ordine
- [x] Aggiunta di prodotti a un ordine
- [x] Checkout con calcolo tasse (Singleton `ConfigurationProvider`)
- [x] Spedizione e cancellazione ordine
- [x] Lista ordini

### 🔔 Notifiche (Delegate/Event) 🔔

- Evento `OnOrderPaid` → stampa “email” e “CRM Sync”
- Evento `OnOrderShipped` → stampa “ordine spedito”

### 🧱 Pattern utilizzati 🧱

| Pattern                  | Descrizione                                                               |
| ------------------------ | ------------------------------------------------------------------------- |
| **Dependency Injection** | Tutti i servizi ricevono le dipendenze nel costruttore.                   |
| **Factory**              | `PaymentFactory` restituisce implementazioni di pagamento basate su enum. |
| **Singleton**            | `ConfigurationProvider` condiviso per tasse e valute.                     |
| **Delegate/Event**       | `OrderService` espone eventi `OnOrderPaid` e `OnOrderShipped`.            |
| **Repository**           | Gestione persistenza in memoria (`InMemoryRepository`).                   |

## 🖥️ Interfaccia Console (UI) 🖥️

Esempio del **menu principale**:
ORDERHUB — MENU

[1] Aggiungi prodotto
[2] Lista prodotti
[3] Crea ordine
[4] Aggiungi item a ordine
[5] Checkout (Paga ordine)
[6] Spedisci ordine
[7] Cancella ordine
[8] Lista ordini
[0] Esci

Ogni schermata mostra input testuali e messaggi colorati (verde=successo, rosso=errore, giallo=info).

## 🚀 Esecuzione

--Inserire Esempio--

### Requisiti

- .NET 8.0 SDK o superiore
- Visual Studio / VS Code
