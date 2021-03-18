CREATE PROCEDURE [dbo].[LoginMember]
	@Email NVARCHAR(250),
	@Password NVARCHAR(50)
AS
BEGIN
	DECLARE @Salt NVARCHAR(100);
	
	SELECT @Salt = Salt 
	 FROM [dbo].[Member] 
	 WHERE [Email] LIKE @Email;

	IF @Salt IS NOT NULL 
	BEGIN
		-- Recuperation du Salt de la DB
		DECLARE @SaltDb NVARCHAR(1000);
		SET @SaltDb = [dbo].[GetDbSalt]();

		-- Hashage du mot de passe avec les salts
		DECLARE @Password_Hash BINARY(64);
		SET @Password_Hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @SaltDb, @Password, @Salt));


		-- Envoie des données en se basant sur la vue
		SELECT VM.*
		FROM [dbo].[Member] M
			JOIN [dbo].[V_Member] VM ON M.[Id_Member] = VM.[Id_Member]
		WHERE M.[Email] LIKE @Email AND M.[Password] = @Password_Hash;
	END
END;


-- Solution alternative pour l'envoie des données
/*
--v2
DECLARE @Id_Member UNIQUEIDENTIFIER;
SELECT @Id_Member = Id_Member
 FROM [dbo].[Member] 
 WHERE [Email] LIKE @Email AND [Password] = @Password_Hash;

SELECT * FROM [V_Member] WHERE [Id_Member] = @Id_Member;

--v3
SELECT * 
 FROM [V_Member] 
 WHERE [Id_Member] = ( SELECT Id_Member
					   FROM [dbo].[Member] 
					   WHERE [Email] LIKE @Email AND [Password] = @Password_Hash );
*/