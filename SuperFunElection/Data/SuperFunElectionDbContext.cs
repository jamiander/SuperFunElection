using Microsoft.EntityFrameworkCore;
using SuperFunElection.Domain;

namespace SuperFunElection.Data
{
    public class SuperFunElectionDbContext : DbContext
    {
        public SuperFunElectionDbContext(DbContextOptions<SuperFunElectionDbContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<Election> Elections { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Election>(election =>
            {
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

            modelBuilder.Entity<Candidate>(candidate =>
            {
                candidate.ToTable("Candidate");

                candidate.HasKey(candidate => candidate.Id);

                candidate.OwnsOne(candidate => candidate.Name, n =>
                {
                    n.Property(n => n.FirstName)
                        .HasColumnName("FirstName");
                    n.Property(n => n.LastName)
                        .HasColumnName("LastName");

                    candidate.HasMany(candidate => candidate.ElectionCandidacies)
                        .WithOne(candidacy => candidacy.Candidate)
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
            });

            modelBuilder.Entity<Candidacy>(candidacy =>
            {
                candidacy.ToTable("Candidacies");

                candidacy.HasKey(candidacy => candidacy.Id);

                candidacy.Property(candidacy => candidacy.InstatedOn)
                    .HasColumnName("EstablishedOn");

                candidacy.Property(candidacy => candidacy.TerminatedOn)
                    .HasColumnName("TerminatedOn");

                candidacy.HasMany(candidacy => candidacy.Ballots)
                    .WithOne(ballot => ballot.Candidacy)
                    .IsRequired();
            });

            modelBuilder.Entity<Ballot>(ballot =>
            {
                ballot.ToTable("Ballot");

                ballot.HasKey(ballot => ballot.Id);

                ballot.OwnsOne(ballot => ballot.Voter, n =>
                {
                    n.Property(n => n.FirstName)
                        .HasColumnName("FirstName");
                    n.Property(n => n.LastName)
                        .HasColumnName("LastName");

                    ballot.HasOne(ballot => ballot.Candidacy);

                });
            });
        }
    }
}

