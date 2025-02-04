using FinpalAccountingService.Models;
using FinpalAccountingService.Repositories;

namespace FinpalAccountingService.Services;

public class UserService {
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void CreateUser(string name)
    {
        var user = new User { Nom = name };
        _userRepository.AddUser(user);
    }
}