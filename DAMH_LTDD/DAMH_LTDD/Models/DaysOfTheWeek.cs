namespace DAMH_LTDD.Models
{
    public class DaysOfTheWeek
    {
        public int Id { get; set; }
        public string? Day { get; set; }
        public List<MealList>? MealLists { get; set; }
        public List<ExerciseList>? ExerciseLists { get; set; }
    }
}
