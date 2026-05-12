using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Interfaces
{
    public interface IUserRepository
    {
        User FindUserByLogin(string login);
    }
}
