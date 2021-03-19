CREATE PROCEDURE [dbo].[AddTopic]
	@Title NVARCHAR(50),
	@First_Message NVARCHAR(4000), 
	@Id_Creator UNIQUEIDENTIFIER
AS
BEGIN
	-- Cette version de la procedure n'est plus utiliser car elle ne correspond
	-- pas au pattern de notre implementation du Repository

	SET NOCOUNT ON;
	BEGIN TRANSACTION;

	DECLARE @Id_Topic UNIQUEIDENTIFIER;
	DECLARE @Inserted_Values TABLE (
		Id UNIQUEIDENTIFIER
	);

	-- Création du topic
	INSERT INTO [Topic]([Title], [Id_Creator])
	 OUTPUT [inserted].[Id_Topic] INTO @Inserted_Values
	 VALUES (@Title, @Id_Creator); 

	SELECT @Id_Topic = Id FROM @Inserted_Values;

	-- Ajout du message dans le topic
	INSERT INTO [Message] ([Content], [Id_Member], [Id_Topic])
	 VALUES (@First_Message, @Id_Creator, @Id_Topic);

	-- Renvoie de l'ID du topic via un select
	SELECT @Id_Topic;
	COMMIT;
END
