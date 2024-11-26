﻿using Container_App.Model.Tokens;

namespace Container_App.Services.AuthService
{
    public interface IAuthService
    {
        Task<Token> Login(string username, string password);
        Task<Token> RefreshToken(string refreshToken);
    }
}
