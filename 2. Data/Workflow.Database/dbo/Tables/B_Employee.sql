﻿CREATE TABLE [dbo].[B_Employee] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]         NVARCHAR (255) NULL,
    [LastName]          NVARCHAR (255) NULL,
    [EmployeeNumber]    NVARCHAR (255) NULL,
    [PhoneNumber]       NVARCHAR (255) NULL,
    [Fax]               NVARCHAR (255) NULL,
    [MobilePhoneNumber] NVARCHAR (255) NULL,
    [Email]             NVARCHAR (255) NULL,
    [Pesel]             NVARCHAR (255) NULL,
    [Education]         NVARCHAR (255) NULL,
    [Sex]               INT            NULL,
    [TypeEmployee]      INT            NULL,
    [Date]              DATETIME       NULL,
    [Status]            INT            NULL,
    [C_Date]            DATETIME       NULL,
    [M_Date]            DATETIME       NULL,
    [User_id]           INT            NULL,
    [C_User_id]         INT            NULL,
    [M_User_id]         INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FKA9A8790F2AD212FB] FOREIGN KEY ([User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FKA9A8790FB8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FKA9A8790FB857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

