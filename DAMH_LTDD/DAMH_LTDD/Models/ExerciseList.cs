namespace DAMH_LTDD.Models
{
    public class ExerciseList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Time { get; set; }
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public int DaysOfTheWeekId { get; set; }
        public DaysOfTheWeek? DaysOfTheWeek { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
