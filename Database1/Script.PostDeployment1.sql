/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
Use Measure

EXEC InsertRoom 'LR';
EXEC InsertRoom 'DR';
EXEC InsertRoom 'FOYER';
EXEC InsertRoom 'LWHALL';
EXEC InsertRoom 'UPHALL';
EXEC InsertRoom 'UPSTR';
EXEC InsertRoom 'BED 1';
EXEC InsertRoom 'CLOS 1';
EXEC InsertRoom 'BED 2';
EXEC InsertRoom 'CLOS 2';
EXEC InsertRoom 'BED 3';
EXEC InsertRoom 'CLOS 3';
EXEC InsertRoom 'BED 4';
EXEC InsertRoom 'CLOS 4';
EXEC InsertRoom 'FR';
EXEC InsertRoom 'LWSTR';
EXEC InsertRoom 'DEN';
EXEC InsertRoom 'BATH 1';
EXEC InsertRoom 'KIT';
EXEC InsertRoom 'DIN';
EXEC InsertRoom 'NOOK';
EXEC InsertRoom 'KITHALL';
EXEC InsertRoom 'KITFYR';
EXEC InsertRoom 'KITENT';
EXEC InsertRoom 'KITSTR';
EXEC InsertRoom 'KITLAND';
EXEC InsertRoom 'LNDRY';
EXEC InsertRoom 'PORCH';
EXEC InsertRoom 'COMM';
EXEC InsertRoom 'M BED';
EXEC InsertRoom 'M CLOS';
EXEC InsertRoom 'M BATH';
EXEC InsertRoom 'PANTRY';
EXEC InsertRoom 'UTILITY';
EXEC InsertRoom 'BATH 2';
EXEC InsertRoom 'BATH 3';
EXEC InsertRoom 'BSMNT_STR';
EXEC InsertRoom 'HMOFC';
EXEC InsertRoom 'BSMNT_BED 1';
EXEC InsertRoom 'BSMNT_BED 2';
EXEC InsertRoom 'BSMNT_BATH';
EXEC InsertRoom 'BSMNT_FR';
EXEC InsertRoom 'BSMNT_KIT';
EXEC InsertRoom 'STRINGER';
EXEC InsertRoom 'VANITY';
EXEC InsertSlotType 'Morning';
EXEC InsertSlotType 'Afternoon';
EXEC InsertSlotType 'Evening';
go

--Customer    [LastModifiedById]
IF (OBJECT_ID('FK_Customer_LastModified', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.Customer DROP CONSTRAINT FK_Customer_LastModified
END

--Employee    [UserId]
IF (OBJECT_ID('FK_Employees_User', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.Employees DROP CONSTRAINT FK_Employee_User
END

--Measure    [EnterredById]
IF (OBJECT_ID('FK_Measure_EnterredById', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.Measure DROP CONSTRAINT FK_Measure_EnterredById
END

--StoreUser    [UserId]
IF (OBJECT_ID('FK_StoreUser_Use', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.StoreUser DROP CONSTRAINT FK_StoreUser_Use
END

--Tech    [LastModifiedById]
IF (OBJECT_ID('FK_Tech_LastModified', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.Tech DROP CONSTRAINT FK_Tech_LastModified
END

--Tech    [UserId]
IF (OBJECT_ID('FK_Tech_User', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.Tech DROP CONSTRAINT FK_Tech_User
END
go

--Customer    [LastModifiedById]
ALTER TABLE Customer 
ADD CONSTRAINT [FK_Customer_LastModified] FOREIGN KEY ([LastModifiedById]) 
    REFERENCES [dbo].[AspNetUsers] ([Id]) ;
	
--Employee    [UserId]
ALTER TABLE dbo.Employees 
ADD CONSTRAINT [FK_Employees_User] FOREIGN KEY ([UserId]) 
    REFERENCES [dbo].[AspNetUsers] ([Id]) ;

--Measure    [EnterredById]
ALTER TABLE Measure 
ADD CONSTRAINT [FK_Measure_EnterredBy] FOREIGN KEY ([EnterredById]) 
    REFERENCES [dbo].[AspNetUsers] ([Id]) ;

--StoreUser    [UserId]
ALTER TABLE StoreUser 
ADD CONSTRAINT [FK_StoreUser_User] FOREIGN KEY ([UserId]) 
    REFERENCES [dbo].[AspNetUsers] ([Id]) ;

--Tech    [LastModifiedById]
ALTER TABLE Tech 
ADD CONSTRAINT [FK_Tech_LastModified] FOREIGN KEY ([LastModifiedById]) 
    REFERENCES [dbo].[AspNetUsers] ([Id]) ;

--Tech    [UserId]
ALTER TABLE Tech 
ADD CONSTRAINT [FK_Tech_User] FOREIGN KEY ([UserId]) 
    REFERENCES [dbo].[AspNetUsers] ([Id]) ;
go
