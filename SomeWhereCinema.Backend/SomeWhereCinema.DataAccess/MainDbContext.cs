using Microsoft.EntityFrameworkCore;

namespace SomeWhereCinema.DataAccess;

public class MainDbContext:DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext>options) : base(options)
    {
    }
}