using Entities.Models;

namespace Contracts
{
	/// <summary>
	/// Contract which defines <see cref="User"/> specific methods
	/// </summary>
	public interface IUsersRepository : IRepository<User>
	{
	}
}
