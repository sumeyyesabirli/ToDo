using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;
using Todo.Core;

namespace Todo.Application.Services.Commands.User.Insert
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            
            string hashedPassword = PasswordEncryptor.Encrpt(request.Password);         
            var map = _mapper.Map<Core.Entities.User>(request);
            map.Password = hashedPassword;            
            var userRepo = await _userRepository.AddAsync(map);
            await _userRepository.SaveAsync();
            return true;
        }
    }
}
