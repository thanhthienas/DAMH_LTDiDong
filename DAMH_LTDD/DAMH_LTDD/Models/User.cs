using Microsoft.AspNetCore.Identity;

namespace DAMH_LTDD.Models
{
    public class User: IdentityUser
    {
        public int? Height { get; set; }
        public float? Weight { get; set; }
        public DateTime Date_of_birth { get; set; }
        public bool Sex { get; set; }
        public List<MealList>? MealLists { get; set; }
        public List<ExerciseList>? ExerciseLists { get; set; }
    }
}
