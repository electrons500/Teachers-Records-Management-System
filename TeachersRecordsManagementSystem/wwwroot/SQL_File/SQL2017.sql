USE [master]
GO
/****** Object:  Database [trms]    Script Date: 9/27/2020 4:00:21 PM ******/
CREATE DATABASE [trms]

GO


USE [trms]
GO

CREATE TABLE [dbo].[Admin](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Othername] [nvarchar](100) NOT NULL,
	[Contact] [char](15) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 9/27/2020 4:00:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banks](
	[BankId] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 9/27/2020 4:00:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderId] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [char](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaritalStatus]    Script Date: 9/27/2020 4:00:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaritalStatus](
	[MaritalId] [int] IDENTITY(1,1) NOT NULL,
	[MaritalStatusName] [char](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 9/27/2020 4:00:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [char](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 9/27/2020 4:00:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TitleId] [int] NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Othernames] [nvarchar](150) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[GenderId] [int] NOT NULL,
	[Hometown] [nvarchar](100) NOT NULL,
	[Contact] [char](15) NULL,
	[MaritalId] [int] NOT NULL,
	[AcademicQualification] [nvarchar](100) NOT NULL,
	[ProfessionalQualification] [nvarchar](100) NOT NULL,
	[StaffId] [char](15) NOT NULL,
	[RegisteredNumber] [char](15) NULL,
	[SSFno] [nvarchar](50) NULL,
	[BankId] [int] NOT NULL,
	[AccountName] [nvarchar](100) NOT NULL,
	[FirstAppointmentDate] [date] NOT NULL,
	[StateId] [int] NOT NULL,
	[ImageName] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Title]    Script Date: 9/27/2020 4:00:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Title](
	[TitleId] [int] IDENTITY(1,1) NOT NULL,
	[TitleName] [nvarchar](10) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([AdminId], [Surname], [Othername], [Contact], [Email], [Username], [Password]) VALUES (1, N'Obeng', N'Ishmael', N'0546290555     ', N'electrons500@gmail.com', N'admin', N'21232f297a57a5a743894a0e4a801fc3')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Banks] ON 

INSERT [dbo].[Banks] ([BankId], [BankName]) VALUES (1, N'Absa')
INSERT [dbo].[Banks] ([BankId], [BankName]) VALUES (2, N'Ecobank')
INSERT [dbo].[Banks] ([BankId], [BankName]) VALUES (3, N'GCB')
INSERT [dbo].[Banks] ([BankId], [BankName]) VALUES (4, N'HFC Bank')
INSERT [dbo].[Banks] ([BankId], [BankName]) VALUES (5, N'Access Bank')
INSERT [dbo].[Banks] ([BankId], [BankName]) VALUES (6, N'Standard Chartered Bank')
SET IDENTITY_INSERT [dbo].[Banks] OFF
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([GenderId], [GenderName]) VALUES (1, N'Female    ')
INSERT [dbo].[Gender] ([GenderId], [GenderName]) VALUES (2, N'Male      ')
SET IDENTITY_INSERT [dbo].[Gender] OFF
SET IDENTITY_INSERT [dbo].[MaritalStatus] ON 

