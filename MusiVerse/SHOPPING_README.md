# ?? Shopping Feature - MusiVerse

## ?? Gi?i Thi?u

Ph?n Shopping là module qu?n lý bán vé concert trong MusiVerse. Cho phép:
- **Ng??i dùng bình th??ng**: Mua vé concert c?a các ngh? s?
- **Ngh? s?**: T?o concert và bán vé
- **Qu?n tr? viên**: Qu?n lý t?t c? concert và vé

## ?? Tính N?ng Chính

### 1. ?? Duy?t Concert
```
ucShopping (Trang chính)
?? Hi?n th? danh sách concert còn hi?u l?c
?? L?c theo ngày, giá, ngh? s?
?? Nút "Chi ti?t" - Xem thông tin ??y ??
?? Nút "Mua vé" - M? form mua vé
?? Nút "Vé c?a tôi" - Xem vé ?ã mua
```

### 2. ?? Mua Vé
```
frmBuying (Form mua vé)
?? Hi?n th? thông tin concert
?? Ch?n s? l??ng vé (1 - AvailableTickets)
?? Ch?n h?ng gh? (n?u concert có s?p ch?)
?  ?? VIP - 150% giá g?c
?  ?? Standard - 100% giá g?c
?  ?? Economy - 70% giá g?c
?? Tính t? ??ng t?ng giá
?? Nút "Mua vé" - Hoàn t?t mua hàng
```

**Quy trình mua vé:**
1. T?o mã vé ng?u nhiên (5 ch? s?)
2. T?o QR code PNG
3. L?u vé vào database
4. C?p nh?t s? vé còn l?i
5. Hi?n th? thông báo thành công

### 3. ??? Qu?n Lý Vé C?a Tôi
```
frmMyTickets (Xem vé ?ã mua)
?? Danh sách vé còn hi?u l?c
?? Thông tin vé
?  ?? Tên concert
?  ?? Ngày gi? di?n ra
?  ?? ??a ?i?m
?  ?? Mã vé (5 ch? s?)
?  ?? H?ng gh? (n?u có)
?  ?? Giá vé
?? Nút "Xem QR Code" - Hi?n th? QR code
?? Nút "T?i QR Code" - L?u file PNG
```

### 4. ?? QR Code
- **T?o t? ??ng** khi mua vé
- **L?u file PNG** trong `QRCodes/` folder
- **Tên file**: `QR_{TicketCode}.png` (ví d?: `QR_12345.png`)
- **N?i dung**: Mã vé 5 ch? s?

### 5. ? Vé H?t H?n
- Vé s? **?n t? ??ng** khi concert ?ã di?n ra
- Ki?m tra: `ConcertDate > Ngày hi?n t?i`
- Status ???c c?p nh?t thành "Expired"

## ??? C?u Trúc Th? M?c

```
MusiVerse/
?? DTO/Models/
?  ?? Concert.cs ?
?  ?? Ticket.cs ?
?? BLL/Services/
?  ?? ConcertService.cs ?
?  ?? TicketService.cs ?
?? DAL/Repositories/
?  ?? ConcertRepository.cs ?
?  ?? TicketRepository.cs ?
?? GUI/UserControls/
?  ?? ucShopping.cs ?
?  ?? ucShopping.Designer.cs ?
?  ?? ucConcertCard.cs ?
?  ?? ucConcertCard.Designer.cs ?
?? GUI/Forms/Shopping/
?  ?? frmBuying.cs ?
?  ?? frmBuying.Designer.cs ?
?  ?? frmConcertDetail.cs ?
?  ?? frmConcertDetail.Designer.cs ?
?  ?? frmMyTickets.cs ?
?  ?? frmMyTickets.Designer.cs ?
?? SQL_Scripts/
?  ?? CreateShoppingTables.sql ?
?? SHOPPING_FEATURE_GUIDE.md ?
```

## ?? Database Schema

### Concerts Table
```
ConcertID (INT, PK, Identity)
ArtistID (INT, FK ? Users)
Name (NVARCHAR(255))
Description (NVARCHAR(MAX))
Venue (NVARCHAR(255))
ConcertDate (DATETIME)
PosterImage (NVARCHAR(MAX))
TotalTickets (INT)
AvailableTickets (INT) ? C?p nh?t khi mua vé
Price (DECIMAL)
TicketType (INT) 0=NoSeat, 1=WithSeat
IsActive (BIT) 1=Active, 0=Deleted
CreatedDate (DATETIME)
```

### Tickets Table
```
TicketID (INT, PK, Identity)
ConcertID (INT, FK ? Concerts)
UserID (INT, FK ? Users)
TicketCode (NVARCHAR(5), UNIQUE)
PurchaseDate (DATETIME)
Price (DECIMAL)
Status (NVARCHAR(20)) Active/Expired/Used
TicketType (INT) 0=NoSeat, 1=WithSeat
SeatClass (NVARCHAR(20)) VIP/Standard/Economy
QRCodeImage (NVARCHAR(MAX)) ???ng d?n file PNG
```

## ?? Cách S? D?ng

### 1. Setup Database
```sql
-- Ch?y SQL script
SQL_Scripts\CreateShoppingTables.sql
```

### 2. Ng??i Dùng Mua Vé
```
Main Form ? Nút "Shopping"
    ?
ucShopping (Danh sách concert)
    ?
Click "Mua vé" trên concert
    ?
frmBuying (Ch?n s? l??ng, h?ng gh?)
    ?
Click "Mua vé"
    ?
Vé ???c l?u, QR code ???c t?o
```

