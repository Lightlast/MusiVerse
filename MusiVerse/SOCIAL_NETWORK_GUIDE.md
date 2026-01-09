# MusiVerse Social Network - H??ng D?n S? D?ng

## ?? T?ng Quan
Ph?n Social Network c?a MusiVerse cung c?p m?t n?n t?ng t??ng tác ki?u Instagram cho các ngh? s? và ng??i dùng chia s? bài vi?t, bình lu?n, và t??ng tác v?i c?ng ??ng.

## ?? Tính N?ng Chính

### 1. **T?o Bài Vi?t** (Create Post)
- **Nút "?? T?o bài vi?t"** trong top bar c?a Social Feed
- H? tr?:
  - ?? N?i dung v?n b?n
  - ??? Hình ?nh (JPG, PNG, GIF)
  - ?? Video (MP4, AVI, MOV)
- Dialog form: `frmCreateEditPost`
- T? ??ng l?u vào database

### 2. **Ch?nh S?a Bài Vi?t** (Edit Post)
- Menu "?" (ba ch?m) ? góc ph?i bài vi?t (ch? hi?n th? cho ch? bài)
- Ch?n "?? Ch?nh s?a"
- C?p nh?t n?i dung ho?c hình ?nh/video
- L?u thay ??i vào database

### 3. **Xóa Bài Vi?t** (Delete Post)
- Menu "?" ? "??? Xóa"
- Yêu c?u xác nh?n tr??c khi xóa
- Soft delete (?ánh d?u IsActive = 0)

### 4. **Like / Unlike** (?? Thích)
- Button "?? Thích" / "?? Thích" ? d??i m?i bài vi?t
- Hi?n th? t?ng s? l??t like
- C?p nh?t t?c th?i
- L?u vào b?ng `PostLikes`

### 5. **Bình Lu?n** (Comment)
- Button "?? Bình lu?n" ? d??i m?i bài vi?t
- M? dialog `frmCommentDialog`
- Tính n?ng:
  - Xem t?t c? bình lu?n
  - Thêm bình lu?n m?i
  - Xóa bình lu?n c?a chính mình
  - Hi?n th? tên user, avatar, th?i gian
  - Gi?i h?n 1000 ký t?/bình lu?n

### 6. **Chia S?** (Share)
- Button "?? Chia s?" ? d??i m?i bài vi?t
- Sao chép thông tin bài vi?t vào clipboard
- Hi?n th? tác gi? + n?i dung tóm t?t

### 7. **L?u Bài Vi?t** (Save)
- Button "?? L?u" / "?? ?ã l?u" ? d??i m?i bài vi?t
- L?u bài vi?t yêu thích
- Truy c?p t? button "?? Bài vi?t ?ã l?u" trong top bar
- M? form `frmSavedPosts`

### 8. **Xem Bài Vi?t ?ã L?u** (Saved Posts)
- Button "?? Bài vi?t ?ã l?u" trong top bar
- Hi?n th? t?t c? bài vi?t ?ã l?u c?a user hi?n t?i
- Ch?c n?ng:
  - Like/Unlike
  - Bình lu?n
  - B? l?u bài vi?t

### 9. **Feed Paging** (T?i Thêm)
- Button "?? T?i thêm bài vi?t" ? d??i cùng
- T?i 10 bài vi?t/trang
- H? tr? pagination

## ?? Th?ng Kê Hi?n Th?
M?i bài vi?t hi?n th?:
- **?? S? l??t like**
- **?? S? bình lu?n**
- **?? S? l?n chia s?**

## ??? C?u Trúc T?p

### UserControl
- `ucSocialNetworkPage.cs` - Main page hi?n th? feed
- `ucSocialNetworkPage.Designer.cs` - Designer

### Forms
- `frmCreateEditPost.cs` - Form t?o/ch?nh s?a bài vi?t
- `frmCreateEditPost.Designer.cs` - Designer
- `frmCommentDialog.cs` - Dialog bình lu?n
- `frmCommentDialog.Designer.cs` - Designer
- `frmSavedPosts.cs` - Form xem bài vi?t ?ã l?u
- `frmSavedPosts.Designer.cs` - Designer

### Services
- `PostService.cs` - Qu?n lý bài vi?t
- `CommentService.cs` - Qu?n lý bình lu?n

### Repository
- `PostRepository.cs` - L?y d? li?u bài vi?t t? DB
- `CommentRepository.cs` - L?y d? li?u bình lu?n t? DB

