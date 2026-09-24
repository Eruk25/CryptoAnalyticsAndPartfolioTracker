using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Users.Update
{
    public class UpdateUserNameCommandHandler : IRequestHandler<UpdateUserNameCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserNameCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserNameCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);

            if (user is null)
                throw new NullReferenceException("User was not found");

            user.UserName = request.UserName;
        }
    }
}