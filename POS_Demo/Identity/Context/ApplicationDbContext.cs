using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace POS_Demo
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, int, UserLogin, UserRole, UserClaim>
    {

        public ApplicationDbContext()
            : this("DefaultConnection")
        {
            this.Database.CreateIfNotExists();
        }

        public ApplicationDbContext(string connStringName)
            : base(connStringName)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        

        public DbQuery<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>().AsNoTracking();
        }
    }
}