using MyMovieApi.Core.Helper;
using MyMovieApi.Core.Interfaces;
using MyMovieApi.Core.Models.Requests;
using MyMovieApi.Core.Models.Response;
using Serilog;

namespace MyMovieApi.Core.Handlers
{
    public class AuthHandler
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public AuthHandler(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public async Task<Result<LoginResponse>> Login(LoginRequest request)
        {
            var result = new Result<LoginResponse>();

            //TODO: Validação da request


            try
            {
                var user = await _userService.GetVerifiedUserOrFailAsync(request.Email, request.Password);
                var token = _authService.GenerateToken(user);
                result.Value = new LoginResponse()
                {
                    UserId = user.Id,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "<{EventoId}> - Falha ao completar login", this.GetType().Name);
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}