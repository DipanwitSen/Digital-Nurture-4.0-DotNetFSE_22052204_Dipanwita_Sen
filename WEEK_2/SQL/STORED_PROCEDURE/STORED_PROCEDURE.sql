-- Drop Existing Stored Procedures (if any)
IF OBJECT_ID('sp_GetEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetEmployeesByDepartment;
GO

IF OBJECT_ID('sp_InsertEmployee', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertEmployee;
GO

-- Drop Existing Tables (Child to Parent)
IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;
GO

IF OBJECT_ID('Departments', 'U') IS NOT NULL DROP TABLE Departments;
GO

-- Create Departments Table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

-- Create Employees Table with IDENTITY (Auto Increment)
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);
GO

-- Insert Departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');
GO

-- Insert Employees
INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');
GO

-- Create Stored Procedure: Retrieve Employees by Department with Salary > 5000
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID AND Salary > 5000;
END;
GO

-- Create Stored Procedure: Insert Employee
CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

-- Execute: Retrieve Employees from Department 3 with Salary > 5000
EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;
GO

-- Execute: Insert New Employee (Alex)
EXEC sp_InsertEmployee 'Alex', 'Brown', 2, 6200.00, '2024-06-24';
GO

-- Display Departments Table
SELECT * FROM Departments;
GO

-- Display Employees Table (Alex will appear here)
SELECT * FROM Employees;
GO

-- Display Employees in Department 3 with Salary > 5000 (Direct Query)
SELECT * FROM Employees WHERE DepartmentID = 3 AND Salary > 5000;
GO

-- Display Employees in Department 2 (Alex should appear)
SELECT * FROM Employees WHERE DepartmentID = 2;
GO