using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgramingLanguages => Set<ProgrammingLanguage>();
        public DbSet<ProgrammingTechnology> ProgrammingTechnologies => Set<ProgrammingTechnology>();


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.ProgrammingTechnologies).WithOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<ProgrammingTechnology>(a =>
            {
                a.ToTable("ProgrammingTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage).WithMany(p => p.ProgrammingTechnologies);
            });

            ProgrammingLanguage[] languageEntitySeeds = {
                new(1, "C#"),
                new(2, "Java"),
                new(3, "JavaScript")
            };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(languageEntitySeeds);

            ProgrammingTechnology[] technologyEntitySeeds = {
                new(1, 1, "ASP.NET"),
                new(2, 1, "WPF"),
                new(3, 2, "JSP"),
                new(4, 2, "Spring"),
                new(5, 3, "Angular"),
                new(6, 3, "React"),
                new(7, 3, "Vue")
            };
            modelBuilder.Entity<ProgrammingTechnology>().HasData(technologyEntitySeeds);
        }
    }
}
