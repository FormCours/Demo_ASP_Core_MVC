CREATE PROCEDURE [dbo].[UpdateTopic]
	@Id_Topic UNIQUEIDENTIFIER,
	@Title NVARCHAR(50)
AS
BEGIN
	UPDATE [Topic]
	 SET Title = @Title
	 WHERE Id_Topic = @Id_Topic;
END;