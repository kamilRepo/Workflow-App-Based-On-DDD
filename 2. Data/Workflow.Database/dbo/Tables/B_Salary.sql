CREATE TABLE [dbo].[B_Salary] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [BaseSalary]         FLOAT (53)    NULL,
    [DiscretionaryBonus] FLOAT (53)    NULL,
    [MasterBonus]        FLOAT (53)    NULL,
    [Bonus]              FLOAT (53)    NULL,
    [Date]               DATETIME2 (7) NULL,
    [Status]             INT           NULL,
    [C_Date]             DATETIME      NULL,
    [M_Date]             DATETIME      NULL,
    [Employee_id]        INT           NULL,
    [C_User_id]          INT           NULL,
    [M_User_id]          INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FKE0D9478F58C6A50B] FOREIGN KEY ([Employee_id]) REFERENCES [dbo].[B_Employee] ([Id]),
    CONSTRAINT [FKE0D9478FB8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FKE0D9478FB857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

