using Contracts;
using EduPortalBackend.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
	/// <summary>
	/// Implementation of basic interaction with model of specified type <see cref="T"/>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BaseRepository<T> : IRepository<T> where T : class
	{
		protected ApplicationDbContext context;
		protected DbSet<T> dbSet;

		public BaseRepository(ApplicationDbContext context) => (this.context, this.dbSet) = (context, context.Set<T>());

		public void Create(T entity) => this.dbSet.Add(entity);

		public void Delete(T entity) => this.dbSet.Remove(entity);

		public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null) => this.dbSet.Where(predicate).AsNoTracking();

		public void Update(T entity) => this.dbSet.Update(entity);
	}
}
