-- SQL Script ?? t?o b?ng Concerts và Tickets

-- Ki?m tra và xóa b?ng c? (n?u có)
IF OBJECT_ID('Tickets', 'U') IS NOT NULL
    DROP TABLE Tickets;

IF OBJECT_ID('Concerts', 'U') IS NOT NULL
    DROP TABLE Concerts;

-- T?o b?ng Concerts
CREATE TABLE Concerts (
    ConcertID INT PRIMARY KEY IDENTITY(1,1),
    ArtistID INT NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Venue NVARCHAR(255) NOT NULL,
    ConcertDate DATETIME NOT NULL,
    PosterImage NVARCHAR(MAX),
    TotalTickets INT NOT NULL,
    AvailableTickets INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    TicketType INT DEFAULT 0,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ArtistID) REFERENCES Users(UserID)
);

-- T?o b?ng Tickets
CREATE TABLE Tickets (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    ConcertID INT NOT NULL,
    UserID INT NOT NULL,
    TicketCode NVARCHAR(5) NOT NULL UNIQUE,
    PurchaseDate DATETIME NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Active',
    TicketType INT,
    SeatClass NVARCHAR(20),
    QRCodeImage NVARCHAR(MAX),
    FOREIGN KEY (ConcertID) REFERENCES Concerts(ConcertID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- T?o ch? m?c
CREATE INDEX IX_Concerts_ArtistID ON Concerts(ArtistID);
CREATE INDEX IX_Concerts_IsActive_ConcertDate ON Concerts(IsActive, ConcertDate);
CREATE INDEX IX_Tickets_UserID ON Tickets(UserID);
CREATE INDEX IX_Tickets_ConcertID ON Tickets(ConcertID);
CREATE INDEX IX_Tickets_TicketCode ON Tickets(TicketCode);

-- D? li?u m?u (có th? xóa sau khi test)
-- INSERT INTO Concerts (ArtistID, Name, Description, Venue, ConcertDate, TotalTickets, AvailableTickets, Price, TicketType)
-- VALUES 
-- (1, 'Summer Festival 2024', 'L? h?i âm nh?c hè', 'Sân v?n ??ng Th?ng Nh?t', DATEADD(MONTH, 3, GETDATE()), 1000, 1000, 150000, 1),
-- (2, 'Rock Night', '?êm nh?c rock', 'Tháp tài chính Bitexco', DATEADD(MONTH, 2, GETDATE()), 500, 500, 100000, 0);

PRINT 'B?ng Concerts và Tickets ?ã ???c t?o thành công!';
