:On Error exit

USE [master]
GO

IF DB_ID(N'USClothesShop') IS NULL
BEGIN
	EXEC sp_executesql N'CREATE DATABASE [USClothesShop] COLLATE Cyrillic_General_CI_AS';
END
GO

USE [USClothesShop]
GO


-- User Table --
CREATE TABLE [dbo].[User]
(
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[PasswordHash] [varchar](32) NOT NULL,
	[PasswordSalt] [varchar](32) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId]),
 CONSTRAINT [UK_User] UNIQUE NONCLUSTERED ([Login])
)
GO

ALTER TABLE [dbo].[User] ADD CONSTRAINT [FK_User_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_User_CreateUser] ON [dbo].[User] ([CreateUserId])
GO

ALTER TABLE [dbo].[User] ADD CONSTRAINT [FK_User_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_User_ChangeUser] ON [dbo].[User] ([ChangeUserId])
GO


-- Role Table --
CREATE TABLE [dbo].[Role]
(
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleId]),
 CONSTRAINT [UK_Role] UNIQUE NONCLUSTERED ([Name])
)
GO


-- UserRole Table --
CREATE TABLE [dbo].[UserRole]
(
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([UserRoleId]),
 CONSTRAINT [UK_UserRole] UNIQUE NONCLUSTERED ([UserId],[RoleId])
)
GO

ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_UserRole_User] ON [dbo].[UserRole] ([UserId])
GO

ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId]) REFERENCES [dbo].[Role] ([RoleId])
GO
CREATE NONCLUSTERED INDEX [IX_UserRole_Role] ON [dbo].[UserRole] ([RoleId])
GO

ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [FK_UserRole_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_UserRole_CreateUser] ON [dbo].[UserRole] ([CreateUserId])
GO

ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [FK_UserRole_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_UserRole_ChangeUser] ON [dbo].[UserRole] ([ChangeUserId])
GO


-- Brand Table --
CREATE TABLE [dbo].[Brand]
(
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED ([BrandId]),
 CONSTRAINT [UK_Brand] UNIQUE NONCLUSTERED ([Name])
)
GO

ALTER TABLE [dbo].[Brand] ADD CONSTRAINT [FK_Brand_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Brand_CreateUser] ON [dbo].[Brand] ([CreateUserId])
GO

ALTER TABLE [dbo].[Brand] ADD CONSTRAINT [FK_Brand_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Brand_ChangeUser] ON [dbo].[Brand] ([ChangeUserId])
GO


-- Category Table --
CREATE TABLE [dbo].[Category]
(
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId]),
 CONSTRAINT [UK_Category] UNIQUE NONCLUSTERED ([Name])
)
GO

ALTER TABLE [dbo].[Category] ADD CONSTRAINT [FK_Category_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Category_CreateUser] ON [dbo].[Category] ([CreateUserId])
GO

ALTER TABLE [dbo].[Category] ADD CONSTRAINT [FK_Category_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Category_ChangeUser] ON [dbo].[Category] ([ChangeUserId])
GO


