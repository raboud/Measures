CREATE PROCEDURE [dbo].[InsertRoom]
	@Name nvarchar(50)
AS
INSERT INTO Room (Name)
    SELECT @Name
WHERE NOT EXISTS (SELECT * FROM Room WHERE Name = @Name)
RETURN 0
