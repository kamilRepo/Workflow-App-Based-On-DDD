CREATE TABLE [dbo].[B_GroupEmployee] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [Status]      INT      NULL,
    [C_Date]      DATETIME NULL,
    [M_Date]      DATETIME NULL,
    [Group_id]    INT      NULL,
    [Employee_id] INT      NULL,
    [C_User_id]   INT      NULL,
    [M_User_id]   INT      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FKCD728A6658C6A50B] FOREIGN KEY ([Employee_id]) REFERENCES [dbo].[B_Employee] ([Id]),
    CONSTRAINT [FKCD728A667E8AAA7B] FOREIGN KEY ([Group_id]) REFERENCES [dbo].[B_Group] ([Id]),
    CONSTRAINT [FKCD728A66B8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FKCD728A66B857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

