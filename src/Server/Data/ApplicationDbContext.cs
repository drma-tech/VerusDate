using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using VerusDate.Server.Models;

namespace VerusDate.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
                .Where(p => !p.Name.Contains("Identity", System.StringComparison.InvariantCulture))
                .Where(p => !p.Name.Contains("ApplicationUser", System.StringComparison.InvariantCulture))
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                if (!property.GetMaxLength().HasValue)
                    property.SetMaxLength(256);

                if (!property.IsUnicode().HasValue)
                    property.SetIsUnicode(false);
            }

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(builder);
        }
    }
}