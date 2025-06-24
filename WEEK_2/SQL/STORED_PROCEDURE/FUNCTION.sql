--Exercise 7: Return Data from a Scalar Function 
--Goal: Return the annual salary for a specific employee using `fn_CalculateAnnualSalary`. 
--Steps: 
--1. Execute the `fn_CalculateAnnualSalary` function for an employee with `EmployeeID = 1`. 
--2. Verify the result.
CREATE FUNCTION CalculateAnnualSal (@Salary DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 12;
END;
GO
SELECT EmployeeID,FirstName,LastName,Salary,
dbo.CalculateAnnualSal(Salary) AS AnnualSalary
FROM Employees
WHERE EmployeeID = 1;
GO
