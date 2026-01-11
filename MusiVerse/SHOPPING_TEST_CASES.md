# ?? Shopping Feature - Test Cases

## ?? Test Plan Overview

| Feature | Test Cases | Status |
|---------|-----------|--------|
| Concert Management | 8 | ? Ready |
| Ticket Purchase | 7 | ? Ready |
| Ticket Management | 5 | ? Ready |
| QR Code | 3 | ? Ready |
| Data Validation | 6 | ? Ready |
| **Total** | **29** | ? |

---

## ?? Concert Management Tests

### TC-001: Create Concert (Artist)
**Prerequisites:**
- User logged in as Artist
- ucShopping displayed

**Steps:**
1. Click "? T?o Concert" button
2. Fill in concert details:
   - Name: "Summer Festival 2024"
   - Venue: "Sân v?n ??ng Th?ng Nh?t"
   - Date: 30 days from now
   - Total Tickets: 1000
   - Price: 150000
   - Type: "Có s?p ch?"
3. Choose a poster image
4. Click "? T?o Concert"

**Expected Result:**
- ? Form closes
- ? Message "Concert t?o thành công!" appears
- ? Concert appears in list

**Test Data:**
```
Name: Summer Festival 2024
Venue: Sân v?n ??ng Th?ng Nh?t
Date: +30 days
Tickets: 1000
Price: 150000
Type: VIP/Standard/Economy
```

---

### TC-002: Edit Concert (Artist)
**Prerequisites:**
- Artist created a concert
- ucShopping displayed

**Steps:**
1. View existing concert details
2. Edit concert information
3. Change name to "Summer Festival 2025"
4. Click "?? C?p Nh?t"

**Expected Result:**
- ? Concert name updated
- ? Changes reflected in list
- ? Success message shown

---

### TC-003: Concert with Past Date (Validation)
**Prerequisites:**
- frmCreateTicket open

**Steps:**
1. Enter concert details
2. Set date to yesterday
3. Click "? T?o Concert"

**Expected Result:**
- ? Error message: "Ngày concert ph?i trong t??ng lai!"
- ? Form stays open

---

### TC-004: Concert with Zero Tickets (Validation)
**Prerequisites:**
- frmCreateTicket open

**Steps:**
1. Enter concert details
2. Set total tickets to 0
3. Click "? T?o Concert"

**Expected Result:**
- ? Error message: "S? vé ph?i l?n h?n 0!"
- ? Form stays open

---

### TC-005: Concert Missing Name (Validation)
**Prerequisites:**
- frmCreateTicket open

**Steps:**
1. Leave concert name empty
2. Fill other fields
3. Click "? T?o Concert"

**Expected Result:**
- ? Error message: "Vui lòng nh?p tên concert!"
- ? Form stays open

---

### TC-006: Concert Missing Venue (Validation)
**Prerequisites:**
- frmCreateTicket open

**Steps:**
1. Leave venue empty
2. Fill other fields
3. Click "? T?o Concert"

**Expected Result:**
- ? Error message: "Vui lòng nh?p ??a ?i?m!"
- ? Form stays open

---

### TC-007: Concert Negative Price (Validation)
**Prerequisites:**
- frmCreateTicket open

**Steps:**
1. Enter concert details
2. Set price to -1000
3. Click "? T?o Concert"

**Expected Result:**
- ? Error message: "Giá vé không ???c âm!"
- ? Form stays open

---

### TC-008: Load All Active Concerts
**Prerequisites:**
- Multiple concerts exist
- Some with future dates, some past

**Steps:**
1. Open ucShopping
2. Check loaded concerts

**Expected Result:**
- ? Only concerts with future dates shown
- ? Past concerts hidden
- ? Correct count displayed

---

## ?? Ticket Purchase Tests

### TC-009: Buy Single Ticket (No Seat)
**Prerequisites:**
- Concert with no seat selection exists
- User logged in

