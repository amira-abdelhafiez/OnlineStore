using MediatR;
using OnlineStore.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.Common.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch stopwatch;
        private readonly IPerformanceLogger performanceLogger;
        public PerformanceBehavior(IPerformanceLogger performanceLogger)
        {
            this.performanceLogger = performanceLogger;

            stopwatch = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // logic to measure performance.....
            stopwatch.Start();
            var response = await next();
            stopwatch.Stop();

            string requestName = typeof(TRequest).Name;

            if(stopwatch.ElapsedMilliseconds > 1)
            {
                performanceLogger.Log(requestName, stopwatch.ElapsedMilliseconds, "", request.ToString(), DateTime.UtcNow);
            }

            return response;
        }
    }
}
