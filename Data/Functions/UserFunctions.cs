using Data.DataContext;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Functions
{
    public class UserFunctions : IRepository<User>
    {
        public async Task<User> Create(User user)
        {
            using (var context = new DatabaseContext(DatabaseContext.OpsBuild.DpOptions))
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }

            return user;
        }

        public async Task<List<User>> GetAll()
        {
            List<User> users = new();

            using (var context = new DatabaseContext(DatabaseContext.OpsBuild.DpOptions))
            {
                users = await context.Users.ToListAsync();
            }

            return users;
        }

        public async Task<User?> GetById(int Id)
        {

            using (var context = new DatabaseContext(DatabaseContext.OpsBuild.DpOptions))
            {
                User? user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
                return user;
            }
        }
        
        public async void Update(User user)
        {
            using (var context = new DatabaseContext(DatabaseContext.OpsBuild.DpOptions))
            {
                if (context.Update(user) != null)
                    await context.SaveChangesAsync();
            }
        }

        public async void Delete(User user)
        {
            using (var context = new DatabaseContext(DatabaseContext.OpsBuild.DpOptions))
            {
                if (context.Remove(user) != null)
                    await context.SaveChangesAsync();
            }
        }
    }
}

