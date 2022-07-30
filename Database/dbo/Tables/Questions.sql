CREATE TABLE [dbo].[Questions] (
    [QuestionID]     INT             IDENTITY (1, 1) NOT NULL,
    [QuestionNumber] INT             NOT NULL,
    [QuestionText]   NVARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([QuestionID] ASC)
);

