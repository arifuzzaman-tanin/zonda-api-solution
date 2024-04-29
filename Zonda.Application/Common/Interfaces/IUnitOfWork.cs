namespace Zonda.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ICustomerOrderRepository CustomerOrderRepository { get; }
        public int Commit();
        public Task<int> CommitAsync();
        public void DetachEntity<T>(T entity);
    }
}
