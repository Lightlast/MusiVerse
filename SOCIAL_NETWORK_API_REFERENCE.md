# Social Network API Reference

## ?? Complete Method Reference

---

## `UcSocialPage` - Main Social Network Page

### Public Methods

#### `SetupUI()`
Initializes the UI components for the social network page.
- **Returns**: `void`
- **Description**: Sets up header with buttons, creates feed panel, and initializes scroll event

#### `LoadNewsFeed()`
Loads posts from database with pagination.
- **Returns**: `void`
- **Parameters**: None
- **Description**: Retrieves posts from `PostService.GetNewsFeed()` and adds them to feed
- **Pagination**: 5 posts per page (configurable via `PAGE_SIZE`)
- **Exceptions**: Catches and displays MessageBox on error

#### `AddPostToFeed(Post post)`
Adds a single post card to the feed with all event handlers.
- **Parameters**:
  - `post` (Post): Post object to display
- **Returns**: `void`
- **Description**: Creates ucPostCard, subscribes to events, adds to panel

### Private Methods

#### `HandleLikePost(Post post, ucPostCard postCard)`
Handles like/unlike toggle for a post.
- **Parameters**:
  - `post` (Post): Post object to toggle like
  - `postCard` (ucPostCard): Post card component
- **Returns**: `void`
- **Logic**: 
  - If liked: calls `UnlikePost()`, decrements count
  - If not liked: calls `LikePost()`, increments count
  - Updates UI via `UpdateLikeStatus()`

#### `HandleSavePost(Post post, ucPostCard postCard)`
Handles save/unsave toggle for a post.
- **Parameters**:
  - `post` (Post): Post to toggle save
  - `postCard` (ucPostCard): Post card component
- **Returns**: `void`

#### `HandleDeletePost(Post post, ucPostCard postCard)`
Handles post deletion with confirmation.
- **Parameters**:
  - `post` (Post): Post to delete
  - `postCard` (ucPostCard): Post card to remove from UI
- **Returns**: `void**
- **Behavior**: Shows confirmation dialog, calls service, removes from feed

#### `HandleSharePost(Post post)`
Handles sharing post to clipboard.
- **Parameters**:
  - `post` (Post): Post to share
- **Returns**: `void`
- **Action**: Copies "Bài vi?t t? {Username}: {Content}" to clipboard

#### `ShowCreatePostForm()`
Opens the create post dialog.
- **Returns**: `void`
- **Opens**: `frmCreatePost` form
- **OnSuccess**: Reloads newsfeed with page 1

#### `ShowEditPostForm(Post post, ucPostCard postCard)`
Opens the edit post dialog.
- **Parameters**:
  - `post` (Post): Post to edit
  - `postCard` (ucPostCard): Post card component
- **Returns**: `void`
- **Validation**: Checks if current user is post owner
- **OnSuccess**: Removes card and reloads feed

#### `ShowCommentForm(Post post)`
Opens the comment section dialog.
- **Parameters**:
  - `post` (Post): Post to view comments
- **Returns**: `void`
- **Opens**: `frmCommentSection` form

#### `ShowMyPostsForm()`
Opens the user's posts window.
- **Returns**: `void`
- **Opens**: `frmMyPosts` form

#### `ShowSavedPostsForm()`
Opens the saved posts window.
- **Returns**: `void`
- **Opens**: `frmSavedPosts` form

#### `ShowUserProfile(int userID)`
Opens user profile (placeholder).
- **Parameters**:
  - `userID` (int): User ID to view
- **Returns**: `void`
- **Note**: Currently shows placeholder message

---

## `ucPostCard` - Post Display Component

### Public Methods

#### `LoadPost(Post post, int currentUserID)`
Loads post data into the card and displays it.
- **Parameters**:
  - `post` (Post): Post object to display
  - `currentUserID` (int): Current logged-in user ID
- **Returns**: `void`
- **Behavior**: Clears existing controls and calls `DisplayPostData()`

#### `UpdateLikeStatus(bool isLiked, int newLikeCount)`
Updates the like button and count after like/unlike action.
- **Parameters**:
  - `isLiked` (bool): New like status
  - `newLikeCount` (int): Updated like count
- **Returns**: `void**
- **Behavior**: Refreshes UI with new like state

