create database DocumentManager
go
USE DocumentManager
GO


CREATE TABLE [dbo].[Documento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Usuario] [nvarchar](max) NULL,
	[DataUpload] [datetime] NOT NULL,
	[DataUltimoAcesso] [datetime] NOT NULL,
	[TamanhoArquivo] [decimal](18, 2) NOT NULL,
	[Arquivo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Documento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO