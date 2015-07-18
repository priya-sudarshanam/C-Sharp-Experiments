USE [BalloonShop]
GO
/****** Object:  StoredProcedure [dbo].[CatalogGetProductDetails]    Script Date: 7/5/2015 10:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[CatalogGetProductDetails]
(@ProductID int)
as
Select Name, Description,Price,Thumbnail,Image,PromoFront,PromoDept
from Product
where ProductID = @ProductID