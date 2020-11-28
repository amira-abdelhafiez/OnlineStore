using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Common.Interfaces
{
    public interface IPerformanceLogger
    {
        void Log(string requestName, long milliseconds, string username, string content, DateTime dateTime);
    }
}
