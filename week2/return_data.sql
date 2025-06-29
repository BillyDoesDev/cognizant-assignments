-- @block
USE Employee_Management;

-- @block
CREATE OR ALTER PROCEDURE sp_Count_Employees
    @DepartmentID INT
AS
BEGIN
    select DepartmentID, count(*) as emp_count from Employees where DepartmentID = @DepartmentID GROUP BY DepartmentID;
END;

-- @block
exec sp_Count_Employees @DepartmentID = 4;
