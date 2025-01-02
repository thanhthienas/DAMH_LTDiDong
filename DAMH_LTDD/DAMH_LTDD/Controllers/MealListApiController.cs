using DAMH_LTDD.Models;
using DAMH_LTDD.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAMH_LTDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealListApiController : ControllerBase
    {
        private readonly IMealListRepository _mealListRepository;
        public MealListApiController(IMealListRepository mealListRepository)
        {
            _mealListRepository = mealListRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetMealList()
        {
            try
            {
                var mealLists = await _mealListRepository.GetMealListAsync();
                return Ok(mealLists);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealListById(int id)
        {
            try
            {
                var mealLists = await _mealListRepository.GetMealListByIdAsync(id);
                if (mealLists == null)
                    return NotFound();
                return Ok(mealLists);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddMealList([FromBody] MealList mealList)
        {
            try
            {
                await _mealListRepository.AddMealListAsync(mealList);
                return CreatedAtAction(nameof(GetMealListById), new
                {
                    id = mealList.Id
                }, mealList);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMealList(int id, [FromBody] MealList mealList)
        {
            try
            {
                if (id != mealList.Id)
                    return BadRequest();
                await _mealListRepository.UpdateMealListAsync(mealList);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealList(int id)
        {
            try
            {
                await _mealListRepository.DeleteMealListAsync(id);
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