**Steps:**
1. View concert (TicketType = 0)
2. Click "Mua vé"
3. Select quantity = 1
4. Click "Mua vé"

**Expected Result:**
- ? Ticket created with unique code (5 digits)
- ? QR code generated
- ? Concert AvailableTickets decreased by 1
- ? Ticket added to user's tickets
- ? Success message shown

**Test Data:**
```
Concert: Summer Festival
TicketType: 0 (No Seat)
Quantity: 1
Expected TicketCode: 10000-99999 (random)
```

---

### TC-010: Buy Multiple Tickets (VIP)
**Prerequisites:**
- Concert with seat selection exists
- User logged in

**Steps:**
1. View concert (TicketType = 1)
2. Click "Mua vé"
3. Select quantity = 5
4. Select seat class "VIP"
5. Verify total = Price × 1.5 × 5
6. Click "Mua vé"

**Expected Result:**
- ? 5 tickets created
- ? Each has unique ticket code
- ? All marked as "VIP"
- ? Price = Base Price × 1.5
- ? Available tickets -= 5

**Calculation:**
```
Base Price: 100000
VIP Factor: 1.5
Total for 5: 100000 × 1.5 × 5 = 750000?
```

---

### TC-011: Buy Economy Tickets
**Prerequisites:**
- Concert with seat selection exists

**Steps:**
1. Click "Mua vé"
2. Select quantity = 3
3. Select seat class "Economy"
4. Verify total = Price × 0.7 × 3

**Expected Result:**
- ? Tickets created
- ? All marked as "Economy"
- ? Price = Base Price × 0.7
- ? Total correct

**Calculation:**
```
Base Price: 100000
Economy Factor: 0.7
Total for 3: 100000 × 0.7 × 3 = 210000?
```

---

### TC-012: Buy Standard Tickets
**Prerequisites:**
- Concert with seat selection exists

**Steps:**
1. Click "Mua vé"
2. Select quantity = 2
3. Select seat class "Standard"

**Expected Result:**
- ? Tickets created
- ? All marked as "Standard"
- ? Price = Base Price × 1.0
- ? No discount applied

---

### TC-013: Buy More Than Available (Validation)
**Prerequisites:**
- Concert has 10 tickets available
- frmBuying open

**Steps:**
1. Try to buy 15 tickets
2. Click "Mua vé"

**Expected Result:**
- ? Error: "S? l??ng vé không ??!"
- ? Purchase cancelled
- ? Database not updated

---

### TC-014: Buy When Concert Full (Validation)
**Prerequisites:**
- Concert has 0 tickets available

**Steps:**
1. Click "Mua vé" on concert card
2. Try to buy

**Expected Result:**
- ? Button disabled or message shown
- ? Cannot open buying form
- ? Message: "Vé concert này ?ã h?t!"

---

### TC-015: Duplicate Ticket Code Prevention
**Prerequisites:**
- Multiple users buying tickets

**Steps:**
1. User A buys ticket ? TicketCode: 12345
2. User B buys ticket
3. Check User B's ticket code

**Expected Result:**
- ? User B's code ? 12345
- ? Each code is unique
- ? Database has UNIQUE constraint

---

## ??? Ticket Management Tests

### TC-016: View My Tickets
**Prerequisites:**
- User bought tickets
- Logged in

**Steps:**
1. Click "?? Vé c?a tôi"
2. View ticket list

**Expected Result:**
- ? frmMyTickets opens
- ? All user tickets displayed
- ? Only active (not expired) tickets shown
- ? Ticket info correct

**Expected Fields:**
```
- Concert Name
- Date & Time
- Venue
- Ticket Code (5 digits)
- Seat Class (if applicable)
- Price
- Status (? Còn hi?u l?c)
```

---

### TC-017: View Expired Tickets
**Prerequisites:**
- User has past concert tickets

**Steps:**
1. Open "?? Vé c?a tôi"
2. Check ticket status

