# Social Network - API Methods Summary

## PostService Methods

### Public Methods

#### `List<Post> GetNewsFeed(int currentUserID, int pageNumber = 1, int pageSize = 10)`
- L?y feed bài vi?t (newsfeed) theo trang
- Parameters:
  - `currentUserID`: ID user hi?n t?i (?? xác ??nh ?ã like/save ch?a)
  - `pageNumber`: S? trang (default = 1)
  - `pageSize`: S? bài vi?t/trang (default = 10)
- Returns: `List<Post>` - Danh sách bài vi?t

#### `List<Post> GetUserPosts(int userID, int currentUserID)`
- L?y t?t c? bài vi?t c?a 1 user
- Parameters:
  - `userID`: ID user c?n l?y bài vi?t
  - `currentUserID`: ID user hi?n t?i
- Returns: `List<Post>`

#### `List<Post> GetSavedPosts(int userID)`
- L?y t?t c? bài vi?t ?ã l?u c?a user
- Parameters:
  - `userID`: ID user hi?n t?i
- Returns: `List<Post>`

#### `(bool, string) CreatePost(Post post)`
- T?o bài vi?t m?i
- Parameters:
  - `post`: ??i t??ng Post ch?a d? li?u bài vi?t
- Returns: Tuple (thành công, tin nh?n)
- Validates: Content, mediaPath, mediaType

#### `(bool, string) UpdatePost(Post post)`
- C?p nh?t bài vi?t
- Parameters:
  - `post`: ??i t??ng Post (ph?i có PostID)
- Returns: Tuple (thành công, tin nh?n)

#### `(bool, string) DeletePost(int postID)`
- Xóa bài vi?t (soft delete)
- Parameters:
  - `postID`: ID bài vi?t
- Returns: Tuple (thành công, tin nh?n)

#### `(bool, string) LikePost(int userID, int postID)`
- Like bài vi?t
- Parameters:
  - `userID`: ID user
  - `postID`: ID bài vi?t
- Returns: Tuple (thành công, tin nh?n)
- Notes: Không like 2 l?n cùng 1 bài

#### `(bool, string) UnlikePost(int userID, int postID)`
- B? like bài vi?t
- Parameters:
  - `userID`: ID user
  - `postID`: ID bài vi?t
- Returns: Tuple (thành công, tin nh?n)

#### `(bool, string) SavePost(int userID, int postID)`
- L?u bài vi?t
- Parameters:
  - `userID`: ID user
  - `postID`: ID bài vi?t
- Returns: Tuple (thành công, tin nh?n)

#### `(bool, string) UnsavePost(int userID, int postID)`
- B? l?u bài vi?t
- Parameters:
  - `userID`: ID user
  - `postID`: ID bài vi?t
- Returns: Tuple (thành công, tin nh?n)

---

## CommentService Methods

### Public Methods

#### `List<Comment> GetCommentsByPost(int postID)`
- L?y t?t c? bình lu?n c?a 1 bài vi?t
- Parameters:
  - `postID`: ID bài vi?t
- Returns: `List<Comment>`

#### `(bool, string) AddComment(Comment comment)`
- Thêm bình lu?n m?i
- Parameters:
  - `comment`: ??i t??ng Comment
- Returns: Tuple (thành công, tin nh?n)
- Validates:
  - Content không tr?ng
  - Content <= 1000 ký t?
  - UserID > 0, PostID > 0

#### `(bool, string) UpdateComment(Comment comment)`
- C?p nh?t bình lu?n
- Parameters:
  - `comment`: ??i t??ng Comment (ph?i có CommentID)
- Returns: Tuple (thành công, tin nh?n)
- Validates: Gi?ng AddComment

#### `(bool, string) DeleteComment(int commentID)`
- Xóa bình lu?n
- Parameters:
  - `commentID`: ID bình lu?n
- Returns: Tuple (thành công, tin nh?n)

---

## Post Model

