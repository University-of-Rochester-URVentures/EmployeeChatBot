CREATE TABLE [dbo].[Report](
	[Report_ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[EmployeeId] [int] NULL,
	[Fever] [bit] NULL,
	[Coughing] [bit] NULL,
	[Breathing] [bit] NULL,
	[SoreThroat] [bit] NULL,
	[BodyAches] [bit] NULL,
	[LossOfTasteSmell] [bit] NULL,
	[CreatedAt] [datetime2](2) NOT NULL,
	[CompletedAt] [datetime2](2) NULL
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[Report_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Report] ADD  CONSTRAINT [DF_Report_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO