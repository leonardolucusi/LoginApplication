using Microsoft.EntityFrameworkCore;

namespace LoginApplication
{
    public class UserService
    {
        private readonly Context _context;
        public UserService(Context context)
        {
            _context = context;
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            if(user != null) return true; 
            return false;
        }
    }
}
