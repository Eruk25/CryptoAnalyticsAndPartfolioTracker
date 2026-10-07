using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions;
using CryptoAnalyticsAndPartfolioTracker.Application.Users.DTOs;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Users.Get.Profile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, UserProfile>
    {
        private readonly IUserRepository _userRepository;

        public GetProfileQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserProfile> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new InvalidOperationException(nameof(request));

            var user = await _userRepository.GetUserByIdAsync(request.UserId);

            if (user is null)
                throw new ArgumentNullException("User was not found");

            return new UserProfile(user.UserName, user.Email);
        }
    }
}