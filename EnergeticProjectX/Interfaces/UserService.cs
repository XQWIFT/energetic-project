using EnergeticProjectX.interfaces;
using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Interfaces
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public User FindByLogin(string login)
        {
            var user = _repository.FindUserByLogin(login);
            return user;
        }
    }
}
