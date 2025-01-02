using DAMH_LTDD.Models;

namespace DAMH_LTDD.Repositories
{
    public interface IExerciseListRepository
    {
        Task<IEnumerable<ExerciseList>> GetExerciseListAsync();
        Task<ExerciseList> GetExerciseListByIdAsync(int id);
        Task AddExerciseListAsync(ExerciseList exerciseList);
        Task UpdateExerciseListAsync(ExerciseList exerciseList);
        Task DeleteExerciseListAsync(int id);
    }
}
