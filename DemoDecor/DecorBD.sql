USE [DecorDataBase]
GO
/****** Object:  Table [dbo].[ProductTable]    Script Date: 27.06.2023 10:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](50) NULL,
	[Price] [int] NOT NULL,
	[Discount] [int] NULL,
	[Quantity] [int] NULL,
	[Description] [varchar](200) NOT NULL,
	[Image] [varchar](50) NULL
) ON [PRIMARY]
GO
