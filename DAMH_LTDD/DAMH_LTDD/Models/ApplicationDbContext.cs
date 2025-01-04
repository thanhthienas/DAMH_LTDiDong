using System.Reflection.Emit;
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
        public DbSet<BodyData> BodyDatas { get; set; }
        public DbSet<MealListFood> MealListFoods { get; set; }
        public DbSet<ExerciseListExercise> ExerciseListExercises { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>();
            builder.HasDefaultSchema("identity");
            // Quan hệ 1:N giữa User và MealList
            builder.Entity<MealList>()
                .HasOne(ml => ml.User)
                .WithMany(u => u.MealLists)
                .HasForeignKey(ml => ml.UserId);

            // Quan hệ N:N giữa MealList và Food thông qua bảng trung gian
            builder.Entity<MealListFood>()
                .HasKey(mlf => new { mlf.MealListId, mlf.FoodId });

            builder.Entity<MealListFood>()
                .HasOne(mlf => mlf.MealList)
                .WithMany(ml => ml.MealListFoods)
                .HasForeignKey(mlf => mlf.MealListId);

            builder.Entity<MealListFood>()
                .HasOne(mlf => mlf.Food)
                .WithMany(f => f.MealListFoods)
                .HasForeignKey(mlf => mlf.FoodId);

            base.OnModelCreating(builder);
            // Quan hệ 1:N giữa User và ExerciseList
            builder.Entity<ExerciseList>()
                .HasOne(el => el.User)
                .WithMany(u => u.ExerciseLists)
                .HasForeignKey(el => el.UserId);
            // Quan hệ N:N giữa ExerciseList và Exercise thông qua bảng trung gian
            builder.Entity<ExerciseListExercise>()
                .HasKey(ele => new { ele.ExerciseListId, ele.ExerciseId });

            builder.Entity<ExerciseListExercise>()
                .HasOne(ele => ele.ExerciseList)
                .WithMany(el => el.ExerciseListExercises)
                .HasForeignKey(ele => ele.ExerciseListId);

            builder.Entity<ExerciseListExercise>()
                .HasOne(ele => ele.Exercise)
                .WithMany(e => e.ExerciseListExercises)
                .HasForeignKey(ele => ele.ExerciseId);

            base.OnModelCreating(builder);
        }
    }
}
