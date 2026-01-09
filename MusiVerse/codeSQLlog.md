-- ==========================================
-- MUSIVERSE DATABASE SCHEMA
-- ==========================================

-- Bảng Users (Người dùng)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL, -- Nên hash bằng SHA256 hoặc bcrypt
    Email NVARCHAR(100) UNIQUE NOT NULL,
    FullName NVARCHAR(100),
    Avatar NVARCHAR(255), -- Đường dẫn file ảnh
    Role NVARCHAR(20) CHECK (Role IN ('User', 'Artist', 'IndieArtist', 'Admin')) DEFAULT 'User',
    Bio NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

-- Bảng Songs (Bài hát)
CREATE TABLE Songs (
    SongID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    ArtistID INT FOREIGN KEY REFERENCES Users(UserID),
    Duration INT, -- Thời lượng (giây)
    FilePath NVARCHAR(255) NOT NULL, -- Đường dẫn file nhạc
    CoverImage NVARCHAR(255), -- Ảnh bìa
    Genre NVARCHAR(50),
    ReleaseDate DATETIME DEFAULT GETDATE(),
    PlayCount INT DEFAULT 0,
    IsActive BIT DEFAULT 1
);

-- Bảng Playlists
CREATE TABLE Playlists (
    PlaylistID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    CoverImage NVARCHAR(255),
    IsPublic BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Bảng PlaylistSongs (Quan hệ nhiều-nhiều)
CREATE TABLE PlaylistSongs (
    PlaylistSongID INT PRIMARY KEY IDENTITY(1,1),
    PlaylistID INT FOREIGN KEY REFERENCES Playlists(PlaylistID) ON DELETE CASCADE,
    SongID INT FOREIGN KEY REFERENCES Songs(SongID) ON DELETE CASCADE,
    OrderIndex INT DEFAULT 0,
    AddedDate DATETIME DEFAULT GETDATE()
);

-- Bảng LikedSongs (Bài hát yêu thích)
CREATE TABLE LikedSongs (
    LikedSongID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    SongID INT FOREIGN KEY REFERENCES Songs(SongID) ON DELETE CASCADE,
    LikedDate DATETIME DEFAULT GETDATE(),
    UNIQUE(UserID, SongID)
);

-- Bảng Posts (Bài đăng social)
CREATE TABLE Posts (
    PostID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Content NVARCHAR(MAX),
    MediaPath NVARCHAR(255), -- Ảnh hoặc video
    MediaType NVARCHAR(10) CHECK (MediaType IN ('Image', 'Video')),
    CreatedDate DATETIME DEFAULT GETDATE(),
    LikeCount INT DEFAULT 0,
    CommentCount INT DEFAULT 0,
    ShareCount INT DEFAULT 0,
    IsActive BIT DEFAULT 1
);

-- Bảng PostLikes (Tim bài đăng)
CREATE TABLE PostLikes (
    PostLikeID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT FOREIGN KEY REFERENCES Posts(PostID) ON DELETE CASCADE,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    LikedDate DATETIME DEFAULT GETDATE(),
    UNIQUE(PostID, UserID)
);

-- Bảng Comments (Bình luận)
CREATE TABLE Comments (
    CommentID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT FOREIGN KEY REFERENCES Posts(PostID) ON DELETE CASCADE,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Content NVARCHAR(500) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

-- Bảng SavedPosts (Đánh dấu bài đăng)
CREATE TABLE SavedPosts (
    SavedPostID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    PostID INT FOREIGN KEY REFERENCES Posts(PostID) ON DELETE CASCADE,
    SavedDate DATETIME DEFAULT GETDATE(),
    UNIQUE(UserID, PostID)
);

-- Bảng Concerts (Concert/Sự kiện)
CREATE TABLE Concerts (
    ConcertID INT PRIMARY KEY IDENTITY(1,1),
    ArtistID INT FOREIGN KEY REFERENCES Users(UserID),
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    Venue NVARCHAR(200), -- Địa điểm
    ConcertDate DATETIME NOT NULL,
    PosterImage NVARCHAR(255),
    TotalTickets INT NOT NULL,
    AvailableTickets INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

-- Bảng Tickets (Vé)
CREATE TABLE Tickets (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    ConcertID INT FOREIGN KEY REFERENCES Concerts(ConcertID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    TicketCode NVARCHAR(50) UNIQUE NOT NULL,
    PurchaseDate DATETIME DEFAULT GETDATE(),
    Price DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(20) CHECK (Status IN ('Active', 'Used', 'Cancelled')) DEFAULT 'Active'
);

-- Bảng Followers (Theo dõi nghệ sĩ)
CREATE TABLE Followers (
    FollowerID INT PRIMARY KEY IDENTITY(1,1),
    ArtistID INT FOREIGN KEY REFERENCES Users(UserID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    FollowDate DATETIME DEFAULT GETDATE(),
    UNIQUE(ArtistID, UserID)
);

-- ==========================================
-- INDEXES để tối ưu hiệu suất
-- ==========================================

CREATE INDEX IX_Songs_ArtistID ON Songs(ArtistID);
CREATE INDEX IX_Playlists_UserID ON Playlists(UserID);
CREATE INDEX IX_Posts_UserID ON Posts(UserID);
CREATE INDEX IX_Posts_CreatedDate ON Posts(CreatedDate DESC);
CREATE INDEX IX_Concerts_ArtistID ON Concerts(ArtistID);
CREATE INDEX IX_Concerts_ConcertDate ON Concerts(ConcertDate);

-- ==========================================
-- DỮ LIỆU MẪU
-- ==========================================

-- Insert Admin
INSERT INTO Users (Username, Password, Email, FullName, Role) 
VALUES ('admin', 'admin123', 'admin@musiverse.com', N'Administrator', 'Admin');

-- Insert Artists
INSERT INTO Users (Username, Password, Email, FullName, Role, Bio) 
VALUES 
('sontung', 'pass123', 'sontung@musiverse.com', N'Sơn Tùng M-TP', 'Artist', N'Ca sĩ, nhạc sĩ Việt Nam'),
('mtp', 'pass123', 'mtp@musiverse.com', N'My Tam', 'Artist', N'Nữ hoàng nhạc pop'),
('indie_artist', 'pass123', 'indie@musiverse.com', N'Indie Artist', 'IndieArtist', N'Nghệ sĩ độc lập');

-- Insert Normal Users
INSERT INTO Users (Username, Password, Email, FullName, Role) 
VALUES 
('user1', 'pass123', 'user1@musiverse.com', N'Nguyễn Văn A', 'User'),
('user2', 'pass123', 'user2@musiverse.com', N'Trần Thị B', 'User');

-- ==========================================
-- BẢNG UPGRADE REQUESTS (OPTIONAL)
-- Dùng nếu muốn có quy trình Admin duyệt
-- ==========================================

CREATE TABLE UpgradeRequests (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    RequestedRole NVARCHAR(20) CHECK (RequestedRole IN ('Artist', 'IndieArtist')) NOT NULL,
    Reason NVARCHAR(500), -- Lý do muốn nâng cấp
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Approved', 'Rejected')) DEFAULT 'Pending',
    CreatedDate DATETIME DEFAULT GETDATE(),
    ReviewedBy INT FOREIGN KEY REFERENCES Users(UserID), -- Admin duyệt
    ReviewedDate DATETIME,
    ReviewNote NVARCHAR(500) -- Ghi chú của admin
);

-- Index để tìm nhanh
CREATE INDEX IX_UpgradeRequests_UserID ON UpgradeRequests(UserID);
CREATE INDEX IX_UpgradeRequests_Status ON UpgradeRequests(Status);

-- ==========================================
-- STORED PROCEDURES (Optional - Nâng cao)
-- ==========================================

-- SP: Tạo yêu cầu nâng cấp
CREATE PROCEDURE sp_CreateUpgradeRequest
    @UserID INT,
    @RequestedRole NVARCHAR(20),
    @Reason NVARCHAR(500)
AS
BEGIN
    -- Kiểm tra user đã có yêu cầu pending chưa
    IF EXISTS (SELECT 1 FROM UpgradeRequests 
               WHERE UserID = @UserID AND Status = 'Pending')
    BEGIN
        RAISERROR('Bạn đã có yêu cầu đang chờ duyệt', 16, 1)
        RETURN
    END

    -- Kiểm tra role hiện tại
    DECLARE @CurrentRole NVARCHAR(20)
    SELECT @CurrentRole = Role FROM Users WHERE UserID = @UserID

    IF @CurrentRole != 'User'
    BEGIN
        RAISERROR('Chỉ User mới có thể nâng cấp', 16, 1)
        RETURN
    END

    -- Tạo yêu cầu
    INSERT INTO UpgradeRequests (UserID, RequestedRole, Reason)
    VALUES (@UserID, @RequestedRole, @Reason)

    SELECT 'SUCCESS' AS Result
END
GO

-- SP: Admin duyệt yêu cầu
CREATE PROCEDURE sp_ApproveUpgradeRequest
    @RequestID INT,
    @AdminID INT,
    @ReviewNote NVARCHAR(500) = NULL
AS
BEGIN
    DECLARE @UserID INT, @RequestedRole NVARCHAR(20)

    -- Lấy thông tin request
    SELECT @UserID = UserID, @RequestedRole = RequestedRole
    FROM UpgradeRequests
    WHERE RequestID = @RequestID AND Status = 'Pending'

    IF @UserID IS NULL
    BEGIN
        RAISERROR('Không tìm thấy yêu cầu hoặc đã được xử lý', 16, 1)
        RETURN
    END

    BEGIN TRANSACTION

    -- Cập nhật role của user
    UPDATE Users
    SET Role = @RequestedRole
    WHERE UserID = @UserID

    -- Cập nhật status request
    UPDATE UpgradeRequests
    SET Status = 'Approved',
        ReviewedBy = @AdminID,
        ReviewedDate = GETDATE(),
        ReviewNote = @ReviewNote
    WHERE RequestID = @RequestID

    COMMIT TRANSACTION

    SELECT 'SUCCESS' AS Result
END
GO

-- SP: Admin từ chối yêu cầu
CREATE PROCEDURE sp_RejectUpgradeRequest
    @RequestID INT,
    @AdminID INT,
    @ReviewNote NVARCHAR(500)
AS
BEGIN
    UPDATE UpgradeRequests
    SET Status = 'Rejected',
        ReviewedBy = @AdminID,
        ReviewedDate = GETDATE(),
        ReviewNote = @ReviewNote
    WHERE RequestID = @RequestID AND Status = 'Pending'

    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('Không tìm thấy yêu cầu hoặc đã được xử lý', 16, 1)
        RETURN
    END

    SELECT 'SUCCESS' AS Result
END
GO

-- ==========================================
-- CÁCH SỬ DỤNG 2 OPTION
-- ==========================================

/*
OPTION 1: NÂNG CẤP TRỰC TIẾP (Đơn giản)
- User nhấn nút "Nâng cấp" → Nâng cấp ngay lập tức
- Không cần Admin duyệt
- Phù hợp cho đồ án nhỏ

Code trong frmUpgradeToArtist:
    userRepository.UpgradeToArtist(userID, newRole, bio);


OPTION 2: CẦN ADMIN DUYỆT (Chuyên nghiệp hơn)
- User submit yêu cầu → Admin xem và duyệt
- Có bảng UpgradeRequests
- Có thêm form Admin quản lý requests

Code trong frmUpgradeToArtist:
    userRepository.CreateUpgradeRequest(userID, newRole, reason);

Code trong frmAdminUpgradeManagement:
    // Duyệt
    EXEC sp_ApproveUpgradeRequest @RequestID, @AdminID, @Note
    
    // Từ chối
    EXEC sp_RejectUpgradeRequest @RequestID, @AdminID, @Note
*/

Cập nhật datbase
-- ==========================================
-- MUSIVERSE DATABASE SCHEMA
-- ==========================================

-- Bảng Users (Người dùng)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL, -- Nên hash bằng SHA256 hoặc bcrypt
    Email NVARCHAR(100) UNIQUE NOT NULL,
    FullName NVARCHAR(100),
    Avatar NVARCHAR(255), -- Đường dẫn file ảnh
    Role NVARCHAR(20) CHECK (Role IN ('User', 'Artist', 'IndieArtist', 'Admin')) DEFAULT 'User',
    Bio NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,
    -- ✅ THÊM: VIP Package (Không quảng cáo)
    HasVIP BIT DEFAULT 0,
    VIPExpiryDate DATETIME NULL -- Ngày hết hạn VIP
);

-- Bảng Songs (Bài hát)
CREATE TABLE Songs (
    SongID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    ArtistID INT FOREIGN KEY REFERENCES Users(UserID),
    Duration INT, -- Thời lượng (giây)
    FilePath NVARCHAR(255) NOT NULL, -- Đường dẫn file nhạc
    CoverImage NVARCHAR(255), -- Ảnh bìa
    Genre NVARCHAR(50),
    ReleaseDate DATETIME DEFAULT GETDATE(),
    PlayCount INT DEFAULT 0,
    IsActive BIT DEFAULT 1
);

-- Bảng Playlists
CREATE TABLE Playlists (
    PlaylistID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    CoverImage NVARCHAR(255),
    IsPublic BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Bảng PlaylistSongs (Quan hệ nhiều-nhiều)
CREATE TABLE PlaylistSongs (
    PlaylistSongID INT PRIMARY KEY IDENTITY(1,1),
    PlaylistID INT FOREIGN KEY REFERENCES Playlists(PlaylistID) ON DELETE CASCADE,
    SongID INT FOREIGN KEY REFERENCES Songs(SongID) ON DELETE CASCADE,
    OrderIndex INT DEFAULT 0,
    AddedDate DATETIME DEFAULT GETDATE()
);

-- Bảng LikedSongs (Bài hát yêu thích)
CREATE TABLE LikedSongs (
    LikedSongID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    SongID INT FOREIGN KEY REFERENCES Songs(SongID) ON DELETE CASCADE,
    LikedDate DATETIME DEFAULT GETDATE(),
    UNIQUE(UserID, SongID)
);

-- Bảng Posts (Bài đăng social)
CREATE TABLE Posts (
    PostID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Content NVARCHAR(MAX),
    MediaPath NVARCHAR(255), -- Ảnh hoặc video
    MediaType NVARCHAR(10) CHECK (MediaType IN ('Image', 'Video')),
    CreatedDate DATETIME DEFAULT GETDATE(),
    LikeCount INT DEFAULT 0,
    CommentCount INT DEFAULT 0,
    ShareCount INT DEFAULT 0,
    IsActive BIT DEFAULT 1
);

-- Bảng PostLikes (Tim bài đăng)
CREATE TABLE PostLikes (
    PostLikeID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT FOREIGN KEY REFERENCES Posts(PostID) ON DELETE CASCADE,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    LikedDate DATETIME DEFAULT GETDATE(),
    UNIQUE(PostID, UserID)
);

-- Bảng Comments (Bình luận)
CREATE TABLE Comments (
    CommentID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT FOREIGN KEY REFERENCES Posts(PostID) ON DELETE CASCADE,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Content NVARCHAR(500) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

-- Bảng SavedPosts (Đánh dấu bài đăng)
CREATE TABLE SavedPosts (
    SavedPostID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    PostID INT FOREIGN KEY REFERENCES Posts(PostID) ON DELETE CASCADE,
    SavedDate DATETIME DEFAULT GETDATE(),
    UNIQUE(UserID, PostID)
);

-- Bảng Concerts (Concert/Sự kiện)
CREATE TABLE Concerts (
    ConcertID INT PRIMARY KEY IDENTITY(1,1),
    ArtistID INT FOREIGN KEY REFERENCES Users(UserID),
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    Venue NVARCHAR(200), -- Địa điểm
    ConcertDate DATETIME NOT NULL,
    PosterImage NVARCHAR(255),
    TotalTickets INT NOT NULL,
    AvailableTickets INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

-- Bảng Tickets (Vé)
CREATE TABLE Tickets (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    ConcertID INT FOREIGN KEY REFERENCES Concerts(ConcertID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    TicketCode NVARCHAR(50) UNIQUE NOT NULL,
    PurchaseDate DATETIME DEFAULT GETDATE(),
    Price DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(20) CHECK (Status IN ('Active', 'Used', 'Cancelled')) DEFAULT 'Active'
);

-- Bảng Followers (Theo dõi nghệ sĩ)
CREATE TABLE Followers (
    FollowerID INT PRIMARY KEY IDENTITY(1,1),
    ArtistID INT FOREIGN KEY REFERENCES Users(UserID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    FollowDate DATETIME DEFAULT GETDATE(),
    UNIQUE(ArtistID, UserID)
);

-- ==========================================
-- INDEXES để tối ưu hiệu suất
-- ==========================================

CREATE INDEX IX_Songs_ArtistID ON Songs(ArtistID);
CREATE INDEX IX_Playlists_UserID ON Playlists(UserID);
CREATE INDEX IX_Posts_UserID ON Posts(UserID);
CREATE INDEX IX_Posts_CreatedDate ON Posts(CreatedDate DESC);
CREATE INDEX IX_Concerts_ArtistID ON Concerts(ArtistID);
CREATE INDEX IX_Concerts_ConcertDate ON Concerts(ConcertDate);

-- ==========================================
-- DỮ LIỆU MẪU
-- ==========================================

-- Insert Admin
INSERT INTO Users (Username, Password, Email, FullName, Role) 
VALUES ('admin', 'admin123', 'admin@musiverse.com', N'Administrator', 'Admin');

-- Insert Artists
INSERT INTO Users (Username, Password, Email, FullName, Role, Bio) 
VALUES 
('sontung', 'pass123', 'sontung@musiverse.com', N'Sơn Tùng M-TP', 'Artist', N'Ca sĩ, nhạc sĩ Việt Nam'),
('mtp', 'pass123', 'mtp@musiverse.com', N'My Tam', 'Artist', N'Nữ hoàng nhạc pop'),
('indie_artist', 'pass123', 'indie@musiverse.com', N'Indie Artist', 'IndieArtist', N'Nghệ sĩ độc lập');

-- Insert Normal Users
INSERT INTO Users (Username, Password, Email, FullName, Role) 
VALUES 
('user1', 'pass123', 'user1@musiverse.com', N'Nguyễn Văn A', 'User'),
('user2', 'pass123', 'user2@musiverse.com', N'Trần Thị B', 'User');

-- ==========================================
-- UPDATE DATABASE: THÊM TÍNH NĂNG VIP
-- ==========================================

USE MusiverseDB;
GO

-- BƯỚC 1: Thêm cột VIP vào bảng Users
IF NOT EXISTS (SELECT * FROM sys.columns 
               WHERE object_id = OBJECT_ID(N'Users') 
               AND name = 'HasVIP')
BEGIN
    ALTER TABLE Users 
    ADD HasVIP BIT DEFAULT 0;
    
    PRINT 'Added column HasVIP to Users table';
END

IF NOT EXISTS (SELECT * FROM sys.columns 
               WHERE object_id = OBJECT_ID(N'Users') 
               AND name = 'VIPExpiryDate')
BEGIN
    ALTER TABLE Users 
    ADD VIPExpiryDate DATETIME NULL;
    
    PRINT 'Added column VIPExpiryDate to Users table';
END
GO

-- BƯỚC 2: Tạo bảng VIPTransactions (lịch sử mua VIP)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'VIPTransactions')
BEGIN
    CREATE TABLE VIPTransactions (
        TransactionID INT PRIMARY KEY IDENTITY(1,1),
        UserID INT FOREIGN KEY REFERENCES Users(UserID),
        PackageType NVARCHAR(20) CHECK (PackageType IN ('Monthly', 'Yearly')),
        Amount DECIMAL(18,2) NOT NULL,
        PaymentMethod NVARCHAR(50), -- MoMo, VNPay, Banking, etc.
        TransactionDate DATETIME DEFAULT GETDATE(),
        StartDate DATETIME NOT NULL,
        EndDate DATETIME NOT NULL,
        Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Success', 'Failed')) DEFAULT 'Pending',
        TransactionCode NVARCHAR(100) UNIQUE
    );
    
    CREATE INDEX IX_VIPTransactions_UserID ON VIPTransactions(UserID);
    
    PRINT 'Created VIPTransactions table';
END
GO

-- BƯỚC 3: Stored Procedure - Mua gói VIP
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_PurchaseVIP')
    DROP PROCEDURE sp_PurchaseVIP;
GO

CREATE PROCEDURE sp_PurchaseVIP
    @UserID INT,
    @PackageType NVARCHAR(20), -- 'Monthly' hoặc 'Yearly'
    @PaymentMethod NVARCHAR(50),
    @TransactionCode NVARCHAR(100)
AS
BEGIN
    DECLARE @Amount DECIMAL(18,2);
    DECLARE @StartDate DATETIME = GETDATE();
    DECLARE @EndDate DATETIME;
    
    -- Tính giá và ngày hết hạn
    IF @PackageType = 'Monthly'
    BEGIN
        SET @Amount = 59000;
        SET @EndDate = DATEADD(MONTH, 1, @StartDate);
    END
    ELSE IF @PackageType = 'Yearly'
    BEGIN
        SET @Amount = 590000;
        SET @EndDate = DATEADD(YEAR, 1, @StartDate);
    END
    ELSE
    BEGIN
        RAISERROR('Invalid package type', 16, 1);
        RETURN;
    END
    
    BEGIN TRANSACTION;
    
    -- Thêm transaction
    INSERT INTO VIPTransactions (UserID, PackageType, Amount, PaymentMethod, 
                                StartDate, EndDate, Status, TransactionCode)
    VALUES (@UserID, @PackageType, @Amount, @PaymentMethod, 
            @StartDate, @EndDate, 'Success', @TransactionCode);
    
    -- Cập nhật user
    UPDATE Users
    SET HasVIP = 1,
        VIPExpiryDate = @EndDate
    WHERE UserID = @UserID;
    
    COMMIT TRANSACTION;
    
    SELECT 'SUCCESS' AS Result, @EndDate AS ExpiryDate, @Amount AS Amount;
END
GO

-- BƯỚC 4: Stored Procedure - Gia hạn VIP
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_RenewVIP')
    DROP PROCEDURE sp_RenewVIP;
GO

CREATE PROCEDURE sp_RenewVIP
    @UserID INT,
    @PackageType NVARCHAR(20),
    @PaymentMethod NVARCHAR(50),
    @TransactionCode NVARCHAR(100)
AS
BEGIN
    DECLARE @CurrentExpiry DATETIME;
    DECLARE @NewExpiry DATETIME;
    DECLARE @Amount DECIMAL(18,2);
    
    -- Lấy ngày hết hạn hiện tại
    SELECT @CurrentExpiry = VIPExpiryDate FROM Users WHERE UserID = @UserID;
    
    -- Nếu đã hết hạn, tính từ hôm nay
    IF @CurrentExpiry IS NULL OR @CurrentExpiry < GETDATE()
        SET @CurrentExpiry = GETDATE();
    
    -- Tính ngày mới
    IF @PackageType = 'Monthly'
    BEGIN
        SET @Amount = 59000;
        SET @NewExpiry = DATEADD(MONTH, 1, @CurrentExpiry);
    END
    ELSE IF @PackageType = 'Yearly'
    BEGIN
        SET @Amount = 590000;
        SET @NewExpiry = DATEADD(YEAR, 1, @CurrentExpiry);
    END
    
    BEGIN TRANSACTION;
    
    -- Thêm transaction
    INSERT INTO VIPTransactions (UserID, PackageType, Amount, PaymentMethod, 
                                StartDate, EndDate, Status, TransactionCode)
    VALUES (@UserID, @PackageType, @Amount, @PaymentMethod, 
            @CurrentExpiry, @NewExpiry, 'Success', @TransactionCode);
    
    -- Cập nhật user
    UPDATE Users
    SET HasVIP = 1,
        VIPExpiryDate = @NewExpiry
    WHERE UserID = @UserID;
    
    COMMIT TRANSACTION;
    
    SELECT 'SUCCESS' AS Result, @NewExpiry AS ExpiryDate;
END
GO

-- BƯỚC 5: Stored Procedure - Kiểm tra và hủy VIP hết hạn
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_CheckExpiredVIP')
    DROP PROCEDURE sp_CheckExpiredVIP;
GO

CREATE PROCEDURE sp_CheckExpiredVIP
AS
BEGIN
    -- Hủy VIP của những user đã hết hạn
    UPDATE Users
    SET HasVIP = 0
    WHERE VIPExpiryDate < GETDATE() AND HasVIP = 1;
    
    SELECT @@ROWCOUNT AS ExpiredCount;
END
GO

-- BƯỚC 6: Stored Procedure - Lấy thông tin VIP của user
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_GetVIPInfo')
    DROP PROCEDURE sp_GetVIPInfo;
GO

CREATE PROCEDURE sp_GetVIPInfo
    @UserID INT
AS
BEGIN
    -- Kiểm tra và update nếu hết hạn
    IF EXISTS (SELECT 1 FROM Users 
               WHERE UserID = @UserID 
                 AND HasVIP = 1 
                 AND VIPExpiryDate < GETDATE())
    BEGIN
        UPDATE Users SET HasVIP = 0 WHERE UserID = @UserID;
    END
    
    -- Trả về thông tin
    SELECT 
        UserID,
        HasVIP,
        VIPExpiryDate,
        CASE 
            WHEN HasVIP = 1 THEN DATEDIFF(DAY, GETDATE(), VIPExpiryDate)
            ELSE 0
        END AS DaysRemaining
    FROM Users
    WHERE UserID = @UserID;
END
GO

-- BƯỚC 7: Stored Procedure - Lấy lịch sử mua VIP
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_GetVIPHistory')
    DROP PROCEDURE sp_GetVIPHistory;
GO

CREATE PROCEDURE sp_GetVIPHistory
    @UserID INT
AS
BEGIN
    SELECT 
        TransactionID,
        PackageType,
        Amount,
        PaymentMethod,
        TransactionDate,
        StartDate,
        EndDate,
        Status,
        DATEDIFF(DAY, StartDate, EndDate) AS DurationDays
    FROM VIPTransactions
    WHERE UserID = @UserID
    ORDER BY TransactionDate DESC;
END
GO

-- BƯỚC 8: Job tự động kiểm tra VIP hết hạn (chạy hàng ngày)
-- Bạn có thể tạo SQL Agent Job hoặc gọi thủ công

-- TEST: Tạo job agent (nếu có quyền)
/*
USE msdb;
GO

EXEC sp_add_job
    @job_name = N'Check Expired VIP Daily',
    @enabled = 1;

EXEC sp_add_jobstep
    @job_name = N'Check Expired VIP Daily',
    @step_name = N'Check VIP',
    @subsystem = N'TSQL',
    @command = N'EXEC MusiverseDB.dbo.sp_CheckExpiredVIP',
    @database_name = N'MusiverseDB';

EXEC sp_add_schedule
    @schedule_name = N'Daily at 2 AM',
    @freq_type = 4, -- Daily
    @freq_interval = 1,
    @active_start_time = 20000; -- 2:00 AM

EXEC sp_attach_schedule
    @job_name = N'Check Expired VIP Daily',
    @schedule_name = N'Daily at 2 AM';
*/

-- BƯỚC 9: Insert test data (optional)
-- User test mua VIP
/*
EXEC sp_PurchaseVIP 
    @UserID = 4,
    @PackageType = 'Monthly',
    @PaymentMethod = 'MoMo',
    @TransactionCode = 'MM' + CONVERT(VARCHAR, GETDATE(), 112) + '_001';
*/

-- ==========================================
-- KIỂM TRA KẾT QUẢ
-- ==========================================

-- Xem thông tin VIP của user
-- EXEC sp_GetVIPInfo @UserID = 4;

-- Xem lịch sử mua VIP
-- EXEC sp_GetVIPHistory @UserID = 4;

-- Kiểm tra VIP hết hạn
-- EXEC sp_CheckExpiredVIP;

PRINT '==================================';
PRINT 'VIP Feature installed successfully!';
PRINT '==================================';
PRINT '';
PRINT 'Available Stored Procedures:';
PRINT '1. sp_PurchaseVIP - Mua gói VIP mới';
PRINT '2. sp_RenewVIP - Gia hạn VIP';
PRINT '3. sp_GetVIPInfo - Xem thông tin VIP';
PRINT '4. sp_GetVIPHistory - Xem lịch sử';
PRINT '5. sp_CheckExpiredVIP - Kiểm tra hết hạn';
PRINT '';
PRINT 'Next steps:';
PRINT '- Update UserRepository.cs với các methods mới';
PRINT '- Tạo VIPService.cs trong BLL';
PRINT '- Tạo frmVIPPackage.cs để hiển thị UI mua VIP';
GO

-- ============================================
-- SQL Script to Create Missing Social Network Tables
-- Database: MUSIVERSE_DB
-- ============================================

-- Check if tables exist and create them if they don't

-- 1. Create Posts Table (if not exists)
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Posts')
BEGIN
    CREATE TABLE Posts (
        PostID INT PRIMARY KEY IDENTITY(1,1),
        UserID INT NOT NULL,
        Content NVARCHAR(MAX),
        MediaPath NVARCHAR(255),
        MediaType NVARCHAR(50),
        CreatedDate DATETIME NOT NULL,
        IsActive BIT DEFAULT 1,
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
    PRINT 'Created Posts table';
END
ELSE
    PRINT 'Posts table already exists';

-- 2. Create Comments Table (if not exists)
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Comments')
BEGIN
    CREATE TABLE Comments (
        CommentID INT PRIMARY KEY IDENTITY(1,1),
        PostID INT NOT NULL,
        UserID INT NOT NULL,
        Content NVARCHAR(1000),
        CreatedDate DATETIME NOT NULL,
        IsActive BIT DEFAULT 1,
        FOREIGN KEY (PostID) REFERENCES Posts(PostID),
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
    PRINT 'Created Comments table';
END
ELSE
    PRINT 'Comments table already exists';

-- 3. Create PostLikes Table (if not exists)
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PostLikes')
BEGIN
    CREATE TABLE PostLikes (
        LikeID INT PRIMARY KEY IDENTITY(1,1),
        PostID INT NOT NULL,
        UserID INT NOT NULL,
        LikeDate DATETIME NOT NULL,
        UNIQUE(PostID, UserID),
        FOREIGN KEY (PostID) REFERENCES Posts(PostID),
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
    PRINT 'Created PostLikes table';
END
ELSE
    PRINT 'PostLikes table already exists';

-- 4. Create PostSaves Table (if not exists) - THIS IS THE MISSING ONE!
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PostSaves')
BEGIN
    CREATE TABLE PostSaves (
        SaveID INT PRIMARY KEY IDENTITY(1,1),
        PostID INT NOT NULL,
        UserID INT NOT NULL,
        SaveDate DATETIME NOT NULL,
        UNIQUE(PostID, UserID),
        FOREIGN KEY (PostID) REFERENCES Posts(PostID),
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
    PRINT 'Created PostSaves table';
END
ELSE
    PRINT 'PostSaves table already exists';

-- 5. Create PostShares Table (if not exists)
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PostShares')
BEGIN
    CREATE TABLE PostShares (
        ShareID INT PRIMARY KEY IDENTITY(1,1),
        PostID INT NOT NULL,
        UserID INT NOT NULL,
        ShareDate DATETIME NOT NULL,
        FOREIGN KEY (PostID) REFERENCES Posts(PostID),
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
    PRINT 'Created PostShares table';
END
ELSE
    PRINT 'PostShares table already exists';

-- ============================================
-- Create Indexes for Better Performance
-- ============================================

-- Posts Indexes
IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_Posts_UserID')
    CREATE INDEX IX_Posts_UserID ON Posts(UserID);

IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_Posts_CreatedDate')
    CREATE INDEX IX_Posts_CreatedDate ON Posts(CreatedDate DESC);

IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_Posts_IsActive')
    CREATE INDEX IX_Posts_IsActive ON Posts(IsActive);

-- Comments Indexes
IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_Comments_PostID')
    CREATE INDEX IX_Comments_PostID ON Comments(PostID);

IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_Comments_UserID')
    CREATE INDEX IX_Comments_UserID ON Comments(UserID);

IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_Comments_IsActive')
    CREATE INDEX IX_Comments_IsActive ON Comments(IsActive);

-- PostLikes Indexes
IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_PostLikes_PostID')
    CREATE INDEX IX_PostLikes_PostID ON PostLikes(PostID);

IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_PostLikes_UserID')
    CREATE INDEX IX_PostLikes_UserID ON PostLikes(UserID);

-- PostSaves Indexes
IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_PostSaves_PostID')
    CREATE INDEX IX_PostSaves_PostID ON PostSaves(PostID);

IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_PostSaves_UserID')
    CREATE INDEX IX_PostSaves_UserID ON PostSaves(UserID);

-- PostShares Indexes
IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_PostShares_PostID')
    CREATE INDEX IX_PostShares_PostID ON PostShares(PostID);

-- ============================================
-- Verification - List Created Tables
-- ============================================
PRINT '------- Verification -------';
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME IN ('Posts', 'Comments', 'PostLikes', 'PostSaves', 'PostShares')
ORDER BY TABLE_NAME;

PRINT 'Database setup completed!';