## ??? Database Schema

### B?ng Posts
```sql
- PostID (PK)
- UserID (FK)
- Content (nvarchar(max))
- MediaPath (nvarchar(255))
- MediaType (nvarchar(50))
- CreatedDate (datetime)
- IsActive (bit)
```

### B?ng PostLikes
```sql
- LikeID (PK)
- UserID (FK)
- PostID (FK)
- LikeDate (datetime)
```

### B?ng PostSaves
```sql
- SaveID (PK)
- UserID (FK)
- PostID (FK)
- SaveDate (datetime)
```

### B?ng PostShares
```sql
- ShareID (PK)
- UserID (FK)
- PostID (FK)
- ShareDate (datetime)
```

### B?ng Comments
```sql
- CommentID (PK)
- PostID (FK)
- UserID (FK)
- Content (nvarchar(1000))
- CreatedDate (datetime)
- IsActive (bit)
```

## ?? Giao Di?n & Màu S?c

| Ph?n T? | Màu | Code |
|---------|-----|------|
| Background Feed | Xám nh?t | `Color.FromArgb(245, 245, 245)` |
| Bài vi?t | Tr?ng | `Color.White` |
| Tiêu ?? | Xanh d??ng | `Color.FromArgb(30, 144, 255)` |
| Like Button (?ã like) | ?? | `Color.FromArgb(220, 20, 60)` |
| Save Button (?ã l?u) | Xanh nh?t | `Color.FromArgb(100, 149, 237)` |
| Text th??ng | ?en | `Color.Black` |
| Text m? | Xám | `Color.Gray` |

## ?? Quy?n H?n & B?o M?t

- **Ch?nh s?a/Xóa**: Ch? ch? bài vi?t m?i có quy?n
- **Bình lu?n**: M?i user ?ã ??ng nh?p ??u có th? bình lu?n
- **Like/Save**: M?i user ?ã ??ng nh?p
- **User ID**: L?y t? `SessionManager.GetCurrentUserID()`

## ?? Cách S? D?ng

### Ng??i dùng bình th??ng:
1. Nh?n "?? T?o bài vi?t" ?? ??ng bài m?i
2. Nh?p n?i dung và ch?n hình ?nh/video (tùy ch?n)
3. Nh?n "?? ??ng bài" ?? l?u
4. Like, bình lu?n, chia s? bài vi?t khác
5. L?u bài vi?t yêu thích v?i "?? L?u"
6. Xem l?i bài vi?t ?ã l?u ? "?? Bài vi?t ?ã l?u"

### Ch? bài vi?t:
1. Nh?n menu "?" ? góc ph?i bài vi?t
2. Ch?n "?? Ch?nh s?a" ?? s?a ho?c "??? Xóa" ?? xóa

## ?? L?u Ý

- Bài vi?t ph?i có ít nh?t n?i dung text
- Hình ?nh/video là tùy ch?n
- Bình lu?n có gi?i h?n 1000 ký t?
- Xóa bài vi?t là v?nh vi?n (soft delete)
- Th?i gian hi?n th? d?ng t??ng ??i: "v?a xong", "5 phút tr??c", v.v.

## ?? Event Flow

```
1. T?o bài vi?t
   ucSocialNetworkPage ? frmCreateEditPost ? PostService.CreatePost()
   ? PostRepository.CreatePost() ? DB

2. Like bài vi?t
   HandleLike() ? PostService.LikePost() ? PostRepository.LikePost()

3. Bình lu?n
   ShowCommentDialog() ? frmCommentDialog ? CommentService.AddComment()

4. L?u bài vi?t
   HandleSave() ? PostService.SavePost() ? PostRepository.SavePost()

5. Xem bài vi?t ?ã l?u
   BtnSavedPosts_Click() ? frmSavedPosts ? LoadSavedPosts()
```

## ? Hoàn Thành
- ? UI ki?u Instagram
- ? T?o, ch?nh s?a, xóa bài vi?t
- ? Like/Unlike
- ? Bình lu?n
- ? Chia s? (sao chép clipboard)
- ? L?u bài vi?t
- ? Xem bài vi?t ?ã l?u
- ? Pagination
- ? Quy?n h?n ng??i dùng

## ?? Có Th? Phát Tri?n Thêm
- ?? Thông báo real-time
- ?? Follow/Unfollow
- ??? Hashtag & Mention
- ?? Video streaming
- ?? Analytics & Statistics
- ?? AI Recommendation
