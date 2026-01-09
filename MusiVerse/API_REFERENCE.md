# ?? MusiVerse Social Network - API Reference

## PostService

### GetNewsFeed
```csharp
public List<Post> GetNewsFeed(int currentUserID, int pageNumber = 1, int pageSize = 10)
```
**Description:** Retrieves paginated newsfeed posts for a user
**Parameters:**
- `currentUserID` - The user requesting the feed
- `pageNumber` - Page number (default: 1)
- `pageSize` - Posts per page (default: 10)

**Returns:** List of Post objects with like/save status

**Example:**
```csharp
var postService = new PostService();
var posts = postService.GetNewsFeed(userId: 1, pageNumber: 1, pageSize: 10);
foreach (var post in posts)
{
    Console.WriteLine($"{post.Username}: {post.Content}");
}
```

---

### GetUserPosts
```csharp
public List<Post> GetUserPosts(int userID, int currentUserID)
```
**Description:** Gets all posts by a specific user

**Parameters:**
- `userID` - The user whose posts to retrieve
- `currentUserID` - The user viewing the posts

**Returns:** List of Post objects filtered by userID

---

### GetSavedPosts
```csharp
public List<Post> GetSavedPosts(int userID)
```
**Description:** Gets all posts saved by a user

**Parameters:**
- `userID` - The user whose saved posts to retrieve

**Returns:** List of saved Post objects

---

### CreatePost
```csharp
public (bool, string) CreatePost(Post post)
```
**Description:** Creates a new post

**Parameters:**
- `post` - Post object with Content, MediaPath, MediaType, UserID

**Returns:** Tuple of (success: bool, message: string)

**Validation:**
- Content cannot be empty if no media
- Content max length: unlimited
- Media file must exist

**Example:**
```csharp
var newPost = new Post
{
    UserID = 1,
    Content = "Hello World!",
    MediaPath = "C:\\Images\\photo.jpg",
    MediaType = "Image",
    CreatedDate = DateTime.Now,
    IsActive = true
};

var result = postService.CreatePost(newPost);
if (result.Item1)
    MessageBox.Show(result.Item2); // "Bài vi?t ?ã ???c t?o thành công"
else
    MessageBox.Show("Error: " + result.Item2);
```

---

### UpdatePost
```csharp
public (bool, string) UpdatePost(Post post)
```
**Description:** Updates an existing post

**Parameters:**
- `post` - Post object with updated Content/MediaPath and PostID

**Returns:** Tuple of (success: bool, message: string)

**Example:**
```csharp
post.Content = "Updated content";
post.MediaPath = "C:\\Images\\new-photo.jpg";
var result = postService.UpdatePost(post);
```

---

### DeletePost
```csharp
public (bool, string) DeletePost(int postID)
public (bool, string) DeletePost(int postID, int userID)
```
**Description:** Soft deletes a post (marks IsActive = 0)

**Parameters:**
- `postID` - Post to delete
- `userID` - User deleting (optional ownership check)

**Returns:** Tuple of (success: bool, message: string)

**Security:** Only call if current user owns the post

---

### LikePost
```csharp
public (bool, string) LikePost(int userID, int postID)
```
**Description:** Adds a like from user to post

**Parameters:**
- `userID` - User liking
- `postID` - Post being liked

**Returns:** Tuple of (success: bool, message: string)

**Behavior:** Ignores if already liked (duplicate check in SQL)

---

### UnlikePost
```csharp
public (bool, string) UnlikePost(int userID, int postID)
```
**Description:** Removes a like from user to post

**Returns:** Tuple of (success: bool, message: string)

---

### SavePost
```csharp
public (bool, string) SavePost(int userID, int postID)
```
**Description:** Saves a post to user's saved list

**Parameters:**
- `userID` - User saving
- `postID` - Post being saved

**Returns:** Tuple of (success: bool, message: string)

---

### UnsavePost
```csharp
public (bool, string) UnsavePost(int userID, int postID)
```
**Description:** Removes a post from user's saved list

**Returns:** Tuple of (success: bool, message: string)

---

## CommentService

### GetCommentsByPost
```csharp
public List<Comment> GetCommentsByPost(int postID)
```
**Description:** Retrieves all comments on a post

**Parameters:**
- `postID` - Post to get comments for

**Returns:** List of Comment objects

---

### AddComment
```csharp
public (bool, string) AddComment(Comment comment)
```
**Description:** Creates a new comment on a post

**Parameters:**
- `comment` - Comment object with PostID, UserID, Content