#### `UpdateSaveStatus(bool isSaved)`
Updates the save button after save/unsave action.
- **Parameters**:
  - `isSaved` (bool): New save status
- **Returns**: `void**
- **Behavior**: Refreshes UI with new save state

### Public Properties

#### `PostData`
Gets or sets the Post object.
- **Type**: `Post`
- **Access**: Public get/set

### Public Events

```csharp
public event EventHandler OnLikeClicked;
public event EventHandler OnCommentClicked;
public event EventHandler OnSaveClicked;
public event EventHandler OnDeleteClicked;
public event EventHandler OnEditClicked;
public event EventHandler OnShareClicked;
public event EventHandler OnProfileClicked;
public event EventHandler OnPlaySongClicked;
```

### Private Methods

#### `DisplayPostData()`
Renders all UI components for the post.
- **Returns**: `void`
- **Components Created**:
  - Header with avatar, username, date
  - Menu button for owner
  - Content label
  - Media picture box
  - Stats panel
  - Action buttons panel

#### `ShowPostMenu(Button btnMenu)`
Shows context menu for post owner.
- **Parameters**:
  - `btnMenu` (Button): Menu button
- **Returns**: `void**
- **Options**: Edit, Delete

#### `LoadUserAvatar(string avatarPath)`
Loads user avatar image or creates default.
- **Parameters**:
  - `avatarPath` (string): Path to avatar file
- **Returns**: `Image`
- **Fallback**: Default avatar with "??" emoji if file not found

#### `GetTimeAgo(DateTime date)`
Formats date as relative time string.
- **Parameters**:
  - `date` (DateTime): Date to format
- **Returns**: `string`
- **Examples**: "v?a xong", "5 phút tr??c", "2 gi? tr??c"

---

## `frmCreatePost` - Create Post Form

### Public Methods

#### Constructor: `frmCreatePost()`
Initializes the form and sets up UI.
- **Parameters**: None
- **Initialization**: 
  - Creates new PostService
  - Calls SetupUI()

### Private Methods

#### `SetupUI()`
Sets up all form UI components.
- **Returns**: `void**
- **Components**:
  - Title label
  - User info panel
  - Content textarea
  - Media selection
  - Publish/Cancel buttons

#### `SelectMedia()`
Opens file dialog to select media.
- **Returns**: `void**
- **Dialog**: OpenFileDialog
- **Filters**: Image/Video files
- **Behavior**: Loads and previews selected image

#### `PublishPost()`
Creates and publishes the post.
- **Returns**: `void**
- **Validation**:
  - Content + Media not both empty
- **Process**:
  - Creates Post object
  - Calls `PostService.CreatePost()`
  - Shows success/error message
  - Closes dialog with OK result

#### `GetMediaType(string filePath)`
Determines media type from file extension.
- **Parameters**:
  - `filePath` (string): File path to check
- **Returns**: `string` - "image", "video", or "unknown"

---

## `frmEditPost` - Edit Post Form

### Public Methods

#### Constructor: `frmEditPost(Post post)`
Initializes form with post data.
- **Parameters**:
  - `post` (Post): Post object to edit
- **Pre-fills**: Content and media from post

### Private Methods

#### `SetupUI()`
Sets up UI with pre-filled post data.
- **Returns**: `void**

#### `SelectMedia()`
Opens file dialog to change media.
- **Returns**: `void**

#### `SaveChanges()`
Saves updated post to database.
- **Returns**: `void**
- **Process**:
  - Validates content/media
  - Updates Post object
  - Calls `PostService.UpdatePost()`
  - Shows success/error message
  - Closes dialog with OK result

#### `GetMediaType(string filePath)`
Same as frmCreatePost.

---

## `frmCommentSection` - Comments Dialog

### Public Methods

#### Constructor: `frmCommentSection(Post post)`
Initializes comment section for a post.
- **Parameters**:
  - `post` (Post): Post to view comments

### Private Methods

#### `SetupUI()`
Sets up comment section UI.
- **Returns**: `void**
- **Components**:
  - Post preview header
  - Comments list panel
  - Comment input area

#### `LoadComments()`
Loads all comments for the post.
- **Returns**: `void**
- **Process**:
  - Calls `CommentService.GetCommentsByPost()`
  - Creates comment controls for each

