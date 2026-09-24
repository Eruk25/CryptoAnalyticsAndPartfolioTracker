using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.JwtGenerator;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.PasswordHasher;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

            if (user is null || !_passwordHasher.VerifyPassword(request.Password, user.HashPassword))
                throw new InvalidOperationException("Incorrect email or password");

            var jwt = _jwtGenerator.Generate(user);

            return jwt;
        }
    }
}