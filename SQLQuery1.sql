Create proc sp_login
@Us_id NVARCHAR(100),
@Us_Password NVARCHAR(100),
@Isvalid BIT OUT
AS
BEGIN
SET @Isvalid=(SELECT COUNT(1) FROM dbo.Users WHERE Id =@Us_id and Password=@Us_Password)
END