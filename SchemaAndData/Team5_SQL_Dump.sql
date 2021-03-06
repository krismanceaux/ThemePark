USE [ThemeParkdb]
GO
/****** Object:  Schema [ThemePark]    Script Date: 4/23/2019 6:37:33 PM ******/
CREATE SCHEMA [ThemePark]
GO
/****** Object:  Table [ThemePark].[ADMITTED_BY]    Script Date: 4/23/2019 6:37:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[ADMITTED_BY](
	[TicketID] [bigint] NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[AdmissionsDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[Concession]    Script Date: 4/23/2019 6:37:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[Concession](
	[ItemName] [nvarchar](15) NOT NULL,
	[ItemPrice] [smallmoney] NULL,
	[ItemDescription] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[Department]    Script Date: 4/23/2019 6:37:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[Department](
	[DepartmentID] [bigint] IDENTITY(100000,1) NOT NULL,
	[DName] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[DependentPassHolder]    Script Date: 4/23/2019 6:37:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[DependentPassHolder](
	[DepID] [bigint] IDENTITY(100000,1) NOT NULL,
	[FirstName] [nvarchar](15) NULL,
	[LastName] [nvarchar](15) NULL,
	[MiddleName] [nvarchar](15) NULL,
	[TicketNumber] [bigint] NULL,
	[SPH_ID] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[DepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[EmployeeLogin]    Script Date: 4/23/2019 6:37:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[EmployeeLogin](
	[LoginEmail] [nvarchar](40) NOT NULL,
	[Pswd] [nvarchar](20) NULL,
	[EmployeeID] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoginEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[MaintCode]    Script Date: 4/23/2019 6:37:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[MaintCode](
	[MaintCode] [int] IDENTITY(1,1) NOT NULL,
	[MaintType] [nvarchar](20) NULL,
 CONSTRAINT [PK__MaintCod__F74AADD826E8B96F] PRIMARY KEY CLUSTERED 
(
	[MaintCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[Maintenance]    Script Date: 4/23/2019 6:37:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[Maintenance](
	[MaintenanceID] [bigint] IDENTITY(100000,1) NOT NULL,
	[MaintDescription] [nvarchar](200) NULL,
	[CorrectiveAction] [nvarchar](100) NULL,
	[DateAdded] [date] NULL,
	[DateFixed] [date] NULL,
	[MaintCode] [int] NULL,
	[RideID] [bigint] NULL,
 CONSTRAINT [PK__Maintena__E60542B544B7941C] PRIMARY KEY CLUSTERED 
(
	[MaintenanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[MANAGED_BY]    Script Date: 4/23/2019 6:37:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[MANAGED_BY](
	[EmployeeID] [bigint] NOT NULL,
	[DepartmentID] [bigint] NOT NULL,
	[StartDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[ParkEmployee]    Script Date: 4/23/2019 6:37:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[ParkEmployee](
	[EmployeeID] [bigint] IDENTITY(100000,1) NOT NULL,
	[FirstName] [nvarchar](15) NULL,
	[MiddleName] [nvarchar](15) NULL,
	[LastName] [nvarchar](15) NULL,
	[StreetAddress] [nvarchar](50) NULL,
	[State] [nvarchar](20) NULL,
	[City] [nvarchar](20) NULL,
	[ZipCode] [nvarchar](5) NULL,
	[PhoneNumber] [nvarchar](12) NULL,
	[DateOfBirth] [date] NULL,
	[Sex] [nchar](1) NULL,
	[JobTitle] [nvarchar](20) NULL,
	[DepartmentID] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[PERFORMED_BY]    Script Date: 4/23/2019 6:37:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[PERFORMED_BY](
	[MaintenanceID] [bigint] NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[ManHours] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaintenanceID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[PERMITS]    Script Date: 4/23/2019 6:37:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[PERMITS](
	[RideID] [bigint] NOT NULL,
	[TicketNumber] [bigint] NOT NULL,
	[PTimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ThemePark.PERMITS] PRIMARY KEY CLUSTERED 
(
	[RideID] ASC,
	[TicketNumber] ASC,
	[PTimeStamp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[Ride]    Script Date: 4/23/2019 6:37:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[Ride](
	[RideID] [bigint] IDENTITY(100000,1) NOT NULL,
	[RideName] [nvarchar](20) NULL,
	[RideDiscription] [nvarchar](200) NULL,
	[RideLocation] [nvarchar](20) NULL,
	[RideCapacity] [int] NULL,
	[RideStatus] [int] NULL,
 CONSTRAINT [PK__Ride__C5B8C414A52B3259] PRIMARY KEY CLUSTERED 
(
	[RideID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[RideStatus]    Script Date: 4/23/2019 6:37:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[RideStatus](
	[RideStatus] [int] IDENTITY(1,1) NOT NULL,
	[StatusDescription] [nvarchar](20) NULL,
 CONSTRAINT [PK_ThemePark.RideStatus] PRIMARY KEY CLUSTERED 
(
	[RideStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[SeasonPassHolder]    Script Date: 4/23/2019 6:37:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[SeasonPassHolder](
	[SPH_ID] [bigint] IDENTITY(100000,1) NOT NULL,
	[StreetAddress] [nvarchar](30) NULL,
	[CityOfAddress] [nvarchar](15) NULL,
	[StateOfAddress] [nvarchar](15) NULL,
	[ZipCode] [nvarchar](5) NULL,
	[FirstName] [nvarchar](15) NULL,
	[LastName] [nvarchar](15) NULL,
	[MiddleName] [nvarchar](15) NULL,
	[TicketNumber] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[SPH_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[SOLD_BY]    Script Date: 4/23/2019 6:37:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[SOLD_BY](
	[ItemName] [nvarchar](15) NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[DateSold] [datetime] NOT NULL,
 CONSTRAINT [PK__SOLD_BY__49EE7709997D2D53] PRIMARY KEY CLUSTERED 
(
	[ItemName] ASC,
	[EmployeeID] ASC,
	[DateSold] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[SPHLogin]    Script Date: 4/23/2019 6:37:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[SPHLogin](
	[LoginEmail] [nvarchar](40) NULL,
	[Pswd] [nvarchar](20) NULL,
	[SPH_ID] [bigint] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ThemePark.SPHLogin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[TENDED_BY]    Script Date: 4/23/2019 6:37:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[TENDED_BY](
	[RideID] [bigint] NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[DateTended] [date] NOT NULL,
 CONSTRAINT [PK_ThemePark.TENDED_BY] PRIMARY KEY CLUSTERED 
(
	[RideID] ASC,
	[EmployeeID] ASC,
	[DateTended] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[Ticket]    Script Date: 4/23/2019 6:37:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[Ticket](
	[TicketNumber] [bigint] IDENTITY(100000,1) NOT NULL,
	[Price] [smallmoney] NULL,
	[DateOfPurchase] [date] NULL,
	[TicketCode] [int] NULL,
 CONSTRAINT [PK__Ticket__CBED06DB34233F76] PRIMARY KEY CLUSTERED 
(
	[TicketNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ThemePark].[TicketCode]    Script Date: 4/23/2019 6:37:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThemePark].[TicketCode](
	[TicketCode] [int] IDENTITY(1,1) NOT NULL,
	[TicketType] [nvarchar](20) NULL,
 CONSTRAINT [PK__TicketCo__598CF7A26CCA441E] PRIMARY KEY CLUSTERED 
(
	[TicketCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [ThemePark].[ADMITTED_BY]  WITH CHECK ADD  CONSTRAINT [FK__ADMIMTTED__Ticke__3A6CA48E] FOREIGN KEY([TicketID])
REFERENCES [ThemePark].[Ticket] ([TicketNumber])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[ADMITTED_BY] CHECK CONSTRAINT [FK__ADMIMTTED__Ticke__3A6CA48E]
GO
ALTER TABLE [ThemePark].[ADMITTED_BY]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [ThemePark].[ParkEmployee] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[DependentPassHolder]  WITH CHECK ADD FOREIGN KEY([SPH_ID])
REFERENCES [ThemePark].[SeasonPassHolder] ([SPH_ID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[DependentPassHolder]  WITH CHECK ADD  CONSTRAINT [FK__Dependent__Ticke__4301EA8F] FOREIGN KEY([TicketNumber])
REFERENCES [ThemePark].[Ticket] ([TicketNumber])
GO
ALTER TABLE [ThemePark].[DependentPassHolder] CHECK CONSTRAINT [FK__Dependent__Ticke__4301EA8F]
GO
ALTER TABLE [ThemePark].[EmployeeLogin]  WITH NOCHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [ThemePark].[ParkEmployee] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[Maintenance]  WITH NOCHECK ADD  CONSTRAINT [FK__Maintenan__Maint__30E33A54] FOREIGN KEY([MaintCode])
REFERENCES [ThemePark].[MaintCode] ([MaintCode])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [ThemePark].[Maintenance] CHECK CONSTRAINT [FK__Maintenan__Maint__30E33A54]
GO
ALTER TABLE [ThemePark].[Maintenance]  WITH NOCHECK ADD  CONSTRAINT [FK__Maintenan__RideI__31D75E8D] FOREIGN KEY([RideID])
REFERENCES [ThemePark].[Ride] ([RideID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[Maintenance] CHECK CONSTRAINT [FK__Maintenan__RideI__31D75E8D]
GO
ALTER TABLE [ThemePark].[MANAGED_BY]  WITH NOCHECK ADD FOREIGN KEY([DepartmentID])
REFERENCES [ThemePark].[Department] ([DepartmentID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[MANAGED_BY]  WITH NOCHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [ThemePark].[ParkEmployee] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[ParkEmployee]  WITH NOCHECK ADD FOREIGN KEY([DepartmentID])
REFERENCES [ThemePark].[Department] ([DepartmentID])
ON DELETE SET NULL
GO
ALTER TABLE [ThemePark].[PERFORMED_BY]  WITH NOCHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [ThemePark].[ParkEmployee] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[PERFORMED_BY]  WITH NOCHECK ADD  CONSTRAINT [FK__PERFORMED__Maint__2EFAF1E2] FOREIGN KEY([MaintenanceID])
REFERENCES [ThemePark].[Maintenance] ([MaintenanceID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[PERFORMED_BY] CHECK CONSTRAINT [FK__PERFORMED__Maint__2EFAF1E2]
GO
ALTER TABLE [ThemePark].[PERMITS]  WITH CHECK ADD  CONSTRAINT [FK__PERMITS__RideID__38845C1C] FOREIGN KEY([RideID])
REFERENCES [ThemePark].[Ride] ([RideID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[PERMITS] CHECK CONSTRAINT [FK__PERMITS__RideID__38845C1C]
GO
ALTER TABLE [ThemePark].[PERMITS]  WITH CHECK ADD  CONSTRAINT [FK__PERMITS__TicketN__39788055] FOREIGN KEY([TicketNumber])
REFERENCES [ThemePark].[Ticket] ([TicketNumber])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[PERMITS] CHECK CONSTRAINT [FK__PERMITS__TicketN__39788055]
GO
ALTER TABLE [ThemePark].[Ride]  WITH CHECK ADD  CONSTRAINT [FK_ThemePark.Ride_ThemePark.RideStatus_RideStatus] FOREIGN KEY([RideStatus])
REFERENCES [ThemePark].[RideStatus] ([RideStatus])
GO
ALTER TABLE [ThemePark].[Ride] CHECK CONSTRAINT [FK_ThemePark.Ride_ThemePark.RideStatus_RideStatus]
GO
ALTER TABLE [ThemePark].[SeasonPassHolder]  WITH CHECK ADD  CONSTRAINT [FK__SeasonPas__Ticke__33BFA6FF] FOREIGN KEY([TicketNumber])
REFERENCES [ThemePark].[Ticket] ([TicketNumber])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[SeasonPassHolder] CHECK CONSTRAINT [FK__SeasonPas__Ticke__33BFA6FF]
GO
ALTER TABLE [ThemePark].[SOLD_BY]  WITH CHECK ADD  CONSTRAINT [FK__SOLD_BY__Employe__7A672E12] FOREIGN KEY([EmployeeID])
REFERENCES [ThemePark].[ParkEmployee] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[SOLD_BY] CHECK CONSTRAINT [FK__SOLD_BY__Employe__7A672E12]
GO
ALTER TABLE [ThemePark].[SOLD_BY]  WITH CHECK ADD  CONSTRAINT [FK__SOLD_BY__ItemNam__7B5B524B] FOREIGN KEY([ItemName])
REFERENCES [ThemePark].[Concession] ([ItemName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[SOLD_BY] CHECK CONSTRAINT [FK__SOLD_BY__ItemNam__7B5B524B]
GO
ALTER TABLE [ThemePark].[SPHLogin]  WITH CHECK ADD FOREIGN KEY([SPH_ID])
REFERENCES [ThemePark].[SeasonPassHolder] ([SPH_ID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[TENDED_BY]  WITH CHECK ADD  CONSTRAINT [FK__TENDED_BY__Emplo__7D439ABD] FOREIGN KEY([EmployeeID])
REFERENCES [ThemePark].[ParkEmployee] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[TENDED_BY] CHECK CONSTRAINT [FK__TENDED_BY__Emplo__7D439ABD]
GO
ALTER TABLE [ThemePark].[TENDED_BY]  WITH CHECK ADD  CONSTRAINT [FK__TENDED_BY__RideI__369C13AA] FOREIGN KEY([RideID])
REFERENCES [ThemePark].[Ride] ([RideID])
ON DELETE CASCADE
GO
ALTER TABLE [ThemePark].[TENDED_BY] CHECK CONSTRAINT [FK__TENDED_BY__RideI__369C13AA]
GO
ALTER TABLE [ThemePark].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK__Ticket__TicketCo__32CB82C6] FOREIGN KEY([TicketCode])
REFERENCES [ThemePark].[TicketCode] ([TicketCode])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [ThemePark].[Ticket] CHECK CONSTRAINT [FK__Ticket__TicketCo__32CB82C6]
GO
