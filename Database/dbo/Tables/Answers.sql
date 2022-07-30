CREATE TABLE [dbo].[Answers] (
    [AnswerID]     INT             IDENTITY (1, 1) NOT NULL,
    [QuestionID]   INT             NOT NULL,
    [AnswerNumber] INT             NOT NULL,
    [AnswerText]   NVARCHAR (1000) NOT NULL,
    [IsCorrect]    BIT             NOT NULL,
    CONSTRAINT [PK_Answers_1] PRIMARY KEY CLUSTERED ([AnswerID] ASC),
    CONSTRAINT [FK_Answers_Questions] FOREIGN KEY ([QuestionID]) REFERENCES [dbo].[Questions] ([QuestionID])
);

