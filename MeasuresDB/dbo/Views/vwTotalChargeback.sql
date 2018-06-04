CREATE VIEW dbo.TotalChargeback
AS
SELECT top 100 percent
	dbo.ChargeBack.Id
	, IIF(dbo.ChargeBack.Approved = 1, ISNULL(dbo.ChargeBack.Amount, 0), 0) AS ApprovedAmount
	, ISNULL(dbo.vwChargeBacksTakenTotal.AmountTaken, 0) AS AmountTaken
	, IIF(dbo.ChargeBack.Approved = 1, ISNULL(dbo.ChargeBack.Amount, 0), 0) - ISNULL(dbo.vwChargeBacksTakenTotal.AmountTaken, 0) AS Balance
FROM         
	dbo.ChargeBack 
		INNER JOIN dbo.vwChargeBacksTakenTotal ON dbo.ChargeBack.Id = dbo.vwChargeBacksTakenTotal.ChargeBackID
ORDER BY dbo.ChargeBack.Id DESC

