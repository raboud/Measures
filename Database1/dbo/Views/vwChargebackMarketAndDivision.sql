CREATE VIEW [ChargebackBranchAndDivision] AS 
SELECT 
	dbo.[Check].[Date]
	, dbo.Division.Name as Division
	, dbo.Branch.Name as Branch
	, dbo.[Check].Number
	, dbo.ChargeBack.OriginalPO
	, dbo.CheckCBDetail.Amount AS CBTotal
	, dbo.CheckCBDetail.Amount - dbo.ChargeBack.AmountToSub AS CBCFI
	, dbo.ChargeBack.AmountToSub AS CBSub
	, dbo.Store.BranchId
	, dbo.Program.DivisionId 
FROM 
	dbo.Store 
		INNER JOIN dbo.[Order] ON dbo.Store.Id = dbo.[Order].StoreID 
		INNER JOIN dbo.Program ON dbo.[Order].ProgramId = dbo.Program.Id 
		INNER JOIN dbo.Branch ON dbo.Store.BranchId = dbo.Branch.Id 
		INNER JOIN dbo.Division ON dbo.Program.DivisionId = dbo.Division.Id 
		INNER JOIN dbo.CheckCBDetail 
		INNER JOIN dbo.ChargeBack ON dbo.CheckCBDetail.ChargeBackID = dbo.ChargeBack.Id 
		ON [dbo].[Order].Id = dbo.ChargeBack.OrderID 
		INNER JOIN dbo.[Check] ON dbo.CheckCBDetail.CheckID = dbo.[Check].Id 
WHERE 
	(ISNULL(dbo.[Check].Date, '') >= CONVERT(DATETIME, '2003-01-01 00:00:00', 102)) AND ([dbo].[Order].Deleted = 0) 