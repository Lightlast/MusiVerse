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