### 3. Xem Vé ?ã Mua
```
ucShopping ? Click "Vé c?a tôi"
    ?
frmMyTickets (Danh sách vé)
    ?
Click "Xem QR Code" ho?c "T?i QR Code"
```

## ?? Code Examples

### T?o Concert
```csharp
var concert = new Concert
{
    ArtistID = artistID,
    Name = "Summer Concert 2024",
    Venue = "Sân v?n ??ng Th?ng Nh?t",
    ConcertDate = DateTime.Now.AddMonths(3),
    TotalTickets = 1000,
    AvailableTickets = 1000,
    Price = 150000,
    TicketType = 1, // 1 = Có s?p ch?
    IsActive = true
};

var service = new ConcertService();
int concertID = service.CreateConcert(concert);
```

### Mua Vé
```csharp
var ticketService = new TicketService();

// Mua 1 vé h?ng VIP
int ticketID = ticketService.BuyTicket(
    concertID: 1,
    userID: 123,
    seatClass: "VIP"
);

// N?u không s?p ch?
int ticketID = ticketService.BuyTicket(
    concertID: 2,
    userID: 123,
    seatClass: ""
);
```

### L?y Vé C?a User
```csharp
var ticketService = new TicketService();
var myTickets = ticketService.GetUserTickets(userID: 123);

foreach (var ticket in myTickets)
{
    Console.WriteLine($"{ticket.ConcertName} - {ticket.TicketCode}");
    Console.WriteLine($"H?ng: {ticket.SeatClass}");
    Console.WriteLine($"Giá: {ticket.Price}?");
}
```

### Ki?m Tra Vé H?t H?n
```csharp
var ticket = ticketService.GetTicketById(ticketID);

if (ticketService.IsTicketExpired(ticket))
{
    Console.WriteLine("Vé này ?ã h?t h?n");
}
```

## ?? Giao Di?n

### ucShopping
- **Tiêu ??**: ?? MUA VÉ CONCERT
- **Nút**: ?? Vé c?a tôi | ?? Làm m?i
- **Danh sách**: FlowLayout hi?n th? concert cards

### ucConcertCard
- **Size**: 470×220px
- **Poster**: 180×180px (?nh)
- **Info**: Tên, ngh? s?, ngày, ??a ?i?m, giá
- **Nút**: Chi ti?t (xanh) | Mua vé (teal)

### frmBuying
- **Size**: 600×500px
- **Input**: S? l??ng, h?ng gh?
- **Output**: T?ng giá
- **Nút**: Mua vé (teal) | H?y

### frmMyTickets
- **Danh sách**: Card-based
- **Card size**: 850×200px
- **Nút**: Xem QR Code | T?i QR Code

## ? Tính N?ng N?i B?t

? **Mã Vé Duy Nh?t** - 5 ch? s? ng?u nhiên, không trùng  
? **QR Code T? ??ng** - T?o PNG khi mua vé  
? **H?ng Gh? Linh Ho?t** - VIP/Standard/Economy v?i giá khác nhau  
? **Vé H?t H?n T? ??ng** - ?n khi concert ?ã di?n ra  
? **Giao Di?n ??p** - Emojis, màu s?c, layout hi?n ??i  
? **T?i QR Code** - L?u file PNG cho khách hàng  
? **Ki?m Soát Vé** - Gi?i h?n s? l??ng vé  

## ?? B?o M?t

- Mã vé: UNIQUE constraint
- TicketCode không th? trùng l?p
- Ki?m tra s? vé tr??c mua
- Ki?m tra user ID khi xem vé
- Soft delete cho concert

## ?? M? R?ng Trong T??ng Lai

### Phase 2
- [ ] H? th?ng gh? chi ti?t (A1, A2, B1, v.v.)
- [ ] Thanh toán tr?c tuy?n (MoMo, VNPay)
- [ ] G?i ý concert d?a trên l?ch s?

### Phase 3
- [ ] Share vé cho b?n
- [ ] Review concert
- [ ] Chuy?n nh??ng vé
- [ ] Hoàn ti?n vé

## ?? G? L?i

**V?n ??**: QR Code không xu?t hi?n
- ? Ki?m tra th? m?c `QRCodes` t?n t?i
- ? Ki?m tra quy?n write
- ? Ki?m tra file path

**V?n ??**: Vé không ???c l?u
- ? Ki?m tra s? vé còn l?i > 0
- ? Ki?m tra database connection
- ? Ki?m tra TicketCode duy nh?t

**V?n ??**: Vé c? không ?n
- ? C?p nh?t ConcertDate chính xác
- ? Reload page
- ? Ki?m tra logic `IsTicketExpired()`

## ?? H? Tr?

Xem chi ti?t: `SHOPPING_FEATURE_GUIDE.md`

---

## ?? L?u Ý

- Th? m?c `QRCodes/` s? ???c t?o t? ??ng
- TicketCode là 5 ch? s?: 10000-99999
- Giá vé ???c tính theo h?ng gh? (n?u có)
- Concert c? ???c soft-delete (IsActive = 0)

## ? Hoàn Thành

- [x] Models & Database
- [x] Services & Repositories
- [x] UI Components & Forms
- [x] QR Code Generation
- [x] Mã Vé Duy Nh?t
- [x] H?ng Gh?
- [x] Vé H?t H?n
- [x] Xem & T?i QR Code

---

**?? Ph?n Shopping ?ã hoàn thành và s?n sàng s? d?ng!**
