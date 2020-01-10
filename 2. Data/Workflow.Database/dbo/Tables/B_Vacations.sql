CREATE TABLE [dbo].[B_Vacations] (
    [Id]                     INT      IDENTITY (1, 1) NOT NULL,
    [HolidaysDue]            INT      NULL,
    [HolidaysCalculated]     INT      NULL,
    [HolidaysUnderpaid]      INT      NULL,
    [HolidaysUsed]           INT      NULL,
    [HolidaysRehabilitation] INT      NULL,
    [RemainedUnused]         INT      NULL,
    [Art188KP]               INT      NULL,
    [Status]                 INT      NULL,
    [C_Date]                 DATETIME NULL,
    [M_Date]                 DATETIME NULL,
    [Employee_id]            INT      NULL,
    [C_User_id]              INT      NULL,
    [M_User_id]              INT      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK23F08A4858C6A50B] FOREIGN KEY ([Employee_id]) REFERENCES [dbo].[B_Employee] ([Id]),
    CONSTRAINT [FK23F08A48B8579BD2] FOREIGN KEY ([M_User_id]) REFERENCES [dbo].[B_User] ([Id]),
    CONSTRAINT [FK23F08A48B857B964] FOREIGN KEY ([C_User_id]) REFERENCES [dbo].[B_User] ([Id])
);

