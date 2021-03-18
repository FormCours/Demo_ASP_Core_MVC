CREATE PROCEDURE [dbo].[AddMember]
	@Pseudo NVARCHAR(50),
	@Email NVARCHAR(250),
	@Password NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	-- Génération du Salt du Member
	DECLARE @Salt NVARCHAR(100);
	SET @Salt = CONCAT(NEWID(),NEWID(),NEWID());

	-- Recuperation du Salt de la DB
	DECLARE @SaltDb NVARCHAR(1000);
	SET @SaltDb = [dbo].[GetDbSalt]();

	-- Hashage du mot de passe avec les salts
	DECLARE @Password_Hash BINARY(64);
	SET @Password_Hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @SaltDb, @Password, @Salt));

	-- Ajout du membre en DB avec le mot de passe hashé et le salt
	INSERT INTO [Member]([Pseudo], [Email], [Password], [Salt])
	 OUTPUT [inserted].Id_Member
	 VALUES (@Pseudo, @Email, @Password_Hash, @Salt);
END