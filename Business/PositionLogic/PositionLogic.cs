using Data.Entities;
using Data.Functions;
using Data.Interfaces;

namespace Business.PositionLogic
{
    public class PositionLogic
    {
        private IRepository<Position> _positionFunctions = new PositionFunctions();

        public async Task<bool> CreatePositionAsync(string title)
        {
            try
            {
                Position p = new()
                {
                    Title = title
                };


                var result = await _positionFunctions.Create(p);
                return result.Id > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Position>> GetAllPositionsAsync()
        {
            List<Position> positions = await _positionFunctions.GetAll();

            return positions;
        }

        public async Task<bool> DeletePositionAsync(int positionId)
        {

            Position? p = await _positionFunctions.GetById(positionId);

            if (p == null) //position not exists
                return false;

            try
            {
                _positionFunctions.Delete(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

