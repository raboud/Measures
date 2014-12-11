CREATE TABLE [dbo].[StoreUser]
(
	[StoreId] INT NOT NULL , 
    [UserId] [dbo].[AspNetUserId] NOT NULL, 
    CONSTRAINT [PK_StoreUser] PRIMARY KEY ([StoreId], [UserId]), 
    CONSTRAINT [FK_StoreUser_Store] FOREIGN KEY ([StoreId]) REFERENCES [Store]([Id])
)
