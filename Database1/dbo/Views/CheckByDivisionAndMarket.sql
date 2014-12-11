CREATE VIEW dbo.CheckByDivisionAndMarket AS 
SELECT 
	[dbo].[Check].Number
	, [dbo].[Check].[Date]
	, SUM(dbo.CheckDetail.Amount) AS Total
	, dbo.Division.Name as Division
	, dbo.Branch.Name as Branch
FROM 
	dbo.[Order] 
	INNER JOIN dbo.CheckDetail ON [dbo].[Order].Id = dbo.CheckDetail.OrderID 
	INNER JOIN dbo.Program ON [dbo].[Order].ProgramId = dbo.Program.Id 
	INNER JOIN dbo.Division ON dbo.Program.DivisionID = dbo.Division.Id 
	INNER JOIN dbo.Store ON [dbo].[Order].StoreID = dbo.Store.id 
	INNER JOIN dbo.Branch ON dbo.Store.BranchId = dbo.Branch.Id 
	INNER JOIN dbo.[Check] ON dbo.CheckDetail.CheckID = [dbo].[Check].Id
WHERE 
	([dbo].[Order].Deleted = 0) 
GROUP BY 
	[dbo].[Check].Number
	, [dbo].[Check].[Date]
	, dbo.Division.Name
	, dbo.Branch.Name