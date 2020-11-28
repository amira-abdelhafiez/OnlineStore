using MediatR;
using Ninject;
using OnlineStore.Application.Users;
using OnlineStore.Application.Users.Command;
using OnlineStore.Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application
{
    public static class DependancyInjection
    {
        public static void BindApplication(this IKernel kernel)
        {
            
        }
    }
}