#### `AddCommentControl(Comment comment)`
Adds a single comment to the display.
- **Parameters**:
  - `comment` (Comment): Comment to display
- **Returns**: `void**
- **Components**: Avatar, username, date, content, delete button

#### `SendComment()`
Adds a new comment to the post.
- **Returns**: `void**
- **Validation**: Content not empty
- **Process**:
  - Creates Comment object
  - Calls `CommentService.AddComment()`
  - Reloads comments
  - Updates comment count

#### `DeleteComment(Comment comment, Panel pnlComment)`
Deletes a comment after confirmation.
- **Parameters**:
  - `comment` (Comment): Comment to delete
  - `pnlComment` (Panel): Comment panel to remove
- **Returns**: `void**

#### `LoadUserAvatar(string avatarPath)`
Same as ucPostCard.
- **Returns**: `Image`

#### `GetTimeAgo(DateTime date)`
Shorter format than ucPostCard.
- **Returns**: `string` - "v?a xong", "5m tr??c", "2h tr??c"

---

## `frmMyPosts` - User's Posts Window

### Public Methods

#### Constructor: `frmMyPosts(User user = null)`
Initializes window for viewing user's posts.
- **Parameters**:
  - `user` (User, optional): User to view posts, null for current user
- **Behavior**: Sets title and loads appropriate posts

### Private Methods

#### `SetupUI()`
Sets up window UI.
- **Returns**: `void**

#### `LoadUserPosts()`
Loads posts for specified or current user.
- **Returns**: `void**
- **Process**:
  - Gets target user ID
  - Calls `PostService.GetUserPosts()`
  - Adds posts to display

#### `AddPostToList(Post post, int currentUserID)`
Adds post card with appropriate event handlers.
- **Parameters**:
  - `post` (Post): Post to display
  - `currentUserID` (int): Current user ID
- **Returns**: `void**
- **Behavior**: Restricts edit/delete to post owner

#### `HandleLikePost()`, `HandleSavePost()`, `HandleDeletePost()`
Same as UcSocialPage.

#### `ShowEditPostForm(Post post, ucPostCard postCard)`
Opens edit dialog and reloads on success.
- **Returns**: `void**

#### `ShowCommentForm(Post post)`
Opens comment section dialog.
- **Returns**: `void**

---

## `frmSavedPosts` - Saved Posts Window

### Public Methods

#### Constructor: `frmSavedPosts()`
Initializes window for viewing saved posts.

### Private Methods

#### `SetupUI()`
Sets up window UI.
- **Returns**: `void**

#### `LoadSavedPosts()`
Loads all saved posts for current user.
- **Returns**: `void**
- **Process**:
  - Calls `PostService.GetSavedPosts()`
  - Adds posts to display

#### `AddPostToList(Post post)`
Adds post card with save removal capability.
- **Parameters**:
  - `post` (Post): Post to display
- **Returns**: `void**

#### `HandleRemoveFromSaved(Post post, ucPostCard postCard)`
Removes post from saved list.
- **Parameters**:
  - `post` (Post): Post to unsave
  - `postCard` (ucPostCard): Card to remove
- **Returns**: `void**
- **Process**:
  - Calls `PostService.UnsavePost()`
  - Removes from UI

#### Other handlers
Same as UcSocialPage.

---

## `PostService` - Post Operations Service

### Public Methods

#### `GetNewsFeed(int currentUserID, int pageNumber = 1, int pageSize = 10)`
Gets paginated newsfeed.
- **Parameters**:
  - `currentUserID` (int): Current user ID
  - `pageNumber` (int): Page number (1-based)
  - `pageSize` (int): Posts per page
- **Returns**: `List<Post>`
- **Database**: Calls `PostRepository.GetNewsFeed()`

#### `GetUserPosts(int userID, int currentUserID)`
Gets all posts by specific user.
- **Parameters**:
  - `userID` (int): User ID to get posts
  - `currentUserID` (int): Current user ID
- **Returns**: `List<Post>`

#### `GetSavedPosts(int userID)`
Gets all posts saved by user.
- **Parameters**:
  - `userID` (int): User ID
- **Returns**: `List<Post>`

#### `CreatePost(Post post)`
Creates a new post.
- **Parameters**:
  - `post` (Post): Post object to create
