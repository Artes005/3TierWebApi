using _3TierWebApi.Models;
using Business.PositionLogic;
using Microsoft.AspNetCore.Mvc;

namespace _3TierWebApi.Controllers
{
    [Route("api/position/")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        readonly PositionLogic positionLogic = new();


        //get all positions
        [Route("all")]
        [HttpGet]
        public async Task<List<PositionViewModel>> GetAllPositions()
        {
            List<PositionViewModel> positionsList = new();

            var positions = await positionLogic.GetAllPositionsAsync();

            foreach (var position in positions)
            {
                PositionViewModel positionModel = new()
                {
                    Id = position.Id,
                    Title = position.Title
                };
                positionsList.Add(positionModel);
            }

            return positionsList;
        }

        //add position
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddPositionAsync([FromBody] PositionCreateModel positionCreateModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            bool result = await positionLogic.CreatePositionAsync(positionCreateModel.Title);

            return result == true ? Ok("Position created") : UnprocessableEntity();
        }

        //delete position
        [Route("delete")]
        [HttpDelete]
        public async Task<bool> DeletePosition(int id)
        {
            return await positionLogic.DeletePositionAsync(id);
        }
    }
}
