USE [BalloonShop]
GO
/****** Object:  StoredProcedure [dbo].[CatalogGetCategoryDetails]    Script Date: 7/5/2015 10:13:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[CatalogGetCategoryDetails]
(@categoryID int)
as
Select DepartmentID, Name, Description
from Category
where CategoryID = @CategoryID