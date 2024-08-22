
GO
CREATE TRIGGER Products_INSERT_UPDATE
ON [dbo].[Table]
AFTER INSERT, UPDATE
AS
UPDATE [dbo].[Table]
SET cost = cost + cost * 0.38
WHERE Id = (SELECT Id FROM inserted)