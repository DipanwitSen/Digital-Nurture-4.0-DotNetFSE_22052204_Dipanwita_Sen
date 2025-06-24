--Exercise 5: Return Data from a Stored Procedure
--Goal: Create a stored procedure that returns the total number of employees in a department.
--Steps:
--1. Define the stored procedure with a parameter for DepartmentID.
--2. Write the SQL query to count the number of employees in the specified department.
--3. Save the stored procedure by executing the Stored procedure content
CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS EmployeeCount
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO
EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 2
;
GO
