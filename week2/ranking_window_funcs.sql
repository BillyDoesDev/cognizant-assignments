-- Goal: Use ROW_NUMBER(), RANK(), DENSE_RANK(), OVER(), and PARTITION BY.

-- Scenario:

-- Find the top 3 most expensive products in each category using different
-- ranking functions.

-- Steps:

-- 1. Use ROW_NUMBER() to assign a unique rank within each category.
-- 2. Use RANK() and DENSE_RANK() to compare how ties are handled.
-- 3. Use PARTITION BY Category and ORDER BY Price DESC.

-- @block
USE cognizant_stuff;


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
