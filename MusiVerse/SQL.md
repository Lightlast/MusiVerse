-- ==========================================
-- MUSIVERSE DATABASE SCHEMA - PHIÊN BẢN HOÀN CHỈNH
-- Tính năng: Nghe nhạc + Social + Concert + VIP (No Ads)
-- ==========================================

USE MusiverseDB;
GO

-- ==========================================
-- 1. BẢNG CHÍNH
-- ==========================================

-- Bảng Users
IF OBJECT_ID('Users', 'U') IS NOT NULL DROP TABLE Users;
CREATE TABLE Users (
    UserID        INT PRIMARY KEY IDENTITY(1,1),
    Username      NVARCHAR(50)  UNIQUE NOT NULL,
    Password      NVARCHAR(255) NOT NULL,        -- Nên hash (bcrypt/SHA256)
    Email         NVARCHAR(100) UNIQUE NOT NULL,
    FullName      NVARCHAR(100),
    Avatar        NVARCHAR(255),                 -- Đường dẫn ảnh đại diện
    Role          NVARCHAR(20)  CHECK (Role IN ('User', 'Artist', 'IndieArtist', 'Admin')) DEFAULT 'User',
    Bio           NVARCHAR(500),
    HasVIP        BIT           DEFAULT 0,       -- VIP: không quảng cáo
    VIPExpiryDate DATETIME      NULL,            -- Ngày hết hạn VIP
    CreatedDate   DATETIME      DEFAULT GETDATE(),
    IsActive      BIT           DEFAULT 1
);

-- Bảng Songs
CREATE TABLE Songs (
    SongID      INT PRIMARY KEY IDENTITY(1,1),
    Title       NVARCHAR(200) NOT NULL,
    ArtistID    INT FOREIGN KEY REFERENCES Users(UserID),
    Duration    INT,                           -- giây
    FilePath    NVARCHAR(255) NOT NULL,
    CoverImage  NVARCHAR(255),
    Genre       NVARCHAR(50),
    ReleaseDate DATETIME      DEFAULT GETDATE(),
    PlayCount   INT           DEFAULT 0,
    IsActive    BIT           DEFAULT 1
);

-- Bảng Playlists
CREATE TABLE Playlists (
    PlaylistID   INT PRIMARY KEY IDENTITY(1,1),
    UserID       INT FOREIGN KEY REFERENCES Users(UserID),
    Name         NVARCHAR(100) NOT NULL,
    Description  NVARCHAR(500),
    CoverImage   NVARCHAR(255),
    IsPublic     BIT           DEFAULT 1,
    CreatedDate  DATETIME      DEFAULT GETDATE()
);

-- Bảng PlaylistSongs (nhiều-nhiều)
CREATE TABLE PlaylistSongs (
    PlaylistSongID INT PRIMARY KEY IDENTITY(1,1),
    PlaylistID     INT FOREIGN KEY REFERENCES Playlists(PlaylistID) ON DELETE CASCADE,
    SongID         INT FOREIGN KEY REFERENCES Songs(SongID) ON DELETE CASCADE,
    OrderIndex     INT           DEFAULT 0,
    AddedDate      DATETIME      DEFAULT GETDATE()
);

-- Bảng LikedSongs (Yêu thích)
CREATE TABLE LikedSongs (
    LikedSongID INT PRIMARY KEY IDENTITY(1,1),
    UserID      INT FOREIGN KEY REFERENCES Users(UserID),
    SongID      INT FOREIGN KEY REFERENCES Songs(SongID) ON DELETE CASCADE,
    LikedDate   DATETIME      DEFAULT GETDATE(),
    UNIQUE(UserID, SongID)
);

-- Bảng Posts (Social)
CREATE TABLE Posts (
    PostID      INT PRIMARY KEY IDENTITY(1,1),
    UserID      INT FOREIGN KEY REFERENCES Users(UserID),
    Content     NVARCHAR(MAX),
    MediaPath   NVARCHAR(255),
    MediaType   NVARCHAR(10) CHECK (MediaType IN ('Image', 'Video', NULL)),
    CreatedDate DATETIME     DEFAULT GETDATE(),
    LikeCount   INT          DEFAULT 0,
    CommentCount INT         DEFAULT 0,
    ShareCount  INT          DEFAULT 0,
    IsActive    BIT          DEFAULT 1
);

-- Bảng Comments
CREATE TABLE Comments (
    CommentID   INT PRIMARY KEY IDENTITY(1,1),
    PostID      INT FOREIGN KEY REFERENCES Posts(PostID) ON DELETE CASCADE,
    UserID      INT FOREIGN KEY REFERENCES Users(UserID),
    Content     NVARCHAR(500) NOT NULL,
    CreatedDate DATETIME      DEFAULT GETDATE(),
    IsActive    BIT           DEFAULT 1
);