- **Returns**: `(bool, string)` - Success, Message
- **Validation**: Calls `PostValidator.ValidateCreatePost()`

#### `UpdatePost(Post post)`
Updates existing post.
- **Parameters**:
  - `post` (Post): Post with updated data
- **Returns**: `(bool, string)` - Success, Message
- **Validation**: Calls `PostValidator.ValidateUpdatePost()`

#### `DeletePost(int postID)`
Soft deletes a post.
- **Parameters**:
  - `postID` (int): Post ID to delete
- **Returns**: `(bool, string)` - Success, Message

#### `LikePost(int userID, int postID)`
Adds like to post.
- **Parameters**:
  - `userID` (int): User adding like
  - `postID` (int): Post to like
- **Returns**: `(bool, string)` - Success, Message

#### `UnlikePost(int userID, int postID)`
Removes like from post.
- **Parameters**:
  - `userID` (int): User removing like
  - `postID` (int): Post to unlike
- **Returns**: `(bool, string)` - Success, Message

#### `SavePost(int userID, int postID)`
Saves post for later.
- **Parameters**:
  - `userID` (int): User saving post
  - `postID` (int): Post to save
- **Returns**: `(bool, string)` - Success, Message

#### `UnsavePost(int userID, int postID)`
Removes post from saved.
- **Parameters**:
  - `userID` (int): User unsaving post
  - `postID` (int): Post to unsave
- **Returns**: `(bool, string)` - Success, Message

---

## `CommentService` - Comment Operations Service

### Public Methods

#### `GetCommentsByPost(int postID)`
Gets all comments on a post.
- **Parameters**:
  - `postID` (int): Post ID
- **Returns**: `List<Comment>`

#### `AddComment(Comment comment)`
Creates a new comment.
- **Parameters**:
  - `comment` (Comment): Comment object
- **Returns**: `(bool, string)` - Success, Message
- **Validation**: 
  - Content not empty
  - Max 1000 characters

#### `UpdateComment(Comment comment)`
Updates a comment.
- **Parameters**:
  - `comment` (Comment): Updated comment
- **Returns**: `(bool, string)` - Success, Message

#### `DeleteComment(int commentID)`
Deletes a comment.
- **Parameters**:
  - `commentID` (int): Comment ID to delete
- **Returns**: `(bool, string)` - Success, Message

---

## Helper Methods

### `SessionManager` Integration

#### `GetCurrentUserID()`
Gets logged-in user's ID.
- **Returns**: `int`
- **Used in**: Determining post ownership, action attribution

#### `GetCurrentUsername()`
Gets logged-in user's name.
- **Returns**: `string`
- **Used in**: Displaying in UI

#### `IsLoggedIn()`
Checks if user is logged in.
- **Returns**: `bool`

---

## Event System

### Post Card Events

```csharp
postCard.OnLikeClicked += (s, e) => HandleLikePost(post, postCard);
postCard.OnCommentClicked += (s, e) => ShowCommentForm(post);
postCard.OnSaveClicked += (s, e) => HandleSavePost(post, postCard);
postCard.OnDeleteClicked += (s, e) => HandleDeletePost(post, postCard);
postCard.OnEditClicked += (s, e) => ShowEditPostForm(post, postCard);
postCard.OnShareClicked += (s, e) => HandleSharePost(post);
postCard.OnProfileClicked += (s, e) => ShowUserProfile(post.UserID);
```

---

## Constants

| Constant | Value | Location |
|----------|-------|----------|
| `PAGE_SIZE` | 5 | UcSocialPage |
| Max Comment Length | 1000 | CommentService |
| Max Post Content | 5000 | PostValidator |

---

## Return Value Tuples

### Standard Service Returns
```csharp
(bool success, string message)
```
- **Item1**: True if operation successful
- **Item2**: Message to display to user

---

## Exception Handling

All methods wrap database operations in try-catch:
```csharp
try
{
    // Database operation
}
catch (Exception ex)
{
    return (false, "L?i: " + ex.Message);
}
```

---

## Notes

- All dates/times use `DateTime.Now` (server time)
- All database queries use parameterized commands
- Soft delete used for data integrity
- One-to-one relationships between actions (one like per user/post)
- Responsive design adapts to container size

---

**Document Version**: 1.0  
**Last Updated**: 2024
