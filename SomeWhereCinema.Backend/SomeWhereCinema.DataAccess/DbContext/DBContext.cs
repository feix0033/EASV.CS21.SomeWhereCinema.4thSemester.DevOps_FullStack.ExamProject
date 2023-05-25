using Microsoft.EntityFrameworkCore;
using SomeWhereCinema.DataAccess.Entities;

namespace SomeWhereCinema.DataAccess.DbContext;

public class DBContext:Microsoft.EntityFrameworkCore.DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieEntity>()
            .Property(m => m.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<MovieEntity>().ToTable("MovieTable");
        
        modelBuilder.Entity<OrderEntity>()
            .Property(o => o.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<OrderEntity>().ToTable("OrderTable");

    
        modelBuilder.Entity<ProjectionPlanEntity>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<ProjectionPlanEntity>().ToTable("ProjectionPlanTable");

        
        modelBuilder.Entity<TheatreEntity>()
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<TheatreEntity>().ToTable("TheatreTable");

    }

    public DbSet<MovieEntity> MovieTable { get; set; }
    public DbSet<OrderEntity> OrderTable { get; set; }
    public DbSet<ProjectionPlanEntity> ProjectionPlanTable { get; set; }
    public DbSet<TheatreEntity> TheatreTable { get; set; }
}