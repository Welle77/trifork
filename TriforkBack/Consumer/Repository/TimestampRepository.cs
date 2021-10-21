using Consumer.DB;

namespace Consumer.Repository
{
    public class TimestampRepository : GenericRepository<Timestamp>
    {
        public TimestampRepository(TimestampContext context) : base(context)
        {

        }

        //Overwrites can be made here.
    }
}
