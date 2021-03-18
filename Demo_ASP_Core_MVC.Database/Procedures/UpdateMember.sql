CREATE PROCEDURE [dbo].[UpdateMember]
	@Id_Member UNIQUEIDENTIFIER,
	@Pseudo NVARCHAR(50),
	@Email NVARCHAR(250)
AS
BEGIN
	UPDATE [Member]
	 SET Pseudo = @Pseudo,
		 Email = @Email
	 WHERE Id_Member = @Id_Member;
END;