CREATE TABLE [dbo].[B_Inspection] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Entitlement] NVARCHAR (255) NULL,
    [Comments]    NVARCHAR (255) NULL,
    [FromDate]    DATETIME2 (7)  NULL,
    [ToDate]      DATETIME       NULL,
    [Status]      INT            NULL,
    [C_Date]      DATETIME       NULL,
    [M_Date]      DATETIME       NULL,
    [Employee_id] INT            NULL,
    [C_User_id]   INT            NULL,
    [M_User_id]   INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK5DF3A84758C6A50B] FOREIGN KEY ([Employee_id]) REFERENCES [dbo].[B_Employee] ([Id]),
    CONSTRAINT [FK5DF3A847B8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FK5DF3A847B857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

