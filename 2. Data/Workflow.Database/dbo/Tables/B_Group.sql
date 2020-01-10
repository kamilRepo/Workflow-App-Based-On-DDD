CREATE TABLE [dbo].[B_Group] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (255) NULL,
    [Description] NVARCHAR (255) NULL,
    [Preview]     BIT            NULL,
    [Edit]        BIT            NULL,
    [Status]      INT            NULL,
    [C_Date]      DATETIME       NULL,
    [M_Date]      DATETIME       NULL,
    [Group_id]    INT            NULL,
    [C_User_id]   INT            NULL,
    [M_User_id]   INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK7DA86A927E8AAA7B] FOREIGN KEY ([Group_id]) REFERENCES [dbo].[B_Group] ([Id]),
    CONSTRAINT [FK7DA86A92B8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FK7DA86A92B857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

