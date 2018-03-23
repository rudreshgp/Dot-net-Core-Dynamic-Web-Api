using System.Linq;
using DynamicProject.Model;
using Microsoft.EntityFrameworkCore;

namespace DynamicProject.Repository.Helper
{

      public interface IDomainModelContext
    {
        #region Master Tables
        /// <summary>
        /// Gets or sets users
        /// </summary>
        DbSet<User> Users { get; set; }

        #endregion
    }
    public class ApplicationContext : DbContext,IDomainModelContext
    {
        public DbSet<User> Users{get;set;}
    
        // public DbSet<Role> Roles{get;set;}
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

     /// <summary>
    /// This interface is used to call context factory
    /// </summary>
    /// <typeparam name="TDomainModelContext">Specifies domain model context</typeparam>
    public interface IDbContextFactory<TDomainModelContext>
    {
        /// <summary>
        /// Gets or sets a value
        /// </summary>
        TDomainModelContext DomainModelContext { get; set; }

        /// <summary>
        /// Gets or sets a value
        /// </summary>
        DbContext DbContext { get; set; }

        /// <summary>
        /// this method is called for set
        /// </summary>
        /// <typeparam name="TModel">Specifies data type</typeparam>
        /// <returns>returns a value</returns>
        DbSet<TModel> Set<TModel>() where TModel : class;
    }

    /// <summary>
    /// This class is used for data base context factory
    /// </summary>
    public class DbContextFactory : IDbContextFactory<IDomainModelContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextFactory"/> class.
        /// </summary>
        public DbContextFactory(ApplicationContext applicationContext)
        {
            DbContext = applicationContext;
            this.DomainModelContext = DbContext as IDomainModelContext;
            try
            {
            }
            catch (System.Exception ex)
            {
            }

        }
        /// <summary>
        /// Gets or sets a value
        /// </summary>
        public IDomainModelContext DomainModelContext { get; set; }

        /// <summary>
        /// Gets or sets a value
        /// </summary>
        public DbContext DbContext { get; set; }

        /// <summary>
        /// This method is used for Set a value
        /// </summary>
        /// <typeparam name="TModel">Specifies data type</typeparam>
        /// <returns>Returns a value</returns>
        public DbSet<TModel> Set<TModel>() where TModel : class
        {
            if (DbContext == null)
            {
                var dbsetProperty = (from property in this.DomainModelContext.GetType().GetProperties().ToList()
                                     where typeof(DbSet<TModel>).IsAssignableFrom(property.PropertyType)
                                     select property).Single();

                return dbsetProperty.GetValue(this.DomainModelContext, null) as DbSet<TModel>;
            }

            return DbContext.Set<TModel>();
        }
    }
}