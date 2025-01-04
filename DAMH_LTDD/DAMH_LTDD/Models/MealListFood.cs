namespace DAMH_LTDD.Models
{
    public class MealListFood
    {
        public int MealListId { get; set; }
        public MealList? MealList { get; set; }

        public int FoodId { get; set; }
        public Food? Food { get; set; }
    }
}
