using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts
{
	/// <summary>
	/// Contract for basic interaction with model of specified type <see cref="T"/>
	/// </summary>
	/// <typeparam name="T">Type to interact with</typeparam>
	/// <typeparam name="TKey">Type of <typeparamref name="T"/> primary key</typeparam>
	public interface IRepository<T, TKey>
	{
		IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);

		T GetById(TKey id);
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
