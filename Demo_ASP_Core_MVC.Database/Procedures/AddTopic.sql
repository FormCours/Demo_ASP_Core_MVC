CREATE PROCEDURE [dbo].[AddTopic]
	@Title NVARCHAR(50), 
	@Id_Creator UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	-- Création du topic
	INSERT INTO [Topic]([Title], [Id_Creator])
	 OUTPUT [inserted].[Id_Topic]
	 VALUES (@Title, @Id_Creator); 
END
