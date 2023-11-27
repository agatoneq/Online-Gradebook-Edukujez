USE [EdukuJez]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 21.11.2023 00:29:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ID_Group] [int] NULL,
	[Day] [varchar](20) NULL,
	[ID_Teacher] [int] NULL,
	[ID_Class] [int] IDENTITY(1,1) NOT NULL,
	[ID_Subject] [int] NULL,
	[Hour] [varchar](20) NULL,
 CONSTRAINT [PK__Classes__D7CF744CB48CAA89] PRIMARY KEY CLUSTERED 
(
	[ID_Class] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 21.11.2023 00:29:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[ID_Student] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [int] NULL,
	[Grade_Weight] [int] NULL,
	[ID_Subject] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 21.11.2023 00:29:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[ID_Group] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Parent_Group] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission_List]    Script Date: 21.11.2023 00:29:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission_List](
	[ID_Group] [int] NOT NULL,
	[ID_Permission] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Group] ASC,
	[ID_Permission] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 21.11.2023 00:29:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Type] [varchar](255) NULL,
	[ID_Permission] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Permission] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 21.11.2023 00:29:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[ID_Subject] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Subject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Group]    Script Date: 21.11.2023 00:29:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Group](
	[ID_User] [int] NOT NULL,
	[ID_Group] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC,
	[ID_Group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21.11.2023 00:29:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Surname] [varchar](255) NOT NULL,
	[Group] [varchar](255) NULL,
	[Login] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Subjects] FOREIGN KEY([ID_Subject])
REFERENCES [dbo].[Subjects] ([ID_Subject])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Subjects]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Users] FOREIGN KEY([ID_Student])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Users]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Groups] FOREIGN KEY([Parent_Group])
REFERENCES [dbo].[Groups] ([ID_Group])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Groups]
GO
ALTER TABLE [dbo].[Permission_List]  WITH CHECK ADD  CONSTRAINT [FK_Permission_List_Groups] FOREIGN KEY([ID_Group])
REFERENCES [dbo].[Groups] ([ID_Group])
GO
ALTER TABLE [dbo].[Permission_List] CHECK CONSTRAINT [FK_Permission_List_Groups]
GO
ALTER TABLE [dbo].[Permission_List]  WITH CHECK ADD  CONSTRAINT [FK_Permission_List_Permissions] FOREIGN KEY([ID_Permission])
REFERENCES [dbo].[Permissions] ([ID_Permission])
GO
ALTER TABLE [dbo].[Permission_List] CHECK CONSTRAINT [FK_Permission_List_Permissions]
GO
ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_Groups] FOREIGN KEY([ID_Group])
REFERENCES [dbo].[Groups] ([ID_Group])
GO
ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_Groups]
GO
ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_Users] FOREIGN KEY([ID_User])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_Users]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [CK__Classes__Day__00200768] CHECK  (([Day]='piątek' OR [Day]='czwartek' OR [Day]='środa' OR [Day]='wtorek' OR [Day]='poniedziałek'))
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [CheckDay]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [CheckPrzedzialCzasu] CHECK  (([Hour]='14:25 – 15:10' OR [Hour]='13:35 – 14:20' OR [Hour]='12:45 – 13:30' OR [Hour]='11:40 – 12:25' OR [Hour]='10:35 – 11:20' OR [Hour]='9:45 – 10:30' OR [Hour]='8:50 – 9:35' OR [Hour]='8:00 – 8:45'))
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [CheckPrzedzialCzasu]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [Day] CHECK  (([day]='Piatek' OR [day]='Czwartek' OR [day]='Sroda' OR [day]='Wtorek' OR [day]='Poniedzialek'))
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [Day]
GO
