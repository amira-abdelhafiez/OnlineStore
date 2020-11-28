using MediatR;
using OnlineStore.Application.Common.Encryption;
using OnlineStore.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.Users.Command
{
    public class LoginUserCommand : IRequest<long>
    {
        public UserDTO User;
        public bool RemeberMe;
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, long>
        {
            private readonly IDbContext dbContext;
            private readonly IUserService userService;
            public LoginUserCommandHandler(IDbContext dbContext
                , IUserService userService)
            {
                this.dbContext = dbContext;
                this.userService = userService;
            }

            public async Task<long> Handle(LoginUserCommand request , CancellationToken cancellationToken)
            {
                long status = 0;
                var result1 = dbContext.Users.Where(u => u.UserName.Equals(request.User.UserName)).FirstOrDefault();
                
                var result = result1 != null ? await dbContext.Users.FindAsync(cancellationToken ,  result1.UserId ) : null;
                if(result != null)
                {
                    string decryptedPassword = EncryptionLib.Decrypt(result.Password, result.Salt);
                    if (decryptedPassword.Equals(request.User.Password))
                    {
                        status = result.UserId;
                        request.User.CreatedAt = result.CreatedAt;
                        request.User.Email = result.Email;
                        request.User.UserId = result.UserId;
                        request.User.UserName = result.UserName;
                        request.User.UserRole = new Roles.RoleDTO() { RoleId = result.RoleId , RoleName = result.Role.RoleName };
                        userService.AddUserSession(request.User);
                        if (request.RemeberMe)
                        {
                            userService.UpdateCookie(request.User);
                        }
                    }
                }
                return status;   
            }
        }
    }
}
