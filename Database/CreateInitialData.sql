:On Error exit

USE [USClothesShop]
GO


-- User Table --

INSERT INTO [dbo].[User] ([FirstName],[LastName],[Email],[Login],[PasswordHash],[PasswordSalt],[Active],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (N'Андрей',N'Test','andrey@test.com','chyuck','7FD968BDC1BF0C55CFEC23DE9DE0145E','1B8A40A0C5C7309A457830A7045D1802',1,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO

INSERT INTO [dbo].[User] ([FirstName],[LastName],[Email],[Login],[PasswordHash],[PasswordSalt],[Active],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (N'Гость',N'','','guest','','',1,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO


-- Role Table --

INSERT INTO [dbo].[Role] ([Name])
VALUES (N'Администратор')
GO

INSERT INTO [dbo].[Role] ([Name])
VALUES (N'Закупщик')
GO

INSERT INTO [dbo].[Role] ([Name])
VALUES (N'Распространитель')
GO

INSERT INTO [dbo].[Role] ([Name])
VALUES (N'Продавец')
GO


-- UserRole Table --

INSERT INTO [dbo].[UserRole] ([UserId],[RoleId],[Active],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (1,1,1,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO

INSERT INTO [dbo].[UserRole] ([UserId],[RoleId],[Active],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (1,2,0,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO

INSERT INTO [dbo].[UserRole] ([UserId],[RoleId],[Active],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (1,3,0,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO

INSERT INTO [dbo].[UserRole] ([UserId],[RoleId],[Active],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (1,4,0,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO

INSERT INTO [dbo].[UserRole] ([UserId],[RoleId],[Active],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (2,1,0,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO

INSERT INTO [dbo].[UserRole] ([UserId],[RoleId],[Active],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (2,2,0,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO

INSERT INTO [dbo].[UserRole] ([UserId],[RoleId],[Active],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (2,3,0,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO

INSERT INTO [dbo].[UserRole] ([UserId],[RoleId],[Active],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (2,4,0,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO


-- ActionLogType Table --

INSERT INTO [dbo].[ActionLogType] ([Name]) 
VALUES (N'Пользователь создан')
GO

INSERT INTO [dbo].[ActionLogType] ([Name]) 
VALUES (N'Пользователь изменен')
GO

INSERT INTO [dbo].[ActionLogType] ([Name]) 
VALUES (N'Пользователь сменил пароль')
GO

INSERT INTO [dbo].[ActionLogType] ([Name]) 
VALUES (N'Пароль был сброшен для пользователя')
GO


-- Settings Table --

INSERT INTO [dbo].[Settings] ([RublesPerDollar],[CreateDate],[ChangeDate],[CreateUserId],[ChangeUserId])
VALUES (33,SYSUTCDATETIME(),SYSUTCDATETIME(),1,1)
GO