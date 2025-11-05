
-- ================================================
-- Create Database: Library
-- ================================================
CREATE DATABASE Library
ON 
PRIMARY (
    NAME = Library_Data,
    FILENAME = 'C:\SQLData\Library_Data.mdf',  -- Change path as needed
    SIZE = 20MB,
    MAXSIZE = 200MB,
    FILEGROWTH = 10MB
)
LOG ON (
    NAME = Library_Log,
    FILENAME = 'C:\SQLData\Library_Log.ldf',  -- Change path as needed
    SIZE = 10MB,
    MAXSIZE = 100MB,
    FILEGROWTH = 5MB
);
GO

-- Switch context to Library database
USE Library;
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 11/4/2025 9:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[author_id] [int] NOT NULL,
	[author_name] [nvarchar](100) NULL,
	[country] [char](2) NULL,
	[address] [nvarchar](250) NULL,
	[phone] [nvarchar](20) NULL,
	[email] [nvarchar](200) NULL,
	[create_date] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 11/4/2025 9:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[book_id] [int] NOT NULL,
	[title] [nvarchar](100) NULL,
	[description] [nvarchar](250) NULL,
	[author_id] [int] NULL,
	[category_id] [int] NULL,
	[publisher_id] [int] NULL,
	[publish_date] [datetime] NULL,
	[ISBN] [nvarchar](20) NULL,
	[price] [decimal](18, 2) NULL,
	[create_date] [datetime] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/4/2025 9:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[category_id] [int] NOT NULL,
	[category_name] [nvarchar](100) NULL,
	[description] [nvarchar](250) NULL,
	[create_date] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 11/4/2025 9:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[country_id] [char](2) NOT NULL,
	[country_name] [nvarchar](100) NULL,
	[nationality] [nvarchar](100) NULL,
	[calling_code] [int] NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[country_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 11/4/2025 9:41:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[publisher_id] [int] NOT NULL,
	[publisher_name] [nvarchar](100) NULL,
	[address] [nvarchar](150) NULL,
	[phone] [nvarchar](20) NULL,
	[email] [nvarchar](200) NULL,
	[create_date] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[publisher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
