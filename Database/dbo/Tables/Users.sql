CREATE TABLE [dbo].[Users] (
    [UserID]     INT            IDENTITY (1, 1) NOT NULL,
    [LastName]   NVARCHAR (255) NOT NULL,
    [FirstName]  NVARCHAR (255) NOT NULL,
    [MiddleName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