INSERT [dbo].[MaritalStatus] ([MaritalId], [MaritalStatusName]) VALUES (1, N'Single         ')
INSERT [dbo].[MaritalStatus] ([MaritalId], [MaritalStatusName]) VALUES (2, N'Married        ')
INSERT [dbo].[MaritalStatus] ([MaritalId], [MaritalStatusName]) VALUES (3, N'Divorced       ')
SET IDENTITY_INSERT [dbo].[MaritalStatus] OFF
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([StateId], [StateName]) VALUES (1, N'Active         ')
INSERT [dbo].[State] ([StateId], [StateName]) VALUES (2, N'Inactive       ')
INSERT [dbo].[State] ([StateId], [StateName]) VALUES (3, N'Transferred    ')
INSERT [dbo].[State] ([StateId], [StateName]) VALUES (4, N'Study Leave    ')
SET IDENTITY_INSERT [dbo].[State] OFF
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([TeacherId], [TitleId], [Surname], [Othernames], [BirthDate], [GenderId], [Hometown], [Contact], [MaritalId], [AcademicQualification], [ProfessionalQualification], [StaffId], [RegisteredNumber], [SSFno], [BankId], [AccountName], [FirstAppointmentDate], [StateId], [ImageName]) VALUES (1, 3, N'Obeng', N'Ishmael', CAST(N'2020-09-19' AS Date), 2, N'Obuasi', N'0546290555     ', 1, N'Wassce', N'DBE', N'1096578        ', N'1117/2014      ', N'HO787899087654', 3, N'67554478787665544', CAST(N'2020-09-19' AS Date), 4, N'9f77b77d-54a1-4b1f-b26b-4547d7172e18_admin.jpg')
INSERT [dbo].[Teachers] ([TeacherId], [TitleId], [Surname], [Othernames], [BirthDate], [GenderId], [Hometown], [Contact], [MaritalId], [AcademicQualification], [ProfessionalQualification], [StaffId], [RegisteredNumber], [SSFno], [BankId], [AccountName], [FirstAppointmentDate], [StateId], [ImageName]) VALUES (2, 5, N'Owusu', N'Naana Monicia', CAST(N'1994-06-23' AS Date), 1, N'Accra', N'0206593241     ', 2, N'BSc. Computer Science,MSc Cybersecurity', N'BEd Information Technology', N'778956         ', N'45662/17       ', N'GO08126789907546', 1, N'235678906765489', CAST(N'2017-09-01' AS Date), 1, N'5cebb381-48de-43b7-b243-50a45cffe233_5.jpg')
INSERT [dbo].[Teachers] ([TeacherId], [TitleId], [Surname], [Othernames], [BirthDate], [GenderId], [Hometown], [Contact], [MaritalId], [AcademicQualification], [ProfessionalQualification], [StaffId], [RegisteredNumber], [SSFno], [BankId], [AccountName], [FirstAppointmentDate], [StateId], [ImageName]) VALUES (3, 1, N'Smith', N'Michael', CAST(N'1975-02-18' AS Date), 2, N'Cape Coast', N'02468945692    ', 2, N'BA History', N'MEd Business Adminstration', N'103965856      ', N'88395/10       ', N'E05897996787655', 6, N'89356869654458', CAST(N'2010-10-01' AS Date), 3, N'cff719da-4272-4cd4-920e-8079260086a3_teacher2.jpg')
INSERT [dbo].[Teachers] ([TeacherId], [TitleId], [Surname], [Othernames], [BirthDate], [GenderId], [Hometown], [Contact], [MaritalId], [AcademicQualification], [ProfessionalQualification], [StaffId], [RegisteredNumber], [SSFno], [BankId], [AccountName], [FirstAppointmentDate], [StateId], [ImageName]) VALUES (4, 3, N'Edurance', N'Francis', CAST(N'1967-05-12' AS Date), 2, N'Kumasi', N'0563597854     ', 3, N'BSc. I.T', N'MEd Information Technology', N'5678968        ', N'152564/04      ', N'W060876656798', 2, N'72569699665844', CAST(N'2004-01-07' AS Date), 1, N'088262e7-b037-4191-8794-a7b5e9dd48c4_teacher1.jpg')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
SET IDENTITY_INSERT [dbo].[Title] ON 

INSERT [dbo].[Title] ([TitleId], [TitleName]) VALUES (1, N'Dr')
INSERT [dbo].[Title] ([TitleId], [TitleName]) VALUES (2, N'Prof')
INSERT [dbo].[Title] ([TitleId], [TitleName]) VALUES (3, N'Mr')
INSERT [dbo].[Title] ([TitleId], [TitleName]) VALUES (4, N'Mrs')
INSERT [dbo].[Title] ([TitleId], [TitleName]) VALUES (5, N'Miss')
SET IDENTITY_INSERT [dbo].[Title] OFF
/****** Object:  Index [PK_Admin]    Script Date: 9/27/2020 4:00:22 PM ******/
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [PK_Admin] PRIMARY KEY NONCLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_Banks]    Script Date: 9/27/2020 4:00:22 PM ******/
ALTER TABLE [dbo].[Banks] ADD  CONSTRAINT [PK_Banks] PRIMARY KEY NONCLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_Gender]    Script Date: 9/27/2020 4:00:22 PM ******/
ALTER TABLE [dbo].[Gender] ADD  CONSTRAINT [PK_Gender] PRIMARY KEY NONCLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_MaritalStatus]    Script Date: 9/27/2020 4:00:22 PM ******/
ALTER TABLE [dbo].[MaritalStatus] ADD  CONSTRAINT [PK_MaritalStatus] PRIMARY KEY NONCLUSTERED 
(
	[MaritalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_State]    Script Date: 9/27/2020 4:00:22 PM ******/
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [PK_State] PRIMARY KEY NONCLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_Teachers]    Script Date: 9/27/2020 4:00:22 PM ******/
ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [PK_Teachers] PRIMARY KEY NONCLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_Title]    Script Date: 9/27/2020 4:00:22 PM ******/
ALTER TABLE [dbo].[Title] ADD  CONSTRAINT [PK_Title] PRIMARY KEY NONCLUSTERED 
(
	[TitleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Banks_Teachers] FOREIGN KEY([BankId])
REFERENCES [dbo].[Banks] ([BankId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Banks_Teachers]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Gender_Teachers] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([GenderId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Gender_Teachers]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_MaritalStatus_Teachers] FOREIGN KEY([MaritalId])
REFERENCES [dbo].[MaritalStatus] ([MaritalId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_MaritalStatus_Teachers]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_State_Teachers] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_State_Teachers]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Title_Teachers] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Title] ([TitleId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Title_Teachers]
GO
