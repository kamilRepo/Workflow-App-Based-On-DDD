CREATE TABLE [dbo].[B_OrganizationalUnit] (
    [Id]                           INT            IDENTITY (1, 1) NOT NULL,
    [Name]                         NVARCHAR (255) NULL,
    [Code]                         NVARCHAR (255) NULL,
    [Status]                       INT            NULL,
    [C_Date]                       DATETIME       NULL,
    [M_Date]                       DATETIME       NULL,
    [ManagerOrganizationalUnit_id] INT            NULL,
    [C_User_id]                    INT            NULL,
    [M_User_id]                    INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK98AD6FCB5089604B] FOREIGN KEY ([ManagerOrganizationalUnit_id]) REFERENCES [dbo].[B_Employee] ([Id]),
    CONSTRAINT [FK98AD6FCBB8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FK98AD6FCBB857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

