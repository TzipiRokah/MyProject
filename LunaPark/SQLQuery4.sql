
drop database [LunaPark]
go
create database [LunaPark]
go
USE [LunaPark]
GO
/****** Object:  Table [dbo].[AccessLevel]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessLevel](
	[AccessLevelId] [int] IDENTITY(1,1) NOT NULL,
	[AccessDetails] [nchar](30) NULL,
 CONSTRAINT [PK_AccessLevel] PRIMARY KEY CLUSTERED 
(
	[AccessLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Attraction]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attraction](
	[AttractionId] [int] IDENTITY(1,1) NOT NULL,
	[AttractionName] [nchar](30) NULL,
	[AttractionIfActive] [int] NULL,
	[AttractionMaxPeople] [int] NOT NULL,
	[AttractionNowPeople] [int] NULL,
	[AttractionCountQueue] [int] NOT NULL,
	[AttractionTime] [int] NOT NULL,
	[AttractionTimeOUt] [int] NOT NULL,
	[AttractionLastAction] [int] NULL,
	[AttractionCost] [int] NULL,
 CONSTRAINT [PK_Attraction] PRIMARY KEY CLUSTERED 
(
	[AttractionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AttractionStatus]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttractionStatus](
	[AttractionStatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [int] NULL,
	[AttractionId] [int] NULL,
	[AttractionStatusDateTime] [datetime] NULL,
	[EmployeeReportId] [int] NULL,
 CONSTRAINT [PK_AttractionStatus] PRIMARY KEY CLUSTERED 
(
	[AttractionStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeAccessLevel] [int] NULL,
	[EmployeeDetails] [nchar](30) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FavoriteAttraction]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoriteAttraction](
	[FavoriteAttractionId] [int] IDENTITY(1,1) NOT NULL,
	[AttractionId] [int] NULL,
	[UserId] [int] NULL,
	[FavoriteAttractionRate] [int] NULL,
 CONSTRAINT [PK_FavoriteAttraction] PRIMARY KEY CLUSTERED 
(
	[FavoriteAttractionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[MessageDateTime] [datetime] NULL,
	[MessageDetails] [nchar](300) NULL,
	[EmployeeId] [int] NULL,
	[AttractionId] [int] NULL,
	[UserId] [int] NULL,
	[AccessLevelId] [int] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QueuePerUser]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueuePerUser](
	[QueuePerUserId] [int] IDENTITY(1,1) NOT NULL,
	[QueueId] [int] NOT NULL,
	[UserId] [int] NULL,
	[CountTickets] [int] NULL,
 CONSTRAINT [PK_QueuePerUser] PRIMARY KEY CLUSTERED 
(
	[QueuePerUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Queues]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Queues](
	[QueueId] [int] IDENTITY(1,1) NOT NULL,
	[AttractionId] [int] NULL,
	[Hour] [datetime] NULL,
	[MaxPeopleInAttraction] [int] NULL,
 CONSTRAINT [PK_Queues] PRIMARY KEY CLUSTERED 
(
	[QueueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rate]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate](
	[RateId] [int] IDENTITY(1,1) NOT NULL,
	[AttractionId] [int] NULL,
	[UserId] [int] NULL,
	[RateDateTime] [datetime] NULL,
	[RateLevel] [int] NULL,
 CONSTRAINT [PK_Rate] PRIMARY KEY CLUSTERED 
(
	[RateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Status]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusDetails] [nchar](10) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/09/2020 23:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserEnterance] [nchar](20) NULL,
	[UserPassword] [nchar](10) NULL,
	[UserFirstName] [nchar](10) NULL,
	[UserLastName] [nchar](10) NULL,
	[UserGmail] [nchar](30) NULL,
	[UserPhone] [nchar](10) NULL,
	[UsersCount] [int] NULL,
	[UserAccessLevel] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AccessLevel] ON 

GO
INSERT [dbo].[AccessLevel] ([AccessLevelId], [AccessDetails]) VALUES (1, N'מנהל                          ')
GO
INSERT [dbo].[AccessLevel] ([AccessLevelId], [AccessDetails]) VALUES (2, N'סדרן                          ')
GO
INSERT [dbo].[AccessLevel] ([AccessLevelId], [AccessDetails]) VALUES (3, N'מפעיל מתקן                    ')
GO
INSERT [dbo].[AccessLevel] ([AccessLevelId], [AccessDetails]) VALUES (4, N'לקוח                          ')
GO
SET IDENTITY_INSERT [dbo].[AccessLevel] OFF
GO
SET IDENTITY_INSERT [dbo].[Attraction] ON 

GO
INSERT [dbo].[Attraction] ([AttractionId], [AttractionName], [AttractionIfActive], [AttractionMaxPeople], [AttractionNowPeople], [AttractionCountQueue], [AttractionTime], [AttractionTimeOUt], [AttractionLastAction], [AttractionCost]) VALUES (1, N'רכבת הרים                     ', 1, 50, 48, 100, 4, 4, 17, 30)
GO
INSERT [dbo].[Attraction] ([AttractionId], [AttractionName], [AttractionIfActive], [AttractionMaxPeople], [AttractionNowPeople], [AttractionCountQueue], [AttractionTime], [AttractionTimeOUt], [AttractionLastAction], [AttractionCost]) VALUES (2, N'גלגל ענק                      ', 1, 70, 0, 200, 15, 15, 17, 20)
GO
INSERT [dbo].[Attraction] ([AttractionId], [AttractionName], [AttractionIfActive], [AttractionMaxPeople], [AttractionNowPeople], [AttractionCountQueue], [AttractionTime], [AttractionTimeOUt], [AttractionLastAction], [AttractionCost]) VALUES (3, N'מערת שדים                     ', 1, 20, 20, 100, 15, 5, 17, 15)
GO
INSERT [dbo].[Attraction] ([AttractionId], [AttractionName], [AttractionIfActive], [AttractionMaxPeople], [AttractionNowPeople], [AttractionCountQueue], [AttractionTime], [AttractionTimeOUt], [AttractionLastAction], [AttractionCost]) VALUES (4, N'סירות                         ', 1, 30, 28, 100, 10, 7, 17, 15)
GO
INSERT [dbo].[Attraction] ([AttractionId], [AttractionName], [AttractionIfActive], [AttractionMaxPeople], [AttractionNowPeople], [AttractionCountQueue], [AttractionTime], [AttractionTimeOUt], [AttractionLastAction], [AttractionCost]) VALUES (5, N'ספינת פיראטים                 ', 1, 15, 15, 50, 5, 4, 17, 12)
GO
INSERT [dbo].[Attraction] ([AttractionId], [AttractionName], [AttractionIfActive], [AttractionMaxPeople], [AttractionNowPeople], [AttractionCountQueue], [AttractionTime], [AttractionTimeOUt], [AttractionLastAction], [AttractionCost]) VALUES (6, N'בלאק במבה                     ', 1, 20, 19, 80, 6, 4, 17, 15)
GO
SET IDENTITY_INSERT [dbo].[Attraction] OFF
GO
SET IDENTITY_INSERT [dbo].[AttractionStatus] ON 

GO
INSERT [dbo].[AttractionStatus] ([AttractionStatusId], [StatusId], [AttractionId], [AttractionStatusDateTime], [EmployeeReportId]) VALUES (1, 1, 1, CAST(0x0000ABCE00000000 AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[AttractionStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

GO
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeAccessLevel], [EmployeeDetails]) VALUES (1, 3, N'מפעיל רכבת הרים               ')
GO
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeAccessLevel], [EmployeeDetails]) VALUES (2, 3, N'מפעיל מערת שדים               ')
GO
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeAccessLevel], [EmployeeDetails]) VALUES (3, 2, N'סדרן בוקר                     ')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[FavoriteAttraction] ON 

GO
INSERT [dbo].[FavoriteAttraction] ([FavoriteAttractionId], [AttractionId], [UserId], [FavoriteAttractionRate]) VALUES (3, 1, 1, 5)
GO
INSERT [dbo].[FavoriteAttraction] ([FavoriteAttractionId], [AttractionId], [UserId], [FavoriteAttractionRate]) VALUES (4, 2, 1, 4)
GO
SET IDENTITY_INSERT [dbo].[FavoriteAttraction] OFF
GO
SET IDENTITY_INSERT [dbo].[Message] ON 

GO
INSERT [dbo].[Message] ([MessageId], [MessageDateTime], [MessageDetails], [EmployeeId], [AttractionId], [UserId], [AccessLevelId]) VALUES (1, CAST(0x0000ABCE00000000 AS DateTime), N'הנחה ברכבת הרים                                                                                                                                                                                                                                                                                             ', NULL, NULL, 1, 4)
GO
INSERT [dbo].[Message] ([MessageId], [MessageDateTime], [MessageDetails], [EmployeeId], [AttractionId], [UserId], [AccessLevelId]) VALUES (2, CAST(0x0000AC4300000000 AS DateTime), N'תקלה ברכבת הרים                                                                                                                                                                                                                                                                                             ', 2, NULL, NULL, 3)
GO
SET IDENTITY_INSERT [dbo].[Message] OFF
GO
SET IDENTITY_INSERT [dbo].[QueuePerUser] ON 

GO
INSERT [dbo].[QueuePerUser] ([QueuePerUserId], [QueueId], [UserId], [CountTickets]) VALUES (1, 1, 1, 3)
GO
INSERT [dbo].[QueuePerUser] ([QueuePerUserId], [QueueId], [UserId], [CountTickets]) VALUES (2, 2, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[QueuePerUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Queues] ON 

GO
INSERT [dbo].[Queues] ([QueueId], [AttractionId], [Hour], [MaxPeopleInAttraction]) VALUES (1, 1, CAST(0x0000AC3D009450C0 AS DateTime), 47)
GO
INSERT [dbo].[Queues] ([QueueId], [AttractionId], [Hour], [MaxPeopleInAttraction]) VALUES (2, 2, CAST(0x0000AC3D015A11C0 AS DateTime), 47)
GO
INSERT [dbo].[Queues] ([QueueId], [AttractionId], [Hour], [MaxPeopleInAttraction]) VALUES (3, 1, CAST(0x0000AC3D00968340 AS DateTime), 50)
GO
SET IDENTITY_INSERT [dbo].[Queues] OFF
GO
SET IDENTITY_INSERT [dbo].[Rate] ON 

GO
INSERT [dbo].[Rate] ([RateId], [AttractionId], [UserId], [RateDateTime], [RateLevel]) VALUES (2, 1, 1, CAST(0x0000ABCE00000000 AS DateTime), 5)
GO
INSERT [dbo].[Rate] ([RateId], [AttractionId], [UserId], [RateDateTime], [RateLevel]) VALUES (3, 2, 1, CAST(0x0000AC4000000000 AS DateTime), 4)
GO
INSERT [dbo].[Rate] ([RateId], [AttractionId], [UserId], [RateDateTime], [RateLevel]) VALUES (4, 1, 1, CAST(0x0000AC4100000000 AS DateTime), 3)
GO
INSERT [dbo].[Rate] ([RateId], [AttractionId], [UserId], [RateDateTime], [RateLevel]) VALUES (5, 3, 1, CAST(0x0000AC4100000000 AS DateTime), 2)
GO
INSERT [dbo].[Rate] ([RateId], [AttractionId], [UserId], [RateDateTime], [RateLevel]) VALUES (6, 2, 1, CAST(0x0000AC4100000000 AS DateTime), 3)
GO
INSERT [dbo].[Rate] ([RateId], [AttractionId], [UserId], [RateDateTime], [RateLevel]) VALUES (7, 6, 1, CAST(0x0000AC420163DD3A AS DateTime), 2)
GO
INSERT [dbo].[Rate] ([RateId], [AttractionId], [UserId], [RateDateTime], [RateLevel]) VALUES (8, 4, 1, CAST(0x0000AC420163E286 AS DateTime), 5)
GO
INSERT [dbo].[Rate] ([RateId], [AttractionId], [UserId], [RateDateTime], [RateLevel]) VALUES (9, 2, 1, CAST(0x0000AC42016599F1 AS DateTime), 4)
GO
INSERT [dbo].[Rate] ([RateId], [AttractionId], [UserId], [RateDateTime], [RateLevel]) VALUES (10, 1, 1, CAST(0x0000AC4201781F32 AS DateTime), 5)
GO
SET IDENTITY_INSERT [dbo].[Rate] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

GO
INSERT [dbo].[Status] ([StatusId], [StatusDetails]) VALUES (1, N'פעיל      ')
GO
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (1, N'רינה                ', N'9852      ', N'רינה      ', N'ברק       ', N'rinabarak3222@gmail.com       ', N'0533149852', 1, 1)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (2, N'ציפי                ', N'5666      ', N'ציפי      ', N'רוקח      ', N'tzipi409@gmail.com            ', N'0504168409', 1, 3)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (3, N'אפרת                ', N'5589      ', N'אפרת      ', N'כהן       ', N'efrat263@gmail.com            ', N'0568956321', 1, 2)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (4, N'                    ', N'          ', N'          ', N'          ', N'                              ', N'          ', 1, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (5, NULL, NULL, NULL, NULL, NULL, NULL, 1, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (6, NULL, NULL, NULL, NULL, NULL, NULL, 1, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (7, NULL, NULL, NULL, NULL, NULL, NULL, 1, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (8, NULL, NULL, NULL, NULL, NULL, NULL, 1, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (9, NULL, NULL, NULL, NULL, NULL, NULL, 1, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (10, NULL, NULL, NULL, NULL, NULL, NULL, 1, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (13, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (15, N'שרי                 ', N'125631    ', N'שרי       ', N'כהן       ', N'sari@gmail.com                ', N'0533147852', NULL, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (16, N'שירה                ', N'789456    ', N'שירה      ', N'לוי       ', N'shira@gmail.com               ', N'0568963852', 1, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (17, N'מירי                ', N'789456    ', N'מירי      ', N'ברק       ', N'miri@gmail.com                ', N'025807495 ', 1, NULL)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (18, N'רבקי                ', N'4563      ', N'רבקה      ', N'כהן       ', N'rivka@gmail.com               ', N'0556478965', 1, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (19, N'                    ', N'          ', N'          ', N'          ', N'                              ', N'          ', NULL, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (20, N'שרי                 ', N'123456    ', N'שרי       ', N'לוי       ', N'sari@gmail.com                ', N'025888444 ', 1, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (21, N'ג.ר.                ', N'45678     ', N'גילה      ', N'מילר      ', N'gili.m@gmail.com              ', N'025777469 ', 3, 4)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (22, N'Gadi                ', N'9999      ', N'Gadi      ', N'Levin     ', N'gadi.levin@gmail.com          ', N'0556789999', 1, 3)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (23, N'בנימין              ', N'7894as    ', N'בנימין    ', N'ישראל     ', N'beni@gmail.com                ', N'0556778999', 1, 2)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (24, N'בנימין              ', N'7894as    ', N'בנימין    ', N'ישראל     ', N'beni@gmail.com                ', N'0556778999', 1, 2)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (25, N'בנימין              ', N'7894as    ', N'בנימין    ', N'ישראל     ', N'beni@gmail.com                ', N'0556778999', 1, 2)
GO
INSERT [dbo].[Users] ([UserId], [UserEnterance], [UserPassword], [UserFirstName], [UserLastName], [UserGmail], [UserPhone], [UsersCount], [UserAccessLevel]) VALUES (26, N'בנימין              ', N'123475    ', N'בנימין    ', N'ישראל     ', N'beni@gmail.com                ', N'0556789999', 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[AttractionStatus]  WITH CHECK ADD  CONSTRAINT [FK_AttractionStatus_Attraction] FOREIGN KEY([AttractionId])
REFERENCES [dbo].[Attraction] ([AttractionId])
GO
ALTER TABLE [dbo].[AttractionStatus] CHECK CONSTRAINT [FK_AttractionStatus_Attraction]
GO
ALTER TABLE [dbo].[AttractionStatus]  WITH CHECK ADD  CONSTRAINT [FK_AttractionStatus_Employee] FOREIGN KEY([EmployeeReportId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[AttractionStatus] CHECK CONSTRAINT [FK_AttractionStatus_Employee]
GO
ALTER TABLE [dbo].[AttractionStatus]  WITH CHECK ADD  CONSTRAINT [FK_AttractionStatus_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[AttractionStatus] CHECK CONSTRAINT [FK_AttractionStatus_Status]
GO
ALTER TABLE [dbo].[FavoriteAttraction]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteAttraction_Attraction] FOREIGN KEY([AttractionId])
REFERENCES [dbo].[Attraction] ([AttractionId])
GO
ALTER TABLE [dbo].[FavoriteAttraction] CHECK CONSTRAINT [FK_FavoriteAttraction_Attraction]
GO
ALTER TABLE [dbo].[FavoriteAttraction]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteAttraction_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[FavoriteAttraction] CHECK CONSTRAINT [FK_FavoriteAttraction_Users]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [dbo].[AccessLevel] ([AccessLevelId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_AccessLevel]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Attraction] FOREIGN KEY([AttractionId])
REFERENCES [dbo].[Attraction] ([AttractionId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Attraction]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Employee]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Users]
GO
ALTER TABLE [dbo].[QueuePerUser]  WITH CHECK ADD  CONSTRAINT [FK_QueuePerUser_Queues] FOREIGN KEY([QueueId])
REFERENCES [dbo].[Queues] ([QueueId])
GO
ALTER TABLE [dbo].[QueuePerUser] CHECK CONSTRAINT [FK_QueuePerUser_Queues]
GO
ALTER TABLE [dbo].[QueuePerUser]  WITH CHECK ADD  CONSTRAINT [FK_QueuePerUser_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[QueuePerUser] CHECK CONSTRAINT [FK_QueuePerUser_Users]
GO
ALTER TABLE [dbo].[Queues]  WITH CHECK ADD  CONSTRAINT [FK_Queues_Attraction] FOREIGN KEY([AttractionId])
REFERENCES [dbo].[Attraction] ([AttractionId])
GO
ALTER TABLE [dbo].[Queues] CHECK CONSTRAINT [FK_Queues_Attraction]
GO
ALTER TABLE [dbo].[Rate]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Attraction] FOREIGN KEY([AttractionId])
REFERENCES [dbo].[Attraction] ([AttractionId])
GO
ALTER TABLE [dbo].[Rate] CHECK CONSTRAINT [FK_Rate_Attraction]
GO
ALTER TABLE [dbo].[Rate]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Rate] CHECK CONSTRAINT [FK_Rate_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_AccessLevel] FOREIGN KEY([UserAccessLevel])
REFERENCES [dbo].[AccessLevel] ([AccessLevelId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_AccessLevel]
GO
