# labProject

Task Program : Visual Studio 2015
Using NuGet Solution : MySQL.Data 8.0.13.0v
Using MySQL Server version : 5.7
Using MySQL Workbench : 6.3CE


--- MySQL Settings ---
Schema Name : libraryDB
Table list : 
  <blacklist>
    name (VARCHAR(30), Primary Key, NotNull)
    date (DATE, NotNull)

  <booklist>
    isbn    (VARCHAR(50), Primary Key, NotNull)
    name    (VARCHAR(50), NotNull)
    author  (VARCHAR(20), NotNull)
    company (VARCHAR(20), NotNull)
    stock   (INT(2), NotNull)

  <borrowlist>
    borrower  (VARCHAR(24), NotNull)
    isbn      (VARCHAR(50, NotNull)
    name      (VARCHAR(50, NotNull)
    bdate     (DATE, NotNull)
    rdate     (DATE, NotNull)
    limit_    (VARCHAR(1), NotNull)
    
  <loglist>
    ldate     (DATETIME, NotNull)
    lname     (VARCHAR(30), NotNull)
    message   (VARCHAR(100), NotNull)

Access account : 
'root'  - Access to the program dedicated to managing the book is available. (Full authorization)
'admin' - (grant select, create user)
other   - (grant usage)
