CREATE PROCEDURE CatalogGetProductsOnDeptPromo
(@DepartmentID INT,
@DescriptionLength INT,
@PageNumber INT,
@ProductsPerPage INT,
@HowManyProducts INT OUTPUT)
AS

-- declare a new TABLE variable
DECLARE @Products TABLE
(RowNumber INT,
ProductID INT,
Name NVARCHAR(50),
Description NVARCHAR(MAX),
Price MONEY,
Thumbnail NVARCHAR(50),
Image NVARCHAR(50),
PromoFront bit,
PromoDept bit)

-- populate the table variable with the complete list of products
INSERT INTO @Products
SELECT ROW_NUMBER() OVER (ORDER BY ProductID) AS Row,
		ProductID, Name, SUBSTRING(Description, 1, @DescriptionLength) + '...' AS Description,
		Price, Thumbnail, Image, PromoFront, PromoDept
FROM
	(SELECT DISTINCT Product.ProductID, Product.Name,
			CASE WHEN LEN(Product.Description) <= @DescriptionLength THEN Product.Description
			ELSE SUBSTRING(Product.Description, 1, @DescriptionLength) + '...' END
		AS Description, Price, Thumbnail, Image, PromoFront, PromoDept
FROM Product INNER JOIN ProductCategory
					ON Product.ProductID = ProductCategory.ProductID
			INNER JOIN Category
					ON ProductCategory.CategoryID = Category.CategoryID
WHERE Product.PromoDept = 1
AND Category.DepartmentID = @DepartmentID
) AS ProductOnDepPr

-- return the total number of products using an OUTPUT variable
SELECT @HowManyProducts = COUNT(ProductID) FROM @Products
-- extract the requested page of products

SELECT ProductID, Name, Description, Price, Thumbnail,Image, PromoFront, PromoDept
FROM @Products
WHERE RowNumber > (@PageNumber - 1) * @ProductsPerPage
		AND RowNumber <= @PageNumber * @ProductsPerPage