**Validation:**
- Content required (not empty)
- Content max length: 1000 characters

**Returns:** Tuple of (success: bool, message: string)

**Example:**
```csharp
var newComment = new Comment
{
    PostID = 5,
    UserID = 1,
    Content = "Great post!",
    CreatedDate = DateTime.Now,
    IsActive = true
};

var result = commentService.AddComment(newComment);
```

---

### UpdateComment
```csharp
public (bool, string) UpdateComment(Comment comment)
```
**Description:** Updates an existing comment

**Parameters:**
- `comment` - Comment object with CommentID and updated Content

**Validation:** Same as AddComment

**Returns:** Tuple of (success: bool, message: string)

---

### DeleteComment
```csharp
public (bool, string) DeleteComment(int commentID)
public (bool, string) DeleteComment(int commentID, int userID)
```
**Description:** Soft deletes a comment (marks IsActive = 0)

**Parameters:**
- `commentID` - Comment to delete
- `userID` - User deleting (optional ownership check)

**Returns:** Tuple of (success: bool, message: string)

---

## ShareService

### SharePost
```csharp
public (bool, string) SharePost(int userID, int postID)
```
**Description:** Records a share of a post

**Parameters:**
- `userID` - User sharing
- `postID` - Post being shared

**Returns:** Tuple of (success: bool, message: string)

**Example:**
```csharp
var result = shareService.SharePost(userId: 1, postId: 5);
if (result.Item1)
    MessageBox.Show("Post shared successfully!");
```

---

### UnsharePost
```csharp
public (bool, string) UnsharePost(int userID, int postID)
```
**Description:** Removes a share record

**Returns:** Tuple of (success: bool, message: string)

---

### GetShareCount
```csharp
public int GetShareCount(int postID)
```
**Description:** Gets share count for a post

**Returns:** Integer count of shares

---

## Data Models

### Post
```csharp
public class Post
{
    public int PostID { get; set; }              // Primary key
    public int UserID { get; set; }              // Creator
    public string Username { get; set; }         // Display name
    public string UserAvatar { get; set; }       // Avatar path
    public string Content { get; set; }          // Post text
    public string MediaPath { get; set; }        // Image/video path
    public string MediaType { get; set; }        // "Image" or "Video"
    public DateTime CreatedDate { get; set; }    // Post timestamp
    public int LikeCount { get; set; }           // Like count
    public int CommentCount { get; set; }        // Comment count
    public int ShareCount { get; set; }          // Share count
    public bool IsActive { get; set; }           // Soft delete flag
    public bool IsLiked { get; set; }            // Current user likes?
    public bool IsSaved { get; set; }            // Current user saved?
}
```

### Comment
```csharp
public class Comment
{
    public int CommentID { get; set; }           // Primary key
    public int PostID { get; set; }              // Parent post
    public int UserID { get; set; }              // Author
    public string Username { get; set; }         // Display name
    public string UserAvatar { get; set; }       // Avatar path
    public string Content { get; set; }          // Comment text
    public DateTime CreatedDate { get; set; }    // Comment timestamp
    public bool IsActive { get; set; }           // Soft delete flag
}
```

---

## UI Components

### ucSocialNetworkPage
```csharp
public partial class ucSocialNetworkPage : UserControl
{
    // Events
    public event EventHandler OnPostCreated;
    public event EventHandler OnPostDeleted;
    public event EventHandler OnPostLiked;
    public event EventHandler OnCommentAdded;
    
    // Methods
    public void LoadFeed()
    public void RefreshFeed()
    public void CreatePost()
}
```

### ucPostCard
```csharp
public partial class ucPostCard : UserControl
{
    // Events
    public event EventHandler OnLikeClicked;
    public event EventHandler OnCommentClicked;
    public event EventHandler OnSaveClicked;
    public event EventHandler OnDeleteClicked;
    public event EventHandler OnEditClicked;
    public event EventHandler OnShareClicked;
    
    // Methods
    public void LoadPost(Post post, int currentUserID)
    public void UpdateLikeStatus(bool isLiked, int newLikeCount)
    public void UpdateCommentCount(int newCount)
    public void UpdateShareCount(int newCount)
    public void UpdateSaveStatus(bool isSaved)
}
```

---

## Forms

### frmCreateEditPost
```csharp
public partial class frmCreateEditPost : Form
{
    // Constructor
    public frmCreateEditPost(Post post, int currentUserID)
    // post: null for new, existing Post for edit
    
    // DialogResult
    DialogResult.OK      // Post created/updated
    DialogResult.Cancel  // User cancelled
}
```

