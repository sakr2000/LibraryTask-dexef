using LibraryTask_dexef.Domain.Constants;
using LibraryTask_dexef.Shared.Enums;
using System.Diagnostics.CodeAnalysis;

namespace LibraryTask_dexef.Application.Common.Exceptions
{
    public class ProgramExeption
    {
        [ExcludeFromCodeCoverage]
        public static class ProgramException
        {
            public static FriendlyException AppsettingNotSetException()
                => new(ErrorCode.Internal, ErrorMessage.AppConfigurationMessage, ErrorMessage.InternalError);
        }

    }
}
