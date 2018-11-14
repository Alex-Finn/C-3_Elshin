--INSERT INTO Email(Id, Value,
--Name) VALUES (10, 'value10', 'name10')

--update Email set Value = 'value8@mail.com' where Id = 8
--update Email set Value = 'value9@mail.com' where Id = 9
--update Email set Value = 'value10@mail.com' where Id = 10

select
*
from email

--CREATE TABLE [dbo].[Email] (
--[Id] int NOT NULL,
--[Value] NVARCHAR (MAX) NOT NULL,
--[Name] NVARCHAR (MAX) NOT NULL
--);
--ALTER TABLE [dbo].[Email]
--ADD CONSTRAINT PK_Email_Id PRIMARY KEY CLUSTERED (Id);