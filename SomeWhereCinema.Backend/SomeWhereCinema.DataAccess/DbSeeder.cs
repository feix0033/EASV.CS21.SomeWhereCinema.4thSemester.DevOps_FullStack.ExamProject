// using SomeWhereCinema.DataAccess.Entities;
//
// namespace SomeWhereCinema.DataAccess;
//
// public class DbSeeder
// {
//     private readonly MovieDbContext _movieDbContext;
//
//     public DbSeeder(MovieDbContext movieDbContext)
//     {
//         _movieDbContext = movieDbContext;
//     }
//
//     public void SeedDevelopment()
//     {
//         _movieDbContext.Database.EnsureDeleted();
//         _movieDbContext.Database.EnsureCreated();
//         _movieDbContext.Movies.Add(new MovieEntity() { Name = "name1" });
//         _movieDbContext.Movies.Add(new MovieEntity() { Name = "name2" });
//         _movieDbContext.Movies.Add(new MovieEntity() { Name = "name3" });
//         _movieDbContext.SaveChanges();
//     }
// }