CREATE VIEW dbo.TotalPayment AS
SELECT     
	SUM(ISNULL(dbo.CheckDetail.Amount, 0)) AS TotalAmount
	, dbo.CheckDetail.OrderID
FROM         
	dbo.[Check] 
		INNER JOIN dbo.CheckDetail ON dbo.[Check].Id = dbo.CheckDetail.CheckID
GROUP BY 
	dbo.CheckDetail.OrderID
