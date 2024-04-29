using Microsoft.EntityFrameworkCore;
using Zonda.Application.Common.Interfaces;
using Zonda.Persistance.Repositories;

namespace Zonda.Persistance
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDbContext _context;
        private ICustomerRepository _customerRepository;
        private IProductRepository _productRepository;
        private ICustomerOrderRepository _customerOrderRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_context);
                }
                return _customerRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        public ICustomerOrderRepository CustomerOrderRepository
        {
            get
            {
                if (_customerOrderRepository == null)
                {
                    _customerOrderRepository = new CustomerOrderRepository(_context);
                }
                return _customerOrderRepository;
            }
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DetachEntity<T>(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
