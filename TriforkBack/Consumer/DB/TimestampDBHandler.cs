using Consumer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.DB
{
    class TimestampDBHandler
    {
        private readonly IRepository<Timestamp> repository;

        public TimestampDBHandler(IRepository<Timestamp> repository)
        {
            this.repository = repository;

        }

        public async Task AddTimeStampAsync(Timestamp timeStamp)
        {
                await repository.Add(timeStamp);
        }
    }
}
