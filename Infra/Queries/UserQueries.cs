namespace Browl.Infra.Repositories;
public partial class UserRepository
{
	private const string QueryAuthenticateUser = @"
SELECT TOP 1
	Id,
	Nome,
	Email
FROM
	Browl.dbo.[User]
WHERE
	Email = @Email 
	AND Passwordhash = @passwordhash
";



}
