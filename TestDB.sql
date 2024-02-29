USE [test]
GO
/****** Object:  Table [dbo].[test_TB]    Script Date: 2/28/2024 9:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test_TB](
	[ID] [int] NOT NULL,
	[name] [nchar](10) NULL,
	[phone] [nchar](10) NULL,
 CONSTRAINT [PK_test_TB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test2_TB]    Script Date: 2/28/2024 9:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test2_TB](
	[id] [nchar](10) NULL,
	[nashdu] [nchar](10) NULL,
	[ndjsa] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test3_TB]    Script Date: 2/28/2024 9:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test3_TB](
	[id] [nchar](10) NULL,
	[mdkajsn] [nchar](10) NULL,
	[asjhduja] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test4_TB]    Script Date: 2/28/2024 9:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test4_TB](
	[id] [nchar](10) NULL,
	[mdkjasjdn] [int] NULL
) ON [PRIMARY]
GO