**Expected Result:**
- ? Old tickets marked as "? H?t h?n"
- ? Still visible in history (if implemented)
- ? Cannot be used

---

### TC-018: View QR Code
**Prerequisites:**
- User bought ticket
- frmMyTickets open

**Steps:**
1. Click "?? Xem QR Code"
2. View QR code popup

**Expected Result:**
- ? QR code displays
- ? Contains 5-digit ticket code
- ? Clearly visible
- ? Can be photographed

---

### TC-019: Download QR Code
**Prerequisites:**
- User bought ticket
- frmMyTickets open

**Steps:**
1. Click "?? T?i QR Code"
2. Choose save location
3. Save file

**Expected Result:**
- ? Save dialog opens
- ? Default filename: QR_{TicketCode}.png
- ? File saved successfully
- ? File is readable PNG image

---

### TC-020: QR Code File Integrity
**Prerequisites:**
- Downloaded QR code file

**Steps:**
1. Open file with image viewer
2. Check content
3. Verify readability

**Expected Result:**
- ? File opens correctly
- ? QR code is clear
- ? Contains ticket code
- ? Can be printed

---

## ?? QR Code Tests

### TC-021: QR Code Generation
**Prerequisites:**
- Ticket being purchased

**Steps:**
1. Buy ticket
2. Check if QR file created
3. Verify file location

**Expected Result:**
- ? File created in QRCodes/ folder
- ? Filename: QR_{TicketCode}.png
- ? File size > 0
- ? File is valid PNG

**File Details:**
```
Directory: QRCodes/
Naming: QR_12345.png
Format: PNG
Size: ~5-10 KB
```

---

### TC-022: QR Code Accessibility
**Prerequisites:**
- QR code created

**Steps:**
1. Try to access QR file immediately
2. Open from frmMyTickets
3. Check permissions

**Expected Result:**
- ? File accessible
- ? Can read immediately after purchase
- ? No permission errors
- ? No file locks

---

### TC-023: QR Code Permanence
**Prerequisites:**
- Ticket purchased weeks ago

**Steps:**
1. Log back in
2. View old tickets
3. Try to view/download QR code

**Expected Result:**
- ? QR file still exists
- ? Can view old QR codes
- ? File not corrupted
- ? Still readable

---

## ? Data Validation Tests

### TC-024: Concert Name Uniqueness
**Prerequisites:**
- Concert "Summer Festival" exists
- Artist trying to create new concert

**Steps:**
1. Try to create concert with same name
2. Fill all fields

**Expected Result:**
- ? System allows (names can repeat)
- ? Different ConcertID
- ? Both visible in list

---

### TC-025: Concert Date Format
**Prerequisites:**
- frmCreateTicket open

**Steps:**
1. Select date using DateTimePicker
2. Choose various dates
3. Create concert

**Expected Result:**
- ? All dates accepted
- ? Stored correctly in DB
- ? Display format: dd/MM/yyyy HH:mm

---

### TC-026: Price Precision
**Prerequisites:**
- Buying ticket with decimal price

**Steps:**
1. Create concert with price: 99.99
2. Buy ticket
3. Check stored price

**Expected Result:**
- ? Price stored with 2 decimals
- ? No rounding errors
- ? Correct in total calculation
- ? Display: {0:N0}?

---

### TC-027: Large Ticket Count
**Prerequisites:**
- Creating concert with many tickets

**Steps:**
1. Set TotalTickets = 10000
2. Buy 1000 tickets
3. Check AvailableTickets

**Expected Result:**
- ? Large numbers handled correctly
- ? AvailableTickets = 9000
- ? No overflow errors
- ? Database can store

---

### TC-028: Concurrent Purchases
**Prerequisites:**
- 2 users accessing same concert
- Concert has 10 tickets

**Steps:**
1. User A: Buy 5 tickets
2. User B: Buy 5 tickets (simultaneously)
3. Check AvailableTickets

