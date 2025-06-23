-- Start spooling to Ranking.txt
:OUT Ranking.txt
-- U is user table
-- =========================================
-- Drop existing tables (Child to Parent) 
-- =========================================
IF OBJECT_ID('Order_Items', 'U') IS NOT NULL DROP TABLE Order_Items;
GO
IF OBJECT_ID('Orders', 'U') IS NOT NULL DROP TABLE Orders;
GO
IF OBJECT_ID('Customers', 'U') IS NOT NULL DROP TABLE Customers;
GO
IF OBJECT_ID('Products', 'U') IS NOT NULL DROP TABLE Products;
GO

-- =========================================
-- Create Products Table
-- =========================================
CREATE TABLE Products (
    P_ID INT PRIMARY KEY,
    P_NAME VARCHAR(255) NOT NULL,
    CATEGORY VARCHAR(100) NOT NULL,
    PRICE DECIMAL(10, 2) NOT NULL
);
GO

-- =========================================
-- Create Customers Table
-- =========================================
CREATE TABLE Customers (
    Customer_ID INT PRIMARY KEY,
    Customer_Name VARCHAR(255) NOT NULL,
    Region VARCHAR(100) NOT NULL
);
GO

-- =========================================
-- Create Orders Table
-- =========================================
CREATE TABLE Orders (
    Order_ID INT PRIMARY KEY,
    Customer_ID INT,
    Order_Date DATE NOT NULL,
    FOREIGN KEY (Customer_ID) REFERENCES Customers(Customer_ID)
);
GO

-- =========================================
-- Create Order_Items Table
-- =========================================
CREATE TABLE Order_Items (
    Order_Item_ID INT PRIMARY KEY,
    Order_ID INT,
    Product_ID INT,
    Quantity INT NOT NULL,
    FOREIGN KEY (Order_ID) REFERENCES Orders(Order_ID),
    FOREIGN KEY (Product_ID) REFERENCES Products(P_ID)
);
GO

-- =========================================
-- Insert Values into Products Table
-- =========================================
INSERT INTO Products VALUES
(1, 'iPhone 14', 'Electronics', 70000.00),
(2, 'Samsung S23', 'Electronics', 68000.00),
(3, 'MacBook Air', 'Electronics', 110000.00),
(4, 'Nike Shoes', 'Footwear', 5000.00),
(5, 'Adidas Shoes', 'Footwear', 4500.00),
(6, 'Dell XPS 13', 'Electronics', 95000.00),
(7, 'Puma Shoes', 'Footwear', 4000.00),
(8, 'Sony Headset', 'Electronics', 15000.00),
(9, 'LG Monitor', 'Electronics', 12000.00),
(10, 'Crocs', 'Footwear', 3500.00);
GO

-- =========================================
-- Insert Values into Customers Table
-- =========================================
INSERT INTO Customers VALUES
(1, 'John Doe', 'North'),
(2, 'Jane Smith', 'South'),
(3, 'Alice Johnson', 'East'),
(4, 'Bob Brown', 'West');
GO

-- =========================================
-- Insert Values into Orders Table
-- =========================================
INSERT INTO Orders VALUES
(101, 1, '2025-06-01'),
(102, 2, '2025-06-02'),
(103, 3, '2025-06-03'),
(104, 4, '2025-06-04');
GO

-- =========================================
-- Insert Values into Order_Items Table
-- =========================================
INSERT INTO Order_Items VALUES
(1, 101, 1, 1),
(2, 101, 4, 2),
(3, 102, 3, 1),
(4, 102, 7, 1),
(5, 103, 5, 2),
(6, 104, 2, 1),
(7, 104, 6, 1);
GO

-- =========================================
-- Display Products Table (Formatted)
-- =========================================
SELECT
    RIGHT('     ' + CAST(P_ID AS VARCHAR), 5) AS P_ID,
    LEFT(P_NAME + SPACE(15), 15) AS P_NAME,
    LEFT(CATEGORY + SPACE(15), 15) AS CATEGORY,
    RIGHT('       ' + CAST(PRICE AS VARCHAR), 10) AS PRICE
FROM Products;
GO

-- =========================================
-- Display Customers Table (Formatted)
-- =========================================
SELECT
    RIGHT('     ' + CAST(Customer_ID AS VARCHAR), 5) AS Customer_ID,
    LEFT(Customer_Name + SPACE(20), 20) AS Customer_Name,
    LEFT(Region + SPACE(15), 15) AS Region
FROM Customers;
GO

-- =========================================
-- Display Orders Table (Formatted)
-- =========================================
SELECT
    RIGHT('     ' + CAST(Order_ID AS VARCHAR), 5) AS Order_ID,
    RIGHT('     ' + CAST(Customer_ID AS VARCHAR), 5) AS Customer_ID,
    Order_Date
FROM Orders;
GO

-- =========================================
-- Display Order_Items Table (Formatted)
-- =========================================
SELECT
    RIGHT('     ' + CAST(Order_Item_ID AS VARCHAR), 5) AS Order_Item_ID,
    RIGHT('     ' + CAST(Order_ID AS VARCHAR), 5) AS Order_ID,
    RIGHT('     ' + CAST(Product_ID AS VARCHAR), 5) AS Product_ID,
    RIGHT('     ' + CAST(Quantity AS VARCHAR), 5) AS Quantity
FROM Order_Items;
GO

-- Stop spooling
:OUT
-- Here everything output in Ranking.txt
