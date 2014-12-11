CREATE VIEW dbo.vwChargeBacksTakenTotal
AS
SELECT ChargeBackID, SUM(Amount) AS AmountTaken
FROM dbo.CheckCBDetail
GROUP BY ChargeBackID
