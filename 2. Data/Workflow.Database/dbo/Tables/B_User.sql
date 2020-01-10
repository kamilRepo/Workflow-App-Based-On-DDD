CREATE TABLE [dbo].[B_User] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Login]     NVARCHAR (255) NULL,
    [Status]    INT            NULL,
    [C_Date]    DATETIME       NULL,
    [M_Date]    DATETIME       NULL,
    [C_User_id] INT            NULL,
    [M_User_id] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK2663A098B8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FK2663A098B857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [UNIQUE_Login] UNIQUE NONCLUSTERED ([Login] ASC)
);

