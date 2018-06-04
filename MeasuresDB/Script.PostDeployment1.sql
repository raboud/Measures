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
IF (OBJECT_ID('FK_Employee_User', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.Employee DROP CONSTRAINT FK_Employee_User
END

--Measure    [EnterredById]
IF (OBJECT_ID('FK_Measure_EnterredById', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.Measure DROP CONSTRAINT FK_Measure_EnterredById
END

--StoreUser    [UserId]
IF (OBJECT_ID('FK_StoreUser_User', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.StoreUser DROP CONSTRAINT FK_StoreUser_User
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
ALTER TABLE dbo.Employee 
ADD CONSTRAINT [FK_Employee_User] FOREIGN KEY ([UserId]) 
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

ALTER TABLE Slot
ADD CONSTRAINT [FK_Slot_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) on delete cascade;
go
