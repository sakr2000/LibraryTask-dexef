using AutoMapper;
using LibraryTask_dexef.Application;
using LibraryTask_dexef.Application.Common.Interfaces;
using LibraryTask_dexef.Application.Common.Utilities;
using LibraryTask_dexef.Infrastructure.Interface;
using LibraryTask_dexef.Application.Common.Exceptions;
using LibraryTask_dexef.Domain.Constants;
using LibraryTask_dexef.Shared.Models.User;

namespace LibraryTask_dexef.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICookieService _cookieService;
        private readonly ITokenService _tokenService;
        private readonly ICurrentUser _currentUser;
        private readonly IUserRepository _userRepository;

        public AuthService(IUnitOfWork unitOfWork,
            IMapper mapper,
            ICookieService cookieService,
            ITokenService tokenService,
            ICurrentUser currentUser,
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cookieService = cookieService;
            _tokenService = tokenService;
            _currentUser = currentUser;
            _userRepository = userRepository;
        }

        public async Task<UserSignInResponse> SignIn(UserSignInRequest request)
        {
            var user = await _unitOfWork.UserRepository.FirstOrDefaultAsync(x => x.UserName == request.UserName)
                ?? throw UserException.BadRequestException(UserErrorMessage.UserNotExist);

            if (!StringHelper.Verify(request.Password, StringHelper.Hash(user.Password)))
            {
                throw UserException.BadRequestException(UserErrorMessage.PasswordIncorrect);
            }

            var token = _tokenService.GenerateToken(user);
            _cookieService.Set(token);

            var response = _mapper.Map<UserSignInResponse>(user);
            response.Token = token;

            return response;
        }

        public async Task<UserSignUpResponse> SignUp(UserSignUpRequest request, CancellationToken token)
        {
            var isUserNameExist = await _unitOfWork.UserRepository.AnyAsync(x => x.UserName == request.UserName);
            if (isUserNameExist)
                throw UserException.UserAlreadyExistsException(request.UserName);

            var isEmailExist = await _unitOfWork.UserRepository.AnyAsync(x => x.UserName == request.Email);
            if (isEmailExist)
                throw UserException.UserAlreadyExistsException(request.Email);

            var user = _mapper.Map<ApplicationUser>(request);
            user.Password = user.Password.Hash();
            await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.UserRepository.AddAsync(user), token);

            var response = _mapper.Map<UserSignUpResponse>(user);

            return response;
        }

        public void Logout()
        {
            try
            {
                _ = _cookieService.Get();
                _cookieService.Delete();
            }
            catch { }
        }

        public async Task<UserProfileResponse> GetProfile()
        {
            var userId = _currentUser.GetCurrentUserId();
            var user = await _userRepository.GetByIdAsync(userId);

            var result = _mapper.Map<UserProfileResponse>(user);
            return result;
        }

        public async Task<string> RefreshToken()
        {
            var user = await _userRepository.GetByIdAsync(_currentUser.GetCurrentUserId());
            var accessToken = _tokenService.GenerateToken(user);
            _cookieService.Set(accessToken);

            return accessToken;
        }
    }
}