using System.Diagnostics.CodeAnalysis;
using LibraryTask_dexef.Application.Common.Exceptions;
using LibraryTask_dexef.Domain.Constants;
using LibraryTask_dexef.Shared.Enums;

namespace libraryTask_dexef.Application.Common.Exceptions
{

    [ExcludeFromCodeCoverage]
    public static class AuthIdentityException
    {
        public static FriendlyException ThrowTokenNotExist()
            => throw new FriendlyException(ErrorCode.NotFound, AuthIdentityErrorMessage.TokenNotExistMessage, AuthIdentityErrorMessage.TokenNotExistMessage);

        public static FriendlyException ThrowTokenNotActive()
            => throw new FriendlyException(ErrorCode.BadRequest, AuthIdentityErrorMessage.TokenNotActiveMessage, AuthIdentityErrorMessage.TokenNotActiveMessage);

        public static FriendlyException ThrowAccountDoesNotExist()
            => throw new FriendlyException(ErrorCode.NotFound, AuthIdentityErrorMessage.AccountDoesNotExistMessage, AuthIdentityErrorMessage.AccountDoesNotExistMessage);

        public static FriendlyException ThrowLoginUnsuccessful()
            => throw new FriendlyException(ErrorCode.BadRequest, AuthIdentityErrorMessage.LoginUnsuccessfulMessage, AuthIdentityErrorMessage.LoginUnsuccessfulMessage);

        public static FriendlyException ThrowUsernameAvailable()
            => throw new FriendlyException(ErrorCode.NotFound, AuthIdentityErrorMessage.UsernameAvailableMessage, AuthIdentityErrorMessage.UsernameAvailableMessage);

        public static FriendlyException ThrowEmailAvailable()
            => throw new FriendlyException(ErrorCode.NotFound, AuthIdentityErrorMessage.EmailAvailableMessage, AuthIdentityErrorMessage.EmailAvailableMessage);

        public static FriendlyException ThrowRegisterUnsuccessful(string errors)
            => throw new FriendlyException(ErrorCode.BadRequest, AuthIdentityErrorMessage.RegisterUnsuccessfulMessage, errors);

        public static FriendlyException ThrowUserNotExist()
            => throw new FriendlyException(ErrorCode.NotFound, AuthIdentityErrorMessage.UserNotExistMessage, AuthIdentityErrorMessage.UserNotExistMessage);

        public static FriendlyException ThrowUpdateUnsuccessful(string errors)
            => throw new FriendlyException(ErrorCode.BadRequest, AuthIdentityErrorMessage.UpdateUnsuccessfulMessage, errors);

        public static FriendlyException ThrowDeleteUnsuccessful()
            => throw new FriendlyException(ErrorCode.BadRequest, AuthIdentityErrorMessage.DeleteUnsuccessfulMessage, AuthIdentityErrorMessage.DeleteUnsuccessfulMessage);

        public static FriendlyException ThrowEmailRequired()
            => throw new FriendlyException(ErrorCode.NotFound, AuthIdentityErrorMessage.EmailRequiredMessage, AuthIdentityErrorMessage.EmailRequiredMessage);

    }
}