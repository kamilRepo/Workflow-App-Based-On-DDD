CREATE TABLE [dbo].[B_EmployeeMembershipCoefficients] (
    [Id]                    INT           IDENTITY (1, 1) NOT NULL,
    [Coefficient]           REAL          NULL,
    [FromDate]              DATETIME2 (7) NULL,
    [ToDate]                DATETIME      NULL,
    [Status]                INT           NULL,
    [C_Date]                DATETIME      NULL,
    [M_Date]                DATETIME      NULL,
    [Employee_id]           INT           NULL,
    [OrganizationalUnit_id] INT           NULL,
    [OrganizationalCell_id] INT           NULL,
    [Silo_id]               INT           NULL,
    [C_User_id]             INT           NULL,
    [M_User_id]             INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK7C177A7E2D8D6A45] FOREIGN KEY ([Silo_id]) REFERENCES [dbo].[B_Silo] ([Id]),
    CONSTRAINT [FK7C177A7E58C6A50B] FOREIGN KEY ([Employee_id]) REFERENCES [dbo].[B_Employee] ([Id]),
    CONSTRAINT [FK7C177A7E5EB02953] FOREIGN KEY ([OrganizationalCell_id]) REFERENCES [dbo].[B_OrganizationalCell] ([Id]),
    CONSTRAINT [FK7C177A7EB8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FK7C177A7EB857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FK7C177A7EBBB43D21] FOREIGN KEY ([OrganizationalUnit_id]) REFERENCES [dbo].[B_OrganizationalUnit] ([Id])
);

