## 1

```sql
-- @block
USE Product_Management;


-- @block
WITH RankedProducts AS (
    SELECT 
        ProductName, 
        Category, 
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS row_num,
        RANK()       OVER (PARTITION BY Category ORDER BY Price DESC) AS row_rank,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS row_dense_rank
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE row_num <= 3;
```

**Output**

```
Changed database context to 'Product_Management'.
ProductName                                                                                          Category                                           Price        row_num              row_rank             row_dense_rank      
---------------------------------------------------------------------------------------------------- -------------------------------------------------- ------------ -------------------- -------------------- --------------------
Headphones                                                                                           Accessories                                              150.00                    1                    1                    1
Laptop                                                                                               Electronics                                             1200.00                    1                    1                    1
Smartphone                                                                                           Electronics                                              800.00                    2                    2                    2
Tablet                                                                                               Electronics                                              600.00                    3                    3                    3

(4 rows affected)
```

## 2

```sql

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
```

**Output**

```
Changed database context to 'Employee_Management'.
EmployeeID  FirstName                                          LastName                                           DepartmentID Salary       JoinDate        
----------- -------------------------------------------------- -------------------------------------------------- ------------ ------------ ----------------
          1 John                                               Doe                                                           1      5000.00       2020-01-15

(1 rows affected)


Changed database context to 'Employee_Management'.
EmployeeID  FirstName                                          LastName                                           DepartmentID Salary       JoinDate        
----------- -------------------------------------------------- -------------------------------------------------- ------------ ------------ ----------------
          1 John                                               Doe                                                           1      5000.00       2020-01-15
          2 Jane                                               Smith                                                         2      6000.00       2019-03-22
          3 Michael                                            Johnson                                                       3      7000.00       2018-07-30
          4 Emily                                              Davis                                                         4      5500.00       2021-11-05
         69 Rakesh                                             Golmez                                                        4        69.00       2025-06-29
        420 Rakesh                                             Golmez                                                        4        69.00       2025-06-29

(6 rows affected)
```

## 3

```sql
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
```

**Output**

```
Changed database context to 'Employee_Management'.
DepartmentID emp_count  
------------ -----------
           4           3

(1 rows affected)
```