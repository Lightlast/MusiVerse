# Social Network Quick Start Guide

## ?? Getting Started

### Prerequisites
1. Ensure database tables exist (see schema below)
2. Ensure `SessionManager` is properly initialized with user data
3. `PostService` and `CommentService` should be available in project

### Database Setup

Run these SQL commands to create required tables:

```sql
-- Posts Table
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

-- Comments Table
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

-- Post Likes Table
CREATE TABLE PostLikes (
    LikeID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT NOT NULL,
    UserID INT NOT NULL,
    LikeDate DATETIME NOT NULL,
    UNIQUE(PostID, UserID),
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Post Saves Table
CREATE TABLE PostSaves (
    SaveID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT NOT NULL,
    UserID INT NOT NULL,
    SaveDate DATETIME NOT NULL,
    UNIQUE(PostID, UserID),
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Post Shares Table (Optional)
CREATE TABLE PostShares (
    ShareID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT NOT NULL,
    UserID INT NOT NULL,
    ShareDate DATETIME NOT NULL,
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Create Indexes for better performance
CREATE INDEX IX_Posts_UserID ON Posts(UserID);
CREATE INDEX IX_Posts_CreatedDate ON Posts(CreatedDate DESC);
CREATE INDEX IX_Comments_PostID ON Comments(PostID);
CREATE INDEX IX_Comments_UserID ON Comments(UserID);
CREATE INDEX IX_PostLikes_PostID ON PostLikes(PostID);
CREATE INDEX IX_PostLikes_UserID ON PostLikes(UserID);
CREATE INDEX IX_PostSaves_PostID ON PostSaves(PostID);
CREATE INDEX IX_PostSaves_UserID ON PostSaves(UserID);
```

## ?? Files Added/Modified

### New Files Created:
1. `MusiVerse\GUI\Forms\Social\frmCreatePost.cs` - Create posts
2. `MusiVerse\GUI\Forms\Social\frmEditPost.cs` - Edit posts
3. `MusiVerse\GUI\Forms\Social\frmEditPost.Designer.cs`
4. `MusiVerse\GUI\Forms\Social\frmCommentSection.cs` - Comment management
5. `MusiVerse\GUI\Forms\Social\frmCommentSection.Designer.cs`
6. `MusiVerse\GUI\Forms\Social\frmMyPosts.cs` - View user posts
7. `MusiVerse\GUI\Forms\Social\frmMyPosts.Designer.cs`
8. `MusiVerse\GUI\Forms\Social\frmSavedPosts.cs` - View saved posts
9. `MusiVerse\GUI\Forms\Social\frmSavedPosts.Designer.cs`
10. `MusiVerse\GUI\Forms\Social\SOCIAL_NETWORK_README.md` - Documentation

### Files Modified:
1. `MusiVerse\GUI\UserControls\UcSocialPage.cs` - Complete rewrite
2. `MusiVerse\GUI\UserControls\ucPostItem.cs` - Enhanced with new events
3. `MusiVerse\GUI\Forms\Main\frmMain.cs` - Updated LoadSocialNetworkPage()

## ?? Main Entry Points

### Access Social Network from Main Form
The Social Network is accessed from the main menu by clicking the "?? Social Network" button which triggers:
```csharp
LoadSocialNetworkPage() ? UcSocialPage
```

### UcSocialPage Features
- **Newsfeed**: Shows posts from all users with pagination
- **Create Post**: Button to open `frmCreatePost`
- **My Posts**: Button to open `frmMyPosts`
- **Saved Posts**: Button to open `frmSavedPosts`
- **Post Interactions**: Like, comment, save, share, edit, delete

## ?? Usage Examples

### Create a Post
```
1. Click "?? T?o bài vi?t" on Social Network page
2. Enter content in text area
3. (Optional) Click "?? Ch?n hình ?nh" to add media
4. Click "?? ??ng bài" to publish
```

### Comment on a Post
```
1. Click "?? Bình lu?n" on any post
2. Type comment in text field
3. Click "G?i" button
4. Comment appears immediately
```

### Like/Save Posts
```
1. Click "?? Thích" to like (red when liked)
2. Click "?? L?u" to save (blue when saved)
3. Stats update in real-time
```

### View My Posts
```
1. Click "?? Bài vi?t c?a tôi"
2. See all your posts
3. Edit or delete posts using menu (?)
4. Comment on posts
```

### View Saved Posts
```
1. Click "?? Bài vi?t ?ã l?u"
2. See all posts you've saved
3. Click "?? ?ã l?u" to remove from saved
4. Comment and like saved posts
```

## ?? Configuration

### Change Pagination Size
In `UcSocialPage.cs`:
```csharp
private const int PAGE_SIZE = 5; // Change this to desired number
```

