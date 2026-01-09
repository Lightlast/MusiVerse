# MusiVerse Social Network Feature Documentation

## Overview
The Social Network feature allows users to create, edit, delete posts, and interact with other users' posts through likes, comments, and saves. It's designed to work like Instagram with a focus on music and artist community engagement.

## Features Implemented

### 1. **Newsfeed (UcSocialPage)**
- Main social network page with automatic pagination
- Display posts from all users
- Real-time update of post stats (likes, comments, shares)
- Load more posts automatically when scrolling to bottom
- Quick access buttons to:
  - Create new post
  - View my posts
  - View saved posts

### 2. **Create Post (frmCreatePost)**
- Create new posts with text content
- Add media (images/videos)
- Preview selected media before posting
- Remove media option
- Placeholder text with focus/blur handling
- Validation to ensure content or media is provided

### 3. **Edit Post (frmEditPost)**
- Edit existing posts (only for post owner)
- Change post content
- Update media
- Remove media
- Same UI as create post for consistency

### 4. **View Comments (frmCommentSection)**
- View all comments on a post
- Add new comments
- Delete own comments
- See comment count and display
- Shows post preview at top
- Real-time comment count update

### 5. **My Posts (frmMyPosts)**
- View all posts created by current user
- View other users' posts (read-only)
- Edit own posts
- Delete own posts
- Like, comment, share, and save functionality

### 6. **Saved Posts (frmSavedPosts)**
- View all saved posts
- Remove from saved
- Like/unlike saved posts
- Comment on saved posts
- Share saved posts

### 7. **Post Interactions**
- **Like Post**: Toggle like status with color change
- **Comment**: Open comment section modal
- **Save Post**: Save/unsave posts for later
- **Share Post**: Copy post to clipboard
- **Edit Post**: Modify post content and media (owner only)
- **Delete Post**: Soft delete post (owner only)

## Database Tables Required

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

-- Post Shares Table
CREATE TABLE PostShares (
    ShareID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT NOT NULL,
    UserID INT NOT NULL,
    ShareDate DATETIME NOT NULL,
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
```

## File Structure

### Forms (GUI/Forms/Social/)
- `frmCreatePost.cs` - Create new posts
- `frmEditPost.cs` - Edit existing posts
- `frmCommentSection.cs` - View and manage comments
- `frmMyPosts.cs` - View user's posts
- `frmSavedPosts.cs` - View saved posts

### User Controls (GUI/UserControls/)
- `UcSocialPage.cs` - Main social network page
- `ucPostCard.cs` - Post display component

### Services (BLL/Services/)
- `PostService.cs` - Post operations
- `CommentService.cs` - Comment operations

### Repositories (DAL/Repositories/)
- `PostRepository.cs` - Post data access
- `CommentRepository.cs` - Comment data access

### Models (DTO/Models/)
- `Post.cs` - Post model
- `Comment.cs` - Comment model

## Usage

### For Users
1. **Access Social Network**: Click "?? Social Network" in main menu
2. **Create Post**: Click "?? T?o bài vi?t" button
3. **Interact with Posts**:
   - Like posts by clicking "?? Thích"
   - Comment by clicking "?? Bình lu?n"
   - Save posts by clicking "?? L?u"
   - Share by copying to clipboard with "?? Chia s?"
4. **View My Posts**: Click "?? Bài vi?t c?a tôi"
5. **View Saved Posts**: Click "?? Bài vi?t ?ã l?u"

### For Developers
- All components are designed with dependency injection
- Services handle business logic and validation
- Repositories handle data access
- UI components are reusable and customizable
- Follow existing patterns for extending functionality

## Key Features Details

### Post Validation
- Content must not be empty (max 5000 characters recommended)
- Must have either content or media
- Media files are validated for type and existence

### Comment Validation
- Content must not be empty
- Max 1000 characters per comment
- Only allows active comments

### Performance
- Pagination in newsfeed (5 posts per page by default)
- Lazy loading as user scrolls
- Efficient database queries with LEFT JOINs for stats
- Soft delete for data integrity

### Security
- Users can only edit/delete their own posts
- Users can only delete their own comments
- Session manager validates user identity
- SQL parameterized queries prevent SQL injection

## Future Enhancements

1. **User Following System**
   - Follow/unfollow users
   - View specific user feeds
   - Notification system

2. **Search & Filter**
   - Search posts by keyword
   - Filter by date, popularity
   - Hashtag support

3. **Advanced Interactions**
   - Reply to comments (nested comments)
   - Mention users with @
   - Emoji reactions instead of just likes
   - View who liked/saved posts

4. **Performance**
   - Implement caching
   - Real-time updates with SignalR
   - Image compression and optimization

5. **Moderation**
   - Report inappropriate content
   - Block users
   - Hide posts

## Troubleshooting

### Posts not loading
- Check database connection
- Verify Posts table exists and has data
- Check SessionManager for valid user

### Images not displaying
- Verify media path is correct
- Check file permissions
- Use absolute paths instead of relative

### Comments not saving
- Ensure CommentRepository and CommentService are initialized
- Check database connection
- Verify Comments table exists

### Performance issues
- Reduce PAGE_SIZE in UcSocialPage
- Implement caching
- Add database indexes on UserID, PostID, CreatedDate

## Notes

- All date/time operations use server time (GETDATE())
- Soft deletes are used to maintain referential integrity
- Avatar loading has fallback to default avatar
- All times display relative (e.g., "2 hours ago")
- Media paths are stored as file paths, ensure proper permissions
