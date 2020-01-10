CREATE TABLE [dbo].[B_EmployeeAddress] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Street]           NVARCHAR (255) NULL,
    [BuildingNo]       NVARCHAR (255) NULL,
    [LocalNo]          NVARCHAR (255) NULL,
    [PostalCode]       NVARCHAR (255) NULL,
    [City]             NVARCHAR (255) NULL,
    [PostOffice]       NVARCHAR (255) NULL,
    [IsCorrespondence] BIT            NULL,
    [Status]           INT            NULL,
    [C_Date]           DATETIME       NULL,
    [M_Date]           DATETIME       NULL,
    [Employee_id]      INT            NULL,
    [C_User_id]        INT            NULL,
    [M_User_id]        INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FKA8D4D6A558C6A50B] FOREIGN KEY ([Employee_id]) REFERENCES [dbo].[B_Employee] ([Id]),
    CONSTRAINT [FKA8D4D6A5B8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FKA8D4D6A5B857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

