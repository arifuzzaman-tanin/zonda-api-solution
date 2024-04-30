using Zonda.Application.Common.Interfaces;
using Zonda.Application.Entities;

namespace Zonda.Persistance.Repositories
{
    public class CustomerOrderRepository : BaseRepository<CustomerOrder>, ICustomerOrderRepository
    {
        ApplicationDbContext _dbContext;

        public CustomerOrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
