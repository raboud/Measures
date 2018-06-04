CREATE VIEW [dbo].[RptInstallerCheckList] AS 
SELECT 
	CustomerOrders.Name
	, CustomerOrders.Address
	, CustomerOrders.City
	, CustomerOrders.State
	, CustomerOrders.ZipCode
	, CustomerOrders.OrderId
	, CustomerOrders.PONumber
	, CustomerOrders.Number
	, CustomerOrders.ShortName
	, Branch.Name as Branch
FROM   
	dbo.CustomerOrders CustomerOrders 
		INNER JOIN dbo.Branch ON CustomerOrders.BranchId = Branch.Id
