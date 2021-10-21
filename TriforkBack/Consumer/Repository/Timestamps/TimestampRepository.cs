using Consumer.DB;

namespace Consumer.Repository.Timestamps
{
    public class TimestampRepository : GenericRepository<Timestamp>, ITimestampRepository
    {
        public TimestampRepository(TimestampContext context) : base(context)
        {

        }
        //Overwrites can be made here.
    }
}
