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
	public class BaseRepository<T, TKey> : IRepository<T, TKey> where T : class
	{
		protected DbContext context;
		protected DbSet<T> dbSet;

		public BaseRepository(DbContext context) => (this.context, this.dbSet) = (context, context.Set<T>());

		public virtual void Create(T entity) => this.dbSet.Add(entity);

		public virtual void Delete(T entity) => this.dbSet.Remove(entity);

		public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null) => this.dbSet.Where(predicate);

		public virtual T GetById(TKey id) => this.dbSet.Find(id);

		public virtual void Update(T entity) => this.dbSet.Update(entity);
	}
}
