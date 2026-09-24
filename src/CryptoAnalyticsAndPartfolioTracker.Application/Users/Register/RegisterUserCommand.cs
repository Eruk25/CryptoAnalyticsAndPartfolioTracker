using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Users.Register
{
    public record RegisterUserCommand(string UserName, string Email, string Password) : IRequest;
}