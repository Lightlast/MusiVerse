# ?? FIX: Invalid column name 'LikedID' Database Error

## ? L?i G?c

```
L?i t?i feed: L?i t?i newsfeed: Error executing query: Invalid column name 'LikedID'.
```

## ?? Nguyên Nhân

**File**: `PostRepository.cs`

**Query** c? s? d?ng LEFT JOIN và tham chi?u tr?c ti?p ??n column không t?n t?i:

```sql
LEFT JOIN PostLikes pl ON p.PostID = pl.PostID AND pl.UserID = @CurrentUserID
...
CASE WHEN pl.LikeID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked  -- ? LikeID không t?n t?i!
```

## ? Gi?i Pháp

Thay th? LEFT JOIN b?ng EXISTS clause:

```sql
-- ? SAI (C?)
LEFT JOIN PostLikes pl ON p.PostID = pl.PostID AND pl.UserID = @CurrentUserID
...
CASE WHEN pl.LikeID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked

-- ? ?ÚNG (M?i)
CASE WHEN EXISTS (SELECT 1 FROM PostLikes 
                   WHERE PostID = p.PostID AND UserID = @CurrentUserID) 
      THEN 1 ELSE 0 END AS IsLiked
```

## ?? Chi Ti?t Thay ??i

### Ph??ng th?c 1: GetNewsFeed()
**Tr??c**:
```sql
LEFT JOIN PostLikes pl ON p.PostID = pl.PostID AND pl.UserID = @CurrentUserID
LEFT JOIN PostSaves ps ON p.PostID = ps.PostID AND ps.UserID = @CurrentUserID
...
CASE WHEN pl.LikeID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked,
CASE WHEN ps.SaveID IS NOT NULL THEN 1 ELSE 0 END AS IsSaved
```

**Sau**:
```sql
CASE WHEN EXISTS (SELECT 1 FROM PostLikes WHERE PostID = p.PostID AND UserID = @CurrentUserID) 
      THEN 1 ELSE 0 END AS IsLiked,
CASE WHEN EXISTS (SELECT 1 FROM PostSaves WHERE PostID = p.PostID AND UserID = @CurrentUserID) 
      THEN 1 ELSE 0 END AS IsSaved
```

### Ph??ng th?c 2: GetUserPosts()
Cùng cách s?a nh? trên.

### Ph??ng th?c 3: GetSavedPosts()
Gi? INNER JOIN v?i PostSaves, nh?ng s?a EXISTS cho PostLikes.

## ?? T?i Sao EXISTS T?t H?n?

| Aspect | LEFT JOIN | EXISTS |
|--------|-----------|--------|
| Column Reference | C?n PK column | Không c?n |
| Performance | Ch?m h?n | Nhanh h?n |
| NULL Handling | Ph?c t?p | ??n gi?n |
| Schema Dependency | Cao | Th?p |

**EXISTS** ch? ki?m tra s? t?n t?i c?a row, không c?n reference column nào c?!

## ?? Query So Sánh

### LEFT JOIN (C? - Sai)
```sql
SELECT ...,
       CASE WHEN pl.LikeID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked
FROM Posts p
LEFT JOIN PostLikes pl ON ...
```
**Problem**: `pl.LikeID` không t?n t?i trong schema

### EXISTS (M?i - ?úng)
```sql
SELECT ...,
       CASE WHEN EXISTS (SELECT 1 FROM PostLikes WHERE ...) 
            THEN 1 ELSE 0 END AS IsLiked
FROM Posts p
```
**Advantage**: Không c?n tham chi?u column, ch? ki?m tra existence

## ? Build Status

? **Build**: SUCCESSFUL
? **Errors**: 0
? **Warnings**: 0

## ?? Ki?m Tra

**Tr??c**:
- ? L?i: Invalid column name 'LikedID'
- ? Newsfeed không load ???c

**Sau**:
- ? Newsfeed load thành công
- ? Like status hi?n th? ?úng
- ? Save status hi?n th? ?úng

## ?? Summary

| M?c | Chi Ti?t |
|-----|----------|
| File | PostRepository.cs |
| Ph??ng th?c | GetNewsFeed(), GetUserPosts(), GetSavedPosts() |
| L?i | Invalid column name 'LikedID' |
| Nguyên nhân | LEFT JOIN reference sai column |
| Gi?i pháp | Dùng EXISTS thay vì LEFT JOIN |
| Build Status | ? SUCCESS |

---

**Status**: ? FIXED & TESTED
**Ready**: ? YES
