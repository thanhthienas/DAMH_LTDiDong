using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAMH_LTDD.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Food> Foods { get; set; }
        public DbSet<CategoryFood> CategoryFood { get; set; }
        public DbSet<DaysOfTheWeek> DaysOfTheWeeks { get; set; }
        public DbSet<MealList> MealList { get; set; }
        public DbSet<ExerciseList> ExerciseList { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<CategoryExercise> CategoryExercise { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>();
            builder.HasDefaultSchema("identity");
        }

    }
}
