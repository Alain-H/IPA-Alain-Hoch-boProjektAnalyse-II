CREATE TABLE [dbo].[PA_ProjAn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ADR_ID] [int] NOT NULL,
	[BelegID] [int] NOT NULL,
	[BelegTyp] [varchar](2) NOT NULL,
	[SSV_ID] [int] NOT NULL,
 CONSTRAINT [PK_PA_ProjAn] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PA_ProjAn] ADD  CONSTRAINT [DF_PA_ProjAn_ADR_ID]  DEFAULT ((0)) FOR [ADR_ID]
GO

ALTER TABLE [dbo].[PA_ProjAn] ADD  CONSTRAINT [DF_PA_ProjAn_BelegID]  DEFAULT ((0)) FOR [BelegID]
GO

ALTER TABLE [dbo].[PA_ProjAn] ADD  CONSTRAINT [DF_PA_ProjAn_BelegTyp]  DEFAULT ('') FOR [BelegTyp]
GO

ALTER TABLE [dbo].[PA_ProjAn] ADD  CONSTRAINT [DF_PA_ProjAn_SSV_ID]  DEFAULT ((0)) FOR [SSV_ID]
GO