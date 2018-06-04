CREATE PROCEDURE [dbo].[InsertSlotType]
	@Name nvarchar(50)
AS
INSERT INTO SlotType(Name)
    SELECT @Name
WHERE NOT EXISTS (SELECT * FROM SlotType WHERE Name = @Name)
RETURN 0
