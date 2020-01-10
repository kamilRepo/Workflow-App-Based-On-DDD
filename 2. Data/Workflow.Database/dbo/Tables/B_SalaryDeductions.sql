CREATE TABLE [dbo].[B_SalaryDeductions] (
    [Id]                       INT            IDENTITY (1, 1) NOT NULL,
    [FromDate]                 DATETIME2 (7)  NULL,
    [ToDate]                   DATETIME       NULL,
    [SalaryDeductionsType]     INT            NULL,
    [Amount]                   FLOAT (53)     NULL,
    [ContractNumber]           NVARCHAR (255) NULL,
    [FirstInstallmentCapital]  FLOAT (53)     NULL,
    [FirstInstallmentInterest] FLOAT (53)     NULL,
    [MonthlyCycle]             FLOAT (53)     NULL,
    [RegistrationNumber]       NVARCHAR (255) NULL,
    [Status]                   INT            NULL,
    [C_Date]                   DATETIME       NULL,
    [M_Date]                   DATETIME       NULL,
    [Employee_id]              INT            NULL,
    [C_User_id]                INT            NULL,
    [M_User_id]                INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FKAD009B0858C6A50B] FOREIGN KEY ([Employee_id]) REFERENCES [dbo].[B_Employee] ([Id]),
    CONSTRAINT [FKAD009B08B8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FKAD009B08B857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