-- Bảng PostLikes
CREATE TABLE PostLikes (
    LikeID    INT PRIMARY KEY IDENTITY(1,1),
    PostID    INT FOREIGN KEY REFERENCES Posts(PostID) ON DELETE CASCADE,
    UserID    INT FOREIGN KEY REFERENCES Users(UserID),
    LikeDate  DATETIME DEFAULT GETDATE(),
    UNIQUE(PostID, UserID)
);

-- Bảng PostSaves (Lưu bài đăng)
CREATE TABLE PostSaves (
    SaveID    INT PRIMARY KEY IDENTITY(1,1),
    PostID    INT FOREIGN KEY REFERENCES Posts(PostID) ON DELETE CASCADE,
    UserID    INT FOREIGN KEY REFERENCES Users(UserID),
    SaveDate  DATETIME DEFAULT GETDATE(),
    UNIQUE(PostID, UserID)
);

-- Bảng PostShares
CREATE TABLE PostShares (
    ShareID   INT PRIMARY KEY IDENTITY(1,1),
    PostID    INT FOREIGN KEY REFERENCES Posts(PostID) ON DELETE CASCADE,
    UserID    INT FOREIGN KEY REFERENCES Users(UserID),
    ShareDate DATETIME DEFAULT GETDATE()
);

-- Bảng Concerts
CREATE TABLE Concerts (
    ConcertID        INT PRIMARY KEY IDENTITY(1,1),
    ArtistID         INT FOREIGN KEY REFERENCES Users(UserID),
    Name             NVARCHAR(200) NOT NULL,
    Description      NVARCHAR(MAX),
    Venue            NVARCHAR(200),
    ConcertDate      DATETIME NOT NULL,
    PosterImage      NVARCHAR(255),
    TotalTickets     INT NOT NULL,
    AvailableTickets INT NOT NULL,
    Price            DECIMAL(18,2) NOT NULL,
    CreatedDate      DATETIME DEFAULT GETDATE(),
    IsActive         BIT DEFAULT 1
);

-- Bảng Tickets
CREATE TABLE Tickets (
    TicketID     INT PRIMARY KEY IDENTITY(1,1),
    ConcertID    INT FOREIGN KEY REFERENCES Concerts(ConcertID),
    UserID       INT FOREIGN KEY REFERENCES Users(UserID),
    TicketCode   NVARCHAR(50) UNIQUE NOT NULL,
    PurchaseDate DATETIME DEFAULT GETDATE(),
    Price        DECIMAL(18,2) NOT NULL,
    Status       NVARCHAR(20) CHECK (Status IN ('Active', 'Used', 'Cancelled')) DEFAULT 'Active'
);

-- Bảng Followers
CREATE TABLE Followers (
    FollowerID INT PRIMARY KEY IDENTITY(1,1),
    ArtistID   INT FOREIGN KEY REFERENCES Users(UserID),
    UserID     INT FOREIGN KEY REFERENCES Users(UserID),
    FollowDate DATETIME DEFAULT GETDATE(),
    UNIQUE(ArtistID, UserID)
);

-- ==========================================
-- 2. BẢNG VIP
-- ==========================================

-- Bảng VIPTransactions (Lịch sử mua VIP)
CREATE TABLE VIPTransactions (
    TransactionID   INT PRIMARY KEY IDENTITY(1,1),
    UserID          INT FOREIGN KEY REFERENCES Users(UserID),
    PackageType     NVARCHAR(20) CHECK (PackageType IN ('Monthly', 'Yearly')),
    Amount          DECIMAL(18,2) NOT NULL,
    PaymentMethod   NVARCHAR(50),
    TransactionDate DATETIME DEFAULT GETDATE(),
    StartDate       DATETIME NOT NULL,
    EndDate         DATETIME NOT NULL,
    Status          NVARCHAR(20) CHECK (Status IN ('Pending', 'Success', 'Failed')) DEFAULT 'Pending',
    TransactionCode NVARCHAR(100) UNIQUE
);

-- ==========================================
-- 3. INDEXES TỐI ƯU
-- ==========================================

CREATE INDEX IX_Songs_ArtistID          ON Songs(ArtistID);
CREATE INDEX IX_Playlists_UserID        ON Playlists(UserID);
CREATE INDEX IX_Posts_UserID            ON Posts(UserID);
CREATE INDEX IX_Posts_CreatedDate       ON Posts(CreatedDate DESC);
CREATE INDEX IX_Comments_PostID         ON Comments(PostID);
CREATE INDEX IX_PostLikes_PostID        ON PostLikes(PostID);
CREATE INDEX IX_PostSaves_PostID        ON PostSaves(PostID);
CREATE INDEX IX_Concerts_ArtistID       ON Concerts(ArtistID);
CREATE INDEX IX_Concerts_ConcertDate    ON Concerts(ConcertDate);
CREATE INDEX IX_VIPTransactions_UserID  ON VIPTransactions(UserID);

-- ==========================================
-- 4. STORED PROCEDURES VIP
-- ==========================================

-- Mua VIP mới
CREATE OR ALTER PROCEDURE sp_PurchaseVIP
    @UserID         INT,
    @PackageType    NVARCHAR(20),
    @PaymentMethod  NVARCHAR(50),
    @TransactionCode NVARCHAR(100)
