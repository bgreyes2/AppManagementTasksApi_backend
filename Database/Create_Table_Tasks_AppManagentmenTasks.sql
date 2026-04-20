USE [AppManagementTasks]
GO

/****** Object:  Table [dbo].[Tasks]    Script Date: 20/04/2026 7:06:34 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tasks](
	[id_task] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](200) NOT NULL,
	[description] [nvarchar](max) NULL,
	[status] [nvarchar](20) NOT NULL,
	[users_id] [int] NOT NULL,
	[create_date] [datetime2](7) NULL,
	[additional_data] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_task] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (getdate()) FOR [create_date]
GO

ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Users] FOREIGN KEY([users_id])
REFERENCES [dbo].[Users] ([id_user])
GO

ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Users]
GO

ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [CK_Task_Json] CHECK  (([additional_data] IS NULL OR isjson([additional_data])=(1)))
GO

ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [CK_Task_Json]
GO

ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [CK_Task_Status] CHECK  (([Status]='Done' OR [Status]='InProgress' OR [Status]='Pending'))
GO

ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [CK_Task_Status]
GO


