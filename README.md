script para la creacion de la BD y SP, la tabla de pueden crear con el comando update-database

CREATE DATABASE [Jabil]
Go
Use Jabil
GO
CREATE PROCEDURE [dbo].[UpdateUser]
@Id INT,
@Name NVARCHAR(100),
@Age DECIMAL(18,2)
AS
BEGIN
    UPDATE Users
    SET Name = @Name, Age = @Age
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE [dbo].[DeleteUser]
@Id INT

AS
BEGIN
    Delete Users WHERE Id = @Id;
END;
GO
