using AutoMapper;
using MediatR;
using System.Net;
using Todo.Application.Exceptions;
using Todo.Application.Repositories;
using Todo.Application.Services.Queries.User.GetAll;
using Todo.Application.Token;
using Todo.Core;

namespace Todo.Application.Services.Commands.User.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
       

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
           
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            string encryptedPassword = PasswordEncryptor.Encrpt(request.Password);
            var filteredItems = _userRepository.GetByFilter(x => x.Email == request.Email);
            var user = filteredItems.FirstOrDefault();

            //StringComparison.OrdinalIgnoreCase değeri, karşılaştırma işleminin büyü-küçük harf duyarlılığı olmaksızın gerçekleştirilmesini sağlar

            if (user == null || !string.Equals(user.Password, encryptedPassword, StringComparison.OrdinalIgnoreCase))
            {
                throw new NotFoundUserException();
            }

            else
            {
                var response = _mapper.Map<LoginUserCommandResponse>(user);
                return response;
            }         
           
        }
    }
}
