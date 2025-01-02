using DAMH_LTDD.Models;

namespace DAMH_LTDD.Repositories
{
    public interface IMealListRepository
    {
        Task<IEnumerable<MealList>> GetMealListAsync();
        Task<MealList> GetMealListByIdAsync(int id);
        Task AddMealListAsync(MealList mealList);
        Task UpdateMealListAsync(MealList mealList);
        Task DeleteMealListAsync(int id);
    }
}
