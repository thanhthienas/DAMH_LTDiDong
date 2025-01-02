using DAMH_LTDD.Models;
using DAMH_LTDD.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAMH_LTDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseListApiController : ControllerBase
    {
        private readonly IExerciseListRepository _exerciseListRepository;
        public ExerciseListApiController(IExerciseListRepository exerciseListRepository)
        {
            _exerciseListRepository = exerciseListRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetExerciseList()
        {
            try
            {
                var exerciseList = await _exerciseListRepository.GetExerciseListAsync();
                return Ok(exerciseList);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseListById(int id)
        {
            try
            {
                var exerciseList = await _exerciseListRepository.GetExerciseListByIdAsync(id);
                if (exerciseList == null)
                    return NotFound();
                return Ok(exerciseList);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddExerciseList([FromBody] ExerciseList exerciseList)
        {
            try
            {
                await _exerciseListRepository.AddExerciseListAsync(exerciseList);
                return CreatedAtAction(nameof(GetExerciseListById), new
                {
                    id = exerciseList.Id
                }, exerciseList);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseList(int id, [FromBody] ExerciseList exerciseList)
        {
            try
            {
                if (id != exerciseList.Id)
                    return BadRequest();
                await _exerciseListRepository.UpdateExerciseListAsync(exerciseList);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseList(int id)
        {
            try
            {
                await _exerciseListRepository.DeleteExerciseListAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
