 -- Start spooling to Ranking.txt
:OUT Index.txt
GO
--EXCERCISE 1:Creating Non Cluster Index
-- Step 1: Query to fetch product details before index creation
SELECT * FROM Products WHERE ProductName = 'Laptop';

-- Step 2: Create a non-clustered index on ProductName
CREATE NONCLUSTERED INDEX idx_ProductName ON Products (ProductName);

-- Step 3: Query to fetch product details after index creation
SELECT * FROM Products WHERE ProductName = 'Laptop';
--EXCERCISE 2:Creating Cluster Index
-- Step 1: Query to fetch orders before index creation
SELECT * FROM Orders WHERE OrderDate = '2023-01-15';

-- Step 2: Create a clustered index on OrderDate
CREATE CLUSTERED INDEX idx_OrderDate ON Orders (OrderDate);

-- Step 3: Query to fetch orders after index creation
SELECT * FROM Orders WHERE OrderDate = '2023-01-15';
--EXCERCISE 3:Creating Composite Index
-- Step 1: Query to fetch orders before index creation
SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';

-- Step 2: Create a composite index on CustomerID and OrderDate
CREATE NONCLUSTERED INDEX idx_CustomerID_OrderDate ON Orders (CustomerID, OrderDate);

-- Step 3: Query to fetch orders after index creation
SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';
