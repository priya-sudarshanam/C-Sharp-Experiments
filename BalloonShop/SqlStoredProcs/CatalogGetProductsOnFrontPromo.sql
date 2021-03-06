USE [BalloonShop]
GO
/****** Object:  StoredProcedure [dbo].[CatalogGetProductsOnFrontPromo]    Script Date: 7/5/2015 10:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[CatalogGetProductsOnFrontPromo]
(
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
       ProductID, Name,
	   CASE when len(Description) <= @DescriptionLength then Description
	        else substring(Description,1,@DescriptionLength) + '...' end
	   as Description, Price, Thumbnail, Image,  PromoFront, PromoDept
From Product
where PromoFront = 1

/*Return the total number of products using an output variable */
Select @HowManyProducts = Count(ProductID) from @Products

/* extract  the requested page of products */
Select ProductID, Name, Description, Price, Thumbnail, Image, PromoFront, PromoDept
from @Products
Where RowNumber > (@PageNumber -1) * @ProductsPerPage
and   RowNumber <= @PageNumber * @ProductsPerPage