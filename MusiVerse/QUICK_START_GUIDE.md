# ?? MusiVerse Social Network - Quick Start Guide

## ?? Table of Contents
1. [Project Overview](#project-overview)
2. [Components Overview](#components-overview)
3. [Running the Application](#running-the-application)
4. [Feature Demonstrations](#feature-demonstrations)
5. [Troubleshooting](#troubleshooting)

## Project Overview

The MusiVerse Social Network is a complete Facebook-like social platform built into the MusiVerse application. Users can:
- Create and edit posts with images/videos
- Like, comment, save, and share posts
- View a personalized newsfeed
- Manage their saved posts

### Tech Stack
- **Framework**: .NET Framework 4.7.2
- **Language**: C# 7.3
- **Database**: SQL Server
- **UI Framework**: Windows Forms

## Components Overview

### 1. Core Services (Business Logic)

#### PostService
```csharp
// Creating a post
var postService = new PostService();
var post = new Post 
{ 
    UserID = 1, 
    Content = "Hello World!", 
    MediaPath = "image.jpg",
    MediaType = "Image"
};
var result = postService.CreatePost(post);
// returns: (true/false, message)

// Getting newsfeed
var posts = postService.GetNewsFeed(userID: 1, pageNumber: 1, pageSize: 10);

// Liking a post
var likeResult = postService.LikePost(userID: 1, postID: 5);
```

#### CommentService
```csharp
// Getting comments
var comments = _commentService.GetCommentsByPost(postID: 5);

// Adding comment
var comment = new Comment 
{ 
    PostID = 5, 
    UserID = 1, 
    Content = "Nice post!" 
};
var result = _commentService.AddComment(comment);
```

#### ShareService
```csharp
// Sharing a post
var shareResult = _shareService.SharePost(userID: 1, postID: 5);
```

### 2. User Interface Components

#### Main Social Feed Page
```csharp
// Add to your main form
ucSocialNetworkPage socialFeed = new ucSocialNetworkPage();
this.Controls.Add(socialFeed);
```

**Features:**
- ? Posts display with pagination
- ? Create post button
- ? Saved posts button
- ? Like/Comment/Share/Save/Edit/Delete buttons
- ? User avatar and timestamp display

#### Post Card User Control
```csharp
// Individual post component
var postCard = new ucPostCard();
postCard.LoadPost(post, currentUserID: 1);

// Handle events
postCard.OnLikeClicked += (s, e) => HandleLikeClick();
postCard.OnCommentClicked += (s, e) => HandleCommentClick();
postCard.OnSaveClicked += (s, e) => HandleSaveClick();
postCard.OnShareClicked += (s, e) => HandleShareClick();
postCard.OnEditClicked += (s, e) => HandleEditClick();
postCard.OnDeleteClicked += (s, e) => HandleDeleteClick();
```

### 3. Dialog Forms

#### Create/Edit Post Form
```csharp
// Create new post
var createForm = new frmCreateEditPost(post: null, currentUserID: 1);
if (createForm.ShowDialog() == DialogResult.OK)
{
    // Post created successfully
}

// Edit existing post
var editForm = new frmCreateEditPost(post: existingPost, currentUserID: 1);
if (editForm.ShowDialog() == DialogResult.OK)
{
    // Post updated
}
```

#### Comment Dialog
```csharp
var commentDialog = new frmCommentDialog(post: post, currentUserID: 1);
commentDialog.ShowDialog();
// Users can view, add, edit, and delete comments
```

#### Saved Posts Form
```csharp
var savedForm = new frmSavedPosts();
savedForm.ShowDialog();
// Shows user's saved posts with full interaction capabilities
```

## Running the Application

### Prerequisites
1. ? SQL Server database with social tables
2. ? User authenticated and session established
3. ? .NET Framework 4.7.2 installed

### Database Setup
Ensure these tables exist:
```sql
-- Posts table
CREATE TABLE Posts (
    PostID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    Content NVARCHAR(MAX),
    MediaPath NVARCHAR(500),
    MediaType NVARCHAR(50),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

-- Comments table
CREATE TABLE Comments (
    CommentID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT NOT NULL,
    UserID INT NOT NULL,
    Content NVARCHAR(1000) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

-- Post likes
CREATE TABLE PostLikes (
    PostLikeID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT NOT NULL,
    UserID INT NOT NULL,
    LikeDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

-- Saved posts
CREATE TABLE PostSaves (
    SaveID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT NOT NULL,
    UserID INT NOT NULL,
    SaveDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

-- Post shares
CREATE TABLE PostShares (
    ShareID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT NOT NULL,
    UserID INT NOT NULL,
    ShareDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)
```

### Build & Run
```bash
# Build the solution
Ctrl+Shift+B (in Visual Studio)

# Run the application
F5 (in Visual Studio)

# Navigate to social features
# Main form ? Social Network tab/page
```

## Feature Demonstrations

### Demo 1: Creating a Post
1. Click "?? T?o bài vi?t" button
2. Enter post content: "Hello MusiVerse!"
3. Optionally select an image file
4. Click "?? ??ng bài"
5. ? Post appears in newsfeed

**Expected Result:**
- Post is created in database
- Appears at top of newsfeed
- Shows username, avatar, and timestamp

### Demo 2: Liking Posts
1. View a post in the newsfeed
2. Click "?? Thích" button (white heart)
3. ? Button changes to "?? Thích" (red heart)
4. Like count increases by 1

**Expected Result:**
- Like recorded in PostLikes table
- Visual feedback immediate
- Can unlike by clicking again

### Demo 3: Commenting
1. Click "?? Bình lu?n" button on any post
2. Comment dialog opens
3. Enter comment in text box
4. Click "?? G?i" button
5. ? Comment appears in list

**Expected Result:**
- Comment saved to database
- Displayed with username and timestamp
- Can edit/delete own comments

### Demo 4: Saving Posts
1. Click "?? L?u" button (unlined bookmark)
2. ? Button changes to "?? ?ã l?u" (filled bookmark)
3. Post saved to PostSaves table

**Expected Result:**
- Post appears in saved posts list
- Can access via "?? Bài vi?t ?ã l?u" button
- Can unsave by clicking again

### Demo 5: Sharing Posts
1. Click "?? Chia s?" button
2. Success message appears
3. Share count increases
4. ? Post is recorded in PostShares table

**Expected Result:**
- Share count visible on post
- User-friendly notification
- Data persisted in database

### Demo 6: Editing Posts (Owner Only)
1. For your own post, click "?" menu
2. Click "?? Ch?nh s?a"
3. Edit form opens
4. Modify content or media
5. Click "?? C?p nh?t"
6. ? Post updated in database

**Expected Result:**
- Only post owner sees menu
- Changes reflected immediately
- New content visible in newsfeed

### Demo 7: Deleting Posts (Owner Only)
1. For your own post, click "?" menu
2. Click "??? Xóa"
3. Confirmation dialog appears
4. Click "Yes"
5. ? Post removed from view

**Expected Result:**
- Soft delete (IsActive = 0)
- Removed from newsfeed
- Data preserved in database

## Troubleshooting

### Issue: "L?i t?i feed"
**Causes:**
- Database connection failed
- User not authenticated
- No Posts table

**Solution:**
1. Check database connection string
2. Verify SessionManager.GetCurrentUserID() returns valid ID
3. Run database setup scripts

### Issue: Posts don't appear
**Causes:**
- Posts table is empty
- No posts created yet
- IsActive = 0 (deleted)

**Solution:**
1. Create a test post
2. Check Posts table for data
3. Verify IsActive = 1 for posts

### Issue: Media files not displaying
**Causes:**
- Invalid file path
- File doesn't exist
- Unsupported format

**Solution:**
1. Check file path in database
2. Verify file exists at location
3. Ensure file is JPG, PNG, GIF, MP4, AVI, or MOV

### Issue: Comments won't load
**Causes:**
- Comments table missing
- PostID doesn't exist
- Database error

**Solution:**
1. Create Comments table
2. Ensure PostID is valid
3. Check database logs

### Issue: "Ch?a có bài vi?t nào" (No posts)
**This is normal when:**
- First time using app
- User is new
- Feed is empty

**Solution:**
1. Create a new post
2. Wait for others to post
3. Check "Bài vi?t ?ã l?u" for saved posts

## ?? Customization

### Changing Colors
Edit UI setup in form/control code:
```csharp
Button btnLike = new Button
{
    BackColor = Color.FromArgb(220, 20, 60),  // Red
    ForeColor = Color.White
};
```

### Adjusting Pagination
```csharp
// In LoadFeed method
List<Post> posts = _postService.GetNewsFeed(_currentUserID, _currentPage, 20); // Change 20 to desired page size
```

### Modifying Validation
Edit PostValidator.cs and CommentService.cs:
```csharp
// Increase comment max length
if (content.Length > 2000) // was 1000
    return (false, "Comment too long");
```

## ?? Performance Tips

1. **Database Indexes**
   - Index on UserID for queries
   - Index on PostID for joins
   - Index on CreatedDate for sorting

2. **Query Optimization**
   - Use pagination (don't load all posts)
   - Lazy load images
   - Cache frequently accessed data

3. **Media Management**
   - Compress images before upload
   - Limit video file sizes
   - Clean up old files regularly

## ?? Related Documentation
- SOCIAL_NETWORK_COMPLETION.md - Full feature list
- SOCIAL_NETWORK_API.md - API reference
- SOCIAL_NETWORK_GUIDE.md - User guide

---

**Quick Links:**
- ?? Main Form: frmMain.cs
- ?? Social Feed: ucSocialNetworkPage.cs
- ?? Create Post: frmCreateEditPost.cs
- ?? Comments: frmCommentDialog.cs
- ?? Saved: frmSavedPosts.cs

**Build Status:** ? Successful
**Ready to Deploy:** ? Yes
