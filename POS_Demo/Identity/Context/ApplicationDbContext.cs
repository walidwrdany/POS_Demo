using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
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

        

        public ICollection<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class
        {
            if (predicate != null)
                return Set<TEntity>().AsNoTracking().Where(predicate).ToList();
            return Set<TEntity>().AsNoTracking().ToList();
        }
    }
}