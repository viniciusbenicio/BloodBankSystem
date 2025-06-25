using BloodBankSystem.Core;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace BloodBankSystem.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloodBankSystemDBContext _context;

        private IDbContextTransaction _transaction;
        public IDonorRepository Donors { get; }
        public IDonationRepository Donations { get; }
        public IBloodStockRepository BloodStocks { get; }

        public UnitOfWork(BloodBankSystemDBContext context, IDonorRepository donors, IDonationRepository donations, IBloodStockRepository bloodStocks)
        {
            _context = context;
            Donors = donors;
            Donations = donations;
            BloodStocks = bloodStocks;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw ex;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

    }
}