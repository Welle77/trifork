using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Utility
{
    class TimestampUtility
    {
        public static bool TimeStampShouldSave(DateTime dateTime, DateTime dateTime1)
        {

            if (dateTime1.Subtract(dateTime) > TimeSpan.FromMinutes(1)) return false;

            if (dateTime1.Second % 2 == 0) return true;

            return false;

        }

        public static bool TimeStampShouldPublish(DateTime dateTime, DateTime dateTime1)
        {

            return dateTime1.Subtract(dateTime) > TimeSpan.FromSeconds(1);

        }
    }
}
