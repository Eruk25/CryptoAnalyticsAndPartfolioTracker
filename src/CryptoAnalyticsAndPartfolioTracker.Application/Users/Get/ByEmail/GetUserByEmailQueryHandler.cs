using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Users.Get
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUserRepository _userRepositor;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepositor = userRepository;
        }

        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepositor.GetUserByEmailAsync(request.Email, cancellationToken);

            if (user is null)
                throw new NullReferenceException("User was not found");

            return user;
        }
    }
}