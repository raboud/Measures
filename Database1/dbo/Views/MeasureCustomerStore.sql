CREATE VIEW [dbo].[MeasureCustomerStore] AS 
SELECT    
	Customer.Id   
	, Customer.Name
	, Customer.Address
	, Customer.City
	, Customer.State
	, Customer.ZipCode
	, Measure.Status
	, Measure.StoreId
	, Measure.Enterred
	, Branch.Name AS Branch
	, Branch.Id as BranchId
	, Measure.Id as MeasureId
FROM            
	Customer 
		LEFT OUTER JOIN Measure ON Measure.CustomerId = Customer.Id 
		LEFT OUTER JOIN Store ON Measure.StoreId = Store.Id 
		LEFT OUTER JOIN Branch ON Store.BranchId = Branch.Id
