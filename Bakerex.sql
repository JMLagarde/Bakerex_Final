USE [master]
GO
/****** Object:  Database [BakerexCustomerSupportSystem]    Script Date: 25/03/2025 9:13:38 am ******/
CREATE DATABASE [BakerexCustomerSupportSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BakerexCustomerSupportSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BakerexCustomerSupportSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BakerexCustomerSupportSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BakerexCustomerSupportSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BakerexCustomerSupportSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET  MULTI_USER 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BakerexCustomerSupportSystem]
GO
/****** Object:  Table [dbo].[CustomerRequests]    Script Date: 25/03/2025 9:13:38 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerRequests](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](255) NULL,
	[IssueType] [nvarchar](100) NOT NULL,
	[Subject] [nvarchar](255) NOT NULL,
	[Description] [text] NOT NULL,
	[ProductDetails] [nvarchar](255) NULL,
	[PriorityLevel] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[Status] [varchar](50) NOT NULL,
	[Technician] [varchar](100) NULL,
	[Response] [text] NULL,
	[Schedule] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 25/03/2025 9:13:38 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
	[Role] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestStatusHistory]    Script Date: 25/03/2025 9:13:38 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestStatusHistory](
	[HistoryID] [int] IDENTITY(1,1) NOT NULL,
	[RequestID] [int] NULL,
	[Status] [varchar](50) NOT NULL,
	[Technician] [varchar](100) NULL,
	[UpdatedBy] [varchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
	[Response] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomerRequests] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CustomerRequests] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[RequestStatusHistory] ADD  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[RequestStatusHistory]  WITH CHECK ADD FOREIGN KEY([RequestID])
REFERENCES [dbo].[CustomerRequests] ([RequestID])
GO
USE [master]
GO
ALTER DATABASE [BakerexCustomerSupportSystem] SET  READ_WRITE 
GO
