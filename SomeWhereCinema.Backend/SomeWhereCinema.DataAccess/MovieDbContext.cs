using Microsoft.EntityFrameworkCore;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.DataAccess;

public class MovieDbContext:DbContext
{
    public DbSet<Movie> MovieTable { get; set; }
    // public virtual DbSet<MovieEntity>? Movies { get; set; }

    // Constructor will inject the db context option
    public MovieDbContext(DbContextOptions<MovieDbContext>options) : base(options)
    {
    }

    // here defend every thing need init like primary key 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .Property(m => m.Id)
            .ValueGeneratedOnAdd();
    }
}