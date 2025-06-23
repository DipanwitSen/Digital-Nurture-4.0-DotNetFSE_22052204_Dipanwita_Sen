--Exercise 1: Ranking and Window Functions
--Goal: Use ROW_NUMBER(), RANK(), DENSE_RANK(), OVER(), and PARTITION BY.
--Scenario:
--Find the top 3 most expensive products in each category using different ranking functions.
--Steps:
--1. Use ROW_NUMBER() to assign a unique rank within each category.
--2. Use RANK() and DENSE_RANK() to compare how ties are handled.
--3. Use PARTITION BY Category and ORDER BY Price DESC.
sqlcmd -S localhost
    
-- ROW NUMBER()    
    
SELECT
    RIGHT('     ' + CAST(P_ID AS VARCHAR), 5) AS P_ID,
    LEFT(P_NAME + SPACE(15), 15) AS P_NAME,
    LEFT(CATEGORY + SPACE(15), 15) AS CATEGORY,
    RIGHT('       ' + CAST(PRICE AS VARCHAR), 10) AS PRICE,
    RIGHT('     ' + CAST(ROW_NUMBER() OVER (PARTITION BY CATEGORY ORDER BY PRICE DESC) AS VARCHAR), 5) AS P_RANK
FROM Products;
GO

-- RANK() 
    
SELECT
    RIGHT('     ' + CAST(P_ID AS VARCHAR), 5) AS P_ID,
    LEFT(P_NAME + SPACE(15), 15) AS P_NAME,
    LEFT(CATEGORY + SPACE(15), 15) AS CATEGORY,
    RIGHT('       ' + CAST(PRICE AS VARCHAR), 10) AS PRICE,
    RIGHT('     ' + CAST(RANK() OVER (PARTITION BY CATEGORY ORDER BY PRICE DESC) AS VARCHAR), 5) AS P_RANK 
FROM Products;
GO

-- DENSE_RANK()

SELECT
    RIGHT('          ' + CAST(P_ID AS VARCHAR), 5) AS P_ID,
    LEFT(P_NAME + SPACE(20), 20) AS P_NAME,
    LEFT(CATEGORY + SPACE(20), 20) AS CATEGORY,
    RIGHT('             ' + CAST(PRICE AS VARCHAR), 10) AS PRICE,
    RIGHT('          ' + CAST(DENSE_RANK() OVER (PARTITION BY CATEGORY ORDER BY PRICE DESC) AS VARCHAR), 5) AS P_RANK 
FROM Products;
GO


