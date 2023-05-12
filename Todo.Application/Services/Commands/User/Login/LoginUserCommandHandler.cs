using AutoMapper;
using MediatR;
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

            var filteredItems = _userRepository.GetByFilter(x => x.Email == request.Email && x.Password == request.Password);
            var user = filteredItems.FirstOrDefault();
            if (user == null)
            {
                throw new NotFoundUserException();

            }
            else
            {
                var response = _mapper.Map<LoginUserCommandResponse>(user);
                return response;
            }


            // var filteredItems = _userRepository.GetByFilter(x => x.Email == request.Email && x.Password == request.Password);
            // var map = _mapper.Map<Core.Entities.User>(filteredItems);
            // return Task.FromResult(map);
        }
    }
}
