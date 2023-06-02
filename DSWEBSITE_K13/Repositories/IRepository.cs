using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Repositories
{
    /// <summary>
    /// this repostiory for commong method's for all inheret repository 
    /// </summary>
    public interface IRepository
    {
        public interface IRepository
        {

            IPageDataContextRetriever DataContextRetriever { get; }
            IPageDataContextInitializer DataContextInitializer { get; }

            //DbContext GetDbContext();
            T GetById<T>(Guid id) where T : class;
            IQueryable<T> GetAll<T>() where T : class;
            T FindBy<T>(object parameter) where T : class;
            T FindBy<T>(Expression<Func<T, bool>> filter) where T : class;
            T FindBy<T>(Expression<Func<T, bool>> filter, string include) where T : class;
            IQueryable<T> SearchBy<T>(Expression<Func<T, bool>> filter) where T : class;
            IQueryable<T> SearchBy<T>(Expression<Func<T, bool>> filter, string include) where T : class;
            IEnumerable<T> SqlQuery<T>(string sql) where T : class;
            IEnumerable<T> SqlQuery<T>(string sql, object[] parameters) where T : class;
            bool Exists<T>(T entity) where T : class;
            bool Exists<T>(params object[] keys) where T : class;
            bool Exists<T>(Expression<Func<T, bool>> filter) where T : class;
            void Insert<T>(T entity) where T : class;
            void Update<T>(T entity) where T : class;
            void Update<T>(List<T> entities) where T : class;
            void Delete<T>(T entity) where T : class;
            void Delete<T>(List<T> entities) where T : class;
            void Commit();
            void Dispose();
        }

        public partial class Repository : AbstractRepository
        {
            public Repository()
            {
                //this.context.Configuration.ProxyCreationEnabled = true;
                //this.context.Configuration.LazyLoadingEnabled = true;
            }

            #region CREATE METHOD

            /// <summary>
            /// This method for insert record is database.
            /// </summary>
            /// <typeparam name="T">object entity</typeparam>
            /// <param name="entity">entity</param>
            public override void Insert<T>(T entity)
            {
                try
                {
                    //DbSet<T> _set = IsCodeFirstApproch ? identityDbContext.Set<T>() : dbContext.Set<T>();
                    DbSet<T> _set = DataContextRetriever.Set<T>();

                    _set.Add(entity);

                    //Commit();
                    //context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }

            #endregion

            #region RETRIVE METHOD

            ////Get Entity

            /// <summary>
            /// This method using for get single record from database entity by id.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="id">ID (Primary Key)</param>
            /// <returns>Entity Object</returns>
            public override T GetById<T>(Guid id)
            {
                try
                {
                    return context.Set<T>().Find(id);
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The exception errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }

            }

            /// <summary>
            /// This method using for get all record from database entity.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns>All Entity Object</returns>
            public override IQueryable<T> GetAll<T>()
            {
                try
                {
                    return context.Set<T>();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The exception errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }

            ////Single Object Type Method

            /// <summary>
            /// This method using for get single record from database entity by key parameter.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="parameter">key value parameter</param>
            /// <returns>Single Entity Object</returns>
            public override T FindBy<T>(object parameter)
            {
                try
                {
                    return context.Set<T>().Find(parameter);
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The exception errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }

            /// <summary>
            ///This method using for get single record from database entity by key filter expression.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="filter">condition</param>
            /// <returns>Single Entity Object</returns>
            public override T FindBy<T>(Expression<Func<T, bool>> filter)
            {
                try
                {
                    return context.Set<T>().Where(filter).FirstOrDefault();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The exception errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }

            /// <summary>
            ///  This method using for get single record from database entity by key filter expression including additional.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="filter">condition</param>
            /// <param name="include">include</param>
            /// <returns>Single Entity Object</returns>
            public override T FindBy<T>(Expression<Func<T, bool>> filter, string include)
            {
                try
                {
                    return context.Set<T>().Where(filter).Include(include).FirstOrDefault();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The exception errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }

            ////Collection Type Methods

            /// <summary>
            /// This method using for get filter records from database entity by key filter expression.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="filter"></param>
            /// <returns>List</returns>
            public override IQueryable<T> SearchBy<T>(Expression<Func<T, bool>> filter)
            {
                try
                {
                    return context.Set<T>().Where(filter).AsQueryable();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The exception errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }


            }

            /// <summary>
            /// This method using for get filter records from database entity by key filter expression including additional.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="filter">expression</param>
            /// <param name="include">include</param>
            /// <returns>List</returns>
            public override IQueryable<T> SearchBy<T>(Expression<Func<T, bool>> filter, string include)
            {
                try
                {
                    return context.Set<T>().Where(filter).Include(include);
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The exception errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }

            #endregion

            #region UPDATE METHOD

            /// <summary>
            /// This method for update single record is database.
            /// </summary>
            /// <typeparam name="T">object entity</typeparam>
            /// <param name="entity">entity</param>
            public override void Update<T>(T entity)
            {
                try
                {
                    DbSet<T> _set = context.Set<T>();
                    _set.Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;

                    //context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }

            /// <summary>
            ///  This method for update bulk record is database.
            /// </summary>
            /// <typeparam name="T">object entity</typeparam>
            /// <param name="entities">entity</param>
            public override void Update<T>(List<T> entities)
            {
                foreach (var entity in entities)
                {
                    Update(entity);
                }
            }

            #endregion

            #region  DELETE METHOD
            /// <summary>
            ///  This method for delete single record is database.
            /// </summary>
            /// <typeparam name="T">object entity</typeparam>
            /// <param name="entity">entity</param>
            public override void Delete<T>(T entity)
            {
                try
                {
                    DbSet<T> _set = context.Set<T>();
                    var entry = context.Entry(entity);
                    if (entry != null)
                    {
                        entry.State = EntityState.Deleted;
                    }
                    else
                    {
                        _set.Attach(entity);
                    }
                    context.Entry(entity).State = EntityState.Deleted;
                    //context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }

            /// <summary>
            ///  This method for delete bulk record is database.
            /// </summary>
            /// <typeparam name="T">object entity</typeparam>
            /// <param name="entities">entity</param>
            public override void Delete<T>(List<T> entities)
            {
                foreach (var entity in entities)
                {
                    Delete(entity);
                }
            }

            #endregion

            //// Collection Type Methods SQL Query
            /// <summary>
            /// This method using for get records from database by sql query expression.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="sql"></param>
            /// <returns>entity</returns>
            public override IEnumerable<T> SqlQuery<T>(string sql)
            {
                try
                {
                    return context.Set<T>().SqlQuery(sql);
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The exception errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }

            }

            /// <summary>
            /// This method using for get records from database by sql query with filter expression.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="sql">Sql Query</param>
            /// <param name="parameters">Filter Parameters</param>
            /// <returns>Set of Entity</returns>
            public override IEnumerable<T> SqlQuery<T>(string sql, object[] parameters)
            {
                try
                {
                    return context.Set<T>().SqlQuery(sql, parameters);
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The exception errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }

            ////Result Type Method
            /// <summary>
            /// This method using for checked record is exist in database entity by entity.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="entity"></param>
            /// <returns></returns>
            public override bool Exists<T>(T entity)
            {
                return context.Set<T>().Local.Any(e => e == entity);
            }

            /// <summary>
            /// This method using for checked record is exist in database entity by key object arry.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="keys"></param>
            /// <returns></returns>
            public override bool Exists<T>(params object[] keys)
            {
                return (context.Set<T>().Find(keys) != null);
            }

            /// <summary>
            /// This method using for checked record is exist in database entity by key filter expression.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="filter">expression</param>
            /// <returns>true/false</returns>
            public override bool Exists<T>(Expression<Func<T, bool>> filter)
            {
                try
                {
                    var result = context.Set<T>().Where(filter).ToList();

                    return result != null && result.Count > 0 ? true : false;
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The exception errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }

            /// <summary>
            /// Save record from database.
            /// </summary>
            public override void Commit()
            {
                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    Exception raise = ex;
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
            }

            public override T GetSingle<T>(Expression<Func<T, bool>> filter)
            {
                throw new NotImplementedException();
            }

            public override bool Exists<T>(Expression<Func<T, bool>> filter, string include)
            {
                throw new NotImplementedException();
            }

            public override void CreateTo<T>(T entity)
            {
                throw new NotImplementedException();
            }

            public override void UpdateTo<T>(T entity)
            {
                throw new NotImplementedException();
            }

            public override void BulkUpdateTo<T>(IQueryable<T> entities)
            {
                throw new NotImplementedException();
            }

            public override void DeleteTo<T>(T entity)
            {
                throw new NotImplementedException();
            }
        }


        public abstract class AbstractRepository : IRepository
        {
            //protected dbConnection context = ContextFactory.GetContext();

            #region Collection Methods

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public abstract IQueryable<T> GetAll<T>() where T : class;

            /// <summary>
            /// Get Single or Defult Record
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="filter"></param>
            /// <param name="include"></param>
            /// <returns></returns>
            public abstract T GetSingle<T>(Expression<Func<T, bool>> filter) where T : class;

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="filter"></param>
            /// <returns></returns>
            public abstract IQueryable<T> FindBy<T>(Expression<Func<T, bool>> filter) where T : class;

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="filter"></param>
            /// <param name="include"></param>
            /// <returns></returns>
            public abstract IQueryable<T> FindBy<T>(Expression<Func<T, bool>> filter, string include) where T : class;

            #endregion

            #region If Is Exists Function
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="filter"></param>
            /// <returns></returns>
            public abstract bool Exists<T>(Expression<Func<T, bool>> filter) where T : class;

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="filter"></param>
            /// <param name="include"></param>
            /// <returns></returns>
            public abstract bool Exists<T>(Expression<Func<T, bool>> filter, string include) where T : class;

            #endregion

            #region CRUD Methods
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="entity"></param>
            public abstract void CreateTo<T>(T entity) where T : class;

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="entity"></param>
            public abstract void UpdateTo<T>(T entity) where T : class;

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="entity"></param>
            public abstract void BulkUpdateTo<T>(IQueryable<T> entities) where T : class;

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="entity"></param>
            public abstract void DeleteTo<T>(T entity) where T : class;

            #endregion

            //public abstract dbConnection GetContext();


            //public void Dispose()
            //{
            //    if (context != null) { context.Dispose(); context = null; }
            //}
        }
    }
}
