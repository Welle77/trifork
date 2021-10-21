using Consumer.DB;
using Consumer.Repository.Timestamps;

namespace Consumer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TimestampContext _context;
        public ITimestampRepository Timestamps { get; private set; }

        public UnitOfWork(TimestampContext context)
        {
            _context = context;
            Timestamps = new TimestampRepository(_context);
        }

        public int CompleteTransaction()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
