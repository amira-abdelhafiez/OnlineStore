using MediatR;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.Users.Queries
{
    //public class GetEmployeeQuery : IRequest<ProductDTO>
    //{
    //    public int TargetEmployeeId { get; set; }

    //    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, ProductDTO>
    //    {
    //        IDbContext dbContext;
    //        public GetEmployeeQueryHandler(IDbContext dbContext)
    //        {
    //            this.dbContext = dbContext;
    //        }
    //        public async Task<ProductDTO> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    //        {
    //            ProductDTO employeeDTO = null;

    //            ProductDTO employee = await dbContext.Products.FindAsync(cancellationToken, request.TargetEmployeeId);
    //            if(employee != null)
    //            {
    //                employeeDTO = new EmployeeDTO { EmployeeId = employee.EmployeeId, EmpName = employee.EmpName };
    //            }

    //            return employeeDTO;                
    //        }


           
    //    }
    //}
}
