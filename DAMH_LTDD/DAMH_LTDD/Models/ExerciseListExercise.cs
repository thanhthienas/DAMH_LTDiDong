namespace DAMH_LTDD.Models
{
    public class ExerciseListExercise
    {
        public int ExerciseListId { get; set; }
        public ExerciseList? ExerciseList { get; set; }

        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
