USE [BalloonShop]
GO
/****** Object:  StoredProcedure [dbo].[CatalogGetDepartmentDetails]    Script Date: 7/5/2015 10:13:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[CatalogGetDepartmentDetails]
(@DepartmentID Int)
as
Select Name, Description
from Department
Where DepartmentID = @DepartmentID  



