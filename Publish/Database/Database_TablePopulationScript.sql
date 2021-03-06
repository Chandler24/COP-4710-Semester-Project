USE [RSO_Database]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (1, N'John', N'Smith', N'johnsmith@gmail.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (2, N'Jimmy', N'Neutron', N'gottablast@gmail.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (3, N'Testing', N'Tester', N'test123@testing.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (4, N'Timmy', N'Turner', N'tturner@test.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (5, N'King', N'Tchalla', N'kt@wakanda.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (6, N'Testing', N'User', N'testuser@test.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (7, N'Test', N'New User', N'tnu@test.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (8, N'Jon', N'Snow', N'jsnow@gmail.com', N'Test123$', 2)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (9, N'Super', N'Admin', N'superadmin@test.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (10, N'admin', N'user', N'admin@test.com', N'Test123$', 2)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (11, N'Student', N'user', N'student@test.com', N'Test123$', 3)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (12, N'Test', N'SuperAdmin', N'super.admin@test.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (13, N'Chandler', N'Douglas', N'chandler@test.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (14, N'Knightro', N'UCF', N'knightro@ucf.com', N'Test123$', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (15, N'Testing', N'Admin', N'testadmin@test.com', N'Test123$', 2)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (16, N'Tony', N'Stark', N'tstark@test.com', N'Test123$', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
INSERT [dbo].[Locations] ([Id], [Name], [Longitude], [Latitude], [Hours]) VALUES (1, N'University of Central Florida', CAST(28.602400 AS Decimal(9, 6)), CAST(81.200100 AS Decimal(9, 6)), N'8 AM - 8 PM')
INSERT [dbo].[Locations] ([Id], [Name], [Longitude], [Latitude], [Hours]) VALUES (2, N'Magic Kingdom', CAST(28.417700 AS Decimal(9, 6)), CAST(81.581200 AS Decimal(9, 6)), N'9 AM - 10 PM')
INSERT [dbo].[EventType] ([Id], [Description]) VALUES (1, N'Public')
INSERT [dbo].[EventType] ([Id], [Description]) VALUES (2, N'Private')
INSERT [dbo].[EventType] ([Id], [Description]) VALUES (3, N'RSO')
INSERT [dbo].[EventCategory] ([Id], [Name]) VALUES (1, N'Social')
INSERT [dbo].[EventCategory] ([Id], [Name]) VALUES (2, N'Fundraising')
INSERT [dbo].[EventCategory] ([Id], [Name]) VALUES (3, N'TechTalk')
SET IDENTITY_INSERT [dbo].[Universities] ON 

INSERT [dbo].[Universities] ([Id], [Name], [Address1], [Address2], [City], [State], [Zip], [Description], [NumberOfStudents]) VALUES (1, N'University of Central Florida', N'4000 Central Florida Blvd', NULL, N'Orlando', N'Florida', N'32816', N'The University of Central Florida is home to UCF Knights - National Champions!', 66183)
INSERT [dbo].[Universities] ([Id], [Name], [Address1], [Address2], [City], [State], [Zip], [Description], [NumberOfStudents]) VALUES (2, N'University of South Florida', N'123 Garbage Lane', NULL, N'Tampa', N'Florida', N'32819', N'The University of South Florida sucks!', 66183)
INSERT [dbo].[Universities] ([Id], [Name], [Address1], [Address2], [City], [State], [Zip], [Description], [NumberOfStudents]) VALUES (3, N'Test New University', N'Testq', N'Test', N'Orlando', N'Florida', N'32825', N'Test', 8120)
SET IDENTITY_INSERT [dbo].[Universities] OFF
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [Name], [Type], [Category], [Description], [DateTime], [Location], [ContactPhone], [ContactEmail], [EventAdmin], [HostUniversity]) VALUES (4, N'UCF VS USF Tailgate! ', 1, 1, N'Come on out to tailgate before the big game! #BEATUSF', CAST(N'2018-11-23T11:00:00.000' AS DateTime), 1, N'386 847 6711', N'chandlerdgls@yahoo.com', 12, 1)
INSERT [dbo].[Events] ([Id], [Name], [Type], [Category], [Description], [DateTime], [Location], [ContactPhone], [ContactEmail], [EventAdmin], [HostUniversity]) VALUES (5, N'UCF Bowl Game', 1, 1, N'Come out and watch UCF win another bowl game! #Back2Back', CAST(N'2019-01-01T11:00:00.000' AS DateTime), 1, N'386 847 6711', N'chandlerdgls@yahoo.com', 12, 1)
INSERT [dbo].[Events] ([Id], [Name], [Type], [Category], [Description], [DateTime], [Location], [ContactPhone], [ContactEmail], [EventAdmin], [HostUniversity]) VALUES (6, N'Robotics Team Meeting', 2, 1, N'This is a very selective event! Make sure you RSVP!', CAST(N'2018-12-01T14:00:00.000' AS DateTime), 1, N'386 847 6711', N'chandlerdgls@yahoo.com', 14, 1)
INSERT [dbo].[Events] ([Id], [Name], [Type], [Category], [Description], [DateTime], [Location], [ContactPhone], [ContactEmail], [EventAdmin], [HostUniversity]) VALUES (7, N'New Member Orientation', 3, 1, N'Everyone come out and welcome our new members! ', CAST(N'2018-12-12T12:00:00.000' AS DateTime), 1, N'386 847 6711', N'chandlerdgls@yahoo.com', 14, 1)
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[EventSocial] ON 

INSERT [dbo].[EventSocial] ([Id], [EventId], [UserId], [Rating], [Comment], [IsDeleted]) VALUES (4, 4, 13, NULL, N'Can''t wait! Let''s beat USF! EDIT: Where should I park?', 1)
INSERT [dbo].[EventSocial] ([Id], [EventId], [UserId], [Rating], [Comment], [IsDeleted]) VALUES (5, 4, 13, NULL, N'Test', 0)
INSERT [dbo].[EventSocial] ([Id], [EventId], [UserId], [Rating], [Comment], [IsDeleted]) VALUES (6, 4, 14, NULL, N'Test', 1)
SET IDENTITY_INSERT [dbo].[EventSocial] OFF
SET IDENTITY_INSERT [dbo].[RegisteredStudentOrganizations] ON 

INSERT [dbo].[RegisteredStudentOrganizations] ([Id], [Name], [Description]) VALUES (5, N'UCF Robotics Club', N'Come join the UCF Robotics club! We delve into everything robotics --- AI, Machine learning, design, and custom building robots!')
INSERT [dbo].[RegisteredStudentOrganizations] ([Id], [Name], [Description]) VALUES (6, N'Film Fanatics', N'We''re a bunch of students that love talking about & watching films! Come on out for in-depth discussions, movie nights, and fun!')
INSERT [dbo].[RegisteredStudentOrganizations] ([Id], [Name], [Description]) VALUES (7, N'Actuarial Science Club', N'To provide support and fellowship for students interested in pursuing a career in the field of actuarial science. ')
SET IDENTITY_INSERT [dbo].[RegisteredStudentOrganizations] OFF
SET IDENTITY_INSERT [dbo].[RSO_Members] ON 

INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (8, 5, N'chandler@test.com', 1)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (9, 5, N'chandler@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (10, 5, N'jesse@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (11, 5, N'whitney@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (12, 5, N'tia@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (13, 5, N'tony@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (14, 6, N'chandler@test.com', 1)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (15, 6, N'chandler@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (16, 6, N'jesse@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (17, 6, N'whitney@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (18, 6, N'tia@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (19, 6, N'tony@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (20, 7, N'chandler@test.com', 1)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (21, 7, N'chandler@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (22, 7, N'jesse@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (23, 7, N'whitney@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (24, 7, N'tia@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (25, 7, N'tony@knights.ucf.edu', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (27, 5, N'knightro@ucf.com', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (28, 6, N'knightro@ucf.com', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (29, 7, N'knightro@ucf.com', 0)
INSERT [dbo].[RSO_Members] ([Id], [RSO_Id], [StudentEmail], [IsAdmin]) VALUES (30, 5, N'tstark@test.com', 0)
SET IDENTITY_INSERT [dbo].[RSO_Members] OFF
SET IDENTITY_INSERT [dbo].[UserTypes] ON 

INSERT [dbo].[UserTypes] ([Id], [Description]) VALUES (1, N'Super Admin')
INSERT [dbo].[UserTypes] ([Id], [Description]) VALUES (2, N'Admin')
INSERT [dbo].[UserTypes] ([Id], [Description]) VALUES (3, N'Student')
SET IDENTITY_INSERT [dbo].[UserTypes] OFF
