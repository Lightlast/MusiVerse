# ? REFACTOR: Move UI Creation Code to ucPostItem

## ?? Thay ??i

### 1. ucSocialNetworkPage.cs (T? 400+ lines ? ~200 lines)
**Xóa**:
- ? `CreatePostCard()` (~180 lines)
- ? `CreateActionsPanel()` 
- ? `CreateStatsPanel()`
- ? `CreateHeaderPanel()`
- ? `LoadUserAvatar()`
- ? `GetTimeAgo()`

**Gi? l?i**:
- ? `LoadFeed()` - G?i `postCard.BuildUI()`
- ? `HandleLike()`, `HandleSave()`, `HandleShare()`
- ? `ShowCommentDialog()`, `ShowEditPostForm()`, `DeletePost()`
- ? `ShowPostMenu()`, `ShowUserProfile()`
- ? Button event handlers

### 2. ucPostItem.cs (T? ~80 lines ? ~400 lines)
**Thêm**:
- ? `BuildUI()` - Main method to build card
- ? `CreateActionsPanel()` - Build action buttons
- ? `CreateStatsPanel()` - Build stats
- ? `CreateHeaderPanel()` - Build header
- ? `LoadUserAvatar()` - Load user avatar
- ? `GetTimeAgo()` - Format time

---

## ??? Architecture

### Tr??c (Sai)
```
ucSocialNetworkPage
?? LoadFeed()
?? CreatePostCard() ? (UI creation ? ?ây)
?? CreateActionsPanel()
?? CreateStatsPanel()
?? CreateHeaderPanel()
?? LoadUserAvatar()
?? GetTimeAgo()

ucPostItem
?? LoadPost()
```

### Sau (?úng)
```
ucSocialNetworkPage
?? LoadFeed()
?  ?? postCard.BuildUI() ? Call here
?? HandleLike()
?? HandleSave()
?? Other handlers...

ucPostItem
?? BuildUI() ? (UI creation ? ?ây)
?? CreateActionsPanel()
?? CreateStatsPanel()
?? CreateHeaderPanel()
?? LoadUserAvatar()
?? GetTimeAgo()
```

---

## ?? BuildUI() Method

```csharp
public void BuildUI(Post post, int currentUserID, 
    Action<Post> onLike, 
    Action<Post> onComment, 
    Action<Post> onSave,
    Action<Post> onEdit, 
    Action<Post> onShare,
    Action<int> onProfile, 
    Action<Post> onMenu)
{
    // Clear old controls
    this.Controls.Clear();
    
    // Add controls in REVERSE order (Dock = DockStyle.Top)
    // 5. pnlActions (add last ? appears at bottom)
    // 4. pnlStats
    // 3. pbMedia
    // 2. lblContent
    // 1. pnlHeader (add first ? appears at top)
    
    this.Height = cardHeight;
}
```

---

## ?? Usage in ucSocialNetworkPage

**Old Way** (? Wrong):
```csharp
Panel postCard = CreatePostCard(post);  // ? Code here
```

**New Way** (? Right):
```csharp
ucPostCard postCard = new ucPostCard();
postCard.BuildUI(post, _currentUserID,
    (p) => HandleLike(p),
    (p) => ShowCommentDialog(p),
    (p) => HandleSave(p),
    (p) => ShowEditPostForm(p),
    (p) => HandleShare(p),
    (uid) => ShowUserProfile(uid),
    (p) => ShowPostMenu(p)
);
```

---

## ? Benefits

| Aspect | Before | After |
|--------|--------|-------|
| UI Code | ucSocialNetworkPage | **ucPostItem** ? |
| Separation | ? Mixed | ? Separated |
| Responsibility | ? Two classes | ? One class (ucPostItem) |
| Maintainability | ? Hard | ? Easy |
| Reusability | ? Only in this page | ? Any page can use |
| Lines (ucSocialNetworkPage) | 400+ | **~200** |
| Lines (ucPostItem) | ~80 | **~400** |

---

## ?? Code Flow

**LoadFeed()**:
```
1. Get posts from database
2. For each post:
   a. Create new ucPostCard()
   b. Call postCard.BuildUI()
   c. BuildUI() creates all controls
   d. Wire up event handlers (lambda functions)
   e. Add to panel
```

**Event Handling**:
```
User clicks Like button
  ?
btnLike.Click triggered
  ?
Lambda: (s, e) => onLike?.Invoke(post)
  ?
LoadFeed() passed: (p) => HandleLike(p)
  ?
HandleLike(post) executed
  ?
Like counted, UI reloaded
```

---

## ?? File Size Changes

| File | Before | After | Change |
|------|--------|-------|--------|
| ucSocialNetworkPage.cs | 450 | 200 | -250 (-55%) |
| ucPostItem.cs | 80 | 400 | +320 (+400%) |
| **Total** | **530** | **600** | +70 |

---

## ? Build Status

? **Build**: SUCCESSFUL
? **Errors**: 0
? **Warnings**: 0

---

## ?? Responsibilities

### ucSocialNetworkPage.cs
- ? Load posts from database
- ? Handle like/save logic
- ? Open dialogs (comment, edit, etc.)
- ? Manage pagination

### ucPostItem.cs
- ? Build post card UI
- ? Create panels & controls
- ? Format data (avatar, time-ago)
- ? Wire up UI events

---

## ?? Reusability

**Now ucPostItem can be used in**:
- ucSocialNetworkPage ?
- frmMyPosts ?
- frmSavedPosts ?
- frmTrendingPosts ?
- frmUserProfile ?
- Any other page ?

**Just call**:
```csharp
postCard.BuildUI(post, userID, handlers...);
```

---

**Status**: ? REFACTORED & CLEAN
**Separation**: ? UI in ucPostItem
**Build**: ? SUCCESSFUL
