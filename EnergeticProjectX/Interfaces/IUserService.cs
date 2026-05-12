using EnergeticProjectX.Objects;

namespace EnergeticProjectX.interfaces
{
    public interface IUserService
    {
        public User FindByLogin(string login);
    }
}
