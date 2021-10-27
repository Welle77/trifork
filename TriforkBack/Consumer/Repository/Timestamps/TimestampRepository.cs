using Consumer.DB;
using System;

namespace Consumer.Repository.Timestamps
{
    public class TimestampRepository : GenericRepository<Timestamp>, ITimestampRepository
    {
        public TimestampRepository(TimestampContext context) : base(context)
        {

        }

        public override void Add(Timestamp entity)
        {
            if (new DateTime().Subtract(entity.Stamp) < TimeSpan.FromMinutes(1))
                Context.Add(entity);
        }

        //Overwrites can be made here.
    }
}
