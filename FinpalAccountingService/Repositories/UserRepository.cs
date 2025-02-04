using FinpalAccountingService.Models;

namespace FinpalAccountingService.Repositories;

public class UserRepository {
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();  // Equivalent to save()
    }
    
}