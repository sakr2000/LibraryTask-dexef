using LibraryTask_dexef.Application.Common.Exceptions;
using LibraryTask_dexef.Domain.Constants;
using LibraryTask_dexef.Shared.Enums;
using System.Diagnostics.CodeAnalysis;

namespace LibraryTask_dexef.Application.Common.Exceptions
{

    [ExcludeFromCodeCoverage]
    public static class UserException
    {
        public static FriendlyException UserAlreadyExistsException(string field)
            => new(ErrorCode.BadRequest, string.Format(UserErrorMessage.AlreadyExists, field), string.Format(UserErrorMessage.AlreadyExists, field));

        public static FriendlyException UserUnauthorizedException()
            => new(ErrorCode.Unauthorized, UserErrorMessage.Unauthorized, UserErrorMessage.Unauthorized);

        public static FriendlyException InternalException(Exception? exception)
            => new(ErrorCode.Internal, ErrorMessage.InternalError, ErrorMessage.InternalError, exception);

        public static FriendlyException BadRequestException(string errorMessage)
            => new(ErrorCode.BadRequest, errorMessage, errorMessage);
    }
}