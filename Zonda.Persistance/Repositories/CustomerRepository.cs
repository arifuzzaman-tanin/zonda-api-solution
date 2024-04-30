using Zonda.Application.Common.Interfaces;
using Zonda.Application.Entities;

namespace Zonda.Persistance.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