### frmCommentDialog
```csharp
public partial class frmCommentDialog : Form
{
    // Constructor
    public frmCommentDialog(Post post, int currentUserID)
    
    // Full comment management (view, add, edit, delete)
}
```

### frmSavedPosts
```csharp
public partial class frmSavedPosts : Form
{
    // Shows user's saved posts with full interaction
}
```

---

## Utility Classes

### MediaHelper
```csharp
public static class MediaHelper
{
    public static string SaveMediaFile(string sourceFilePath)
    // Copies media to app Resources folder
    // Returns: new path or null on failure
    
    public static bool DeleteMediaFile(string filePath)
    // Deletes media file from app directory
    // Returns: success status
    
    public static string GetMediaType(string filePath)
    // Returns: "Image", "Video", or null
    
    public static bool IsValidMediaFile(string filePath)
    // Returns: true if valid media format
    
    public static string GetMediaDirectory()
    // Returns: path to media directory
}
```

### SessionManager
```csharp
public static class SessionManager
{
    public static int GetCurrentUserID()
    // Returns: logged-in user ID
}
```

---

## Error Handling

All service methods return `(bool, string)` tuples:

```csharp
var result = postService.CreatePost(post);
if (result.Item1)
{
    // Success
    MessageBox.Show(result.Item2); // "Bài vi?t ?ã ???c t?o thành công"
}
else
{
    // Failure
    MessageBox.Show(result.Item2); // Error message in Vietnamese
}
```

### Common Error Messages
- "L?i t?i newsfeed: [exception]"
- "Không th? t?o bài vi?t"
- "D? li?u bình lu?n không h?p l?"
- "N?i dung bình lu?n không ???c tr?ng"
- "Bình lu?n không ???c v??t quá 1000 ký t?"

---

## Database Queries

### Get Newsfeed with Status
```sql
SELECT p.PostID, p.UserID, u.FullName AS Username, u.Avatar AS UserAvatar,
       p.Content, p.MediaPath, p.MediaType, p.CreatedDate, p.IsActive,
       (SELECT COUNT(*) FROM PostLikes WHERE PostID = p.PostID) AS LikeCount,
       (SELECT COUNT(*) FROM Comments WHERE PostID = p.PostID AND IsActive = 1) AS CommentCount,
       (SELECT COUNT(*) FROM PostShares WHERE PostID = p.PostID) AS ShareCount,
       CASE WHEN pl.LikeID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked,
       CASE WHEN ps.SaveID IS NOT NULL THEN 1 ELSE 0 END AS IsSaved
FROM Posts p
INNER JOIN Users u ON p.UserID = u.UserID
LEFT JOIN PostLikes pl ON p.PostID = pl.PostID AND pl.UserID = @CurrentUserID
LEFT JOIN PostSaves ps ON p.PostID = ps.PostID AND ps.UserID = @CurrentUserID
WHERE p.IsActive = 1
ORDER BY p.CreatedDate DESC
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
```

---

## Response Codes

| Code | Meaning |
|------|---------|
| 200 | Success |
| 400 | Validation error |
| 401 | Unauthorized |
| 404 | Not found |
| 500 | Server error |

---

## Rate Limiting

No rate limiting currently implemented. Consider adding:
- Max posts per hour: 10
- Max comments per hour: 50
- Max likes per hour: 100

---

## Best Practices

1. **Always check return tuple**
   ```csharp
   var result = postService.CreatePost(post);
   if (result.Item1) { /* success */ }
   ```

2. **Validate user ownership before edit/delete**
   ```csharp
   if (_currentUserID == post.UserID) { /* allow */ }
   ```

3. **Handle exceptions gracefully**
   ```csharp
   try 
   {
       // Service call
   }
   catch (Exception ex)
   {
       MessageBox.Show("L?i: " + ex.Message);
   }
   ```

4. **Use proper date formatting**
   ```csharp
   // Use GetTimeAgo() for relative timestamps
   ```

5. **Validate input before service calls**
   ```csharp
   if (string.IsNullOrWhiteSpace(content))
       return;
   ```

---

## Version History

| Version | Date | Changes |
|---------|------|---------|
| 1.0.0 | 2024 | Initial release |
| 1.0.1 | 2024 | Added share functionality |
| 1.1.0 | TBD | Nested comments, reactions |

---

**Last Updated:** 2024
**Status:** Complete ?
