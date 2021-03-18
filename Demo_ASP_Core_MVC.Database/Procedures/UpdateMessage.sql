CREATE PROCEDURE [dbo].[UpdateMessage]
	@Id_Message UNIQUEIDENTIFIER,
	@Content NVARCHAR(4000)
AS
BEGIN
	UPDATE [Message]
	 SET Content = @Content,
		 Update_Date = GETDATE()
	 WHERE Id_Message = @Id_Message;
END;