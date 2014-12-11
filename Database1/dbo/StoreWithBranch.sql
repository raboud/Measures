CREATE VIEW [dbo].[StoreWithBranch]	AS 
	
SELECT 
	Store.Id
	, Store.Address
	, Store.City
	, Store.State
	, Store.ZipCode
	, Store.NickName
	, Branch.Name as BranchName
	, StoreType.Name as StoreType
	, store.Active
	, Store.Number
	, Store.DistrictNumber
FROM 
	Store
		Inner Join Branch on Store.BranchId = Branch.Id
		Inner Join StoreType on Store.TypeID = StoreType.Id
