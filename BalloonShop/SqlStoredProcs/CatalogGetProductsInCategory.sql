create procedure CatalogGetProductsInCategory
(
 @CategoryID int,
 @DescriptionLength int,
 @PageNumber int,
 @ProductsPerPage int,
 @HowManyProducts int output)
as
Declare @Products TABLE
(
 RowNumber int,
 ProductID int,
 Name varchar(50),
 Description nvarchar(max),
 Price Money,
 Thumbnail nvarchar(50),
 Image nvarchar(50),
 PromoFront bit,
 PromoDept bit)

Insert into @Products
Select ROW_NUMBER() over (order by Product.ProductID),
       Product.ProductID, PName,
	   CASE when len(PDescription) <= @DescriptionLength then PDescription
	        else substring(PDescription,1,@DescriptionLength) + '...' end
	   as Description, PPrice, PThumbnail, PImage,  PPromoFront, PPromoDept
From Product inner join ProductCategory
on Product.ProductID = ProductCategory.ProductID
where ProductCategory.CategoryID = @CategoryID

/*Return the total number of products using an output variable */
Select @HowManyProducts = Count(ProductID) from @Products

/* extract  the requested page of products */
Select ProductID, Name, Description, Price, Thumbnail, Image, PromoFront, PromoDept
from @Products
Where RowNumber > (@PageNumber -1) * @ProductsPerPage
and   RowNumber <= @PageNumber * @ProductsPerPage