using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.DB
{
    public class Timestamp
    {


        public Timestamp(DateTime stamp)
        {
            Stamp = stamp;
        }

        public int TimeStampID { get; set; }
        public DateTime Stamp { get; set; }

    }
}