-- SubCategory Table --
CREATE TABLE [dbo].[SubCategory]
(
	[SubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED ([SubCategoryId]),
 CONSTRAINT [UK_SubCategory] UNIQUE NONCLUSTERED ([Name],[CategoryId])
)
GO

ALTER TABLE [dbo].[SubCategory] ADD CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
GO
CREATE NONCLUSTERED INDEX [IX_SubCategory_Category] ON [dbo].[SubCategory] ([CategoryId])
GO

ALTER TABLE [dbo].[SubCategory] ADD CONSTRAINT [FK_SubCategory_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_SubCategory_CreateUser] ON [dbo].[SubCategory] ([CreateUserId])
GO

ALTER TABLE [dbo].[SubCategory] ADD CONSTRAINT [FK_SubCategory_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_SubCategory_ChangeUser] ON [dbo].[SubCategory] ([ChangeUserId])
GO


-- Size Table --
CREATE TABLE [dbo].[Size]
(
	[SizeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SubCategoryId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
	[Weight] [nvarchar](30) NOT NULL,
	[Height] [nvarchar](30) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED ([SizeId]),
 CONSTRAINT [UK_Size] UNIQUE NONCLUSTERED ([Name],[SubCategoryId],[BrandId])
)
GO

ALTER TABLE [dbo].[Size] ADD CONSTRAINT [FK_Size_SubCategory] FOREIGN KEY([SubCategoryId]) REFERENCES [dbo].[SubCategory] ([SubCategoryId])
GO
CREATE NONCLUSTERED INDEX [IX_Size_SubCategory] ON [dbo].[Size] ([SubCategoryId])
GO

ALTER TABLE [dbo].[Size] ADD CONSTRAINT [FK_Size_Brand] FOREIGN KEY([BrandId]) REFERENCES [dbo].[Brand] ([BrandId])
GO
CREATE NONCLUSTERED INDEX [IX_Size_Brand] ON [dbo].[Size] ([BrandId])
GO

ALTER TABLE [dbo].[Size] ADD CONSTRAINT [FK_Size_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Size_CreateUser] ON [dbo].[Size] ([CreateUserId])
GO

ALTER TABLE [dbo].[Size] ADD CONSTRAINT [FK_Size_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Size_ChangeUser] ON [dbo].[Size] ([ChangeUserId])
GO


-- Product Table --
CREATE TABLE [dbo].[Product]
(
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[PreviewPictureURL] [varchar](1000) NOT NULL,
	[FullPictureURL] [varchar](1000) NOT NULL,
	[VendorShopURL] [varchar](1000) NULL,
	[SubCategoryId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId])
)
GO

ALTER TABLE [dbo].[Product] ADD CONSTRAINT [FK_Product_SubCategory] FOREIGN KEY([SubCategoryId]) REFERENCES [dbo].[SubCategory] ([SubCategoryId])
GO
CREATE NONCLUSTERED INDEX [IX_Product_SubCategory] ON [dbo].[Product] ([SubCategoryId])
GO

ALTER TABLE [dbo].[Product] ADD CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId]) REFERENCES [dbo].[Brand] ([BrandId])
GO
CREATE NONCLUSTERED INDEX [IX_Product_Brand] ON [dbo].[Brand] ([BrandId])
GO

ALTER TABLE [dbo].[Product] ADD CONSTRAINT [FK_Product_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Product_CreateUser] ON [dbo].[Product] ([CreateUserId])
GO

ALTER TABLE [dbo].[Product] ADD CONSTRAINT [FK_Product_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Product_ChangeUser] ON [dbo].[Product] ([ChangeUserId])
GO


-- ProductSize Table --
CREATE TABLE [dbo].[ProductSize]
(
	[ProductSizeId] [int] IDENTITY(1,1) NOT NULL,
	[Price] [money] NOT NULL,
	[ProductId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_ProductSize] PRIMARY KEY CLUSTERED ([ProductSizeId]),
 CONSTRAINT [UK_ProductSize] UNIQUE NONCLUSTERED ([ProductId],[SizeId])
)
GO