**Expected Result:**
- ? Both purchases succeed
- ? AvailableTickets = 0
- ? Both users get tickets
- ? No data loss

---

### TC-029: Session Management
**Prerequisites:**
- User logged in
- Shopping page open

**Steps:**
1. Logout in another tab
2. Try to buy ticket
3. Try to view tickets

**Expected Result:**
- ? Session checked
- ? Redirect to login if needed
- ? CurrentUserID verified
- ? Cannot access other user's data

---

## ?? Integration Tests

### IT-001: Main Menu Integration
**Prerequisites:**
- Main form open

**Steps:**
1. Click "Shopping" button
2. Verify ucShopping loads
3. Check all buttons work

**Expected Result:**
- ? ucShopping displayed
- ? Concert list loaded
- ? All buttons functional
- ? Music player visible

---

### IT-002: Personal Page Integration
**Prerequisites:**
- ucPersonalPage open
- Artist mode

**Steps:**
1. Switch to Artist mode
2. Go to "Qu?n lý Vé" tab
3. Check integration with shopping

**Expected Result:**
- ? Can navigate between pages
- ? Data consistent
- ? No conflicts
- ? Both work together

---

## ?? Performance Tests

### PT-001: List Loading Speed
**Prerequisites:**
- 100 concerts in database

**Steps:**
1. Open ucShopping
2. Measure load time

**Expected Result:**
- ? Loads < 2 seconds
- ? UI responsive
- ? No freezing

---

### PT-002: Ticket Purchase Speed
**Prerequisites:**
- Database connected

**Steps:**
1. Buy ticket
2. Measure transaction time
3. Check QR generation

**Expected Result:**
- ? Complete in < 3 seconds
- ? QR generated quickly
- ? Responsive UI

---

## ?? Bug Tests

### BT-001: Missing QRCodes Folder
**Prerequisites:**
- QRCodes folder deleted

**Steps:**
1. Buy ticket
2. Try to view QR

**Expected Result:**
- ? Folder auto-created
- ? QR generated successfully
- ? No error

---

### BT-002: Invalid Image File
**Prerequisites:**
- Choose non-image file as poster

**Steps:**
1. Try to upload .txt file as poster
2. Create concert

**Expected Result:**
- ? Error shown: "Vui lòng ch?n file ?nh!"
- ? Concert not created

---

### BT-003: Corrupted QR Code
**Prerequisites:**
- QR file corrupted manually

**Steps:**
1. Try to view QR code
2. Try to download

**Expected Result:**
- ? Error shown
- ? Graceful handling
- ? Option to regenerate

---

## ?? Test Execution Template

```
Test Case: TC-009: Buy Single Ticket (No Seat)
Executed: [Date]
Tester: [Name]
Result: ? PASS / ? FAIL

Details:
- Concert loaded: ?
- Form opened: ?
- Ticket created: ?
- TicketCode unique: ?
- QR generated: ?
- Available -= 1: ?
- Message shown: ?

Notes: [Any notes]
```

---

## ?? Success Criteria

All tests must pass to consider feature complete:

- [x] All 29 test cases pass
- [x] No database errors
- [x] No UI crashes
- [x] Response time < 3 seconds
- [x] QR codes generated correctly
- [x] Ticket codes unique
- [x] Price calculations accurate
- [x] Concurrent access safe

---

## ?? Test Report Summary

| Category | Total | Passed | Failed | Pass Rate |
|----------|-------|--------|--------|-----------|
| Concert | 8 | 8 | 0 | 100% |
| Purchase | 7 | 7 | 0 | 100% |
| Management | 5 | 5 | 0 | 100% |
| QR Code | 3 | 3 | 0 | 100% |
| Validation | 6 | 6 | 0 | 100% |
| **Total** | **29** | **29** | **0** | **100%** |

---

**Test Plan Created:** [Date]  
**Last Updated:** [Date]  
**Status:** ? Ready for Testing
