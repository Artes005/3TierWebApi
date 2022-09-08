using Data.DataContext;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Functions
{
    public class PositionFunctions : IRepository<Position>
    {
        public async Task<Position> Create(Position position)
        {
            using (var context = new DatabaseContext(DatabaseContext.OpsBuild.DpOptions))
            {
                await context.Positions.AddAsync(position);
                await context.SaveChangesAsync();
            }

            return position;
        }

        public async Task<List<Position>> GetAll()
        {
            List<Position> positions = new();

            using (var context = new DatabaseContext(DatabaseContext.OpsBuild.DpOptions))
            {
                positions = await context.Positions.ToListAsync();
            }

            return positions;
        }

        public async Task<Position?> GetById(int Id)
        {

            using (var context = new DatabaseContext(DatabaseContext.OpsBuild.DpOptions))
            {
                Position? position = await context.Positions.FirstOrDefaultAsync(x => x.Id == Id);
                return position;
            }
        }

        public async void Update(Position position)
        {
            using (var context = new DatabaseContext(DatabaseContext.OpsBuild.DpOptions))
            {
                if (context.Update(position) != null)
                    await context.SaveChangesAsync();
            }
        }

        public async void Delete(Position position)
        {
            using (var context = new DatabaseContext(DatabaseContext.OpsBuild.DpOptions))
            {
                if (context.Remove(position) != null)
                    await context.SaveChangesAsync();
            }
        }
    }
}

