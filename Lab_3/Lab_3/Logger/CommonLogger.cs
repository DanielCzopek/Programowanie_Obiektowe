using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Logger
{
    class CommonLogger : ILogger
    {
        private readonly ILogger[] loggers;
        //public CommonLogger(ILogger[] loggers => _loggers = loggers;
        // było na stronie więc przepisuje ale chyba nie potrzebne
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        

        public void Log(params string[] messages)
        {
            throw new NotImplementedException();
        }
    }
}

