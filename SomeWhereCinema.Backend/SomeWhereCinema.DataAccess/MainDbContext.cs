using Microsoft.EntityFrameworkCore;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess.Entities;

namespace SomeWhereCinema.DataAccess;

public class MainDbContext:DbContext
{
    public virtual DbSet<MovieEntity>? Movies { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext>options) : base(options)
    {
    }

    
}