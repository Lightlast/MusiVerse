# ?? Kh?c ph?c l?i: "Invalid object name 'PostSaves'"

## ? L?i x?y ra
```
L?i t?i newsfeed: L?i t?i newsfeed: Error executing query: Invalid object name 'PostSaves'
```

## ?? Nguyên nhân
B?ng `PostSaves` không t?n t?i trong database `MUSIVERSE_DB`. ?i?u này x?y ra vì:
- B?ng ch?a ???c t?o tr??c khi deploy code m?i
- SQL script ch?a ???c ch?y
- Database ch?a ???c c?p nh?t

## ? Cách kh?c ph?c

### B??c 1: M? SQL Server Management Studio
1. Nh?p vào "Start" ? tìm "SQL Server Management Studio"
2. M? ?ng d?ng

### B??c 2: K?t n?i t?i Database
1. Server name: `MTC` (ho?c `localhost` ho?c `.` tùy c?u hình)
2. Authentication: `Windows Authentication`
3. Nh?p "Connect"

### B??c 3: Ch?n Database
1. Trong "Object Explorer" (bên trái), tìm database `MUSIVERSE_DB`
2. Click ph?i vào nó ? New Query

### B??c 4: Ch?y Script SQL

**Option A: Ch?y file SQL (Khuy?n ngh?)**
1. File ? Open ? File...
2. Ch?n file `CREATE_SOCIAL_NETWORK_TABLES.sql` t? solution root
3. Nh?p "Execute" (ho?c Ctrl+Shift+E)

**Option B: Copy-Paste Script**
1. Copy toàn b? SQL script bên d??i
2. Paste vào Query window
3. Nh?p "Execute"

### B??c 5: Xác minh (Execute ?o?n này)
```sql
-- Ki?m tra xem các b?ng ?ã t?n t?i ch?a
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME IN ('Posts', 'Comments', 'PostLikes', 'PostSaves', 'PostShares')
ORDER BY TABLE_NAME;
```

**K?t qu? mong ??i:**
```
Comments
PostLikes
PostSaves
PostShares
Posts
```

### B??c 6: Restart Application
1. ?óng ?ng d?ng MusiVerse
2. M? l?i
3. Click vào "Social Network"
4. Seharusnya bây gi? không có l?i

---

## ?? SQL Script Hoàn Ch?nh

N?u b?n mu?n t?o th? công, hãy ch?y script này:

```sql
-- 1. Create Posts Table
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

-- 2. Create Comments Table
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

-- 3. Create PostLikes Table
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

-- 4. Create PostSaves Table (QUAN TR?NG - B?ng b? thi?u)
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

-- 5. Create PostShares Table
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

-- Create Indexes
CREATE INDEX IX_Posts_UserID ON Posts(UserID);
CREATE INDEX IX_Posts_CreatedDate ON Posts(CreatedDate DESC);
CREATE INDEX IX_Comments_PostID ON Comments(PostID);
CREATE INDEX IX_Comments_UserID ON Comments(UserID);
CREATE INDEX IX_PostLikes_PostID ON PostLikes(PostID);
CREATE INDEX IX_PostSaves_PostID ON PostSaves(PostID);
CREATE INDEX IX_PostShares_PostID ON PostShares(PostID);

PRINT 'All tables and indexes created successfully!';
```

---

## ?? Ki?m tra Chi Ti?t

### Xem toàn b? c?u trúc b?ng PostSaves
```sql
EXEC sp_columns PostSaves;
```

### Xem Foreign Keys
```sql
SELECT CONSTRAINT_NAME, TABLE_NAME, COLUMN_NAME 
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
WHERE TABLE_NAME = 'PostSaves';
```

### Xem Indexes
```sql
SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID('PostSaves');
```

---

## ?? N?u l?i v?n x?y ra

### Ki?m tra 1: Database Connection
```sql
-- Ch?y ?o?n này ?? test
SELECT @@VERSION;
```

N?u có l?i ? Check connection string trong `DatabaseConnection.cs`

### Ki?m tra 2: Users Table
```sql
SELECT * FROM Users LIMIT 1;
```

N?u không tìm th?y ? B?ng Users không t?n t?i

### Ki?m tra 3: Xem toàn b? b?ng
```sql
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 
ORDER BY TABLE_NAME;
```

### Ki?m tra 4: Xem l?i c? th?
```sql
-- Th? query mà code ?ang g?p v?n ??
SELECT p.PostID, p.UserID, p.Content
FROM Posts p
LEFT JOIN PostSaves ps ON p.PostID = ps.PostID
WHERE p.IsActive = 1;
```

---

## ?? G?i ý

### N?u b?n mu?n t?o b?ng nhanh h?n
Sao chép script t? file `CREATE_SOCIAL_NETWORK_TABLES.sql` (? root solution) và ch?y

### N?u b?n mu?n xóa t?t c? và start l?i
```sql
-- ?? C?P NH?T: Ch? ch?y n?u b?n mu?n xóa t?t c? d? li?u!
DROP TABLE IF EXISTS PostShares;
DROP TABLE IF EXISTS PostSaves;
DROP TABLE IF EXISTS PostLikes;
DROP TABLE IF EXISTS Comments;
DROP TABLE IF EXISTS Posts;
```

Sau ?ó ch?y l?i script CREATE

---

## ?? Ghi chú

- **PostSaves** là b?ng ?? l?u tr? nh?ng bài vi?t mà user ?ã l?u
- Nó có UNIQUE constraint trên (PostID, UserID) ?? tránh save trùng
- Có foreign key t?i Posts và Users ?? ??m b?o tính toàn v?n d? li?u

---

## ? Sau khi kh?c ph?c

1. ? T?t c? b?ng ???c t?o
2. ? T?t c? indexes ???c t?o
3. ? Có th? t?o, s?a, xóa posts
4. ? Có th? like, save, comment trên posts
5. ? Có th? xem newsfeed

---

**N?u v?n có v?n ??, hãy:**
1. Screenshot error message
2. Ch?y ki?m tra chi ti?t ? trên
3. Ki?m tra connection string
4. Ch?c ch?n database name là `MUSIVERSE_DB`

Happy coding! ????
