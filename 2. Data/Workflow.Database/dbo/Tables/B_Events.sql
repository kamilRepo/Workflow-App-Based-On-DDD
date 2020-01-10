CREATE TABLE [dbo].[B_Events] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Version]      DATETIME       NOT NULL,
    [EventType]    INT            NULL,
    [ObjectEvents] INT            NULL,
    [TableName]    NVARCHAR (255) NULL,
    [StateBefore]  INT            NULL,
    [StateAfter]   INT            NULL,
    [UserIP]       NVARCHAR (255) NULL,
    [Status]       INT            NULL,
    [C_Date]       DATETIME       NULL,
    [M_Date]       DATETIME       NULL,
    [C_User_id]    INT            NULL,
    [M_User_id]    INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK6E563ABAB8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FK6E563ABAB857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

