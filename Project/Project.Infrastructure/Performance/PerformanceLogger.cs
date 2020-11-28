using OnlineStore.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.Performance
{
    public class PerformanceLogger : IPerformanceLogger
    {
        public void Log(string requestName, long milliseconds, string username, string content, DateTime dateTime)
        {
            Debug.Print($"Online Store Longtime running request: {requestName} [time:{milliseconds} ms]\r\n[username:{username}]\r\n[Content:{content}]");
        }
    }
}