AS
BEGIN
    DECLARE @Amount DECIMAL(18,2), @StartDate DATETIME = GETDATE(), @EndDate DATETIME;

    IF @PackageType = 'Monthly'  BEGIN SET @Amount = 59000; SET @EndDate = DATEADD(MONTH, 1, @StartDate); END
    ELSE IF @PackageType = 'Yearly' BEGIN SET @Amount = 590000; SET @EndDate = DATEADD(YEAR, 1, @StartDate); END
    ELSE RAISERROR('Invalid package type', 16, 1);

    BEGIN TRANSACTION;
    INSERT INTO VIPTransactions (UserID, PackageType, Amount, PaymentMethod, StartDate, EndDate, Status, TransactionCode)
    VALUES (@UserID, @PackageType, @Amount, @PaymentMethod, @StartDate, @EndDate, 'Success', @TransactionCode);

    UPDATE Users SET HasVIP = 1, VIPExpiryDate = @EndDate WHERE UserID = @UserID;
    COMMIT TRANSACTION;

    SELECT 'SUCCESS' AS Result, @Amount AS Amount, @EndDate AS ExpiryDate;
END
GO

-- Gia hạn VIP
CREATE OR ALTER PROCEDURE sp_RenewVIP
    @UserID         INT,
    @PackageType    NVARCHAR(20),
    @PaymentMethod  NVARCHAR(50),
    @TransactionCode NVARCHAR(100)
AS
BEGIN
    DECLARE @CurrentExpiry DATETIME, @NewExpiry DATETIME, @Amount DECIMAL(18,2);

    SELECT @CurrentExpiry = VIPExpiryDate FROM Users WHERE UserID = @UserID;
    IF @CurrentExpiry IS NULL OR @CurrentExpiry < GETDATE() SET @CurrentExpiry = GETDATE();

    IF @PackageType = 'Monthly'  BEGIN SET @Amount = 59000; SET @NewExpiry = DATEADD(MONTH, 1, @CurrentExpiry); END
    ELSE IF @PackageType = 'Yearly' BEGIN SET @Amount = 590000; SET @NewExpiry = DATEADD(YEAR, 1, @CurrentExpiry); END

    BEGIN TRANSACTION;
    INSERT INTO VIPTransactions (UserID, PackageType, Amount, PaymentMethod, StartDate, EndDate, Status, TransactionCode)
    VALUES (@UserID, @PackageType, @Amount, @PaymentMethod, @CurrentExpiry, @NewExpiry, 'Success', @TransactionCode);

    UPDATE Users SET HasVIP = 1, VIPExpiryDate = @NewExpiry WHERE UserID = @UserID;
    COMMIT TRANSACTION;

    SELECT 'SUCCESS' AS Result, @NewExpiry AS ExpiryDate;
END
GO

-- Kiểm tra và hủy VIP hết hạn
CREATE OR ALTER PROCEDURE sp_CheckExpiredVIP
AS
BEGIN
    UPDATE Users SET HasVIP = 0 WHERE HasVIP = 1 AND VIPExpiryDate < GETDATE();
    SELECT @@ROWCOUNT AS ExpiredCount;
END
GO

-- Lấy thông tin VIP user
CREATE OR ALTER PROCEDURE sp_GetVIPInfo
    @UserID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Users WHERE UserID = @UserID AND HasVIP = 1 AND VIPExpiryDate < GETDATE())
        UPDATE Users SET HasVIP = 0 WHERE UserID = @UserID;

    SELECT UserID, HasVIP, VIPExpiryDate,
           CASE WHEN HasVIP = 1 THEN DATEDIFF(DAY, GETDATE(), VIPExpiryDate) ELSE 0 END AS DaysRemaining
    FROM Users WHERE UserID = @UserID;
END
GO

-- Lấy lịch sử mua VIP
CREATE OR ALTER PROCEDURE sp_GetVIPHistory
    @UserID INT
AS
BEGIN
    SELECT TransactionID, PackageType, Amount, PaymentMethod, TransactionDate, StartDate, EndDate, Status
    FROM VIPTransactions
    WHERE UserID = @UserID
    ORDER BY TransactionDate DESC;
END
GO

-- ==========================================
-- 5. DỮ LIỆU MẪU (TEST)
-- ==========================================

INSERT INTO Users (Username, Password, Email, FullName, Role) VALUES
('admin', 'admin123', 'admin@musiverse.com', N'Administrator', 'Admin'),
('sontung', 'pass123', 'sontung@musiverse.com', N'Sơn Tùng M-TP', 'Artist'),
('user1', 'pass123', 'user1@gmail.com', N'Nguyễn Văn A', 'User');

PRINT '==================================';
PRINT 'Musiverse Database setup HOÀN TẤT!';
PRINT 'Tính năng VIP + Social đầy đủ';
PRINT 'Chạy được ngay, bro ơi!';
PRINT '==================================';