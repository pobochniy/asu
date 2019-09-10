USE [asu]
GO

/****** Объект: Table [dbo].[Issue] Дата скрипта: 03.09.2019 17:54:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Issue] (
    [Id]                    BIGINT           IDENTITY (1, 1) NOT NULL,
    [Assignee]              UNIQUEIDENTIFIER NULL,
    [Reporter]              UNIQUEIDENTIFIER NOT NULL,
    [Summary]               NVARCHAR (MAX)   NULL,
    [Description]           NVARCHAR (MAX)   NULL,
    [Type]                  INT              NOT NULL,
    [Status]                INT              NOT NULL,
    [Priority]              INT              NOT NULL,
    [AssigneeEstimatedTime] DECIMAL (18, 2)  NULL,
    [ReporterEstimatedTime] DECIMAL (18, 2)  NULL,
    [CreateDate]            DATETIME2 (7)    NOT NULL,
    [DueDate]               DATETIME2 (7)    NULL,
    [EpicLink]              INT              NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Issue_Id]
    ON [dbo].[Issue]([Id] ASC);


GO
ALTER TABLE [dbo].[Issue]
    ADD CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED ([Id] ASC);


