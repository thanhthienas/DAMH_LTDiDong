namespace DAMH_LTDD.Models
{
    public class ExerciseList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Time { get; set; }
        public int DaysOfTheWeekId { get; set; }
        public DaysOfTheWeek? DaysOfTheWeek { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }

        // Quan hệ nhiều-nhiều với Food thông qua MealListFood
        public ICollection<ExerciseListExercise>? ExerciseListExercises { get; set; }
    }
}
