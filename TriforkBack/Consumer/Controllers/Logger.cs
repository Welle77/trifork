using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Controllers
{
    interface ILogger
    {
        void Log(string String);
    }
    class Logger : ILogger
    {
        public void Log(string String)
        {
            Console.WriteLine(String);
        }
    }
}
