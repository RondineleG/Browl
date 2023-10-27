namespace Browl.Infra.Repositories;
public partial class UserRepository
{
	private const string QueryAuthenticateUser = @"
SELECT TOP 1
	Id,
	Nome,
	Email
FROM
	User
WHERE
	Email = @email 
	AND Passwordhash = @passwordhash
";



}
