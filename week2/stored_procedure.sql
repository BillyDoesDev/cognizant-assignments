
-- @block
USE Employee_Management;

-- @block
-- get list of all stored procedures
SELECT name, schema_id, create_date, modify_date
FROM sys.procedures
ORDER BY name;


-- @block
CREATE OR ALTER PROCEDURE sp_SelectEmployees
    @DepartmentID INT
AS
BEGIN
    SELECT * FROM Employees WHERE DepartmentID = @DepartmentID;
END;

-- @block
USE Employee_Management;
EXEC sp_SelectEmployees @DepartmentID = 1;


-- @block
CREATE OR ALTER PROCEDURE sp_InsertEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@EmployeeID, @FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;

-- @block
USE Employee_Management;
EXEC sp_InsertEmployee @EmployeeID = 69, @FirstName = 'Rakesh', @LastName = 'Golmez', @DepartmentID = 4, @Salary = 69.0, @JoinDate = '2025-06-29';


-- @block
-- verify if insertion has actually taken place
USE Employee_Management;
select * from Employees;
