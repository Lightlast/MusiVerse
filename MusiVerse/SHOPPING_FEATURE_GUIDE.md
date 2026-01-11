# Shopping Feature Implementation Guide

## ?? T?ng Quan

Ph?n Shopping cho phép ng??i dùng mua vé concert và qu?n lý vé c?a mình. Ch? có m?t lo?i hàng hóa ?o: **Vé Concert**.

---

## ?? C?u Trúc H? Th?ng

### Models
- **Concert.cs** - Thông tin concert
  - ConcertID, ArtistID, Name, Description
  - Venue, ConcertDate, PosterImage
  - TotalTickets, AvailableTickets
  - Price, TicketType (0 = Không s?p ch?, 1 = Có s?p ch?)
  
- **Ticket.cs** - Thông tin vé
  - TicketID, ConcertID, UserID
  - TicketCode (mã 5 ch? s? duy nh?t)
  - PurchaseDate, Price, Status
  - TicketType, SeatClass (VIP/Standard/Economy)
  - QRCodeImage (???ng d?n file QR code)

### Services
- **ConcertService** - Qu?n lý concert
- **TicketService** - Qu?n lý vé
  - T?o mã vé ng?u nhiên (5 ch? s?)
  - T?o QR code
  - Mua vé
  - Qu?n lý tr?ng thái vé

### Repositories
- **ConcertRepository** - Truy c?p CSDL concert
- **TicketRepository** - Truy c?p CSDL vé

### UI Components
- **ucShopping** - Trang chính shopping
  - Hi?n th? danh sách concert
  - Nút "Vé c?a tôi"
  - Nút "Làm m?i"

- **ucConcertCard** - Card hi?n th? concert
  - Poster, tên, ngh? s?
  - Ngày, ??a ?i?m
  - Giá, s? vé còn l?i
  - Lo?i vé
  - Nút "Chi ti?t" và "Mua vé"

- **frmBuying** - Form mua vé
  - Hi?n th? thông tin concert
  - Ch?n s? l??ng vé
  - Ch?n h?ng gh? (n?u có s?p ch?)
  - Tính t?ng giá
  - Nút "Mua vé"

- **frmMyTickets** - Xem vé ?ã mua
  - Danh sách vé còn hi?u l?c
  - Thông tin vé (concert, ngày, mã vé)
  - Nút "Xem QR Code"
  - Nút "T?i QR Code"

- **frmConcertDetail** - Chi ti?t concert
  - Thông tin ??y ??
  - Poster l?n
  - Mô t? chi ti?t

---

## ?? Lo?i Vé

### 1. Vé Không S?p Ch? (TicketType = 0)
- Giá c? ??nh
- Không có h?ng gh?
- S? l??ng gi?i h?n

### 2. Vé Có S?p Ch? (TicketType = 1)
Có 3 h?ng gh?:
- **VIP** - 150% giá g?c (gh? t?t nh?t)
- **Standard** - 100% giá g?c (gh? th??ng)
- **Economy** - 70% giá g?c (gh? phía sau)

---

## ?? Mã Vé & QR Code

### Mã Vé
- 5 ch? s? ng?u nhiên
- Duy nh?t cho m?i vé
- ???c hi?n th? trên vé

### QR Code
- File PNG ???c l?u trong th? m?c `QRCodes`
- ???c t?o khi mua vé
- Có th? xem và t?i xu?ng
- Ch?a mã vé 5 ch? s?

Cách t?o QR:
```
QRCodes/
??? QR_12345.png
```

---

## ? Hi?u L?c Vé

### Vé Còn Hi?u L?c
- Concert date > Ngày hi?n t?i
- Status = "Active"

### Vé H?t H?n
- Concert date <= Ngày hi?n t?i
- T? ??ng ?n kh?i danh sách
- Có th? xem l?ch s?

---

## ?? Quy Trình Mua Vé

1. **Ng??i dùng vào trang Shopping**
   - Xem danh sách concert
   - L?c theo ngày, giá, v.v.

2. **Ch?n Concert & Click "Mua vé"**
   - M? form frmBuying
   - Hi?n th? thông tin concert

3. **Ch?n S? L??ng & H?ng Gh?**
   - NumericUpDown ?? ch?n s? l??ng
   - ComboBox ?? ch?n h?ng gh? (n?u có)
   - T? ??ng tính t?ng giá

4. **Click "Mua vé"**
   - T?o mã vé duy nh?t
   - T?o QR code
   - L?u vào CSDL
   - C?p nh?t s? vé còn l?i
   - Hi?n th? thông báo thành công

5. **Xem Vé**
   - Vào "Vé c?a tôi"
   - Xem danh sách vé
   - Xem QR code
   - T?i xu?ng QR code

---

## ?? Lu?ng D? Li?u

```
User ? Click "Mua vé"
       ?
    frmBuying
       ?
    TicketService.BuyTicket()
       ?? Generate TicketCode (5 digits)
       ?? Generate QRCode (PNG file)
       ?? Create Ticket record
       ?? Update Concert.AvailableTickets
       ?? Return TicketID
       ?
    Save to Database
       ?? Tickets table
       ?? Concert.AvailableTickets updated
       ?
    User sees "Thành công!"
```

---

## ?? Database Tables

