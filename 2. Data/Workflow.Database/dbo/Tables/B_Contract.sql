CREATE TABLE [dbo].[B_Contract] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [DimensionTime] REAL           NULL,
    [FromDate]      DATETIME2 (7)  NULL,
    [ToDate]        DATETIME2 (7)  NULL,
    [DismissDate]   DATETIME2 (7)  NULL,
    [AnnexDate]     DATETIME2 (7)  NULL,
    [TypeContract]  NVARCHAR (255) NULL,
    [Salary]        REAL           NULL,
    [Status]        INT            NULL,
    [C_Date]        DATETIME       NULL,
    [M_Date]        DATETIME       NULL,
    [Employee_id]   INT            NULL,
    [C_User_id]     INT            NULL,
    [M_User_id]     INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK37C766858C6A50B] FOREIGN KEY ([Employee_id]) REFERENCES [dbo].[B_Employee] ([Id]),
    CONSTRAINT [FK37C7668B8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FK37C7668B857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

