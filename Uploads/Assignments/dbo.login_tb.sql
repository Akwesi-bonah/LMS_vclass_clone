CREATE TABLE [dbo].[login_tb] (
    [ID]        INT          IDENTITY (1, 1) NOT NULL,
    [Username]  VARCHAR (50) NOT NULL,
    [Password]  VARCHAR (50) NOT NULL,
    [Full_Name] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_login_tb] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_login_tb]
    ON [dbo].[login_tb]([ID] ASC);