### Concerts Table
```sql
CREATE TABLE Concerts (
    ConcertID INT PRIMARY KEY IDENTITY(1,1),
    ArtistID INT,
    Name NVARCHAR(255),
    Description NVARCHAR(MAX),
    Venue NVARCHAR(255),
    ConcertDate DATETIME,
    PosterImage NVARCHAR(MAX),
    TotalTickets INT,
    AvailableTickets INT,
    Price DECIMAL(10,2),
    TicketType INT DEFAULT 0,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ArtistID) REFERENCES Users(UserID)
)
```

### Tickets Table
```sql
CREATE TABLE Tickets (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    ConcertID INT,
    UserID INT,
    TicketCode NVARCHAR(5) UNIQUE,
    PurchaseDate DATETIME,
    Price DECIMAL(10,2),
    Status NVARCHAR(20),
    TicketType INT,
    SeatClass NVARCHAR(20),
    QRCodeImage NVARCHAR(MAX),
    FOREIGN KEY (ConcertID) REFERENCES Concerts(ConcertID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)
```

---

## ?? UI Design

### ucShopping
- Panel top: Tiêu ??, "Vé c?a tôi", "Làm m?i"
- FlowLayoutPanel: Danh sách concert cards

### ucConcertCard
- 200x180: Poster
- Thông tin concert bên c?nh
- Hai nút: "Chi ti?t", "Mua vé"

### frmBuying
- Thông tin concert c? ??nh
- Ch?n s? l??ng
- Ch?n h?ng gh? (n?u có)
- Tính t?ng
- Nút "Mua vé" / "H?y"

### frmMyTickets
- Danh sách vé d?ng card
- M?i card: Tên concert, ngày, mã vé, h?ng gh?
- Hai nút: "Xem QR Code", "T?i QR Code"

---

## ?? B?o M?t

- Mã vé duy nh?t (UNIQUE constraint)
- Ki?m tra s? vé còn l?i tr??c khi mua
- Ki?m tra user ID khi xem vé
- Soft delete cho concert (IsActive = 0)

---

## ?? M? R?ng Trong T??ng Lai

### 1. H? Th?ng Gh?
- L?u gh? c? th? (A1, A2, B1, v.v.)
- T?o s? ?? gh?
- Ch?n gh? khi mua

### 2. Thanh Toán Tr?c Tuy?n
- Tích h?p MoMo, VNPay
- Xác minh thanh toán
- Ghi nh?n doanh thu

### 3. Qu?n Lý Concert (Ngh? S?)
- Form t?o concert
- Ch?nh s?a concert
- Xem th?ng kê vé bán

### 4. Review & Rating
- Cho phép review concert
- Rating sau khi di?n ra

### 5. G?i Ý Concert
- D?a trên l?ch s? mua
- D?a trên theo dõi ngh? s?

---

## ?? H??ng D?n S? D?ng Cho Developer

### T?o Concert (Admin/Artist)
```csharp
var concert = new Concert
{
    ArtistID = artistID,
    Name = "Concert Name",
    Venue = "Venue",
    ConcertDate = DateTime.Now.AddDays(30),
    TotalTickets = 1000,
    Price = 50000,
    TicketType = 1 // 0 = No seat, 1 = With seat
};

var concertService = new ConcertService();
int concertID = concertService.CreateConcert(concert);
```

### Mua Vé
```csharp
var ticketService = new TicketService();
int ticketID = ticketService.BuyTicket(
    concertID: 1,
    userID: 123,
    seatClass: "VIP"
);
```

### L?y Vé C?a User
```csharp
var ticketService = new TicketService();
var tickets = ticketService.GetUserTickets(userID);
```

### Ki?m Tra Vé H?t H?n
```csharp
bool isExpired = ticketService.IsTicketExpired(ticket);
```

---

## ? Danh Sách Ki?m Tra

- [x] Models (Concert, Ticket)
- [x] Repositories (ConcertRepository, TicketRepository)
- [x] Services (ConcertService, TicketService)
- [x] UI Components (ucShopping, ucConcertCard)
- [x] Forms (frmBuying, frmMyTickets, frmConcertDetail)
- [x] T?o mã vé (5 ch? s?)
- [x] T?o QR code
- [x] Hi?u l?c vé
- [x] H?ng gh? (VIP/Standard/Economy)
- [x] Tính giá theo h?ng gh?

---

## ?? Troubleshooting

### QR Code không hi?n th?
- Ki?m tra th? m?c `QRCodes` t?n t?i
- Ki?m tra quy?n write folder
- Ki?m tra file path trong database

### Vé không ???c l?u
- Ki?m tra Concert còn vé (`AvailableTickets > 0`)
- Ki?m tra database connection
- Ki?m tra TicketCode duy nh?t

### Vé h?t h?n không ?n
- C?p nh?t Concert date chính xác
- Ki?m tra `IsTicketExpired()` logic
- Reload page sau khi concert di?n ra

---

## ?? Liên H? & H? Tr?

N?u có v?n ??, ki?m tra:
1. Database tables t?n t?i
2. Connection string chính xác
3. QRCodes folder t?n t?i
4. User ID h?p l?

---

## ?? Phiên B?n

- **v1.0** - Hoàn thành tính n?ng c? b?n
  - Mua vé
  - Xem vé
  - QR code
  - H?ng gh?
  - Vé h?t h?n

---

**Happy Coding! ????**