ALTER TABLE [dbo].[ProductSize] ADD CONSTRAINT [FK_ProductSize_Product] FOREIGN KEY([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
GO
CREATE NONCLUSTERED INDEX [IX_ProductSize_Product] ON [dbo].[ProductSize] ([ProductId])
GO

ALTER TABLE [dbo].[ProductSize] ADD CONSTRAINT [FK_ProductSize_Size] FOREIGN KEY([SizeId]) REFERENCES [dbo].[Size] ([SizeId])
GO
CREATE NONCLUSTERED INDEX [IX_ProductSize_Size] ON [dbo].[ProductSize] ([SizeId])
GO

ALTER TABLE [dbo].[ProductSize] ADD CONSTRAINT [FK_ProductSize_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_ProductSize_CreateUser] ON [dbo].[ProductSize] ([CreateUserId])
GO

ALTER TABLE [dbo].[ProductSize] ADD CONSTRAINT [FK_ProductSize_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_ProductSize_ChangeUser] ON [dbo].[ProductSize] ([ChangeUserId])
GO


-- Parcel Table --
CREATE TABLE [dbo].[Parcel]
(
	[ParcelId] [int] IDENTITY(1,1) NOT NULL,
	[TrackingNumber] [nvarchar](20) NULL,
	[SentDate] [datetime2](7) NULL,
	[Comments] [nvarchar](1000) NULL,
	[RublesPerDollar] [money] NOT NULL,
	[PurchaserSpentOnDelivery] [money] NOT NULL,
	[DistributorId] [int] NULL,
	[ReceivedDate] [datetime2](7) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,

 CONSTRAINT [PK_Parcel] PRIMARY KEY CLUSTERED ([ParcelId])
)
GO

ALTER TABLE [dbo].[Parcel] ADD CONSTRAINT [FK_Parcel_Distributor] FOREIGN KEY([DistributorId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Parcel_Distributor] ON [dbo].[Parcel] ([DistributorId])
GO

ALTER TABLE [dbo].[Parcel] ADD CONSTRAINT [FK_Parcel_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Parcel_CreateUser] ON [dbo].[Parcel] ([CreateUserId])
GO

ALTER TABLE [dbo].[Parcel] ADD CONSTRAINT [FK_Parcel_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Parcel_ChangeUser] ON [dbo].[Parcel] ([ChangeUserId])
GO


-- Order Table --
CREATE TABLE [dbo].[Order]
(
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[CustomerFirstName] [nvarchar](50) NOT NULL,
	[CustomerLastName] [nvarchar](50) NOT NULL,
	[CustomerAddress] [nvarchar](100) NOT NULL,
	[CustomerCity] [nvarchar](50) NOT NULL,
	[CustomerCountry] [nvarchar](50) NOT NULL,
	[CustomerPostalCode] [varchar](20) NOT NULL,
	[CustomerPhoneNumber] [varchar](20) NOT NULL,
	[CustomerEmail] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[Comments] [nvarchar](1000) NULL,
	[RublesPerDollar] [money] NOT NULL,
	[CustomerPrepaid] [money] NOT NULL,
	[ParcelId] [int] NULL,
	[DistributorSpentOnDelivery] [money] NOT NULL,
	[CustomerPaid] [money] NOT NULL,
	[TrackingNumber] [nvarchar](20) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,

 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderId])
)
GO

ALTER TABLE [dbo].[Order] ADD CONSTRAINT [FK_Order_Parcel] FOREIGN KEY([ParcelId]) REFERENCES [dbo].[Parcel] ([ParcelId])
GO
CREATE NONCLUSTERED INDEX [IX_Order_Parcel] ON [dbo].[Order] ([ParcelId])
GO

ALTER TABLE [dbo].[Order] ADD CONSTRAINT [FK_Order_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Order_CreateUser] ON [dbo].[Order] ([CreateUserId])
GO

ALTER TABLE [dbo].[Order] ADD CONSTRAINT [FK_Order_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Order_ChangeUser] ON [dbo].[Order] ([ChangeUserId])
GO


-- OrderItem Table --
CREATE TABLE [dbo].[OrderItem]
(
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[Price] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[PurchaserPaid] [money] NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductSizeId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED ([OrderItemId]),
 CONSTRAINT [UK_OrderItem] UNIQUE NONCLUSTERED ([OrderId],[ProductSizeId])
)
GO

ALTER TABLE [dbo].[OrderItem] ADD CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY([OrderId]) REFERENCES [dbo].[Order] ([OrderId])
GO
CREATE NONCLUSTERED INDEX [IX_OrderItem_Order] ON [dbo].[OrderItem] ([OrderId])
GO

ALTER TABLE [dbo].[OrderItem] ADD CONSTRAINT [FK_OrderItem_ProductSize] FOREIGN KEY([ProductSizeId]) REFERENCES [dbo].[ProductSize] ([ProductSizeId])
GO
CREATE NONCLUSTERED INDEX [IX_OrderItem_ProductSize] ON [dbo].[OrderItem] ([ProductSizeId])
GO

ALTER TABLE [dbo].[OrderItem] ADD CONSTRAINT [FK_OrderItem_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_OrderItem_CreateUser] ON [dbo].[OrderItem] ([CreateUserId])
GO

ALTER TABLE [dbo].[OrderItem] ADD CONSTRAINT [FK_OrderItem_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_OrderItem_ChangeUser] ON [dbo].[OrderItem] ([ChangeUserId])
GO


-- ActionLogType Table --
CREATE TABLE [dbo].[ActionLogType]
(
	[ActionLogTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL
 CONSTRAINT [PK_ActionLogType] PRIMARY KEY CLUSTERED ([ActionLogTypeId]),
 CONSTRAINT [UK_ActionLogType] UNIQUE NONCLUSTERED ([Name])
)
GO


-- ActionLog Table --
CREATE TABLE [dbo].[ActionLog]
(
	[ActionLogId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[DocumentId] [int] NOT NULL,
	[ActionLogTypeId] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
 CONSTRAINT [PK_ActionLog] PRIMARY KEY CLUSTERED ([ActionLogId])
)
GO

ALTER TABLE [dbo].[ActionLog] ADD CONSTRAINT [FK_ActionLog_ActionLogType] FOREIGN KEY([ActionLogTypeId]) REFERENCES [dbo].[ActionLogType] ([ActionLogTypeId])
GO
CREATE NONCLUSTERED INDEX [IX_ActionLog_ActionLogType] ON [dbo].[ActionLog] ([ActionLogTypeId])
GO

ALTER TABLE [dbo].[ActionLog] ADD CONSTRAINT [FK_ActionLog_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_ActionLog_CreateUser] ON [dbo].[ActionLog] ([CreateUserId])
GO


-- Session Table --
CREATE TABLE [dbo].[Session]
(
	[SessionId] [int] IDENTITY(1,1) NOT NULL,
	[Key] [varchar](50) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED ([SessionId]),
 CONSTRAINT [UK_Session] UNIQUE NONCLUSTERED ([Key])
)
GO


-- ShoppingCart Table --
CREATE TABLE [dbo].[ShoppingCart]
(
	[ShoppingCartId] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[SessionId] [int] NOT NULL,
	[ProductSizeId] [int] NOT NULL
 CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED ([ShoppingCartId])
)
GO

ALTER TABLE [dbo].[ShoppingCart] ADD CONSTRAINT [FK_ShoppingCart_Session] FOREIGN KEY([SessionId]) REFERENCES [dbo].[Session] ([SessionId])
GO
CREATE NONCLUSTERED INDEX [IX_ShoppingCart_Session] ON [dbo].[ShoppingCart] ([SessionId])
GO

ALTER TABLE [dbo].[ShoppingCart] ADD CONSTRAINT [FK_ShoppingCart_ProductSize] FOREIGN KEY([ProductSizeId]) REFERENCES [dbo].[ProductSize] ([ProductSizeId])
GO
CREATE NONCLUSTERED INDEX [IX_ShoppingCart_ProductSize] ON [dbo].[ShoppingCart] ([ProductSizeId])
GO


-- Settings Table --
CREATE TABLE [dbo].[Settings]
(
	[SettingsId] [int] IDENTITY(1,1) NOT NULL,
	[RublesPerDollar] [money] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([SettingsId])
)
GO

ALTER TABLE [dbo].[Settings] ADD CONSTRAINT [FK_Settings_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Settings_CreateUser] ON [dbo].[Settings] ([CreateUserId])
GO

ALTER TABLE [dbo].[Settings] ADD CONSTRAINT [FK_Settings_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_Settings_ChangeUser] ON [dbo].[Settings] ([ChangeUserId])
GO


-- DistributorTransfer Table --
CREATE TABLE [dbo].[DistributorTransfer]
(
	[DistributorTransferId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Amount] [money] NOT NULL,
	[RublesPerDollar] [money] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ChangeUserId] [int] NOT NULL,
 CONSTRAINT [PK_DistributorTransfer] PRIMARY KEY CLUSTERED ([DistributorTransferId])
)
GO

ALTER TABLE [dbo].[DistributorTransfer] ADD CONSTRAINT [FK_DistributorTransfer_CreateUser] FOREIGN KEY([CreateUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_DistributorTransfer_CreateUser] ON [dbo].[DistributorTransfer] ([CreateUserId])
GO

ALTER TABLE [dbo].[DistributorTransfer] ADD CONSTRAINT [FK_DistributorTransfer_ChangeUser] FOREIGN KEY([ChangeUserId]) REFERENCES [dbo].[User] ([UserId])
GO
CREATE NONCLUSTERED INDEX [IX_DistributorTransfer_ChangeUser] ON [dbo].[DistributorTransfer] ([ChangeUserId])
GO