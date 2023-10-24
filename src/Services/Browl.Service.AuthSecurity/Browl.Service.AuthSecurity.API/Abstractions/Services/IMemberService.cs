using System.Linq.Expressions;

using Browl.Service.AuthSecurity.API.Entities.Members;
using Browl.Service.AuthSecurity.API.Utilities;

namespace Browl.Service.AuthSecurity.API.Abstractions.Services;

public interface IMemberService
{
	IDataResult<Member> Get(Expression<Func<Member, bool>> filter);
	IDataResult<List<Member>> GetAll(Expression<Func<Member, bool>>? filter = null);
	Utilities.IResult Add(Member entity);
	Utilities.IResult Update(Member entity);
	Utilities.IResult Delete(Guid entityId);
}
