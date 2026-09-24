using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Users.Update
{
    public record UpdateUserNameCommand(Guid UserId, string UserName) : IRequest;
}