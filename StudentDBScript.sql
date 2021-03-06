USE [master]
GO
/****** Object:  Database [StudentsDB]    Script Date: 7/15/2017 9:33:14 PM ******/
CREATE DATABASE [StudentsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StudentsDB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StudentsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StudentsDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StudentsDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentsDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StudentsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentsDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StudentsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentsDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentsDB] SET  MULTI_USER 
GO
ALTER DATABASE [StudentsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentsDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StudentsDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [StudentsDB]
GO
/****** Object:  Table [dbo].[tbl_students]    Script Date: 7/15/2017 9:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentId] [nvarchar](25) NULL,
	[firstname] [nvarchar](100) NULL,
	[lastname] [nvarchar](100) NULL,
	[birthdate] [datetime] NULL,
	[sex] [bit] NULL,
	[majorId] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_students] ON 

INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (1, N'SE62248', N'Tran', N'Vu', CAST(N'1997-02-10 00:00:00.000' AS DateTime), 1, N'SE')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (2, N'SE62249', N'Phan', N'Tri', CAST(N'1997-02-16 00:00:00.000' AS DateTime), 1, N'SE')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (3, N'SE62250', N'Pham', N'Khac', CAST(N'1997-10-10 00:00:00.000' AS DateTime), 1, N'SE')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (4, N'SE62251', N'Thien Nhi', N'Dam', CAST(N'1997-01-03 00:00:00.000' AS DateTime), 0, N'SE')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (6, N'SE62183', N'Bao', N'Nguyen Van', CAST(N'1997-07-16 00:00:00.000' AS DateTime), 1, N'SB')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (9, N'SE62184', N'Cam Ha', N'Nguyen', CAST(N'1997-01-09 00:00:00.000' AS DateTime), 0, N'GD')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (10, N'SE62485', N'Bao Ngoc', N'Dao', CAST(N'1996-04-05 00:00:00.000' AS DateTime), 0, N'SB')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (11, N'SB62589', N'Tuyet Nhung', N'Tran', CAST(N'1995-05-05 00:00:00.000' AS DateTime), 0, N'SB')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (12, N'SB62115', N'Thanh Thuy', N'Pham', CAST(N'1994-05-08 00:00:00.000' AS DateTime), 0, N'SB')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (13, N'SB68963', N'Thanh Tung', N'Duong', CAST(N'1995-10-10 00:00:00.000' AS DateTime), 1, N'SB')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (14, N'SB69966', N'Ngoc Ha', N'Ho', CAST(N'1996-08-08 00:00:00.000' AS DateTime), 0, N'SB')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (15, N'GD64040', N'Thanh Hang', N'Le', CAST(N'1994-06-06 00:00:00.000' AS DateTime), 0, N'GD')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (16, N'GD65234', N'Minh Di', N'Cao', CAST(N'1994-08-09 00:00:00.000' AS DateTime), 0, N'GD')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (17, N'GD65236', N'Tra My', N'Nguyen', CAST(N'1995-03-06 00:00:00.000' AS DateTime), 0, N'GD')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (18, N'GD69856', N'Hoang Thai', N'Duong', CAST(N'1997-05-10 00:00:00.000' AS DateTime), 1, N'GD')
INSERT [dbo].[tbl_students] ([id], [studentId], [firstname], [lastname], [birthdate], [sex], [majorId]) VALUES (20, N'GD123456', N'Ngoc Tram', N'Nguyen', CAST(N'2017-07-10 00:00:00.000' AS DateTime), 1, N'GD')
SET IDENTITY_INSERT [dbo].[tbl_students] OFF
USE [master]
GO
ALTER DATABASE [StudentsDB] SET  READ_WRITE 
GO
