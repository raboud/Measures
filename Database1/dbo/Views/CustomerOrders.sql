
CREATE VIEW CustomerOrders AS
SELECT     
	dbo.Customer.Id as CustomerId
	, dbo.Customer.Name
	, dbo.Customer.FirstName
	, dbo.Customer.LastName
	, dbo.Customer.Address
	, dbo.Customer.City
	, dbo.Customer.State
	, dbo.Customer.ZipCode
	, dbo.Customer.PhoneNumber1
	, dbo.Customer.PhoneNumber2
	, dbo.Customer.Directions
	, [dbo].[Order].Id as OrderId
	, [dbo].[Order].OrderDate
	, [dbo].[Order].PONumber
	, [dbo].[Order].SpecialInstructions
	, [dbo].[Order].ScheduleStartDate
	, [dbo].[Order].ScheduleEndDate
	, [dbo].[Order].BilledDate
	, [dbo].[Order].Scheduled
	, [dbo].[Order].Billed
	, [dbo].[Order].Paid
	, [dbo].[Order].Called
	, [dbo].[Order].InternalNotes
	, [dbo].[Order].CostAmount
	, [dbo].[Order].BilledAmount
	, [dbo].[Order].ProgramId
	, [dbo].[Order].OrderAmount
	, [dbo].[Order].TripCharge
	, [dbo].[Order].NoMinimum
	, [dbo].[Order].ScheduledAM
	, [dbo].[Order].Cancelled
	, [dbo].[Order].Warrenty
	, dbo.Store.Number
	, IIF([Order].Billed = 1, [Order].BilledAmount, [Order].OrderAmount) - ISNULL(dbo.TotalPayment.TotalAmount, 0) AS Balance
	, ISNULL(dbo.TotalPayment.TotalAmount, 0) AS TotalAmount
	, [dbo].[Order].Invoice
	, dbo.Program.Name as ProgramName
	, dbo.Program.ShortName
	, dbo.Store.Id
	, [dbo].[Order].OriginalPO
	, dbo.Program.DivisionID, dbo.Store.BranchId, dbo.Division.VendorID, dbo.Division.MarkBilledWhenPaid, [dbo].[Order].XMLOrderCostAmount, 
                      [dbo].[Order].EntryMethodID
FROM         dbo.[Order] INNER JOIN
                      dbo.Program ON [dbo].[Order].PrimaryOrderId = dbo.Program.Id INNER JOIN
                      dbo.Customer ON [dbo].[Order].CustomerID = dbo.Customer.id INNER JOIN
                      dbo.Store ON [dbo].[Order].StoreID = dbo.Store.id INNER JOIN
                      dbo.Division ON dbo.Program.DivisionID = dbo.Division.Id LEFT OUTER JOIN
                      dbo.TotalPayment ON dbo.TotalPayment.OrderID = [dbo].[Order].Id
WHERE     ([dbo].[Order].Deleted = 0)

