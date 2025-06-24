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
