using Container_App.Data;
using Container_App.Model.Tokens;
using Container_App.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace Container_App.Repository.AuthRepository
{
    public class AuthRepository: IAuthRepository
    {
        private readonly MyDbContext _context;

        public AuthRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task<RefreshTokenModel> GetRefreshToken(string token)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token && !rt.IsRevoked);
        }

        public async Task SaveRefreshToken(RefreshTokenModel refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task RevokeRefreshToken(string token)
        {
            var refreshToken = await GetRefreshToken(token);
            if (refreshToken != null)
            {
                refreshToken.IsRevoked = true;
                _context.RefreshTokens.Update(refreshToken);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UserModel> GetUserByID(int Id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == Id);
        }
    }
}
