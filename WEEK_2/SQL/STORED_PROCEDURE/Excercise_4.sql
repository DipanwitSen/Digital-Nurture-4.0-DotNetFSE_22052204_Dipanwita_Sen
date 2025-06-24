--Exercise 4: Execute a Stored Procedure
--Goal: Execute the stored procedure to retrieve employee details for a specific department.
--Steps:
--1. Write the SQL command to execute the stored procedure with a DepartmentID parameter.
--2. Execute the command and review the results
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO
EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;
GO