### Change Media Allowed Types
In `frmCreatePost.cs` and `frmEditPost.cs`:
```csharp
ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|Video Files|*.mp4;*.avi;*.mkv|All Files|*.*";
// Modify this filter as needed
```

### Change Colors
Search for `Color.FromArgb()` calls and modify the RGB values.

## ?? Common Issues & Solutions

### Issue: Posts not showing
**Solution**: 
- Check database connection in `DatabaseConnection.cs`
- Verify Posts table exists and has data
- Check user is logged in via `SessionManager`

### Issue: Images not displaying
**Solution**:
- Ensure media file path is correct (absolute paths recommended)
- Check file permissions
- Verify file exists at specified path

### Issue: Comments not loading
**Solution**:
- Verify Comments table created
- Check foreign key constraints
- Ensure `CommentRepository` is initialized

### Issue: Slow performance
**Solution**:
- Reduce `PAGE_SIZE` in pagination
- Add database indexes (see schema above)
- Consider implementing caching

### Issue: "Cannot find user" errors
**Solution**:
- Verify user is logged in
- Check `SessionManager.CurrentUser` is set
- Ensure `SessionManager.GetCurrentUserID()` returns valid ID

## ?? Database Query Examples

### Get Newsfeed (with stats)
```sql
SELECT p.PostID, p.UserID, u.FullName AS Username,
       COUNT(DISTINCT pl.LikeID) AS LikeCount,
       COUNT(DISTINCT c.CommentID) AS CommentCount,
       COUNT(DISTINCT ps.ShareID) AS ShareCount
FROM Posts p
INNER JOIN Users u ON p.UserID = u.UserID
LEFT JOIN PostLikes pl ON p.PostID = pl.PostID
LEFT JOIN Comments c ON p.PostID = c.PostID AND c.IsActive = 1
LEFT JOIN PostShares ps ON p.PostID = ps.PostID
WHERE p.IsActive = 1
GROUP BY p.PostID, p.UserID, u.FullName
ORDER BY p.CreatedDate DESC;
```

### Get User's Posts
```sql
SELECT * FROM Posts
WHERE UserID = @UserID AND IsActive = 1
ORDER BY CreatedDate DESC;
```

### Get Saved Posts
```sql
SELECT p.* FROM Posts p
INNER JOIN PostSaves ps ON p.PostID = ps.PostID
WHERE ps.UserID = @UserID AND p.IsActive = 1
ORDER BY ps.SaveDate DESC;
```

## ?? Color Reference

| Component | Color | RGB |
|-----------|-------|-----|
| Primary | Blue | 30, 144, 255 |
| CTA Buttons | Teal | 0, 150, 136 |
| Delete | Red | 220, 20, 60 |
| Save | Blue | 100, 149, 237 |
| Background | Light Gray | 240, 240, 245 |
| Header | White | 255, 255, 255 |

## ?? Class Hierarchy

```
UcSocialPage (UserControl)
??? Manages overall social network page
??? Uses PostService for operations
??? Contains ucPostCard components

ucPostCard (UserControl)
??? Displays individual post
??? Fires events for interactions
??? Shows all post details

frmCreatePost (Form)
??? Dialog for creating posts
??? Uses PostService
??? Returns DialogResult.OK on success

frmEditPost (Form)
??? Dialog for editing posts
??? Similar to frmCreatePost
??? Pre-populated with post data

frmCommentSection (Form)
??? Dialog for viewing/adding comments
??? Uses CommentService
??? Real-time comment updates

frmMyPosts (Form)
??? Window showing user's posts
??? Uses PostService
??? Allows edit/delete for owner

frmSavedPosts (Form)
??? Window showing saved posts
??? Uses PostService
??? Allow remove from saved
```

## ?? Performance Tips

1. **Use Pagination**: Don't load all posts at once
2. **Lazy Loading**: Load more as user scrolls
3. **Database Indexes**: Add indexes on foreign keys and dates
4. **Image Compression**: Consider compressing images before saving
5. **Caching**: Cache frequently accessed posts
6. **Async Loading**: Load posts asynchronously (future enhancement)

## ? Validation Rules

| Field | Rules |
|-------|-------|
| Post Content | Max 5000 chars, required if no media |
| Comment | Max 1000 chars, required, not empty |
| Media | Valid image/video file, must exist |
| Like | One per user per post |
| Save | One per user per post |

## ?? Support

For issues or questions:
1. Check `SOCIAL_NETWORK_README.md` for detailed docs
2. Review error messages in `MessageBox` dialogs
3. Check `SOCIAL_NETWORK_IMPLEMENTATION.md` for architecture
4. Review database connection in `DatabaseConnection.cs`
5. Verify services are properly initialized

## ?? Next Steps

1. Run database setup script
2. Build and run application
3. Test Social Network features
4. Customize colors/layout as needed
5. Implement additional features (following, hashtags, etc.)

Happy Coding! ????