```csharp
public class Post
{
    public int PostID { get; set; }
    public int UserID { get; set; }
    public string Username { get; set; }           // Hi?n th?
    public string UserAvatar { get; set; }          // Hi?n th?
    public string Content { get; set; }
    public string MediaPath { get; set; }
    public string MediaType { get; set; }           // "image" ho?c "video"
    public DateTime CreatedDate { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public int ShareCount { get; set; }
    public bool IsActive { get; set; }
    public bool IsLiked { get; set; }               // C?a user hi?n t?i
    public bool IsSaved { get; set; }               // C?a user hi?n t?i
}
```

---

## Comment Model

```csharp
public class Comment
{
    public int CommentID { get; set; }
    public int PostID { get; set; }
    public int UserID { get; set; }
    public string Username { get; set; }           // Hi?n th?
    public string UserAvatar { get; set; }          // Hi?n th?
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}
```

---

## Usage Examples

### T?o bài vi?t
```csharp
var postService = new PostService();
var post = new Post
{
    UserID = SessionManager.GetCurrentUserID(),
    Content = "?ây là bài vi?t test",
    MediaPath = "C:\\path\\to\\image.jpg",
    MediaType = "image",
    CreatedDate = DateTime.Now,
    IsActive = true
};

var result = postService.CreatePost(post);
if (result.Item1)
{
    MessageBox.Show("T?o bài vi?t thành công!");
}
```

### Like bài vi?t
```csharp
var result = postService.LikePost(userID, postID);
if (result.Item1)
{
    // Update UI
    post.IsLiked = true;
    post.LikeCount++;
}
```

### Thêm bình lu?n
```csharp
var commentService = new CommentService();
var comment = new Comment
{
    PostID = postID,
    UserID = userID,
    Content = "Bài vi?t hay quá!"
};

var result = commentService.AddComment(comment);
```

### L?y feed
```csharp
var posts = postService.GetNewsFeed(userID, pageNumber: 1, pageSize: 10);
foreach (var post in posts)
{
    // Hi?n th? post
}
```

---

## Error Handling

T?t c? Service methods tr? v? Tuple `(bool success, string message)`:
- `Item1`: `true` = thành công, `false` = th?t b?i
- `Item2`: Tin nh?n mô t? (ti?ng Vi?t)

### Ví d?
```csharp
var result = postService.CreatePost(post);
if (!result.Item1)
{
    MessageBox.Show(result.Item2, "L?i");
}
```

---

## Database Queries

### PostRepository Methods
- `GetNewsFeed()`: SELECT v?i OFFSET/FETCH (paging)
- `GetUserPosts()`: SELECT WHERE UserID
- `GetSavedPosts()`: SELECT t? PostSaves table
- `CreatePost()`: INSERT
- `UpdatePost()`: UPDATE
- `DeletePost()`: UPDATE IsActive = 0 (soft delete)
- `LikePost()`: INSERT vào PostLikes (ki?m tra duplicate)
- `UnlikePost()`: DELETE t? PostLikes
- `SavePost()`: INSERT vào PostSaves (ki?m tra duplicate)
- `UnsavePost()`: DELETE t? PostSaves

### CommentRepository Methods
- `GetCommentsByPost()`: SELECT WHERE PostID
- `AddComment()`: INSERT
- `UpdateComment()`: UPDATE
- `DeleteComment()`: UPDATE IsActive = 0

---

## Performance Notes

- ?? GetNewsFeed() s? d?ng OFFSET/FETCH cho pagination t?t
- ?? Queries tính LikeCount, CommentCount, ShareCount inline
- ?? IsLiked, IsSaved xác ??nh b?ng LEFT JOIN v?i user hi?n t?i
- ? Nên cache ho?c lazy-load avatar n?u c?n t?i ?u

---

## Security Considerations

- ? SQL Injection: S? d?ng SqlParameters
- ? Authorization: Ki?m tra UserID khi update/delete
- ? Input Validation: Validator classes có s?n
- ? Soft Delete: Không xóa v?nh vi?n, ch? ?ánh d?u
