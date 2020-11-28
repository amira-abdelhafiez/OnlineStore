using MediatR;
using OnlineStore.Application.Common.Encryption;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.Users.Command
{

    public class RegisterUserCommand : IRequest<int>
    {
        public UserDTO User;
        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
        {
            private readonly IDbContext dbContext;
            private readonly IUserService userService;
            public RegisterUserCommandHandler(IDbContext dbContext
                , IUserService userService)
            {
                this.dbContext = dbContext;
                this.userService = userService;
            }

            public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                string hash = EncryptionLib.GetRandomKey(64);
                string encryptedPassword = EncryptionLib.Encrypt(request.User.Password , hash);
                Domain.Entities.Cart cart = new Domain.Entities.Cart()
                {
                    Products = new List<Domain.Entities.ProductCart>(),
                    Total = 0
                };
                dbContext.Carts.Add(cart);

                await dbContext.SaveChangesAsync(cancellationToken);
                Domain.Entities.User user = new Domain.Entities.User
                {
                    UserName = request.User.UserName,
                    Password = encryptedPassword,
                    Salt = hash,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Email = request.User.Email,
                    IsDeleted = false,
                    EmailConfirmed = true,
                    IsLocked = false,
                    RoleId = 2,
                    CartId = cart.CartId
                };
                dbContext.Users.Add(user);
                request.User.UserId = user.UserId;
                
                return await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
