using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.PasswordHasher;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with the same email already exists.");
            }

            var hashedPassword = _passwordHasher.HashPassword(request.Password);
            var newUser = new User(request.UserName, request.Email, hashedPassword);
            await _userRepository.CreateAsync(newUser, cancellationToken);
        }
    }
}