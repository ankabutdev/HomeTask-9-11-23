using DemoLessonTask.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoLessonTask.DataContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Car> Cars { get; set; }
    public virtual DbSet<PersonCars> PersonCars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseLazyLoadingProxies(true);
    }
}
