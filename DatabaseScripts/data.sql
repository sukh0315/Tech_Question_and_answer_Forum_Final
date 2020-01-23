INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7a8a896a-c84d-4fde-9124-0107e3d2ea37', N'forum_member', N'forum_member', N'1639b8b6-6fb8-4ad0-886e-415bbf88b70e')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1717edc5-7abd-471d-ab9c-3f3d35a1112b', N'faraday@gmail.com', N'FARADAY@GMAIL.COM', N'faraday@gmail.com', N'FARADAY@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEFBkKcDTllPn86zp0iOJjHb83cSINKlyys9NetDHon67CgHIvDXu9el0l85/zRL4Pw==', N'HQIXUTOOYWVECAFAM3W4RQGFC3NWNEQ7', N'a7a21532-b19a-42f5-8232-74fa62d20783', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bba5fc16-22eb-45aa-b536-86ebb72c7c65', N'kent@gmail.com', N'KENT@GMAIL.COM', N'kent@gmail.com', N'KENT@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEENWOZgmIDDv+g6bOXbEK1CGMInm8XUl7dlWugpAAa+DakHxJg/CiFMElFJH9aRRGA==', N'HYXI3GLJLBKEUNMMPS6KSWBAAJLWAJSV', N'f5697bdf-dd8d-483f-8032-a61c1499b53d', NULL, 0, 0, NULL, 1, 0)

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1717edc5-7abd-471d-ab9c-3f3d35a1112b', N'7a8a896a-c84d-4fde-9124-0107e3d2ea37')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bba5fc16-22eb-45aa-b536-86ebb72c7c65', N'7a8a896a-c84d-4fde-9124-0107e3d2ea37')


SET IDENTITY_INSERT [dbo].[ForumMember] ON
INSERT INTO [dbo].[ForumMember] ([Id], [Email], [Name], [Description]) VALUES (1, N'faraday@gmail.com', N'Tim Faraday', N'Software Developer in C# .Net')
INSERT INTO [dbo].[ForumMember] ([Id], [Email], [Name], [Description]) VALUES (2, N'kent@gmail.com', N'Kent James', N'Senior Developer C# Web API, Microservices ')
SET IDENTITY_INSERT [dbo].[ForumMember] OFF

SET IDENTITY_INSERT [dbo].[Question] ON
INSERT INTO [dbo].[Question] ([Id], [Title], [Details], [ForumMemberId]) VALUES (1, N'C # WEB api How to create a simple WEB api with front end?', N'Hi All,  Has any body come across any resources', 1)
INSERT INTO [dbo].[Question] ([Id], [Title], [Details], [ForumMemberId]) VALUES (2, N'How to use C# WEB API with micro services', N'Hi All, Has anybody have any links or resources where i can quickly learn how to deploy C# on Docker and Kubernetes cluster', 2)
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[Answer] ON
INSERT INTO [dbo].[Answer] ([Id], [Contents], [ForumMemberId], [QuestionId]) VALUES (1, N'Yes You can get the resources from the link http://www.webapiwithcsharp.com', 2, 1)
INSERT INTO [dbo].[Answer] ([Id], [Contents], [ForumMemberId], [QuestionId]) VALUES (2, N'Have you found the resources useful?', 2, 1)
INSERT INTO [dbo].[Answer] ([Id], [Contents], [ForumMemberId], [QuestionId]) VALUES (3, N'Yes You can find a tutorial at tutorial point "Microservice Docker deployments in C#"  They also have a PDF book', 1, 2)
SET IDENTITY_INSERT [dbo].[Answer] OFF
