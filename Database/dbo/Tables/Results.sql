CREATE TABLE [dbo].[Results] (
    [ResultID]   INT      IDENTITY (1, 1) NOT NULL,
    [UserID]     INT      NOT NULL,
    [QuestionID] INT      NOT NULL,
    [AnswerID]   INT      NOT NULL,
    [UpdatedAt]  DATETIME CONSTRAINT [DF_Results_UpdatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED ([ResultID] ASC),
    CONSTRAINT [FK_Results_Answers] FOREIGN KEY ([AnswerID]) REFERENCES [dbo].[Answers] ([AnswerID]),
    CONSTRAINT [FK_Results_Questions] FOREIGN KEY ([QuestionID]) REFERENCES [dbo].[Questions] ([QuestionID]),
    CONSTRAINT [FK_Results_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

