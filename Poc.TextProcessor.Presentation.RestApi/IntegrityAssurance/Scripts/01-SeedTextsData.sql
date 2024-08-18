USE [PocTextProcessor];

SET IDENTITY_INSERT [dbo].[Texts] ON;

INSERT INTO [dbo].[Texts]([Id], [Content]) VALUES (10001, N'Test Expected Result.');
INSERT INTO [dbo].[Texts]([Id], [Content]) VALUES (10002, N'Test Result for Get by Id.');
INSERT INTO [dbo].[Texts]([Id], [Content]) VALUES (10003, N'Test Result for Delete.');

SET IDENTITY_INSERT [dbo].[Texts] OFF;