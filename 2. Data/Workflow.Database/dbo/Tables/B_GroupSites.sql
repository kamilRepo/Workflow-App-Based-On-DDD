CREATE TABLE [dbo].[B_GroupSites] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [Site]      UNIQUEIDENTIFIER NULL,
    [PartPage]  UNIQUEIDENTIFIER NULL,
    [Status]    INT              NULL,
    [C_Date]    DATETIME         NULL,
    [M_Date]    DATETIME         NULL,
    [Group_id]  INT              NULL,
    [C_User_id] INT              NULL,
    [M_User_id] INT              NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK72F774807E8AAA7B] FOREIGN KEY ([Group_id]) REFERENCES [dbo].[B_Group] ([Id]),
    CONSTRAINT [FK72F77480B8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FK72F77480B857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

