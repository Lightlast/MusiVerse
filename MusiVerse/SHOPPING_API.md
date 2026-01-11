# ?? Shopping API Reference

## ?? Table of Contents
1. [Concert Service](#concert-service)
2. [Ticket Service](#ticket-service)
3. [Repository Methods](#repository-methods)
4. [UI Components](#ui-components)
5. [Forms](#forms)
6. [Examples](#examples)

---

## ?? Concert Service

### GetAllActiveConcerts()
L?y t?t c? concert còn hi?u l?c (ch?a di?n ra)

```csharp
public List<Concert> GetAllActiveConcerts()
```

**Returns**: `List<Concert>`

**Example**:
```csharp
var service = new ConcertService();
var concerts = service.GetAllActiveConcerts();

foreach (var concert in concerts)
{
    Console.WriteLine($"{concert.Name} - {concert.ArtistName}");
    Console.WriteLine($"Venue: {concert.Venue}");
    Console.WriteLine($"Date: {concert.ConcertDate:dd/MM/yyyy}");
    Console.WriteLine($"Available: {concert.AvailableTickets}/{concert.TotalTickets}");
}
```

### GetConcertById(int concertID)
L?y concert theo ID

```csharp
public Concert GetConcertById(int concertID)
```

**Parameters**:
- `concertID` (int): ID c?a concert

**Returns**: `Concert` ho?c `null`

**Example**:
```csharp
var service = new ConcertService();
var concert = service.GetConcertById(1);

if (concert != null)
{
    Console.WriteLine($"Concert: {concert.Name}");
    Console.WriteLine($"Venue: {concert.Venue}");
}
```

### GetConcertsByArtist(int artistID)
L?y t?t c? concert c?a m?t ngh? s?

```csharp
public List<Concert> GetConcertsByArtist(int artistID)
```

**Parameters**:
- `artistID` (int): ID c?a ngh? s?

**Returns**: `List<Concert>`

**Example**:
```csharp
var service = new ConcertService();
var concerts = service.GetConcertsByArtist(artistID: 5);

Console.WriteLine($"T?ng concert: {concerts.Count}");
```

### CreateConcert(Concert concert)
T?o concert m?i

```csharp
public int CreateConcert(Concert concert)
```

**Parameters**:
- `concert` (Concert): Thông tin concert

**Returns**: `int` - Concert ID

**Validations**:
- Name không ???c r?ng
- Venue không ???c r?ng
- ConcertDate ph?i > ngày hi?n t?i
- TotalTickets > 0
- Price >= 0

**Example**:
```csharp
var concert = new Concert
{
    ArtistID = 123,
    Name = "Summer Concert 2024",
    Description = "M?t bu?i di?n tuy?t v?i",
    Venue = "Sân v?n ??ng Th?ng Nh?t",
    ConcertDate = DateTime.Now.AddMonths(3),
    PosterImage = "path/to/poster.jpg",
    TotalTickets = 1000,
    Price = 150000,
    TicketType = 1 // 0=NoSeat, 1=WithSeat
};

var service = new ConcertService();
int concertID = service.CreateConcert(concert);
Console.WriteLine($"Concert created with ID: {concertID}");
```

### UpdateConcert(Concert concert)
C?p nh?t thông tin concert

```csharp
public bool UpdateConcert(Concert concert)
```

**Parameters**:
- `concert` (Concert): Thông tin concert v?i ConcertID

**Returns**: `bool` - true n?u thành công

**Example**:
```csharp
var concert = service.GetConcertById(1);
concert.Name = "Updated Concert Name";
concert.Venue = "New Venue";

bool success = service.UpdateConcert(concert);
```

### DeleteConcert(int concertID)
Xóa concert (soft delete - IsActive = 0)

```csharp
public bool DeleteConcert(int concertID)
```

**Parameters**:
- `concertID` (int): ID c?a concert

**Returns**: `bool` - true n?u thành công

**Example**:
```csharp
var service = new ConcertService();
bool success = service.DeleteConcert(concertID: 1);
```

---

## ??? Ticket Service

### GetUserTickets(int userID)
L?y t?t c? vé c?a m?t user (vé ch?a h?t h?n)

```csharp
public List<Ticket> GetUserTickets(int userID)
```

**Parameters**:
- `userID` (int): ID c?a user

**Returns**: `List<Ticket>`

**Example**:
```csharp
var service = new TicketService();
var tickets = service.GetUserTickets(userID: 456);

foreach (var ticket in tickets)
{
    Console.WriteLine($"Concert: {ticket.ConcertName}");
    Console.WriteLine($"Ticket Code: {ticket.TicketCode}");
    Console.WriteLine($"Price: {ticket.Price}?");
}
```

### GetTicketById(int ticketID)
L?y thông tin vé theo ID

```csharp
public Ticket GetTicketById(int ticketID)
```

**Parameters**:
- `ticketID` (int): ID c?a vé

**Returns**: `Ticket` ho?c `null`

**Example**:
```csharp
var service = new TicketService();
var ticket = service.GetTicketById(100);

if (ticket != null)
{
    Console.WriteLine($"Ticket Code: {ticket.TicketCode}");
}
```

### BuyTicket(int concertID, int userID, string seatClass)
Mua vé (t?o mã vé, QR code, l?u database)

```csharp
public int BuyTicket(int concertID, int userID, string seatClass = "")
```

**Parameters**:
- `concertID` (int): ID c?a concert
- `userID` (int): ID c?a user
- `seatClass` (string): "VIP", "Standard", "Economy" (ho?c "" n?u không s?p ch?)

**Returns**: `int` - Ticket ID

**Validations**:
- Concert t?n t?i
- Còn vé trong concert
- User h?p l?

**Side Effects**:
- T?o mã vé 5 ch? s? duy nh?t
- T?o file QR code PNG
- C?p nh?t Concert.AvailableTickets--
- L?u vé vào database

**Example - Vé không s?p ch?**:
```csharp
var service = new TicketService();
int ticketID = service.BuyTicket(
    concertID: 1,
    userID: 456,
    seatClass: ""
);
```

**Example - Vé có s?p ch?**:
```csharp
var service = new TicketService();

// VIP - 150% giá
int ticketID1 = service.BuyTicket(1, 456, "VIP");

// Standard - 100% giá
int ticketID2 = service.BuyTicket(1, 456, "Standard");

// Economy - 70% giá
int ticketID3 = service.BuyTicket(1, 456, "Economy");
```

### GetConcertTickets(int concertID)
L?y t?t c? vé c?a m?t concert

```csharp
public List<Ticket> GetConcertTickets(int concertID)
```

**Parameters**:
- `concertID` (int): ID c?a concert

**Returns**: `List<Ticket>`

**Example**:
```csharp
var service = new TicketService();
var tickets = service.GetConcertTickets(concertID: 1);
Console.WriteLine($"Total tickets sold: {tickets.Count}");
```

### UpdateTicketStatus(int ticketID, string status)
C?p nh?t tr?ng thái vé

```csharp
public bool UpdateTicketStatus(int ticketID, string status)
```

**Parameters**:
- `ticketID` (int): ID c?a vé
- `status` (string): "Active", "Expired", "Used"

**Returns**: `bool` - true n?u thành công

**Example**:
```csharp
var service = new TicketService();
bool success = service.UpdateTicketStatus(ticketID: 100, status: "Used");
```

### IsTicketExpired(Ticket ticket)
Ki?m tra vé có h?t h?n không

```csharp
public bool IsTicketExpired(Ticket ticket)
```

**Parameters**:
- `ticket` (Ticket): Thông tin vé

**Returns**: `bool` - true n?u concert ?ã di?n ra

**Example**:
```csharp
var service = new TicketService();
var ticket = service.GetTicketById(100);

if (service.IsTicketExpired(ticket))
{
    Console.WriteLine("Vé này ?ã h?t h?n");
}
else
{
    Console.WriteLine("Vé còn hi?u l?c");
}
```

### GetSoldTicketsCount(int concertID)
L?y s? vé ?ã bán c?a concert

```csharp
public int GetSoldTicketsCount(int concertID)
```

**Parameters**:
- `concertID` (int): ID c?a concert

**Returns**: `int` - S? vé ?ã bán

**Example**:
```csharp
var service = new TicketService();
int soldCount = service.GetSoldTicketsCount(concertID: 1);
var concert = service.GetConcertById(1);
int remaining = concert.AvailableTickets;
Console.WriteLine($"Sold: {soldCount}, Remaining: {remaining}");
```

---

## ?? Repository Methods

### ConcertRepository

```csharp
public List<Concert> GetAllActiveConcerts()
public Concert GetConcertById(int concertID)
public List<Concert> GetConcertsByArtist(int artistID)
public int AddConcert(Concert concert)
public bool UpdateConcert(Concert concert)
public bool DeleteConcert(int concertID)
```

### TicketRepository

```csharp
public List<Ticket> GetUserTickets(int userID)
public Ticket GetTicketById(int ticketID)
public List<Ticket> GetConcertTickets(int concertID)
public int AddTicket(Ticket ticket)
public bool UpdateTicketStatus(int ticketID, string status)
public bool TicketCodeExists(string ticketCode)
public int GetSoldTicketsCount(int concertID)
```

---

## ??? UI Components

### ucShopping
Main shopping page component

```csharp
// T? ??ng load concert t? ConcertService
// Hi?n th? danh sách ucConcertCard
// Các event:
//   - Nút "Vé c?a tôi" ? M? frmMyTickets
//   - Nút "Làm m?i" ? Reload danh sách concert
```

### ucConcertCard
Concert card component

```csharp
// Properties
public Concert ConcertData { get; set; }

// Methods
public void LoadConcert(Concert concert)

// Events
public event EventHandler OnBuyClicked;      // Nút "Mua vé"
public event EventHandler OnViewDetailsClicked; // Nút "Chi ti?t"
```

**Usage**:
```csharp
var card = new ucConcertCard();
card.LoadConcert(concert);
card.OnBuyClicked += (s, e) => {
    // M? form mua vé
    frmBuying buying = new frmBuying(concert, userID);
    buying.ShowDialog();
};
```

---

## ?? Forms

### frmBuying(Concert concert, int userID)
Form mua vé

```csharp
// Hi?n th?:
//   - Thông tin concert (c? ??nh)
//   - NumericUpDown: Ch?n s? l??ng
//   - ComboBox: Ch?n h?ng gh? (n?u TicketType = 1)
//   - Label: T?ng giá (t? ??ng c?p nh?t)
// Nút: "Mua vé", "H?y"

// DialogResult = OK: Mua thành công
// DialogResult = Cancel: H?y mua
```

### frmMyTickets(int userID)
Xem vé ?ã mua

```csharp
// Hi?n th?:
//   - Danh sách vé d?ng card
//   - M?i card: Concert, ngày, mã vé, h?ng, giá
//   - Tr?ng thái: ? Còn hi?u l?c / ? H?t h?n
// Nút: "Xem QR Code", "T?i QR Code"
```

### frmConcertDetail(Concert concert)
Chi ti?t concert

```csharp
// Hi?n th?:
//   - Tên concert (l?n)
//   - Poster
//   - Thông tin: Ngh? s?, ngày, ??a ?i?m, giá
//   - S? vé còn l?i
//   - Lo?i vé
//   - Mô t? chi ti?t
```

---

## ?? Examples

### Complete Flow: Mua Vé

```csharp
// 1. Hi?n th? danh sách concert
var concertService = new ConcertService();
var concerts = concertService.GetAllActiveConcerts();

// 2. User ch?n concert và click "Mua vé"
var selectedConcert = concerts[0];
var frmBuying = new frmBuying(selectedConcert, userID: 456);

if (frmBuying.ShowDialog() == DialogResult.OK)
{
    // 3. Vé ?ã ???c mua
    MessageBox.Show("Mua vé thành công!");
    
    // 4. Reload danh sách concert (s? vé c?p nh?t)
    concerts = concertService.GetAllActiveConcerts();
}
```

### Complete Flow: Xem Vé

```csharp
// 1. User click "Vé c?a tôi"
var frmMyTickets = new frmMyTickets(userID: 456);
frmMyTickets.ShowDialog();

// Bên trong frmMyTickets:
// - L?y danh sách vé t? TicketService.GetUserTickets()
// - Hi?n th? danh sách
// - User click "Xem QR Code" ho?c "T?i QR Code"
```

### T?o Concert (Admin/Artist)

```csharp
var concert = new Concert
{
    ArtistID = 123,
    Name = "Summer Festival 2024",
    Description = "L? h?i âm nh?c hè l?n nh?t n?m",
    Venue = "Sân v?n ??ng Th?ng Nh?t",
    ConcertDate = new DateTime(2024, 7, 15, 19, 0, 0),
    PosterImage = "C:\\Posters\\summer2024.jpg",
    TotalTickets = 1000,
    Price = 150000,
    TicketType = 1 // Có s?p ch?
};

var service = new ConcertService();
try
{
    int concertID = service.CreateConcert(concert);
    Console.WriteLine($"Concert created: ID {concertID}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

### Mua Nhi?u Vé

```csharp
var ticketService = new TicketService();
int quantity = 5;
List<int> ticketIDs = new List<int>();

for (int i = 0; i < quantity; i++)
{
    int ticketID = ticketService.BuyTicket(
        concertID: 1,
        userID: 456,
        seatClass: i < 2 ? "VIP" : "Standard"
    );
    ticketIDs.Add(ticketID);
}

Console.WriteLine($"Bought {ticketIDs.Count} tickets");
```

### Ki?m Tra Vé H?t H?n

```csharp
var ticketService = new TicketService();
var tickets = ticketService.GetUserTickets(userID: 456);

int activeCount = 0;
int expiredCount = 0;

foreach (var ticket in tickets)
{
    if (ticketService.IsTicketExpired(ticket))
        expiredCount++;
    else
        activeCount++;
}

Console.WriteLine($"Active: {activeCount}, Expired: {expiredCount}");
```

---

## ?? Data Models

### Concert Model
```csharp
public class Concert
{
    public int ConcertID { get; set; }
    public int ArtistID { get; set; }
    public string ArtistName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Venue { get; set; }
    public DateTime ConcertDate { get; set; }
    public string PosterImage { get; set; }
    public int TotalTickets { get; set; }
    public int AvailableTickets { get; set; }
    public decimal Price { get; set; }
    public int TicketType { get; set; } // 0=NoSeat, 1=WithSeat
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}
```

### Ticket Model
```csharp
public class Ticket
{
    public int TicketID { get; set; }
    public int ConcertID { get; set; }
    public string ConcertName { get; set; }
    public int UserID { get; set; }
    public string TicketCode { get; set; } // 5 digits
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; } // Active/Expired/Used
    public DateTime ConcertDate { get; set; }
    public string Venue { get; set; }
    public int TicketType { get; set; }
    public string SeatClass { get; set; } // VIP/Standard/Economy
    public string QRCodeImage { get; set; } // File path
}
```

---

## ?? Error Handling

```csharp
try
{
    int ticketID = ticketService.BuyTicket(1, 456, "VIP");
}
catch (Exception ex)
{
    // X? lý l?i
    MessageBox.Show($"Error: {ex.Message}");
    
    // Có th? là:
    // - "Concert not found"
    // - "No tickets available"
    // - "Error generating QR code"
}
```

---

## ? Checklist

- [x] Concert CRUD
- [x] Ticket CRUD
- [x] Unique Ticket Code
- [x] QR Code Generation
- [x] Seat Classes
- [x] Ticket Expiration
- [x] UI Components
- [x] Forms
- [x] Error Handling

---

**Happy Coding! ????**
