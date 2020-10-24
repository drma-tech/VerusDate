using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using VerusDate.Server.Models;
using VerusDate.Shared.Entity;

namespace VerusDate.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<ProfileLooking> ProfileLooking { get; set; }
        public virtual DbSet<Gamification> Gamification { get; set; }
        public virtual DbSet<Interaction> Interaction { get; set; }
        public virtual DbSet<Badge> Badge { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketVote> TicketVote { get; set; }

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