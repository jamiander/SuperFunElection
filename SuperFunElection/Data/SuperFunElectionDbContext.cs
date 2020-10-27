using Microsoft.EntityFrameworkCore;
using SuperFunElection.Domain;

namespace SuperFunElection.Data
{
    public class SuperFunElectionDbContext : DbContext
    {
        public SuperFunElectionDbContext(DbContextOptions<SuperFunElectionDbContext> contextOptions) : base(contextOptions)
        {}

        public DbSet<Election> Elections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Election>(election => {
                election.ToTable("Election");

                election.HasKey(election => election.Id);

                election.Property(election => election.Id)
                    .HasColumnName("Id");

                election.Property(election => election.Date)
                    .HasColumnName("Date");

                election.Property(election => election.Description)
                    .HasColumnName("Description");

                election.HasMany(election => election.Candidacies)
                    .WithOne(candidacy => candidacy.Election)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
        }
    }
}
