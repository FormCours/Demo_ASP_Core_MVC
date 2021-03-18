CREATE PROCEDURE [dbo].[AddMessage]
	@Content NVARCHAR(4000),
	@Id_Member UNIQUEIDENTIFIER,
	@Id_Topic UNIQUEIDENTIFIER
AS
BEGIN
	INSERT INTO [Message] ([Content], [Id_Member], [Id_Topic])
	 OUTPUT [inserted].[Id_Message]
	 VALUES (@Content, @Id_Member, @Id_Topic);
END;